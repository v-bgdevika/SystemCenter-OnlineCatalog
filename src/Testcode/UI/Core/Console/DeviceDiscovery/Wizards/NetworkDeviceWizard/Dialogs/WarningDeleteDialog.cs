// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SystemCenterOperationsManager2012Dialog.cs">
//   Copyright (c) Microsoft Corporation 2010
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//   [v-juli] 9/9/2010 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards.NetworkDeviceWizard.Dialogs
{
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    
    #region Interface Definition - IWarningDeleteDialog

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISystemCenterOperationsManager2012DialogControls, for SystemCenterOperationsManager2012Dialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-juli] 9/9/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IWarningDeleteDialog
    {
        /// <summary>
        /// Gets read-only property to access CloseButton
        /// </summary>
        Button CloseButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access WarningText
        /// </summary>
        StaticControl WarningText
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
    ///   [asttest] 9/9/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class WarningDeleteDialog : Dialog, IWarningDeleteDialog
    {
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to CloseButton of type Button
        /// </summary>
        private Button cachedCloseButton;
        
        /// <summary>
        /// Cache to hold a reference to WarningText
        /// </summary>
        private StaticControl cachedWarningText;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the SystemCenterOperationsManager2012Dialog class.
        /// </summary>
        /// <param name='app'>
        /// Owner of SystemCenterOperationsManager2012Dialog of type App
        /// </param>
        /// <history>
        ///   [v-juli] 9/9/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public WarningDeleteDialog(MomConsoleApp app, int timeout) : 
                base(app, Init(app, timeout))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion

        #region IWarningDeleteDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [v-juli] 9/9/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IWarningDeleteDialog Controls
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
        ///  Gets access to the CloseButton control
        /// </summary>
        /// <history>
        ///   [v-juli] 9/9/2010 Created
        /// </history>
        ///// -----------------------------------------------------------------------------
        //Button IWarningDeleteDialog.CloseButton
        //{
        //    get
        //    {
        //        if ((this.cachedCloseButton == null))
        //        {
        //            this.cachedCloseButton = new Button(this, WarningDeleteDialog.ControlIDs.CloseButton);
        //        }

        //        return this.cachedCloseButton;
        //    }
        //}
        Button IWarningDeleteDialog.CloseButton
        {
            get
            {
                if ((this.cachedCloseButton == null))
                {
                    this.cachedCloseButton = new Button(this, WarningDeleteDialog.QueryIds.CloseButton);
                }

                return this.cachedCloseButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the WarningText control
        /// </summary>
        /// <history>
        ///   [v-juli] 9/9/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWarningDeleteDialog.WarningText
        {
            get
            {
                if ((this.cachedWarningText == null))
                {
                    this.cachedWarningText = new StaticControl(this, WarningDeleteDialog.QueryIds.WarningText);
                }

                return this.cachedWarningText;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Close
        /// </summary>
        /// <history>
        ///   [asttest] 9/9/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickClose()
        {
            this.Controls.CloseButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">App owning the dialog.</param>
        /// <param name="timeout">timeout.</param>
        /// <history>
        ///   [v-juli] 9/9/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app, int timeout)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(app.MainWindow, new QID(";[VisibleOnly,UIA]AutomationId = 'ErrorDialog'"), timeout);
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
                        tempWindow = new Window(app.MainWindow, new QID(";[VisibleOnly,UIA]AutomationId = 'ErrorDialog'"), timeout);

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
        
        ///// -----------------------------------------------------------------------------
        ///// <summary>
        ///// Class to contain constants for all control ID's.
        ///// </summary>
        ///// <history>
        /////   [asttest] 9/13/2010 Created
        ///// </history>
        ///// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for CloseButton
            /// </summary>
            public const string CloseButton = "closeButton";

            /// <summary>
            /// Control ID for CloseButton
            /// </summary>
            public const string WarningText = "errorMessage";
        }       
        
         /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all query ID's.
        /// </summary>
        /// <history>
        ///   [v-juli] 9/27/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class QueryIds
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for CloseButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCloseButton = ";[UIA]AutomationId = \'buttonPanel\';[UIA]AutomationId = \'closeButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for WarningText query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWarningText = ";[UIA]AutomationId=\'errorMessage\'";
            #endregion
            
            #region Properties
                             
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the CloseButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-juli] 9/27/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID CloseButton
            {
                get
                {
                    return new QID(ResourceCloseButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the WarningText resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 9/27/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID WarningText
            {
                get
                {
                    return new QID(ResourceWarningText);
                }
            }
            #endregion
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        ///   [v-juli] 9/9/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            
            #region Constants

            /// <summary>
            /// Resource string for System Center Operations Manager 2012
            /// </summary>
            //public const string ResourceDialogTitle = ";System Center Operations Manager 2012;ManagedString;Microsoft.EnterpriseManagement.Monitoring.Console.exe;Microsoft.EnterpriseManagement.Monitoring.Console.ConsoleResources;ProductTitle";
            private const string ResourceDialogTitle = ";System Center Operations Manager 2012;ManagedString;Microsoft.EnterpriseManagement.Monitoring.Console.exe;Microsoft.EnterpriseManagement.Monitoring.Console.ConsoleResources;ProductTitle";

            /// <summary>
            /// Resource string for Close
            /// </summary>
            private const string ResourceClose = ";Close;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.ErrorDialog;closeButton.Text";

            /// <summary>
            /// Resource string for The input contains one (or more) device(s) which are seeds in an automatic discovery rule.
            ///Parameter name: devices
            /// </summary>
            private const string ResourceWarningText = ";The following device(s) are the starting point for a network discovery rule and cannot be deleted.  " +
                "Before you can delete the device(s) from Operations Manager, you must remove the device(s) from the associated network discovery rule.;" +
                "ManagedString;Microsoft.EnterpriseManagement.OperationsManager.dll;Microsoft.EnterpriseManagement.OMExceptionMessages;AutomaticSeedDeletionException";
            #endregion

            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Cached reference for DialogTitle.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitle;          

            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            ///   [v-juli] 9/13/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    if (cachedDialogTitle == null)
                    {
                        CoreManager.MomConsole.GetIntlStr(ResourceDialogTitle);
                    }

                    return cachedDialogTitle;                   
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Yes translated resource string
            /// </summary>
            /// <history>
            ///   [v-juli] 9/13/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Close
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceClose);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the No translated resource string
            /// </summary>
            /// <history>
            ///   [v-juli] 9/13/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WarningText
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceWarningText);
                }
            }
            #endregion
        }
        #endregion
    }
}
