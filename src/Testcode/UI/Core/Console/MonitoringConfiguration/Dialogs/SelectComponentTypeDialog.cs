// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SelectComponentTypeDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	MOMv3 UI Test Automation
// </summary>
// <history>
// 	[ruhim] 3/3/2006 Created
//  [faizalk] 4/17/2006 Add resource string for dialog title
//  [ruhim]   6/09/06   Replacing Hardcoded GUIDs with method calls  
//  [faizalk] 7/10/2006 Add support for ASP.NET Exception monitoring
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs
{
    using System;
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console.MonitoringConfiguration;
    
    #region Interface Definition - ISelectComponentTypeDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISelectComponentTypeDialogControls, for SelectComponentTypeDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 3/3/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISelectComponentTypeDialogControls
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
        /// Read-only property to access SelectTheTypeOfComponentToCreateStaticControl
        /// </summary>
        StaticControl SelectTheTypeOfComponentToCreateStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectComponentTypeTreeView
        /// </summary>
        TreeView SelectComponentTypeTreeView
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
        /// Read-only property to access SelectComponentTypeStaticControl
        /// </summary>
        StaticControl SelectComponentTypeStaticControl
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
    /// 	[ruhim] 3/3/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SelectComponentTypeDialog : Dialog, ISelectComponentTypeDialogControls
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
        /// Cache to hold a reference to StaticControl0 of type StaticControl
        /// </summary>
        private StaticControl cachedStaticControl0;
        
        /// <summary>
        /// Cache to hold a reference to DescriptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDescriptionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectTheTypeOfComponentToCreateStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectTheTypeOfComponentToCreateStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectComponentTypeTreeView of type TreeView
        /// </summary>
        private TreeView cachedSelectComponentTypeTreeView;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectComponentTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectComponentTypeStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of SelectComponentTypeDialog of type App
        /// </param>
        /// <history>
        /// 	[ruhim] 3/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SelectComponentTypeDialog(ConsoleApp app)
            : 
                base(app, Init(app))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout); 
        }
        #endregion
        
        #region ISelectComponentTypeDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 3/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISelectComponentTypeDialogControls Controls
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
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectComponentTypeDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, SelectComponentTypeDialog.ControlIDs.PreviousButton);
                }
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectComponentTypeDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, SelectComponentTypeDialog.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectComponentTypeDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, SelectComponentTypeDialog.ControlIDs.CreateButton);
                }
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectComponentTypeDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, SelectComponentTypeDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ComponentTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectComponentTypeDialogControls.ComponentTypeStaticControl
        {
            get
            {
                if ((this.cachedComponentTypeStaticControl == null))
                {
                    this.cachedComponentTypeStaticControl = new StaticControl(this, SelectComponentTypeDialog.ControlIDs.ComponentTypeStaticControl);
                }
                return this.cachedComponentTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StaticControl0 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectComponentTypeDialogControls.StaticControl0
        {
            get
            {
                if ((this.cachedStaticControl0 == null))
                {
                    this.cachedStaticControl0 = new StaticControl(this, SelectComponentTypeDialog.ControlIDs.StaticControl0);
                }
                return this.cachedStaticControl0;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectComponentTypeDialogControls.DescriptionStaticControl
        {
            get
            {
                if ((this.cachedDescriptionStaticControl == null))
                {
                    this.cachedDescriptionStaticControl = new StaticControl(this, SelectComponentTypeDialog.ControlIDs.DescriptionStaticControl);
                }
                return this.cachedDescriptionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectTheTypeOfComponentToCreateStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectComponentTypeDialogControls.SelectTheTypeOfComponentToCreateStaticControl
        {
            get
            {
                if ((this.cachedSelectTheTypeOfComponentToCreateStaticControl == null))
                {
                    this.cachedSelectTheTypeOfComponentToCreateStaticControl = new StaticControl(this, SelectComponentTypeDialog.ControlIDs.SelectTheTypeOfComponentToCreateStaticControl);
                }
                return this.cachedSelectTheTypeOfComponentToCreateStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectComponentTypeTreeView control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TreeView ISelectComponentTypeDialogControls.SelectComponentTypeTreeView
        {
            get
            {
                if ((this.cachedSelectComponentTypeTreeView == null))
                {
                    this.cachedSelectComponentTypeTreeView = new TreeView(this, SelectComponentTypeDialog.ControlIDs.SelectComponentTypeTreeView);
                }
                return this.cachedSelectComponentTypeTreeView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectComponentTypeDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, SelectComponentTypeDialog.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectComponentTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectComponentTypeDialogControls.SelectComponentTypeStaticControl
        {
            get
            {
                if ((this.cachedSelectComponentTypeStaticControl == null))
                {
                    this.cachedSelectComponentTypeStaticControl = new StaticControl(this, SelectComponentTypeDialog.ControlIDs.SelectComponentTypeStaticControl);
                }
                return this.cachedSelectComponentTypeStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/3/2006 Created
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
        /// 	[ruhim] 3/3/2006 Created
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
        /// 	[ruhim] 3/3/2006 Created
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
        /// 	[ruhim] 3/3/2006 Created
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
        ///  <param name="app">App owning the dialog.</param>)
        /// <history>
        /// 	[ruhim] 3/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Templates.Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
            }

            catch (Exceptions.WindowNotFoundException ex)
            {
                tempWindow = null;
                int numberOfTries = 0;
                const int MaxTries = 10;
                while (tempWindow == null && numberOfTries < MaxTries)
                {
                    numberOfTries++;
                    try
                    {
                        // look for the window again using wildcards
                        tempWindow = new Window(
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
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);

                        // bug 68212
                        app.BringToForeground();

                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage(
                            "Attempt " + numberOfTries + " of " + MaxTries);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find window with title:  '" +
                        Templates.Strings.DialogTitle + "'");

                    // throw the existing WindowNotFound exception
                    throw ex;
                }
            }
            return tempWindow;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Strings Class
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/3/2006 Created
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
            /// Contains resource string for:  ComponentType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceComponentType = ";Component Type;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpris" +
                "eManagement.Internal.UI.Authoring.Pages.TemplateListPage;$this.NavigationText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Description
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDescription = ";Description:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseM" +
                "anagement.Mom.Internal.UI.Views.AdminNodeDetailView;descriptionLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectTheTypeOfComponentToCreate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectTheTypeOfComponentToCreate = ";Select the type of component to create;ManagedString;Microsoft.MOM.UI.Components" +
                ".dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.TemplateListPage;pageS" +
                "ectionLabel1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mo" +
                "m.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectComponentType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectComponentType = ";Select Component Type;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.En" +
                "terpriseManagement.Internal.UI.Authoring.Pages.TemplateListPage;$this.HeaderText";

            /// <summary>
            /// Contains GUID for: System.Windows.Service.Template 
            /// </summary>            
            private static Guid GUIDWindowsServiceStandaloneProcessTemplate = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterNTServiceLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.NTServiceOwnProcessTemplateName);

            /// <summary>
            /// Contains GUID for: Microsoft.SystemCenter.WebApplication.SingleUrl.Template 
            /// </summary>            
            private static Guid GUIDWebApplicationTemplate = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterWebApplicationLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WebApplicationSingleUrlTemplateName);

            /// <summary>
            /// Contains GUID for: System.Mom.InstanceGroup.Template 
            /// </summary>            
            private const string GUIDInstanceGroupTemplate = "19C5852A-D89C-BF1E-B2FA-854805CFAFC4";

            /// <summary>
            /// Contains GUID for: Microsoft.SystemCenter.SyntheticTranscations.TCPPortCheck.Template 
            /// </summary>            
            private static Guid GUIDPortTemplate = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterSyntheticTransactionsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.SyntheticTransactionsTCPPortCheckTemplateName);

            /// <summary>
            /// Contains GUID for: Microsoft.SystemCenter.SyntheticTranscations.OleDbCheck.Template 
            /// </summary>            
            private static Guid GUIDOleDbTemplate = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterSyntheticTransactionsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.SyntheticTransactionsOleDbCheckTemplateName);

            /// <summary>
            /// Contains GUID for: System.Windows.Service.SharedProcess.Template 
            /// </summary>            
            private const string GUIDWindowsServiceSharedProcessTemplate = "297AE449-8989-B0FF-F405-C7E6B4902E2F";

            /// <summary>
            /// Contains GUID for: Microsoft.SystemCenter.ASPNET20.2007.AspApplication.Template 
            /// </summary>            
            private static Guid GUIDASPApplicationTemplate = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterASPNETMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.AspApplicationTemplate);

            /// <summary>
            /// Contains GUID for: Microsoft.SystemCenter.ASPNET20.2007.AspWebService.Template 
            /// </summary>            
            private static Guid GUIDASPWebServiceTemplate = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterASPNETMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.AspWebServiceTemplate);

            /// <summary>
            /// Contains GUID for: Microsoft.SystemCenter.ProcessMonitor.Template 
            /// </summary>            
            private static Guid GUIDProcessMonitoringTemplate = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterProcessMonitoringLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.ProcessMonitorTemplate);

            /// <summary>
            /// Contains GUID for: Microsoft.SystemCenter.PowerManagement.PowerSet.Template
            /// </summary>            
            private static Guid GUIDPowerConsumptionTemplate = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterPowerManagemetnLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.PowerConsumptionTemplate);

            #endregion
            
            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource of the Web Application Template
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWebApplicationAvailabilityMonitoringTemplate;

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
            /// Caches the translated resource string for:  Description
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDescription;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectTheTypeOfComponentToCreate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectTheTypeOfComponentToCreate;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectComponentType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectComponentType;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Windows.Service.Template
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWindowsServiceStandaloneProcessTemplate;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: Microsoft.SystemCenter.WebApplication.SingleUrl.Template
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWebApplicationTemplate;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Mom.InstanceGroup.Template
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedInstanceGroupTemplate;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: Microsoft.SystemCenter.SyntheticTranscations.TCPPortCheck.Template
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPortTemplate;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: Microsoft.SystemCenter.SyntheticTranscations.OleDbCheck.Template
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOleDbTemplate;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Windows.Service.SharedProcess.Template
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWindowsServiceSharedProcessTemplate;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: Microsoft.SystemCenter.SyntheticTranscations.TCPPortCheck.Template
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedASPNETApplicationTemplate;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: Microsoft.SystemCenter.SyntheticTranscations.OleDbCheck.Template
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedASPNETWebServiceTemplate;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: Microsoft.SystemCenter.ProcessMonitor.Template
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedProcessMonitoringTemplate;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: Microsoft.SystemCenter.PowerManagement.PowerSet.Template
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPowerConsumptionTemplate;

            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Web Application template translated resource string
            /// ToDo: Don't hard the resource string, please find this string in a appropriate MP file
            /// </summary>
            /// <history>
            /// 	[v-bire] 4/11/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WebApplicationAvailabilityMonitoringTemplate
            {
                get
                {
                    if (cachedWebApplicationAvailabilityMonitoringTemplate  == null)
                    {
                        cachedWebApplicationAvailabilityMonitoringTemplate = "Web Application Availability Monitoring";
                    }
                    return cachedWebApplicationAvailabilityMonitoringTemplate;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/3/2006 Created
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
            /// 	[ruhim] 3/3/2006 Created
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
            /// 	[ruhim] 3/3/2006 Created
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
            /// 	[ruhim] 3/3/2006 Created
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
            /// 	[ruhim] 3/3/2006 Created
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
            /// 	[ruhim] 3/3/2006 Created
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
            /// Exposes access to the Description translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/3/2006 Created
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
            /// Exposes access to the SelectTheTypeOfComponentToCreate translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectTheTypeOfComponentToCreate
            {
                get
                {
                    if ((cachedSelectTheTypeOfComponentToCreate == null))
                    {
                        cachedSelectTheTypeOfComponentToCreate = CoreManager.MomConsole.GetIntlStr(ResourceSelectTheTypeOfComponentToCreate);
                    }
                    return cachedSelectTheTypeOfComponentToCreate;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/3/2006 Created
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
            /// Exposes access to the SelectComponentType translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectComponentType
            {
                get
                {
                    if ((cachedSelectComponentType == null))
                    {
                        cachedSelectComponentType = CoreManager.MomConsole.GetIntlStr(ResourceSelectComponentType);
                    }
                    return cachedSelectComponentType;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Windows.Service.Template
            /// </summary>
            /// <history>
            /// 	[ruhim] 17NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WindowsServiceStandaloneProcessTemplate
            {
                get
                {
                    if ((cachedWindowsServiceStandaloneProcessTemplate == null))
                    {
                        cachedWindowsServiceStandaloneProcessTemplate = Common.Utilities.GetMonitoringTemplateName(GUIDWindowsServiceStandaloneProcessTemplate);
                    }

                    return cachedWindowsServiceStandaloneProcessTemplate;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: Microsoft.SystemCenter.WebApplication.SingleUrl.Template
            /// </summary>
            /// <history>
            /// 	[ruhim] 17NOV05: Created
            ///     [faizalk] 27MAR06: Updated for new Web Application Template
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WebApplicationTemplate
            {
                get
                {
                    if ((cachedWebApplicationTemplate == null))
                    {
                        cachedWebApplicationTemplate = Common.Utilities.GetMonitoringTemplateName(GUIDWebApplicationTemplate);
                    }

                    return cachedWebApplicationTemplate;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Mom.InstanceGroup.Template
            /// </summary>
            /// <history>
            /// 	[ruhim] 17NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string InstanceGroupTemplate
            {
                get
                {
                    if ((cachedInstanceGroupTemplate == null))
                    {
                        cachedInstanceGroupTemplate = Common.Utilities.GetMonitoringTemplateName(GUIDInstanceGroupTemplate);
                    }

                    return cachedInstanceGroupTemplate;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: Microsoft.SystemCenter.SyntheticTranscations.TCPPortCheck.Template
            /// </summary>
            /// <history>
            /// 	[faizalk] 27MAR06: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string PortTemplate
            {
                get
                {
                    if ((cachedPortTemplate == null))
                    {
                        cachedPortTemplate = Common.Utilities.GetMonitoringTemplateName(GUIDPortTemplate);
                    }

                    return cachedPortTemplate;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: Microsoft.SystemCenter.SyntheticTranscations.OleDbCheck.Template
            /// </summary>
            /// <history>
            /// 	[faizalk] 27MAR06: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OleDbTemplate
            {
                get
                {
                    if ((cachedOleDbTemplate == null))
                    {
                        cachedOleDbTemplate = Common.Utilities.GetMonitoringTemplateName(GUIDOleDbTemplate);
                    }

                    return cachedOleDbTemplate;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Windows.Service.SharedProcess.Template
            /// </summary>
            /// <history>
            /// 	[ruhim] 17NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WindowsServiceSharedProcessTemplate
            {
                get
                {
                    if ((cachedWindowsServiceSharedProcessTemplate == null))
                    {
                        cachedWindowsServiceSharedProcessTemplate = Common.Utilities.GetMonitoringTemplateName(GUIDWindowsServiceSharedProcessTemplate);
                    }

                    return cachedWindowsServiceSharedProcessTemplate;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: Microsoft.SystemCenter.ASPNET20.2007.AspApplication.Template
            /// </summary>
            /// <history>
            /// 	[faizalk] 07JUL06: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ASPNETApplicationTemplate
            {
                get
                {
                    if ((cachedASPNETApplicationTemplate == null))
                    {
                        cachedASPNETApplicationTemplate = Common.Utilities.GetMonitoringTemplateName(GUIDASPApplicationTemplate);
                    }

                    return cachedASPNETApplicationTemplate;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: Microsoft.SystemCenter.ASPNET20.2007.AspWebService.Template
            /// </summary>
            /// <history>
            /// 	[faizalk] 07JUL06: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ASPNETWebServiceTemplate
            {
                get
                {
                    if ((cachedASPNETWebServiceTemplate == null))
                    {
                        cachedASPNETWebServiceTemplate = Common.Utilities.GetMonitoringTemplateName(GUIDASPWebServiceTemplate);
                    }

                    return cachedASPNETWebServiceTemplate;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: Microsoft.SystemCenter.ProcessMonitoring.Template
            /// </summary>
            /// <history>
            /// 	[bretlink] 12SEP08: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ProcessMonitoringTemplate
            {
                get
                {
                    if ((cachedProcessMonitoringTemplate == null))
                    {
                        cachedProcessMonitoringTemplate = Common.Utilities.GetMonitoringTemplateName(GUIDProcessMonitoringTemplate);
                    }

                    return cachedProcessMonitoringTemplate;
                }
            }


            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: Microsoft.SystemCenter.PowerManagement.PowerSet.Template
            /// </summary>
            /// <history>
            /// 	[dialac] 13FEV09: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string PowerConsumptionTemplate
            {
                get
                {
                    if ((cachedPowerConsumptionTemplate == null))
                    {
                        cachedPowerConsumptionTemplate = Common.Utilities.GetMonitoringTemplateName(GUIDPowerConsumptionTemplate);
                    }
                    return cachedPowerConsumptionTemplate;
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
        /// 	[ruhim] 3/3/2006 Created
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
            /// Control ID for SelectTheTypeOfComponentToCreateStaticControl
            /// </summary>
            public const string SelectTheTypeOfComponentToCreateStaticControl = "pageSectionLabel1";
            
            /// <summary>
            /// Control ID for SelectComponentTypeTreeView
            /// </summary>
            public const string SelectComponentTypeTreeView = "templatesTreeView";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for SelectComponentTypeStaticControl
            /// </summary>
            public const string SelectComponentTypeStaticControl = "headerLabel";
        }
        #endregion
    }
}
