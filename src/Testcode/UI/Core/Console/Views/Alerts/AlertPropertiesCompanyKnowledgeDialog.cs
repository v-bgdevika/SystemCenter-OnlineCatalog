// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AlertPropertiesCompanyKnowledgeDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[lucyra] 9/18/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.Alerts
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Maui.Core.HtmlControls;
    //using Maui.InternetExplorer;
    
    #region Interface Definition - IAlertPropertiesCompanyKnowledgeDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAlertPropertiesCompanyKnowledgeDialogControls, for AlertPropertiesCompanyKnowledgeDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[lucyra] 9/18/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAlertPropertiesCompanyKnowledgeDialogControls
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
        /// Read-only property to access Tab2TabControl
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TabControl Tab2TabControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EditMonitorButton
        /// </summary>
        Button EditMonitorButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access YouCanEditCompanyKnowledgeByEditingTheKnowledgeForTheSourceOfThisAlertStaticControl
        /// </summary>
        StaticControl YouCanEditCompanyKnowledgeByEditingTheKnowledgeForTheSourceOfThisAlertStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HTMLDoc
        /// </summary>
        HtmlDocument HTMLDoc
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
    /// 	[lucyra] 9/18/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class AlertPropertiesCompanyKnowledgeDialog : Dialog, IAlertPropertiesCompanyKnowledgeDialogControls
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
        /// Cache to hold a reference to Tab2TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab2TabControl;
        
        /// <summary>
        /// Cache to hold a reference to EditMonitorButton of type Button
        /// </summary>
        private Button cachedEditMonitorButton;
        
        /// <summary>
        /// Cache to hold a reference to YouCanEditCompanyKnowledgeByEditingTheKnowledgeForTheSourceOfThisAlertStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedYouCanEditCompanyKnowledgeByEditingTheKnowledgeForTheSourceOfThisAlertStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HTMLDoc of type HTMLDocument
        /// </summary>
        private HtmlDocument cachedHTMLDoc;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of AlertPropertiesCompanyKnowledgeDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[lucyra] 9/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AlertPropertiesCompanyKnowledgeDialog(ConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IAlertPropertiesCompanyKnowledgeDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[lucyra] 9/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAlertPropertiesCompanyKnowledgeDialogControls Controls
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
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertPropertiesCompanyKnowledgeDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, AlertPropertiesCompanyKnowledgeDialog.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertPropertiesCompanyKnowledgeDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, AlertPropertiesCompanyKnowledgeDialog.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertPropertiesCompanyKnowledgeDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, AlertPropertiesCompanyKnowledgeDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertPropertiesCompanyKnowledgeDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AlertPropertiesCompanyKnowledgeDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApplyButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertPropertiesCompanyKnowledgeDialogControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, AlertPropertiesCompanyKnowledgeDialog.ControlIDs.ApplyButton);
                }
                
                return this.cachedApplyButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab2TabControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IAlertPropertiesCompanyKnowledgeDialogControls.Tab2TabControl
        {
            get
            {
                if ((this.cachedTab2TabControl == null))
                {
                    this.cachedTab2TabControl = new TabControl(this, AlertPropertiesCompanyKnowledgeDialog.ControlIDs.Tab2TabControl);
                }
                
                return this.cachedTab2TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EditMonitorButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertPropertiesCompanyKnowledgeDialogControls.EditMonitorButton
        {
            get
            {
                if ((this.cachedEditMonitorButton == null))
                {
                    this.cachedEditMonitorButton = new Button(this, AlertPropertiesCompanyKnowledgeDialog.ControlIDs.EditMonitorButton);
                }
                
                return this.cachedEditMonitorButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the YouCanEditCompanyKnowledgeByEditingTheKnowledgeForTheSourceOfThisAlertStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertPropertiesCompanyKnowledgeDialogControls.YouCanEditCompanyKnowledgeByEditingTheKnowledgeForTheSourceOfThisAlertStaticControl
        {
            get
            {
                if ((this.cachedYouCanEditCompanyKnowledgeByEditingTheKnowledgeForTheSourceOfThisAlertStaticControl == null))
                {
                    this.cachedYouCanEditCompanyKnowledgeByEditingTheKnowledgeForTheSourceOfThisAlertStaticControl = new StaticControl(this, AlertPropertiesCompanyKnowledgeDialog.ControlIDs.YouCanEditCompanyKnowledgeByEditingTheKnowledgeForTheSourceOfThisAlertStaticControl);
                }
                
                return this.cachedYouCanEditCompanyKnowledgeByEditingTheKnowledgeForTheSourceOfThisAlertStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HTMLDoc control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        HtmlDocument IAlertPropertiesCompanyKnowledgeDialogControls.HTMLDoc
        {
            get
            {
                if ((this.cachedHTMLDoc == null))
                {
                    Window wndTemp = this;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 4); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedHTMLDoc = new HtmlDocument(wndTemp);
                }
                
                return this.cachedHTMLDoc;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Next
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/18/2006 Created
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
        /// 	[lucyra] 9/18/2006 Created
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
        /// 	[lucyra] 9/18/2006 Created
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
        /// 	[lucyra] 9/18/2006 Created
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
        /// 	[lucyra] 9/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickApply()
        {
            this.Controls.ApplyButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button EditMonitor
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEditMonitor()
        {
            this.Controls.EditMonitorButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">ConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[lucyra] 9/18/2006 Created
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
                            "AlertPropertiesGeneralDialog:: Attempt " + numberOfTries + " of " + MaxTries);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "AlertPropertiesGeneralDialog:: Failed to find window with title:  '" +
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
        /// 	[lucyra] 9/18/2006 Created
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
            /// Contains resource string for:  Tab2
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTab2 = "Tab2";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EditMonitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEditMonitor = ";Edit Monitor...;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpri" +
                "seManagement.Mom.Internal.UI.Views.SharedResources;EditMonitor";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  YouCanEditCompanyKnowledgeByEditingTheKnowledgeForTheSourceOfThisAlert
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceYouCanEditCompanyKnowledgeByEditingTheKnowledgeForTheSourceOfThisAlert = ";You can edit Company Knowledge by editing the knowledge for the source of this a" +
                "lert;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagemen" +
                "t.Mom.Internal.UI.Views.SharedResources;CompanyKnowledgeCaptionForAuthor";
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
            /// Caches the translated resource string for:  Tab2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EditMonitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEditMonitor;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  YouCanEditCompanyKnowledgeByEditingTheKnowledgeForTheSourceOfThisAlert
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedYouCanEditCompanyKnowledgeByEditingTheKnowledgeForTheSourceOfThisAlert;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/18/2006 Created
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
            /// 	[lucyra] 9/18/2006 Created
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
            /// 	[lucyra] 9/18/2006 Created
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
            /// 	[lucyra] 9/18/2006 Created
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
            /// 	[lucyra] 9/18/2006 Created
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
            /// 	[lucyra] 9/18/2006 Created
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
            /// Exposes access to the Tab2 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/18/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tab2
            {
                get
                {
                    if ((cachedTab2 == null))
                    {
                        cachedTab2 = CoreManager.MomConsole.GetIntlStr(ResourceTab2);
                    }
                    
                    return cachedTab2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EditMonitor translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/18/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EditMonitor
            {
                get
                {
                    if ((cachedEditMonitor == null))
                    {
                        cachedEditMonitor = CoreManager.MomConsole.GetIntlStr(ResourceEditMonitor);
                    }
                    
                    return cachedEditMonitor;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the YouCanEditCompanyKnowledgeByEditingTheKnowledgeForTheSourceOfThisAlert translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/18/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string YouCanEditCompanyKnowledgeByEditingTheKnowledgeForTheSourceOfThisAlert
            {
                get
                {
                    if ((cachedYouCanEditCompanyKnowledgeByEditingTheKnowledgeForTheSourceOfThisAlert == null))
                    {
                        cachedYouCanEditCompanyKnowledgeByEditingTheKnowledgeForTheSourceOfThisAlert = CoreManager.MomConsole.GetIntlStr(ResourceYouCanEditCompanyKnowledgeByEditingTheKnowledgeForTheSourceOfThisAlert);
                    }
                    
                    return cachedYouCanEditCompanyKnowledgeByEditingTheKnowledgeForTheSourceOfThisAlert;
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
        /// 	[lucyra] 9/18/2006 Created
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
            /// Control ID for Tab2TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab2TabControl = "mainTabControl";
            
            /// <summary>
            /// Control ID for EditMonitorButton
            /// </summary>
            public const string EditMonitorButton = "editMonitorButton";
            
            /// <summary>
            /// Control ID for YouCanEditCompanyKnowledgeByEditingTheKnowledgeForTheSourceOfThisAlertStaticControl
            /// </summary>
            public const string YouCanEditCompanyKnowledgeByEditingTheKnowledgeForTheSourceOfThisAlertStaticControl = "companyKnowledgeCaption";
        }
        #endregion
    }
}
