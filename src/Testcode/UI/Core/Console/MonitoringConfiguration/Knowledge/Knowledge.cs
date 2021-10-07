//  -----------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="Knowledge.cs">
//     Copyright © Microsoft 2005
// </copyright>
// <project>
//     Mom.Test.UI.Core.Console.MonitoringConfiguration.Knowledge
// </project>
// <summary>
//     This class contains helper functions for automation of the 
//     configuration of Knowledge. 
// </summary>
// <history>
//      [barryw] 12/12/2005 13:55:55 Created
// </history>
//  -----------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Knowledge
{
    #region Using directives

    using System;
    using System.Text;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs;
    using Mom.Test.UI.Core.Console.MonitoringConfiguration.Knowledge.Dialogs;
    #endregion

    /// <summary>
    /// Class to assist test automation related to Knowledge.
    /// </summary>
    public class Knowledge
    {
        #region Constants sections

        #endregion

        #region Member variables section

        #endregion

        #region  Constructors section

        /// <summary>
        /// Constructor for Knowledge class.
        /// </summary>
        public Knowledge()
        {
            // This prevents the creation of a default constructor
        }

        #endregion

        #region Properties section

        #endregion

        #region Methods section

        #region Public non-static methods section

        /// <summary>
        /// Provides access to an open instance of KnowledgeProperties
        /// </summary>
        /// <param name="dialogTitle">dialog title, set to a constant, e.g., MonitoringConfiguration.Strings.DialogTitleMonitorProperties</param>
        /// <returns>KnowledgeProperties dialog.</returns>
        /// <remarks>Created using 'UI Get Class' snippet</remarks>
        public KnowledgeProperties GetKnowledgeProperties(string dialogTitle)
        {
            // Access the KnowledgeProperties dialog.
            KnowledgeProperties dialog = null;

            // Open the dialog
            try
            {
                dialog = new KnowledgeProperties(
                    CoreManager.MomConsole,
                    dialogTitle);
                
                // wait until application is ready
                //UISynchronization.WaitForUIObjectReady(
                //    dialog,
                //    Constants.DefaultDialogTimeout);
                dialog.ScreenElement.WaitForReady();
                Utilities.LogMessage("Knowledge.GetKnowledgeProperties:: " +
                    "KnowledgeProperties Opened");

                // Make sure dialog is in Foreground.
                dialog.Extended.SetFocus();
                Utilities.LogMessage("Knowledge.GetKnowledgeProperties:: Focus set to " +
                    "KnowledgeProperties");

                return dialog;
            }
            catch
            {
                if (dialog != null)
                {
                    // On a failure try to close the dialog.
                    dialog.SendKeys(KeyboardCodes.Esc);
                    Utilities.LogMessage("Knowledge.GetKnowledgeProperties:: " +
                        "Clicked the Escape key on the KnowledgeProperties dialog.");

                    // Save an image of the screen for diagnostic information.
                    Utilities.TakeScreenshot("Knowledge.GetKnowledgeProperties_Cleared");
                }
                throw;
            }
        }

        /// <summary>
        /// Provides access to an open instance of KnowledgeWordDialog, the Word 
        /// dialog may take several seconds to appear, by default this function will retry 
        /// to find the dialog up to 15 times once a second.
        /// </summary>
        /// <returns>KnowledgeWordDialog dialog.</returns>
        public KnowledgeWordDialog GetKnowledgeWordDialog()
        {
            const int ThirtyRetries = 30;
            return this.GetKnowledgeWordDialog(ThirtyRetries);
        }
        
        /// <summary>
        /// Provides access to an open instance of KnowledgeWordDialog
        /// </summary>
        /// <param name="retries">Number of retries with a delay of one second between tries.</param>
        /// <returns>KnowledgeWordDialog dialog.</returns>
        /// <history>
        /// 	[barryw] 22DEC05 Created.
        /// </history>
        /// <remarks>Created using 'UI Get Class' snippet</remarks>
        public KnowledgeWordDialog GetKnowledgeWordDialog(int retries)
        {
            Utilities.LogMessage("Knowledge.GetKnowledgeWordDialog(...)");

            Utilities.LogMessage("Knowledge.GetKnowledgeWordDialog:: " +
                "Number of retries: " + retries.ToString());

            // Access the KnowledgeWordDialog dialog.
            KnowledgeWordDialog dialog = null;
            int i = 0;
            while (i <= retries)
            {
                i = i + 1;

                // Open the dialog
                try
                {
                    dialog = new KnowledgeWordDialog(
                        CoreManager.MomConsole);

                    // wait until application is ready
                    //UISynchronization.WaitForUIObjectReady(
                    //    dialog,
                    //    Constants.DefaultDialogTimeout);
                    dialog.ScreenElement.WaitForReady();
                    Utilities.LogMessage("Knowledge.GetKnowledgeWordDialog:: " +
                        "KnowledgeWordDialog Opened");

                    // Make sure dialog is in Foreground.
                    dialog.Extended.SetFocus();
                    Utilities.LogMessage("Knowledge.GetKnowledgeWordDialog:: Focus set to " +
                        "KnowledgeWordDialog");
                    
                    // success break out of the loop.
                    break;
                }
                catch
                {
                    if (i < retries)
                    {
                        if (i < 5)
                        {
                            Sleeper.Delay(Constants.OneSecond);
                        }
                        else
                        {
                            Sleeper.Delay(Constants.OneSecond * 2);
                        }
                        Utilities.LogMessage("Knowledge.GetKnowledgeWordDialog:: " +
                            "Retry: " + i.ToString() + " of " + retries.ToString());
                    }
                    else
                    {
                        if (dialog != null)
                        {
                            // On a failure try to close the dialog.
                            dialog.SendKeys(KeyboardCodes.Alt + KeyboardCodes.F4);
                            Utilities.LogMessage("Knowledge.GetKnowledgeWordDialog:: " +
                                "Invoked Alt+F4 keys on the KnowledgeWordDialog dialog.");

                            // Save an image of the screen for diagnostic information.
                            Utilities.TakeScreenshot("Knowledge.GetKnowledgeWordDialog_Cleared");
                        }
                        else
                        {
                            // Save an image of the screen for diagnostic information.
                            Utilities.TakeScreenshot("Knowledge.GetKnowledgeWordDialog");
                        }
                        throw;
                    }
                }
            }
            return dialog;
        }
	
        /// <summary>
        /// This method is designed to assist in automating the navigation of the knowledge article
        /// dialog. By default, this method will click the 'Next' button to go to the next wizard
        /// dialog.
        /// </summary>
        /// <returns>Reference to the knowledge article dialog</returns>
        public Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs.KnowledgeArticleDialog NavigateKnowledgeDialog()
        {
            Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs.KnowledgeArticleDialog knowledgeDialog 
                = NavigateKnowledgeDialog(NavigationMethod.Next);
            return knowledgeDialog;
        }

        /// <summary>
        /// This method is designed to assist in automating the navigation of the knowledge article
        /// dialog.
        /// </summary>
        /// <param name="navigationMethod">Navigation method, e.g., immediately click the 'Edit' button.</param>
        /// <returns>Reference to the knowledge article dialog</returns>
        public Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs.KnowledgeArticleDialog NavigateKnowledgeDialog(NavigationMethod navigationMethod)
        {
            ////Todo: Consider moving this method to MonitoringConfiguration.Dialogs to support
            ////      knowledge for collection rules with alerts.
            Utilities.LogMessage("Knowledge.NavigateKnowledgeDialog(...)");
            Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs.KnowledgeArticleDialog knowledgeDialog
                = new Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs.KnowledgeArticleDialog(CoreManager.MomConsole, MonitoringConfiguration.WindowCaptions.MonitorWizard);

            ////Todo: Chnage to NavigationMethod.Edit then sperately access Word dialog.
            ////      will also need separate functions, e.g., AddKnowledgeLink.
            if (navigationMethod == NavigationMethod.EditAndCancel ||
                (navigationMethod == NavigationMethod.Edit))
            {
                Utilities.LogMessage("Knowledge.NavigateKnowledgeDialog:: " +
                    "Waiting for the 'Edit' button to be enabled.");
                const int WaitMaximumTenSeconds = 10000;
                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(knowledgeDialog.Controls.EditButton, WaitMaximumTenSeconds);

                Utilities.LogMessage("Knowledge.NavigateKnowledgeDialog:: " +
                    "Clicking the 'Edit' button.");
                knowledgeDialog.ClickEdit();
                Utilities.LogMessage("Knowledge.NavigateKnowledgeDialog:: " +
                    "Successfully clicked the 'Edit' button");

                if (navigationMethod == NavigationMethod.EditAndCancel)
                {
                    #region Word dialog

                    // Access the word dialog.
                    KnowledgeWordDialog word = this.GetKnowledgeWordDialog();

                    word.LinkTypeText = "View";

                    word.SendKeys(KeyboardCodes.Ctrl + KeyboardCodes.End);

                    ////Todo: Handle the autosave popup, may need to handle
                    ////      it as an unexpected dialog.
                    /*
                        // Respond Ok to the confirmation dialog
                        CoreManager.MomConsole.ConfirmChoiceDialog(
                            MomConsoleApp.ButtonCaption.OK,
                            MomConsoleApp.Strings.WordDialogTitle,
                            StringMatchSyntax.ExactMatch,
                            MomConsoleApp.ActionIfWindowNotFound.Ignore);
                     */

                    #endregion	// Word dialog
                }
            }

            if (navigationMethod == NavigationMethod.Next)
            {
                Utilities.LogMessage("Knowledge.NavigateKnowledgeDialog:: " +
                    "Waiting for the 'Next' button to be enabled.");
                const int WaitMaximumTenSeconds = 10000;
                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(knowledgeDialog.Controls.NextButton, WaitMaximumTenSeconds);

                Utilities.LogMessage("Knowledge.NavigateKnowledgeDialog:: " +
                    "Clicking the 'Next' button.");
                knowledgeDialog.ClickNext();
                Utilities.LogMessage("Knowledge.NavigateKnowledgeDialog:: " +
                    "Successfully clicked the 'Next' button.");
            }
            return knowledgeDialog;
        }

        #endregion

        #region Private non-static methods section

        #endregion

        #endregion

        /// <summary>
        /// Enumerator for knowledge dialogs's navigation methods.
        /// /// </summary>
        public enum NavigationMethod
        {
            /// <summary>
            /// Immediately click the 'Next' button
            /// </summary>
            Next,
            
            /// <summary>
            /// Click the 'Edit' button and then cancel the Word dialog.
            /// </summary>
            EditAndCancel,
            
                /// <summary>
            /// Click the 'Edit' button and then return a reference to the dialog.
            /// </summary>
            Edit
        }

        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Strings class to provide localized resource strings.
        /// </summary>
        /// <history>
        ///      [barryw] 12/13/2005 14:01:44 Created
        /// </history>
        /// <remarks>Created using 'StringsClass' new item template.</remarks>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            #region Resource constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the Wizard dialog titles: ResourceDialogTitle.
            /// This is maintained here for a group of Wizard dialogs since the title should
            /// be the same for all the dialogs.
            /// </summary>
            /// -----------------------------------------------------------------------------
            /// <remarks>Created using 'Resource private string' snippet</remarks>
            /// -----------------------------------------------------------------------------
            ////Todo:Add the persistent id for this resource string.
            private const string ResourceDialogTitle = "Paste persistent id from Resource Id Spy here";

            #endregion

            #endregion  // Constants

            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitle;

            #endregion  // Private Members

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            ///      [barryw] 12/13/2005 14:01:44 Created
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


            #endregion // Properties
        }
        #endregion  // Strings Class
    }
}
