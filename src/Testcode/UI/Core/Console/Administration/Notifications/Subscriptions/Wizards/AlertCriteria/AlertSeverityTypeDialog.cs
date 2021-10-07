// ----------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AlertSeverityTypeDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	MOMv3 R2 test automation.
// </project>
// <summary>
// 	MOMv3 R2 test automation.
// </summary>
// <history>
// 	[KellyMor]  15-SEP-08   Created
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
    
    #region Interface Definition - IAlertSeverityTypeDialogControls

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAlertSeverityTypeDialogControls, for 
    /// AlertSeverityTypeDialog.  Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 15-SEP-08 Created
    /// </history>
    /// -----------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAlertSeverityTypeDialogControls
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
        /// Read-only property to access SeveritiesCheckedListBox
        /// </summary>
        CheckedListBox SeveritiesCheckedListBox
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
    
    /// -----------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the functionality of the Alert Type dialog for
    /// selecting alert criteria severity.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 15-SEP-08 Created
    /// </history>
    /// -----------------------------------------------------------------------
    public class AlertSeverityTypeDialog : Dialog, IAlertSeverityTypeDialogControls
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
        /// Cache to hold a reference to SeveritiesCheckedListBox of type 
        /// ListBox
        /// </summary>
        private CheckedListBox cachedSeveritiesCheckedListBox;
        
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
        /// Owner of AlertSeverityTypeDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[KellyMor] 15-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public AlertSeverityTypeDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }

        #endregion
        
        #region IAlertSeverityTypeDialog Controls Property

        /// -------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>
        /// An interface that groups all of the dialog's control properties 
        /// together
        /// </value>
        /// <history>
        /// 	[KellyMor] 15-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual IAlertSeverityTypeDialogControls Controls
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
        /// 	[KellyMor] 15-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        Button IAlertSeverityTypeDialogControls.SelectAllButton
        {
            get
            {
                if (this.cachedSelectAllButton == null)
                {
                    this.cachedSelectAllButton = 
                        new Button(
                            this, 
                            AlertSeverityTypeDialog.ControlIDs.SelectAllButton);
                }
                
                return this.cachedSelectAllButton;
            }
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 15-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        Button IAlertSeverityTypeDialogControls.CancelButton
        {
            get
            {
                if (this.cachedCancelButton == null)
                {
                    this.cachedCancelButton = 
                        new Button(
                            this, 
                            AlertSeverityTypeDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ClearAllButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 15-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        Button IAlertSeverityTypeDialogControls.ClearAllButton
        {
            get
            {
                if (this.cachedClearAllButton == null)
                {
                    this.cachedClearAllButton = 
                        new Button(
                            this, 
                            AlertSeverityTypeDialog.ControlIDs.ClearAllButton);
                }
                
                return this.cachedClearAllButton;
            }
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SeveritiesCheckedListBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 15-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        CheckedListBox IAlertSeverityTypeDialogControls.SeveritiesCheckedListBox
        {
            get
            {
                if (this.cachedSeveritiesCheckedListBox == null)
                {
                    this.cachedSeveritiesCheckedListBox = 
                        new CheckedListBox(
                            this, 
                            AlertSeverityTypeDialog.ControlIDs.SeveritiesCheckedListBox);
                }
                
                return this.cachedSeveritiesCheckedListBox;
            }
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 15-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        Button IAlertSeverityTypeDialogControls.OKButton
        {
            get
            {
                if (this.cachedOKButton == null)
                {
                    this.cachedOKButton = 
                        new Button(
                            this, 
                            AlertSeverityTypeDialog.ControlIDs.OKButton);
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
        /// 	[KellyMor] 15-SEP-08 Created
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
        /// 	[KellyMor] 15-SEP-08 Created
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
        /// 	[KellyMor] 15-SEP-08 Created
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
        /// 	[KellyMor] 15-SEP-08 Created
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
        /// 	[KellyMor] 15-SEP-08 Created
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
                if ((null == tempWindow))
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
        /// 	[KellyMor] 15-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceDialogTitle = 
                ";Alert Type" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.CriteriaControl.CriteriaControlResource" +
                ";AlertTypeEditDialogTitle";
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectAll
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceSelectAll =
                ";&Select All" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.CheckedListEditDialogBase" +
                ";buttonSelectAll.Text";
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceCancel =
                ";Cancel" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.SimpleChooserDialog" +
                ";cancelButton.Text";
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ClearAll
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceClearAll =
                ";&Clear All" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.CheckedListEditDialogBase" +
                ";buttonClearAll.Text";
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceOK =
                ";OK" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.SimpleChooserDialog" +
                ";okButton.Text";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CriticalAlertSeverity 
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceCriticalAlertSeverity =
                ";Critical" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";Error";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WarningAlertSeverity 
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceWarningAlertSeverity =
                ";Warning" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";Warning";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  InformationAlertSeverity 
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceInformationAlertSeverity =
                ";Information" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";Information";

            #endregion
            
            #region Private Members

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedDialogTitle;
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectAll
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedSelectAll;
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedCancel;
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ClearAll
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedClearAll;
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedOK;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  
            /// CriticalAlertSeverity 
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedCriticalAlertSeverity;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  
            /// WarningAlertSeverity 
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedWarningAlertSeverity;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  
            /// InformationAlertSeverity 
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedInformationAlertSeverity;

            #endregion
            
            #region Properties

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 15-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
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
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectAll translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 15-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string SelectAll
            {
                get
                {
                    if ((cachedSelectAll == null))
                    {
                        cachedSelectAll = CoreManager.MomConsole.GetIntlStr(ResourceSelectAll);
                    }
                    
                    return cachedSelectAll;
                }
            }
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 15-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string Cancel
            {
                get
                {
                    if ((cachedCancel == null))
                    {
                        cachedCancel = CoreManager.MomConsole.GetIntlStr(ResourceCancel);
                    }
                    
                    return cachedCancel;
                }
            }
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ClearAll translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 15-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string ClearAll
            {
                get
                {
                    if ((cachedClearAll == null))
                    {
                        cachedClearAll = CoreManager.MomConsole.GetIntlStr(ResourceClearAll);
                    }
                    
                    return cachedClearAll;
                }
            }
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 15-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string OK
            {
                get
                {
                    if ((cachedOK == null))
                    {
                        cachedOK = CoreManager.MomConsole.GetIntlStr(ResourceOK);
                    }
                    
                    return cachedOK;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CriticalAlertSeverity translated resource
            /// string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 23-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string CriticalAlertSeverity
            {
                get
                {
                    if ((cachedCriticalAlertSeverity == null))
                    {
                        cachedCriticalAlertSeverity = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCriticalAlertSeverity);
                    }

                    return cachedCriticalAlertSeverity;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WarningAlertSeverity  translated resource
            /// string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 23-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string WarningAlertSeverity 
            {
                get
                {
                    if ((cachedWarningAlertSeverity == null))
                    {
                        cachedWarningAlertSeverity = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceWarningAlertSeverity);
                    }

                    return cachedWarningAlertSeverity;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the InformationAlertSeverity  translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 23-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string InformationAlertSeverity 
            {
                get
                {
                    if ((cachedInformationAlertSeverity == null))
                    {
                        cachedInformationAlertSeverity = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceInformationAlertSeverity);
                    }

                    return cachedInformationAlertSeverity;
                }
            }

            #endregion
        }

        #endregion
        
        #region Control ID's

        /// ---------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 15-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
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
            /// Control ID for SeveritiesCheckedListBox
            /// </summary>
            public const string SeveritiesCheckedListBox = "checkedList";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "buttonOK";
        }

        #endregion
    }
}
