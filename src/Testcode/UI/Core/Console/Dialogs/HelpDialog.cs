//-------------------------------------------------------------------
// <copyright file="HelpDialog.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   MOM Help Dialog
// </summary>
//  <history>
//   [mbickle] 02DEC04: Created
//  </history>
//-------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.Dialogs
{
    #region Using directives
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Maui.Core.HtmlControls;
    using Mom.Test.UI.Core.Common;
    #endregion

    #region "IHelpDialogControls interface definition"
    /// <summary>
    /// Mom Help Dialog Controls
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IHelpDialogControls
    {
        /// <summary>
        /// Toolbar
        /// </summary>
        Toolbar HelpDialogToolbar { get; }

        /// <summary>
        /// TreeListTab Control
        /// </summary>
        TabControl HelpTreeListTabControl { get; }

        /// <summary>
        /// TreeList
        /// </summary>
        TreeView HelpTreeList { get; }

        /// <summary>
        /// HTMLDoc
        /// </summary>
        HtmlDocument HTMLDoc { get; }
    }

#endregion

    /// -----------------------------------------------------------------------------
    /// Project     : Maui
    /// Class       : HelpDialog
    ///  Copyright (C) 2002, Microsoft Corporation
    /// -----------------------------------------------------------------------------
    ///  <summary>
    ///  Declaration for the Help dialog invoked from the Agent Install Wizard.
    ///  </summary>
    ///  <remarks></remarks>
    ///  <history>
    ///     [glennado] 2/15/2004 Created
    ///  </history>
    /// -----------------------------------------------------------------------------
    public class HelpDialog : Dialog, IHelpDialogControls
    {
        #region "Member Variables"
        /// <summary>
        /// Cached reference to Toolbar
        /// </summary>
        private Toolbar cachedHelpDialogToolbar;

        /// <summary>
        /// Cached reference to HTML Doc
        /// </summary>
        private HtmlDocument cachedHTMLDoc;

        /// <summary>
        /// Cached reference to TreeList Tab Control
        /// </summary>
        private TabControl cachedHelpTreeListTabControl;

        /// <summary>
        /// Cached reference to TreeList
        /// </summary>
        private TreeView cachedHelpTreeList;
        #endregion

        #region "Constructor and Init function"

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Constructor for the Help dialog invoked from Agent Install Wizard.
        /// </summary>
        /// <param name="app">ConsoleApp object owning the dialog.</param>
        /// <history>
        ///    [glennado] 2/15/2004 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public HelpDialog(ConsoleApp app) : 
            base(app, Init())
        {
        }
        #endregion

        #region "Properties"
        /// -----------------------------------------------------------------------------
        ///  <summary>
        ///  Exposes access to the raw controls for this dialog
        ///  </summary>
        ///  <value>An interface that groups all of the dialog's control properties together</value>
        ///  <remarks></remarks>
        ///  <history>
        ///     [glennado] 2/15/2004 Created
        ///  </history>
        /// -----------------------------------------------------------------------------
        public virtual IHelpDialogControls Controls
        {
            get
            {
                return this;
            }
        }

        /// -----------------------------------------------------------------------------
        ///  <summary>
        ///  Exposes access to the HelpDialogToolbar control
        ///  </summary>
        ///  <value></value>
        ///  <remarks></remarks>
        ///  <history>
        ///     [glennado] 2/15/2004 Created
        ///  </history>
        /// -----------------------------------------------------------------------------
        Toolbar IHelpDialogControls.HelpDialogToolbar
        {
            get
            {
                if ((this.cachedHelpDialogToolbar == null))
                {
                    this.cachedHelpDialogToolbar = new Toolbar(this, ControlIDs.HelpDialogToolbar.ToString());
                }
                return this.cachedHelpDialogToolbar;
            }
        }

        /// -----------------------------------------------------------------------------
        ///  <summary>
        ///  Exposes access to the HTMLDoc control
        ///  </summary>
        ///  <value></value>
        ///  <remarks></remarks>
        ///  <history>
        ///     [glennado] 2/15/2004 Created
        ///  </history>
        /// -----------------------------------------------------------------------------
        HtmlDocument IHelpDialogControls.HTMLDoc
        {
            get
            {
                if ((this.cachedHTMLDoc == null))
                {
                    Window wndTemp = this;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedHTMLDoc = new HtmlDocument(wndTemp);
                }
                return this.cachedHTMLDoc;
            }
        }

        /// -----------------------------------------------------------------------------
        ///  <summary>
        ///  Exposes access to the HelpTreeListTabControl control
        ///  </summary>
        ///  <value></value>
        ///  <remarks></remarks>
        ///  <history>
        ///     [glennado] 2/15/2004 Created
        ///  </history>
        /// -----------------------------------------------------------------------------
        TabControl IHelpDialogControls.HelpTreeListTabControl
        {
            get
            {
                if ((this.cachedHelpTreeListTabControl == null))
                {
                    this.cachedHelpTreeListTabControl = new TabControl(this, ControlIDs.HelpTreeListTabControl);
                }
                return this.cachedHelpTreeListTabControl;
            }
        }

        /// -----------------------------------------------------------------------------
        ///  <summary>
        ///  Exposes access to the HelpTreeList control
        ///  </summary>
        ///  <value></value>
        ///  <remarks></remarks>
        ///  <history>
        ///     [glennado] 2/15/2004 Created
        ///  </history>
        /// -----------------------------------------------------------------------------
        TreeView IHelpDialogControls.HelpTreeList
        {
            get
            {
                if ((this.cachedHelpTreeList == null))
                {
                    this.cachedHelpTreeList = new TreeView(this, ControlIDs.HelpTreeList);
                }
                return this.cachedHelpTreeList;
            }
        }

#endregion

        #region "Methods"

        /// -----------------------------------------------------------------------------
        ///  <summary>
        ///  Routine to Close the Help dialog.
        ///  </summary>
        ///  <remarks></remarks>
        ///  <history>
        ///     [glennado] 5/25/2004 - Created
        ///  </history>
        /// -----------------------------------------------------------------------------
        public virtual void Close()
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
            this.SendKeys(KeyboardCodes.CloseWindow);
            Sleeper.Delay(1000);
        }
        #endregion

        #region Private Methods
        /// -----------------------------------------------------------------------------
        ///  <summary>
        ///  This function will attempt to find a showing instance of the dialog.
        ///  </summary>
        ///  <returns>The dialog's Window</returns>
        ///  <history>
        ///     [glennado] 2/15/2004 Created
        ///  </history>
        /// -----------------------------------------------------------------------------
        private static Window Init()
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                tempWindow = new Window(Strings.DialogTitle, Maui.Core.Utilities.StringMatchSyntax.ExactMatch);

                UISynchronization.WaitForUIObjectReady(
                    tempWindow,
                    Constants.DefaultDialogTimeout);
                tempWindow.Extended.SetFocus();
            }
            catch (Exceptions.WindowNotFoundException ex)
            {
                throw new Window.Exceptions.WindowNotFoundException("Init " +
                    "function could not find or bring up the dialog." + ex);
            }
            return tempWindow;
        }

        #endregion

        #region "Strings"
        /// <summary>
        /// Mom Help Dialog Strings
        /// </summary>
        public class Strings
        {
            #region Constants Generated Code

            // TODO: DialogMaker could not find the Resource for this string.  Find it and replace literal created by tool.
            private const string ResourceDialogTitle = "Microsoft Operations Manager 2005 Help";

            // TODO: DialogMaker could not find the Resource for this string.  Find it and replace literal created by tool.
            private const string ResourceTab = "Tab0";

            #endregion

            #region Member Variables

            private static string cachedDialogTitle;
            private static string cachedTab;

            #endregion

            #region Properties
            /// <summary>
            /// Dialog Title
            /// </summary>
            public static string DialogTitle
            {
                get
                {
                    if (cachedDialogTitle == null)
                    {
                        Strings.cachedDialogTitle = CoreManager.MomConsole.GetIntlStr(
                            ResourceDialogTitle);
                    }
                    return cachedDialogTitle;
                }
            }

            /// <summary>
            /// Tab
            /// </summary>
            public static string Tab
            {
                get
                {
                    if (cachedTab == null)
                    {
                        Strings.cachedTab = CoreManager.MomConsole.GetIntlStr(
                            ResourceTab);
                    }
                    return cachedTab;
                }
            }

            #endregion
        }
        #endregion

        #region "Control IDs"
        /// <summary>
        /// Control ID's
        /// </summary>
        public class ControlIDs
        {
            /// <summary>
            /// Toolbar Control ID
            /// </summary>
            public const int HelpDialogToolbar = 0x3EE;

            /// <summary>
            /// TreeList Tab Controle ID
            /// </summary>
            public const int HelpTreeListTabControl = 0x3EF;

            /// <summary>
            /// TreeList Control ID
            /// </summary>
            public const int HelpTreeList = 0x0;
        }
        #endregion
    }
}
