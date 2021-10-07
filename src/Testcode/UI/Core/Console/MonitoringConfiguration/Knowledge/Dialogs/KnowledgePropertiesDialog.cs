// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="KnowledgePropertiesDialog.cs">
//   Copyright (c) Microsoft Corporation 2009
// </copyright>
//
// <summary>
//   KnowledgePropertiesDialog support
// </summary>
// <history>
//   [v-waltli] 5/26/2009 Created. Added resource string for Confirm Dialog
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Knowledge.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Maui.Core.HtmlControls;
    using mshtml;
    using System;
    using System.Reflection;
    using Microsoft.EnterpriseManagement.Configuration;
    using Mom.Test.UI.Core.Common;

    #region Interface Definition - IKnowledgePropertiesDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IKnowledgePropertiesDialogControls, for KnowledgePropertiesDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-waltli] 5/26/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IKnowledgePropertiesDialogControls
    {

        /// <summary>
        /// Read-only property to access CloseButton
        /// </summary>
        Button CloseButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access MainTabControl
        /// </summary>
        TabControl MainTabControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access CompanyKnowledgeTab
        /// </summary>
        TabControlTab CompanyKnowledgeTab
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ProductKnowledgeTab
        /// </summary>
        TabControlTab ProductKnowledgeTab
        {
            get;
        }

        /// <summary>
        /// Read-only property to access SaveButton
        /// </summary>
        Button SaveButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access DefaultManagementPack
        /// </summary>
        ComboBox DefaultManagementPack
        {
            get;
        }

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
        /// Read-only property to access CompanyKnowledgeArticleHTMLDoc
        /// </summary>
        HtmlDocument CompanyKnowledgeArticleHTMLDoc
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ProductKnowledgeArticleHTMLDoc
        /// </summary>
        HtmlDocument ProductKnowledgeArticleHTMLDoc
        {
            get;
        }

        /// <summary>
        /// Read-only property to access EditButton
        /// </summary>
        Button EditButton
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
    }
    #endregion

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Knowledge Properties Dialog
    /// </summary>
    /// <history>
    ///   [v-waltli] 5/26/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class KnowledgePropertiesDialog : Dialog, IKnowledgePropertiesDialogControls
    {
        #region Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion

        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to CloseButton of type Button
        /// </summary>
        private Button cachedCloseButton;

        /// <summary>
        /// Cache to hold a reference to MainTabControl of type TabControl
        /// </summary>
        private TabControl cachedMainTabControl;

        /// <summary>
        /// Cache to hold a reference to CompanyKnowledgeTab of type TabControlTab
        /// </summary>
        private TabControlTab cachedCompanyKnowledgeTab;

        /// <summary>
        /// Cache to hold a reference to ProductKnowledgeTab of type TabControlTab
        /// </summary>
        private TabControlTab cachedProductKnowledgeTab;

        /// <summary>
        /// Cache to hold a reference to SaveButton of type Button
        /// </summary>
        private Button cachedSaveButton;

        ///// <summary>
        ///// Cache to hold a reference to NewButton of type Button
        ///// </summary>
        //private Button cachedNewButton;

        /// <summary>
        /// Cache to hold a reference to DefaultManagementPack of type ComboBox
        /// </summary>
        private ComboBox cachedDefaultManagementPack;

        /// <summary>
        /// Cache to hold a reference to ListView1 of type ListView
        /// </summary>
        private ListView cachedListView1;

        /// <summary>
        /// Cache to hold a reference to ProductKnowledgeArticleHTMLDoc of type HtmlDocument
        /// </summary>
        private HtmlDocument cachedProductKnowledgeArticleHTMLDoc;

        /// <summary>
        /// Cache to hold a reference to CompanyKnowledgeArticleHTMLDoc of type HtmlDocument
        /// </summary>
        private HtmlDocument cachedCompanyKnowledgeArticleHTMLDoc;

        /// <summary>
        /// Cache to hold a reference to EditButton of type Button
        /// </summary>
        private Button cachedEditButton;

        /// <summary>
        /// Cache to hold a reference to ApplyButton of type Button
        /// </summary>
        private Button cachedApplyButton;

        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;

        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;

        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of KnowledgePropertiesDialog of type MomConsoleApp
        /// </param>
        /// <history>
        ///   [v-waltli] 5/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public KnowledgePropertiesDialog(MomConsoleApp app) :
            base(app, Init(app))
        {

        }
        #endregion

        #region IKnowledgePropertiesDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [v-waltli] 5/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IKnowledgePropertiesDialogControls Controls
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
        ///  Routine to set/get the text in control DefaultManagementPack
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-waltli] 5/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DefaultManagementPackText
        {
            get
            {
                return this.Controls.DefaultManagementPack.Text;
            }

            set
            {
                this.Controls.DefaultManagementPack.SelectByText(value, true);
            }
        }
        #endregion

        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CloseButton control
        /// </summary>
        /// <history>
        ///   [v-waltli] 5/26/2009 Created
        ///     [a-joelj]   09OCT09 Maui 2.0 Required Change: Calling the Button constructor with a QID.
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IKnowledgePropertiesDialogControls.CloseButton
        {
            get
            {
                if ((this.cachedCloseButton == null))
                {
                    // [a-joelj] - Maui 2.0 Required Change: Calling the button constructor with 'this' and the ControlID 
                    // is not returning the correct Button. Switching over to the UIA tree and using a QID with the AutomationId to
                    // get the correct button.
                    
                    QID queryId = new QID(";[UIA]AutomationId='" + KnowledgePropertiesDialog.ControlIDs.CloseButton + "' && Role='push button'");
                    this.cachedCloseButton = new Button(this, queryId, Constants.DefaultContextMenuTimeout);
                }

                return this.cachedCloseButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MainTabControl control
        /// </summary>
        /// <history>
        ///   [v-waltli] 5/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IKnowledgePropertiesDialogControls.MainTabControl
        {
            get
            {
                if ((this.cachedMainTabControl == null))
                {
                    this.cachedMainTabControl = new TabControl(this, KnowledgePropertiesDialog.ControlIDs.MainTabControl);
                }

                return this.cachedMainTabControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SaveButton control
        /// </summary>
        /// <history>
        ///   [v-waltli] 5/26/2009 Created
        ///     [a-joelj]   09OCT09 Maui 2.0 Required Change: Calling the Button constructor with a QID.
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IKnowledgePropertiesDialogControls.SaveButton
        {
            get
            {
                if ((this.cachedSaveButton == null))
                {
                    // [a-joelj] - Maui 2.0 Required Change: Calling the button constructor with 'this' and the ControlID 
                    // is not returning the correct Button. Switching over to the UIA tree and using a QID with the AutomationId to
                    // get the correct button.

                    QID queryId = new QID(";[UIA]AutomationId='" + KnowledgePropertiesDialog.ControlIDs.SaveButton + "' && Role='push button'");
                    this.cachedSaveButton = new Button(this, queryId, Constants.DefaultContextMenuTimeout);
                }

                return this.cachedSaveButton;
            }
        }

        ///// -----------------------------------------------------------------------------
        ///// <summary>
        /////  Exposes access to the NewButton control
        ///// </summary>
        ///// <history>
        /////   [v-waltli] 5/26/2009 Created
        ///// </history>
        ///// -----------------------------------------------------------------------------
        //Button IKnowledgePropertiesDialogControls.NewButton
        //{
        //    get
        //    {
        //        if ((this.cachedNewButton == null))
        //        {
        //            this.cachedNewButton = new Button(this, KnowledgePropertiesDialog.Strings.New);
        //        }

        //        return this.cachedNewButton;
        //    }
        //}

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DefaultManagementPack control
        /// </summary>
        /// <history>
        ///   [v-waltli] 5/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IKnowledgePropertiesDialogControls.DefaultManagementPack
        {
            get
            {
                if ((this.cachedDefaultManagementPack == null))
                {
                    this.cachedDefaultManagementPack = new ComboBox(this, KnowledgePropertiesDialog.ControlIDs.DefaultManagementPack);
                }

                return this.cachedDefaultManagementPack;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ListView1 control
        /// </summary>
        /// <history>
        ///   [v-waltli] 5/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IKnowledgePropertiesDialogControls.ListView1
        {
            get
            {
                if ((this.cachedListView1 == null))
                {
                    this.cachedListView1 = new ListView(this, KnowledgePropertiesDialog.ControlIDs.ListView1);
                }

                return this.cachedListView1;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CompanyKnowledgeTab control
        /// </summary>
        /// <history>
        ///   [v-waltli] 5/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControlTab IKnowledgePropertiesDialogControls.CompanyKnowledgeTab
        {
            get
            {
                if (this.cachedCompanyKnowledgeTab == null)
                {
                    this.cachedCompanyKnowledgeTab = new TabControlTab(this.Controls.MainTabControl, KnowledgePropertiesDialog.Strings.CompanyKnowledgeTabTitle);
                }
                return this.cachedCompanyKnowledgeTab;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ProductKnowledgeTab control
        /// </summary>
        /// <history>
        ///   [v-waltli] 5/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControlTab IKnowledgePropertiesDialogControls.ProductKnowledgeTab
        {
            get
            {
                if (this.cachedProductKnowledgeTab == null)
                {
                    this.cachedProductKnowledgeTab = new TabControlTab(this.Controls.MainTabControl, KnowledgePropertiesDialog.Strings.ProductKnowledgeTabTitle);
                }
                return this.cachedProductKnowledgeTab;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ProductKnowledgeArticleHTMLDoc control
        /// </summary>
        /// <history>
        ///   [v-waltli] 5/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        HtmlDocument IKnowledgePropertiesDialogControls.ProductKnowledgeArticleHTMLDoc
        {
            get
            {
                if (this.cachedProductKnowledgeArticleHTMLDoc == null)
                {
                    Window wndTemp = this.Controls.MainTabControl;
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; i < this.Controls.ProductKnowledgeTab.Index; i++)
                    {
                        Mom.Test.UI.Core.Common.Utilities.LogMessage("Current Tab caption: " + wndTemp.Caption);
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    Mom.Test.UI.Core.Common.Utilities.LogMessage("Captured tab with caption: " + wndTemp.Caption);

                    try
                    {
                        // [a-joelj] - Maui 2.0 Required Change: Maui 1.0 would automatically replace an empty 
                        // string "" with a WildCard character "*".  Now we must explicitly use a wildcare char
                        // to do a WildCard match so we will always get this window
                        wndTemp = new Window(
                                    "*",
                                    StringMatchSyntax.WildCard,
                                    WindowClassNames.InternetExplorerServer,
                                    StringMatchSyntax.ExactMatch,
                                    wndTemp,
                                    Common.Constants.OneSecond * 30);
                    }
                    catch (Maui.Core.Window.Exceptions.WindowNotFoundException e)
                    {
                        throw new Maui.Core.HtmlControls.HtmlControl.Exceptions.ControlNotFoundException("The control didn't appear in the UI: ", e);
                    }
                    this.cachedProductKnowledgeArticleHTMLDoc = new HtmlDocument(wndTemp);

                }
                return this.cachedProductKnowledgeArticleHTMLDoc;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CompanyKnowledgeArticleHTMLDoc control
        /// </summary>
        /// <history>
        ///   [v-waltli] 5/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        HtmlDocument IKnowledgePropertiesDialogControls.CompanyKnowledgeArticleHTMLDoc
        {
            get
            {
                if (this.cachedCompanyKnowledgeArticleHTMLDoc == null)
                {
                    Window wndTemp = this.Controls.MainTabControl;
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; i < this.Controls.CompanyKnowledgeTab.Index; i++)
                    {
                        Mom.Test.UI.Core.Common.Utilities.LogMessage("Current Tab caption: " + wndTemp.Caption);
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    Mom.Test.UI.Core.Common.Utilities.LogMessage("Captured tab with caption: " + wndTemp.Caption);

                    try
                    {
                        // [a-joelj] - Maui 2.0 Required Change: Maui 1.0 would automatically replace an empty 
                        // string "" with a WildCard character "*".  Now we must explicitly use a wildcare char
                        // to do a WildCard match so we will always get this window
                        wndTemp = new Window(
                                    "*",
                                    StringMatchSyntax.WildCard,
                                    WindowClassNames.InternetExplorerServer,
                                    StringMatchSyntax.ExactMatch,
                                    wndTemp,
                                    Common.Constants.OneSecond * 30);
                    }
                    catch (Maui.Core.Window.Exceptions.WindowNotFoundException e)
                    {
                        throw new Maui.Core.HtmlControls.HtmlControl.Exceptions.ControlNotFoundException("The control didn't appear in the UI: ", e);
                    }

                    this.cachedCompanyKnowledgeArticleHTMLDoc = new HtmlDocument(wndTemp);
                }
                return this.cachedCompanyKnowledgeArticleHTMLDoc;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EditButton control
        /// </summary>
        /// <history>
        ///   [v-waltli] 5/26/2009 Created
        ///     [a-joelj]   09OCT09 Maui 2.0 Required Change: Calling the Button constructor with a QID.
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IKnowledgePropertiesDialogControls.EditButton
        {
            get
            {
                if ((this.cachedEditButton == null))
                {
                    // [a-joelj] - Maui 2.0 Required Change: Calling the button constructor with 'this' and the ControlID 
                    // is not returning the correct Button. Switching over to the UIA tree and using a QID with the AutomationId to
                    // get the correct button.
                    
                    QID queryId = new QID(";[UIA]AutomationId='" + KnowledgePropertiesDialog.ControlIDs.EditButton + "' && Role='push button'");
                    this.cachedEditButton = new Button(this, queryId, Constants.DefaultContextMenuTimeout);
                }

                return this.cachedEditButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApplyButton control
        /// </summary>
        /// <history>
        ///   [v-waltli] 5/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IKnowledgePropertiesDialogControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, KnowledgePropertiesDialog.ControlIDs.ApplyButton);
                }

                return this.cachedApplyButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        ///   [v-waltli] 5/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IKnowledgePropertiesDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, KnowledgePropertiesDialog.ControlIDs.CancelButton);
                }

                return this.cachedCancelButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        ///   [v-waltli] 5/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IKnowledgePropertiesDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, KnowledgePropertiesDialog.ControlIDs.OKButton);
                }

                return this.cachedOKButton;
            }
        }

        #endregion

        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Close
        /// </summary>
        /// <history>
        ///   [v-waltli] 5/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickClose()
        {
            this.Controls.CloseButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Save
        /// </summary>
        /// <history>
        ///   [v-waltli] 5/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSave()
        {
            this.Controls.SaveButton.Click();
        }

        ///// -----------------------------------------------------------------------------
        ///// <summary>
        /////  Routine to click on button New
        ///// </summary>
        ///// <history>
        /////   [v-waltli] 5/26/2009 Created
        ///// </history>
        ///// -----------------------------------------------------------------------------
        //public virtual void ClickNew()
        //{
        //    this.Controls.NewButton.Click();
        //}

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Edit
        /// </summary>
        /// <history>
        ///   [v-waltli] 5/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEdit()
        {
            this.Controls.EditButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Apply
        /// </summary>
        /// <history>
        ///   [v-waltli] 5/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickApply()
        {
            this.Controls.ApplyButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        ///   [v-waltli] 5/26/2009 Created
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
        ///   [v-waltli] 5/26/2009 Created
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
        /// <param name="app">MomConsoleApp owning the dialog.</param>
        /// <history>
        ///   [v-waltli] 5/26/2009 Created
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
                        //UISynchronization.WaitForUIObjectReady(tempWindow, Timeout);
                        tempWindow.ScreenElement.WaitForReady();
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Utilities.LogMessage("Init:: window with title " + Strings.DialogTitle + " is not found. Current attempt: " + numberOfTries);
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
        /// Method to return translated resource string for Knowledge Properties Dialog
        /// </summary>
        /// <history>
        ///   [v-waltli] 5/26/2009 Created. Added resource string for Confirm Dialog
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
                ";Properties;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.AuthoringDialog;$this.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Close
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceClose = ";Close;ManagedString;Corgent.Diagramming.Toolbox.dll;Corgent.Diagramming.Toolbox." +
                "Properties.Resources;Close";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Save
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSave = ";&Save;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.CompanyKnowledgePage;save.Text";

            //";Save;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsof" +
            //"t.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;SaveText";


            ///// -----------------------------------------------------------------------------
            ///// <summary>
            ///// Contains resource string for:  New
            ///// </summary>
            ///// -----------------------------------------------------------------------------
            //private const string ResourceNew = ";newButton;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ExtendedTypeForm;>>newButton.Name";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Edit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEdit = ";&Edit;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ProductKnowledgePage;editKnowledge.Text";
            //";Edit;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.Ent" +
            //"erpriseManagement.Internal.UI.Authoring.Views.GroupsView.GroupsResources;Service" +
            //"EditTask";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Apply
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceApply = ";&Apply;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.PropertyDialogForm;buttonApply.Text";

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
            /// Contains resource string for:  Product Knowledge Tab Title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceProductKnowledgeTabTitle = ";Product Knowledge;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ProductKnowledgePage;$this.TabName";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Company Knowledge Tab Title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCompanyKnowledgeTabTitle = ";Company Knowledge;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.CompanyKnowledgePage;$this.TabName";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Confirm Dialog Title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfirmDialogTitle = ";System Center Operations Manager 2012;ManagedString;Microsoft.EnterpriseManagement.Monitoring.Console.exe;Microsoft.EnterpriseManagement.Monitoring.Console.ConsoleResources;ProductTitle";

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
            /// Caches the translated resource string for:  Close
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedClose;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Save
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSave;

            ///// -----------------------------------------------------------------------------
            ///// <summary>
            ///// Caches the translated resource string for:  New
            ///// </summary>
            ///// -----------------------------------------------------------------------------
            //private static string cachedNew;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Edit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEdit;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Apply
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedApply;

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
            /// Caches the translated resource string for:  ProductKnowledgeTabTitle
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedProductKnowledgeTabTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CompanyKnowledgeTabTitle
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCompanyKnowledgeTabTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfirmDialogTitle
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfirmDialogTitle;

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[v-waltli] 5/26/2009 Created
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
            /// Exposes access to the Close translated resource string
            /// </summary>
            /// <history>
            /// 	[v-waltli] 5/26/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Close
            {
                get
                {
                    if ((cachedClose == null))
                    {
                        cachedClose = CoreManager.MomConsole.GetIntlStr(ResourceClose);
                    }
                    return cachedClose;
                }
            }
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Save translated resource string
            /// </summary>
            /// <history>
            /// 	[v-waltli] 5/26/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Save
            {
                get
                {
                    if ((cachedSave == null))
                    {
                        cachedSave = CoreManager.MomConsole.GetIntlStr(ResourceSave);
                    }
                    return cachedSave;
                }
            }
            ///// -----------------------------------------------------------------------------
            ///// <summary>
            ///// Exposes access to the New translated resource string
            ///// </summary>
            ///// <history>
            ///// 	[v-waltli] 5/26/2009 Created
            ///// </history>
            ///// -----------------------------------------------------------------------------
            //public static string New
            //{
            //    get
            //    {
            //        if ((cachedNew == null))
            //        {
            //            cachedNew = CoreManager.MomConsole.GetIntlStr(ResourceNew);
            //        }
            //        return cachedNew;
            //    }
            //}

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Edit translated resource string
            /// </summary>
            /// <history>
            /// 	[v-waltli] 5/26/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Edit
            {
                get
                {
                    if ((cachedEdit == null))
                    {
                        cachedEdit = CoreManager.MomConsole.GetIntlStr(ResourceEdit);
                    }
                    return cachedEdit;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Apply translated resource string
            /// </summary>
            /// <history>
            /// 	[v-waltli] 5/26/2009 Created
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
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[v-waltli] 5/26/2009 Created
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
            /// 	[v-waltli] 5/26/2009 Created
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
            /// Exposes access to the ProductKnowledgeTabTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[v-waltli] 5/26/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ProductKnowledgeTabTitle
            {
                get
                {
                    if ((cachedProductKnowledgeTabTitle == null))
                    {
                        cachedProductKnowledgeTabTitle = CoreManager.MomConsole.GetIntlStr(ResourceProductKnowledgeTabTitle);
                    }
                    return cachedProductKnowledgeTabTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CompanyKnowledgeTabTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[v-waltli] 5/26/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CompanyKnowledgeTabTitle
            {
                get
                {
                    if ((cachedCompanyKnowledgeTabTitle == null))
                    {
                        cachedCompanyKnowledgeTabTitle = CoreManager.MomConsole.GetIntlStr(ResourceCompanyKnowledgeTabTitle);
                    }
                    return cachedCompanyKnowledgeTabTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfirmDialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[v-waltli] 5/26/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfirmDialogTitle
            {
                get
                {
                    if ((cachedConfirmDialogTitle == null))
                    {
                        cachedConfirmDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceConfirmDialogTitle);
                    }
                    return cachedConfirmDialogTitle;
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
        ///   [v-waltli] 5/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for CloseButton
            /// </summary>
            public const string CloseButton = "cancelButton";

            /// <summary>
            /// Control ID for MainTabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string MainTabControl = "tabPages";

            /// <summary>
            /// Control ID for SaveButton
            /// </summary>
            public const string SaveButton = "save";

            /// <summary>
            /// Control ID for DefaultManagementPack
            /// </summary>
            public const string DefaultManagementPack = "comboBoxMp";

            /// <summary>
            /// Control ID for ListView1
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string ListView1 = "ListBox";

            /// <summary>
            /// Control ID for EditButton
            /// </summary>
            public const string EditButton = "editKnowledge";

            /// <summary>
            /// Control ID for ApplyButton
            /// </summary>
            public const string ApplyButton = "applyButton";

            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";

            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
        }
        #endregion

    }
}
