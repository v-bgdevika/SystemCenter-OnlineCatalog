// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ViewsProperties.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[ruhim] 7/21/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.UserRole.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;

    #region Radio Group Enumeration - Tab4

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group Tab4
    /// </summary>
    /// <history>
    /// 	[ruhim] 7/21/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum Tab4
    {
        /// <summary>
        /// OnlyViewsExplicitlyAddedToTheApprovedViewsGridAreApproved = 0
        /// </summary>
        OnlyViewsExplicitlyAddedToTheApprovedViewsGridAreApproved = 0,

        /// <summary>
        /// AllViewsAreAutomaticallyApprovedIncludingViewsInManagementPacksImportedInTheFuture = 1
        /// </summary>
        AllViewsAreAutomaticallyApprovedIncludingViewsInManagementPacksImportedInTheFuture = 1,
    }
    #endregion

    #region Interface Definition - IViewsPropertiesControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IViewsPropertiesControls, for ViewsProperties.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 7/21/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IViewsPropertiesControls
    {
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

        /// <summary>
        /// Read-only property to access Tab4TabControl
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TabControl Tab4TabControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ViewsTreeView
        /// </summary>
        TreeView ViewsTreeView
        {
            get;
        }

        ListView SummaryListView
        {
            get;
        }
        /// <summary>
        /// Read-only property to access ApprovedViewsStaticControl
        /// </summary>
        StaticControl ApprovedViewsStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ExplicitlyApprovedViewsRadioButton
        /// </summary>
        RadioButton ExplicitlyApprovedViewsRadioButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AllViewsRadioButton
        /// </summary>
        RadioButton AllViewsRadioButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ApproveViewsStaticControl
        /// </summary>
        StaticControl ApproveViewsStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access MembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingDataSt
        /// </summary>
        StaticControl MembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingDataSt
        {
            get;
        }

        /// <summary>
        /// Read-only property to access TabControl
        /// </summary>
        TabControl _TabControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AddRemoveToolbar
        /// </summary>
        Toolbar AddRemoveToolbar
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
    /// 	[ruhim] 7/21/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ViewsProperties : Dialog, IViewsPropertiesControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion

        #region Private Member Variables

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

        /// <summary>
        /// Cache to hold a reference to Tab4TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab4TabControl;

        /// <summary>
        /// Cache to hold a reference to ViewsTreeView of type TreeView
        /// </summary>
        private TreeView cachedViewsTreeView;

        /// <summary>
        /// Cache to hold a reference to ApprovedViewsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedApprovedViewsStaticControl;

        /// <summary>
        /// Cache to hold a reference to ExplicitlyApprovedViewsRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedExplicitlyApprovedViewsRadioButton;

        /// <summary>
        /// Cache to hold a reference to AllViewsRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedAllViewsRadioButton;

        /// <summary>
        /// Cache to hold a reference to ApproveViewsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedApproveViewsStaticControl;

        /// <summary>
        /// Cache to hold a reference to MembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingDataSt of type StaticControl
        /// </summary>
        private StaticControl cachedMembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingDataSt;

        /// <summary>
        /// Cache to hold a reference to Tab0TabControl of type TabControl
        /// </summary>
        private TabControl cachedTabControl;

        /// <summary>
        /// Cache to hold a reference to AddRemoveToolbar of type Toolbar
        /// </summary>
        private Toolbar cachedAddRemoveToolbar;

        /// <summary>
        /// Cache to hold a reference to SummaryListView of type ListView
        /// </summary>
        private ListView cachedSummaryListView;
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ViewsProperties of type App
        /// </param>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ViewsProperties(ConsoleApp app)
            :
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion

        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group Tab4
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual Tab4 Tab4
        {
            get
            {
                if ((this.Controls.ExplicitlyApprovedViewsRadioButton.ButtonState == ButtonState.Checked))
                {
                    return Tab4.OnlyViewsExplicitlyAddedToTheApprovedViewsGridAreApproved;
                }

                if ((this.Controls.AllViewsRadioButton.ButtonState == ButtonState.Checked))
                {
                    return Tab4.AllViewsAreAutomaticallyApprovedIncludingViewsInManagementPacksImportedInTheFuture;
                }
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }

            set
            {
                if ((value == Tab4.OnlyViewsExplicitlyAddedToTheApprovedViewsGridAreApproved))
                {
                    this.Controls.ExplicitlyApprovedViewsRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == Tab4.AllViewsAreAutomaticallyApprovedIncludingViewsInManagementPacksImportedInTheFuture))
                    {
                        this.Controls.AllViewsRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion

        #region IViewsProperties Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IViewsPropertiesControls Controls
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
        ///  Exposes access to the ApplyButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IViewsPropertiesControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, ViewsProperties.ControlIDs.ApplyButton);
                }
                return this.cachedApplyButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IViewsPropertiesControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ViewsProperties.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IViewsPropertiesControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, ViewsProperties.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab4TabControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IViewsPropertiesControls.Tab4TabControl
        {
            get
            {
                if ((this.cachedTab4TabControl == null))
                {
                    this.cachedTab4TabControl = new TabControl(this, ViewsProperties.ControlIDs.Tab4TabControl);
                }
                return this.cachedTab4TabControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ViewsTreeView control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TreeView IViewsPropertiesControls.ViewsTreeView
        {
            get
            {
                if ((this.cachedViewsTreeView == null))
                {
                    Window wndTemp = this.App.MainWindow;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 3); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedViewsTreeView = new TreeView(wndTemp);
                }
                return this.cachedViewsTreeView;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApprovedViewsStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IViewsPropertiesControls.ApprovedViewsStaticControl
        {
            get
            {
                if ((this.cachedApprovedViewsStaticControl == null))
                {
                    this.cachedApprovedViewsStaticControl = new StaticControl(this, ViewsProperties.ControlIDs.ApprovedViewsStaticControl);
                }
                return this.cachedApprovedViewsStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExplicitlyApprovedViewsRadioButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IViewsPropertiesControls.ExplicitlyApprovedViewsRadioButton
        {
            get
            {
                if ((this.cachedExplicitlyApprovedViewsRadioButton == null))
                {
                    this.cachedExplicitlyApprovedViewsRadioButton = new RadioButton(this, ViewsProperties.ControlIDs.ExplicitlyApprovedViewsRadioButton);
                }
                return this.cachedExplicitlyApprovedViewsRadioButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AllViewsRadioButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IViewsPropertiesControls.AllViewsRadioButton
        {
            get
            {
                if ((this.cachedAllViewsRadioButton == null))
                {
                    this.cachedAllViewsRadioButton = new RadioButton(this, ViewsProperties.ControlIDs.AllViewsRadioButton);
                }
                return this.cachedAllViewsRadioButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApproveViewsStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IViewsPropertiesControls.ApproveViewsStaticControl
        {
            get
            {
                if ((this.cachedApproveViewsStaticControl == null))
                {
                    this.cachedApproveViewsStaticControl = new StaticControl(this, ViewsProperties.ControlIDs.ApproveViewsStaticControl);
                }
                return this.cachedApproveViewsStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingDataSt control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IViewsPropertiesControls.MembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingDataSt
        {
            get
            {
                if ((this.cachedMembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingDataSt == null))
                {
                    this.cachedMembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingDataSt = new StaticControl(this, ViewsProperties.ControlIDs.MembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingDataSt);
                }
                return this.cachedMembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingDataSt;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TabControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 1/26/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IViewsPropertiesControls._TabControl
        {
            get
            {
                if ((this.cachedTabControl == null))
                {
                    this.cachedTabControl = new TabControl(this, ViewsProperties.ControlIDs.TabControl);
                }
                return this.cachedTabControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddRemoveToolbar control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// 	[nathd] 24SEP2009 Maui 2.0: Calling the Toolbar constructor with a QID.
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IViewsPropertiesControls.AddRemoveToolbar
        {
            get
            {
                if ((this.cachedAddRemoveToolbar == null))
                {
                    QID queryId = new QID(";[UIA]AutomationId =\'" + ViewsProperties.ControlIDs.PagePanel + "\' && Role = 'pane';[UIA]AutomationId=\'" + ViewsProperties.ControlIDs.AddRemoveToolbar + "\'");
                    this.cachedAddRemoveToolbar = new Toolbar(this, queryId, Constants.DefaultContextMenuTimeout);
                }
                return this.cachedAddRemoveToolbar;
            }
        }


        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SummaryListView control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IViewsPropertiesControls.SummaryListView
        {
            get
            {
                if ((this.cachedSummaryListView == null))
                {
                    this.cachedSummaryListView = new ListView(this, ViewsProperties.ControlIDs.SummaryListView);
                }
                return this.cachedSummaryListView;
            }
        }
        #endregion

        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Apply
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
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
        /// 	[ruhim] 7/21/2006 Created
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
        /// 	[ruhim] 7/21/2006 Created
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
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.            
            Window tempWindow = null;
            try
            {
                tempWindow = new Window(Strings.DialogTitle
                    + "*",
                    StringMatchSyntax.WildCard);
            }
            catch (Exceptions.WindowNotFoundException ex)
            {
                // locate the dialog
                tempWindow = null;
                int numberOfTries = 0;
                const int MAXTRIES = 7;
                Core.Common.Utilities.LogMessage("Looking for window with title:  '"
                    + Strings.DialogTitle + "'");

                while (tempWindow == null && numberOfTries < MAXTRIES)
                {
                    // log the attempt
                    numberOfTries++;

                    try
                    {
                        // look for the dialogue again using wildcard matching
                        tempWindow = new Window(
                            Strings.DialogTitle + "*",
                            StringMatchSyntax.WildCard);
                        // If the window is not found then this wait is never called
                        // Hence added the sleep call in catch block
                        // Wait for the window to report that is ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Window.Exceptions.WindowNotFoundException)
                    {
                        //sleep to wait for window search
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);

                        // log the outcome of this attempt
                        Core.Common.Utilities.LogMessage("Attempt "
                            + numberOfTries
                            + " of "
                            + MAXTRIES
                            + "...");
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    throw new Window.Exceptions.WindowNotFoundException(
                        "Init function could not find or bring up the window"
                        + "with a title of '" + Strings.DialogTitle
                        + "'.\n\n" + ex.Message);
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
        /// 	[ruhim] 7/21/2006 Created
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
                "; - User Role Properties;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;UserRolePropertiesTitle";
            
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
            /// Contains resource string for:  Tab4
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTab4 = "Tab4";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ApprovedViews
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceApprovedViews = ";Approved &views:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.Enterprise" +
                "Management.Mom.Internal.UI.Console.Administration.ViewScope;labelViews.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OnlyViewsExplicitlyAddedToTheApprovedViewsGridAreApproved
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOnlyViewsExplicitlyAddedToTheApprovedViewsGridAreApproved = ";&Only views explicitly added to the \'Approved views\' grid are approved;ManagedSt" +
                "ring;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI" +
                ".Console.Administration.ViewScope;radioButtonSpecific.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AllViewsAreAutomaticallyApprovedIncludingViewsInManagementPacksImportedInTheFuture
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAllViewsAreAutomaticallyApprovedIncludingViewsInManagementPacksImportedInTheFuture = ";A&ll views are automatically approved, including views in Management Packs impor" +
                "ted in the future;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.Enterpris" +
                "eManagement.Mom.Internal.UI.Console.Administration.ViewScope;radioButtonAll.Text" +
                "";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ApproveViews
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceApproveViews = ";Approve views;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseMan" +
                "agement.Mom.Internal.UI.Console.Administration.ViewScope;labelTitle.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingData
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingData = @";Members of this user role can see approved views. Limiting access to views does not limit access to the underlying data.;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.ViewScope;titleLabel.Text";

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
            /// Caches the translated resource string for:  Tab4
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab4;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ApprovedViews
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedApprovedViews;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OnlyViewsExplicitlyAddedToTheApprovedViewsGridAreApproved
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOnlyViewsExplicitlyAddedToTheApprovedViewsGridAreApproved;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AllViewsAreAutomaticallyApprovedIncludingViewsInManagementPacksImportedInTheFuture
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAllViewsAreAutomaticallyApprovedIncludingViewsInManagementPacksImportedInTheFuture;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ApproveViews
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedApproveViews;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingData
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingData;

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
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
            /// Exposes access to the Apply translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
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
            /// 	[ruhim] 7/21/2006 Created
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
            /// 	[ruhim] 7/21/2006 Created
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
            /// Exposes access to the Tab4 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tab4
            {
                get
                {
                    if ((cachedTab4 == null))
                    {
                        cachedTab4 = CoreManager.MomConsole.GetIntlStr(ResourceTab4);
                    }
                    return cachedTab4;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ApprovedViews translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ApprovedViews
            {
                get
                {
                    if ((cachedApprovedViews == null))
                    {
                        cachedApprovedViews = CoreManager.MomConsole.GetIntlStr(ResourceApprovedViews);
                    }
                    return cachedApprovedViews;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OnlyViewsExplicitlyAddedToTheApprovedViewsGridAreApproved translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OnlyViewsExplicitlyAddedToTheApprovedViewsGridAreApproved
            {
                get
                {
                    if ((cachedOnlyViewsExplicitlyAddedToTheApprovedViewsGridAreApproved == null))
                    {
                        cachedOnlyViewsExplicitlyAddedToTheApprovedViewsGridAreApproved = CoreManager.MomConsole.GetIntlStr(ResourceOnlyViewsExplicitlyAddedToTheApprovedViewsGridAreApproved);
                    }
                    return cachedOnlyViewsExplicitlyAddedToTheApprovedViewsGridAreApproved;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AllViewsAreAutomaticallyApprovedIncludingViewsInManagementPacksImportedInTheFuture translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AllViewsAreAutomaticallyApprovedIncludingViewsInManagementPacksImportedInTheFuture
            {
                get
                {
                    if ((cachedAllViewsAreAutomaticallyApprovedIncludingViewsInManagementPacksImportedInTheFuture == null))
                    {
                        cachedAllViewsAreAutomaticallyApprovedIncludingViewsInManagementPacksImportedInTheFuture = CoreManager.MomConsole.GetIntlStr(ResourceAllViewsAreAutomaticallyApprovedIncludingViewsInManagementPacksImportedInTheFuture);
                    }
                    return cachedAllViewsAreAutomaticallyApprovedIncludingViewsInManagementPacksImportedInTheFuture;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ApproveViews translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ApproveViews
            {
                get
                {
                    if ((cachedApproveViews == null))
                    {
                        cachedApproveViews = CoreManager.MomConsole.GetIntlStr(ResourceApproveViews);
                    }
                    return cachedApproveViews;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingData translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingData
            {
                get
                {
                    if ((cachedMembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingData == null))
                    {
                        cachedMembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingData = CoreManager.MomConsole.GetIntlStr(ResourceMembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingData);
                    }
                    return cachedMembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingData;
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
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
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

            /// <summary>
            /// Control ID for Tab4TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab4TabControl = "tabPages";

            /// <summary>
            /// Control ID for ApprovedViewsStaticControl
            /// </summary>
            public const string ApprovedViewsStaticControl = "labelViews";

            /// <summary>
            /// Control ID for ExplicitlyApprovedViewsRadioButton
            /// </summary>
            public const string ExplicitlyApprovedViewsRadioButton = "radioButtonSpecificSelect";

            /// <summary>
            /// Control ID for AllViewsRadioButton
            /// </summary>
            public const string AllViewsRadioButton = "radioButtonAllSelect";

            /// <summary>
            /// Control ID for ApproveViewsStaticControl
            /// </summary>
            public const string ApproveViewsStaticControl = "labelTitle";

            /// <summary>
            /// Control ID for MembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingDataSt
            /// </summary>
            public const string MembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingDataSt = "titleLabel";
            
            /// <summary>
            /// Control ID for Tab0TabControl
            /// </summary>
            public const string TabControl = "tabControl1";

            /// <summary>
            /// Control ID for PagePanel
            /// </summary>
            public const string PagePanel = "panelApprovedTasks";

            /// <summary>
            /// Control ID for AddRemoveToolbar
            /// </summary>
            public const string AddRemoveToolbar = "toolStripAddRemove";

            /// <summary>
            /// Control ID for SummaryListView
            /// </summary>
            public const string SummaryListView = "sortingListViewTasks";
        }
        #endregion
    }
}
