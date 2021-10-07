// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ClassSearchDialog.cs">
// 	Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[nathd] 2/9/2009 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IClassSearchDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IClassSearchDialogControls, for ClassSearchDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[nathd] 2/9/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IClassSearchDialogControls
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
        /// Read-only property to access CompletionComboBox
        /// </summary>
        ComboBox CompletionComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access GeneralPropertiesTextBox
        /// </summary>
        TextBox GeneralPropertiesTextBox
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
        /// Read-only property to access ToAddClassesSearchForTheClassByNameAndManagementPackAndThenAddThemToTheSelectedObjectsListStaticCont
        /// </summary>
        StaticControl ToAddClassesSearchForTheClassByNameAndManagementPackAndThenAddThemToTheSelectedObjectsListStaticCont
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
        /// Read-only property to access CancelButton2
        /// </summary>
        Button CancelButton2
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
    /// 	[nathd] 2/9/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ClassSearchDialog : Dialog, IClassSearchDialogControls
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
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to CompletionComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedCompletionComboBox;
        
        /// <summary>
        /// Cache to hold a reference to GeneralPropertiesTextBox of type TextBox
        /// </summary>
        private TextBox cachedGeneralPropertiesTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ManagementPackStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedManagementPackStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to FilterByOptionalStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedFilterByOptionalStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ToAddClassesSearchForTheClassByNameAndManagementPackAndThenAddThemToTheSelectedObjectsListStaticCont of type StaticControl
        /// </summary>
        private StaticControl cachedToAddClassesSearchForTheClassByNameAndManagementPackAndThenAddThemToTheSelectedObjectsListStaticCont;
        
        /// <summary>
        /// Cache to hold a reference to SearchButton of type Button
        /// </summary>
        private Button cachedSearchButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton2 of type Button
        /// </summary>
        private Button cachedCancelButton2;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ClassSearchDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[nathd] 2/9/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ClassSearchDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IClassSearchDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[nathd] 2/9/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IClassSearchDialogControls Controls
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
        ///  Routine to set/get the text in control Completion
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[nathd] 2/9/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string CompletionText
        {
            get
            {
                return this.Controls.CompletionComboBox.Text;
            }
            
            set
            {
                this.Controls.CompletionComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control GeneralProperties
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[nathd] 2/9/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string GeneralPropertiesText
        {
            get
            {
                return this.Controls.GeneralPropertiesTextBox.Text;
            }
            
            set
            {
                this.Controls.GeneralPropertiesTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AvailableItemsListView control
        /// </summary>
        /// <history>
        /// 	[nathd] 2/9/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IClassSearchDialogControls.AvailableItemsListView
        {
            get
            {
                if ((this.cachedAvailableItemsListView == null))
                {
                    this.cachedAvailableItemsListView = new ListView(this, new QID(";[UIA]AutomationId ='" + ClassSearchDialog.ControlIDs.AvailableItemsListView + "'"));
                }
                
                return this.cachedAvailableItemsListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AvailableItemsStaticControl control
        /// </summary>
        /// <history>
        /// 	[nathd] 2/9/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IClassSearchDialogControls.AvailableItemsStaticControl
        {
            get
            {
                if ((this.cachedAvailableItemsStaticControl == null))
                {
                    this.cachedAvailableItemsStaticControl = new StaticControl(this, ClassSearchDialog.ControlIDs.AvailableItemsStaticControl);
                }
                
                return this.cachedAvailableItemsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[nathd] 2/9/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IClassSearchDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ClassSearchDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[nathd] 2/9/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IClassSearchDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, ClassSearchDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CompletionComboBox control
        /// </summary>
        /// <history>
        /// 	[nathd] 2/9/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IClassSearchDialogControls.CompletionComboBox
        {
            get
            {
                if ((this.cachedCompletionComboBox == null))
                {
                    this.cachedCompletionComboBox = new ComboBox(this, ClassSearchDialog.ControlIDs.CompletionComboBox);
                }
                
                return this.cachedCompletionComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralPropertiesTextBox control
        /// </summary>
        /// <history>
        /// 	[nathd] 2/9/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IClassSearchDialogControls.GeneralPropertiesTextBox
        {
            get
            {
                if ((this.cachedGeneralPropertiesTextBox == null))
                {
                    this.cachedGeneralPropertiesTextBox = new TextBox(this, ClassSearchDialog.ControlIDs.GeneralPropertiesTextBox);
                }
                
                return this.cachedGeneralPropertiesTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementPackStaticControl control
        /// </summary>
        /// <history>
        /// 	[nathd] 2/9/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IClassSearchDialogControls.ManagementPackStaticControl
        {
            get
            {
                if ((this.cachedManagementPackStaticControl == null))
                {
                    this.cachedManagementPackStaticControl = new StaticControl(this, ClassSearchDialog.ControlIDs.ManagementPackStaticControl);
                }
                
                return this.cachedManagementPackStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FilterByOptionalStaticControl control
        /// </summary>
        /// <history>
        /// 	[nathd] 2/9/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IClassSearchDialogControls.FilterByOptionalStaticControl
        {
            get
            {
                if ((this.cachedFilterByOptionalStaticControl == null))
                {
                    this.cachedFilterByOptionalStaticControl = new StaticControl(this, ClassSearchDialog.ControlIDs.FilterByOptionalStaticControl);
                }
                
                return this.cachedFilterByOptionalStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToAddClassesSearchForTheClassByNameAndManagementPackAndThenAddThemToTheSelectedObjectsListStaticCont control
        /// </summary>
        /// <history>
        /// 	[nathd] 2/9/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IClassSearchDialogControls.ToAddClassesSearchForTheClassByNameAndManagementPackAndThenAddThemToTheSelectedObjectsListStaticCont
        {
            get
            {
                if ((this.cachedToAddClassesSearchForTheClassByNameAndManagementPackAndThenAddThemToTheSelectedObjectsListStaticCont == null))
                {
                    this.cachedToAddClassesSearchForTheClassByNameAndManagementPackAndThenAddThemToTheSelectedObjectsListStaticCont = new StaticControl(this, ClassSearchDialog.ControlIDs.ToAddClassesSearchForTheClassByNameAndManagementPackAndThenAddThemToTheSelectedObjectsListStaticCont);
                }
                
                return this.cachedToAddClassesSearchForTheClassByNameAndManagementPackAndThenAddThemToTheSelectedObjectsListStaticCont;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SearchButton control
        /// </summary>
        /// <history>
        /// 	[nathd] 2/9/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IClassSearchDialogControls.SearchButton
        {
            get
            {
                if ((this.cachedSearchButton == null))
                {
                    this.cachedSearchButton = new Button(this, ClassSearchDialog.ControlIDs.SearchButton);
                }

                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.cachedSearchButton, Mom.Test.UI.Core.Common.Constants.OneMinute);

                return this.cachedSearchButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton2 control
        /// </summary>
        /// <history>
        /// 	[nathd] 2/9/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IClassSearchDialogControls.CancelButton2
        {
            get
            {
                if ((this.cachedCancelButton2 == null))
                {
                    this.cachedCancelButton2 = new Button(this, ClassSearchDialog.ControlIDs.CancelButton2);
                }
                
                return this.cachedCancelButton2;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[nathd] 2/9/2009 Created
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
        /// 	[nathd] 2/9/2009 Created
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
        /// 	[nathd] 2/9/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSearch()
        {
            this.Controls.SearchButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel2
        /// </summary>
        /// <history>
        /// 	[nathd] 2/9/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel2()
        {
            this.Controls.CancelButton2.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">MomConsoleApp owning the dialog.</param>
        /// <history>
        /// 	[nathd] 2/9/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
            }
            catch (Exceptions.WindowNotFoundException windowNotFound)
            {
                // Reset the window reference
                tempWindow = null;

                // Maximum number of tries to find window
                int maxTries = 5;

                // Try several more times to find the window
                for (int numberOfTries = 0; ((null == tempWindow) 
                            && (numberOfTries < maxTries)); numberOfTries = (numberOfTries + 1))
                {
                    try
                    {
                        // Try to locate an existing instance of the window
                        tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.WildCard);

                        // Wait for the window to become ready
                        UISynchronization.WaitForUIObjectReady(tempWindow, Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException )
                    {
                        // log the unsuccessful attempt

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }
                
                // check for success
                if ((null == tempWindow))
                {
                    // log the failure

                    // rethrow the original exception
                    throw windowNotFound;
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
        /// 	[nathd] 2/9/2009 Created
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
            private const string ResourceDialogTitle = ";Class Search;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Dialogs.PickerDialogs.ClassSimpleChooserDialog;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AvailableItems
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAvailableItems = ";Available items;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseMa" +
                "nagement.Mom.Internal.UI.Controls.SimpleChooserDialog;mainChooserControl.Caption" +
                "Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";&Cancel;ManagedString;Corgent.Diagramming.Dom.dll;Corgent.Diagramming.Dom.Diagra" +
                "mTemplateProperties;cancelButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";&OK;ManagedString;Corgent.Diagramming.Dom.dll;Corgent.Diagramming.Dom.DiagramTem" +
                "plateProperties;okButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ManagementPack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceManagementPack = ";&Management pack:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterp" +
                "riseManagement.Mom.Internal.UI.Dialogs.PickerDialogs.GroupClassPickerControlBase" +
                ";label3.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  FilterByOptional
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFilterByOptional = ";&Filter by: (optional);ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.E" +
                "nterpriseManagement.Mom.Internal.UI.Dialogs.PickerDialogs.GroupClassPickerContro" +
                "lBase;label2.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ToAddClassesSearchForTheClassByNameAndManagementPackAndThenAddThemToTheSelectedObjectsList
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceToAddClassesSearchForTheClassByNameAndManagementPackAndThenAddThemToTheSelectedObjectsList = @";To add classes, search for the class by name and management pack and then add them to the selected objects list.;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Dialogs.PickerDialogs.ClassPickerControl;$this.DescriptionText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Search
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSearch = ";&Search;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.Di" +
                "alogs.MPCatalogDialog;searchButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel2 = ";C&ancel;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement" +
                ".Mom.Internal.UI.AsyncChooserDialogItemProvider;cancelButton.Text";
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
            /// Caches the translated resource string for:  ToAddClassesSearchForTheClassByNameAndManagementPackAndThenAddThemToTheSelectedObjectsList
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedToAddClassesSearchForTheClassByNameAndManagementPackAndThenAddThemToTheSelectedObjectsList;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Search
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSearch;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel2;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 2/9/2009 Created
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
            /// 	[nathd] 2/9/2009 Created
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
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 2/9/2009 Created
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
            /// 	[nathd] 2/9/2009 Created
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
            /// 	[nathd] 2/9/2009 Created
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
            /// 	[nathd] 2/9/2009 Created
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
            /// Exposes access to the ToAddClassesSearchForTheClassByNameAndManagementPackAndThenAddThemToTheSelectedObjectsList translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 2/9/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ToAddClassesSearchForTheClassByNameAndManagementPackAndThenAddThemToTheSelectedObjectsList
            {
                get
                {
                    if ((cachedToAddClassesSearchForTheClassByNameAndManagementPackAndThenAddThemToTheSelectedObjectsList == null))
                    {
                        cachedToAddClassesSearchForTheClassByNameAndManagementPackAndThenAddThemToTheSelectedObjectsList = CoreManager.MomConsole.GetIntlStr(ResourceToAddClassesSearchForTheClassByNameAndManagementPackAndThenAddThemToTheSelectedObjectsList);
                    }
                    
                    return cachedToAddClassesSearchForTheClassByNameAndManagementPackAndThenAddThemToTheSelectedObjectsList;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Search translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 2/9/2009 Created
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
            /// Exposes access to the Cancel2 translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 2/9/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Cancel2
            {
                get
                {
                    if ((cachedCancel2 == null))
                    {
                        cachedCancel2 = CoreManager.MomConsole.GetIntlStr(ResourceCancel2);
                    }
                    
                    return cachedCancel2;
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
        /// 	[nathd] 2/9/2009 Created
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
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "buttonCancel";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "buttonOK";
            
            /// <summary>
            /// Control ID for CompletionComboBox
            /// </summary>
            public const string CompletionComboBox = "mpSelector";
            
            /// <summary>
            /// Control ID for GeneralPropertiesTextBox
            /// </summary>
            public const string GeneralPropertiesTextBox = "filterEntry";
            
            /// <summary>
            /// Control ID for ManagementPackStaticControl
            /// </summary>
            public const string ManagementPackStaticControl = "label3";
            
            /// <summary>
            /// Control ID for FilterByOptionalStaticControl
            /// </summary>
            public const string FilterByOptionalStaticControl = "label2";
            
            /// <summary>
            /// Control ID for ToAddClassesSearchForTheClassByNameAndManagementPackAndThenAddThemToTheSelectedObjectsListStaticCont
            /// </summary>
            public const string ToAddClassesSearchForTheClassByNameAndManagementPackAndThenAddThemToTheSelectedObjectsListStaticCont = "descriptionLabel";
            
            /// <summary>
            /// Control ID for SearchButton
            /// </summary>
            public const string SearchButton = "searchButton";
            
            /// <summary>
            /// Control ID for CancelButton2
            /// </summary>
            public const string CancelButton2 = "cancelButton";
        }
        #endregion
    }
}
