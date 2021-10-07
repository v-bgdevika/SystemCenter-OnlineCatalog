using System;
using System.Collections.Generic;
using System.Text;
using Maui.Core;
using Maui.Core.Utilities;
using Mom.Test.UI.Core.Common;

namespace Mom.Test.UI.Core.Console.ServiceDesigner {
    class Utility {


        /// <summary>
        /// Get one of the Service Designer's forms
        /// </summary>
        /// <param name="app">Application that owns the window</param>
        /// <param name="dialogTitle">window caption</param>
        /// <param name="timeout">timeout in milliseconds</param>
        /// <param name="enabled">determines whether to wait for the window to be enabled</param>
        /// <param name="foreground">determines whether to wait for the window to be in the foreground</param>
        /// <returns>Maui window</returns>
        /// <exception cref="Window.Exceptions.WindowNotFoundException"></exception>
        public static Window GetDialogOrWindow(
            Mom.Test.UI.Core.Console.MomConsoleApp app,
            string dialogTitle,
            int timeout,
            bool enabled,
            bool foreground)
        {
            Mom.Test.UI.Core.Common.Utilities.LogMessage(
                "Entering GetDialogOrWindow(...) looking for "+dialogTitle+" using timeout of "+timeout);

            // First check if the dialog is already up.
            Window tempWindow = null;
            try {
                if (dialogTitle.EndsWith("*"))
                {
                    // look for the window again using wildcard
                    tempWindow = new Window(
                        dialogTitle + "*",
                        StringMatchSyntax.WildCard,
                        WindowClassNames.WinForms10Window8,
                        StringMatchSyntax.WildCard,
                        app,
                        timeout);
                    Mom.Test.UI.Core.Common.Utilities.LogMessage("GetDialogOrWindow: " +
                        "found window - " + dialogTitle + "*" +
                        " using wildcard match on caption only.");
                }
                else
                {
                    // Try to locate an existing instance of a dialog
                    tempWindow = new Window(
                        dialogTitle,
                        StringMatchSyntax.ExactMatch,
                        WindowClassNames.Dialog,
                        StringMatchSyntax.ExactMatch,
                        app,
                        timeout);
                    Mom.Test.UI.Core.Common.Utilities.LogMessage("GetDialogOrWindow: " +
                        "found dialog - " + dialogTitle +
                        " using exact match on caption only.");
                }
            } catch (Dialog.Exceptions.WindowNotFoundException) {
                tempWindow = null;
                int numberOfTries = 0;
                const int maxTries = 5;
                while (tempWindow == null && numberOfTries < maxTries) {
                    numberOfTries++;
                    Utilities.LogMessage("On try " + numberOfTries + " to find " + dialogTitle+" (using wildcards)");
                    try
                    {
                        // look for the window again using wildcard
                        tempWindow = new Window(
                            dialogTitle,
                            StringMatchSyntax.WildCard,
                            WindowClassNames.WinForms10Window8,
                            StringMatchSyntax.WildCard,
                            app,
                            timeout);
                        Mom.Test.UI.Core.Common.Utilities.LogMessage("GetDialogOrWindow: " +
                            "found window - " + dialogTitle +
                            " using wildcard match on caption only.");

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            timeout);
                    }
                    catch (Dialog.Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt(s)
                        Mom.Test.UI.Core.Common.Utilities.LogMessage("GetDialogOrWindow: " +
                            "Unable to find dialog or window with title - " + dialogTitle);
                    }
                }
                try {
                    // check for success
                    if (tempWindow != null) {
                        //if (foreground) {
                        //    app.WaitForForegroundDialog(
                        //        tempWindow,
                        //        10000);
                        //}
                        //if (enabled) {
                        //    app.WaitForEnabledDialog(
                        //        tempWindow,
                        //        10000);
                        //}
                    } else {
                        // log the failure
                        Mom.Test.UI.Core.Common.Utilities.LogMessage("GetDialogOrWindow: " +
                            "Unable to find dialog - " + dialogTitle +
                            " after " + numberOfTries.ToString() + " tries.");
                        // throw the first existing WindowNotFound exception
                        throw;
                    }
                } catch (System.TimeoutException) {
                    throw new Dialog.Exceptions.WindowNotFoundException("Could not find window " + tempWindow.Caption + " in " + timeout + " milliseconds.");
                }
            }
            return tempWindow;
        }
    }


}