// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="Overview.cs">
//  Copyright (c) Microsoft Corporation 2008
// </copyright>
// <summary>
//  Overview Page Control
// </summary>
// <history>
//  [mbickle] 6/25/2008 Created
// </history>
// -----------------------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.MomControls
{
    #region Using directives
    using Maui.Core;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Common;
    #endregion

    /// <summary>
    /// Overview Page Class
    /// </summary>
    public class Overview : Window
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion

        #region Constructors
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Create reference to a Overview Page
        /// </summary>
        /// <param name="window">Window</param>
        /// <history>
        ///  [mbickle] 6/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public Overview(Window window) : 
                base(window)
        {
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Add Content
        /// </summary>
        /// <param name="contentItem">Name of Item to Add</param>
        /// <exception cref="System.InvalidOperationException">System.InvalidOperationException</exception>
        public virtual void AddContent(string contentItem)
        {
            this.AddRemoveContent(contentItem, true);
        }

        /// <summary>
        /// Remove Content
        /// </summary>
        /// <param name="contentItem">Name of Item to Remove</param>
        /// <exception cref="System.InvalidOperationException">System.InvalidOperationException</exception>
        public virtual void RemoveContent(string contentItem)
        {
            this.AddRemoveContent(contentItem, false);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Add/Remove Content
        /// </summary>
        /// <param name="contentItem">Name of Item to Remove</param>
        /// <param name="addItem">Add Item = True, Remove = False</param>
        /// <exception cref="System.InvalidOperationException">System.InvalidOperationException</exception>
        private void AddRemoveContent(string contentItem, bool addItem)
        {
            Window overviewPageHeader = new Window(CoreManager.MomConsole.ViewPane, QueryIds.PageHeader, Constants.DefaultControlTimeout);

            // Find the Add Content Button
            Button addContentButton = new Button(overviewPageHeader, QueryIds.AddContentButton, Constants.DefaultControlTimeout);

            if (addContentButton != null)
            {
                // Click the Add Content Button
                Utilities.LogMessage("OverView.AddRemoveContent:: addContentButton.ScreenElement.State: " + addContentButton.ScreenElement.State);
                Utilities.LogMessage("OverView.AddRemoveContent:: addContentButton.ScreenElement.Role: " + addContentButton.ScreenElement.Role);

                Utilities.LogMessage("OverView.AddRemoveContent:: Clicking AddContent Button");
                addContentButton.Click();

                Utilities.LogMessage("OverView.AddRemoveContent:: this.ScreenElement.WaitForReady()");
                this.ScreenElement.WaitForReady();

                Utilities.TakeScreenshot("OverView.AddRemoveContent.ButtonClicked");
                Utilities.LogMessage("OverView.AddRemoveContent:: addContentButton.ScreenElement.State: " + addContentButton.ScreenElement.State);
                Utilities.LogMessage("OverView.AddRemoveContent:: addContentButton.ScreenElement.Role: " + addContentButton.ScreenElement.Role);

                // Get reference to the Tile Checkbox list.
                Utilities.LogMessage("OverView.AddRemoveContent:: Looking for TileList Window.");
                Window tileListWindow = new Window(new QID(";[UIA, VisibleOnly]AutomationId='CustomizePopup';[UIA, VisibleOnly]AutomationId = 'PART_CustomizeTileList'"), Constants.DefaultControlTimeout);

                if (null == tileListWindow)
                {
                    Utilities.TakeScreenshot("OverView.AddRemoveContent.FailedToFindTileListWindow");
                    throw new System.InvalidOperationException("Failed to find TileList Window");
                }

                Utilities.TakeScreenshot("OverView.AddRemoveContent.DialogUp");

                // Look for the Item Checkbox to select.
                Utilities.LogMessage("OverView.AddRemoveContent:: Looking for '" + contentItem + "' checkbox.");
                CheckBox checkBox = new CheckBox(tileListWindow, new QID(";[UIA, VisibleOnly]Name = '" + contentItem + "' && Role = 'check box'"), Constants.DefaultControlTimeout);

                if (null == checkBox)
                {
                    Utilities.TakeScreenshot("OverView.AddRemoveContent.FailedToFindCheckBox");
                    throw new System.InvalidOperationException("Failed to find CheckBox: " + contentItem);
                }

                Utilities.TakeScreenshot("OverView.AddRemoveContent.BeforeCheck");
                Utilities.LogMessage("OverView.AddRemoveContent:: Setting '" + contentItem + "' checkbox = " + addItem.ToString());

                int retry = 0;
                int maxtry = 5;
                while (checkBox.Checked != addItem && retry <= maxtry)
                {
                    try
                    {
                        checkBox.Checked = addItem;
                    }
                    catch (System.InvalidOperationException ex)
                    {
                        Utilities.LogMessage("OverView.AddRemoveContent:: Failed to set Checked state, we'll try again.  Exception:: " + ex);
                    }

                    retry++;
                }

                Utilities.TakeScreenshot("OverView.AddRemoveContent.TileChecked");
                Utilities.LogMessage("OverView.AddRemoveContent.TileChecked");

                // Close the Add Content Window
                Utilities.LogMessage("OverView.AddRemoveContent:: Clicking AddContent Button to close Popup.");
                addContentButton.Click();
                CoreManager.MomConsole.WaitForWindowIdle(CoreManager.MomConsole.ViewPane, Constants.DefaultDialogTimeout);
                Utilities.TakeScreenshot("OverView.AddRemoveContent.DialogClosed");
            }
        }
        #endregion

        #region Query ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all query ID's.
        /// </summary>
        /// <history>
        ///  [mbickle] 6/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static class QueryIds
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for AddContent Button query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAddContentButton = ";[UIA]AutomationId=\'Customize\'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for PageHeader query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePageHeader = ";[UIA]AutomationId=\'PageHeader\'";
            #endregion

            #region Private Members
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedAddContentButton;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedPageHeader;
            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AddContent Button translated resource qid string
            /// </summary>
            /// <history>
            ///  [mbickle] 6/25/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID AddContentButton
            {
                get
                {
                    if ((cachedAddContentButton == null))
                    {
                        cachedAddContentButton = new QID(ResourceAddContentButton);
                    }

                    return cachedAddContentButton;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the PageHeader translated resource qid string
            /// </summary>
            /// <history>
            ///  [mbickle] 6/25/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID PageHeader
            {
                get
                {
                    if ((cachedPageHeader == null))
                    {
                        cachedPageHeader = new QID(ResourcePageHeader);
                    }

                    return cachedPageHeader;
                }
            }
            #endregion
        }
        #endregion
    }
}
