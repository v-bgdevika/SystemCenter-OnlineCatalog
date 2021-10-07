// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="TargetGroupAndServiceDialog.cs">
//   Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//   [asttest] 10/1/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.WindowsService.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - ITargetGroupAndServiceDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ITargetGroupAndServiceDialogControls, for TargetGroupAndServiceDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [asttest] 10/1/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ITargetGroupAndServiceDialogControls
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
        /// Read-only property to access GroupNameTextBox
        /// </summary>
        TextBox GroupNameTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AutomaticServiceCheckBox
        /// </summary>
        CheckBox AutomaticServiceCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access GroupSearchButton
        /// </summary>
        Button GroupSearchButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ServiceNameTextBox
        /// </summary>
        TextBox ServiceNameTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ServiceSearchButton
        /// </summary>
        Button ServiceSearchButton
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
    ///   [asttest] 10/1/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class TargetGroupAndServiceDialog : Dialog, ITargetGroupAndServiceDialogControls
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
        /// Cache to hold a reference to GroupNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedGroupNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to AutomaticServiceCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedAutomaticServiceCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to GroupSearchButton of type Button
        /// </summary>
        private Button cachedGroupSearchButton;
        
        /// <summary>
        /// Cache to hold a reference to ServiceNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedServiceNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ServiceSearchButton of type Button
        /// </summary>
        private Button cachedServiceSearchButton;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of TargetGroupAndServiceDialog of type App
        /// </param>
        /// <history>
        ///   [asttest] 10/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public TargetGroupAndServiceDialog(App app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region ITargetGroupAndServiceDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [asttest] 10/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ITargetGroupAndServiceDialogControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion
        
        #region Checkbox Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox AutomaticService
        /// </summary>
        /// <history>
        ///   [asttest] 10/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool AutomaticService
        {
            get
            {
                return this.Controls.AutomaticServiceCheckBox.Checked;
            }
            
            set
            {
                this.Controls.AutomaticServiceCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control GroupName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [asttest] 10/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string GroupNameText
        {
            get
            {
                return this.Controls.GroupNameTextBox.Text;
            }
            
            set
            {
                this.Controls.GroupNameTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ServiceName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [asttest] 10/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ServiceNameText
        {
            get
            {
                return this.Controls.ServiceNameTextBox.Text;
            }
            
            set
            {
                this.Controls.ServiceNameTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        ///   [asttest] 10/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITargetGroupAndServiceDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, TargetGroupAndServiceDialog.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        ///   [asttest] 10/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITargetGroupAndServiceDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, TargetGroupAndServiceDialog.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        ///   [asttest] 10/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITargetGroupAndServiceDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, TargetGroupAndServiceDialog.ControlIDs.CreateButton);
                }
                
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        ///   [asttest] 10/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITargetGroupAndServiceDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, TargetGroupAndServiceDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GroupNameTextBox control
        /// </summary>
        /// <history>
        ///   [asttest] 10/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ITargetGroupAndServiceDialogControls.GroupNameTextBox
        {
            get
            {
                if ((this.cachedGroupNameTextBox == null))
                {
                    this.cachedGroupNameTextBox = new TextBox(this, TargetGroupAndServiceDialog.ControlIDs.GroupNameTextBox);
                }
                
                return this.cachedGroupNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AutomaticServiceCheckBox control
        /// </summary>
        /// <history>
        ///   [asttest] 10/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox ITargetGroupAndServiceDialogControls.AutomaticServiceCheckBox
        {
            get
            {
                if ((this.cachedAutomaticServiceCheckBox == null))
                {
                    this.cachedAutomaticServiceCheckBox = new CheckBox(this, TargetGroupAndServiceDialog.ControlIDs.AutomaticServiceCheckBox);
                }
                
                return this.cachedAutomaticServiceCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GroupSearchButton control
        /// </summary>
        /// <history>
        ///   [asttest] 10/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITargetGroupAndServiceDialogControls.GroupSearchButton
        {
            get
            {
                if ((this.cachedGroupSearchButton == null))
                {
                    this.cachedGroupSearchButton = new Button(this, TargetGroupAndServiceDialog.ControlIDs.GroupSearchButton);
                }
                
                return this.cachedGroupSearchButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ServiceNameTextBox control
        /// </summary>
        /// <history>
        ///   [asttest] 10/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ITargetGroupAndServiceDialogControls.ServiceNameTextBox
        {
            get
            {
                if ((this.cachedServiceNameTextBox == null))
                {
                    this.cachedServiceNameTextBox = new TextBox(this, TargetGroupAndServiceDialog.ControlIDs.ServiceNameTextBox);
                }
                
                return this.cachedServiceNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ServiceSearchButton control
        /// </summary>
        /// <history>
        ///   [asttest] 10/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITargetGroupAndServiceDialogControls.ServiceSearchButton
        {
            get
            {
                if ((this.cachedServiceSearchButton == null))
                {
                    this.cachedServiceSearchButton = new Button(this, TargetGroupAndServiceDialog.ControlIDs.ServiceSearchButton);
                }
                
                return this.cachedServiceSearchButton;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        ///   [asttest] 10/1/2008 Created
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
        ///   [asttest] 10/1/2008 Created
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
        ///   [asttest] 10/1/2008 Created
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
        ///   [asttest] 10/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button AutomaticService
        /// </summary>
        /// <history>
        ///   [asttest] 10/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAutomaticService()
        {
            this.Controls.AutomaticServiceCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button GroupSearch
        /// </summary>
        /// <history>
        ///   [asttest] 10/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickGroupSearch()
        {
            this.Controls.GroupSearchButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ServiceSearch
        /// </summary>
        /// <history>
        ///   [asttest] 10/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickServiceSearch()
        {
            this.Controls.ServiceSearchButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">App owning the dialog.</param>
        /// <history>
        ///   [asttest] 10/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app)
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
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        ///   [asttest] 10/1/2008 Created
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
            /// Control ID for GroupNameTextBox
            /// </summary>
            public const string GroupNameTextBox = "textBoxGroupName";
            
            /// <summary>
            /// Control ID for AutomaticServiceCheckBox
            /// </summary>
            public const string AutomaticServiceCheckBox = "checkBoxAutomaticService";
            
            /// <summary>
            /// Control ID for GroupSearchButton
            /// </summary>
            public const string GroupSearchButton = "buttonSearchGroup";
            
            /// <summary>
            /// Control ID for ServiceNameTextBox
            /// </summary>
            public const string ServiceNameTextBox = "serviceNameTextBox";
            
            /// <summary>
            /// Control ID for ServiceSearchButton
            /// </summary>
            public const string ServiceSearchButton = "browseButton";
        }
        #endregion
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        ///   [asttest] 10/1/2008 Created
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
            private const string ResourceDialogTitle = ";Add Monitoring Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring." +
                "dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Common.PageCommon" +
                "Resources;TemplateWizard";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrevious = ";< &Previous;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll" +
                ";Microsoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel;previousButt" +
                "on.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext = ";&Next >;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Mic" +
                "rosoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel;nextButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Create
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCreate = ";C&reate;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;CreateMP" +
                "Action";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AutomaticService
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAutomaticService = ";Monitor only &automatic service;ManagedString;Microsoft.EnterpriseManagement.UI." +
                "Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Service" +
                "StateProbePage;checkBoxAutomaticService.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  GroupSearch
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGroupSearch = ";...;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.A" +
                "ppearanceProperties;buttonBackColor.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ServiceSearch
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceServiceSearch = ";...;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.A" +
                "ppearanceProperties;buttonBackColor.Text";
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
            /// Caches the translated resource string for:  AutomaticService
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAutomaticService;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  GroupSearch
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGroupSearch;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ServiceSearch
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedServiceSearch;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            ///   [asttest] 10/1/2008 Created
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
            ///   [asttest] 10/1/2008 Created
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
            ///   [asttest] 10/1/2008 Created
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
            ///   [asttest] 10/1/2008 Created
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
            ///   [asttest] 10/1/2008 Created
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
            /// Exposes access to the AutomaticService translated resource string
            /// </summary>
            /// <history>
            ///   [asttest] 10/1/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AutomaticService
            {
                get
                {
                    if ((cachedAutomaticService == null))
                    {
                        cachedAutomaticService = CoreManager.MomConsole.GetIntlStr(ResourceAutomaticService);
                    }
                    
                    return cachedAutomaticService;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the GroupSearch translated resource string
            /// </summary>
            /// <history>
            ///   [asttest] 10/1/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string GroupSearch
            {
                get
                {
                    if ((cachedGroupSearch == null))
                    {
                        cachedGroupSearch = CoreManager.MomConsole.GetIntlStr(ResourceGroupSearch);
                    }
                    
                    return cachedGroupSearch;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ServiceSearch translated resource string
            /// </summary>
            /// <history>
            ///   [asttest] 10/1/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ServiceSearch
            {
                get
                {
                    if ((cachedServiceSearch == null))
                    {
                        cachedServiceSearch = CoreManager.MomConsole.GetIntlStr(ResourceServiceSearch);
                    }
                    
                    return cachedServiceSearch;
                }
            }
            #endregion
        }
        #endregion
    }
}
