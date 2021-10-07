// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="KnowledgeHelper.cs">
//   Copyright (c) Microsoft Corporation 2009
// </copyright>
//
// <summary>
//   Contains utility classes for the MOMX UI Knowledge automated tests
// </summary>
// <history>
//   [v-waltli] 5/26/2009 Created
// </history>
// -----------------------------------------------------------------------------------------

using System;
using System.Reflection;
using Maui.Core.WinControls;
using Mom.Test.UI.Core.Console.MonitoringConfiguration.Knowledge.Dialogs;
using Mom.Test.UI.Core.Common;
using Microsoft.EnterpriseManagement.Configuration;
using mshtml;
using Mom.Test.UI.Core.Console.Views.Alerts;
using Maui.Core.Utilities;
using Maui.Core;

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Knowledge
{
    /// <summary>
    /// Knowledge Helper Class
    /// </summary>
    /// <history>
    ///   [v-waltli] 5/26/2009 Created
    /// </history>
    public class KnowledgeHelper
    {
        #region Constants

        /// <summary>
        /// Max retry to search monitor row in grid view
        /// </summary>
        private const int MaxRetry = 3;

        /// <summary>
        /// Refresh view interval in seconds
        /// </summary>
        private const int RefreshInterval = 30;

        /// <summary>
        /// Sleep time to wait for monitor appearing in grid view
        /// </summary>
        private const int Timeout = 5;

        #endregion

        #region Enums

        /// <summary>
        /// Types of knowledge
        /// </summary>
        public enum KNOWLEDGE_TYPE
        {
            /// <summary>
            /// Product knowledge
            /// </summary>
            PRODUCT_KNOWLEDGE,
            /// <summary>
            /// Company knowledge
            /// </summary>
            COMPANY_KNOWLEDGE
        }

        /// <summary>
        /// Types of knowledge content
        /// </summary>
        public enum KNOWLEDGE_CONTENT_TYPE
        {
            /// <summary>
            /// Text
            /// </summary>
            TEXT,
            /// <summary>
            /// Link
            /// </summary>
            LINK
        }

        /// <summary>
        /// Types of knowledge objects
        /// </summary>
        public enum KNOWLEDGE_OBJECT_TYPE
        {
            /// <summary>
            /// Monitor
            /// </summary>
            MONITOR,
            /// <summary>
            /// Rule
            /// </summary>
            RULE
        }

        #endregion

        #region Private Member

        /// <summary>
        /// Current method name
        /// </summary>
        private static string currentMethodName = String.Empty;

        #endregion

        #region Public Methods

        /// <summary>
        /// Navigate to Monitors / Rules view and select the knowledge object
        /// </summary>
        /// <param name="knowledgeObjectType">knowledge Object Type</param>
        /// <param name="knowledgeObjectTargetDisplayName">knowledge Object Target Display Name</param>
        /// <param name="knowledgeObjectTargetMPDisplayName">Knowledge Object Target MP Display Name</param>
        /// <param name="knowledgeObjectName">knowledge Object Name</param>
        /// <exception cref="System.NotImplementedException">
        /// Throws System.NotImplementedException if knowledge object type or knowledge object target name is not supported
        /// </exception>
        /// <exception cref="Maui.Core.WinControls.DataGridView.Exceptions.DataGridViewRowNotFoundException">
        /// Throws if Maui.Core.WinControls.DataGridView.Exceptions.DataGridViewRowNotFoundException knowledge object type is not found
        /// </exception>
        /// <history>                
        /// [v-waltli] 5/26/2009 Created
        /// </history>
        public static void SelectKnowledgeObject(KNOWLEDGE_OBJECT_TYPE knowledgeObjectType, string knowledgeObjectTargetDisplayName, string knowledgeObjectTargetMPDisplayName, string knowledgeObjectName, bool changeConsoleScope)
        {
            currentMethodName = MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethodName + "...");

            //Resource string of view name to be searched according to knowledge object type
            string viewName = string.Empty;
            switch (knowledgeObjectType)
            {
                case KNOWLEDGE_OBJECT_TYPE.MONITOR:
                    // Resource string of Monitors view
                    viewName = Views.Views.Strings.HealthView;
                    break;
                case KNOWLEDGE_OBJECT_TYPE.RULE:
                    // Resource string of Rules View
                    viewName = Views.Views.Strings.RulesView;
                    break;
                default:
                    throw new NotImplementedException("This knowledge object type is not supported: " + knowledgeObjectType);
            }

            Utilities.LogMessage(currentMethodName + ":: View name := '" + viewName + "'");

            // View node full path
            string viewNodeFullPath =
                NavigationPane.Strings.MonitoringConfiguration
                + Constants.PathDelimiter
                + NavigationPane.Strings.MonConfigTreeViewManagementPackObjects
                + Constants.PathDelimiter
                + viewName;

            Utilities.LogMessage(currentMethodName + ":: Navigating to the specified view with tree view node path := '" + viewNodeFullPath + "'");
            // Navigate to the specified view
            CoreManager.MomConsole.NavigationPane.SelectNode(
                viewNodeFullPath,
                NavigationPane.NavigationTreeView.MonitoringConfiguration);

            Utilities.LogMessage(currentMethodName + ":: Adding scope to show object: '" + knowledgeObjectTargetDisplayName + "' in MP: '" + knowledgeObjectTargetMPDisplayName + "'");

            //Add retry logic to make sure FindBar is available in UI. 
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    if (CoreManager.MomConsole.ViewPane.Find.Controls.FindNowButton.Extended.IsVisible)
                    {
                        //clear first to get to the original state
                        CoreManager.MomConsole.ViewPane.Find.Controls.ClearButton.Click();
                        Utilities.LogMessage(currentMethodName + ":: FindNowButton is visible after " + i + " seconds.");
                        break;
                    }
                }
                catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                {
                    //Workaround here for bug#180622
                   
                    Maui.Core.WinControls.Button findButton =
                        new Button(CoreManager.MomConsole.MainWindow, new Maui.Core.QID(";[UIA]Name = \'" + Core.Console.ConsoleApp.Strings.FindButtonText + "\' && Role = 'push button'"), 6000);
                    if (!findButton.IsEnabled)
                    {

                        NavigationPane navPane = CoreManager.MomConsole.NavigationPane;

                        //Since the focus is in the InfoBar now , we can click Attribute node first then click Monitors node back to workaround. 
                        //Navigate to Attribute
                        navPane.SelectNode(
                        NavigationPane.Strings.Authoring + Constants.PathDelimiter + NavigationPane.Strings.MonConfigTreeViewManagementPackObjects +
                         Constants.PathDelimiter + Core.Console.Views.Views.Strings.AttributesView, //NavigationPane.Strings.MonConfigTreeViewAttributes,
                        NavigationPane.NavigationTreeView.Authoring);
                      
                        CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();
                        CoreManager.MomConsole.ViewPane.Grid.ScreenElement.WaitForReady();

                        //Navigate back to Monitors Node
                        CoreManager.MomConsole.NavigationPane.SelectNode(
                        viewNodeFullPath,
                        NavigationPane.NavigationTreeView.Authoring);

                        CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();
                        CoreManager.MomConsole.ViewPane.Grid.ScreenElement.WaitForReady();
                    }
                    Core.Common.Utilities.LogMessage(currentMethodName + ":: Findbar does not display in UI, click Find Button in tool bar to make it show.");
                    Core.Common.Utilities.LogMessage(currentMethodName + ":: Click Find Button in ToolBar...");

                    findButton = new Button(CoreManager.MomConsole.MainWindow, new Maui.Core.QID(";[UIA]Name = \'" + Core.Console.ConsoleApp.Strings.FindButtonText + "\' && Role = 'push button'"), 6000);
                    findButton.Click();
                    Utilities.LogMessage(currentMethodName + ":: Sleep one second to wait FindNowButton Ready.");
                    Sleeper.Delay(Constants.OneSecond);
                }
            }

            if (changeConsoleScope)
            {
                //Add relative scope to show the object
                CoreManager.MomConsole.ViewPane.ChangeConsoleScope(new ViewPane.TargetType[] { new ViewPane.TargetType(knowledgeObjectTargetDisplayName, knowledgeObjectTargetMPDisplayName, true) }, true, 5);
            }

            switch (knowledgeObjectType)
            {
                case KNOWLEDGE_OBJECT_TYPE.MONITOR:
                    Monitors monitor = new Monitors();
                    Utilities.LogMessage(currentMethodName + ":: Finding the object name: '" + knowledgeObjectName + "' with target: '" + knowledgeObjectTargetDisplayName + "'");

                    // Monitor row index
                    int rowposMonitor = -1;

                    for (int currentAttempt = 0; currentAttempt < MaxRetry; currentAttempt++)
                    {
                        try
                        {
                            Utilities.LogMessage(currentMethodName + ":: Current retry attempt := " + (currentAttempt + 1));
                            rowposMonitor = monitor.SelectTargetMonitor(knowledgeObjectTargetDisplayName, knowledgeObjectName);

                            //Check if monitor is found in view
                            if (rowposMonitor != -1)
                            {
                                break;
                            }

                        }
                        catch (DataGridView.Exceptions.DataGridViewRowNotFoundException e)
                        {
                            Utilities.LogMessage(currentMethodName + ":: Caught Exception; should be ok continue : " + e.ToString());

                            // Check if current attempt matches the refresh interval.
                            // If haven't gotten expected result for several times, then refesh the view
                            if ((Timeout * currentAttempt) % RefreshInterval == 0)
                            {
                                Utilities.LogMessage(currentMethodName + ":: Refreshing the view by sending F5");
                                // Refresh the view
                                CoreManager.MomConsole.ViewPane.SendKeys(
                                    Core.Common.KeyboardCodes.F5);

                                Utilities.LogMessage(currentMethodName + ":: Waiting for Console status ready");
                                // Make sure the Console status is ready
                                CoreManager.MomConsole.Waiters.WaitForStatusReady();
                            }
                            Core.Common.Utilities.LogMessage(currentMethodName + ":: Waiting some seconds := " + Timeout);
                            // Wait some seconds
                            Maui.Core.Utilities.Sleeper.Delay(Constants.OneSecond * Timeout);
                        }
                    }

                    //Check if monitor appeared in view
                    if (rowposMonitor == -1)
                    {
                        Utilities.LogMessage("Monitors.SelectTargetMonitor:: Monitor '"
                            + knowledgeObjectName
                            + "' not found under target "
                            + knowledgeObjectTargetDisplayName);
                        throw new DataGridView.Exceptions.DataGridViewRowNotFoundException("Monitor not found under the specified Target!");
                    }

                    break;
                case KNOWLEDGE_OBJECT_TYPE.RULE:
                    Utilities.LogMessage(currentMethodName + ":: Using the FindBar to looking for the object name: " + knowledgeObjectName);
                    int oldNumber = CoreManager.MomConsole.ViewPane.Grid.Rows.Count;
                    CoreManager.MomConsole.ViewPane.Find.LookForItem(knowledgeObjectName);

                    for (int i = 0; i < 15; i++)
                    {
                        if (oldNumber != CoreManager.MomConsole.ViewPane.Grid.Rows.Count)
                        {
                            Utilities.LogMessage(currentMethodName + ":: Find data finished, cost " + i + "Seconds.");
                            break;
                        }
                        else
                        {
                            Utilities.LogMessage(currentMethodName + ":: Finding data, sleep one second.");
                            Sleeper.Delay(Constants.OneSecond);
                        }
                    }

                    Utilities.LogMessage(currentMethodName + ":: Finding the object name: " + knowledgeObjectName);
                    DataGridViewRow objectRow = CoreManager.MomConsole.ViewPane.Grid.FindData(knowledgeObjectName, Core.Console.MomControls.GridControl.SearchStringMatchType.ExactMatch);

                    //Check if rule appeared in view
                    if (objectRow == null)
                    {
                        throw new DataGridView.Exceptions.DataGridViewRowNotFoundException(string.Format("Rule {0} is not found in Rules view!", knowledgeObjectName));
                    }

                    Utilities.LogMessage(currentMethodName + ":: Selecting the object by click: " + knowledgeObjectName);
                    objectRow.AccessibleObject.Click();


                    Utilities.LogMessage(currentMethodName + ":: Waiting for UI object ready");
                    // Make sure the Console status is ready
                    CoreManager.MomConsole.Waiters.WaitForStatusReady();

                    break;
                default:
                    throw new NotImplementedException("This knowledge object type is not supported: " + knowledgeObjectType);
            }

        }

        /// <summary>
        /// Select Product or Company Knowledge Tab according to Knowledge Type
        /// </summary>
        /// <param name="knowledgePropertiesDialog">Knowledge Properties Dialog</param>
        /// <param name="knowledgeType">Knowledge Type</param>
        /// <exception cref="System.NotImplementedException">
        /// Throws System.NotImplementedException if knowledge type is not supported
        /// </exception>
        /// <history>                
        /// [v-waltli] 5/26/2009 Created
        /// </history>
        public static void SelectKnowledgeTab(KnowledgePropertiesDialog knowledgePropertiesDialog, KNOWLEDGE_TYPE knowledgeType)
        {
            currentMethodName = MethodBase.GetCurrentMethod().Name;
            Core.Common.Utilities.LogMessage(currentMethodName + "...");

            switch (knowledgeType)
            {
                case KNOWLEDGE_TYPE.COMPANY_KNOWLEDGE:
                    Utilities.LogMessage(currentMethodName + ":: Selecting Company Knowledge tab");
                    knowledgePropertiesDialog.Controls.CompanyKnowledgeTab.Select();
                    break;

                case KNOWLEDGE_TYPE.PRODUCT_KNOWLEDGE:
                    Utilities.LogMessage(currentMethodName + ":: Selecting the Product Knowledge Tab");
                    knowledgePropertiesDialog.Controls.ProductKnowledgeTab.Select();
                    break;

                default:
                    throw new NotImplementedException("This knowledge type is not supported: " + knowledgeType);
            }


            Core.Common.Utilities.LogMessage(currentMethodName + ":: Waiting for Console status ready");
            // Make sure the Console status is ready
            CoreManager.MomConsole.Waiters.WaitForStatusReady();

        }

        /// <summary>
        /// Capture Knowledge Document control in Knowledge Properties Dialog
        /// </summary>
        /// <param name="knowledgePropertiesDialog">Knowledge Properties Dialog</param>
        /// <param name="knowledgeType">Knowledge Type</param>
        /// <returns>Knowledge Document control</returns>
        /// <exception cref="System.NotImplementedException">
        /// Throws System.NotImplementedException if knowledge type is not supported
        /// </exception>
        /// <history>                
        /// [v-waltli] 5/26/2009 Created
        /// </history>
        public static IHTMLDocument GetKnowledgeDocument(KnowledgePropertiesDialog knowledgePropertiesDialog, KNOWLEDGE_TYPE knowledgeType)
        {
            currentMethodName = MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethodName + "...");

            IHTMLDocument knowledgeDocument = null;
            switch (knowledgeType)
            {
                case KNOWLEDGE_TYPE.COMPANY_KNOWLEDGE:

                    Utilities.LogMessage(currentMethodName + ":: Getting Knowledge Document");
                    knowledgeDocument = knowledgePropertiesDialog.Controls.CompanyKnowledgeArticleHTMLDoc.Document;
                    break;
                case KNOWLEDGE_TYPE.PRODUCT_KNOWLEDGE:

                    Utilities.LogMessage(currentMethodName + ":: Getting Knowledge Document");
                    knowledgeDocument = knowledgePropertiesDialog.Controls.ProductKnowledgeArticleHTMLDoc.Document;
                    break;
                default:
                    throw new NotImplementedException("This knowledge type is not supported: " + knowledgeType);
            }
            return knowledgeDocument;

        }

        /// <summary>
        /// Get Knowledge Output Content from Knowledge Document
        /// </summary>
        /// <param name="knowledgeDocument">Knowledge Document</param>
        /// <param name="knowledgeType">Knowledge Type</param>
        /// <returns>Knowledge Output Content</returns>
        public static string GetKnowledgeOutputContent(IHTMLDocument knowledgeDocument, KNOWLEDGE_TYPE knowledgeType)
        {
            currentMethodName = MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethodName + "...");

            Utilities.LogMessage(currentMethodName + ":: Getting Knowledge Html Document");
            HTMLDocumentClass knowledgeHtmlDocument = knowledgeDocument as HTMLDocumentClass;

            Utilities.LogMessage(currentMethodName + ":: Getting Knowledge Output Content");
            string knowledgeOutputContent = knowledgeHtmlDocument.body.outerText;

            return knowledgeOutputContent;
        }

        /// <summary>
        /// Verify if Knowledge Document contains expected Knowledge Content 
        /// of a specific Knowledge Content Type in Knowledge Document
        /// The knowledge content are located in tags with class name "lastInCell"
        /// </summary>
        /// <param name="knowledgeDocument">Knowledge Document</param>
        /// <param name="knowledgeContentType">Knowledge Content Type</param>
        /// <param name="expectedContent">Expected Knowledge Content</param>
        /// <returns>True if Knowledge Document contains expected Knowledge Content</returns>
        /// <exception cref="System.NotImplementedException">
        /// Throws System.NotImplementedException if knowledge content type is not supported
        /// </exception>
        /// <history>                
        /// [v-waltli] 5/26/2009 Created
        /// </history>
        public static bool ContainsKnowledgeContent(IHTMLDocument knowledgeDocument, KNOWLEDGE_CONTENT_TYPE knowledgeContentType, string expectedContent)
        {
            currentMethodName = MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethodName + "...");

            Utilities.LogMessage(currentMethodName + ":: Getting Knowledge Html Document");
            HTMLDocumentClass knowledgeHtmlDocument = knowledgeDocument as HTMLDocumentClass;

            Utilities.LogMessage(currentMethodName + ":: Get <p> tag element collection");
            IHTMLElementCollection ps = knowledgeHtmlDocument.getElementsByTagName("p");
            Utilities.LogMessage(currentMethodName + ":: Iterate the collection");
            foreach (IHTMLElement p in ps)
            {
                if (string.Compare(p.className, "lastInCell", true) == 0)
                {
                    Utilities.LogMessage(currentMethodName + ":: Current element class name is: " + p.className);
                    switch (knowledgeContentType)
                    {
                        case KNOWLEDGE_CONTENT_TYPE.TEXT:

                            Utilities.LogMessage(currentMethodName + ":: Current element text is: " + p.outerText);
                            if (p.outerText.Contains(expectedContent.Trim()))
                            {
                                return true;
                            }
                            break;
                        case KNOWLEDGE_CONTENT_TYPE.LINK:
                            foreach (IHTMLElement element in p.children as IHTMLElementCollection)
                            {
                                if (element.tagName == "A")
                                {
                                    Utilities.LogMessage(currentMethodName + ":: Current element is a link");
                                    if (element.outerText.Contains(expectedContent))
                                    {
                                        return true;
                                    }
                                }

                            }
                            break;
                        default:
                            throw new System.NotImplementedException("This knowledge content type is not supported: " + knowledgeContentType);
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Click the "Show knowledge" link to expand knoweldge if the knowledge is collapsed in Alert Details Pane
        /// </summary>
        /// <history>                
        /// [v-waltli] 5/26/2009 Created
        /// </history>
        public static void ExpandKnowledgeInAlertDetailsPane()
        {
            currentMethodName = MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethodName + "...");

            Utilities.LogMessage(currentMethodName + ":: Getting Knowledge Html Document");
            HTMLDocumentClass html = CoreManager.MomConsole.DetailPane.HtmlDocument.Document as HTMLDocumentClass;

            Utilities.LogMessage(currentMethodName + ":: Get <div> tag element collection");
            IHTMLElementCollection divs = html.getElementsByTagName("div");

            // If Knowledge is Collapsed
            bool knowledgeCollapsed = false;

            foreach (IHTMLElement div in divs)
            {
                Utilities.LogMessage(currentMethodName + ":: Current element class name is: " + div.className);
                Utilities.LogMessage(currentMethodName + ":: Current element text is : " + div.outerText);

                if (string.Compare(div.className, "knowledge", true) == 0 &&
                    string.Compare(div.parentElement.tagName.Trim(), "TD", true) == 0)
                {
                    Utilities.LogMessage(currentMethodName + ":: Knowledge is expanded already");
                    knowledgeCollapsed = false;
                }
            }

            if (knowledgeCollapsed)
            {
                foreach (IHTMLElement div in divs)
                {
                    Utilities.LogMessage(currentMethodName + ":: Current element class name is: " + div.className);
                    Utilities.LogMessage(currentMethodName + ":: Current element text is : " + div.outerText);

                    if (string.Compare(div.className, "knowledge", true) == 0 &&
                        string.Compare(div.parentElement.tagName.Trim(), "A", true) == 0)
                    {
                        Utilities.LogMessage(currentMethodName + ":: Click the link to show knowledge");
                        div.parentElement.click();
                    }
                }
            }
        }

        /// <summary>
        /// Close Knowledge Properties Dialog
        /// </summary>
        /// <param name="knowledgePropertiesDialog">Knowledge Properties Dialog</param>
        /// <param name="isSealedMP">If is sealed MP</param>
        /// <param name="save">If save the dialog</param>
        public static void CloseKnowledgePropertiesDialog(KnowledgePropertiesDialog knowledgePropertiesDialog, bool isSealedMP, bool save)
        {
            currentMethodName = MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethodName + "...");

            if (isSealedMP)
            {
                if (save)
                {
                    Utilities.LogMessage(currentMethodName + ":: Click Save button");
                    knowledgePropertiesDialog.ClickSave();

                    Utilities.LogMessage(currentMethodName + ":: Waiting for UI object ready");
                    // Make sure the Console status is ready
                    CoreManager.MomConsole.Waiters.WaitForStatusReady();
                }
                Utilities.LogMessage(currentMethodName + ":: Click Close button");
                knowledgePropertiesDialog.ClickClose();
                if (!save)
                {
                    // Click No button of the Confirmation dialg.
                    Utilities.LogMessage(currentMethodName + ":: Click No button of the confirm dialog");
                    CoreManager.MomConsole.ConfirmChoiceDialog(
                        MomConsoleApp.ButtonCaption.No,
                        KnowledgePropertiesDialog.Strings.ConfirmDialogTitle,
                        StringMatchSyntax.ExactMatch,
                        MomConsoleApp.ActionIfWindowNotFound.Ignore);
                }
            }
            else
            {
                if (save)
                {
                    Utilities.LogMessage(currentMethodName + ":: Click OK button");
                    knowledgePropertiesDialog.ClickOK();
                }
                else
                {
                    Utilities.LogMessage(currentMethodName + ":: Click Cancel button");
                    knowledgePropertiesDialog.ClickCancel();

                    // Trying to close Confirm dialog
                    Utilities.LogMessage(currentMethodName + ":: Trying to close Confirm dialog");
                    CoreManager.MomConsole.ConfirmChoiceDialog(
                        MomConsoleApp.ButtonCaption.No,
                        KnowledgePropertiesDialog.Strings.ConfirmDialogTitle,
                        StringMatchSyntax.ExactMatch,
                        MomConsoleApp.ActionIfWindowNotFound.Ignore);
                }
            }

            CoreManager.MomConsole.BringToForeground();
        }

        #endregion
    }
}
