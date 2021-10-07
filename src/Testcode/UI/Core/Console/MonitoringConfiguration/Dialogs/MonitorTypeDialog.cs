// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="MonitorTypeDialog.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	MOMv3 UI Test Automation
// </summary>
// <history>
// 	[ruhim] 3/10/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Console;
    using Mom.Test.UI.Core.Common;
    using Microsoft.EnterpriseManagement.Mom.Internal;
    using System;
    
    #region Interface Definition - IMonitorTypeDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IMonitorTypeDialogControls, for MonitorTypeDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 3/10/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IMonitorTypeDialogControls
    {
        /// <summary>
        /// Read-only property to access PreviousButton
        /// </summary>
        Button PreviousButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access NextButton
        /// </summary>
        Button NextButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access CreateButton
        /// </summary>
        Button CreateButton
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
        /// Read-only property to access MonitorTypeStaticControl
        /// </summary>
        StaticControl MonitorTypeStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ManagementPackStaticControl
        /// </summary>
        StaticControl ManagementPackStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access SelectDestinationManagementPackStaticControl
        /// </summary>
        StaticControl SelectDestinationManagementPackStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access NewButton
        /// </summary>
        Button NewButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access SelectDestinationManagementPackComboBox
        /// </summary>
        ComboBox SelectDestinationManagementPackComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access SelectTheTypeOfMonitorToCreateStaticControl
        /// </summary>
        StaticControl SelectTheTypeOfMonitorToCreateStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ExpandTheFoldersAndSelectAMonitorTypeToCreateStaticControl
        /// </summary>
        StaticControl ExpandTheFoldersAndSelectAMonitorTypeToCreateStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access DescriptionStaticControl
        /// </summary>
        StaticControl DescriptionStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access SelectAMonitorTypeBelowTreeView
        /// </summary>
        MomControls.TreeView SelectAMonitorTypeBelowTreeView
        {
            get;
        }

        /// <summary>
        /// Read-only property to access HelpStaticControl
        /// </summary>
        StaticControl HelpStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access SelectAMonitorTypeStaticControl
        /// </summary>
        StaticControl SelectAMonitorTypeStaticControl
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
    /// 	[ruhim] 3/10/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class MonitorTypeDialog : Dialog, IMonitorTypeDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion

        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to PreviousButton of type Button
        /// </summary>
        private Button cachedPreviousButton;

        /// <summary>
        /// Cache to hold a reference to NextButton of type Button
        /// </summary>
        private Button cachedNextButton;

        /// <summary>
        /// Cache to hold a reference to CreateButton of type Button
        /// </summary>
        private Button cachedCreateButton;

        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;

        /// <summary>
        /// Cache to hold a reference to MonitorTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMonitorTypeStaticControl;

        /// <summary>
        /// Cache to hold a reference to ManagementPackStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedManagementPackStaticControl;

        /// <summary>
        /// Cache to hold a reference to SelectDestinationManagementPackStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectDestinationManagementPackStaticControl;

        /// <summary>
        /// Cache to hold a reference to NewButton of type Button
        /// </summary>
        private Button cachedNewButton;

        /// <summary>
        /// Cache to hold a reference to SelectDestinationManagementPackComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedSelectDestinationManagementPackComboBox;

        /// <summary>
        /// Cache to hold a reference to SelectTheTypeOfMonitorToCreateStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectTheTypeOfMonitorToCreateStaticControl;

        /// <summary>
        /// Cache to hold a reference to ExpandTheFoldersAndSelectAMonitorTypeToCreateStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedExpandTheFoldersAndSelectAMonitorTypeToCreateStaticControl;

        /// <summary>
        /// Cache to hold a reference to DescriptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDescriptionStaticControl;

        /// <summary>
        /// Cache to hold a reference to SelectAMonitorTypeBelowTreeView of type TreeView
        /// </summary>
        private MomControls.TreeView cachedSelectAMonitorTypeBelowTreeView;

        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;

        /// <summary>
        /// Cache to hold a reference to SelectAMonitorTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectAMonitorTypeStaticControl;
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of MonitorTypeDialog of type App
        /// </param>
        /// <history>
        /// 	[ruhim] 3/10/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public MonitorTypeDialog(Maui.Core.App app)
            :
                base(app, Init(app))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout); 
        }
        #endregion

        #region IMonitorTypeDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 3/10/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IMonitorTypeDialogControls Controls
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
        ///  Routine to set/get the text in control SelectDestinationManagementPack
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 3/10/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SelectDestinationManagementPackText
        {
            get
            {
                return this.Controls.SelectDestinationManagementPackComboBox.Text;
            }

            set
            {
                this.Controls.SelectDestinationManagementPackComboBox.SelectByText(value, true);
            }
        }
        #endregion

        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/10/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMonitorTypeDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, MonitorTypeDialog.ControlIDs.PreviousButton);
                }
                return this.cachedPreviousButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/10/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMonitorTypeDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, MonitorTypeDialog.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/10/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMonitorTypeDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, MonitorTypeDialog.ControlIDs.CreateButton);
                }
                return this.cachedCreateButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/10/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMonitorTypeDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, MonitorTypeDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitorTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/10/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMonitorTypeDialogControls.MonitorTypeStaticControl
        {
            get
            {
                if ((this.cachedMonitorTypeStaticControl == null))
                {
                    this.cachedMonitorTypeStaticControl = new StaticControl(this, MonitorTypeDialog.ControlIDs.MonitorTypeStaticControl);
                }
                return this.cachedMonitorTypeStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementPackStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/10/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMonitorTypeDialogControls.ManagementPackStaticControl
        {
            get
            {
                if ((this.cachedManagementPackStaticControl == null))
                {
                    this.cachedManagementPackStaticControl = new StaticControl(this, MonitorTypeDialog.ControlIDs.ManagementPackStaticControl);
                }
                return this.cachedManagementPackStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectDestinationManagementPackStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/10/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMonitorTypeDialogControls.SelectDestinationManagementPackStaticControl
        {
            get
            {
                if ((this.cachedSelectDestinationManagementPackStaticControl == null))
                {
                    this.cachedSelectDestinationManagementPackStaticControl = new StaticControl(this, MonitorTypeDialog.ControlIDs.SelectDestinationManagementPackStaticControl);
                }
                return this.cachedSelectDestinationManagementPackStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NewButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/10/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMonitorTypeDialogControls.NewButton
        {
            get
            {
                if ((this.cachedNewButton == null))
                {
                    this.cachedNewButton = new Button(this, MonitorTypeDialog.ControlIDs.NewButton);
                }
                return this.cachedNewButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectDestinationManagementPackComboBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/10/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IMonitorTypeDialogControls.SelectDestinationManagementPackComboBox
        {
            get
            {
                int numberOfTries = 0;
                int maxTries = 5;
                while (this.cachedSelectDestinationManagementPackComboBox == null && numberOfTries < maxTries)
                {
                    try
                    {
                        this.cachedSelectDestinationManagementPackComboBox = new ComboBox(this, MonitorTypeDialog.ControlIDs.SelectDestinationManagementPackComboBox);
                    }
                    catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                    {
                        Sleeper.Delay(Constants.OneSecond);
                        Utilities.LogMessage("MonitorTypeDialog.SelectDestinationManagementPackComboBox:: failed to get this combobox, will try again later.");
                    }
                    numberOfTries++;
                }

                if (this.cachedSelectDestinationManagementPackComboBox == null)
                {
                    throw new Maui.Core.Window.Exceptions.WindowNotFoundException("MonitorTypeDialog.SelectDestinationManagementPackComboBox:: failed to get the combobox finally.");
                }

                return this.cachedSelectDestinationManagementPackComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectTheTypeOfMonitorToCreateStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/10/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMonitorTypeDialogControls.SelectTheTypeOfMonitorToCreateStaticControl
        {
            get
            {
                // The ID for this control (pageSectionLabel1) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedSelectTheTypeOfMonitorToCreateStaticControl == null))
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
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    this.cachedSelectTheTypeOfMonitorToCreateStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedSelectTheTypeOfMonitorToCreateStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExpandTheFoldersAndSelectAMonitorTypeToCreateStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/10/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMonitorTypeDialogControls.ExpandTheFoldersAndSelectAMonitorTypeToCreateStaticControl
        {
            get
            {
                if ((this.cachedExpandTheFoldersAndSelectAMonitorTypeToCreateStaticControl == null))
                {
                    this.cachedExpandTheFoldersAndSelectAMonitorTypeToCreateStaticControl = new StaticControl(this, MonitorTypeDialog.ControlIDs.ExpandTheFoldersAndSelectAMonitorTypeToCreateStaticControl);
                }
                return this.cachedExpandTheFoldersAndSelectAMonitorTypeToCreateStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/10/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMonitorTypeDialogControls.DescriptionStaticControl
        {
            get
            {
                if ((this.cachedDescriptionStaticControl == null))
                {
                    this.cachedDescriptionStaticControl = new StaticControl(this, MonitorTypeDialog.ControlIDs.DescriptionStaticControl);
                }
                return this.cachedDescriptionStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectAMonitorTypeBelowTreeView control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/10/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        MomControls.TreeView IMonitorTypeDialogControls.SelectAMonitorTypeBelowTreeView
        {
            get
            {
                if ((this.cachedSelectAMonitorTypeBelowTreeView == null))
                {
                    WindowParameters windowParameters = new WindowParameters();
                    windowParameters.StartWindow = this;
                    windowParameters.WinFormsID = MonitorTypeDialog.ControlIDs.SelectAMonitorTypeBelowTreeView;
                    this.cachedSelectAMonitorTypeBelowTreeView = new MomControls.TreeView(windowParameters);
                }
                return this.cachedSelectAMonitorTypeBelowTreeView;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/10/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMonitorTypeDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, MonitorTypeDialog.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectAMonitorTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/10/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMonitorTypeDialogControls.SelectAMonitorTypeStaticControl
        {
            get
            {
                if ((this.cachedSelectAMonitorTypeStaticControl == null))
                {
                    this.cachedSelectAMonitorTypeStaticControl = new StaticControl(this, MonitorTypeDialog.ControlIDs.SelectAMonitorTypeStaticControl);
                }
                return this.cachedSelectAMonitorTypeStaticControl;
            }
        }
        #endregion

        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/10/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickPrevious()
        {
            this.Controls.PreviousButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Next
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/10/2006 Created
        /// 	[v-bire] 6/28/2011 Modified
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNext()
        {
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.Controls.NextButton, Constants.OneSecond * 10);

            this.Controls.NextButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Create
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/10/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCreate()
        {
            this.Controls.CreateButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/10/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button New
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/10/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNew()
        {
            this.Controls.NewButton.Click();
        }
        #endregion

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">App owning the dialog.</param>)
        /// <history>
        /// 	[ruhim] 3/10/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app)
        {
            // First check if the dialog is already up.            
            Window tempWindow = null;
            // Speicify the search condition for this window
            WindowParameters windowParameters = new WindowParameters();
            windowParameters.Caption = Strings.DialogTitle + "*";
            windowParameters.CaptionMatchSyntax = StringMatchSyntax.WildCard;
            windowParameters.Timeout = Window.DefaultWaitTimeout; // Timeout is set to 3000 ms 

            try
            {
                tempWindow = new Window(windowParameters);
            }
            catch (Exceptions.WindowNotFoundException ex)
            {
                // locate the dialog
                tempWindow = null;
                int numberOfTries = 0;
                const int MAXTRIES = 40;
                Core.Common.Utilities.LogMessage("Looking for window with title:  '"
                    + Strings.DialogTitle + "'");

                while (tempWindow == null && numberOfTries < MAXTRIES)
                {
                    // log the attempt
                    numberOfTries++;
                    try
                    {
                        // look for the dialogue again using wildcard matching
                        tempWindow = new Window(windowParameters);

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
        /// 	[ruhim] 3/10/2006 Created
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
                ";Create Monitor Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Extensibility.UISDKResources;CreateMonitorWizard";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrevious = ";< &Previous;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.PageFramework.WizardButtonsPanel;previousButton.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext = ";&Next >;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement" +
                ".Mom.Internal.UI.PageFrameworks.WizardFramework;buttonNext.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Create
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCreate = ";Create;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagem" +
                "ent.Internal.UI.Authoring.Pages.Common.PageCommonResources;CommitButtonText" +
                "";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;DC01.bT;buttonCancel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MonitorType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMonitorType = ";Monitor Type;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseM" +
                "anagement.Internal.UI.Authoring.Pages.ChooseMonitorTypePage;$this.TabName";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ManagementPack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceManagementPack = ";Management pack;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpri" +
                "seManagement.Mom.Internal.UI.Controls.ManagementPackComboBoxControl;pageSectionL" +
                "abel1.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectDestinationManagementPack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectDestinationManagementPack = ";&Select destination management pack:;ManagedString;Microsoft.MOM.UI.Components.d" +
                "ll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.ManagementPackComboBo" +
                "xControl;label1.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  New
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNew = ";&New...;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.Administration.GroupSettings.ResolutionStates;toolStripButt" +
                "onNew.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectTheTypeOfMonitorToCreate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectTheTypeOfMonitorToCreate = ";Select the type of monitor to create;ManagedString;Microsoft.MOM.UI.Components.d" +
                "ll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ChooseMonitorTypePage;pa" +
                "geSectionLabel1.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ExpandTheFoldersAndSelectAMonitorTypeToCreate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceExpandTheFoldersAndSelectAMonitorTypeToCreate = ";Expand the folders and select a monitor type to create.;ManagedString;Microsoft." +
                "MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring." +
                "Pages.Common.PageCommonResources;SelectMonitorTypeMessage";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Description
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDescription = ";Description:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseM" +
                "anagement.Mom.Internal.UI.Views.AdminNodeDetailView;descriptionLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mo" +
                "m.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectAMonitorType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectAMonitorType = ";Select a Monitor Type;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.En" +
                "terpriseManagement.Internal.UI.Authoring.Pages.ChooseMonitorTypePage;$this.HeaderText";

            /// <summary>
            /// Contains resource string for:  Monitor a Windows Service monitor type
            /// </summary>
            public static Guid NTServiceMonitorGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsNTServiceStateName);

            /// <summary>
            /// Event Monitor - Single Event with Manual Reset Guid (Stored in MonitorType table)
            /// </summary>
            public static Guid SingleEventManualResetGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsEventsSingleEventManualResetName);

            /// <summary>
            /// SNMP Trap Monitor
            /// </summary>
            public static Guid SNMPTrapMonitorGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemNetworkManagementLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.SNMPTrapMonitorName);

            /// <summary>
            /// SNMP Probe Monitor
            /// </summary>
            public static Guid SNMPProbeMonitorGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemNetworkManagementLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.SNMPProbeMonitorName);

            /// <summary>
            /// EventMonitorSingleEventAutoReset
            /// </summary>
            public static Guid EventMonitorSingleEventAutoResetGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.EventMonitorSingleEventAutoResetName);

            /// <summary>
            /// EventMonitorSingleEvent Event Reset
            /// </summary>
            public static Guid EventMonitorSingleEventEventResetGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsEventsSingleEventEventResetName);

            /// <summary>
            /// Event Monitor - Correlated Event with Manual Reset Guid (Stored in MonitorType table)
            /// </summary>
            public static Guid CorrelatedEventManualResetGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsEventsCorrelatedManualResetName);

            /// <summary>
            /// Event Monitor - Correlated Event with Auto Timer Reset Guid (Stored in MonitorType table)
            /// </summary>
            public static Guid CorrelatedEventTimerResetGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsEventsCorrelatedTimerResetName);

            /// <summary>
            /// Event Monitor - Correlated Event with Event Reset Guid (Stored in MonitorType table)
            /// </summary>
            public static Guid CorrelatedEventEventResetGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsEventsCorrelatedEventResetName);

            /// <summary>
            /// Event Monitor - Correlated Missing Event with Manual Reset Guid (Stored in MonitorType table)
            /// </summary>
            public static Guid CorrelatedMissingEventManualResetGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsEventsCorrelatedMissingManualResetName);

            /// <summary>
            /// Event Monitor - Correlated Missing Event with Timer Reset Guid (Stored in MonitorType table)
            /// </summary>
            public static Guid CorrelatedMissingEventTimerResetGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsEventsCorrelatedMissingTimerResetName);

            /// <summary>
            /// Event Monitor - Correlated Missing Event with Event Reset Guid (Stored in MonitorType table)
            /// </summary>
            public static Guid CorrelatedMissingEventEventResetGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsEventsCorrelatedMissingEventResetName);

            /// <summary>
            /// Event Monitor - Missing Event with Manual Reset Guid (Stored in MonitorType table)
            /// </summary>
            public static Guid MissingEventManualResetGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsEventsMissingManualResetName);

            /// <summary>
            /// Event Monitor - Missing Event with Auto Timer Reset Guid (Stored in MonitorType table)
            /// </summary>
            public static Guid MissingEventTimerResetGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsEventsMissingTimerResetName);

            /// <summary>
            /// Event Monitor - Missing Event with Event Reset Guid (Stored in MonitorType table)
            /// </summary>
            public static Guid MissingEventEventResetGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsEventsMissingEventResetName);

            /// <summary>
            /// Event Monitor - Repeated Event with Manual Reset Guid (Stored in MonitorType table)
            /// </summary>
            public static Guid RepeatedEventManualResetGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsEventsRepeatedManualResetName);

            /// <summary>
            /// Event Monitor - Repeated Event with Auto Timer Reset Guid (Stored in MonitorType table)
            /// </summary>
            public static Guid RepeatedEventTimerResetGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsEventsRepeatedTimerResetName);

            /// <summary>
            /// Event Monitor - Repeated Event with Event Reset Guid (Stored in MonitorType table)
            /// </summary>
            public static Guid RepeatedEventEventResetGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsEventsRepeatedEventResetName);

            /// <summary>
            /// Event Monitor - WMI Event Repeated Event with Manual Reset Guid (Stored in MonitorType table)
            /// </summary>
            public static Guid WMIEventSingleManualResetGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsWMIEventsSingleManualResetName);

            /// <summary>
            /// Event Monitor - WMI Event Repeated Event with Auto Timer Reset Guid (Stored in MonitorType table)
            /// </summary>
            public static Guid WMIEventSingleTimerResetGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsWMIEventsSingleTimerResetName);

            /// <summary>
            /// Event Monitor - WMI Event Repeated Event with Event Reset Guid (Stored in MonitorType table)
            /// </summary>
            public static Guid WMIEventSingleEventResetGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsWMIEventsSingleWMIEventResetName);

            /// <summary>
            /// Event Monitor - WMI Event Repeated Event with Manual Reset Guid (Stored in MonitorType table)
            /// </summary>
            public static Guid WMIEventRepeatedManualResetGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsWMIEventsRepeatedManualResetName);

            /// <summary>
            /// Event Monitor - WMI Event Repeated Event with Auto Timer Reset Guid (Stored in MonitorType table)
            /// </summary>
            public static Guid WMIEventRepeatedTimerResetGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsWMIEventsRepeatedTimerResetName);

            /// <summary>
            /// Event Monitor - WMI Event Repeated Event with Event Reset Guid (Stored in MonitorType table)
            /// </summary>
            public static Guid WMIEventRepeatedEventResetGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsWMIEventsRepeatedWMIEventResetName);

            /// <summary>
            /// WMI Performance Monitor - Single Threshold with Average Guid(Stored in MonitorType table)
            /// </summary>
            public static Guid WMIPerformanceAverageThresholdGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsWMIPerformanceAverageThresholdName);

            /// <summary>
            /// WMI Performance Monitor - Single Threshold with Consecutive Guid(Stored in MonitorType table)
            /// </summary>
            public static Guid WMIPerformanceConsecutiveThresholdGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsWMIPerformanceConsecutiveSamplesThresholdName);

            /// <summary>
            /// WMI Performance Monitor - Single Threshold with Delta Guid(Stored in MonitorType table)
            /// </summary>
            public static Guid WMIPerformanceDeltaThresholdGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsWMIPerformanceDeltaThresholdName);

            /// <summary>
            /// WMI Performance Monitor - Single Threshold with Simple Guid(Stored in MonitorType table)
            /// </summary>
            public static Guid WMIPerformanceSimpleThresholdGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsWMIPerformanceSimpleThresholdName);

            /// <summary>
            /// WMI Performance Monitor - Double Threshold Guid(Stored in MonitorType table)
            /// </summary>
            public static Guid WMIPerformanceDoulbeThresholdGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsWMIPerformanceDoulbeThresholdName);

            /// <summary>
            /// Windows Performance Monitor - 2-state Above Self Tuning Threshold Guid(Stored in MonitorType table)
            /// </summary>
            public static Guid WindowsPerformance2StateAboveSelfTuningThresholdGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemPerformanceLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsPerformance2stateAboveThresholdName);
           
            /// <summary>
            /// Windows Performance Monitor - 2-state Baselining Self Tuning Threshold Guid(Stored in MonitorType table)
            /// </summary>
            public static Guid WindowsPerformance2StateBaseliningSelfTuningThresholdGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemPerformanceLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsPerformance2stateBaseliningThresholdName);

            /// <summary>
            /// Windows Performance Monitor - 2-state Below Self Tuning Threshold Guid(Stored in MonitorType table)
            /// </summary>
            public static Guid WindowsPerformance2StateBelowSelfTuningThresholdGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemPerformanceLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsPerformance2stateBelowThresholdName);

            /// <summary>
            /// Windows Performance Monitor - 3-state Baselining Self Tuning Threshold Guid(Stored in MonitorType table)
            /// </summary>
            public static Guid WindowsPerformance3StateBaseliningSelfTuningThresholdGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemPerformanceLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsPerformance3stateBaseliningThresholdName);

            /// <summary>
            /// Windows Performance Monitor - Single Threshold with Average Guid(Stored in MonitorType table)
            /// </summary>
            public static Guid WindowsPerformanceAverageThresholdGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemPerformanceLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsPerformanceAverageThresholdName);

            /// <summary>
            /// Windows Performance Monitor - Single Threshold with Consecutive Guid(Stored in MonitorType table)
            /// </summary>
            public static Guid WindowsPerformanceConsecutiveSamplesOverThresholdGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemPerformanceLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsPerformanceConsecutiveSamplesoverThresholdName);

            /// <summary>
            /// Windows Performance Monitor - Single Threshold with Delta Guid(Stored in MonitorType table)
            /// </summary>
            public static Guid WindowsPerformanceDeltaThresholdGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemPerformanceLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsPerformanceDeltaThresholdName);

            /// <summary>
            /// Windows Performance Monitor - Single Threshold with Simple Guid(Stored in MonitorType table)
            /// </summary>
            public static Guid WindowsPerformanceSimpleThresholdGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemPerformanceLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsPerformanceSimpleThresholdName);

            /// <summary>
            /// Windows Performance Monitor - Double Threshold Guid(Stored in MonitorType table)
            /// </summary>
            public static Guid WindowsPerformanceDoulbeThresholdGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemPerformanceLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsPerformanceDoubleThresholdName);

            /// <summary>
            /// PerformanceBaselineMonitor3StateBaseliningName
            /// </summary>
            public static Guid PerformanceBaselineMonitor3StateBaseliningGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemPerformanceLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.PerformanceBaselineMonitor3StateBaseliningName);

            /// <summary>
            /// Web Page Monitor - Content Match Guid (Stored in MonitorType table)
            /// </summary>
            public const string WebPageMonitorContentMatchGuid = "58A017D7-CF0E-CA5D-40E0-2B668D8B198A";

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
            /// Caches the translated resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPrevious;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNext;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Create
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCreate;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MonitorType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonitorType;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ManagementPack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedManagementPack;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectDestinationManagementPack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectDestinationManagementPack;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  New
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNew;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectTheTypeOfMonitorToCreate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectTheTypeOfMonitorToCreate;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ExpandTheFoldersAndSelectAMonitorTypeToCreate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedExpandTheFoldersAndSelectAMonitorTypeToCreate;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Description
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDescription;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectAMonitorType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectAMonitorType;

            // -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Monitor a Windows Service monitor type
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonitorService;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Event Monitor - Single Event with Manual Reset monitor type
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEventMonitorSingleManual;

            /// ----------------------------------------------------------------------------- 
            /// <summary> 1248             /// <summary> 
            /// Caches the translated resource string for: SNMP Trap Monitor 
            /// </summary> 
            /// ----------------------------------------------------------------------------- 
            private static string cachedSNMPTrapMonitor;

            /// ----------------------------------------------------------------------------- 
            /// <summary> 1248             /// <summary> 
            /// Caches the translated resource string for: SNMP Probe Monitor 
            /// </summary> 
            /// ----------------------------------------------------------------------------- 
            private static string cachedSNMPProbeMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: EventMonitorSingleEventAutoResetName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEventMonitorSingleEventAutoReset;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: EventMonitorSingleEventAutoEventName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEventMonitorSingleEventEventReset;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: PerformanceBaselineMonitor3StateBaseliningName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPerformanceBaselineMonitor3StateBaselining;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Event Monitor - Correlated Event with Manual Reset monitor type
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCorrelatedEventManualReset;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Event Monitor - Correlated Event with Timer Reset monitor type
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCorrelatedEventTimerReset;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Event Monitor - Correlated Event with Event Reset monitor type
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCorrelatedEventEventReset;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Event Monitor - Correlated Missing Event with Manual Reset monitor type
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCorrelatedMissingEventManualReset;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Event Monitor - Correlated Missing Event with Timer Reset monitor type
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCorrelatedMissingEventTimerReset;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Event Monitor - Correlated Missing Event with Event Reset monitor type
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCorrelatedMissingEventEventReset;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Event Monitor - Missing Event with Manual Reset monitor type
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMissingEventManualReset;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Event Monitor - Missing Event with Timer Reset monitor type
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMissingEventTimerReset;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Event Monitor - Missing Event with Event Reset monitor type
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMissingEventEventReset;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Event Monitor - Repeated Event with Manual Reset monitor type
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRepeatedEventManualReset;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Event Monitor - Repeated Event with Timer Reset monitor type
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRepeatedEventTimerReset;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Event Monitor - Repeated Event with Event Reset monitor type
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRepeatedEventEventReset;
            
            /// <summary>
            /// Caches the translated resource string for: Web Page Monitor - Content Match
            /// </summary>
            private static string cachedWebPageMonitorContentMatchGuid;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: WMI Event Monitor - Single Event with Manual Reset monitor type
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWMIEventSingleManualReset;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: WMI Event Monitor - Single Event with Timer Reset monitor type
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWMIEventSingleTimerReset;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: WMI Event Monitor - Single Event with Event Reset monitor type
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWMIEventSingleEventReset;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: WMI Event Monitor - Repeated Event with Manual Reset monitor type
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWMIEventRepeatedManualReset;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: WMI Event Monitor - Repeated Event with Timer Reset monitor type
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWMIEventRepeatedTimerReset;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: WMI Event Monitor - Repeated Event with Event Reset monitor type
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWMIEventRepeatedEventReset;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: WMI Performance Monitor - Average Threshold monitor type
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWMIPerformanceAverageThreshold;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: WMI Performance Monitor - Consecutive Threshold monitor type
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWMIPerformanceConsecutiveThreshold;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: WMI Performance Monitor - Delta Threshold monitor type
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWMIPerformanceDeltaThreshold;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: WMI Performance Monitor - Simple Threshold monitor type
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWMIPerformanceSimpleThreshold;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: WMI Performance Monitor - Doulbe Threshold monitor type
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWMIPerformanceDoulbeThreshold;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Windows Performance Monitor - 2-state Above Self Tuning Threshold monitor type
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWindowsPerformance2StateAboveSelfTuningThreshold;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Windows Performance Monitor - 2-state Baselining Self Tuning Threshold monitor type
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWindowsPerformance2StateBaseliningSelfTuningThreshold;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Windows Performance Monitor - 2-state Below Self Tuning Threshold monitor type
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWindowsPerformance2StateBelowSelfTuningThreshold;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Windows Performance Monitor - 3-state Baselining Self Tuning Threshold monitor type
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWindowsPerformance3StateBaseliningSelfTuningThreshold;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Windows Performance Monitor - Average Static Single Threshold monitor type
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWindowsPerformanceAverageThreshold;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Windows Performance Monitor - Consecutive Samples Over Threshold monitor type
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWindowsPerformanceConsecutiveThreshold;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Windows Performance Monitor - Delta Threshold monitor type
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWindowsPerformanceDeltaThreshold;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Windows Performance Monitor - Simple Threshold monitor type
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWindowsPerformanceSimpleThreshold;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Windows Performance Monitor - Double Threshold monitor type
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWindowsPerformanceDoubleThreshold;

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/10/2006 Created
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
            /// Exposes access to the Previous translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/10/2006 Created
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
            /// Exposes access to the Next translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/10/2006 Created
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
            /// Exposes access to the Create translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/10/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Create
            {
                get
                {
                    if ((cachedCreate == null))
                    {
                        cachedCreate = CoreManager.MomConsole.GetIntlStr(ResourceCreate);
                    }
                    return cachedCreate;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/10/2006 Created
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
            /// Exposes access to the MonitorType translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/10/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MonitorType
            {
                get
                {
                    if ((cachedMonitorType == null))
                    {
                        cachedMonitorType = CoreManager.MomConsole.GetIntlStr(ResourceMonitorType);
                    }
                    return cachedMonitorType;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ManagementPack translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/10/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ManagementPack
            {
                get
                {
                    if ((cachedManagementPack == null))
                    {
                        cachedManagementPack = CoreManager.MomConsole.GetIntlStr(ResourceManagementPack);
                    }
                    return cachedManagementPack;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectDestinationManagementPack translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/10/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectDestinationManagementPack
            {
                get
                {
                    if ((cachedSelectDestinationManagementPack == null))
                    {
                        cachedSelectDestinationManagementPack = CoreManager.MomConsole.GetIntlStr(ResourceSelectDestinationManagementPack);
                    }
                    return cachedSelectDestinationManagementPack;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the New translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/10/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string New
            {
                get
                {
                    if ((cachedNew == null))
                    {
                        cachedNew = CoreManager.MomConsole.GetIntlStr(ResourceNew);
                    }
                    return cachedNew;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectTheTypeOfMonitorToCreate translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/10/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectTheTypeOfMonitorToCreate
            {
                get
                {
                    if ((cachedSelectTheTypeOfMonitorToCreate == null))
                    {
                        cachedSelectTheTypeOfMonitorToCreate = CoreManager.MomConsole.GetIntlStr(ResourceSelectTheTypeOfMonitorToCreate);
                    }
                    return cachedSelectTheTypeOfMonitorToCreate;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ExpandTheFoldersAndSelectAMonitorTypeToCreate translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/10/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ExpandTheFoldersAndSelectAMonitorTypeToCreate
            {
                get
                {
                    if ((cachedExpandTheFoldersAndSelectAMonitorTypeToCreate == null))
                    {
                        cachedExpandTheFoldersAndSelectAMonitorTypeToCreate = CoreManager.MomConsole.GetIntlStr(ResourceExpandTheFoldersAndSelectAMonitorTypeToCreate);
                    }
                    return cachedExpandTheFoldersAndSelectAMonitorTypeToCreate;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Description translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/10/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Description
            {
                get
                {
                    if ((cachedDescription == null))
                    {
                        cachedDescription = CoreManager.MomConsole.GetIntlStr(ResourceDescription);
                    }
                    return cachedDescription;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/10/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Help
            {
                get
                {
                    if ((cachedHelp == null))
                    {
                        cachedHelp = CoreManager.MomConsole.GetIntlStr(ResourceHelp);
                    }
                    return cachedHelp;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectAMonitorType translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/10/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectAMonitorType
            {
                get
                {
                    if ((cachedSelectAMonitorType == null))
                    {
                        cachedSelectAMonitorType = CoreManager.MomConsole.GetIntlStr(ResourceSelectAMonitorType);
                    }
                    return cachedSelectAMonitorType;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Monitor a Windows Service monitor type translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 22Aug05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MonitorService
            {
                get
                {
                    if ((cachedMonitorService == null))
                    {
                        cachedMonitorService = Utilities.GetUnitMonitorTypeName(NTServiceMonitorGuid);
                    }

                    return cachedMonitorService;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Event Monitor - Single Event with Manual Reset 
            /// monitor type translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 08Sep05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EventMonitorSingleManual
            {
                get
                {
                    if ((cachedEventMonitorSingleManual == null))
                    {
                        cachedEventMonitorSingleManual = Utilities.GetUnitMonitorTypeName(SingleEventManualResetGuid);
                    }

                    return cachedEventMonitorSingleManual;
                }
            }

            /// ----------------------------------------------------------------------------- 
            /// <summary>
            /// Exposes access to the SNMP Trap Monitor
            /// monitor type translated resource string 
            /// </summary> 
            /// <history> 
            /// </history> 
            /// ----------------------------------------------------------------------------- 
            public static string SNMPTrapMonitorName 
            { 
                get 
                { 
                    if ((cachedSNMPTrapMonitor == null)) 
                    {
                        cachedSNMPTrapMonitor = Utilities.GetUnitMonitorTypeName(SNMPTrapMonitorGuid); 
                     }

                    return cachedSNMPTrapMonitor; 
                 } 
            }

            /// ----------------------------------------------------------------------------- 
            /// <summary>
            /// Exposes access to the SNMP Probe Monitor
            /// monitor type translated resource string 
            /// </summary> 
            /// <history> 
            /// </history> 
            /// ----------------------------------------------------------------------------- 
            public static string SNMPProbeMonitorName
            {
                get
                {
                    if (cachedSNMPProbeMonitor == null)
                    {
                        cachedSNMPProbeMonitor = Utilities.GetUnitMonitorTypeName(SNMPProbeMonitorGuid);
                    }

                    return cachedSNMPProbeMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the PerformanceBaselineMonitor3StateBaselining
            /// monitor type translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 14JUN06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string PerformanceBaselineMonitor3StateBaselining
            {
                get
                {
                    if ((cachedPerformanceBaselineMonitor3StateBaselining == null))
                    {
                        cachedPerformanceBaselineMonitor3StateBaselining = Utilities.GetUnitMonitorTypeName(PerformanceBaselineMonitor3StateBaseliningGuid);
                    }

                    return cachedPerformanceBaselineMonitor3StateBaselining;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EventMonitorSingleEventAutoReset
            /// monitor type translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 14JUN06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EventMonitorSingleEventAutoReset
            {
                get
                {
                    if ((cachedEventMonitorSingleEventAutoReset == null))
                    {
                        cachedEventMonitorSingleEventAutoReset = Utilities.GetUnitMonitorTypeName(EventMonitorSingleEventAutoResetGuid);
                    }

                    return cachedEventMonitorSingleEventAutoReset;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EventMonitorSingleEventEventReset
            /// monitor type translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 14JUN06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EventMonitorSingleEventEventReset
            {
                get
                {
                    if ((cachedEventMonitorSingleEventEventReset == null))
                    {
                        cachedEventMonitorSingleEventEventReset = Utilities.GetUnitMonitorTypeName(EventMonitorSingleEventEventResetGuid);
                    }

                    return cachedEventMonitorSingleEventEventReset;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Web Page Monitor - Content Match 
            /// </summary>
            /// <history>
            /// 	[mbickle] 04OCT05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WebPageMonitorContentMatch
            {
                get
                {
                    if ((cachedWebPageMonitorContentMatchGuid == null))
                    {
                        //TODO: Need to get the GUID here. Currently just ommenting out the following line to fix a warning
                        //'Mom.Test.UI.Core.Common.Utilities.GetUnitMonitorTypeName(string)' is obsolete: 'Use GetUnitMonitorTypeName(Guid )'
                        //cachedWebPageMonitorContentMatchGuid = Utilities.GetUnitMonitorTypeName(WebPageMonitorContentMatchGuid);
                        cachedWebPageMonitorContentMatchGuid = null;
                    }

                    return cachedWebPageMonitorContentMatchGuid;
                }
            }
                       
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Event Monitor - Correlated Event with Manual Reset 
            /// monitor type translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 18April07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CorrelatedEventManualReset
            {
                get
                {
                    if ((cachedCorrelatedEventManualReset == null))
                    {
                        cachedCorrelatedEventManualReset = Utilities.GetUnitMonitorTypeName(CorrelatedEventManualResetGuid);
                    }

                    return cachedCorrelatedEventManualReset;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Event Monitor - Correlated Event with Timer Reset 
            /// monitor type translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 18April07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CorrelatedEventTimerReset
            {
                get
                {
                    if ((cachedCorrelatedEventTimerReset == null))
                    {
                        cachedCorrelatedEventTimerReset = Utilities.GetUnitMonitorTypeName(CorrelatedEventTimerResetGuid);
                    }

                    return cachedCorrelatedEventTimerReset;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Event Monitor - Correlated Event with Event Reset 
            /// monitor type translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 18April07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CorrelatedEventEventReset
            {
                get
                {
                    if ((cachedCorrelatedEventEventReset == null))
                    {
                        cachedCorrelatedEventEventReset = Utilities.GetUnitMonitorTypeName(CorrelatedEventEventResetGuid);
                    }

                    return cachedCorrelatedEventEventReset;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Event Monitor - Correlated Missing Event with Manual Reset 
            /// monitor type translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 18April07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CorrelatedMissingEventManualReset
            {
                get
                {
                    if ((cachedCorrelatedMissingEventManualReset == null))
                    {
                        cachedCorrelatedMissingEventManualReset = Utilities.GetUnitMonitorTypeName(CorrelatedMissingEventManualResetGuid);
                    }

                    return cachedCorrelatedMissingEventManualReset;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Event Monitor - Correlated Missing Event with Timer Reset 
            /// monitor type translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 18April07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CorrelatedMissingEventTimerReset
            {
                get
                {
                    if ((cachedCorrelatedMissingEventTimerReset == null))
                    {
                        cachedCorrelatedMissingEventTimerReset = Utilities.GetUnitMonitorTypeName(CorrelatedMissingEventTimerResetGuid);
                    }

                    return cachedCorrelatedMissingEventTimerReset;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Event Monitor - Correlated Missing Event with Event Reset 
            /// monitor type translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 18April07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CorrelatedMissingEventEventReset
            {
                get
                {
                    if ((cachedCorrelatedMissingEventEventReset == null))
                    {
                        cachedCorrelatedMissingEventEventReset = Utilities.GetUnitMonitorTypeName(CorrelatedMissingEventEventResetGuid);
                    }

                    return cachedCorrelatedMissingEventEventReset;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Event Monitor - Missing Event with Manual Reset 
            /// monitor type translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 18April07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MissingEventManualReset
            {
                get
                {
                    if ((cachedMissingEventManualReset == null))
                    {
                        cachedMissingEventManualReset = Utilities.GetUnitMonitorTypeName(MissingEventManualResetGuid);
                    }

                    return cachedMissingEventManualReset;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Event Monitor - Missing Event with Timer Reset 
            /// monitor type translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 18April07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MissingEventTimerReset
            {
                get
                {
                    if ((cachedMissingEventTimerReset == null))
                    {
                        cachedMissingEventTimerReset = Utilities.GetUnitMonitorTypeName(MissingEventTimerResetGuid);
                    }

                    return cachedMissingEventTimerReset;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Event Monitor - Missing Event with Event Reset 
            /// monitor type translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 18April07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MissingEventEventReset
            {
                get
                {
                    if ((cachedMissingEventEventReset == null))
                    {
                        cachedMissingEventEventReset = Utilities.GetUnitMonitorTypeName(MissingEventEventResetGuid);
                    }

                    return cachedMissingEventEventReset;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Event Monitor - Repeated Event with Manual Reset 
            /// monitor type translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 18April07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RepeatedEventManualReset
            {
                get
                {
                    if ((cachedRepeatedEventManualReset == null))
                    {
                        cachedRepeatedEventManualReset = Utilities.GetUnitMonitorTypeName(RepeatedEventManualResetGuid);
                    }

                    return cachedRepeatedEventManualReset;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Event Monitor - Repeated Event with Timer Reset 
            /// monitor type translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 18April07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RepeatedEventTimerReset
            {
                get
                {
                    if ((cachedRepeatedEventTimerReset == null))
                    {
                        cachedRepeatedEventTimerReset = Utilities.GetUnitMonitorTypeName(RepeatedEventTimerResetGuid);
                    }

                    return cachedRepeatedEventTimerReset;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Event Monitor - Repeated Event with Event Reset 
            /// monitor type translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 18April07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RepeatedEventEventReset
            {
                get
                {
                    if ((cachedRepeatedEventEventReset == null))
                    {
                        cachedRepeatedEventEventReset = Utilities.GetUnitMonitorTypeName(RepeatedEventEventResetGuid);
                    }

                    return cachedRepeatedEventEventReset;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WMI Event Monitor - Single Event with Manual Reset 
            /// monitor type translated resource string
            /// </summary>
            /// <history>
            /// 	[v-eryon] 12Septempber08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WMIEventSingleManualReset
            {
                get
                {
                    if ((cachedWMIEventSingleManualReset == null))
                    {
                        cachedWMIEventSingleManualReset = Utilities.GetUnitMonitorTypeName(WMIEventSingleManualResetGuid);
                    }

                    return cachedWMIEventSingleManualReset;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WMI Event Monitor - Single Event with Timer Reset 
            /// monitor type translated resource string
            /// </summary>
            /// <history>
            /// 	[v-eryon] 12Septempber08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WMIEventSingleTimerReset
            {
                get
                {
                    if ((cachedWMIEventSingleTimerReset == null))
                    {
                        cachedWMIEventSingleTimerReset = Utilities.GetUnitMonitorTypeName(WMIEventSingleTimerResetGuid);
                    }

                    return cachedWMIEventSingleTimerReset;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WMI Event Monitor - Single Event with Event Reset 
            /// monitor type translated resource string
            /// </summary>
            /// <history>
            /// 	[v-eryon] 12Septempber08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WMIEventSingleEventReset
            {
                get
                {
                    if ((cachedWMIEventSingleEventReset == null))
                    {
                        cachedWMIEventSingleEventReset = Utilities.GetUnitMonitorTypeName(WMIEventSingleEventResetGuid);
                    }

                    return cachedWMIEventSingleEventReset;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WMI Event Monitor - Repeated Event with Manual Reset 
            /// monitor type translated resource string
            /// </summary>
            /// <history>
            /// 	[v-eryon] 12Septempber08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WMIEventRepeatedManualReset
            {
                get
                {
                    if ((cachedWMIEventRepeatedManualReset == null))
                    {
                        cachedWMIEventRepeatedManualReset = Utilities.GetUnitMonitorTypeName(WMIEventRepeatedManualResetGuid);
                    }

                    return cachedWMIEventRepeatedManualReset;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WMI Event Monitor - Repeated Event with Timer Reset 
            /// monitor type translated resource string
            /// </summary>
            /// <history>
            /// 	[v-eryon] 12Septempber08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WMIEventRepeatedTimerReset
            {
                get
                {
                    if ((cachedWMIEventRepeatedTimerReset == null))
                    {
                        cachedWMIEventRepeatedTimerReset = Utilities.GetUnitMonitorTypeName(WMIEventRepeatedTimerResetGuid);
                    }

                    return cachedWMIEventRepeatedTimerReset;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WMI Event Monitor - Repeated Event with Event Reset 
            /// monitor type translated resource string
            /// </summary>
            /// <history>
            /// 	[v-eryon] 12Septempber08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WMIEventRepeatedEventReset
            {
                get
                {
                    if ((cachedWMIEventRepeatedEventReset == null))
                    {
                        cachedWMIEventRepeatedEventReset = Utilities.GetUnitMonitorTypeName(WMIEventRepeatedEventResetGuid);
                    }

                    return cachedWMIEventRepeatedEventReset;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WMI Performance Monitor - Average Threshold 
            /// monitor type translated resource string
            /// </summary>
            /// <history>
            /// 	[v-cheli] 23Dec08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WMIPerformanceAverageThreshold
            {
                get
                {
                    if ((cachedWMIPerformanceAverageThreshold == null))
                    {
                        cachedWMIPerformanceAverageThreshold = Utilities.GetUnitMonitorTypeName(WMIPerformanceAverageThresholdGuid);
 
                    }

                    return cachedWMIPerformanceAverageThreshold;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WMI Performance Monitor - Consecutive Threshold
            /// monitor type translated resource string
            /// </summary>
            /// <history>
            /// 	[v-cheli] 23Dec08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WMIPerformanceConsecutiveThreshold
            {
                get
                {
                    if ((cachedWMIPerformanceConsecutiveThreshold == null))
                    {
                        cachedWMIPerformanceConsecutiveThreshold = Utilities.GetUnitMonitorTypeName(WMIPerformanceConsecutiveThresholdGuid);

                    }

                    return cachedWMIPerformanceConsecutiveThreshold;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WMI Performance Monitor - Delta Threshold
            /// monitor type translated resource string
            /// </summary>
            /// <history>
            /// 	[v-cheli] 23Dec08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WMIPerformanceDeltaThreshold
            {
                get
                {
                    if ((cachedWMIPerformanceDeltaThreshold == null))
                    {
                        cachedWMIPerformanceDeltaThreshold = Utilities.GetUnitMonitorTypeName(WMIPerformanceDeltaThresholdGuid);

                    }

                    return cachedWMIPerformanceDeltaThreshold;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WMI Performance Monitor - Simple Threshold
            /// monitor type translated resource string
            /// </summary>
            /// <history>
            /// 	[v-cheli] 23Dec08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WMIPerformanceSimpleThreshold
            {
                get
                {
                    if ((cachedWMIPerformanceSimpleThreshold == null))
                    {
                        cachedWMIPerformanceSimpleThreshold = Utilities.GetUnitMonitorTypeName(WMIPerformanceSimpleThresholdGuid);

                    }

                    return cachedWMIPerformanceSimpleThreshold;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WMI Performance Monitor - Doulbe Threshold
            /// monitor type translated resource string
            /// </summary>
            /// <history>
            /// 	[v-cheli] 23Dec08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WMIPerformanceDoulbeThreshold
            {
                get
                {
                    if ((cachedWMIPerformanceDoulbeThreshold == null))
                    {
                        cachedWMIPerformanceDoulbeThreshold = Utilities.GetUnitMonitorTypeName(WMIPerformanceDoulbeThresholdGuid);

                    }

                    return cachedWMIPerformanceDoulbeThreshold;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Windows Performance Monitor - 2-state Above Self Tuning Threshold
            /// monitor type translated resource string
            /// </summary>
            /// <history>
            /// 	[v-dayow] 23Nov09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WindowsPerformance2StateAboveThreshold
            {
                get
                {
                    if ((cachedWindowsPerformance2StateAboveSelfTuningThreshold == null))
                    {
                        cachedWindowsPerformance2StateAboveSelfTuningThreshold = Utilities.GetUnitMonitorTypeName(WindowsPerformance2StateAboveSelfTuningThresholdGuid);

                    }

                    return cachedWindowsPerformance2StateAboveSelfTuningThreshold;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Windows Performance Monitor - 2-state Baselining Self Tuning Threshold
            /// monitor type translated resource string
            /// </summary>
            /// <history>
            /// 	[v-dayow] 23Nov09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WindowsPerformance2StateBaseliningThreshold
            {
                get
                {
                    if ((cachedWindowsPerformance2StateBaseliningSelfTuningThreshold == null))
                    {
                        cachedWindowsPerformance2StateBaseliningSelfTuningThreshold = Utilities.GetUnitMonitorTypeName(WindowsPerformance2StateBaseliningSelfTuningThresholdGuid);

                    }

                    return cachedWindowsPerformance2StateBaseliningSelfTuningThreshold;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Windows Performance Monitor - 2-state Below Self Tuning Threshold
            /// monitor type translated resource string
            /// </summary>
            /// <history>
            /// 	[v-dayow] 23Nov09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WindowsPerformance2StateBelowThreshold
            {
                get
                {
                    if ((cachedWindowsPerformance2StateBelowSelfTuningThreshold == null))
                    {
                        cachedWindowsPerformance2StateBelowSelfTuningThreshold = Utilities.GetUnitMonitorTypeName(WindowsPerformance2StateBelowSelfTuningThresholdGuid);

                    }

                    return cachedWindowsPerformance2StateBelowSelfTuningThreshold;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Windows Performance Monitor - 3-state Baselining Self Tuning Threshold
            /// monitor type translated resource string
            /// </summary>
            /// <history>
            /// 	[v-dayow] 23Nov09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WindowsPerformance3StateBaseliningThreshold
            {
                get
                {
                    if ((cachedWindowsPerformance3StateBaseliningSelfTuningThreshold == null))
                    {
                        cachedWindowsPerformance3StateBaseliningSelfTuningThreshold = Utilities.GetUnitMonitorTypeName(WindowsPerformance3StateBaseliningSelfTuningThresholdGuid);

                    }

                    return cachedWindowsPerformance3StateBaseliningSelfTuningThreshold;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Windows Performance Monitor - Average Threshold
            /// monitor type translated resource string
            /// </summary>
            /// <history>
            /// 	[v-dayow] 23Nov09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WindowsPerformanceAverageThreshold
            {
                get
                {
                    if ((cachedWindowsPerformanceAverageThreshold == null))
                    {
                        cachedWindowsPerformanceAverageThreshold = Utilities.GetUnitMonitorTypeName(WindowsPerformanceAverageThresholdGuid);

                    }

                    return cachedWindowsPerformanceAverageThreshold;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Windows Performance Monitor - Consecutive Threshold
            /// monitor type translated resource string
            /// </summary>
            /// <history>
            /// 	[v-dayow] 23Nov09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WindowsPerformanceConsecutiveThreshold
            {
                get
                {
                    if ((cachedWindowsPerformanceConsecutiveThreshold == null))
                    {
                        cachedWindowsPerformanceConsecutiveThreshold = Utilities.GetUnitMonitorTypeName(WindowsPerformanceConsecutiveSamplesOverThresholdGuid);

                    }

                    return cachedWindowsPerformanceConsecutiveThreshold;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Windows Performance Monitor - Delta Threshold
            /// monitor type translated resource string
            /// </summary>
            /// <history>
            /// 	[v-dayow] 23Nov09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WindowsPerformanceDeltaThreshold
            {
                get
                {
                    if ((cachedWindowsPerformanceDeltaThreshold == null))
                    {
                        cachedWindowsPerformanceDeltaThreshold = Utilities.GetUnitMonitorTypeName(WindowsPerformanceDeltaThresholdGuid);

                    }

                    return cachedWindowsPerformanceDeltaThreshold;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Windows Performance Monitor - Double Threshold
            /// monitor type translated resource string
            /// </summary>
            /// <history>
            /// 	[v-dayow] 23Nov09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WindowsPerformanceDoubleThreshold
            {
                get
                {
                    if ((cachedWindowsPerformanceDoubleThreshold == null))
                    {
                        cachedWindowsPerformanceDoubleThreshold = Utilities.GetUnitMonitorTypeName(WindowsPerformanceDoulbeThresholdGuid);

                    }

                    return cachedWindowsPerformanceDoubleThreshold;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Windows Performance Monitor - Simple Threshold
            /// monitor type translated resource string
            /// </summary>
            /// <history>
            /// 	[v-dayow] 23Nov09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WindowsPerformanceSimpleThreshold
            {
                get
                {
                    if ((cachedWindowsPerformanceSimpleThreshold == null))
                    {
                        cachedWindowsPerformanceSimpleThreshold = Utilities.GetUnitMonitorTypeName(WindowsPerformanceSimpleThresholdGuid);

                    }

                    return cachedWindowsPerformanceSimpleThreshold;
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
        /// 	[ruhim] 3/10/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for PreviousButton
            /// </summary>
            public const string PreviousButton = "previousButton";

            /// <summary>
            /// Control ID for NextButton
            /// </summary>
            public const string NextButton = "nextButton";

            /// <summary>
            /// Control ID for CreateButton
            /// </summary>
            public const string CreateButton = "commitButton";

            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";

            /// <summary>
            /// Control ID for MonitorTypeStaticControl
            /// </summary>
            public const string MonitorTypeStaticControl = "textLinkLabel";

            /// <summary>
            /// Control ID for ManagementPackStaticControl
            /// </summary>
            public const string ManagementPackStaticControl = "pageSectionLabel1";

            /// <summary>
            /// Control ID for SelectDestinationManagementPackStaticControl
            /// </summary>
            public const string SelectDestinationManagementPackStaticControl = "label1";

            /// <summary>
            /// Control ID for NewButton
            /// </summary>
            public const string NewButton = "newmpButton";

            /// <summary>
            /// Control ID for SelectDestinationManagementPackComboBox
            /// </summary>
            public const string SelectDestinationManagementPackComboBox = "comboBoxMp";

            /// <summary>
            /// Control ID for SelectTheTypeOfMonitorToCreateStaticControl
            /// </summary>
            public const string SelectTheTypeOfMonitorToCreateStaticControl = "pageSectionLabel1";

            /// <summary>
            /// Control ID for ExpandTheFoldersAndSelectAMonitorTypeToCreateStaticControl
            /// </summary>
            public const string ExpandTheFoldersAndSelectAMonitorTypeToCreateStaticControl = "descriptionTextLabel";

            /// <summary>
            /// Control ID for DescriptionStaticControl
            /// </summary>
            public const string DescriptionStaticControl = "descLabel";

            /// <summary>
            /// Control ID for SelectAMonitorTypeBelowTreeView
            /// </summary>
            public const string SelectAMonitorTypeBelowTreeView = "monitorTypesTree";

            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";

            /// <summary>
            /// Control ID for SelectAMonitorTypeStaticControl
            /// </summary>
            public const string SelectAMonitorTypeStaticControl = "headerLabel";
        }
        #endregion
    }
}
