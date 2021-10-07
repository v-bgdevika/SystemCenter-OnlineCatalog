// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="TaskSelectionWithSpecificStatusDialog.cs">
//   Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//   [v-eachu] 10/15/2009 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.TaskStatus.Dialogs
{
    #region Using directivew
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console;
    #endregion
    
    #region Interface Definition - ITaskSelectionWithSpecificStatusDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ITaskSelectionWithSpecificStatusDialogControls, for TaskSelectionWithSpecificStatusDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-eachu] 10/15/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ITaskSelectionWithSpecificStatusDialogControls
    {
        /// <summary>
        /// Read-only property to access ListBox0
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        ListBox ListBox0
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectAllButton
        /// </summary>
        Button SelectAllButton
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
        /// Read-only property to access OKButton
        /// </summary>
        Button OKButton
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
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add dialog functionality description here.
    /// </summary>
    /// <history>
    ///   [v-eachu] 10/15/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class TaskSelectionWithSpecificStatusDialog : Dialog, ITaskSelectionWithSpecificStatusDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ListBox0 of type ListBox
        /// </summary>
        private ListBox cachedListBox0;
        
        /// <summary>
        /// Cache to hold a reference to SelectAllButton of type Button
        /// </summary>
        private Button cachedSelectAllButton;
        
        /// <summary>
        /// Cache to hold a reference to ClearAllButton of type Button
        /// </summary>
        private Button cachedClearAllButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of TaskSelectionWithSpecificStatusDialog of type App
        /// </param>
        /// <history>
        ///   [v-eachu] 10/15/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public TaskSelectionWithSpecificStatusDialog(ConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region ITaskSelectionWithSpecificStatusDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [v-eachu] 10/15/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ITaskSelectionWithSpecificStatusDialogControls Controls
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
        ///  Exposes access to the ListBox0 control
        /// </summary>
        /// <history>
        ///   [v-eachu] 10/15/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListBox ITaskSelectionWithSpecificStatusDialogControls.ListBox0
        {
            get
            {
                if ((this.cachedListBox0 == null))
                {
                    this.cachedListBox0 = new ListBox(this, TaskSelectionWithSpecificStatusDialog.ControlIDs.ListBox0);
                }
                
                return this.cachedListBox0;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectAllButton control
        /// </summary>
        /// <history>
        ///   [v-eachu] 10/15/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITaskSelectionWithSpecificStatusDialogControls.SelectAllButton
        {
            get
            {
                if ((this.cachedSelectAllButton == null))
                {
                    this.cachedSelectAllButton = new Button(this, TaskSelectionWithSpecificStatusDialog.ControlIDs.SelectAllButton);
                }
                
                return this.cachedSelectAllButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ClearAllButton control
        /// </summary>
        /// <history>
        ///   [v-eachu] 10/15/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITaskSelectionWithSpecificStatusDialogControls.ClearAllButton
        {
            get
            {
                if ((this.cachedClearAllButton == null))
                {
                    this.cachedClearAllButton = new Button(this, TaskSelectionWithSpecificStatusDialog.ControlIDs.ClearAllButton);
                }
                
                return this.cachedClearAllButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        ///   [v-eachu] 10/15/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITaskSelectionWithSpecificStatusDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, TaskSelectionWithSpecificStatusDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        ///   [v-eachu] 10/15/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITaskSelectionWithSpecificStatusDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, TaskSelectionWithSpecificStatusDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button SelectAll
        /// </summary>
        /// <history>
        ///   [v-eachu] 10/15/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSelectAll()
        {
            this.Controls.SelectAllButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ClearAll
        /// </summary>
        /// <history>
        ///   [v-eachu] 10/15/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickClearAll()
        {
            this.Controls.ClearAllButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        ///   [v-eachu] 10/15/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        ///   [v-eachu] 10/15/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">App owning the dialog.</param>
        /// <history>
        ///   [v-eachu] 10/15/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle,
                    StringMatchSyntax.ExactMatch,
                    WindowClassNames.WinForms10Window8,
                    StringMatchSyntax.ExactMatch,
                    app,
                    Timeout);
            }
            catch (Exceptions.WindowNotFoundException windowNotFound)
            {
                tempWindow = null;
                int numberofTries = 0;
                const int MaxTries = 10;
                while (tempWindow == null && numberofTries < MaxTries)
                {
                    numberofTries++;
                    try
                    {
                        // look for the window again using wildcards
                        tempWindow = new Window(Strings.DialogTitle + "*",
                            StringMatchSyntax.WildCard,
                            WindowClassNames.WinForms10Window8,
                            StringMatchSyntax.WildCard,
                            app,
                            Timeout);

                        // wait for the window to report ready
                        app.Waiters.WaitForWindowIdle(tempWindow, 60000);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        //log the unsuccessful attemp
                        Core.Common.Utilities.LogMessage("Attempt " + numberofTries + " of " + MaxTries);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    //log the failure
                    Core.Common.Utilities.LogMessage("Failed to find window with title: '" + Strings.DialogTitle + "'");

                    //throw the existing WindowNotFound exception
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
        ///   [v-eachu] 10/15/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ListBox0
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string ListBox0 = "checkedList";
            
            /// <summary>
            /// Control ID for SelectAllButton
            /// </summary>
            public const string SelectAllButton = "buttonSelectAll";
            
            /// <summary>
            /// Control ID for ClearAllButton
            /// </summary>
            public const string ClearAllButton = "buttonClearAll";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "buttonOK";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "buttonCancel";
        }
        #endregion

        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        ///   [v-eachu] 9/27/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// <summary>
            /// Resource string for Task Status
            /// </summary>
            // Task Status
            public const string ResourceDialogTitle = ";Task Status;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.Controls.CriteriaControl.CriteriaControlResource;TaskStatus" +
                "EditDialogTitle";

            /// <summary>
            /// Resource string for Select All
            /// </summary>
            // &Select All
            public const string ResourceSelectAll = ";&Select All;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;M" +
                "icrosoft.EnterpriseManagement.Mom.Internal.UI.Administration.SelectTasksForm;but" +
                "tonSelectAll.Text";

            /// <summary>
            /// Resource string for Clear All
            /// </summary>
            // &Clear All
            public const string ResourceClearAll = ";&Clear All;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Mi" +
                "crosoft.EnterpriseManagement.Mom.Internal.UI.Administration.SelectTasksForm;butt" +
                "onClearAll.Text";

            /// <summary>
            /// Resource string for OK
            /// </summary>
            // OK
            public const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.Tr" +
                "anslucentColorPicker;buttonOk.Text";

            /// <summary>
            /// Resource string for Cancel
            /// </summary>
            // Cancel
            public const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";

            /// <summary>
            /// Resource string for Scheduled
            /// </summary>
            // Scheduled
            public const string ResourceScheduled = ";Scheduled;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.CriteriaControl.CriteriaControlResource;TaskStatusScheduled";

            /// <summary>
            /// Resource string for Started
            /// </summary>
            // Started
            public const string ResourceStarted = ";Started;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.CriteriaControl.CriteriaControlResource;TaskStatusStarted";

            /// <summary>
            /// Resource string for Succeeded
            /// </summary>
            // Succeeded
            public const string ResourceSucceeded = ";Succeeded;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.CriteriaControl.CriteriaControlResource;TaskStatusSucceeded";

            /// <summary>
            /// Resource string for Failed
            /// </summary>
            // Failed
            public const string ResourceFailed = ";Failed;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.CriteriaControl.CriteriaControlResource;TaskStatusFailed";


            #endregion

            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for: Dialog Title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for: Select All
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectAll;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for: Clear All
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedClearAll;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for: OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for: Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for: Scheduled
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedScheduled;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for: Started
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedStarted;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for: Succeeded
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSucceeded;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for: Failed
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFailed;

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[v-eachu] 9/27/2009 Created
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

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Select All translated resource string
            /// </summary>
            /// <history>
            /// 	[v-eachu] 9/27/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
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

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Clear All translated resource string
            /// </summary>
            /// <history>
            /// 	[v-eachu] 9/27/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
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

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[v-eachu] 9/27/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
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

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[v-eachu] 9/27/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
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

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Scheduled translated resource string
            /// </summary>
            /// <history>
            /// 	[v-eachu] 9/27/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Scheduled
            {
                get
                {
                    if ((cachedScheduled == null))
                    {
                        cachedScheduled = CoreManager.MomConsole.GetIntlStr(ResourceScheduled);
                    }
                    return cachedScheduled;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Started translated resource string
            /// </summary>
            /// <history>
            /// 	[v-eachu] 9/27/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Started
            {
                get
                {
                    if ((cachedStarted == null))
                    {
                        cachedStarted = CoreManager.MomConsole.GetIntlStr(ResourceStarted);
                    }
                    return cachedStarted;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Succeeded translated resource string
            /// </summary>
            /// <history>
            /// 	[v-eachu] 9/27/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Succeeded
            {
                get
                {
                    if ((cachedSucceeded == null))
                    {
                        cachedSucceeded = CoreManager.MomConsole.GetIntlStr(ResourceSucceeded);
                    }
                    return cachedSucceeded;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Failed translated resource string
            /// </summary>
            /// <history>
            /// 	[v-eachu] 9/27/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Failed
            {
                get
                {
                    if ((cachedFailed == null))
                    {
                        cachedFailed = CoreManager.MomConsole.GetIntlStr(ResourceFailed);
                    }
                    return cachedFailed;
                }
            }

            #endregion
        }
        #endregion
    }
}
