// ----------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AlertPriorityDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	MOMv3 R2 test automation.
// </project>
// <summary>
// 	MOMv3 R2 test automation.
// </summary>
// <history>
// 	[KellyMor]  23-SEP-08   Created
//  [KellyMor]  22-OCT-08   Modified list box control to more descriptive name.
//                          StyleCop fixes.
// </history>
// ----------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Administration.Notifications.Subscriptions.Wizards.AlertCriteria
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IAlertPriorityDialogControls

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAlertPriorityDialogControls, for 
    /// AlertPriorityDialog.  Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 23-SEP-08 Created
    /// </history>
    /// -----------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAlertPriorityDialogControls
    {
        /// <summary>
        /// Read-only property to access SelectAllButton
        /// </summary>
        Button SelectAllButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CancelButton
        /// </summary>
        Button CancelButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ClearAllButton
        /// </summary>
        Button ClearAllButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PrioritiesCheckedListBox
        /// </summary>
        CheckedListBox PrioritiesCheckedListBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access OKButton
        /// </summary>
        Button OKButton
        {
            get;
        }
    }

    #endregion
    
    /// -------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the dialog functionality of the Alert Priority critera
    /// dialog.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 23-SEP-08 Created
    /// </history>
    /// -------------------------------------------------------------------
    public class AlertPriorityDialog : Dialog, IAlertPriorityDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;

        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to SelectAllButton of type Button
        /// </summary>
        private Button cachedSelectAllButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to ClearAllButton of type Button
        /// </summary>
        private Button cachedClearAllButton;
        
        /// <summary>
        /// Cache to hold a reference to PrioritiesCheckedListBox of type ListBox
        /// </summary>
        private CheckedListBox cachedPrioritiesCheckedListBox;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;

        #endregion
        
        #region Constructors

        /// -------------------------------------------------------------------
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of AlertPriorityDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[KellyMor] 23-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public AlertPriorityDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }

        #endregion
        
        #region IAlertPriorityDialog Controls Property

        /// -------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>
        /// An interface that groups all of the dialog's control properties 
        /// together
        /// </value>
        /// <history>
        /// 	[KellyMor] 23-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual IAlertPriorityDialogControls Controls
        {
            get
            {
                return this;
            }
        }

        #endregion
        
        #region Control Properties

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectAllButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 23-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        Button IAlertPriorityDialogControls.SelectAllButton
        {
            get
            {
                if (this.cachedSelectAllButton == null)
                {
                    this.cachedSelectAllButton = 
                        new Button(
                            this, 
                            AlertPriorityDialog.ControlIDs.SelectAllButton);
                }
                
                return this.cachedSelectAllButton;
            }
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 23-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        Button IAlertPriorityDialogControls.CancelButton
        {
            get
            {
                if (this.cachedCancelButton == null)
                {
                    this.cachedCancelButton = 
                        new Button(
                            this, 
                            AlertPriorityDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ClearAllButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 23-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        Button IAlertPriorityDialogControls.ClearAllButton
        {
            get
            {
                if (this.cachedClearAllButton == null)
                {
                    this.cachedClearAllButton = 
                        new Button(
                            this, 
                            AlertPriorityDialog.ControlIDs.ClearAllButton);
                }
                
                return this.cachedClearAllButton;
            }
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PrioritiesCheckedListBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 23-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        CheckedListBox IAlertPriorityDialogControls.PrioritiesCheckedListBox
        {
            get
            {
                if (this.cachedPrioritiesCheckedListBox == null)
                {
                    this.cachedPrioritiesCheckedListBox = 
                        new CheckedListBox(
                            this, 
                            AlertPriorityDialog.ControlIDs.PrioritiesCheckedListBox);
                }
                
                return this.cachedPrioritiesCheckedListBox;
            }
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 23-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        Button IAlertPriorityDialogControls.OKButton
        {
            get
            {
                if (this.cachedOKButton == null)
                {
                    this.cachedOKButton = 
                        new Button(
                            this, 
                            AlertPriorityDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }

        #endregion
        
        #region Click Methods

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button SelectAll
        /// </summary>
        /// <history>
        /// 	[KellyMor] 23-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual void ClickSelectAll()
        {
            this.Controls.SelectAllButton.Click();
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[KellyMor] 23-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ClearAll
        /// </summary>
        /// <history>
        /// 	[KellyMor] 23-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual void ClickClearAll()
        {
            this.Controls.ClearAllButton.Click();
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[KellyMor] 23-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }

        #endregion
        
        /// -------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">MomConsoleApp owning the dialog.</param>
        /// <history>
        /// 	[KellyMor] 23-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = 
                    new Window(
                        Strings.DialogTitle, 
                        StringMatchSyntax.ExactMatch, 
                        WindowClassNames.WinForms10Window8, 
                        StringMatchSyntax.ExactMatch, 
                        app.MainWindow, 
                        Timeout);
            }
            catch (Exceptions.WindowNotFoundException windowNotFound)
            {
                // Reset the window reference
                tempWindow = null;

                // Maximum number of tries to find window
                int maxTries = 5;

                // Try several more times to find the window
                for (int numberOfTries = 0; 
                    ((null == tempWindow) && (numberOfTries < maxTries)); 
                    numberOfTries = (numberOfTries + 1))
                {
                    try
                    {
                        // Try to locate an existing instance of the window
                        tempWindow = 
                            new Window(
                                Strings.DialogTitle, 
                                StringMatchSyntax.WildCard);

                        // Wait for the window to become ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow, 
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage(
                            "Attempt " +
                            numberOfTries +
                            " of " +
                            maxTries +
                            "...");

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }
                
                // check for success
                if (null == tempWindow)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find the window with title := '" +
                        Strings.DialogTitle);

                    // rethrow the original exception
                    throw windowNotFound;
                }
            }
            
            return tempWindow;
        }
        
        #region Strings Class

        /// -------------------------------------------------------------------
        /// <summary>
        /// Resource string definitions.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 23-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// -------------------------------------------------------------------
            private const string ResourceDialogTitle = 
                ";Alert Priority" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.CriteriaControl.CriteriaControlResource" +
                ";AlertPriorityTitle";
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectAll
            /// </summary>
            /// -------------------------------------------------------------------
            private const string ResourceSelectAll =
                ";&Select All" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.CheckedListEditDialogBase" +
                ";buttonSelectAll.Text";
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -------------------------------------------------------------------
            private const string ResourceCancel =
                ";Cancel" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.SimpleChooserDialog" +
                ";cancelButton.Text";
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ClearAll
            /// </summary>
            /// -------------------------------------------------------------------
            private const string ResourceClearAll =
                ";&Clear All" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.CheckedListEditDialogBase" +
                ";buttonClearAll.Text";
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -------------------------------------------------------------------
            private const string ResourceOK =
                ";OK" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.SimpleChooserDialog" +
                ";okButton.Text";

            /// -------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  HighAlertPriority 
            /// </summary>
            /// -------------------------------------------------------------------
            private const string ResourceHighAlertPriority =
                ";High" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";High";

            /// -------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MediumAlertPriority 
            /// </summary>
            /// -------------------------------------------------------------------
            private const string ResourceMediumAlertPriority =
                ";Medium" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";Medium";

            /// -------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  LowAlertPriority 
            /// </summary>
            /// -------------------------------------------------------------------
            private const string ResourceLowAlertPriority =
                ";Low" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";Low";

            #endregion
            
            #region Private Members

            /// -------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -------------------------------------------------------------------
            private static string cachedDialogTitle;
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectAll
            /// </summary>
            /// -------------------------------------------------------------------
            private static string cachedSelectAll;
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ClearAll
            /// </summary>
            /// -------------------------------------------------------------------
            private static string cachedClearAll;
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -------------------------------------------------------------------
            private static string cachedOK;

            /// -------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  HighAlertPriority 
            /// </summary>
            /// -------------------------------------------------------------------
            private static string cachedHighAlertPriority;

            /// -------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MediumAlertPriority 
            /// </summary>
            /// -------------------------------------------------------------------
            private static string cachedMediumAlertPriority;

            /// -------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  LowAlertPriority 
            /// </summary>
            /// -------------------------------------------------------------------
            private static string cachedLowAlertPriority;

            #endregion
            
            #region Properties

            /// -------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 23-SEP-08 Created
            /// </history>
            /// -------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    if (cachedDialogTitle == null)
                    {
                        cachedDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceDialogTitle);
                    }
                    
                    return cachedDialogTitle;
                }
            }
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectAll translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 23-SEP-08 Created
            /// </history>
            /// -------------------------------------------------------------------
            public static string SelectAll
            {
                get
                {
                    if (cachedSelectAll == null)
                    {
                        cachedSelectAll = CoreManager.MomConsole.GetIntlStr(ResourceSelectAll);
                    }
                    
                    return cachedSelectAll;
                }
            }
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 23-SEP-08 Created
            /// </history>
            /// -------------------------------------------------------------------
            public static string Cancel
            {
                get
                {
                    if (cachedCancel == null)
                    {
                        cachedCancel = CoreManager.MomConsole.GetIntlStr(ResourceCancel);
                    }
                    
                    return cachedCancel;
                }
            }
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ClearAll translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 23-SEP-08 Created
            /// </history>
            /// -------------------------------------------------------------------
            public static string ClearAll
            {
                get
                {
                    if (cachedClearAll == null)
                    {
                        cachedClearAll = CoreManager.MomConsole.GetIntlStr(ResourceClearAll);
                    }
                    
                    return cachedClearAll;
                }
            }
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 23-SEP-08 Created
            /// </history>
            /// -------------------------------------------------------------------
            public static string OK
            {
                get
                {
                    if (cachedOK == null)
                    {
                        cachedOK = CoreManager.MomConsole.GetIntlStr(ResourceOK);
                    }
                    
                    return cachedOK;
                }
            }

            /// -------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the HighAlertPriority  translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 23-SEP-08 Created
            /// </history>
            /// -------------------------------------------------------------------
            public static string HighAlertPriority 
            {
                get
                {
                    if (cachedHighAlertPriority == null)
                    {
                        cachedHighAlertPriority = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceHighAlertPriority);
                    }

                    return cachedHighAlertPriority;
                }
            }

            /// -------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MediumAlertPriority  translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 23-SEP-08 Created
            /// </history>
            /// -------------------------------------------------------------------
            public static string MediumAlertPriority 
            {
                get
                {
                    if (cachedMediumAlertPriority == null)
                    {
                        cachedMediumAlertPriority = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceMediumAlertPriority);
                    }

                    return cachedMediumAlertPriority;
                }
            }

            /// -------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the LowAlertPriority  translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 23-SEP-08 Created
            /// </history>
            /// -------------------------------------------------------------------
            public static string LowAlertPriority 
            {
                get
                {
                    if (cachedLowAlertPriority == null)
                    {
                        cachedLowAlertPriority = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceLowAlertPriority);
                    }

                    return cachedLowAlertPriority;
                }
            }

            #endregion
        }
        #endregion
        
        #region Control ID's

        /// -------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 23-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for SelectAllButton
            /// </summary>
            public const string SelectAllButton = "buttonSelectAll";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "buttonCancel";
            
            /// <summary>
            /// Control ID for ClearAllButton
            /// </summary>
            public const string ClearAllButton = "buttonClearAll";
            
            /// <summary>
            /// Control ID for PrioritiesCheckedListBox
            /// </summary>
            public const string PrioritiesCheckedListBox = "checkedList";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "buttonOK";
        }

        #endregion
    }
}
