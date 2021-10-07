// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SelectTaskType.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[faizalk] 3/16/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Tasks.Wizards
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    //using Microsoft.Mom.Common;
    //IdUtil
    using Microsoft.EnterpriseManagement.Mom.Internal;
    
    #region Interface Definition - ISelectTaskTypeControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISelectTaskTypeControls, for SelectTaskType.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[faizalk] 3/16/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISelectTaskTypeControls
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
        /// Read-only property to access TaskTypeStaticControl
        /// </summary>
        StaticControl TaskTypeStaticControl
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
        /// Read-only property to access SelectTheTypeOfTaskToCreateStaticControl
        /// </summary>
        StaticControl SelectTheTypeOfTaskToCreateStaticControl
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
        /// Read-only property to access DescriptionStaticControl
        /// </summary>
        StaticControl DescriptionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectTheTypeOfTaskToCreateTreeView
        /// </summary>
        TreeView SelectTheTypeOfTaskToCreateTreeView
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
        /// Read-only property to access SelectATaskTypeStaticControl
        /// </summary>
        StaticControl SelectATaskTypeStaticControl
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
    /// 	[faizalk] 3/16/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SelectTaskType : Dialog, ISelectTaskTypeControls
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
        /// Cache to hold a reference to TaskTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTaskTypeStaticControl;
        
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
        /// Cache to hold a reference to SelectTheTypeOfTaskToCreateStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectTheTypeOfTaskToCreateStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to StaticControl0 of type StaticControl
        /// </summary>
        private StaticControl cachedStaticControl0;
        
        /// <summary>
        /// Cache to hold a reference to DescriptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDescriptionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectTheTypeOfTaskToCreateTreeView of type TreeView
        /// </summary>
        private TreeView cachedSelectTheTypeOfTaskToCreateTreeView;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectATaskTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectATaskTypeStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of SelectTaskType of type Maui.Core.App
        /// </param>
        /// <history>
        /// 	[faizalk] 3/16/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SelectTaskType(Maui.Core.App app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region ISelectTaskType Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[faizalk] 3/16/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISelectTaskTypeControls Controls
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
        /// 	[faizalk] 3/16/2006 Created
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
        /// 	[faizalk] 3/16/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectTaskTypeControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, SelectTaskType.ControlIDs.PreviousButton);
                }
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/16/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectTaskTypeControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, SelectTaskType.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/16/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectTaskTypeControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, SelectTaskType.ControlIDs.CreateButton);
                }
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/16/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectTaskTypeControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, SelectTaskType.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TaskTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/16/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectTaskTypeControls.TaskTypeStaticControl
        {
            get
            {
                if ((this.cachedTaskTypeStaticControl == null))
                {
                    this.cachedTaskTypeStaticControl = new StaticControl(this, SelectTaskType.ControlIDs.TaskTypeStaticControl);
                }
                return this.cachedTaskTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementPackStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/16/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectTaskTypeControls.ManagementPackStaticControl
        {
            get
            {
                if ((this.cachedManagementPackStaticControl == null))
                {
                    this.cachedManagementPackStaticControl = new StaticControl(this, SelectTaskType.ControlIDs.ManagementPackStaticControl);
                }
                return this.cachedManagementPackStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectDestinationManagementPackStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/16/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectTaskTypeControls.SelectDestinationManagementPackStaticControl
        {
            get
            {
                if ((this.cachedSelectDestinationManagementPackStaticControl == null))
                {
                    this.cachedSelectDestinationManagementPackStaticControl = new StaticControl(this, SelectTaskType.ControlIDs.SelectDestinationManagementPackStaticControl);
                }
                return this.cachedSelectDestinationManagementPackStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NewButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/16/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectTaskTypeControls.NewButton
        {
            get
            {
                if ((this.cachedNewButton == null))
                {
                    this.cachedNewButton = new Button(this, SelectTaskType.ControlIDs.NewButton);
                }
                return this.cachedNewButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectDestinationManagementPackComboBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/16/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ISelectTaskTypeControls.SelectDestinationManagementPackComboBox
        {
            get
            {
                if ((this.cachedSelectDestinationManagementPackComboBox == null))
                {
                    this.cachedSelectDestinationManagementPackComboBox = new ComboBox(this, SelectTaskType.ControlIDs.SelectDestinationManagementPackComboBox);
                }
                return this.cachedSelectDestinationManagementPackComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectTheTypeOfTaskToCreateStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/16/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectTaskTypeControls.SelectTheTypeOfTaskToCreateStaticControl
        {
            get
            {
                if ((this.cachedSelectTheTypeOfTaskToCreateStaticControl == null))
                {
                    this.cachedSelectTheTypeOfTaskToCreateStaticControl = new StaticControl(this, SelectTaskType.ControlIDs.SelectDestinationManagementPackStaticControl);
                }
                return this.cachedSelectTheTypeOfTaskToCreateStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StaticControl0 control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/16/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectTaskTypeControls.StaticControl0
        {
            get
            {
                if ((this.cachedStaticControl0 == null))
                {
                    this.cachedStaticControl0 = new StaticControl(this, SelectTaskType.ControlIDs.StaticControl0);
                }
                return this.cachedStaticControl0;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/16/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectTaskTypeControls.DescriptionStaticControl
        {
            get
            {
                if ((this.cachedDescriptionStaticControl == null))
                {
                    this.cachedDescriptionStaticControl = new StaticControl(this, SelectTaskType.ControlIDs.DescriptionStaticControl);
                }
                return this.cachedDescriptionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectTheTypeOfTaskToCreateTreeView control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/16/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TreeView ISelectTaskTypeControls.SelectTheTypeOfTaskToCreateTreeView
        {
            get
            {
                if ((this.cachedSelectTheTypeOfTaskToCreateTreeView == null))
                {
                    this.cachedSelectTheTypeOfTaskToCreateTreeView = new TreeView(this, SelectTaskType.ControlIDs.SelectTheTypeOfTaskToCreateTreeView);
                }
                return this.cachedSelectTheTypeOfTaskToCreateTreeView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/16/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectTaskTypeControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, SelectTaskType.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectATaskTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/16/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectTaskTypeControls.SelectATaskTypeStaticControl
        {
            get
            {
                if ((this.cachedSelectATaskTypeStaticControl == null))
                {
                    this.cachedSelectATaskTypeStaticControl = new StaticControl(this, SelectTaskType.ControlIDs.SelectATaskTypeStaticControl);
                }
                return this.cachedSelectATaskTypeStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/16/2006 Created
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
        /// 	[faizalk] 3/16/2006 Created
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
        /// 	[faizalk] 3/16/2006 Created
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
        /// 	[faizalk] 3/16/2006 Created
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
        /// 	[faizalk] 3/16/2006 Created
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
        ///  <param name="app">Maui.Core.App owning the dialog.</param>)
        /// <history>
        /// 	[faizalk] 3/16/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(Maui.Core.App app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
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
                                Strings.DialogTitle + "*",
                                StringMatchSyntax.WildCard,
                                WindowClassNames.WinForms10Window8, //WindowClassNames.Dialog,
                                StringMatchSyntax.WildCard, //StringMatchSyntax.ExactMatch,
                                app,
                                Timeout);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        //sleep to wait for window search
                        Sleeper.Delay(Timeout);

                        // log the outcome of this attempt
                        Core.Common.Utilities.LogMessage("Attempt "
                            + numberOfTries
                            + " of "
                            + MaxTries
                            + "...");
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
        /// 	[faizalk] 3/16/2006 Created
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
            private const string ResourceDialogTitle = ";Create Task Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Extensibility.UISDKResources;CreateTaskWizard";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrevious = ";< &Previous;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.Enterp" +
                "riseManagement.Mom.Internal.UI.PageFramework.WizardButtonsPanel;previousButton.T" +
                "ext";
            
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
            private const string ResourceCreate = ";C&reate;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft." +
                "EnterpriseManagement.Internal.UI.Authoring.Common.CommonResources;CreateMPAction" +
                "";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TaskType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTaskType = ";Task Type;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsof" +
                "t.EnterpriseManagement.Internal.UI.Authoring.Pages.ChooseTaskTypePage;$this.Navi" +
                "gationText";
            
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
            private const string ResourceSelectDestinationManagementPack = ";&Select destination management pack:;ManagedString;Microsoft.EnterpriseManagemen" +
                "t.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administr" +
                "ation.RunAsProfile.ProfileGeneral;labelSelectMp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  New
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNew = ";N&ew...;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAsProfile.RunAsProfi" +
                "leComboBoxControl;buttonProfile.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectTheTypeOfTaskToCreate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectTheTypeOfTaskToCreate = ";Select the type of task to create;ManagedString;Microsoft.EnterpriseManagement.U" +
                "I.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Choos" +
                "eTaskTypePage;pageSectionLabel1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Description
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDescription = ";Description:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AdminNodeDetailView;descrip" +
                "tionLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.Ent" +
                "erpriseManagement.Internal.UI.Authoring.Common.CommonResources;CommandHelp";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectATaskType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectATaskType = ";Select aTask Type;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;" +
                "Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ChooseTaskTypePage;$t" +
                "his.HeaderText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains GUID for: Microsoft.SystemCenter.TaskTemplates.Folder.AgentTasks 
            /// </summary>   
            /// -----------------------------------------------------------------------------
            private static Guid GUIDAgentTasksFolder = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterTaskTemplatesMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.AgentTasksFolder);

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains GUID for: Microsoft.SystemCenter.TaskTemplates.Folder.ConsoleTasks
            /// </summary>   
            /// -----------------------------------------------------------------------------
            private static Guid GUIDConsoleTasksFolder = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterTaskTemplatesMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.ConsoleTasksFolder);

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains GUID for: Microsoft.SystemCenter.TaskTemplates.CommandLineTask 
            /// </summary>   
            /// -----------------------------------------------------------------------------
            private static Guid GUIDAgentCommandLineTask = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterTaskTemplatesMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.AgentCommandLineTask);

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains GUID for: Microsoft.SystemCenter.TaskTemplates.ScriptTask 
            /// </summary>   
            /// -----------------------------------------------------------------------------
            private static Guid GUIDScriptTask = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterTaskTemplatesMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.ScriptTask);

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains GUID for: Microsoft.SystemCenter.TaskTemplates.ConsoleCommandLineTask
            /// </summary>   
            /// -----------------------------------------------------------------------------
            private static Guid GUIDConsoleCommandLineTask = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterTaskTemplatesMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.ConsoleCommandLineTask);

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains GUID for: Microsoft.SystemCenter.TaskTemplates.ConsoleAlertCommandLineTask
            /// </summary>   
            /// -----------------------------------------------------------------------------
            private static Guid GUIDConsoleAlertTask = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterTaskTemplatesMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.ConsoleAlertTask);

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains GUID for: Microsoft.SystemCenter.TaskTemplates.ConsoleEventCommandLineTask
            /// </summary>   
            /// -----------------------------------------------------------------------------
            private static Guid GUIDConsoleEventTask = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterTaskTemplatesMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.ConsoleEventTask);

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
            /// Caches the translated resource string for:  TaskType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTaskType;
            
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
            /// Caches the translated resource string for:  SelectTheTypeOfTaskToCreate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectTheTypeOfTaskToCreate;
            
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
            /// Caches the translated resource string for:  SelectATaskType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectATaskType;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the display name string for: Microsoft.SystemCenter.TaskTemplates.Folder.AgentTasks
            /// </summary>
            /// <history>
            /// 	[faizalk] 11APR07: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            private static string cachedAgentTasksFolder;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the display name string for: Microsoft.SystemCenter.TaskTemplates.Folder.ConsoleTasks
            /// </summary>
            /// <history>
            /// 	[faizalk] 11APR07: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            private static string cachedConsoleTasksFolder;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the display name string for: Microsoft.SystemCenter.TaskTemplates.CommandLineTask
            /// </summary>
            /// <history>
            /// 	[faizalk] 13FEB07: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            private static string cachedAgentCommandLineTask;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the display name string for: Microsoft.SystemCenter.TaskTemplates.ScriptTask
            /// </summary>
            /// <history>
            /// 	[faizalk] 13FEB07: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            private static string cachedScriptTask;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the display name string for: Microsoft.SystemCenter.TaskTemplates.ConsoleCommandLineTask
            /// </summary>
            /// <history>
            /// 	[faizalk] 13FEB07: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            private static string cachedConsoleCommandLineTask;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the display name string for: Microsoft.SystemCenter.TaskTemplates.ConsoleAlertCommandLineTask
            /// </summary>
            /// <history>
            /// 	[faizalk] 13FEB07: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            private static string cachedConsoleAlertTask;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the display name string for: Microsoft.SystemCenter.TaskTemplates.ConsoleEventCommandLineTask
            /// </summary>
            /// <history>
            /// 	[faizalk] 13FEB07: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            private static string cachedConsoleEventTask;

            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/16/2006 Created
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
            /// 	[faizalk] 3/16/2006 Created
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
            /// 	[faizalk] 3/16/2006 Created
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
            /// 	[faizalk] 3/16/2006 Created
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
            /// 	[faizalk] 3/16/2006 Created
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
            /// Exposes access to the TaskType translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/16/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TaskType
            {
                get
                {
                    if ((cachedTaskType == null))
                    {
                        cachedTaskType = CoreManager.MomConsole.GetIntlStr(ResourceTaskType);
                    }
                    return cachedTaskType;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ManagementPack translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/16/2006 Created
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
            /// 	[faizalk] 3/16/2006 Created
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
            /// 	[faizalk] 3/16/2006 Created
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
            /// Exposes access to the SelectTheTypeOfTaskToCreate translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/16/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectTheTypeOfTaskToCreate
            {
                get
                {
                    if ((cachedSelectTheTypeOfTaskToCreate == null))
                    {
                        cachedSelectTheTypeOfTaskToCreate = CoreManager.MomConsole.GetIntlStr(ResourceSelectTheTypeOfTaskToCreate);
                    }
                    return cachedSelectTheTypeOfTaskToCreate;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Description translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/16/2006 Created
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
            /// 	[faizalk] 3/16/2006 Created
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
            /// Exposes access to the SelectATaskType translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/16/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectATaskType
            {
                get
                {
                    if ((cachedSelectATaskType == null))
                    {
                        cachedSelectATaskType = CoreManager.MomConsole.GetIntlStr(ResourceSelectATaskType);
                    }
                    return cachedSelectATaskType;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: Microsoft.SystemCenter.TaskTemplates.Folder.AgentTasks
            /// </summary>
            /// <history>
            /// 	[faizalk] 11APR07: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AgentTasksFolder
            {
                get
                {
                    if ((cachedAgentTasksFolder == null))
                    {
                        cachedAgentTasksFolder = Common.Utilities.GetMonitoringFolderName(GUIDAgentTasksFolder);
                    }

                    return cachedAgentTasksFolder;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: Microsoft.SystemCenter.TaskTemplates.Folder.ConsoleTasks
            /// </summary>
            /// <history>
            /// 	[faizalk] 11APR07: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConsoleTasksFolder
            {
                get
                {
                    if ((cachedConsoleTasksFolder == null))
                    {
                        cachedConsoleTasksFolder = Common.Utilities.GetMonitoringFolderName(GUIDConsoleTasksFolder);
                    }

                    return cachedConsoleTasksFolder;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: Microsoft.SystemCenter.TaskTemplates.CommandLineTask
            /// </summary>
            /// <history>
            /// 	[faizalk] 13FEB07: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AgentCommandLineTask
            {
                get
                {
                    if ((cachedAgentCommandLineTask == null))
                    {
                        cachedAgentCommandLineTask = Common.Utilities.GetMonitoringTemplateName(GUIDAgentCommandLineTask);
                    }

                    return cachedAgentCommandLineTask;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: Microsoft.SystemCenter.TaskTemplates.ScriptTask
            /// </summary>
            /// <history>
            /// 	[faizalk] 13FEB07: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ScriptTask
            {
                get
                {
                    if ((cachedScriptTask == null))
                    {
                        cachedScriptTask = Common.Utilities.GetMonitoringTemplateName(GUIDScriptTask);
                    }

                    return cachedScriptTask;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: Microsoft.SystemCenter.TaskTemplates.ConsoleCommandLineTask
            /// </summary>
            /// <history>
            /// 	[faizalk] 13FEB07: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConsoleCommandLineTask
            {
                get
                {
                    if ((cachedConsoleCommandLineTask == null))
                    {
                        cachedConsoleCommandLineTask = Common.Utilities.GetMonitoringTemplateName(GUIDConsoleCommandLineTask);
                    }

                    return cachedConsoleCommandLineTask;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: Microsoft.SystemCenter.TaskTemplates.ConsoleAlertCommandLineTask
            /// </summary>
            /// <history>
            /// 	[faizalk] 13FEB07: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConsoleAlertTask
            {
                get
                {
                    if ((cachedConsoleAlertTask == null))
                    {
                        cachedConsoleAlertTask = Common.Utilities.GetMonitoringTemplateName(GUIDConsoleAlertTask);
                    }

                    return cachedConsoleAlertTask;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: Microsoft.SystemCenter.TaskTemplates.ConsoleEventCommandLineTask
            /// </summary>
            /// <history>
            /// 	[faizalk] 13FEB07: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConsoleEventTask
            {
                get
                {
                    if ((cachedConsoleEventTask == null))
                    {
                        cachedConsoleEventTask = Common.Utilities.GetMonitoringTemplateName(GUIDConsoleEventTask);
                    }

                    return cachedConsoleEventTask;
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
        /// 	[faizalk] 3/16/2006 Created
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
            /// Control ID for TaskTypeStaticControl
            /// </summary>
            public const string TaskTypeStaticControl = "textLinkLabel";
            
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
            /// Control ID for SelectTheTypeOfTaskToCreateStaticControl
            /// </summary>
            public const string SelectTheTypeOfTaskToCreateStaticControl = "pageSectionLabel1";
            
            /// <summary>
            /// Control ID for StaticControl0
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string StaticControl0 = "descriptionTextLabel";
            
            /// <summary>
            /// Control ID for DescriptionStaticControl
            /// </summary>
            public const string DescriptionStaticControl = "descLabel";
            
            /// <summary>
            /// Control ID for SelectTheTypeOfTaskToCreateTreeView
            /// </summary>
            public const string SelectTheTypeOfTaskToCreateTreeView = "taskTypesTreeView";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for SelectATaskTypeStaticControl
            /// </summary>
            public const string SelectATaskTypeStaticControl = "headerLabel";
        }
        #endregion
    }
}
