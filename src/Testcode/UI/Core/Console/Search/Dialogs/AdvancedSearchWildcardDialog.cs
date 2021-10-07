// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AdvancedSearchWildcardDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3
// </project>
// <summary>
// 	Advanced Search wildcard dialog
// </summary>
// <history>
// 	[visnara] 6/27/2006 Created
//  [visnara] 1/04/2007 Added resource strings to support searching for Object Discoveries 
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Search.Dialogs
{
    #region using directives

    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;

    using Mom.Test.UI.Core.Console;
    using Mom.Test.UI.Core.Console.AdvancedSearch;

    #endregion

    #region Interface Definition - IAdvancedSearchWildcardDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAdvancedSearchWildcardDialogControls, for AdvancedSearchWildcardDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[visnara] 6/27/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAdvancedSearchWildcardDialogControls
    {
        /// <summary>
        /// Read-only property to access CancelButton
        /// </summary>
        Button CancelButton
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
        /// Read-only property to access SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedStaticControl
        /// </summary>
        StaticControl SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedTextBox
        /// </summary>
        TextBox SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedTextBox
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Advanced Search wildcard dialog
    /// </summary>
    /// <history>
    /// 	[visnara] 6/27/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class AdvancedSearchWildcardDialog : Dialog, IAdvancedSearchWildcardDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedTextBox of type TextBox
        /// </summary>
        private TextBox cachedSpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedTextBox;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name='app'>
        /// Owner of AdvancedSearchWildcardDialog of type App
        /// </param>
        /// <param name="searchObjectType">
        /// Type of object we are searching for. Based on this, we look for dialog with appropriate title
        /// </param>
        /// <history>
        /// 	[visnara] 6/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AdvancedSearchWildcardDialog(App app, AdvancedSearchObjectType searchObjectType) : 
                base(app, Init(app, searchObjectType))
        {
            // Add Constructor logic here. 
        }
        #endregion
        
        #region IAdvancedSearchWildcardDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[visnara] 6/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAdvancedSearchWildcardDialogControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAccepted
        /// </summary>
        /// <history>
        /// 	[visnara] 6/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedText
        {
            get
            {
                return this.Controls.SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedTextBox.Text;
            }
            
            set
            {
                this.Controls.SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[visnara] 6/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAdvancedSearchWildcardDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AdvancedSearchWildcardDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[visnara] 6/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAdvancedSearchWildcardDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, AdvancedSearchWildcardDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedStaticControl control
        /// </summary>
        /// <history>
        /// 	[visnara] 6/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAdvancedSearchWildcardDialogControls.SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedStaticControl
        {
            get
            {
                if ((this.cachedSpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedStaticControl == null))
                {
                    this.cachedSpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedStaticControl = new StaticControl(this, AdvancedSearchWildcardDialog.ControlIDs.SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedStaticControl);
                }
                
                return this.cachedSpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedTextBox control
        /// </summary>
        /// <history>
        /// 	[visnara] 6/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAdvancedSearchWildcardDialogControls.SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedTextBox
        {
            get
            {
                if ((this.cachedSpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedTextBox == null))
                {
                    this.cachedSpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedTextBox = new TextBox(this, AdvancedSearchWildcardDialog.ControlIDs.SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedTextBox);
                }
                
                return this.cachedSpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedTextBox;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[visnara] 6/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[visnara] 6/27/2006 Created
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
        /// <param name="app">App</param>
        /// <param name="searchObjectType">Type of object to search for</param>
        /// <returns>A reference to the dialog's Window</returns>
        /// <history>
        /// 	[visnara] 6/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app, AdvancedSearchObjectType searchObjectType)
        {
            ////Choose appropriate dialog title based on search object type
            string dialogTitle = null;

            switch (searchObjectType)
            {
                case AdvancedSearchObjectType.ManagedObjects:
                    dialogTitle = Strings.ManagedObjectsDialogTitle;
                    break;
                case AdvancedSearchObjectType.Alerts:
                    dialogTitle = Strings.AlertsDialogTitle;
                    break;
                case AdvancedSearchObjectType.Events:
                    dialogTitle = Strings.EventsDialogTitle;
                    break;
                case AdvancedSearchObjectType.Rules:
                    dialogTitle = Strings.RulesDialogTitle;
                    break;
                case AdvancedSearchObjectType.Views:
                    dialogTitle = Strings.ViewsDialogTitle;
                    break;
                case AdvancedSearchObjectType.Tasks:
                    dialogTitle = Strings.TasksDialogTitle;
                    break;
                case AdvancedSearchObjectType.ObjectDiscoveries:
                    dialogTitle = Strings.ObjectDiscoveriesDialogTitle;
                    break;
            }

            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(dialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.WildCard, app, Timeout);
            }
            catch (Exceptions.WindowNotFoundException ex)
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
                                dialogTitle + "*",
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
                            "Attempt " + numberOfTries + " of " + MaxTries);
                
                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }
                
                // check for success
                if (tempWindow == null)
                {
                    //// log the failure
                     Core.Common.Utilities.LogMessage(
                        "Failed to find window with title:  '" +
                        dialogTitle + "'");

                    //// throw the existing WindowNotFound exception
                    throw ex;
                }
            }
            
            return tempWindow;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Strings class
        /// </summary>
        /// <history>
        /// 	[visnara] 6/27/2006 Created
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
            private const string ResourceManagedObjectsDialogTitle = ";Managed Object Name;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.ManagedObjectView.ManagedObjectViewResource;NameCriteriaDialogTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertsDialogTitle = ";Alert Name;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;NameEditTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMonitorsDialogTitle = ";Monitor Name;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.MonitorViewResources;DisplayNameTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEventsDialogTitle = ";Logging Computer;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.EventViewCriteriaResource;AgentTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRulesDialogTitle = ";Rule Name;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.RuleViewCriteriaResources;DisplayNameTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceViewsDialogTitle = ";View Name;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.ViewsViewCriteriaResources;DisplayNameTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTasksDialogTitle = ";Task Name;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.TaskViewCriteriaResources;DisplayNameTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceObjectDiscoveriesDialogTitle = ";Object Discovery Name;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiscoveriesViewCriteriaResources;DisplayNameTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.Tr" +
                "anslucentColorPicker;buttonOk.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAccepted
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecifyTheTextStringToSearchForSQLStyleWildcards_AreAccepted = ";&Specify the text string to search for.  SQL-style wildcards (%, _) are accepted" +
                ".;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.I" +
                "nternal.UI.Controls.StringEditDialog;labelHeader.Text";
            #endregion
            
            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedManagedObjectsDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertsDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonitorsDialogTitle;


            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEventsDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRulesDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedViewsDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTasksDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedObjectDiscoveriesDialogTitle;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAccepted
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpecifyTheTextStringToSearchForSQLStyleWildcards_AreAccepted;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 6/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ManagedObjectsDialogTitle
            {
                get
                {
                    if ((cachedManagedObjectsDialogTitle == null))
                    {
                        cachedManagedObjectsDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceManagedObjectsDialogTitle);
                    }
                    
                    return cachedManagedObjectsDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 6/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertsDialogTitle
            {
                get
                {
                    if ((cachedAlertsDialogTitle == null))
                    {
                        cachedAlertsDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceAlertsDialogTitle);
                    }

                    return cachedAlertsDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 8/22/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MonitorsDialogTitle
            {
                get
                {
                    if ((cachedMonitorsDialogTitle == null))
                    {
                        cachedMonitorsDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceMonitorsDialogTitle);
                    }

                    return cachedMonitorsDialogTitle;
                }
            }


            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 6/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EventsDialogTitle
            {
                get
                {
                    if ((cachedEventsDialogTitle == null))
                    {
                        cachedEventsDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceEventsDialogTitle);
                    }

                    return cachedEventsDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 6/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RulesDialogTitle
            {
                get
                {
                    if ((cachedRulesDialogTitle == null))
                    {
                        cachedRulesDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceRulesDialogTitle);
                    }

                    return cachedRulesDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 6/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ViewsDialogTitle
            {
                get
                {
                    if ((cachedViewsDialogTitle == null))
                    {
                        cachedViewsDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceViewsDialogTitle);
                    }

                    return cachedViewsDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 6/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TasksDialogTitle
            {
                get
                {
                    if ((cachedTasksDialogTitle == null))
                    {
                        cachedTasksDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceTasksDialogTitle);
                    }

                    return cachedTasksDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 01/04/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ObjectDiscoveriesDialogTitle
            {
                get
                {
                    if ((cachedObjectDiscoveriesDialogTitle == null))
                    {
                        cachedObjectDiscoveriesDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceObjectDiscoveriesDialogTitle);
                    }

                    return cachedObjectDiscoveriesDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 6/27/2006 Created
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
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 6/27/2006 Created
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
            /// Exposes access to the SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAccepted translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 6/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAccepted
            {
                get
                {
                    if ((cachedSpecifyTheTextStringToSearchForSQLStyleWildcards_AreAccepted == null))
                    {
                        cachedSpecifyTheTextStringToSearchForSQLStyleWildcards_AreAccepted = CoreManager.MomConsole.GetIntlStr(ResourceSpecifyTheTextStringToSearchForSQLStyleWildcards_AreAccepted);
                    }
                    
                    return cachedSpecifyTheTextStringToSearchForSQLStyleWildcards_AreAccepted;
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
        /// 	[visnara] 6/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "buttonCancel";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "buttonOK";
            
            /// <summary>
            /// Control ID for SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedStaticControl
            /// </summary>
            public const string SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedStaticControl = "labelHeader";
            
            /// <summary>
            /// Control ID for SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedTextBox
            /// </summary>
            public const string SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedTextBox = "textBox";
        }
        #endregion
    }
}
