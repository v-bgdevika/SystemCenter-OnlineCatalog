// ----------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="Search.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	MOMv3
// </project>
// <summary>
// 	Search 
// </summary>
// <history>
// 	[mbickle] 01MAY06 Created
// </history>
// ----------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.Search
{
    #region Using directives
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console.Search.Dialogs;
    #endregion

    /// <summary>
    /// Search
    /// </summary>
    public class Search
    {
        #region Private Members
        /// <summary>
        /// cachedAdvancedSearchDialog
        /// </summary>
        private AdvancedSearchDialog cachedAdvancedSearchDialog;

        /// <summary>
        /// cachedSavedSearchNameDialog
        /// </summary>
        private SavedSearchNameDialog cachedSavedSearchNameDialog;

        /// <summary>
        /// cachedSearchWindowDialog
        /// </summary>
        private SearchWindowDialog cachedSearchWindowDialog;

        /// <summary>
        /// cachedSavedSearchesPath
        /// </summary>
        private string cachedSavedSearchesPath;
        #endregion

        #region Constructor
        /// <summary>
        /// Search
        /// </summary>
        public Search()
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// Advanced Search Dialog
        /// </summary>
        public string SavedSearchsPath
        {
            get
            {
                if (this.cachedSavedSearchesPath == null)
                {
                    this.cachedSavedSearchesPath = NavigationPane.Strings.MyWorkspace + Constants.PathDelimiter + NavigationPane.Strings.SavedSearchesNode;
                }

                return this.cachedSavedSearchesPath;
            }
        }
        
        /// <summary>
        /// Advanced Search Dialog
        /// </summary>
        public AdvancedSearchDialog AdvancedSearchDialog
        {
            get
            {
                if (this.cachedAdvancedSearchDialog == null)
                {
                    this.cachedAdvancedSearchDialog = new AdvancedSearchDialog(CoreManager.MomConsole);
                }

                return this.cachedAdvancedSearchDialog;
            }
        }

        /// <summary>
        /// Search Window Dialog
        /// </summary>
        public SearchWindowDialog SearchWindowDialog
        {
            get
            {
                if (this.cachedSearchWindowDialog == null)
                {
                    this.cachedSearchWindowDialog = new SearchWindowDialog(CoreManager.MomConsole);
                }

                return this.cachedSearchWindowDialog;
            }
        }

        /// <summary>
        /// Saved Search Name Dialog
        /// </summary>
        public SavedSearchNameDialog SavedSearchNameDialog
        {
            get
            {
                if (this.cachedSavedSearchNameDialog == null)
                {
                    this.cachedSavedSearchNameDialog = new SavedSearchNameDialog(CoreManager.MomConsole);
                }

                return this.cachedSavedSearchNameDialog;
            }
        }
        #endregion

        #region Public Methods
        /// ------------------------------------------------------------------
        /// <summary>
        /// Checks to see if the Saved Search Exists
        /// </summary>
        /// <param name="savedSearchName">Saved Search Name</param>
        /// <returns>True/False</returns>
        /// ------------------------------------------------------------------
        public virtual bool SavedSearchExists(string savedSearchName)
        {
            Utilities.LogMessage("Search.SavedSearchExist:: ");
            bool searchExists = false;

            this.NavigateToSavedSearches();

            ViewPane savedSearchesView = CoreManager.MomConsole.ViewPane;
            CoreManager.MomConsole.SendKeys(KeyboardCodes.F5);
            CoreManager.MomConsole.Waiters.WaitForReady(Constants.OneSecond*10);
            MomControls.GridControl savedSearchesGrid = savedSearchesView.Grid;

            // Lets see if we can find the search name.
            DataGridViewRow savedRow = 
                savedSearchesGrid.FindData(savedSearchName, Strings.SavedSearchesNameColumn);

            if (savedRow != null)
            {
                Utilities.LogMessage("Search.SavedSearchExist:: saved search exists");
                searchExists = true;
            }
            else
            {
                Utilities.LogMessage("Search.SavedSearchExist:: saved search NOT exists");
            }

            return searchExists;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Runs a Saved Search
        /// </summary>
        /// <param name="savedSearchName">Name of the Saved Search</param>
        /// <exception cref="DataGridView.Exceptions.DataGridViewRowNotFoundException"></exception>
        /// ------------------------------------------------------------------
        public virtual void RunSavedSearch(string savedSearchName)
        {
            Utilities.LogMessage("Search.RunSavedSearch:: ");

            DataGridViewRow savedSearch = null;
            this.NavigateToSavedSearches();
            MomControls.GridControl saveGrid = CoreManager.MomConsole.ViewPane.Grid;
            int nameColumnIndex = saveGrid.GetColumnTitlePosition(Strings.SavedSearchesNameColumn);

            savedSearch = saveGrid.FindData(savedSearchName, Strings.SavedSearchesNameColumn);
            if (savedSearch != null)
            {
                // Click the Cell
                saveGrid.ClickCell(savedSearch.AccessibleObject.Index, nameColumnIndex);

                // Now lets right click to access Context Menu.
                saveGrid.ClickCell(savedSearch.AccessibleObject.Index, nameColumnIndex, MouseFlags.RightButton);

                // Execute Search Now
                Menu contextMenu = new Menu(5000);
                contextMenu.ExecuteMenuItem(Strings.ContextMenuSearchNow);
            }
            else
            {
                throw new DataGridView.Exceptions.DataGridViewRowNotFoundException("Search.RunSavedSearch:: Failed to find Saved Search");
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Navigates to the Saved Searches view.
        /// </summary>
        /// ------------------------------------------------------------------
        public virtual void NavigateToSavedSearches()
        {
            NavigationPane navpane = CoreManager.MomConsole.NavigationPane;

            // Select Saved Searches node.
            navpane.SelectNode(this.SavedSearchsPath, NavigationPane.NavigationTreeView.MyWorkspace);
        }
        #endregion

        #region Strings
        /// <summary>
        /// Strings
        /// </summary>
        public class Strings
        {
            #region Constants
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Managed Objects
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceManagedObjects = ";Managed Objects;ManagedString;Microsoft.EnterpriseManagement.UI.Console.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.SharedResources;SearchManagedObject";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string Alerts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlerts = ";Alerts;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Search.SearchResource;SearchAlerts";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string Events
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEvents = ";Events;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Search.SearchResource;SearchEvents";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Monitors
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMonitors = ";Monitors;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Search.SearchResource;SearchMonitors";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Rules
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRules = ";Rules;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Search.SearchResource;SearchRules";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Tasks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTasks = ";Tasks;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Search.SearchResource;SearchTasks";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Views
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceViews = ";Views;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Search.SearchResource;SearchViews";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Managed Object Name Column.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceManagedObjectNameColumn = ";Name;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.ManagedObjectView.ManagedObjectViewResource;NameColumn";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Managed Object Health State Column.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceManagedObjectHealthStateColumn = ";Health State;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.ManagedObjectView.ManagedObjectViewResource;HealthStateColumn";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Managed Object Path Column.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceManagedObjectPathColumn = ";Path;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.ManagedObjectView.ManagedObjectViewResource;PathColumn";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Managed Object Type Column.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceManagedObjectTypeColumn = ";Types;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.ManagedObjectView.ManagedObjectViewResource;TypeColumn";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Saved Searches Name Column.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSavedSearchesNameColumn = ";Name;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.WunderBarPages.Favorites.FavoritesResources;SavedSearchNameColumn";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Saved Searches Search Type Column.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSavedSearchesSearchTypeColumn = ";Search Type;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.WunderBarPages.Favorites.FavoritesResources;SavedSearchTypeColumn";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Saved Searches Search Type Column.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceContextMenuSearchNow = ";Search Now;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.WunderBarPages.Favorites.FavoritesResources;SearchNow";
            #endregion

            #region Private Members
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Managed Objects
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedManagedObjects;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains cached string Alerts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlerts;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains cached string Events
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEvents;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains cached string for Monitors
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonitors;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains cached string for Rules
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRules;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains cached string for Tasks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTasks;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains cached string for Views
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedViews;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Managed Object Name Column.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedManagedObjectNameColumn;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains cached string for Managed Object Health State Column.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedManagedObjectHealthStateColumn;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains cached string for Managed Object Path Column.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedManagedObjectPathColumn;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains cached string for Managed Object Type Column.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedManagedObjectTypeColumn;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains cached string for Saved Searches Name Column.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSavedSearchesNameColumn;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains cached string for Saved Searches Search Type Column.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSavedSearchesSearchTypeColumn;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains cached string for Saved Searches Search Type Column.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedContextMenuSearchNow;

            #endregion
            
            #region Properties
            /// <summary>
            /// Managed Objects
            /// </summary>
            public static string ManagedObjects
            {
                get
                {
                    if ((cachedManagedObjects == null))
                    {
                        cachedManagedObjects = CoreManager.MomConsole.GetIntlStr(ResourceManagedObjects);
                    }

                    return cachedManagedObjects;
                }
            }

            /// <summary>
            /// Alerts
            /// </summary>
            public static string Alerts
            {
                get
                {
                    if ((cachedAlerts == null))
                    {
                        cachedAlerts = CoreManager.MomConsole.GetIntlStr(ResourceAlerts);
                    }

                    return cachedAlerts;
                }
            }

            /// <summary>
            /// Events
            /// </summary>
            public static string Events
            {
                get
                {
                    if ((cachedEvents == null))
                    {
                        cachedEvents = CoreManager.MomConsole.GetIntlStr(ResourceEvents);
                    }

                    return cachedEvents;
                }
            }

            /// <summary>
            /// Monitors
            /// </summary>
            public static string Monitors
            {
                get
                {
                    if ((cachedMonitors == null))
                    {
                        cachedMonitors = CoreManager.MomConsole.GetIntlStr(ResourceMonitors);
                    }

                    return cachedMonitors;
                }
            }

            /// <summary>
            /// Rules
            /// </summary>
            public static string Rules
            {
                get
                {
                    if ((cachedRules == null))
                    {
                        cachedRules = CoreManager.MomConsole.GetIntlStr(ResourceRules);
                    }

                    return cachedRules;
                }
            }

            /// <summary>
            /// Tasks
            /// </summary>
            public static string Tasks
            {
                get
                {
                    if ((cachedTasks == null))
                    {
                        cachedTasks = CoreManager.MomConsole.GetIntlStr(ResourceTasks);
                    }

                    return cachedTasks;
                }
            }

            /// <summary>
            /// Views
            /// </summary>
            public static string Views
            {
                get
                {
                    if ((cachedViews == null))
                    {
                        cachedViews = CoreManager.MomConsole.GetIntlStr(ResourceViews);
                    }

                    return cachedViews;
                }
            }

            /// <summary>
            /// Managed Object Name Column
            /// </summary>
            public static string ManagedObjectNameColumn
            {
                get
                {
                    if ((cachedManagedObjectNameColumn == null))
                    {
                        cachedManagedObjectNameColumn = CoreManager.MomConsole.GetIntlStr(ResourceManagedObjectNameColumn);
                    }

                    return cachedManagedObjectNameColumn;
                }
            }

            /// <summary>
            /// ManagedObjectHealthStateColumn
            /// </summary>
            public static string ManagedObjectHealthStateColumn
            {
                get
                {
                    if ((cachedManagedObjectHealthStateColumn == null))
                    {
                        cachedManagedObjectHealthStateColumn = CoreManager.MomConsole.GetIntlStr(ResourceManagedObjectHealthStateColumn);
                    }

                    return cachedManagedObjectHealthStateColumn;
                }
            }

            /// <summary>
            /// ManagedObjectPathColumn
            /// </summary>
            public static string ManagedObjectPathColumn
            {
                get
                {
                    if ((cachedManagedObjectPathColumn == null))
                    {
                        cachedManagedObjectPathColumn = CoreManager.MomConsole.GetIntlStr(ResourceManagedObjectPathColumn);
                    }

                    return cachedManagedObjectPathColumn;
                }
            }

            /// <summary>
            /// ManagedObjectTypesColumn
            /// </summary>
            public static string ManagedObjectTypeColumn
            {
                get
                {
                    if ((cachedManagedObjectTypeColumn == null))
                    {
                        cachedManagedObjectTypeColumn = CoreManager.MomConsole.GetIntlStr(ResourceManagedObjectTypeColumn);
                    }

                    return cachedManagedObjectTypeColumn;
                }
            }

            /// <summary>
            /// SavedSearches Name Column
            /// </summary>
            public static string SavedSearchesNameColumn
            {
                get
                {
                    if ((cachedSavedSearchesNameColumn == null))
                    {
                        cachedSavedSearchesNameColumn = CoreManager.MomConsole.GetIntlStr(ResourceSavedSearchesNameColumn);
                    }

                    return cachedSavedSearchesNameColumn;
                }
            }

            /// <summary>
            /// SavedSearches SearchType Column
            /// </summary>
            public static string SavedSearchesSearchTypeColumn
            {
                get
                {
                    if ((cachedSavedSearchesSearchTypeColumn == null))
                    {
                        cachedSavedSearchesSearchTypeColumn = CoreManager.MomConsole.GetIntlStr(ResourceSavedSearchesSearchTypeColumn);
                    }

                    return cachedSavedSearchesSearchTypeColumn;
                }
            }

            /// <summary>
            /// ContextMenuSearchNow
            /// </summary>
            public static string ContextMenuSearchNow
            {
                get
                {
                    if ((cachedContextMenuSearchNow == null))
                    {
                        cachedContextMenuSearchNow = CoreManager.MomConsole.GetIntlStr(ResourceContextMenuSearchNow);
                    }

                    return cachedContextMenuSearchNow;
                }
            }
            #endregion
        }
        #endregion
    }
}
