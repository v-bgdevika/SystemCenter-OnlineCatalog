// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="DiagnosticAndRecoveryDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[sunsingh] 7/30/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.DiagnosticAndRecovery.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IDiagnosticAndRecoveryDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IDiagnosticAndRecoveryDialogControls, for DiagnosticAndRecoveryDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[sunsingh] 7/30/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IDiagnosticAndRecoveryDialogControls
    {
        /// <summary>
        /// Read-only property to access CloseButton
        /// </summary>
        Button CloseButton
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
        /// Read-only property to access AddButton
        /// </summary>
        Button AddButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RemoveButton
        /// </summary>
        Button RemoveButton
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
        /// Read-only property to access DescriptionOptionalPropertyGridView
        /// </summary>
        PropertyGridView DescriptionOptionalPropertyGridView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConfigureTheDiagnosticTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStatesStaticCo
        /// </summary>
        StaticControl ConfigureTheDiagnosticTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStatesStaticCo
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConfigureDiagnosticTasksStaticControl
        /// </summary>
        StaticControl ConfigureDiagnosticTasksStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AddButton2
        /// </summary>
        Button AddButton2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RemoveButton2
        /// </summary>
        Button RemoveButton2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConfigureTheRecoveryTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStatesStaticCont
        /// </summary>
        StaticControl ConfigureTheRecoveryTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStatesStaticCont
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EditButton2
        /// </summary>
        Button EditButton2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ParentMonitorPropertyGridView
        /// </summary>
        PropertyGridView ParentMonitorPropertyGridView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConfigureRecoveryTasksStaticControl
        /// </summary>
        StaticControl ConfigureRecoveryTasksStaticControl
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
    /// 	[sunsingh] 7/30/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class DiagnosticAndRecoveryDialog : Dialog, IDiagnosticAndRecoveryDialogControls
    {
        #region Private Constants

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
        /// Cache to hold a reference to Tab3TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab3TabControl;
        
        /// <summary>
        /// Cache to hold a reference to AddButton of type Button
        /// </summary>
        private Button cachedAddButton;
        
        /// <summary>
        /// Cache to hold a reference to RemoveButton of type Button
        /// </summary>
        private Button cachedRemoveButton;
        
        /// <summary>
        /// Cache to hold a reference to EditButton of type Button
        /// </summary>
        private Button cachedEditButton;
        
        /// <summary>
        /// Cache to hold a reference to DescriptionOptionalPropertyGridView of type PropertyGridView
        /// </summary>
        private PropertyGridView cachedDescriptionOptionalPropertyGridView;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureTheDiagnosticTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStatesStaticCo of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureTheDiagnosticTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStatesStaticCo;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureDiagnosticTasksStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureDiagnosticTasksStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AddButton2 of type Button
        /// </summary>
        private Button cachedAddButton2;
        
        /// <summary>
        /// Cache to hold a reference to RemoveButton2 of type Button
        /// </summary>
        private Button cachedRemoveButton2;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureTheRecoveryTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStatesStaticCont of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureTheRecoveryTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStatesStaticCont;
        
        /// <summary>
        /// Cache to hold a reference to EditButton2 of type Button
        /// </summary>
        private Button cachedEditButton2;
        
        /// <summary>
        /// Cache to hold a reference to ParentMonitorPropertyGridView of type PropertyGridView
        /// </summary>
        private PropertyGridView cachedParentMonitorPropertyGridView;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureRecoveryTasksStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureRecoveryTasksStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of DiagnosticAndRecoveryDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public DiagnosticAndRecoveryDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IDiagnosticAndRecoveryDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IDiagnosticAndRecoveryDialogControls Controls
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
        ///  Exposes access to the CloseButton control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDiagnosticAndRecoveryDialogControls.CloseButton
        {
            get
            {
                if ((this.cachedCloseButton == null))
                {
                    this.cachedCloseButton = new Button(this, DiagnosticAndRecoveryDialog.ControlIDs.CloseButton);
                }
                
                return this.cachedCloseButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab3TabControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IDiagnosticAndRecoveryDialogControls.Tab3TabControl
        {
            get
            {
                if ((this.cachedTab3TabControl == null))
                {
                    this.cachedTab3TabControl = new TabControl(this, DiagnosticAndRecoveryDialog.ControlIDs.Tab3TabControl);
                }
                
                return this.cachedTab3TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddButton control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDiagnosticAndRecoveryDialogControls.AddButton
        {
            get
            {
                if ((this.cachedAddButton == null))
                {
                    this.cachedAddButton = new Button(this, DiagnosticAndRecoveryDialog.ControlIDs.AddButton);
                }
                
                return this.cachedAddButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RemoveButton control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDiagnosticAndRecoveryDialogControls.RemoveButton
        {
            get
            {
                if ((this.cachedRemoveButton == null))
                {
                    this.cachedRemoveButton = new Button(this, DiagnosticAndRecoveryDialog.ControlIDs.RemoveButton);
                }
                
                return this.cachedRemoveButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EditButton control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDiagnosticAndRecoveryDialogControls.EditButton
        {
            get
            {
                if ((this.cachedEditButton == null))
                {
                    this.cachedEditButton = new Button(this, DiagnosticAndRecoveryDialog.ControlIDs.EditButton);
                }
                
                return this.cachedEditButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionOptionalPropertyGridView control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        PropertyGridView IDiagnosticAndRecoveryDialogControls.DescriptionOptionalPropertyGridView
        {
            get
            {
                if ((this.cachedDescriptionOptionalPropertyGridView == null))
                {
                    this.cachedDescriptionOptionalPropertyGridView = new PropertyGridView(this, DiagnosticAndRecoveryDialog.ControlIDs.DescriptionOptionalPropertyGridView);
                }
                
                return this.cachedDescriptionOptionalPropertyGridView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureTheDiagnosticTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStatesStaticCo control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryDialogControls.ConfigureTheDiagnosticTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStatesStaticCo
        {
            get
            {
                if ((this.cachedConfigureTheDiagnosticTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStatesStaticCo == null))
                {
                    this.cachedConfigureTheDiagnosticTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStatesStaticCo = new StaticControl(this, DiagnosticAndRecoveryDialog.ControlIDs.ConfigureTheDiagnosticTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStatesStaticCo);
                }
                
                return this.cachedConfigureTheDiagnosticTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStatesStaticCo;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureDiagnosticTasksStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryDialogControls.ConfigureDiagnosticTasksStaticControl
        {
            get
            {
                if ((this.cachedConfigureDiagnosticTasksStaticControl == null))
                {
                    this.cachedConfigureDiagnosticTasksStaticControl = new StaticControl(this, DiagnosticAndRecoveryDialog.ControlIDs.ConfigureDiagnosticTasksStaticControl);
                }
                
                return this.cachedConfigureDiagnosticTasksStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddButton2 control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDiagnosticAndRecoveryDialogControls.AddButton2
        {
            get
            {
                if ((this.cachedAddButton2 == null))
                {
                    this.cachedAddButton2 = new Button(this, DiagnosticAndRecoveryDialog.ControlIDs.AddButton2);
                }
                
                return this.cachedAddButton2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RemoveButton2 control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDiagnosticAndRecoveryDialogControls.RemoveButton2
        {
            get
            {
                if ((this.cachedRemoveButton2 == null))
                {
                    this.cachedRemoveButton2 = new Button(this, DiagnosticAndRecoveryDialog.ControlIDs.RemoveButton2);
                }
                
                return this.cachedRemoveButton2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureTheRecoveryTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStatesStaticCont control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryDialogControls.ConfigureTheRecoveryTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStatesStaticCont
        {
            get
            {
                if ((this.cachedConfigureTheRecoveryTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStatesStaticCont == null))
                {
                    this.cachedConfigureTheRecoveryTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStatesStaticCont = new StaticControl(this, DiagnosticAndRecoveryDialog.ControlIDs.ConfigureTheRecoveryTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStatesStaticCont);
                }
                
                return this.cachedConfigureTheRecoveryTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStatesStaticCont;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EditButton2 control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDiagnosticAndRecoveryDialogControls.EditButton2
        {
            get
            {
                if ((this.cachedEditButton2 == null))
                {
                    this.cachedEditButton2 = new Button(this, DiagnosticAndRecoveryDialog.ControlIDs.EditButton2);
                }
                
                return this.cachedEditButton2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ParentMonitorPropertyGridView control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        PropertyGridView IDiagnosticAndRecoveryDialogControls.ParentMonitorPropertyGridView
        {
            get
            {
                if ((this.cachedParentMonitorPropertyGridView == null))
                {
                    this.cachedParentMonitorPropertyGridView = new PropertyGridView(this, DiagnosticAndRecoveryDialog.ControlIDs.ParentMonitorPropertyGridView);
                }
                
                return this.cachedParentMonitorPropertyGridView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureRecoveryTasksStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryDialogControls.ConfigureRecoveryTasksStaticControl
        {
            get
            {
                if ((this.cachedConfigureRecoveryTasksStaticControl == null))
                {
                    this.cachedConfigureRecoveryTasksStaticControl = new StaticControl(this, DiagnosticAndRecoveryDialog.ControlIDs.ConfigureRecoveryTasksStaticControl);
                }
                
                return this.cachedConfigureRecoveryTasksStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Close
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickClose()
        {
            this.Controls.CloseButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Add
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickDiagnosticAdd()
        {
            this.Controls.AddButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Remove
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickDiagonosticRemove()
        {
            this.Controls.RemoveButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Edit
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEdit()
        {
            this.Controls.EditButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Add2
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickRecoveryAdd()
        {
            this.Controls.AddButton2.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Remove2
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickRecoveryRemove()
        {
            this.Controls.RemoveButton2.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Edit2
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEdit2()
        {
            this.Controls.EditButton2.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">MomConsoleApp owning the dialog.</param>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.WildCard, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
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
                    catch (Exceptions.WindowNotFoundException)
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
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Close
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public MomControls.GridControl GetDataGrid(DiagnosticAndRecovery.DiagnosticAndRecoveryParameters.enumConfigrationType configType)
        {

            string gridResorceId = null;

            switch (configType)
            {
                case DiagnosticAndRecovery.DiagnosticAndRecoveryParameters.enumConfigrationType.Diagonostic:
                    {
                        gridResorceId = ControlIDs.DescriptionOptionalPropertyGridView;
                        break;
                    }
                case DiagnosticAndRecovery.DiagnosticAndRecoveryParameters.enumConfigrationType.Recovery:
                    {
                        gridResorceId = ControlIDs.ParentMonitorPropertyGridView;
                        break;
                    }
            }
            
            return new MomControls.GridControl(
                   this,
                   gridResorceId);
        }


        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants
             /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Close
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceClose = ";&Close;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micros" +
                "oft.EnterpriseManagement.Mom.Internal.UI.Administration.MPInstall.MPDeleteStatus" +
                "Dialog;closeButton.Text";
            
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
            /// Contains resource string for:  Add
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdd = ";A&dd...;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.EmailNoti" +
                "fication;add.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Remove
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRemove = ";R&emove;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft." +
                "EnterpriseManagement.Internal.UI.Authoring.Pages.DiagAndRecoveryPage;diagRemoveB" +
                "utton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Edit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEdit = ";Edi&t...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft" +
                ".EnterpriseManagement.Internal.UI.Authoring.Pages.DefaultUIPage;editOrViewBtn.Te" +
                "xt";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureTheDiagnosticTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStates
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureTheDiagnosticTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStates = @";Configure the diagnostic task(s) by creating or editing one or more tasks to be used for each of the health states:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.DiagAndRecoveryPage;label1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureDiagnosticTasks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureDiagnosticTasks = ";Configure diagnostic tasks;ManagedString;Microsoft.EnterpriseManagement.UI.Autho" +
                "ring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.DiagAndRecov" +
                "eryPage;pageSectionLabel1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Add2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdd2 = ";&Add...;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.MPInstall.MPInstallDial" +
                "og;menuAdd.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Remove2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRemove2 = ";Re&move;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.DeviceSche" +
                "dulePage;exclusionPeriods.RemoveButtonText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureTheRecoveryTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStates
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureTheRecoveryTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStates = @";Configure the recovery task(s) by creating or editing one or more tasks to be used for each of the health states:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.DiagAndRecoveryPage;label2.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Edit2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEdit2 = ";&Edit...;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micr" +
                "osoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.EmailNot" +
                "ification;edit.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureRecoveryTasks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureRecoveryTasks = ";Configure recovery tasks;ManagedString;Microsoft.EnterpriseManagement.UI.Authori" +
                "ng.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.DiagAndRecover" +
                "yPage;pageSectionLabel2.Text";
            //Added For DataGridView
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureRecoveryTasks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHealthStateDiagnosticGrid = ";Health state;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.DiagAndRecoveryPage;dataGridViewTextBoxColumn0.HeaderText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureRecoveryTasks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHealthStateRecoveryGrid = ";Health state;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.DiagAndRecoveryPage;dataGridViewTextBoxColumn0.HeaderText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureRecoveryTasks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDiagnosticTaskNameGrid = ";Diagnostic task name;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.DiagAndRecoveryPage;dataGridViewTextBoxColumn1.HeaderText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureRecoveryTasks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRecoveryTaskNameGrid = ";Recovery task name;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.DiagAndRecoveryPage;dataGridViewTextBoxColumn5.HeaderText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureRecoveryTasks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRunAutomaticallyDiagnosticGrid = ";Run automatically;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.DiagAndRecoveryPage;dataGridViewTextBoxColumn4.HeaderText";
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureRecoveryTasks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRunAutomaticallyRecoveryGrid = ";Run automatically;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.DiagAndRecoveryPage;dataGridViewTextBoxColumn8.HeaderText";
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureRecoveryTasks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRecalculateRecoveryGrid = ";Recalculate monitor state;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.DiagAndRecoveryPage;resetMonitorColumn.HeaderText";
            #endregion
            
            #region Private Members
             /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Close
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedClose;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Tab3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab3;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Add
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdd;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Remove
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRemove;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Edit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEdit;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureTheDiagnosticTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStates
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigureTheDiagnosticTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStates;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureDiagnosticTasks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigureDiagnosticTasks;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Add2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdd2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Remove2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRemove2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureTheRecoveryTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStates
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigureTheRecoveryTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStates;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Edit2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEdit2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureRecoveryTasks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigureRecoveryTasks;
            //added
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureRecoveryTasks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRecalculateRecoveryGrid;
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureRecoveryTasks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRunAutomaticallyRecoveryGrid;
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureRecoveryTasks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRunAutomaticallyDiagnosticGrid;
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureRecoveryTasks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRecoveryTaskNameGrid;
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureRecoveryTasks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDiagnosticTaskNameGrid;
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureRecoveryTasks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHealthStateRecoveryGrid;
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureRecoveryTasks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHealthStateDiagnosticGrid;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/30/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {

                    return MonitorPropertiesDialog.Strings.DialogTitle;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Close translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/30/2008 Created
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
            /// Exposes access to the Tab3 translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/30/2008 Created
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
            /// Exposes access to the Add translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/30/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Add
            {
                get
                {
                    if ((cachedAdd == null))
                    {
                        cachedAdd = CoreManager.MomConsole.GetIntlStr(ResourceAdd);
                    }
                    
                    return cachedAdd;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Remove translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/30/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Remove
            {
                get
                {
                    if ((cachedRemove == null))
                    {
                        cachedRemove = CoreManager.MomConsole.GetIntlStr(ResourceRemove);
                    }
                    
                    return cachedRemove;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Edit translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/30/2008 Created
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
            /// Exposes access to the ConfigureTheDiagnosticTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStates translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/30/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfigureTheDiagnosticTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStates
            {
                get
                {
                    if ((cachedConfigureTheDiagnosticTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStates == null))
                    {
                        cachedConfigureTheDiagnosticTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStates = CoreManager.MomConsole.GetIntlStr(ResourceConfigureTheDiagnosticTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStates);
                    }
                    
                    return cachedConfigureTheDiagnosticTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStates;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfigureDiagnosticTasks translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/30/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfigureDiagnosticTasks
            {
                get
                {
                    if ((cachedConfigureDiagnosticTasks == null))
                    {
                        cachedConfigureDiagnosticTasks = CoreManager.MomConsole.GetIntlStr(ResourceConfigureDiagnosticTasks);
                    }
                    
                    return cachedConfigureDiagnosticTasks;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Add2 translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/30/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Add2
            {
                get
                {
                    if ((cachedAdd2 == null))
                    {
                        cachedAdd2 = CoreManager.MomConsole.GetIntlStr(ResourceAdd2);
                    }
                    
                    return cachedAdd2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Remove2 translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/30/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Remove2
            {
                get
                {
                    if ((cachedRemove2 == null))
                    {
                        cachedRemove2 = CoreManager.MomConsole.GetIntlStr(ResourceRemove2);
                    }
                    
                    return cachedRemove2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfigureTheRecoveryTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStates translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/30/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfigureTheRecoveryTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStates
            {
                get
                {
                    if ((cachedConfigureTheRecoveryTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStates == null))
                    {
                        cachedConfigureTheRecoveryTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStates = CoreManager.MomConsole.GetIntlStr(ResourceConfigureTheRecoveryTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStates);
                    }
                    
                    return cachedConfigureTheRecoveryTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStates;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Edit2 translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/30/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Edit2
            {
                get
                {
                    if ((cachedEdit2 == null))
                    {
                        cachedEdit2 = CoreManager.MomConsole.GetIntlStr(ResourceEdit2);
                    }
                    
                    return cachedEdit2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfigureRecoveryTasks translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/30/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfigureRecoveryTasks
            {
                get
                {
                    if ((cachedConfigureRecoveryTasks == null))
                    {
                        cachedConfigureRecoveryTasks = CoreManager.MomConsole.GetIntlStr(ResourceConfigureRecoveryTasks);
                    }
                    
                    return cachedConfigureRecoveryTasks;
                }
            }

            //added
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfigureRecoveryTasks translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/30/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RecalculateRecoveryGrid
            {
                get
                {
                    if ((cachedRecalculateRecoveryGrid == null))
                    {
                        cachedRecalculateRecoveryGrid = CoreManager.MomConsole.GetIntlStr(ResourceRecalculateRecoveryGrid);
                    }

                    return cachedRecalculateRecoveryGrid;
                }
            }
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfigureRecoveryTasks translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/30/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RunAutomaticallyRecoveryGrid
            {
                get
                {
                    if ((cachedRunAutomaticallyRecoveryGrid == null))
                    {
                        cachedRunAutomaticallyRecoveryGrid = CoreManager.MomConsole.GetIntlStr(ResourceRunAutomaticallyRecoveryGrid);
                    }

                    return cachedRunAutomaticallyRecoveryGrid;
                }
            }
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfigureRecoveryTasks translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/30/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RunAutomaticallyDiagnosticGrid
            {
                get
                {
                    if ((cachedRunAutomaticallyDiagnosticGrid == null))
                    {
                        cachedRunAutomaticallyDiagnosticGrid = CoreManager.MomConsole.GetIntlStr(ResourceRunAutomaticallyDiagnosticGrid);
                    }

                    return cachedRunAutomaticallyDiagnosticGrid;
                }
            }
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfigureRecoveryTasks translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/30/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RecoveryTaskNameGrid
            {
                get
                {
                    if ((cachedRecoveryTaskNameGrid == null))
                    {
                        cachedRecoveryTaskNameGrid = CoreManager.MomConsole.GetIntlStr(ResourceRecoveryTaskNameGrid);
                    }

                    return cachedRecoveryTaskNameGrid;
                }
            }
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfigureRecoveryTasks translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/30/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DiagnosticTaskNameGrid
            {
                get
                {
                    if ((cachedDiagnosticTaskNameGrid == null))
                    {
                        cachedDiagnosticTaskNameGrid = CoreManager.MomConsole.GetIntlStr(ResourceDiagnosticTaskNameGrid);
                    }

                    return cachedDiagnosticTaskNameGrid;
                }
            }
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfigureRecoveryTasks translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/30/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string HealthStateRecoveryGrid
            {
                get
                {
                    if ((cachedHealthStateRecoveryGrid == null))
                    {
                        cachedHealthStateRecoveryGrid = CoreManager.MomConsole.GetIntlStr(ResourceHealthStateRecoveryGrid);
                    }

                    return cachedHealthStateRecoveryGrid;
                }
            }
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfigureRecoveryTasks translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/30/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string HealthStateDiagnosticGrid
            {
                get
                {
                    if ((cachedHealthStateDiagnosticGrid == null))
                    {
                        cachedHealthStateDiagnosticGrid = CoreManager.MomConsole.GetIntlStr(ResourceHealthStateDiagnosticGrid);
                    }

                    return cachedHealthStateDiagnosticGrid;
                }
            }
            #endregion
        }
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for CloseButton
            /// </summary>
            public const string CloseButton = "cancelButton";
            
            /// <summary>
            /// Control ID for Tab3TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab3TabControl = "tabPages";
            
            /// <summary>
            /// Control ID for AddButton
            /// </summary>
            public const string AddButton = "addDiagnosticButton";
            
            /// <summary>
            /// Control ID for RemoveButton
            /// </summary>
            public const string RemoveButton = "diagRemoveButton";
            
            /// <summary>
            /// Control ID for EditButton
            /// </summary>
            public const string EditButton = "diagEditButton";
            
            /// <summary>
            /// Control ID for DescriptionOptionalPropertyGridView
            /// </summary>
            public const string DescriptionOptionalPropertyGridView = "diagDataGridView";
            
            /// <summary>
            /// Control ID for ConfigureTheDiagnosticTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStatesStaticCo
            /// </summary>
            public const string ConfigureTheDiagnosticTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStatesStaticCo = "label1";
            
            /// <summary>
            /// Control ID for ConfigureDiagnosticTasksStaticControl
            /// </summary>
            public const string ConfigureDiagnosticTasksStaticControl = "pageSectionLabel1";
            
            /// <summary>
            /// Control ID for AddButton2
            /// </summary>
            public const string AddButton2 = "addRecoveryButton";
            
            /// <summary>
            /// Control ID for RemoveButton2
            /// </summary>
            public const string RemoveButton2 = "recoveryRemoveButton";
            
            /// <summary>
            /// Control ID for ConfigureTheRecoveryTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStatesStaticCont
            /// </summary>
            public const string ConfigureTheRecoveryTasksByCreatingOrEditingOneOrMoreTasksToBeUsedForEachOfTheHealthStatesStaticCont = "label2";
            
            /// <summary>
            /// Control ID for EditButton2
            /// </summary>
            public const string EditButton2 = "recoveryEditButton";
            
            /// <summary>
            /// Control ID for ParentMonitorPropertyGridView
            /// </summary>
            public const string ParentMonitorPropertyGridView = "recoveryDataGridView";
            
            /// <summary>
            /// Control ID for ConfigureRecoveryTasksStaticControl
            /// </summary>
            public const string ConfigureRecoveryTasksStaticControl = "pageSectionLabel2";
        }
        #endregion
    }
}
