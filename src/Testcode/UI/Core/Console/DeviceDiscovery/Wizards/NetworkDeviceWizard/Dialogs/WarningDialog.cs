// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="WarningDialog.cs">
//   Copyright (c) Microsoft Corporation 2010
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//   [dialac] 5/10/2010 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards.NetworkDeviceWizard.Dialogs
{
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    
    #region Interface Definition - IWarningDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IWarningDialogControls, for WarningDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [dialac] 5/10/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IWarningDialogControls
    {
        /// <summary>
        /// Gets read-only property to access YesButton
        /// </summary>
        Button YesButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access NoButton
        /// </summary>
        Button NoButton
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
    ///   [dialac] 5/10/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class WarningDialog : Dialog, IWarningDialogControls
    {
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to YesButton of type Button
        /// </summary>
        private Button cachedYesButton;
        
        /// <summary>
        /// Cache to hold a reference to NoButton of type Button
        /// </summary>
        private Button cachedNoButton;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the WarningDialog class.
        /// </summary>
        /// <param name='app'>
        /// Owner of WarningDialog of type MomConsoleApp
        /// </param>
        /// <history>
        ///   [dialac] 5/10/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public WarningDialog(MomConsoleApp app, int timeout) : 
                base(app, Init(app, timeout))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IWarningDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [dialac] 5/10/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IWarningDialogControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the YesButton control
        /// </summary>
        /// <history>
        ///   [dialac] 5/10/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWarningDialogControls.YesButton
        {
            get
            {
                if ((this.cachedYesButton == null))
                {
                    this.cachedYesButton = new Button(this, WarningDialog.ControlIDs.YesButton);
                }
                
                return this.cachedYesButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the NoButton control
        /// </summary>
        /// <history>
        ///   [dialac] 5/10/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWarningDialogControls.NoButton
        {
            get
            {
                if ((this.cachedNoButton == null))
                {
                    this.cachedNoButton = new Button(this, WarningDialog.ControlIDs.NoButton);
                }
                
                return this.cachedNoButton;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Yes
        /// </summary>
        /// <history>
        ///   [dialac] 5/10/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickYes()
        {
            this.Controls.YesButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button No
        /// </summary>
        /// <history>
        ///   [dialac] 5/10/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNo()
        {
            this.Controls.NoButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">MomConsoleApp owning the dialog.</param>
        /// <param name="timeout">timeout.</param>
        /// <history>
        ///   [dialac] 5/10/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app, int timeout)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app, timeout);
            }
            catch (Exceptions.WindowNotFoundException windowNotFound)
            {
                // Reset the window reference
                tempWindow = null;

                // Maximum number of tries to find window
                int maxTries = 5;

                // Try several more times to find the window
                for (int numberOfTries = 0; ((null == tempWindow)
                            && (numberOfTries < maxTries)); numberOfTries = (numberOfTries + 1))
                {
                    try
                    {
                        // Try to locate an existing instance of the window
                        tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app, timeout);

                        // Wait for the window to become ready
                        UISynchronization.WaitForUIObjectReady(tempWindow, timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Mom.Test.UI.Core.Common.Utilities.LogMessage("Attempt " + numberOfTries + " of " + maxTries);


                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(timeout);
                    }
                }

                // check for success
                if ((null == tempWindow))
                {
                    // log the failure

                    // rethrow the original exception
                    throw windowNotFound;
                }
            }

            
            return tempWindow;
        }
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        ///   [dialac] 5/10/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for YesButton
            /// </summary>
            public const int YesButton = 6;
            
            /// <summary>
            /// Control ID for NoButton
            /// </summary>
            public const int NoButton = 7;
        }
        #endregion
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        ///   [dialac] 5/10/2010 Created
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
            private const string ResourceDialogTitle = ";Warning;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;Warning";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Yes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceYes = "&Yes";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  No
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNo = "&No";
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 5/10/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceDialogTitle);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Yes translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 5/10/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Yes
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceYes);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the No translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 5/10/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string No
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceNo);
                }
            }
            #endregion
        }
        #endregion
    }
}
