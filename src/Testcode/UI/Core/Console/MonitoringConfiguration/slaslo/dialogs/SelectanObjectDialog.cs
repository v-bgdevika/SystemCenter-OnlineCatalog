// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SelectanObjectDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	Proxy class that represents the Select a Object to Scope Dialog
// </project>
// <summary>
// 	Proxy class that represents the Select a Object to Scope Dialog
// </summary>
// <history>
// 	[dialac] 10/4/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.SLASLO.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - ISelectanObjectDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISelectanObjectDialogControls, for SelectanObjectDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[dialac] 10/4/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISelectanObjectDialogControls
    {
        /// <summary>
        /// Read-only property to access ListView1
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        ListView ListView1
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StaticControl0
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        StaticControl StaticControl0
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
        /// Read-only property to access LookForTextBox
        /// </summary>
        TextBox LookForTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LookForStaticControl
        /// </summary>
        StaticControl LookForStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EnterSearchKeywordsFromTheNameOfTheGroupThatContainsObjectFromTheClassYouWantToTargetAndClickSearchS
        /// </summary>
        StaticControl EnterSearchKeywordsFromTheNameOfTheGroupThatContainsObjectFromTheClassYouWantToTargetAndClickSearchS
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SearchButton
        /// </summary>
        Button SearchButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CancelButton2
        /// </summary>
        Button CancelButton2
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
    /// 	[dialac] 10/4/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SelectanObjectDialog : Dialog, ISelectanObjectDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ListView1 of type ListView
        /// </summary>
        private ListView cachedListView1;
        
        /// <summary>
        /// Cache to hold a reference to StaticControl0 of type StaticControl
        /// </summary>
        private StaticControl cachedStaticControl0;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to LookForTextBox of type TextBox
        /// </summary>
        private TextBox cachedLookForTextBox;
        
        /// <summary>
        /// Cache to hold a reference to LookForStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedLookForStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to EnterSearchKeywordsFromTheNameOfTheGroupThatContainsObjectFromTheClassYouWantToTargetAndClickSearchS of type StaticControl
        /// </summary>
        private StaticControl cachedEnterSearchKeywordsFromTheNameOfTheGroupThatContainsObjectFromTheClassYouWantToTargetAndClickSearchS;
        
        /// <summary>
        /// Cache to hold a reference to SearchButton of type Button
        /// </summary>
        private Button cachedSearchButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton2 of type Button
        /// </summary>
        private Button cachedCancelButton2;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of SelectanObjectDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[dialac] 10/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SelectanObjectDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region ISelectanObjectDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[dialac] 10/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISelectanObjectDialogControls Controls
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
        ///  Routine to set/get the text in control LookFor
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 10/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string LookForText
        {
            get
            {
                return this.Controls.LookForTextBox.Text;
            }
            
            set
            {
                this.Controls.LookForTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ListView1 control
        /// </summary>
        /// <history>
        /// 	[dialac] 10/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView ISelectanObjectDialogControls.ListView1
        {
            get
            {
                if ((this.cachedListView1 == null))
                {
                    this.cachedListView1 = new ListView(this, new QID(";[UIA]AutomationId ='" + SelectanObjectDialog.ControlIDs.ListView1 + "'"));
                }
                
                return this.cachedListView1;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StaticControl0 control
        /// </summary>
        /// <history>
        /// 	[dialac] 10/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectanObjectDialogControls.StaticControl0
        {
            get
            {
                if ((this.cachedStaticControl0 == null))
                {
                    this.cachedStaticControl0 = new StaticControl(this, SelectanObjectDialog.ControlIDs.StaticControl0);
                }
                
                return this.cachedStaticControl0;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 10/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectanObjectDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, SelectanObjectDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 10/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectanObjectDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, SelectanObjectDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LookForTextBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 10/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ISelectanObjectDialogControls.LookForTextBox
        {
            get
            {
                if ((this.cachedLookForTextBox == null))
                {
                    this.cachedLookForTextBox = new TextBox(this, SelectanObjectDialog.ControlIDs.LookForTextBox);
                }
                
                return this.cachedLookForTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LookForStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 10/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectanObjectDialogControls.LookForStaticControl
        {
            get
            {
                if ((this.cachedLookForStaticControl == null))
                {
                    this.cachedLookForStaticControl = new StaticControl(this, SelectanObjectDialog.ControlIDs.LookForStaticControl);
                }
                
                return this.cachedLookForStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EnterSearchKeywordsFromTheNameOfTheGroupThatContainsObjectFromTheClassYouWantToTargetAndClickSearchS control
        /// </summary>
        /// <history>
        /// 	[dialac] 10/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectanObjectDialogControls.EnterSearchKeywordsFromTheNameOfTheGroupThatContainsObjectFromTheClassYouWantToTargetAndClickSearchS
        {
            get
            {
                if ((this.cachedEnterSearchKeywordsFromTheNameOfTheGroupThatContainsObjectFromTheClassYouWantToTargetAndClickSearchS == null))
                {
                    this.cachedEnterSearchKeywordsFromTheNameOfTheGroupThatContainsObjectFromTheClassYouWantToTargetAndClickSearchS = new StaticControl(this, SelectanObjectDialog.ControlIDs.EnterSearchKeywordsFromTheNameOfTheGroupThatContainsObjectFromTheClassYouWantToTargetAndClickSearchS);
                }
                
                return this.cachedEnterSearchKeywordsFromTheNameOfTheGroupThatContainsObjectFromTheClassYouWantToTargetAndClickSearchS;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SearchButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 10/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectanObjectDialogControls.SearchButton
        {
            get
            {
                if ((this.cachedSearchButton == null))
                {
                    this.cachedSearchButton = new Button(this, SelectanObjectDialog.ControlIDs.SearchButton);
                }
                
                return this.cachedSearchButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton2 control
        /// </summary>
        /// <history>
        /// 	[dialac] 10/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectanObjectDialogControls.CancelButton2
        {
            get
            {
                if ((this.cachedCancelButton2 == null))
                {
                    this.cachedCancelButton2 = new Button(this, SelectanObjectDialog.ControlIDs.CancelButton2);
                }
                
                return this.cachedCancelButton2;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[dialac] 10/4/2008 Created
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
        /// 	[dialac] 10/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Search
        /// </summary>
        /// <history>
        /// 	[dialac] 10/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSearch()
        {
            this.Controls.SearchButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel2
        /// </summary>
        /// <history>
        /// 	[dialac] 10/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel2()
        {
            this.Controls.CancelButton2.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">MomConsoleApp owning the dialog.</param>
        /// <history>
        /// 	[dialac] 10/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
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
                        tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.WildCard);

                        // Wait for the window to become ready
                        UISynchronization.WaitForUIObjectReady(tempWindow, Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException )
                    {
                        // log the unsuccessful attempt

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
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
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[dialac] 10/4/2008 Created
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
            private const string ResourceDialogTitle = ";Select an Object;" + 
                "ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;" + 
                "Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Sla.SlaScopePickerDialog;$this.Text";

            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";&Cancel;ManagedString;Corgent.Diagramming.Dom.dll;Corgent.Diagramming.Dom.Diagra" +
                "mTemplateProperties;cancelButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";&OK;ManagedString;Corgent.Diagramming.Dom.dll;Corgent.Diagramming.Dom.DiagramTem" +
                "plateProperties;okButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  LookFor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLookFor = ";Look for:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsof" +
                "t.EnterpriseManagement.Internal.UI.Authoring.Pages.Sla.ScopeFilterControl;label2" +
                ".Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EnterSearchKeywordsFromTheNameOfTheGroupThatContainsObjectFromTheClassYouWantToTargetAndClickSearch
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEnterSearchKeywordsFromTheNameOfTheGroupThatContainsObjectFromTheClassYouWantToTargetAndClickSearch = @";Enter search keywords from the name of the group that contains object from the class you want to target, and click search.;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Sla.ScopeFilterControl;label1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Search
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSearch = ";&Search;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft." +
                "EnterpriseManagement.Internal.UI.Authoring.Pages.GroupSearchCriteria;searchButto" +
                "n.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel2 = ";C&ancel;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement" +
                ".Mom.Internal.UI.AsyncChooserDialogItemProvider;cancelButton.Text";
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
            /// Caches the translated resource string for:  LookFor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLookFor;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EnterSearchKeywordsFromTheNameOfTheGroupThatContainsObjectFromTheClassYouWantToTargetAndClickSearch
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEnterSearchKeywordsFromTheNameOfTheGroupThatContainsObjectFromTheClassYouWantToTargetAndClickSearch;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Search
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSearch;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel2;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 10/4/2008 Created
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
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 10/4/2008 Created
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
            /// 	[dialac] 10/4/2008 Created
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
            /// Exposes access to the LookFor translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 10/4/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LookFor
            {
                get
                {
                    if ((cachedLookFor == null))
                    {
                        cachedLookFor = CoreManager.MomConsole.GetIntlStr(ResourceLookFor);
                    }
                    
                    return cachedLookFor;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EnterSearchKeywordsFromTheNameOfTheGroupThatContainsObjectFromTheClassYouWantToTargetAndClickSearch translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 10/4/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EnterSearchKeywordsFromTheNameOfTheGroupThatContainsObjectFromTheClassYouWantToTargetAndClickSearch
            {
                get
                {
                    if ((cachedEnterSearchKeywordsFromTheNameOfTheGroupThatContainsObjectFromTheClassYouWantToTargetAndClickSearch == null))
                    {
                        cachedEnterSearchKeywordsFromTheNameOfTheGroupThatContainsObjectFromTheClassYouWantToTargetAndClickSearch = CoreManager.MomConsole.GetIntlStr(ResourceEnterSearchKeywordsFromTheNameOfTheGroupThatContainsObjectFromTheClassYouWantToTargetAndClickSearch);
                    }
                    
                    return cachedEnterSearchKeywordsFromTheNameOfTheGroupThatContainsObjectFromTheClassYouWantToTargetAndClickSearch;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Search translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 10/4/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Search
            {
                get
                {
                    if ((cachedSearch == null))
                    {
                        cachedSearch = CoreManager.MomConsole.GetIntlStr(ResourceSearch);
                    }
                    
                    return cachedSearch;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel2 translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 10/4/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Cancel2
            {
                get
                {
                    if ((cachedCancel2 == null))
                    {
                        cachedCancel2 = CoreManager.MomConsole.GetIntlStr(ResourceCancel2);
                    }
                    
                    return cachedCancel2;
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
        /// 	[dialac] 10/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ListView1
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string ListView1 = "availableItemsListView";
            
            /// <summary>
            /// Control ID for StaticControl0
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string StaticControl0 = "availableItemsLabel";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelBtn";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "buttonOK";
            
            /// <summary>
            /// Control ID for LookForTextBox
            /// </summary>
            public const string LookForTextBox = "filterEntry";
            
            /// <summary>
            /// Control ID for LookForStaticControl
            /// </summary>
            public const string LookForStaticControl = "label2";
            
            /// <summary>
            /// Control ID for EnterSearchKeywordsFromTheNameOfTheGroupThatContainsObjectFromTheClassYouWantToTargetAndClickSearchS
            /// </summary>
            public const string EnterSearchKeywordsFromTheNameOfTheGroupThatContainsObjectFromTheClassYouWantToTargetAndClickSearchS = "label1";
            
            /// <summary>
            /// Control ID for SearchButton
            /// </summary>
            public const string SearchButton = "searchButton";
            
            /// <summary>
            /// Control ID for CancelButton2
            /// </summary>
            public const string CancelButton2 = "cancelButton";
        }
        #endregion
    }
}
