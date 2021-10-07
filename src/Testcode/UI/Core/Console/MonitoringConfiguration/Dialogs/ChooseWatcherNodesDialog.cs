// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ChooseWatcherNodesDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[faizalk] 3/25/2006 Created
//  [faizalk] 4/17/2006 Use resource string for dialog title
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IChooseWatcherNodesDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IChooseWatcherNodesDialogControls, for ChooseWatcherNodesDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[faizalk] 3/25/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IChooseWatcherNodesDialogControls
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
        /// Read-only property to access ComponentTypeStaticControl
        /// </summary>
        StaticControl ComponentTypeStaticControl
        {
            get;
        }
                               
        /// <summary>
        /// Read-only property to access ChooseMOMManagedComputersToActAsWatcherNodesFromDifferentLocationsStaticControl
        /// </summary>
        StaticControl ChooseMOMManagedComputersToActAsWatcherNodesFromDifferentLocationsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ComboBox0
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        ComboBox UnitsComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RunThisQueryEveryComboBox
        /// </summary>
        EditComboBox RunThisQueryEveryComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RunThisQueryEveryStaticControl
        /// </summary>
        StaticControl RunThisQueryEveryStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WatcherNodeStaticControl2
        /// </summary>
        StaticControl WatcherNodeStaticControl2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ManagementPackDetailsListView
        /// </summary>
        ListView ManagementPackDetailsListView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectOneOrMoreMOMManagedComputersStaticControl
        /// </summary>
        StaticControl SelectOneOrMoreMOMManagedComputersStaticControl
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
       
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add dialog functionality description here.
    /// </summary>
    /// <history>
    /// 	[faizalk] 3/25/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ChooseWatcherNodesDialog : Dialog, IChooseWatcherNodesDialogControls
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
        /// Cache to hold a reference to ComponentTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedComponentTypeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ChooseMOMManagedComputersToActAsWatcherNodesFromDifferentLocationsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedChooseMOMManagedComputersToActAsWatcherNodesFromDifferentLocationsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ComboBox0 of type ComboBox
        /// </summary>
        private ComboBox cachedUnitsComboBox;
        
        /// <summary>
        /// Cache to hold a reference to RunThisQueryEveryComboBox of type ComboBox
        /// </summary>
        private EditComboBox cachedRunThisQueryEveryComboBox;
        
        /// <summary>
        /// Cache to hold a reference to RunThisQueryEveryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRunThisQueryEveryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to WatcherNodeStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedWatcherNodeStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to ManagementPackDetailsListView of type ListView
        /// </summary>
        private ListView cachedManagementPackDetailsListView;
        
        /// <summary>
        /// Cache to hold a reference to SelectOneOrMoreMOMManagedComputersStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectOneOrMoreMOMManagedComputersStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ChooseWatcherNodesDialog of type Mom.Test.UI.Core.Console.MomConsoleApp
        /// </param>
        /// <history>
        /// 	[faizalk] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ChooseWatcherNodesDialog(Mom.Test.UI.Core.Console.MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IChooseWatcherNodesDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[faizalk] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IChooseWatcherNodesDialogControls Controls
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
        ///  Routine to set/get the text in control ComboBox0
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string UnitsComboBoxText
        {
            get
            {
                return this.Controls.UnitsComboBox.Text;
            }
            
            set
            {
                this.Controls.UnitsComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control RunThisQueryEvery
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string RunThisQueryEveryText
        {
            get
            {
                return this.Controls.RunThisQueryEveryComboBox.Text;
            }
            
            set
            {
                this.Controls.RunThisQueryEveryComboBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IChooseWatcherNodesDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, ChooseWatcherNodesDialog.ControlIDs.PreviousButton);
                }
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IChooseWatcherNodesDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, ChooseWatcherNodesDialog.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IChooseWatcherNodesDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, ChooseWatcherNodesDialog.ControlIDs.CreateButton);
                }
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IChooseWatcherNodesDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ChooseWatcherNodesDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ComponentTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IChooseWatcherNodesDialogControls.ComponentTypeStaticControl
        {
            get
            {
                if ((this.cachedComponentTypeStaticControl == null))
                {
                    this.cachedComponentTypeStaticControl = new StaticControl(this, ChooseWatcherNodesDialog.ControlIDs.ComponentTypeStaticControl);
                }
                return this.cachedComponentTypeStaticControl;
            }
        }
                                        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ChooseMOMManagedComputersToActAsWatcherNodesFromDifferentLocationsStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IChooseWatcherNodesDialogControls.ChooseMOMManagedComputersToActAsWatcherNodesFromDifferentLocationsStaticControl
        {
            get
            {
                if ((this.cachedChooseMOMManagedComputersToActAsWatcherNodesFromDifferentLocationsStaticControl == null))
                {
                    this.cachedChooseMOMManagedComputersToActAsWatcherNodesFromDifferentLocationsStaticControl = new StaticControl(this, ChooseWatcherNodesDialog.ControlIDs.ChooseMOMManagedComputersToActAsWatcherNodesFromDifferentLocationsStaticControl);
                }
                return this.cachedChooseMOMManagedComputersToActAsWatcherNodesFromDifferentLocationsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ComboBox0 control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IChooseWatcherNodesDialogControls.UnitsComboBox
        {
            get
            {
                if ((this.cachedUnitsComboBox == null))
                {
                    this.cachedUnitsComboBox = new ComboBox(this, ChooseWatcherNodesDialog.ControlIDs.UnitsComboBox);
                }
                return this.cachedUnitsComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RunThisQueryEveryComboBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IChooseWatcherNodesDialogControls.RunThisQueryEveryComboBox
        {
            get
            {
                if ((this.cachedRunThisQueryEveryComboBox == null))
                {
                    this.cachedRunThisQueryEveryComboBox = new EditComboBox(this);
                }
                return this.cachedRunThisQueryEveryComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RunThisQueryEveryStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IChooseWatcherNodesDialogControls.RunThisQueryEveryStaticControl
        {
            get
            {
                if ((this.cachedRunThisQueryEveryStaticControl == null))
                {
                    this.cachedRunThisQueryEveryStaticControl = new StaticControl(this, ChooseWatcherNodesDialog.ControlIDs.RunThisQueryEveryStaticControl);
                }
                return this.cachedRunThisQueryEveryStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WatcherNodeStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IChooseWatcherNodesDialogControls.WatcherNodeStaticControl2
        {
            get
            {
                if ((this.cachedWatcherNodeStaticControl2 == null))
                {
                    this.cachedWatcherNodeStaticControl2 = new StaticControl(this, ChooseWatcherNodesDialog.ControlIDs.WatcherNodeStaticControl2);
                }
                return this.cachedWatcherNodeStaticControl2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementPackDetailsListView control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IChooseWatcherNodesDialogControls.ManagementPackDetailsListView
        {
            get
            {
                if ((this.cachedManagementPackDetailsListView == null))
                {
                    this.cachedManagementPackDetailsListView = new ListView(this, ChooseWatcherNodesDialog.ControlIDs.ManagementPackDetailsListView);
                }
                return this.cachedManagementPackDetailsListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectOneOrMoreMOMManagedComputersStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IChooseWatcherNodesDialogControls.SelectOneOrMoreMOMManagedComputersStaticControl
        {
            get
            {
                if ((this.cachedSelectOneOrMoreMOMManagedComputersStaticControl == null))
                {
                    this.cachedSelectOneOrMoreMOMManagedComputersStaticControl = new StaticControl(this, ChooseWatcherNodesDialog.ControlIDs.SelectOneOrMoreMOMManagedComputersStaticControl);
                }
                return this.cachedSelectOneOrMoreMOMManagedComputersStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IChooseWatcherNodesDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, ChooseWatcherNodesDialog.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/25/2006 Created
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
        /// 	[faizalk] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNext()
        {
            this.Controls.NextButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Create
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/25/2006 Created
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
        /// 	[faizalk] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">Mom.Test.UI.Core.Console.MomConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[faizalk] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(Mom.Test.UI.Core.Console.MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(app.GetIntlStr(Strings.DialogTitle), StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
            }
            
            catch (Exceptions.WindowNotFoundException)
            {
                // TODO:  Uncomment the following code and apply the appropriate command for invoking the dialog.
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
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure

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
        /// 	[faizalk] 3/25/2006 Created
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
            private const string ResourceDialogTitle = ";Add Monitoring Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Common.PageCommonResources;TemplateWizard";
            
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
            private const string ResourceCreate = ";Create;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagem" +
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
            /// Contains resource string for:  ComponentType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceComponentType = ";Component Type;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.Enterpris" +
                "eManagement.Internal.UI.Authoring.Pages.TemplateListPage;$this.NavigationText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  GeneralProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneralProperties = ";General Properties;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.Enter" +
                "priseManagement.Internal.UI.Authoring.Pages.NameAndDescriptionPage;$this.NavigationT" +
                "ext";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WebAddress
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceWebAddress = "Web Address";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WatcherNode
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWatcherNode = ";Watcher Node;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseM" +
                "anagement.Internal.UI.Authoring.Pages.ChooseWatcherNodesPage;$this." +
                "NavigationText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Summary
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSummary = ";Summary;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.Administration.AdminResources;SummaryTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ChooseMOMManagedComputersToActAsWatcherNodesFromDifferentLocations
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceChooseMOMManagedComputersToActAsWatcherNodesFromDifferentLocations = ";Choose MOM managed computers to act as watcher nodes from different locations.;M" +
                "anagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement." +
                "Internal.UI.Authoring.Pages.WatcherNodeChooserControl;labelDesc" +
                "ription.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RunThisQueryEvery
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRunThisQueryEvery = ";&Run this query every:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.E" +
                "nterpriseManagement.Internal.UI.Authoring.Pages.WatcherNode" +
                "ChooserControl;labelInterval.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WatcherNode2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWatcherNode2 = ";Watcher node;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseM" +
                "anagement.Internal.UI.Authoring.Pages.WatcherNodeChooserCon" +
                "trol;pageSectionLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectOneOrMoreMOMManagedComputers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectOneOrMoreMOMManagedComputers = ";&Select one or more MOM managed computers:;ManagedString;Microsoft.MOM.UI.Compon" +
                "ents.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages." +
                "WatcherNodeChooserControl;selectNodesLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mo" +
                "m.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ChooseWatcherNodes
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceChooseWatcherNodes = "Choose Watcher Nodes";
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
            /// Caches the translated resource string for:  ComponentType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedComponentType;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  GeneralProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneralProperties;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WebAddress
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWebAddress;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WatcherNode
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWatcherNode;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Summary
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSummary;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ChooseMOMManagedComputersToActAsWatcherNodesFromDifferentLocations
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedChooseMOMManagedComputersToActAsWatcherNodesFromDifferentLocations;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RunThisQueryEvery
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRunThisQueryEvery;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WatcherNode2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWatcherNode2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectOneOrMoreMOMManagedComputers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectOneOrMoreMOMManagedComputers;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ChooseWatcherNodes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedChooseWatcherNodes;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/25/2006 Created
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
            /// 	[faizalk] 3/25/2006 Created
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
            /// 	[faizalk] 3/25/2006 Created
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
            /// 	[faizalk] 3/25/2006 Created
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
            /// 	[faizalk] 3/25/2006 Created
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
            /// Exposes access to the ComponentType translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/25/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ComponentType
            {
                get
                {
                    if ((cachedComponentType == null))
                    {
                        cachedComponentType = CoreManager.MomConsole.GetIntlStr(ResourceComponentType);
                    }
                    return cachedComponentType;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the GeneralProperties translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/25/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string GeneralProperties
            {
                get
                {
                    if ((cachedGeneralProperties == null))
                    {
                        cachedGeneralProperties = CoreManager.MomConsole.GetIntlStr(ResourceGeneralProperties);
                    }
                    return cachedGeneralProperties;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WebAddress translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/25/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WebAddress
            {
                get
                {
                    if ((cachedWebAddress == null))
                    {
                        cachedWebAddress = CoreManager.MomConsole.GetIntlStr(ResourceWebAddress);
                    }
                    return cachedWebAddress;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WatcherNode translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/25/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WatcherNode
            {
                get
                {
                    if ((cachedWatcherNode == null))
                    {
                        cachedWatcherNode = CoreManager.MomConsole.GetIntlStr(ResourceWatcherNode);
                    }
                    return cachedWatcherNode;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Summary translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/25/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Summary
            {
                get
                {
                    if ((cachedSummary == null))
                    {
                        cachedSummary = CoreManager.MomConsole.GetIntlStr(ResourceSummary);
                    }
                    return cachedSummary;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ChooseMOMManagedComputersToActAsWatcherNodesFromDifferentLocations translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/25/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ChooseMOMManagedComputersToActAsWatcherNodesFromDifferentLocations
            {
                get
                {
                    if ((cachedChooseMOMManagedComputersToActAsWatcherNodesFromDifferentLocations == null))
                    {
                        cachedChooseMOMManagedComputersToActAsWatcherNodesFromDifferentLocations = CoreManager.MomConsole.GetIntlStr(ResourceChooseMOMManagedComputersToActAsWatcherNodesFromDifferentLocations);
                    }
                    return cachedChooseMOMManagedComputersToActAsWatcherNodesFromDifferentLocations;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RunThisQueryEvery translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/25/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RunThisQueryEvery
            {
                get
                {
                    if ((cachedRunThisQueryEvery == null))
                    {
                        cachedRunThisQueryEvery = CoreManager.MomConsole.GetIntlStr(ResourceRunThisQueryEvery);
                    }
                    return cachedRunThisQueryEvery;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WatcherNode2 translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/25/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WatcherNode2
            {
                get
                {
                    if ((cachedWatcherNode2 == null))
                    {
                        cachedWatcherNode2 = CoreManager.MomConsole.GetIntlStr(ResourceWatcherNode2);
                    }
                    return cachedWatcherNode2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectOneOrMoreMOMManagedComputers translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/25/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectOneOrMoreMOMManagedComputers
            {
                get
                {
                    if ((cachedSelectOneOrMoreMOMManagedComputers == null))
                    {
                        cachedSelectOneOrMoreMOMManagedComputers = CoreManager.MomConsole.GetIntlStr(ResourceSelectOneOrMoreMOMManagedComputers);
                    }
                    return cachedSelectOneOrMoreMOMManagedComputers;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/25/2006 Created
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
            /// Exposes access to the ChooseWatcherNodes translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/25/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ChooseWatcherNodes
            {
                get
                {
                    if ((cachedChooseWatcherNodes == null))
                    {
                        cachedChooseWatcherNodes = CoreManager.MomConsole.GetIntlStr(ResourceChooseWatcherNodes);
                    }
                    return cachedChooseWatcherNodes;
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
        /// 	[faizalk] 3/25/2006 Created
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
            /// Control ID for ComponentTypeStaticControl
            /// </summary>
            public const string ComponentTypeStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for GeneralPropertiesStaticControl
            /// </summary>
            public const string GeneralPropertiesStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for WebAddressStaticControl
            /// </summary>
            public const string WebAddressStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for WatcherNodeStaticControl
            /// </summary>
            public const string WatcherNodeStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for SummaryStaticControl
            /// </summary>
            public const string SummaryStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ChooseMOMManagedComputersToActAsWatcherNodesFromDifferentLocationsStaticControl
            /// </summary>
            public const string ChooseMOMManagedComputersToActAsWatcherNodesFromDifferentLocationsStaticControl = "labelDescription";
            
            /// <summary>
            /// Control ID for ComboBox0
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string UnitsComboBox = "comboBoxUnit";
            
            /// <summary>
            /// Control ID for RunThisQueryEveryComboBox
            /// </summary>
            public const string RunThisQueryEveryComboBox = "numericDropDown";
            
            /// <summary>
            /// Control ID for RunThisQueryEveryStaticControl
            /// </summary>
            public const string RunThisQueryEveryStaticControl = "labelInterval";
            
            /// <summary>
            /// Control ID for WatcherNodeStaticControl2
            /// </summary>
            public const string WatcherNodeStaticControl2 = "pageSectionLabel";
            
            /// <summary>
            /// Control ID for ManagementPackDetailsListView
            /// </summary>
            public const string ManagementPackDetailsListView = "agentsListView";
            
            /// <summary>
            /// Control ID for SelectOneOrMoreMOMManagedComputersStaticControl
            /// </summary>
            public const string SelectOneOrMoreMOMManagedComputersStaticControl = "selectNodesLabel";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for ChooseWatcherNodesStaticControl
            /// </summary>
            public const string ChooseWatcherNodesStaticControl = "headerLabel";
        }
        #endregion
    }
}
