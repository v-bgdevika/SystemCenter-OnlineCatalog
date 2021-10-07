// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AlertSourceViewCriteria.cs">
// 	Copyright (c) Microsoft Corporation 2007
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
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
    
    #region Interface Definition - IAlertSourceViewCriteriaControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAlertSourceViewCriteriaControls, for AlertSourceViewCriteria.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[lucyra] 3/21/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAlertSourceViewCriteriaControls
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
        /// Read-only property to access AlertSourceListBox
        /// </summary>
        ListBox AlertSourceListBox
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
    /// TODO: Add dialog functionality description here.
    /// </summary>
    /// <history>
    /// 	[lucyra] 3/21/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class AlertSourceViewCriteria : Dialog, IAlertSourceViewCriteriaControls
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
        /// Cache to hold a reference to AlertSourceListBox of type ListBox
        /// </summary>
        private ListBox cachedAlertSourceListBox;
        
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
        /// Owner of AlertSourceViewCriteria of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AlertSourceViewCriteria(ConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IAlertSourceViewCriteria Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAlertSourceViewCriteriaControls Controls
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
        Button IAlertSourceViewCriteriaControls.SelectAllButton
        {
            get
            {
                if ((this.cachedSelectAllButton == null))
                {
                    this.cachedSelectAllButton = new Button(this, AlertSourceViewCriteria.ControlIDs.SelectAllButton);
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
        Button IAlertSourceViewCriteriaControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AlertSourceViewCriteria.ControlIDs.CancelButton);
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
        Button IAlertSourceViewCriteriaControls.ClearAllButton
        {
            get
            {
                if ((this.cachedClearAllButton == null))
                {
                    this.cachedClearAllButton = new Button(this, AlertSourceViewCriteria.ControlIDs.ClearAllButton);
                }
                
                return this.cachedClearAllButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertSourceListBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListBox IAlertSourceViewCriteriaControls.AlertSourceListBox
        {
            get
            {
                if ((this.cachedAlertSourceListBox == null))
                {
                    this.cachedAlertSourceListBox = new ListBox(this, AlertSourceViewCriteria.ControlIDs.AlertSourceListBox);
                }
                
                return this.cachedAlertSourceListBox;
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
        Button IAlertSourceViewCriteriaControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, AlertSourceViewCriteria.ControlIDs.OKButton);
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
                            "AlertSourceViewCriteriaDialog:: Attempt " + numberOfTries + " of " + MaxTries);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "AlertSourceViewCriteriaDialog:: Failed to find window with title:  '" +
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
            private const string ResourceDialogTitle = ";Alert Source;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;SourceTitle";
            
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
            /// Control ID for AlertSourceListBox
            /// </summary>
            public const string AlertSourceListBox = "checkedList";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "buttonOK";
        }
        #endregion
    }
}
