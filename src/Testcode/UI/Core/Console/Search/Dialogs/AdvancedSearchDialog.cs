// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AdvancedSearchDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3
// </project>
// <summary>
// 	Advanced Search Dialog
// </summary>
// <history>
// 	[mbickle] 01MAY06 Created
//  [v-cheli] 27NOV08 Added ViewNameStaticControl for view title
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Search.Dialogs
{
    #region Using directives
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    #endregion
    
    #region Interface Definition - IAdvancedSearchDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAdvancedSearchDialogControls, for AdvancedSearchDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[mbickle] 01MAY06 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAdvancedSearchDialogControls
    {
        /// <summary>
        /// Read-only property to access SaveParametersToMyFavoritesStaticControl
        /// </summary>
        StaticControl SaveParametersToMyFavoritesStaticControl
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
        /// Read-only property to access ObjectTypeComboBox
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        EditComboBox ObjectTypeComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TextBox11
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TextBox TextBox11
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SearchForSpecificObjectTypesStaticControl
        /// </summary>
        StaticControl SearchForSpecificObjectTypesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CreateInListBox
        /// </summary>
        ListBox CreateInListBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl
        /// </summary>
        StaticControl CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ViewAllManagedObjectsStaticControl
        /// </summary>
        StaticControl ViewAllManagedObjectsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WithASpecificNameStaticControl for managed objects
        /// </summary>
        StaticControl WithASpecificNameStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access WithASpecificNameStaticControl for alerts
        /// </summary>
        StaticControl WithASpecificNameStaticControlAlerts
        {
            get;
        }

        /// <summary>
        /// Read-only property to access LoggedByASpecificComputerStaticControl for events
        /// </summary>
        StaticControl LoggedByASpecificComputerStaticControlEvents
        {
            get;
        }

        /// <summary>
        /// Read-only property to access WithASpecificNameStaticControl for Rules
        /// </summary>
        StaticControl WithASpecificNameStaticControlRules
        {
            get;
        }

        /// <summary>
        /// Read-only property to access WithASpecificNameStaticControl for Views
        /// </summary>
        StaticControl WithASpecificNameStaticControlViews
        {
            get;
        }

        /// <summary>
        /// Read-only property to access WithASpecificNameStaticControl for Tasks
        /// </summary>
        StaticControl WithASpecificNameStaticControlTasks
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AndInSpecificHealthStateStaticControl
        /// </summary>
        StaticControl AndInSpecificHealthStateStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AndContainedInASpecificGroupStaticControl
        /// </summary>
        StaticControl AndContainedInASpecificGroupStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AndTheMonitorGeneratesAlertsOfSpecificPriorityStaticControl
        /// </summary>
        StaticControl AndTheMonitorGeneratesAlertsOfSpecificPriorityStaticControl
        {
            get;
        }
        /// <summary>
        /// Read-only property to access HeaderToolbar
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Toolbar HeaderToolbar
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SaveParametersToMyFavoritesStatusBar
        /// </summary>
        StatusBar SaveParametersToMyFavoritesStatusBar
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ViewNameStaticControl
        /// </summary>
        StaticControl ViewNameStaticControl
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
    /// 	[mbickle] 01MAY06 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class AdvancedSearchDialog : Dialog, IAdvancedSearchDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 10000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to SaveParametersToMyFavoritesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSaveParametersToMyFavoritesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SearchButton of type Button
        /// </summary>
        private Button cachedSearchButton;
        
        /// <summary>
        /// Cache to hold a reference to ObjectTypeComboBox of type EditComboBox
        /// </summary>
        private EditComboBox cachedObjectTypeComboBox;
        
        /// <summary>
        /// Cache to hold a reference to TextBox11 of type TextBox
        /// </summary>
        private TextBox cachedTextBox11;
        
        /// <summary>
        /// Cache to hold a reference to SearchForSpecificObjectTypesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSearchForSpecificObjectTypesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CreateInListBox of type ListBox
        /// </summary>
        private ListBox cachedCreateInListBox;
        
        /// <summary>
        /// Cache to hold a reference to CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCriteriaDescriptionClickTheUnderlinedValueToEditStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ViewAllManagedObjectsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedViewAllManagedObjectsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to WithASpecificNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWithASpecificNameStaticControl;

        /// <summary>
        /// Cache to hold a reference to WithASpecificNameStaticControl of type StaticControl for alerts
        /// </summary>
        private StaticControl cachedWithASpecificNameStaticControlAlerts;

        /// <summary>
        /// Cache to hold a reference to LoggedByASpecificComputerStaticControl of type StaticControl for events
        /// </summary>
        private StaticControl cachedLoggedByASpecificComputerStaticControlEvents;

        /// <summary>
        /// Cache to hold a reference to WithASpecificNameStaticControl of type StaticControl for rules
        /// </summary>
        private StaticControl cachedWithASpecificNameStaticControlRules;

        /// <summary>
        /// Cache to hold a reference to WithASpecificNameStaticControl of type StaticControl for views
        /// </summary>
        private StaticControl cachedWithASpecificNameStaticControlViews;

        /// <summary>
        /// Cache to hold a reference to WithASpecificNameStaticControl of type StaticControl for tasks
        /// </summary>
        private StaticControl cachedWithASpecificNameStaticControlTasks;
        
        /// <summary>
        /// Cache to hold a reference to AndInSpecificHealthStateStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAndInSpecificHealthStateStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AndContainedInASpecificGroupStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAndContainedInASpecificGroupStaticControl;

        /// <summary>
        /// Cache to hold a reference to AndTheMonitorGeneratesAlertsOfSpecificPriorityStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAndTheMonitorGeneratesAlertsOfSpecificPriorityStaticControl;

        /// <summary>
        /// Cache to hold a reference to HeaderToolbar of type Toolbar
        /// </summary>
        private Toolbar cachedHeaderToolbar;
        
        /// <summary>
        /// Cache to hold a reference to SaveParametersToMyFavoritesStatusBar of type StatusBar
        /// </summary>
        private StatusBar cachedSaveParametersToMyFavoritesStatusBar;

        /// <summary>
        /// Cache to hold a reference to ViewNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedViewNameStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of AdvancedSearchDialog of type App
        /// </param>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AdvancedSearchDialog(App app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IAdvancedSearchDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAdvancedSearchDialogControls Controls
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
        ///  Routine to set/get the text in control ObjectTypeComboBox
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ObjectTypeComboBoxText
        {
            get
            {
                return this.Controls.ObjectTypeComboBox.Text;
            }
            
            set
            {
                this.Controls.ObjectTypeComboBox.SelectByText(value);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TextBox11
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TextBox11Text
        {
            get
            {
                return this.Controls.TextBox11.Text;
            }
            
            set
            {
                this.Controls.TextBox11.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SaveParametersToMyFavoritesStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAdvancedSearchDialogControls.SaveParametersToMyFavoritesStaticControl
        {
            get
            {
                if ((this.cachedSaveParametersToMyFavoritesStaticControl == null))
                {
                    this.cachedSaveParametersToMyFavoritesStaticControl = new StaticControl(this, AdvancedSearchDialog.QueryIds.SaveParametersToMyFavoritesStaticControl);
                }

                return this.cachedSaveParametersToMyFavoritesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SearchButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAdvancedSearchDialogControls.SearchButton
        {
            get
            {
                if ((this.cachedSearchButton == null))
                {
                    this.cachedSearchButton = new Button(this, AdvancedSearchDialog.ControlIDs.SearchButton);
                }

                return this.cachedSearchButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ObjectTypeComboBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IAdvancedSearchDialogControls.ObjectTypeComboBox
        {
            get
            {
                if ((this.cachedObjectTypeComboBox == null))
                {
                    this.cachedObjectTypeComboBox = new EditComboBox(this, AdvancedSearchDialog.ControlIDs.ObjectTypeComboBox);
                }

                return this.cachedObjectTypeComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TextBox11 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAdvancedSearchDialogControls.TextBox11
        {
            get
            {
                if ((this.cachedTextBox11 == null))
                {
                    Window wndTemp = this;

                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedTextBox11 = new TextBox(wndTemp);
                }

                return this.cachedTextBox11;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SearchForSpecificObjectTypesStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAdvancedSearchDialogControls.SearchForSpecificObjectTypesStaticControl
        {
            get
            {
                if ((this.cachedSearchForSpecificObjectTypesStaticControl == null))
                {
                    this.cachedSearchForSpecificObjectTypesStaticControl = new StaticControl(this, AdvancedSearchDialog.ControlIDs.SearchForSpecificObjectTypesStaticControl);
                }

                return this.cachedSearchForSpecificObjectTypesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateInListBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListBox IAdvancedSearchDialogControls.CreateInListBox
        {
            get
            {
                if ((this.cachedCreateInListBox == null))
                {
                    this.cachedCreateInListBox = new ListBox(this, AdvancedSearchDialog.ControlIDs.CreateInListBox);
                }

                return this.cachedCreateInListBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAdvancedSearchDialogControls.CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl
        {
            get
            {
                if ((this.cachedCriteriaDescriptionClickTheUnderlinedValueToEditStaticControl == null))
                {
                    this.cachedCriteriaDescriptionClickTheUnderlinedValueToEditStaticControl = new StaticControl(this, AdvancedSearchDialog.ControlIDs.CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl);
                }

                return this.cachedCriteriaDescriptionClickTheUnderlinedValueToEditStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ViewAllManagedObjectsStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAdvancedSearchDialogControls.ViewAllManagedObjectsStaticControl
        {
            get
            {
                if ((this.cachedViewAllManagedObjectsStaticControl == null))
                {
                    this.cachedViewAllManagedObjectsStaticControl = new StaticControl(this, AdvancedSearchDialog.ControlIDs.ViewAllManagedObjectsStaticControl);
                }

                return this.cachedViewAllManagedObjectsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WithASpecificNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAdvancedSearchDialogControls.WithASpecificNameStaticControl
        {
            get
            {
                if ((this.cachedWithASpecificNameStaticControl == null))
                {
                    this.cachedWithASpecificNameStaticControl = new StaticControl(this, AdvancedSearchDialog.ControlIDs.WithASpecificNameStaticControl);
                }

                return this.cachedWithASpecificNameStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WithASpecificNameStaticControl control for alerts
        /// </summary>
        /// <history>
        /// 	[visnara] 6/26/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAdvancedSearchDialogControls.WithASpecificNameStaticControlAlerts
        {
            get
            {
                if ((this.cachedWithASpecificNameStaticControlAlerts == null))
                {
                    this.cachedWithASpecificNameStaticControlAlerts = new StaticControl(this, AdvancedSearchDialog.ControlIDs.WithASpecificNameStaticControlAlerts);
                }

                return this.cachedWithASpecificNameStaticControlAlerts;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LoggedByASpecificComputerStaticControl control for Events
        /// </summary>
        /// <history>
        /// 	[visnara] 6/26/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAdvancedSearchDialogControls.LoggedByASpecificComputerStaticControlEvents
        {
            get
            {
                if ((this.cachedLoggedByASpecificComputerStaticControlEvents == null))
                {
                    this.cachedLoggedByASpecificComputerStaticControlEvents = new StaticControl(this, AdvancedSearchDialog.ControlIDs.LoggedByASpecificComputerStaticControlEvents);
                }

                return this.cachedLoggedByASpecificComputerStaticControlEvents;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WithASpecificNameStaticControl control for rules
        /// </summary>
        /// <history>
        /// 	[visnara] 6/26/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAdvancedSearchDialogControls.WithASpecificNameStaticControlRules
        {
            get
            {
                if ((this.cachedWithASpecificNameStaticControlRules == null))
                {
                    this.cachedWithASpecificNameStaticControlRules = new StaticControl(this, AdvancedSearchDialog.ControlIDs.WithASpecificNameStaticControlRules);
                }

                return this.cachedWithASpecificNameStaticControlRules;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WithASpecificNameStaticControl control for views
        /// </summary>
        /// <history>
        /// 	[visnara] 6/26/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAdvancedSearchDialogControls.WithASpecificNameStaticControlViews
        {
            get
            {
                if ((this.cachedWithASpecificNameStaticControlViews == null))
                {
                    this.cachedWithASpecificNameStaticControlViews = new StaticControl(this, AdvancedSearchDialog.ControlIDs.WithASpecificNameStaticControlViews);
                }

                return this.cachedWithASpecificNameStaticControlViews;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WithASpecificNameStaticControl control for tasks
        /// </summary>
        /// <history>
        /// 	[visnara] 6/26/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAdvancedSearchDialogControls.WithASpecificNameStaticControlTasks
        {
            get
            {
                if ((this.cachedWithASpecificNameStaticControlTasks == null))
                {
                    this.cachedWithASpecificNameStaticControlTasks = new StaticControl(this, AdvancedSearchDialog.ControlIDs.WithASpecificNameStaticControlTasks);
                }

                return this.cachedWithASpecificNameStaticControlTasks;
            }
        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AndTheMonitorGeneratesAlertsOfSpecificPriorityStaticControl control
        /// </summary>
        /// <history>
        /// 	[asttest] 2/15/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAdvancedSearchDialogControls.AndTheMonitorGeneratesAlertsOfSpecificPriorityStaticControl
        {
            get
            {
                if ((this.cachedAndTheMonitorGeneratesAlertsOfSpecificPriorityStaticControl == null))
                {
                    this.cachedAndTheMonitorGeneratesAlertsOfSpecificPriorityStaticControl = new StaticControl(this, AdvancedSearchDialog.ControlIDs.AndTheMonitorGeneratesAlertsOfSpecificPriorityStaticControl);
                }
                return this.cachedAndTheMonitorGeneratesAlertsOfSpecificPriorityStaticControl;
            }
        }




        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AndInSpecificHealthStateStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAdvancedSearchDialogControls.AndInSpecificHealthStateStaticControl
        {
            get
            {
                if ((this.cachedAndInSpecificHealthStateStaticControl == null))
                {
                    this.cachedAndInSpecificHealthStateStaticControl = new StaticControl(this, AdvancedSearchDialog.ControlIDs.AndInSpecificHealthStateStaticControl);
                }

                return this.cachedAndInSpecificHealthStateStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AndContainedInASpecificGroupStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAdvancedSearchDialogControls.AndContainedInASpecificGroupStaticControl
        {
            get
            {
                if ((this.cachedAndContainedInASpecificGroupStaticControl == null))
                {
                    this.cachedAndContainedInASpecificGroupStaticControl = new StaticControl(this, AdvancedSearchDialog.ControlIDs.AndContainedInASpecificGroupStaticControl);
                }

                return this.cachedAndContainedInASpecificGroupStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HeaderToolbar control
        /// </summary>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IAdvancedSearchDialogControls.HeaderToolbar
        {
            get
            {
                if ((this.cachedHeaderToolbar == null))
                {
                    this.cachedHeaderToolbar = new Toolbar(this, AdvancedSearchDialog.ControlIDs.HeaderToolbar);
                }

                return this.cachedHeaderToolbar;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SaveParametersToMyFavoritesStatusBar control
        /// </summary>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StatusBar IAdvancedSearchDialogControls.SaveParametersToMyFavoritesStatusBar
        {
            get
            {
                if ((this.cachedSaveParametersToMyFavoritesStatusBar == null))
                {
                    this.cachedSaveParametersToMyFavoritesStatusBar = new StatusBar(this, AdvancedSearchDialog.ControlIDs.SaveParametersToMyFavoritesStatusBar);
                }

                return this.cachedSaveParametersToMyFavoritesStatusBar;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ViewNameStaticControl control
        /// </summary>
        /// <history>
        ///   [v-cheli] 11/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAdvancedSearchDialogControls.ViewNameStaticControl
        {
            get
            {
                if ((this.cachedViewNameStaticControl == null))
                {
                    this.cachedViewNameStaticControl = new StaticControl(this, AdvancedSearchDialog.ControlIDs.ViewNameStaticControl);
                }

                return this.cachedViewNameStaticControl;
            }
        }

        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Search
        /// </summary>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSearch()
        {
            this.Controls.SearchButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on Save parameters to My Favorites
        /// </summary>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSaveToFavorites()
        {
            this.Controls.SaveParametersToMyFavoritesStaticControl.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">App owning the dialog.</param>)
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app)
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
                const int MaxTries = 15;
                while (tempWindow == null && numberOfTries < MaxTries)
                {
                    numberOfTries++;
                    try
                    {
                        // look for the window again using wildcards
                        tempWindow =
                            new Window(
                                app.GetIntlStr(Strings.DialogTitle) + "*",
                                StringMatchSyntax.WildCard,
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
        /// 	[mbickle] 01MAY06 Created
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
            private const string ResourceDialogTitle = ";Advanced Search;ManagedString;Microsoft.EnterpriseManagement.UI.Console.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.SharedResources;AdvancedSearchWindowTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SaveParametersToMyFavorites
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSaveParametersToMyFavorites = ";Save parameters to My Favorites;ManagedString;Microsoft.MOM.UI.Components.dll;Mi" +
                "crosoft.EnterpriseManagement.Mom.Internal.UI.Search.AdvancedSearchControl;saveLi" +
                "nk.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Search
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSearch = ";Search;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.E" +
                "nterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.ReportMonitori" +
                "ngObjectSearchCriteria;searchButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SearchForSpecificObjectTypes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSearchForSpecificObjectTypes = ";Search for specific object types:;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Search.AdvancedSearchControl;obje" +
                "ctTypeLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CriteriaDescriptionClickTheUnderlinedValueToEdit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCriteriaDescriptionClickTheUnderlinedValueToEdit = ";Criteria description (click the underlined value to edit):;ManagedString;Microso" +
                "ft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.Cri" +
                "teriaControl.CriteriaControlResource;Description";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ViewAllManagedObjects
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceViewAllManagedObjects = ";View all managed objects:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsof" +
                "t.EnterpriseManagement.Mom.Internal.UI.Views.ManagedObjectView.ManagedObjectView" +
                "Resource;CriteriaTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WithASpecificName
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceWithASpecificName = "with a specific name";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AndInSpecificHealthState
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAndInSpecificHealthState = "  and in specific health state";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AndContainedInASpecificGroup
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAndContainedInASpecificGroup = "  and contained in a specific group";
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
            /// Caches the translated resource string for:  SaveParametersToMyFavorites
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSaveParametersToMyFavorites;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Search
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSearch;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SearchForSpecificObjectTypes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSearchForSpecificObjectTypes;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CriteriaDescriptionClickTheUnderlinedValueToEdit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCriteriaDescriptionClickTheUnderlinedValueToEdit;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ViewAllManagedObjects
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedViewAllManagedObjects;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WithASpecificName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWithASpecificName;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AndInSpecificHealthState
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAndInSpecificHealthState;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AndContainedInASpecificGroup
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAndContainedInASpecificGroup;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 01MAY06 Created
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
            /// Exposes access to the SaveParametersToMyFavorites translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 01MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SaveParametersToMyFavorites
            {
                get
                {
                    if ((cachedSaveParametersToMyFavorites == null))
                    {
                        cachedSaveParametersToMyFavorites = CoreManager.MomConsole.GetIntlStr(ResourceSaveParametersToMyFavorites);
                    }

                    return cachedSaveParametersToMyFavorites;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Search translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 01MAY06 Created
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
            /// Exposes access to the SearchForSpecificObjectTypes translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 01MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SearchForSpecificObjectTypes
            {
                get
                {
                    if ((cachedSearchForSpecificObjectTypes == null))
                    {
                        cachedSearchForSpecificObjectTypes = CoreManager.MomConsole.GetIntlStr(ResourceSearchForSpecificObjectTypes);
                    }

                    return cachedSearchForSpecificObjectTypes;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CriteriaDescriptionClickTheUnderlinedValueToEdit translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 01MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CriteriaDescriptionClickTheUnderlinedValueToEdit
            {
                get
                {
                    if ((cachedCriteriaDescriptionClickTheUnderlinedValueToEdit == null))
                    {
                        cachedCriteriaDescriptionClickTheUnderlinedValueToEdit = CoreManager.MomConsole.GetIntlStr(ResourceCriteriaDescriptionClickTheUnderlinedValueToEdit);
                    }

                    return cachedCriteriaDescriptionClickTheUnderlinedValueToEdit;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ViewAllManagedObjects translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 01MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ViewAllManagedObjects
            {
                get
                {
                    if ((cachedViewAllManagedObjects == null))
                    {
                        cachedViewAllManagedObjects = CoreManager.MomConsole.GetIntlStr(ResourceViewAllManagedObjects);
                    }

                    return cachedViewAllManagedObjects;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WithASpecificName translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 01MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WithASpecificName
            {
                get
                {
                    if ((cachedWithASpecificName == null))
                    {
                        cachedWithASpecificName = CoreManager.MomConsole.GetIntlStr(ResourceWithASpecificName);
                    }

                    return cachedWithASpecificName;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AndInSpecificHealthState translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 01MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AndInSpecificHealthState
            {
                get
                {
                    if ((cachedAndInSpecificHealthState == null))
                    {
                        cachedAndInSpecificHealthState = CoreManager.MomConsole.GetIntlStr(ResourceAndInSpecificHealthState);
                    }

                    return cachedAndInSpecificHealthState;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AndContainedInASpecificGroup translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 01MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AndContainedInASpecificGroup
            {
                get
                {
                    if ((cachedAndContainedInASpecificGroup == null))
                    {
                        cachedAndContainedInASpecificGroup = CoreManager.MomConsole.GetIntlStr(ResourceAndContainedInASpecificGroup);
                    }

                    return cachedAndContainedInASpecificGroup;
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
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            ///// <summary>
            ///// Control ID for SaveParametersToMyFavoritesStaticControl
            ///// </summary>
            //public const string SaveParametersToMyFavoritesStaticControl = "saveLink";
            
            /// <summary>
            /// Control ID for SearchButton
            /// </summary>
            public const string SearchButton = "searchButton";
            
            /// <summary>
            /// Control ID for ObjectTypeComboBox
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string ObjectTypeComboBox = "objectTypeComboBox";
            
            /// <summary>
            /// Control ID for SearchForSpecificObjectTypesStaticControl
            /// </summary>
            public const string SearchForSpecificObjectTypesStaticControl = "objectTypeLabel";
            
            /// <summary>
            /// Control ID for CreateInListBox
            /// </summary>
            public const string CreateInListBox = "checkboxes";
            
            /// <summary>
            /// Control ID for CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl
            /// </summary>
            public const string CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl = "labelDescription";
            
            /// <summary>
            /// Control ID for ViewAllManagedObjectsStaticControl
            /// </summary>
            public const string ViewAllManagedObjectsStaticControl = "labelHeader";
            
            /// <summary>
            /// Control ID for WithASpecificNameStaticControl
            /// </summary>
            public const string WithASpecificNameStaticControl = "0";
            
            /// <summary>
            /// Control ID for AndInSpecificHealthStateStaticControl
            /// </summary>
            public const string AndInSpecificHealthStateStaticControl = "1";
            
            /// <summary>
            /// Control ID for AndContainedInASpecificGroupStaticControl
            /// </summary>
            public const string AndContainedInASpecificGroupStaticControl = "2";

            /// <summary>
            /// Control ID for WithASpecificNameStaticControlAlerts
            /// </summary>
            public const string WithASpecificNameStaticControlAlerts = "4";

            /// <summary>
            /// Control ID for LoggedByASpecificComputerStaticControlEvents
            /// </summary>
            public const string LoggedByASpecificComputerStaticControlEvents = "7";

            /// <summary>
            /// Control ID for WithASpecificNameStaticControlRules
            /// </summary>
            public const string WithASpecificNameStaticControlRules = "0";

            /// <summary>
            /// Control ID for WithASpecificNameStaticControlViews
            /// </summary>
            public const string WithASpecificNameStaticControlViews = "0";

            /// <summary>
            /// Control ID for WithASpecificNameStaticControl
            /// </summary>
            public const string WithASpecificNameStaticControlTasks = "0";


            /// <summary>
            /// Control ID for AndTheMonitorGeneratesAlertsOfSpecificPriorityStaticControl
            /// </summary>
            public const string AndTheMonitorGeneratesAlertsOfSpecificPriorityStaticControl = "5";
            
            /// <summary>
            /// Control ID for HeaderToolbar
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string HeaderToolbar = "header";
            
            /// <summary>
            /// Control ID for SaveParametersToMyFavoritesStatusBar
            /// </summary>
            public const string SaveParametersToMyFavoritesStatusBar = "consoleStatusBar";

            /// <summary>
            /// Control ID for ViewNameStaticControl
            /// </summary>
            public const string ViewNameStaticControl = "ViewTitle";

        }
        #endregion

        #region Query ID's
        /// <summary>
        /// Class to contain constants for all query ID's
        /// </summary>
        /// <history>
        ///    [v-kayu] 11JAN10 Created
        /// </history>
        public static class QueryIds
        {
            #region Constants
            /// <summary>
            /// Contains Query Id string for Save Parameters to MyFavorites Static Control
            /// </summary>
            private const string QidSaveParametersToMyFavoritesStaticControl = ";[MSAA]ControlName = 'saveLink';Role = 'link'";
            #endregion

            #region Private Members
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            private static QID cachedSaveParametersToMyFavoritesStaticControl;
            #endregion

            #region Properties
            /// <summary>
            /// Exposes access to the Save Parameters to MyFavorites Static control
            /// </summary>
            public static QID SaveParametersToMyFavoritesStaticControl
            {
                get
                {
                    if ((cachedSaveParametersToMyFavoritesStaticControl == null))
                    {
                        cachedSaveParametersToMyFavoritesStaticControl = new QID(QidSaveParametersToMyFavoritesStaticControl);
                    }

                    return cachedSaveParametersToMyFavoritesStaticControl;
                }
            }
            #endregion
        }
        #endregion
    }
}
