// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="RequestResultDetailsDialogDetailsTab.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Web Application
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[v-eryon] 7/27/2009 Created
// </history>
// -----------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using Maui.Core;
using Mom.Test.UI.Core.Common;

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.URL.Dialogs
{

    #region Interfaces
    /// <summary>
    /// Console ActionsPane Interface
    /// </summary>
    public interface IActionsPane
    {
        /// <summary>
        /// Splitter Bar
        /// </summary>
        ActiveAccessibility Splitter
        {
            get;
        }
    }
    #endregion


    /// ------------------------------------------------------------------
    /// <summary>
    /// Actions Pane Class
    /// </summary>
    /// ------------------------------------------------------------------
    public class WebApplicationEditorActionPane : Window, IActionsPane
    {
        #region Constructor
        /// ------------------------------------------------------------------
        /// <summary>
        /// ActionsPane Window
        /// </summary>
        /// <param name="win">Window</param>
        /// ------------------------------------------------------------------
        public WebApplicationEditorActionPane(Window win) :
            base(win.Extended.AccessibleObject.FindChild(ControlIDs.ActionsPane).Window.Extended.HWnd)
        {
            Utilities.LogMessage("WebApplicationEditorActionPane:: Constructor");
        }

        #endregion

        #region Properties
        /// ------------------------------------------------------------------
        /// <summary>
        /// Returns if Pane is Visible or Not.
        /// </summary>
        /// ------------------------------------------------------------------
        public new bool IsVisible
        {
            get
            {
                return this.Extended.IsVisible;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Access to the ActionsPane Splitter Bar
        /// </summary>
        /// ------------------------------------------------------------------
        public ActiveAccessibility Splitter
        {
            get
            {
                return CoreManager.MomConsole.MainWindow.Extended.AccessibleObject.FindChild(ControlIDs.ActionsPaneSplitter);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// MyWorkspace Control - NYI
        /// </summary>
        /// ------------------------------------------------------------------
        public MomControls.TaskStrip MyWorkspace
        {
            get
            {
                return new MomControls.TaskStrip(this, MomControls.TaskStrip.ControlIDs.MyWorkspace);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Tasks Control - NYI
        /// </summary>
        /// ------------------------------------------------------------------
        public MomControls.TaskStrip Tasks
        {
            get
            {
                return new MomControls.TaskStrip(this, MomControls.TaskStrip.ControlIDs.Tasks);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Related Tasks - NYI
        /// </summary>
        /// ------------------------------------------------------------------
        public MomControls.TaskStrip RelatedTasks
        {
            get
            {
                return new MomControls.TaskStrip(this, MomControls.TaskStrip.ControlIDs.RelatedTasks);
            }
        }
        #endregion


        #region Public Methods

        /// ------------------------------------------------------------------
        /// <summary>
        /// Generic method to click a link on Actions Pane
        /// </summary>
        /// <param name="linkName">string</param>
        /// <param name="actionsPaneNode">Task node in the actions pane</param>
        /// <exception cref="MomControls.TaskStrip.Exceptions.TaskStripItemNotFoundException"></exception>
        /// ------------------------------------------------------------------
        public void ClickLink(string linkName, string actionsPaneNode)
        {
            Utilities.LogMessage("ClickLink:: entering method");

            UISynchronization.WaitForUIObjectReady(
                            this,
                            Constants.DefaultDialogTimeout);

            Utilities.LogMessage("ClickLink:: Clicking Task link: \"" + linkName + "\"");
            //Fix bug#188747
            Maui.Core.WinControls.Control linkElement = new Maui.Core.WinControls.Control(this,
                        new QID(";[MSAA, VisibleOnly]Name = ~'" + linkName + "' && Role = 'link'"), Constants.DefaultViewLoadTimeout);
            
            CoreManager.MomConsole.Waiters.WaitForWindowEnabled(linkElement, Constants.OneSecond * 10);
            
            linkElement.ScreenElement.LeftButtonClick(-1, -1, true, KeyboardFlags.NoFlag);

            Utilities.LogMessage("ClickLink:: leaving method");
        }

        #endregion

        #region Strings Class

        /// ------------------------------------------------------------------
        /// <summary>
        /// Resource string definitions.
        /// </summary>
        /// ------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceActionsPaneWebRequest =
                ";Web Request;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.WebApplicationEditorForm;taskStripWebRequest.Text";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Web Request Insert
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceActionsPaneWebRequestInsert =
                ";Insert request;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.WebApplicationEditorForm;taskStripTextItemInsertRequest.Text";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Web Request Group
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceActionsPaneWebRequestGroup =
                ";Group requests;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.WebApplicationEditorForm;taskStripTextItemCreateGroup.Text";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Web Request Properties
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceActionsPaneWebRequestProperties =
                //Resource string is invalid for other language build but EN; If remove '.en' then invalid for all language build
                //";Properties;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.WebApplicationEditorForm.en;taskStripTextItemProperties.Text";
                ";Properties;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.AuthoringDialog;$this.Text";
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Web Request
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceActionsPaneWebApplication =
                ";Web Application;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.WebApplicationEditorForm;taskStripWebApplication.Text";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Web Request RUN NOW
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceActionsPaneRunNow =
                ";Run Now;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.WebApplicationEditorForm;taskStripRunNow.Text";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Web Request Run Test
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceActionsPaneRunNowRunTest =
                ";Run Test;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.WebApplicationEditorForm;taskStripTextItemRunNow.Text";
            
            #endregion

            #region Private Members

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedActionsPaneWebRequest;

            /// <summary>
            /// cachedActionsPaneRunNow
            /// </summary>
            private static string cachedActionsPaneRunNow;

            /// <summary>
            /// cachedActionsPaneWebRequestInsert
            /// </summary>
            private static string cachedActionsPaneWebRequestInsert;

            /// <summary>
            /// cachedActionsPaneWebRequestProperties
            /// </summary>
            private static string cachedActionsPaneWebRequestProperties;

            /// <summary>
            /// cachedActionsPaneWebRequestGroup
            /// </summary>
            private static string cachedActionsPaneWebRequestGroup;

            /// <summary>
            /// cachedActionsPaneRunNowRunTest
            /// </summary>
            private static string cachedActionsPaneRunNowRunTest;

            #endregion

            #region Properties

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// ---------------------------------------------------------------
            public static string ActionsPaneNodeWebRequest
            {
                get
                {
                    if ((cachedActionsPaneWebRequest == null))
                    {
                        cachedActionsPaneWebRequest = CoreManager.MomConsole.GetIntlStr(ResourceActionsPaneWebRequest);
                    }

                    return cachedActionsPaneWebRequest;
                }
            }
            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Monitored Components in the actions pane translated resource string
            /// </summary>
            /// ---------------------------------------------------------------
            public static string ActionsPaneNodeRunNow
            {
                get
                {
                    if ((cachedActionsPaneRunNow == null))
                    {
                        cachedActionsPaneRunNow = CoreManager.MomConsole.GetIntlStr(ResourceActionsPaneRunNow);
                    }

                    return cachedActionsPaneRunNow;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Monitored Components in the actions pane translated resource string
            /// </summary>
            /// ---------------------------------------------------------------
            public static string ActionsPaneNodeWebRequestInsert
            {
                get
                {
                    if ((cachedActionsPaneWebRequestInsert == null))
                    {
                        cachedActionsPaneWebRequestInsert = CoreManager.MomConsole.GetIntlStr(ResourceActionsPaneWebRequestInsert);
                    }

                    return cachedActionsPaneWebRequestInsert;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Monitored Components in the actions pane translated resource string
            /// </summary>
            /// ---------------------------------------------------------------
            public static string ActionsPaneLinkWebRequestGroup
            {
                get
                {
                    if ((cachedActionsPaneWebRequestGroup == null))
                    {
                        cachedActionsPaneWebRequestGroup = CoreManager.MomConsole.GetIntlStr(ResourceActionsPaneWebRequestGroup);
                    }

                    return cachedActionsPaneWebRequestGroup;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Monitored Components in the actions pane translated resource string
            /// </summary>
            /// ---------------------------------------------------------------
            public static string ActionsPaneLinkWebRequestProperties
            {
                get
                {
                    if ((cachedActionsPaneWebRequestProperties == null))
                    {
                        cachedActionsPaneWebRequestProperties = CoreManager.MomConsole.GetIntlStr(ResourceActionsPaneWebRequestProperties);
                    }

                    return cachedActionsPaneWebRequestProperties;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Monitored Components in the actions pane translated resource string
            /// </summary>
            /// ---------------------------------------------------------------
            public static string ActionsPaneLinkRunNowRunTest
            {
                get
                {
                    if ((cachedActionsPaneRunNowRunTest == null))
                    {
                        cachedActionsPaneRunNowRunTest = CoreManager.MomConsole.GetIntlStr(ResourceActionsPaneRunNowRunTest);
                    }

                    return cachedActionsPaneRunNowRunTest;
                }
            }

            #endregion
        }
        #endregion

        #region ControlIDs
        /// ------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// ------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ActionsPane Window
            /// </summary>
            public const string ActionsPane = "";

            /// <summary>
            /// Control ID for ActionsPane Splitter
            /// </summary>
            public const string ActionsPaneSplitter = "TaskSplitter";
        }
        #endregion
    }
}
