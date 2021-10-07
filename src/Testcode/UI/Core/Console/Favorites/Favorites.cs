// ----------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="Favorites.cs">
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
namespace Mom.Test.UI.Core.Console.Favorites
{
    #region Using directives
    using System;
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using Mom.Test.UI.Core.Console.Favorites.Dialogs;
    using Mom.Test.UI.Core.Common;
    #endregion
  
    /// <summary>
    /// Favorites
    /// </summary>
    public class Favorites
    {
        #region Private Members
        /// <summary>
        /// cachedAddFavoriteDialog
        /// </summary>
        private AddFavoriteDialog cachedAddFavoriteDialog;

        /// <summary>
        /// cachedCreateNewFavoriteFolderDialog
        /// </summary>
        private CreateNewFavoriteFolderDialog cachedCreateNewFavoriteFolderDialog;
        /// <summary>
        /// timeout value for dialog UIs to become ready 
        /// </summary>
        private int timeout = Constants.DefaultDialogTimeout;

        /// <summary>
        /// cachedConfirmShortcutDeleteDialog
        /// </summary>
        private ConfirmShortcutDeleteDialog cachedConfirmShortcutDeleteDialog;

        #endregion

        #region Constructor
        /// <summary>
        /// Favorites
        /// </summary>
        public Favorites()
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// AddFavoriteDialog
        /// </summary>
        public AddFavoriteDialog AddFavoriteDialog
        {
            get
            {
                if (this.cachedAddFavoriteDialog == null)
                {
                    this.cachedAddFavoriteDialog = new AddFavoriteDialog(CoreManager.MomConsole);
                }

                return this.cachedAddFavoriteDialog;
            }
        }

        /// <summary>
        /// CreateNewFavoriteFolderDialog
        /// </summary>
        public CreateNewFavoriteFolderDialog CreateNewFavoriteFolderDialog
        {
            get
            {
                if (this.cachedCreateNewFavoriteFolderDialog == null)
                {
                    this.cachedCreateNewFavoriteFolderDialog = new CreateNewFavoriteFolderDialog(CoreManager.MomConsole);
                }

                return this.cachedCreateNewFavoriteFolderDialog;
            }
        }
        /// <summary>
        /// ConfirmShortcutDeleteDialog
        /// </summary>
        public ConfirmShortcutDeleteDialog ConfirmShortcutDeleteDialog
        {
            get
            {
                if (this.cachedConfirmShortcutDeleteDialog == null)
                {
                    this.cachedConfirmShortcutDeleteDialog = new ConfirmShortcutDeleteDialog(CoreManager.MomConsole);
                    UISynchronization.WaitForUIObjectReady(this.cachedConfirmShortcutDeleteDialog, this.timeout);
                    this.cachedConfirmShortcutDeleteDialog.Extended.SetFocus();
                }

                return this.cachedConfirmShortcutDeleteDialog;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        public bool DeleteShortCutFromFavorite(FavoritesParameters parameters)
        {
            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            
            Utilities.LogMessage("Views.Delete :: Navigate To My Workspace(...)");
            try
            {
                navPane.SelectNode(NavigationPane.Strings.MyWorkspace + Constants.PathDelimiter + parameters.CreateInFolderName + Constants.PathDelimiter + parameters.FavoriteName,
                    NavigationPane.NavigationTreeView.MyWorkspace);
                // Selecting Delete from the context menu
                CoreManager.MomConsole.ExecuteContextMenu(Core.Console.Views.Views.Strings.DeleteContextMenu, true);
                CoreManager.MomConsole.Waiters.WaitForWindowReady(CoreManager.MomConsole.MainWindow, Constants.TenSeconds);
                //confirmation dialog
                bool confirmDialogFound = false;
                int currentRetry = 0;
                while (!confirmDialogFound && currentRetry <= 10)
                {
                    try
                    {
                        this.cachedConfirmShortcutDeleteDialog = null;
                        CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.ConfirmShortcutDeleteDialog.Controls.DeleteShortcutButton, this.timeout);
                        this.ConfirmShortcutDeleteDialog.ClickDeleteShortcut();
                        Utilities.LogMessage("Delete:: DeleteShortCut : " + currentMethod);
                        confirmDialogFound = true;
                    }
                    catch (Window.Exceptions.WindowNotFoundException)
                    {
                        Utilities.LogMessage("Delete:: Delete confirmation dialog not found yet, continue to wait. Attempt - " + currentRetry + " : " + currentMethod);
                        Maui.Core.Utilities.Sleeper.Delay(Constants.OneSecond);
                    }

                    currentRetry++;
                }

                CoreManager.MomConsole.Waiters.WaitForStatusReady(this.timeout);
                return(confirmDialogFound);
            }
            catch (Maui.Core.WinControls.TreeNode.Exceptions.NodeNotFoundException)
            {
                Utilities.LogMessage("Node not found that means it got deleted. : " + currentMethod);
                return(true);
            }
        }

        /// <summary>
        /// Add To Favorite
        /// </summary>
        /// <param name="parameters">FavoritesParameters</param>
        public void AddToFavorite(FavoritesParameters parameters)
        {
            NavigationPane navpane = CoreManager.MomConsole.NavigationPane;
            CoreManager.MomConsole.BringToForeground();
            CoreManager.MomConsole.Waiters.WaitForWindowReady(CoreManager.MomConsole.MainWindow,Constants.DefaultDialogTimeout);
            navpane.ClickWunderBarButton(NavigationPane.WunderBarButton.Monitoring);

            //wait for monitoring overview page to load
            UISynchronization.WaitForProcessReady(CoreManager.MomConsole.MainWindow, 60000);
            UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow, 60000);
            CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.OneMinute * 2);

            TreeNode viewNode = null;
            int dialogTimeoutSeconds = 15;

            try
            {

                if (parameters.PathToView != null)
                {
                    Utilities.LogMessage("Favorites.AddToFavorite:: Selecting View: " + parameters.PathToView);
                    viewNode = navpane.SelectNode(parameters.PathToView, NavigationPane.NavigationTreeView.Monitoring, MouseFlags.LeftButton, 10);

                    //Wait for ViewPane ready after selecting view node.
                    CoreManager.MomConsole.ViewPane.ScreenElement.WaitForReady();
                    CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.OneMinute * 2);
                }
                else
                {
                    Utilities.LogMessage("Favorites.AddToFavorite:: Attempting to use current selected node");
                    viewNode = navpane.Controls.MonitoringTreeView.SelectedItem;
                }
            }
            catch (TreeNode.Exceptions.NodeNotFoundException)
            {
                //if viewnode still null after selectnode, back to myworkspace and then selectnode again, workaround #516306
                    Utilities.LogMessage("Select Node fail, click back and try:: ");               
                    CoreManager.MomConsole.NavigationPane.ClickWunderBarButton(NavigationPane.WunderBarButton.MyWorkspace);
                    viewNode = navpane.SelectNode(parameters.PathToView, NavigationPane.NavigationTreeView.Monitoring, MouseFlags.LeftButton, 5);
                    if (viewNode == null)
                    {
                        throw;
                    }
            }
                      

            if (viewNode != null)
            {
                Utilities.LogMessage("Favorites.AddToFavorite:: ExecuteMenuItem: " + NavigationPane.Strings.ContextMenuAddToFavorites);

                //CoreManager.MomConsole.NavigationPane.Extended.SetFocus();
                // Execute the Add to favorites... context menu.
                //viewNode.ContextMenu.ExecuteMenuItem(NavigationPane.Strings.ContextMenuAddToFavorites);                             
                Utilities.LogMessage("Favorites.AddToFavorite:: Try to execute Context Menu :'" + NavigationPane.Strings.ContextMenuAddToFavorites + "'");
                CoreManager.MomConsole.ExecuteContextMenu(NavigationPane.Strings.ContextMenuAddToFavorites, true);
                CoreManager.MomConsole.Waiters.WaitForWindowReady(AddFavoriteDialog, Constants.DefaultDialogTimeout);
            }
           

            // Lets see if we should change the Name, or just keep default.
            if (parameters.FavoriteName != null)
            {
                Utilities.LogMessage("Favorites.AddToFavorite:: Try to set Name as '" + parameters.FavoriteName + "'");
                this.AddFavoriteDialog.NameText = parameters.FavoriteName;
            }

            // See if we are creating in a new folder.
            if (parameters.NewFolderName != null)
            {
                if (String.Compare(Core.Common.Utilities.RemoveAcceleratorKeys(AddFavoriteDialog.Strings.CreateInCollapsed), this.AddFavoriteDialog.Controls.CreateInButton.Caption) == 0)
                {
                    // Button is collapsed, lets open it.
                    CoreManager.MomConsole.Waiters.WaitForButtonEnabled(AddFavoriteDialog.Controls.CreateInButton, Constants.OneSecond * 5);
                    Utilities.LogMessage("Favorites.AddToFavorite:: Try to click button CreateIn.");
                    this.AddFavoriteDialog.ClickCreateIn();
                    CoreManager.MomConsole.Waiters.WaitForWindowReady(AddFavoriteDialog, Constants.DefaultDialogTimeout);
                }

                TreeNode folder = null;
                try
                {
                    // Checking to see if node exists before creating it again.
                    folder = this.AddFavoriteDialog.Controls.CreateInTreeView.Find(parameters.NewFolderName, 1, false, SearchMode.DepthFirst, true);
                    Utilities.LogMessage("Favorites.AddToFavorite:: Result of finding folder: '"+folder.ToString()+"'");
                }
                catch (TreeNode.Exceptions.NodeNotFoundException)
                {
                    // Node not found, all good.
                }

                // If it's null lets create it.
                if (folder == null)
                {
                    Utilities.LogMessage("Favorites.AddToFavorite:: Creating new folder: " + parameters.NewFolderName);
                    CoreManager.MomConsole.Waiters.WaitForButtonEnabled(AddFavoriteDialog.Controls.NewFolderButton, Constants.OneSecond * 5);
                    Utilities.LogMessage("Favorites.AddToFavorite:: Try to click button NewFolder");
                    this.AddFavoriteDialog.ClickNewFolder();

                    CoreManager.MomConsole.Waiters.WaitForWindowReady(CreateNewFavoriteFolderDialog, Constants.DefaultDialogTimeout);
                    Utilities.LogMessage("Favorites.AddToFavorite:: Trying to set NewFolderName as '" + parameters.NewFolderName + "'");
                    this.CreateNewFavoriteFolderDialog.FolderNameText = parameters.NewFolderName;

                    CoreManager.MomConsole.Waiters.WaitForButtonEnabled(CreateNewFavoriteFolderDialog.Controls.OKButton, Constants.OneSecond * 5);
                    Utilities.LogMessage("Favorites.AddToFavorite:: Try to click button OK.");
                    this.CreateNewFavoriteFolderDialog.ClickOK();
                    CoreManager.MomConsole.Waiters.WaitForWindowClose(CreateNewFavoriteFolderDialog, Constants.DefaultDialogTimeout);
                }

                // Setting CreateInFolderName to the NewFolderName so we create in the right folder.
                parameters.CreateInFolderName = parameters.NewFolderName;
            }

            // If CreateInFolderName specified, lets select it.
            if (parameters.CreateInFolderName != null)
            {
                Utilities.LogMessage("Favorites.AddToFavorite:: Createing in folder: " + parameters.CreateInFolderName);

                if (String.Compare(Core.Common.Utilities.RemoveAcceleratorKeys(AddFavoriteDialog.Strings.CreateInCollapsed), this.AddFavoriteDialog.Controls.CreateInButton.Caption) == 0)
                {
                    // Button is collapsed, lets open it.
                    CoreManager.MomConsole.Waiters.WaitForButtonEnabled(AddFavoriteDialog.Controls.CreateInButton, Constants.OneSecond*5);
                    Utilities.LogMessage("Favorites.AddToFavorite:: Try to click button CreateIn.");
                    this.AddFavoriteDialog.ClickCreateIn();
                    CoreManager.MomConsole.Waiters.WaitForWindowReady(AddFavoriteDialog, Constants.DefaultDialogTimeout);
                }

                Utilities.LogMessage("Favorites.AddToFavorite:: Try to select folder '" + parameters.CreateInFolderName + "'");
                this.AddFavoriteDialog.Controls.CreateInTreeView.Find(parameters.CreateInFolderName, 1, false, SearchMode.DepthFirst, true).Click();
            }
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(AddFavoriteDialog.Controls.OKButton, Constants.OneSecond * 5);
            Utilities.LogMessage("Favorites.AddToFavorite:: Try to click button OK.");
            this.AddFavoriteDialog.ClickOK();
            CoreManager.MomConsole.Waiters.WaitForWindowClose(AddFavoriteDialog, Constants.DefaultDialogTimeout);
        }

        #endregion

        #region Favorites Parameters Class
        /// <summary>
        /// Favorites Parameters Class
        /// </summary>
        public class FavoritesParameters
        {
            #region Private Members
            private string cachedPathToView = null;
            private string cachedFavoriteName = null;
            private bool cachedExpandCreateIn = false;
            private string cachedCreateInFolderName = null;
            private bool cachedCreateNewFolder = false;
            private string cachedNewFolderName = null;
            #endregion

            #region Constructors
            /// <summary>
            /// Default Constructor.
            /// </summary>
            public FavoritesParameters()
            {
            }
            #endregion

            #region Properties
            /// <summary>
            /// PathToView
            /// </summary>
            public string PathToView
            {
                get
                {
                    return this.cachedPathToView;
                }

                set
                {
                    this.cachedPathToView = value;
                }
            }

            /// <summary>
            /// Favorite Name
            /// </summary>
            public string FavoriteName
            {
                get
                {
                    return this.cachedFavoriteName;
                }

                set
                {
                    this.cachedFavoriteName = value;
                }
            }

            /// <summary>
            /// CreateInFolderName
            /// </summary>
            public string CreateInFolderName
            {
                get
                {
                    return this.cachedCreateInFolderName;
                }

                set
                {
                    this.cachedCreateInFolderName = value;
                }
            }

            /// <summary>
            /// ExpandCreateIn
            /// </summary>
            public bool ExpandCreateIn
            {
                get
                {
                    return this.cachedExpandCreateIn;
                }

                set
                {
                    this.cachedExpandCreateIn = value;
                }
            }

            /// <summary>
            /// CreateNewFolder
            /// </summary>
            public bool CreateNewFolder
            {
                get
                {
                    return this.cachedCreateNewFolder;
                }

                set
                {
                    this.cachedCreateNewFolder = value;
                }
            }

            /// <summary>
            /// NewFolderName
            /// </summary>
            public string NewFolderName
            {
                get
                {
                    return this.cachedNewFolderName;
                }

                set
                {
                    this.cachedNewFolderName = value;
                }
            }
            #endregion
        }
        #endregion
    }
}
