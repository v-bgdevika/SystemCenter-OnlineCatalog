// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AlertPropertiesHistoryDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[lucyra] 7/21/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.Alerts
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IAlertPropertiesHistoryDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAlertPropertiesHistoryDialogControls, for AlertPropertiesHistoryDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[lucyra] 7/21/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAlertPropertiesHistoryDialogControls
    {
        /// <summary>
        /// Read-only property to access NextButton
        /// </summary>
        Button NextButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PreviousButton
        /// </summary>
        Button PreviousButton
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
        
        /// <summary>
        /// Read-only property to access ApplyButton
        /// </summary>
        Button ApplyButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Tab3TabControl
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TabControl Tab3TabControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access YouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSavedStaticControl
        /// </summary>
        StaticControl YouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSavedStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HistoryCommentText
        /// </summary>
        TextBox HistoryCommentText
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AddHistoryCommentStaticControl
        /// </summary>
        StaticControl AddHistoryCommentStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AlertHistoryStaticControl
        /// </summary>
        StaticControl AlertHistoryStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HistoryListView
        /// </summary>
        ListView HistoryListView
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
    /// 	[lucyra] 7/21/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class AlertPropertiesHistoryDialog : Dialog, IAlertPropertiesHistoryDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to NextButton of type Button
        /// </summary>
        private Button cachedNextButton;
        
        /// <summary>
        /// Cache to hold a reference to PreviousButton of type Button
        /// </summary>
        private Button cachedPreviousButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to ApplyButton of type Button
        /// </summary>
        private Button cachedApplyButton;
        
        /// <summary>
        /// Cache to hold a reference to Tab3TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab3TabControl;
        
        /// <summary>
        /// Cache to hold a reference to YouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSavedStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedYouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSavedStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HistoryCommentText of type TextBox
        /// </summary>
        private TextBox cachedHistoryCommentText;
        
        /// <summary>
        /// Cache to hold a reference to AddHistoryCommentStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAddHistoryCommentStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AlertHistoryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAlertHistoryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HistoryListView of type ListView
        /// </summary>
        private ListView cachedHistoryListView;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of AlertPropertiesHistoryDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[lucyra] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AlertPropertiesHistoryDialog(ConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IAlertPropertiesHistoryDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[lucyra] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAlertPropertiesHistoryDialogControls Controls
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
        ///  Routine to set/get the text in control HistoryCommentText
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string HistoryCommentText
        {
            get
            {
                return this.Controls.HistoryCommentText.Text;
            }
            
            set
            {
                this.Controls.HistoryCommentText.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertPropertiesHistoryDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, AlertPropertiesHistoryDialog.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertPropertiesHistoryDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, AlertPropertiesHistoryDialog.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertPropertiesHistoryDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, AlertPropertiesHistoryDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertPropertiesHistoryDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AlertPropertiesHistoryDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApplyButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertPropertiesHistoryDialogControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, AlertPropertiesHistoryDialog.ControlIDs.ApplyButton);
                }
                
                return this.cachedApplyButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab3TabControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IAlertPropertiesHistoryDialogControls.Tab3TabControl
        {
            get
            {
                if ((this.cachedTab3TabControl == null))
                {
                    this.cachedTab3TabControl = new TabControl(this, AlertPropertiesHistoryDialog.ControlIDs.Tab3TabControl);
                }
                
                return this.cachedTab3TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the YouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSavedStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertPropertiesHistoryDialogControls.YouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSavedStaticControl
        {
            get
            {
                if ((this.cachedYouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSavedStaticControl == null))
                {
                    this.cachedYouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSavedStaticControl = new StaticControl(this, AlertPropertiesHistoryDialog.ControlIDs.YouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSavedStaticControl);
                }
                
                return this.cachedYouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSavedStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HistoryCommentText control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAlertPropertiesHistoryDialogControls.HistoryCommentText
        {
            get
            {
                if ((this.cachedHistoryCommentText == null))
                {
                    this.cachedHistoryCommentText = new TextBox(this, AlertPropertiesHistoryDialog.ControlIDs.HistoryCommentText);
                }
                
                return this.cachedHistoryCommentText;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddHistoryCommentStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertPropertiesHistoryDialogControls.AddHistoryCommentStaticControl
        {
            get
            {
                if ((this.cachedAddHistoryCommentStaticControl == null))
                {
                    this.cachedAddHistoryCommentStaticControl = new StaticControl(this, AlertPropertiesHistoryDialog.ControlIDs.AddHistoryCommentStaticControl);
                }
                
                return this.cachedAddHistoryCommentStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertHistoryStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertPropertiesHistoryDialogControls.AlertHistoryStaticControl
        {
            get
            {
                if ((this.cachedAlertHistoryStaticControl == null))
                {
                    this.cachedAlertHistoryStaticControl = new StaticControl(this, AlertPropertiesHistoryDialog.ControlIDs.AlertHistoryStaticControl);
                }
                
                return this.cachedAlertHistoryStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HistoryListView control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IAlertPropertiesHistoryDialogControls.HistoryListView
        {
            get
            {
                if ((this.cachedHistoryListView == null))
                {
                    this.cachedHistoryListView = new ListView(this, AlertPropertiesHistoryDialog.ControlIDs.HistoryListView);
                }
                
                return this.cachedHistoryListView;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Next
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNext()
        {
            this.Controls.NextButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickPrevious()
        {
            this.Controls.PreviousButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/21/2006 Created
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
        /// 	[lucyra] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Apply
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickApply()
        {
            this.Controls.ApplyButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">ConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[lucyra] 7/21/2006 Created
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
                            "AlertPropertiesHistoryDialog:: Attempt " + numberOfTries + " of " + MaxTries);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "AlertPropertiesHistoryDialog:: Failed to find window with title:  '" +
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
        /// 	[lucyra] 7/21/2006 Created
        ///     [a-joelj] 19MAR09 Added DialogTitle resource
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
                ";Alert Properties;" +
                "ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertResources;" +
                "BulkAlertPropertiesTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext = ";&Next;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManageme" +
                "nt.Mom.UI.AlertPropertyDialog;nextButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrevious = ";&Previous;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMana" +
                "gement.Mom.UI.AlertPropertyDialog;prevButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.Tr" +
                "anslucentColorPicker;buttonOk.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Apply
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceApply = ";&Apply;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.PropertyDialogForm;buttonApply.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Tab3
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTab3 = "Tab3";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  YouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSaved
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceYouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSaved = ";You can add a comment that will be added to the alert history when the alert is " +
                "saved;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManageme" +
                "nt.Mom.UI.AlertPropertyDialog;historyCommentCaptionLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AddHistoryComment
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAddHistoryComment = ";Add History Comment;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Ente" +
                "rpriseManagement.Mom.UI.AlertPropertyDialog;historyCommentLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertHistory
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertHistory = ";Alert History;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterprise" +
                "Management.Mom.UI.AlertPropertyDialog;historyHeaderLabel.Text";
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
            /// Caches the translated resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNext;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPrevious;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Apply
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedApply;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Tab3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab3;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  YouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSaved
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedYouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSaved;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AddHistoryComment
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAddHistoryComment;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertHistory
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertHistory;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/21/2006 Created
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
            /// Exposes access to the Next translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Next
            {
                get
                {
                    if ((cachedNext == null))
                    {
                        cachedNext = CoreManager.MomConsole.GetIntlStr(ResourceNext);
                    }
                    
                    return cachedNext;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Previous translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Previous
            {
                get
                {
                    if ((cachedPrevious == null))
                    {
                        cachedPrevious = CoreManager.MomConsole.GetIntlStr(ResourcePrevious);
                    }
                    
                    return cachedPrevious;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/21/2006 Created
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
            /// 	[lucyra] 7/21/2006 Created
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
            /// Exposes access to the Apply translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Apply
            {
                get
                {
                    if ((cachedApply == null))
                    {
                        cachedApply = CoreManager.MomConsole.GetIntlStr(ResourceApply);
                    }
                    
                    return cachedApply;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Tab3 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tab3
            {
                get
                {
                    if ((cachedTab3 == null))
                    {
                        cachedTab3 = CoreManager.MomConsole.GetIntlStr(ResourceTab3);
                    }
                    
                    return cachedTab3;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the YouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSaved translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string YouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSaved
            {
                get
                {
                    if ((cachedYouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSaved == null))
                    {
                        cachedYouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSaved = CoreManager.MomConsole.GetIntlStr(ResourceYouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSaved);
                    }
                    
                    return cachedYouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSaved;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AddHistoryComment translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AddHistoryComment
            {
                get
                {
                    if ((cachedAddHistoryComment == null))
                    {
                        cachedAddHistoryComment = CoreManager.MomConsole.GetIntlStr(ResourceAddHistoryComment);
                    }
                    
                    return cachedAddHistoryComment;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertHistory translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertHistory
            {
                get
                {
                    if ((cachedAlertHistory == null))
                    {
                        cachedAlertHistory = CoreManager.MomConsole.GetIntlStr(ResourceAlertHistory);
                    }
                    
                    return cachedAlertHistory;
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
        /// 	[lucyra] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for NextButton
            /// </summary>
            public const string NextButton = "nextButton";
            
            /// <summary>
            /// Control ID for PreviousButton
            /// </summary>
            public const string PreviousButton = "prevButton";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for ApplyButton
            /// </summary>
            public const string ApplyButton = "applyButton";
            
            /// <summary>
            /// Control ID for Tab3TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab3TabControl = "mainTabControl";
            
            /// <summary>
            /// Control ID for YouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSavedStaticControl
            /// </summary>
            public const string YouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSavedStaticControl = "historyCommentCaptionLabel";
            
            /// <summary>
            /// Control ID for HistoryCommentText
            /// </summary>
            public const string HistoryCommentText = "historyCommentTextbox";
            
            /// <summary>
            /// Control ID for AddHistoryCommentStaticControl
            /// </summary>
            public const string AddHistoryCommentStaticControl = "historyCommentLabel";
            
            /// <summary>
            /// Control ID for AlertHistoryStaticControl
            /// </summary>
            public const string AlertHistoryStaticControl = "historyHeaderLabel";
            
            /// <summary>
            /// Control ID for HistoryListView
            /// </summary>
            public const string HistoryListView = "historyListView";
        }
        #endregion
    }
}
