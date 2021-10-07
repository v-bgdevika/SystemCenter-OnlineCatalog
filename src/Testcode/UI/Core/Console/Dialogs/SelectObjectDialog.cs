// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SelectObjectDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3 Test UI Automation
// </project>
// <summary>
// 	Common dialog used to pick Groups or Instances
// </summary>
// <history>
// 	[ruhim] 9/20/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - ISelectObjectDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISelectObjectDialogControls, for SelectObjectDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 9/20/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISelectObjectDialogControls
    {
        /// <summary>
        /// Read-only property to access SearchTextBelow
        /// </summary>
        TextBox SearchTextBelow
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MatchingObjectsListView
        /// </summary>
        ListView MatchingObjectsListView
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
        /// Read-only property to access OKButton
        /// </summary>
        Button OKButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EnterYourSearchTextBelowThisSearchesBothDisplayNameAndPathStaticControl
        /// </summary>
        StaticControl EnterYourSearchTextBelowThisSearchesBothDisplayNameAndPathStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MatchingObjectsStaticControl
        /// </summary>
        StaticControl MatchingObjectsStaticControl
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
    /// 	[ruhim] 9/20/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SelectObjectDialog : Dialog, ISelectObjectDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to SearchTextBelow of type TextBox
        /// </summary>
        private TextBox cachedSearchTextBelow;
        
        /// <summary>
        /// Cache to hold a reference to MatchingObjectsListView of type ListView
        /// </summary>
        private ListView cachedMatchingObjectsListView;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to EnterYourSearchTextBelowThisSearchesBothDisplayNameAndPathStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEnterYourSearchTextBelowThisSearchesBothDisplayNameAndPathStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to MatchingObjectsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMatchingObjectsStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of SelectObjectDialog of type App
        /// </param>
        /// <history>
        /// 	[ruhim] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SelectObjectDialog(MomConsoleApp app)
            :
                base(app, Init(app))
        {
            Core.Common.Utilities.LogMessage("SelectObjectDialog:: Sucessfully found the dialog");
        }
        #endregion
        
        #region ISelectObjectDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISelectObjectDialogControls Controls
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
        ///  Routine to set/get the text in control EnterYourSearchTextBelowThisSearchesBothDisplayNameAndPath
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string EnterYourSearchTextBelowThisSearchesBothDisplayNameAndPathText
        {
            get
            {
                return this.Controls.SearchTextBelow.Text;
            }
            
            set
            {
                this.Controls.SearchTextBelow.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SearchTextBelow control
        /// </summary>
        /// <history>
        /// 	[ruhim] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ISelectObjectDialogControls.SearchTextBelow
        {
            get
            {
                if ((this.cachedSearchTextBelow == null))
                {
                    this.cachedSearchTextBelow = new TextBox(this, SelectObjectDialog.ControlIDs.SearchTextBelow);
                }
                return this.cachedSearchTextBelow;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MatchingObjectsListView control
        /// </summary>
        /// <history>
        /// 	[ruhim] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView ISelectObjectDialogControls.MatchingObjectsListView
        {
            get
            {
                if ((this.cachedMatchingObjectsListView == null))
                {
                    this.cachedMatchingObjectsListView = new ListView(this, SelectObjectDialog.ControlIDs.MatchingObjectsListView);
                }
                return this.cachedMatchingObjectsListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectObjectDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, SelectObjectDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectObjectDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, SelectObjectDialog.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EnterYourSearchTextBelowThisSearchesBothDisplayNameAndPathStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectObjectDialogControls.EnterYourSearchTextBelowThisSearchesBothDisplayNameAndPathStaticControl
        {
            get
            {
                if ((this.cachedEnterYourSearchTextBelowThisSearchesBothDisplayNameAndPathStaticControl == null))
                {
                    this.cachedEnterYourSearchTextBelowThisSearchesBothDisplayNameAndPathStaticControl = new StaticControl(this, SelectObjectDialog.ControlIDs.EnterYourSearchTextBelowThisSearchesBothDisplayNameAndPathStaticControl);
                }
                return this.cachedEnterYourSearchTextBelowThisSearchesBothDisplayNameAndPathStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MatchingObjectsStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectObjectDialogControls.MatchingObjectsStaticControl
        {
            get
            {
                if ((this.cachedMatchingObjectsStaticControl == null))
                {
                    this.cachedMatchingObjectsStaticControl = new StaticControl(this, SelectObjectDialog.ControlIDs.MatchingObjectsStaticControl);
                }
                return this.cachedMatchingObjectsStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[ruhim] 9/20/2006 Created
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
        /// 	[ruhim] 9/20/2006 Created
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
        ///  <param name="app">App owning the dialog.</param>)
        /// <history>
        /// 	[ruhim] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(
                    Strings.DialogTitle,
                    StringMatchSyntax.ExactMatch,
                    WindowClassNames.Dialog,
                    StringMatchSyntax.ExactMatch,
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
                                app.GetIntlStr(Strings.DialogTitle) + "*",
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
                            "BrowseForFolderDialog:: Attempt " + numberOfTries + " of " + MaxTries);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "BrowseForFolderDialog:: Failed to find window with title:  '" +
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
        /// 	[ruhim] 9/20/2006 Created
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
            private const string ResourceDialogTitle = 
                ";Select Object;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.MonitoringObjectChooser;$this.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Display Name column Header
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDisplayNameHeader = 
                ";Display Name;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.MonitoringObjectChooser;nameColumn.Text";

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
            /// Contains resource string for:  EnterYourSearchTextBelowThisSearchesBothDisplayNameAndPath
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEnterYourSearchTextBelowThisSearchesBothDisplayNameAndPath = ";Enter your search text below. This searches both display name and path.;ManagedS" +
                "tring;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.Moni" +
                "toringObjectChooser;searchLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MatchingObjects
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMatchingObjects = ";Matching objects;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpr" +
                "iseManagement.Mom.UI.MonitoringObjectChooser;classesLabel.Text";
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
            /// Caches the translated resource the Display Name column Header
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDisplayNameHeader;
            
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
            /// Caches the translated resource string for:  EnterYourSearchTextBelowThisSearchesBothDisplayNameAndPath
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEnterYourSearchTextBelowThisSearchesBothDisplayNameAndPath;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MatchingObjects
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMatchingObjects;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 9/20/2006 Created
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
            /// Exposes access to the Display Name column Header translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 9/20/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DisplayNameHeader
            {
                get
                {
                    if ((cachedDisplayNameHeader == null))
                    {
                        cachedDisplayNameHeader = CoreManager.MomConsole.GetIntlStr(ResourceDisplayNameHeader);
                    }
                    return cachedDisplayNameHeader;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 9/20/2006 Created
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
            /// 	[ruhim] 9/20/2006 Created
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
            /// Exposes access to the EnterYourSearchTextBelowThisSearchesBothDisplayNameAndPath translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 9/20/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EnterYourSearchTextBelowThisSearchesBothDisplayNameAndPath
            {
                get
                {
                    if ((cachedEnterYourSearchTextBelowThisSearchesBothDisplayNameAndPath == null))
                    {
                        cachedEnterYourSearchTextBelowThisSearchesBothDisplayNameAndPath = CoreManager.MomConsole.GetIntlStr(ResourceEnterYourSearchTextBelowThisSearchesBothDisplayNameAndPath);
                    }
                    return cachedEnterYourSearchTextBelowThisSearchesBothDisplayNameAndPath;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MatchingObjects translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 9/20/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MatchingObjects
            {
                get
                {
                    if ((cachedMatchingObjects == null))
                    {
                        cachedMatchingObjects = CoreManager.MomConsole.GetIntlStr(ResourceMatchingObjects);
                    }
                    return cachedMatchingObjects;
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
        /// 	[ruhim] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for SearchTextBelow
            /// </summary>
            public const string SearchTextBelow = "searchTextBox";
            
            /// <summary>
            /// Control ID for MatchingObjectsListView
            /// </summary>
            public const string MatchingObjectsListView = "mainListView";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for EnterYourSearchTextBelowThisSearchesBothDisplayNameAndPathStaticControl
            /// </summary>
            public const string EnterYourSearchTextBelowThisSearchesBothDisplayNameAndPathStaticControl = "searchLabel";
            
            /// <summary>
            /// Control ID for MatchingObjectsStaticControl
            /// </summary>
            public const string MatchingObjectsStaticControl = "classesLabel";
        }
        #endregion
    }
}
