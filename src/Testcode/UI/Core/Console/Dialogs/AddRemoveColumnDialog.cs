// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AddRemoveColumnDialog.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[lucyra] 8/30/2005 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Dialogs
{
    #region Using directives

    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console;
    using System.Drawing;

    #endregion
    
    #region Interface Definition - IAddRemoveColumnDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAddRemoveColumnDialogControls, for AddRemoveColumnDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[lucyra] 8/30/2005 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAddRemoveColumnDialogControls
    {
        /// <summary>
        /// Read-only property to access SelectedColumnsStaticControl
        /// </summary>
        StaticControl SelectedColumnsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AvailableColumnsStaticControl
        /// </summary>
        StaticControl AvailableColumnsStaticControl
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
        /// Read-only property to access RemoveAllButton
        /// </summary>
        Button RemoveAllButton
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
        /// Read-only property to access AddAllButton
        /// </summary>
        Button AddAllButton
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
        /// Read-only property to access DataGridView1
        /// </summary>
        PropertyGridView DataGridView1
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AvailableColumnsListBox
        /// </summary>
        ListBox AvailableColumnsListBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DialogToolstrip
        /// </summary>
        Toolbar DialogToolstrip
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
    /// 	[lucyra] 8/30/2005 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class AddRemoveColumnDialog : Dialog, IAddRemoveColumnDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to SelectedColumnsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectedColumnsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AvailableColumnsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAvailableColumnsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to Button0 of type Button
        /// </summary>
        private Button cachedButton0;
        
        /// <summary>
        /// Cache to hold a reference to Button1 of type Button
        /// </summary>
        private Button cachedButton1;
        
        /// <summary>
        /// Cache to hold a reference to RemoveAllButton of type Button
        /// </summary>
        private Button cachedRemoveAllButton;
        
        /// <summary>
        /// Cache to hold a reference to RemoveButton of type Button
        /// </summary>
        private Button cachedRemoveButton;
        
        /// <summary>
        /// Cache to hold a reference to AddAllButton of type Button
        /// </summary>
        private Button cachedAddAllButton;
        
        /// <summary>
        /// Cache to hold a reference to AddButton of type Button
        /// </summary>
        private Button cachedAddButton;
        
        /// <summary>
        /// Cache to hold a reference to DataGridView1 of type PropertyGridView
        /// </summary>
        private PropertyGridView cachedDataGridView1;
        
        /// <summary>
        /// Cache to hold a reference to AvailableColumnsListBox of type ListBox
        /// </summary>
        private ListBox cachedAvailableColumnsListBox;
        
        /// <summary>
        /// Cache to hold a reference to DialogToolstrip of type Toolbar
        /// </summary>
        private Toolbar cachedDialogToolstrip;             
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of AddRemoveColumnDialog of type App
        /// </param>
        /// <history>
        /// 	[lucyra] 8/30/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AddRemoveColumnDialog(ConsoleApp app)
            : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IAddRemoveColumnDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[lucyra] 8/30/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAddRemoveColumnDialogControls Controls
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
        ///  Exposes access to the SelectedColumnsStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 8/30/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddRemoveColumnDialogControls.SelectedColumnsStaticControl
        {
            get
            {
                if ((this.cachedSelectedColumnsStaticControl == null))
                {
                    this.cachedSelectedColumnsStaticControl = new StaticControl(this, AddRemoveColumnDialog.ControlIDs.SelectedColumnsStaticControl);
                }
                return this.cachedSelectedColumnsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AvailableColumnsStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 8/30/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddRemoveColumnDialogControls.AvailableColumnsStaticControl
        {
            get
            {
                if ((this.cachedAvailableColumnsStaticControl == null))
                {
                    this.cachedAvailableColumnsStaticControl = new StaticControl(this, AddRemoveColumnDialog.ControlIDs.AvailableColumnsStaticControl);
                }
                return this.cachedAvailableColumnsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Button0 control
        /// </summary>
        /// <history>
        /// 	[lucyra] 8/30/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddRemoveColumnDialogControls.Button0
        {
            get
            {
                if ((this.cachedButton0 == null))
                {
                    this.cachedButton0 = new Button(this, AddRemoveColumnDialog.ControlIDs.Button0);
                }
                return this.cachedButton0;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Button1 control
        /// </summary>
        /// <history>
        /// 	[lucyra] 8/30/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddRemoveColumnDialogControls.Button1
        {
            get
            {
                if ((this.cachedButton1 == null))
                {
                    this.cachedButton1 = new Button(this, AddRemoveColumnDialog.ControlIDs.Button1);
                }
                return this.cachedButton1;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RemoveAllButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 8/30/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddRemoveColumnDialogControls.RemoveAllButton
        {
            get
            {
                if ((this.cachedRemoveAllButton == null))
                {
                    this.cachedRemoveAllButton = new Button(this, AddRemoveColumnDialog.ControlIDs.RemoveAllButton);
                }
                return this.cachedRemoveAllButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RemoveButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 8/30/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddRemoveColumnDialogControls.RemoveButton
        {
            get
            {
                if ((this.cachedRemoveButton == null))
                {
                    this.cachedRemoveButton = new Button(this, AddRemoveColumnDialog.ControlIDs.RemoveButton);
                }
                return this.cachedRemoveButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddAllButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 8/30/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddRemoveColumnDialogControls.AddAllButton
        {
            get
            {
                if ((this.cachedAddAllButton == null))
                {
                    this.cachedAddAllButton = new Button(this, AddRemoveColumnDialog.ControlIDs.AddAllButton);
                }
                return this.cachedAddAllButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 8/30/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddRemoveColumnDialogControls.AddButton
        {
            get
            {
                if ((this.cachedAddButton == null))
                {
                    this.cachedAddButton = new Button(this, AddRemoveColumnDialog.ControlIDs.AddButton);
                }
                return this.cachedAddButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DataGridView1 control
        /// </summary>
        /// <history>
        /// 	[lucyra] 8/30/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        PropertyGridView IAddRemoveColumnDialogControls.DataGridView1
        {
            get
            {
                if ((this.cachedDataGridView1 == null))
                {
                    this.cachedDataGridView1 = new PropertyGridView(this, AddRemoveColumnDialog.ControlIDs.DataGridView1);
                }
                return this.cachedDataGridView1;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AvailableColumnsListBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 8/30/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListBox IAddRemoveColumnDialogControls.AvailableColumnsListBox
        {
            get
            {                
                if ((this.cachedAvailableColumnsListBox == null))
                {
                    this.cachedAvailableColumnsListBox = new ListBox(this, AddRemoveColumnDialog.ControlIDs.AvailableColumnsListBox);
                }
                return this.cachedAvailableColumnsListBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DialogToolstrip control
        /// </summary>
        /// <history>
        /// 	[lucyra] 8/30/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IAddRemoveColumnDialogControls.DialogToolstrip
        {
            get
            {
                if ((this.cachedDialogToolstrip == null))
                {
                    this.cachedDialogToolstrip = new Toolbar(this);
                }
                return this.cachedDialogToolstrip;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on Save and Close button
        /// </summary>
        /// <history>
        /// 	[lucyra] 8/30/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSaveAndClose()
        {
            try
            {
                this.Controls.DialogToolstrip[Strings.SaveAndClose].Click();
                UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow);
                CoreManager.MomConsole.MainWindow.WaitForResponse();
            }
            catch (Maui.Core.Window.Exceptions.InvalidHWndException)
            {
                //Currently hitting this issue, even though dialog is closing.
                Utilities.LogMessage("Invalid HWnd was hit, but should be ok");
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click TitleBar close button
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/16/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public new virtual void ClickTitleBarClose()
        {
            try
            {
                this.AccessibleObject.Window.ClickTitleBarClose();
                UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow);
                CoreManager.MomConsole.MainWindow.WaitForResponse();
            }
            catch (Maui.Core.Window.Exceptions.InvalidHWndException)
            {
                //Currently hitting this issue, even though dialog is closing.
                Utilities.LogMessage("Invalid HWnd was hit, but should be ok");
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Button0
        /// </summary>
        /// <history>
        /// 	[lucyra] 8/30/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickButton0()
        {
            this.Controls.Button0.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Button1
        /// </summary>
        /// <history>
        /// 	[lucyra] 8/30/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickButton1()
        {
            this.Controls.Button1.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button RemoveAll
        /// </summary>
        /// <history>
        /// 	[lucyra] 8/30/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickRemoveAll()
        {
            this.Controls.RemoveAllButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Remove
        /// </summary>
        /// <history>
        /// 	[lucyra] 8/30/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickRemove()
        {
            this.Controls.RemoveButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button AddAll
        /// </summary>
        /// <history>
        /// 	[lucyra] 8/30/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAddAll()
        {
            this.Controls.AddAllButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Add
        /// </summary>
        /// <history>
        /// 	[lucyra] 8/30/2005 Created
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
        ///  <param name="app">ConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[lucyra] 8/30/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(
                    Strings.DialogTitle,
                    StringMatchSyntax.ExactMatch,
                    WindowClassNames.WinForms10Window8,
                    StringMatchSyntax.WildCard,
                    app,
                    Timeout);
            }

            catch (Exceptions.WindowNotFoundException ex)
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
                        tempWindow = new Window(
                            Strings.DialogTitle + "*",
                            StringMatchSyntax.ExactMatch,
                            WindowClassNames.WinForms10Window8,
                            StringMatchSyntax.WildCard,
                            app,
                            Timeout);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage(
                            "Attempt " + numberOfTries + " of " + MaxTries);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find window with title:  '" +
                        Strings.DialogTitle + "'");

                    // throw the existing WindowNotFound exception
                    throw ex;
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
        /// 	[lucyra] 8/30/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// <summary>
            /// Contains resource string for Save and Close button
            /// </summary>
            private const string ResourceSaveAndClose = ";&Save and Close;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.ColumnPickerDialog;saveButton.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle = "Select Columns";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectedColumns
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectedColumns = ";Selected Colum&ns;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterp" +
                "riseManagement.Mom.UI.ColumnPickerControl;selectedColumnsLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AvailableColumns
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAvailableColumns = ";Availa&ble Columns;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enter" +
                "priseManagement.Mom.UI.ColumnPickerControl;availableColumnsLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RemoveAll
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRemoveAll = ";<< Rem&ove all;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpris" +
                "eManagement.Mom.UI.ColumnPickerControl;removeAllButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Remove
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRemove = ";< &Remove;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMana" +
                "gement.Mom.Internal.UI.Administration.DiscoveryResults;buttonRemove.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AddAll
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAddAll = ";Add a&ll >>;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMa" +
                "nagement.Mom.UI.ColumnPickerControl;addAllButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Add
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdd = ";&Add >;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagem" +
                "ent.Mom.Internal.UI.Administration.DiscoveryResults;buttonAdd.Text";
            
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
            /// Contains resource string for:  DialogToolstrip
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogToolstrip = ";toolStrip1;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagem" +
                "ent.Mom.Internal.UI.PageFrameworks.SheetFramework;stripTop.Text";
            #endregion
            
            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitle;

            /// <summary>
            /// Caches the translated resource fir Save and Close
            /// </summary>
            private static string cachedSaveAndClose;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectedColumns
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectedColumns;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AvailableColumns
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAvailableColumns;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RemoveAll
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRemoveAll;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Remove
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRemove;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AddAll
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAddAll;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Add
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdd;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DataGridView1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDataGridView1;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DialogToolstrip
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogToolstrip;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 8/30/2005 Created
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
            /// Exposes access to the SelectedColumns translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 8/30/2005 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectedColumns
            {
                get
                {
                    if ((cachedSelectedColumns == null))
                    {
                        cachedSelectedColumns = CoreManager.MomConsole.GetIntlStr(ResourceSelectedColumns);
                    }
                    return cachedSelectedColumns;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AvailableColumns translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 8/30/2005 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AvailableColumns
            {
                get
                {
                    if ((cachedAvailableColumns == null))
                    {
                        cachedAvailableColumns = CoreManager.MomConsole.GetIntlStr(ResourceAvailableColumns);
                    }
                    return cachedAvailableColumns;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RemoveAll translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 8/30/2005 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RemoveAll
            {
                get
                {
                    if ((cachedRemoveAll == null))
                    {
                        cachedRemoveAll = CoreManager.MomConsole.GetIntlStr(ResourceRemoveAll);
                    }
                    return cachedRemoveAll;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Remove translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 8/30/2005 Created
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
            /// Exposes access to the AddAll translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 8/30/2005 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AddAll
            {
                get
                {
                    if ((cachedAddAll == null))
                    {
                        cachedAddAll = CoreManager.MomConsole.GetIntlStr(ResourceAddAll);
                    }
                    return cachedAddAll;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Add translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 8/30/2005 Created
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
            /// Exposes access to the DataGridView1 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 8/30/2005 Created
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
            /// Exposes access to the DialogToolstrip translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 8/30/2005 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogToolstrip
            {
                get
                {
                    if ((cachedDialogToolstrip == null))
                    {
                        cachedDialogToolstrip = CoreManager.MomConsole.GetIntlStr(ResourceDialogToolstrip);
                    }
                    return cachedDialogToolstrip;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Save and Close translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 8/30/2005 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SaveAndClose
            {
                get
                {
                    if ((cachedSaveAndClose == null))
                    {
                        cachedSaveAndClose = CoreManager.MomConsole.GetIntlStr(ResourceSaveAndClose);
                    }
                    return cachedSaveAndClose;
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
        /// 	[lucyra] 8/30/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for SelectedColumnsStaticControl
            /// </summary>
            public const string SelectedColumnsStaticControl = "selectedColumnsLabel";
            
            /// <summary>
            /// Control ID for AvailableColumnsStaticControl
            /// </summary>
            public const string AvailableColumnsStaticControl = "availableColumnsLabel";
            
            /// <summary>
            /// Control ID for Button0
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Button0 = "upButton";
            
            /// <summary>
            /// Control ID for Button1
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Button1 = "downButton";
            
            /// <summary>
            /// Control ID for RemoveAllButton
            /// </summary>
            public const string RemoveAllButton = "removeAllButton";
            
            /// <summary>
            /// Control ID for RemoveButton
            /// </summary>
            public const string RemoveButton = "removeButton";
            
            /// <summary>
            /// Control ID for AddAllButton
            /// </summary>
            public const string AddAllButton = "addAllButton";
            
            /// <summary>
            /// Control ID for AddButton
            /// </summary>
            public const string AddButton = "addButton";
            
            /// <summary>
            /// Control ID for DataGridView1
            /// </summary>
            public const string DataGridView1 = "selectedColumnsGrid";
            
            /// <summary>
            /// Control ID for AvailableColumnsListBox
            /// </summary>
            public const string AvailableColumnsListBox = "availableColumnsListbox";
            
            /// <summary>
            /// Control ID for DialogToolstrip
            /// </summary>
            public const string DialogToolstrip = "mainToolstrip";
        }
        #endregion
    }
}
