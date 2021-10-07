// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AlertTypeViewCriteria.cs">
// 	Copyright (c) Microsoft Corporation 2007
// </copyright>
// <project>
// 	Alert View criteria automation
// </project>
// <summary>
// 	This dialog is supporting Alert Severity Type View criteria
// </summary>
// <history>
// 	[lucyra] 3/21/2007 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.Alerts
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console.Views;

    
    #region Interface Definition - IAlertTypeViewCriteriaControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAlertTypeViewCriteriaControls, for AlertTypeViewCriteria.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[lucyra] 3/21/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAlertTypeViewCriteriaControls
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
        /// Read-only property to access AlertSeverityTypeListBox
        /// </summary>
        ListBox AlertSeverityTypeListBox
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
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// This dialog is used to set Alert Severity Type View Criteria of the Alerts view
    /// </summary>
    /// <history>
    /// 	[lucyra] 3/21/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class AlertTypeViewCriteria : Dialog, IAlertTypeViewCriteriaControls
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
        /// Cache to hold a reference to AlertSeverityTypeListBox of type ListBox
        /// </summary>
        private ListBox cachedAlertSeverityTypeListBox;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of AlertTypeViewCriteria of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AlertTypeViewCriteria(ConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IAlertTypeViewCriteria Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAlertTypeViewCriteriaControls Controls
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
        ///  Exposes access to the SelectAllButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertTypeViewCriteriaControls.SelectAllButton
        {
            get
            {
                if ((this.cachedSelectAllButton == null))
                {
                    this.cachedSelectAllButton = new Button(this, AlertTypeViewCriteria.ControlIDs.SelectAllButton);
                }
                
                return this.cachedSelectAllButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertTypeViewCriteriaControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AlertTypeViewCriteria.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ClearAllButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertTypeViewCriteriaControls.ClearAllButton
        {
            get
            {
                if ((this.cachedClearAllButton == null))
                {
                    this.cachedClearAllButton = new Button(this, AlertTypeViewCriteria.ControlIDs.ClearAllButton);
                }
                
                return this.cachedClearAllButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertSeverityTypeListBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListBox IAlertTypeViewCriteriaControls.AlertSeverityTypeListBox
        {
            get
            {
                if ((this.cachedAlertSeverityTypeListBox == null))
                {
                    this.cachedAlertSeverityTypeListBox = new ListBox(this, AlertTypeViewCriteria.ControlIDs.AlertSeverityTypeListBox);
                }
                
                return this.cachedAlertSeverityTypeListBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertTypeViewCriteriaControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, AlertTypeViewCriteria.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button SelectAll
        /// </summary>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSelectAll()
        {
            this.Controls.SelectAllButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ClearAll
        /// </summary>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
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
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">ConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(
                    Strings.DialogTitle,
                    StringMatchSyntax.WildCard,
                    WindowClassNames.WinForms10Window8,
                    StringMatchSyntax.WildCard,
                    app,
                    Timeout);
            }
            catch (Exceptions.WindowNotFoundException)
            {
                tempWindow = null;
                int numberOfTries = 0;
                const int MaxTries = 5;
                while (tempWindow == null && numberOfTries < MaxTries)
                {
                    numberOfTries++;
                    try
                    {
                        // look for the window again using wildcards
                        tempWindow =
                            new Window(
                                Strings.DialogTitle + "*",
                                StringMatchSyntax.WildCard,
                                WindowClassNames.WinForms10Window8,
                                StringMatchSyntax.WildCard,
                                app,
                                Timeout);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage(
                            "AlertSeverityTypeViewCriteriaDialog:: Attempt " + numberOfTries + " of " + MaxTries);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "AlertSeverityTypeViewCriteriaDialog:: Failed to find window with title:  '" +
                        Strings.DialogTitle + "'");

                    // throw the existing WindowNotFound exception
                    throw;
                }
            }

            return tempWindow;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        ///     [a-joelj]   27JAN09 Added resources for Information, Warning and Critical   
        ///                         alert types
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle = 
                ";Alert Type;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls." +
                "CriteriaControl.CriteriaControlResource;AlertTypeEditDialogTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectAll
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectAll = ";&Select All;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;M" +
                "icrosoft.EnterpriseManagement.Mom.Internal.UI.Administration.SelectTasksForm;but" +
                "tonSelectAll.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ClearAll
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceClearAll = ";&Clear All;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Mi" +
                "crosoft.EnterpriseManagement.Mom.Internal.UI.Administration.SelectTasksForm;butt" +
                "onClearAll.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.Tr" +
                "anslucentColorPicker;buttonOk.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Information
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertTypeInformation = 
                ";Information" +
                ";ManagedString;Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.CriteriaControl.CriteriaControlResource" +
                ";AlertSeveritySuccess";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Warning
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertTypeWarning = 
                ";Warning" +
                ";ManagedString;Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.CriteriaControl.CriteriaControlResource" +
                ";AlertSeverityWarning";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Critical
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertTypeCritical = 
                ";Critical" +
                ";ManagedString;Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.CriteriaControl.CriteriaControlResource" +
                ";AlertSeverityError";

            #endregion
            
            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitle;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectAll
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectAll;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ClearAll
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedClearAll;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Information
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertTypeInformation;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Warning
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertTypeWarning;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Critical
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertTypeCritical;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 3/21/2007 Created
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
            /// Exposes access to the SelectAll translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 3/21/2007 Created
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
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 3/21/2007 Created
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
            /// Exposes access to the ClearAll translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 3/21/2007 Created
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
            /// 	[lucyra] 3/21/2007 Created
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
            /// Exposes access to the Information alert type translated resource string
            /// </summary>
            /// <history>
            /// 	[a-joelj] 9/27/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertTypeInformation
            {
                get
                {
                    if ((cachedAlertTypeInformation == null))
                    {
                        cachedAlertTypeInformation = CoreManager.MomConsole.GetIntlStr(ResourceAlertTypeInformation);
                    }

                    return cachedAlertTypeInformation;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Warning alert type translated resource string
            /// </summary>
            /// <history>
            /// 	[a-joelj] 9/27/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertTypeWarning
            {
                get
                {
                    if ((cachedAlertTypeWarning == null))
                    {
                        cachedAlertTypeWarning = CoreManager.MomConsole.GetIntlStr(ResourceAlertTypeWarning);
                    }

                    return cachedAlertTypeWarning;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Critical alert type translated resource string
            /// </summary>
            /// <history>
            /// 	[a-joelj] 9/27/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertTypeCritical
            {
                get
                {
                    if ((cachedAlertTypeCritical == null))
                    {
                        cachedAlertTypeCritical = CoreManager.MomConsole.GetIntlStr(ResourceAlertTypeCritical);
                    }

                    return cachedAlertTypeCritical;
                }
            }
            #endregion
        }
        #endregion
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
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
            /// Control ID for AlertSeverityTypeListBox
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string AlertSeverityTypeListBox = "checkedList";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "buttonOK";
        }
        #endregion
    }
}
