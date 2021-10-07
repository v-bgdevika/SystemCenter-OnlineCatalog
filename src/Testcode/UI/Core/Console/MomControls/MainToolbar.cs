//----------------------------------------------------------------------------
// <copyright file="MainToolbar.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   Main Console Toolbar.
// </summary>
//  <history>
//   [mbickle] 13JUL05: Created
//   [mbickle] 02SEP05: Fixed some FxCop Issues.
//   [faizalk] 27MAR06 Rename TaskPane to ActionsPane
//  </history>
//----------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.MomControls
{
    #region Using directives
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Maui.Core.WinControls;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Mom.Test.UI.Core.Common;
    #endregion

    #region Interface Definition - IMainToolbar
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IMainToolbar, for MainToolbar.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[mbickle] 12JUL05 Created
    ///     [faizalk] 27MAR06 Rename TaskPane to ActionsPane
    /// </history>
    /// -----------------------------------------------------------------------------
    public interface IMainToolbar
    {
        /// <summary>
        /// Back button
        /// </summary>
        ToolbarItem BackToolbarItem
        {
            get;
        }

        /// <summary>
        /// Forward button
        /// </summary>
        ToolbarItem ForwardToolbarItem
        {
            get;
        }

        /// <summary>
        /// Refresh button
        /// </summary>
        ToolbarItem RefreshToolbarItem
        {
            get;
        }

        /// <summary>
        /// Home button
        /// </summary>
        ToolbarItem HomeToolbarItem
        { 
            get;
        }

        /// <summary>
        /// Tasks Pane button
        /// </summary>
        ToolbarItem ActionsPaneToolbarItem 
        { 
            get;
        }
    }
    #endregion

    /// ----------------------------------------------------------------------
    /// <summary>
    /// Console Main Toolbar Definition
    /// </summary>
    /// <history>
    /// [mbickle] 13JUL05 Created
    /// [sunsingh] 24Feb10 Marking this Class and all it's member as obselete So the We Use SCUI SControl MainToolBar Class
    /// </history>
    /// ----------------------------------------------------------------------
    public sealed class MainToolbar : Toolbar, IMainToolbar
    {
        private ConsoleApp consoleApp; 

        #region "constructors"
        /// ------------------------------------------------------------------
        /// <summary>
        /// constructor 
        /// </summary>
        /// <param name="app">Console app</param>
        /// <remarks></remarks>
        /// <history>
        /// [mbickle] 13JUL05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public MainToolbar(ConsoleApp app) 
            : base(new Window(
            ConsoleApp.Strings.ConsoleToolBarCommandBar,
            StringMatchSyntax.ExactMatch, 
            WindowClassNames.WinForms10Window8, 
            StringMatchSyntax.WildCard, 
            app.MainWindow, 
            Constants.DefaultDialogTimeout))
        {
            this.consoleApp = app;
        }
        #endregion

        #region "Properties"
        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets the WordPad app
        /// </summary>
        /// <history>
        /// [mbickle] 	13JUL05	Created
        /// </history>
        /// ------------------------------------------------------------------
        public ConsoleApp App
        {
            get
            {
                return this.consoleApp;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Exposes the controls
        /// </summary>
        /// <history>
        /// [mbickle] 	13JUL05	Created
        /// </history>
        /// ------------------------------------------------------------------

       public IMainToolbar Controls
        {
            get
            {
                return this;
            }
        }
        #endregion

        #region "IMainToolbar Implementation"
        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets the Back Toolbar item
        /// </summary>
        /// <history>
        /// [mbickle] 	13JUL05	Created
        /// </history>
        /// ------------------------------------------------------------------
        ToolbarItem IMainToolbar.BackToolbarItem
        {
            get
            {
                return this.ToolbarItems[0];
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets the Forward Toolbar item
        /// </summary>
        /// <history>
        /// [mbickle] 	13JUL05	Created
        /// </history>
        /// ------------------------------------------------------------------
        ToolbarItem IMainToolbar.ForwardToolbarItem
        {
            get
            {
                return this.ToolbarItems[1];
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets the Refresh Toolbar item
        /// </summary>
        /// <history>
        /// [mbickle] 	13JUL05	Created
        /// </history>
        /// ------------------------------------------------------------------
        ToolbarItem IMainToolbar.RefreshToolbarItem
        {
            get
            {
                return this.ToolbarItems[2];
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets the Home Toolbar item
        /// </summary>
        /// <history>
        /// [mbickle] 	13JUL05	Created
        /// </history>
        /// ------------------------------------------------------------------
        ToolbarItem IMainToolbar.HomeToolbarItem
        {
            get
            {
                return this.ToolbarItems[3];
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets the ActionsPane Toolbar item
        /// </summary>
        /// <history>
        /// [mbickle] 	13JUL05	Created
        /// [faizalk] 27MAR06 Rename TaskPane to ActionsPane
        /// </history>
        /// ------------------------------------------------------------------
        ToolbarItem IMainToolbar.ActionsPaneToolbarItem
        {
            get
            {
                return this.ToolbarItems[6];
            }
        }
        #endregion

        #region Public Methods
        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Back Toolbar Button
        /// </summary>
        /// ------------------------------------------------------------------
        public void ClickBack()
        {
            this.Controls.BackToolbarItem.Click();
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Forward Toolbar Button
        /// </summary>
        /// ------------------------------------------------------------------
        public void ClickForward()
        {
            this.Controls.ForwardToolbarItem.Click();
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Refresh Toolbar Button
        /// </summary>
        /// ------------------------------------------------------------------
        [Obsolete("call into SCUI SControls MainToolBar MainToolbar Methods")] 
       public void ClickRefresh()
        {
            this.Controls.RefreshToolbarItem.Click();
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Home Toolbar Button
        /// </summary>
        /// ------------------------------------------------------------------
        public void ClickHome()
        {
            this.Controls.HomeToolbarItem.Click();
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Actions Pane Toolbar Button
        /// </summary>
        /// ------------------------------------------------------------------
        public void ClickActionsPane()
        {
            this.Controls.ActionsPaneToolbarItem.Click();
        }
        #endregion
    }
}
