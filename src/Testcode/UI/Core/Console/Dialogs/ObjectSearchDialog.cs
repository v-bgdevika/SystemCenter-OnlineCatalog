// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ObjectSearchDialog.cs">
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
    
    #region Interface Definition - IObjectSearchDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IObjectSearchDialogControls, for ObjectSearchDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[nathd] 2/9/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IObjectSearchDialogControls
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
        /// Read-only property to access GeneralPropertiesComboBox
        /// </summary>
        ComboBox GeneralPropertiesComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CompletionTextBox
        /// </summary>
        TextBox CompletionTextBox
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
        /// Read-only property to access ToAddObjectsSearchForTheObjectsAndThenAddThemToTheSelectedObjectsListStaticControl
        /// </summary>
        StaticControl ToAddObjectsSearchForTheObjectsAndThenAddThemToTheSelectedObjectsListStaticControl
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
    public class ObjectSearchDialog : Dialog, IObjectSearchDialogControls
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
        /// Cache to hold a reference to GeneralPropertiesComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedGeneralPropertiesComboBox;
        
        /// <summary>
        /// Cache to hold a reference to CompletionTextBox of type TextBox
        /// </summary>
        private TextBox cachedCompletionTextBox;
        
        /// <summary>
        /// Cache to hold a reference to LookForStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedLookForStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to FilterByStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedFilterByStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ToAddObjectsSearchForTheObjectsAndThenAddThemToTheSelectedObjectsListStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedToAddObjectsSearchForTheObjectsAndThenAddThemToTheSelectedObjectsListStaticControl;
        
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
        /// Owner of ObjectSearchDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[nathd] 2/9/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ObjectSearchDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IObjectSearchDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[nathd] 2/9/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IObjectSearchDialogControls Controls
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
                return this.Controls.GeneralPropertiesComboBox.Text;
            }
            
            set
            {
                this.Controls.GeneralPropertiesComboBox.SelectByText(value, true);
            }
        }
        
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
                return this.Controls.CompletionTextBox.Text;
            }
            
            set
            {
                this.Controls.CompletionTextBox.Text = value;
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
        ListView IObjectSearchDialogControls.AvailableItemsListView
        {
            get
            {
                if ((this.cachedAvailableItemsListView == null))
                {
                    this.cachedAvailableItemsListView = new ListView(this, ObjectSearchDialog.ControlIDs.AvailableItemsListView);
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
        StaticControl IObjectSearchDialogControls.AvailableItemsStaticControl
        {
            get
            {
                if ((this.cachedAvailableItemsStaticControl == null))
                {
                    this.cachedAvailableItemsStaticControl = new StaticControl(this, ObjectSearchDialog.ControlIDs.AvailableItemsStaticControl);
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
        Button IObjectSearchDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ObjectSearchDialog.ControlIDs.CancelButton);
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
        Button IObjectSearchDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, ObjectSearchDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralPropertiesComboBox control
        /// </summary>
        /// <history>
        /// 	[nathd] 2/9/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IObjectSearchDialogControls.GeneralPropertiesComboBox
        {
            get
            {
                if ((this.cachedGeneralPropertiesComboBox == null))
                {
                    this.cachedGeneralPropertiesComboBox = new ComboBox(this, ObjectSearchDialog.ControlIDs.GeneralPropertiesComboBox);
                }
                
                return this.cachedGeneralPropertiesComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CompletionTextBox control
        /// </summary>
        /// <history>
        /// 	[nathd] 2/9/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IObjectSearchDialogControls.CompletionTextBox
        {
            get
            {
                if ((this.cachedCompletionTextBox == null))
                {
                    this.cachedCompletionTextBox = new TextBox(this, ObjectSearchDialog.ControlIDs.CompletionTextBox);
                }
                
                return this.cachedCompletionTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LookForStaticControl control
        /// </summary>
        /// <history>
        /// 	[nathd] 2/9/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IObjectSearchDialogControls.LookForStaticControl
        {
            get
            {
                if ((this.cachedLookForStaticControl == null))
                {
                    this.cachedLookForStaticControl = new StaticControl(this, ObjectSearchDialog.ControlIDs.LookForStaticControl);
                }
                
                return this.cachedLookForStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FilterByStaticControl control
        /// </summary>
        /// <history>
        /// 	[nathd] 2/9/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IObjectSearchDialogControls.FilterByStaticControl
        {
            get
            {
                if ((this.cachedFilterByStaticControl == null))
                {
                    this.cachedFilterByStaticControl = new StaticControl(this, ObjectSearchDialog.ControlIDs.FilterByStaticControl);
                }
                
                return this.cachedFilterByStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToAddObjectsSearchForTheObjectsAndThenAddThemToTheSelectedObjectsListStaticControl control
        /// </summary>
        /// <history>
        /// 	[nathd] 2/9/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IObjectSearchDialogControls.ToAddObjectsSearchForTheObjectsAndThenAddThemToTheSelectedObjectsListStaticControl
        {
            get
            {
                if ((this.cachedToAddObjectsSearchForTheObjectsAndThenAddThemToTheSelectedObjectsListStaticControl == null))
                {
                    this.cachedToAddObjectsSearchForTheObjectsAndThenAddThemToTheSelectedObjectsListStaticControl = new StaticControl(this, ObjectSearchDialog.ControlIDs.ToAddObjectsSearchForTheObjectsAndThenAddThemToTheSelectedObjectsListStaticControl);
                }
                
                return this.cachedToAddObjectsSearchForTheObjectsAndThenAddThemToTheSelectedObjectsListStaticControl;
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
        Button IObjectSearchDialogControls.SearchButton
        {
            get
            {
                if ((this.cachedSearchButton == null))
                {
                    this.cachedSearchButton = new Button(this, ObjectSearchDialog.ControlIDs.SearchButton);
                }
                
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
        Button IObjectSearchDialogControls.CancelButton2
        {
            get
            {
                if ((this.cachedCancelButton2 == null))
                {
                    this.cachedCancelButton2 = new Button(this, ObjectSearchDialog.ControlIDs.CancelButton2);
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
            private const string ResourceDialogTitle = ";Object search;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Dialogs.PickerDialogs.ObjectSimpleChooserDialog;$this.Text";
            
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
            /// Contains resource string for:  LookFor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLookFor = ";&Look for:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Mi" +
                "crosoft.EnterpriseManagement.Mom.Internal.UI.Administration.SelectTasksForm;look" +
                "ForLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  FilterBy
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFilterBy = ";&Filter by:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMa" +
                "nagement.Mom.Internal.UI.Dialogs.PickerDialogs.ObjectPickerControl;label2.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ToAddObjectsSearchForTheObjectsAndThenAddThemToTheSelectedObjectsList
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceToAddObjectsSearchForTheObjectsAndThenAddThemToTheSelectedObjectsList = ";To add objects, search for the objects and then add them to the selected objects" +
                " list.;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagem" +
                "ent.Mom.Internal.UI.Dialogs.PickerDialogs.ObjectPickerControl;label1.Text";
            
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
            /// Caches the translated resource string for:  ToAddObjectsSearchForTheObjectsAndThenAddThemToTheSelectedObjectsList
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedToAddObjectsSearchForTheObjectsAndThenAddThemToTheSelectedObjectsList;
            
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
            /// Exposes access to the LookFor translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 2/9/2009 Created
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
            /// 	[nathd] 2/9/2009 Created
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
            /// Exposes access to the ToAddObjectsSearchForTheObjectsAndThenAddThemToTheSelectedObjectsList translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 2/9/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ToAddObjectsSearchForTheObjectsAndThenAddThemToTheSelectedObjectsList
            {
                get
                {
                    if ((cachedToAddObjectsSearchForTheObjectsAndThenAddThemToTheSelectedObjectsList == null))
                    {
                        cachedToAddObjectsSearchForTheObjectsAndThenAddThemToTheSelectedObjectsList = CoreManager.MomConsole.GetIntlStr(ResourceToAddObjectsSearchForTheObjectsAndThenAddThemToTheSelectedObjectsList);
                    }
                    
                    return cachedToAddObjectsSearchForTheObjectsAndThenAddThemToTheSelectedObjectsList;
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
            /// Control ID for GeneralPropertiesComboBox
            /// </summary>
            public const string GeneralPropertiesComboBox = "classSelector";
            
            /// <summary>
            /// Control ID for CompletionTextBox
            /// </summary>
            public const string CompletionTextBox = "filterEntry";
            
            /// <summary>
            /// Control ID for LookForStaticControl
            /// </summary>
            public const string LookForStaticControl = "label3";
            
            /// <summary>
            /// Control ID for FilterByStaticControl
            /// </summary>
            public const string FilterByStaticControl = "label2";
            
            /// <summary>
            /// Control ID for ToAddObjectsSearchForTheObjectsAndThenAddThemToTheSelectedObjectsListStaticControl
            /// </summary>
            public const string ToAddObjectsSearchForTheObjectsAndThenAddThemToTheSelectedObjectsListStaticControl = "label1";
            
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
