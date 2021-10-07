// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="DevicesDialog.cs">
//   Copyright (c) Microsoft Corporation 2010
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//   [dialac] 4/18/2010 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards.NetworkDeviceWizard.Dialogs
{
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    
    #region Interface Definition - IDevicesDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IDevicesDialogControls, for DevicesDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [dialac] 4/18/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IDevicesDialogControls
    {
        /// <summary>
        /// Gets read-only property to access PreviousButton
        /// </summary>
        Button PreviousButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access NextButton
        /// </summary>
        Button NextButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access DiscoverButton
        /// </summary>
        Button DiscoverButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access CancelButton
        /// </summary>
        Button CancelButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access AdvancedDiscoverySettingsButton
        /// </summary>
        Button AdvancedDiscoverySettingsButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access Devices List View
        /// </summary>
        ListView DevicesListView
        {
            get;
        }


        /// <summary>
        /// Read-only property to access ToolBar
        /// </summary>
        Toolbar DeviceButtonsToolStrip
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ToolbarImportButton
        /// </summary>
        Button ToolbarImportButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ToolbarAddButton
        /// </summary>
        Button ToolbarAddButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ToolbarEditButton
        /// </summary>
        Button ToolbarEditButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ToolbarRemoveButton
        /// </summary>
        Button ToolbarRemoveButton
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
    ///   [dialac] 4/18/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class DevicesDialog : Dialog, IDevicesDialogControls
    {
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
        /// Cache to hold a reference to DiscoverButton of type Button
        /// </summary>
        private Button cachedDiscoverButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to AdvancedDiscoverySettingsButton of type Button
        /// </summary>
        private Button cachedAdvancedDiscoverySettingsButton;

        /// <summary>
        /// Cache to hold a reference to DevicesistView of type ListView
        /// </summary>
        private ListView cachedDevicesListView;

        /// <summary>
        /// Cache to hold a reference to DevicesButtonsToolStrip of type Toolbar
        /// </summary>
        private Toolbar cachedDevicesButtonsToolStrip;

        /// <summary>
        /// Cache to hold a reference to ToolbarImportButton of type Button
        /// </summary>
        private Button cachedToolbarImportButton;

        /// <summary>
        /// Cache to hold a reference to ToolbarAddButton of type Button
        /// </summary>
        private Button cachedToolbarAddButton;

        /// <summary>
        /// Cache to hold a reference to ToolbarEditButton of type Button
        /// </summary>
        private Button cachedToolbarEditButton;

        /// <summary>
        /// Cache to hold a reference to ToolbarRemoveButton of type Button
        /// </summary>
        private Button cachedToolbarRemoveButton;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the DevicesDialog class.
        /// </summary>
        /// <param name='app'>
        /// Owner of DevicesDialog of type MomConsoleApp
        /// </param>
        /// <history>
        ///   [dialac] 4/18/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public DevicesDialog(MomConsoleApp app, int timeout) : 
                base(app, Init(app, timeout))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IDevicesDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [dialac] 4/18/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IDevicesDialogControls Controls
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
        ///  Gets access to the PreviousButton control
        /// </summary>
        /// <history>
        ///   [dialac] 4/18/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDevicesDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, DevicesDialog.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the NextButton control
        /// </summary>
        /// <history>
        ///   [dialac] 4/18/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDevicesDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, DevicesDialog.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the DiscoverButton control
        /// </summary>
        /// <history>
        ///   [dialac] 4/18/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDevicesDialogControls.DiscoverButton
        {
            get
            {
                if ((this.cachedDiscoverButton == null))
                {
                    this.cachedDiscoverButton = new Button(this, DevicesDialog.ControlIDs.DiscoverButton);
                }
                
                return this.cachedDiscoverButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the CancelButton control
        /// </summary>
        /// <history>
        ///   [dialac] 4/18/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDevicesDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, DevicesDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the AdvancedDiscoverySettingsButton control
        /// </summary>
        /// <history>
        ///   [dialac] 4/18/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDevicesDialogControls.AdvancedDiscoverySettingsButton
        {
            get
            {
                if ((this.cachedAdvancedDiscoverySettingsButton == null))
                {
                    this.cachedAdvancedDiscoverySettingsButton = new Button(this, DevicesDialog.ControlIDs.AdvancedDiscoverySettingsButton);
                }
                
                return this.cachedAdvancedDiscoverySettingsButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DevicesListView control
        /// </summary>
        /// <history>
        /// 	[dialac] 4/19/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IDevicesDialogControls.DevicesListView
        {
            get
            {
                if ((this.cachedDevicesListView == null))
                {
                    this.cachedDevicesListView = new ListView(this, DevicesDialog.ControlIDs.DevicesListView);
                }

                return this.cachedDevicesListView;
            }
        }

        /// <summary>
        /// Exposes access to the Toolbar control
        /// </summary>
        /// <history>
        ///     [v-bire] 6/8/2011 Created
        /// </history>
        Toolbar IDevicesDialogControls.DeviceButtonsToolStrip
        {
            get
            {
                if ((this.cachedDevicesButtonsToolStrip == null))
                {
                    this.cachedDevicesButtonsToolStrip = new Toolbar(this, new QID(";[UIA]AutomationId='toolStrip1'"), Control.DefaultWaitTimeout);
                }

                return this.cachedDevicesButtonsToolStrip;
            }
        }

        /// <summary>
        /// Exposes access to the ToolbarImportButton
        /// </summary>
        /// <histtory>
        ///     [v-bire] 6/8/2011 Created
        /// </histtory>
        Button IDevicesDialogControls.ToolbarImportButton
        {
            get
            {
                if (this.cachedToolbarImportButton == null)
                {
                    this.cachedToolbarImportButton = new Button(this, new QID(string.Format(";[UIA]Name='{0}'",ControlIDs.ToolbarImportButtonName)));
                }

                return this.cachedToolbarImportButton;
            }
        }

        /// <summary>
        /// Exposes access to the ToolbarAddButton
        /// </summary>
        /// <histtory>
        ///     [v-bire] 6/8/2011 Created
        /// </histtory>
        Button IDevicesDialogControls.ToolbarAddButton
        {
            get
            {
                if (this.cachedToolbarAddButton == null)
                {
                    this.cachedToolbarAddButton = new Button(this, new QID(string.Format(";[UIA]Name='{0}'", ControlIDs.ToolbarAddButtonName)));
                }

                return this.cachedToolbarAddButton;
            }
        }

        /// <summary>
        /// Exposes access to the ToolbarEditButton
        /// </summary>
        /// <histtory>
        ///     [v-bire] 6/8/2011 Created
        /// </histtory>
        Button IDevicesDialogControls.ToolbarEditButton
        {
            get
            {
                if (this.cachedToolbarEditButton == null)
                {
                    this.cachedToolbarEditButton = new Button(this, new QID(string.Format(";[UIA]Name='{0}'", ControlIDs.ToolbarEditButtonName)));
                }

                return this.cachedToolbarEditButton;
            }
        }

        /// <summary>
        /// Exposes access to the ToolbarRemoveButton
        /// </summary>
        /// <histtory>
        ///     [v-bire] 6/8/2011 Created
        /// </histtory>
        Button IDevicesDialogControls.ToolbarRemoveButton
        {
            get
            {
                if (this.cachedToolbarRemoveButton == null)
                {
                    this.cachedToolbarRemoveButton = new Button(this, new QID(string.Format(";[UIA]Name='{0}'", ControlIDs.ToolbarRemoveButtonName)));
                }

                return this.cachedToolbarRemoveButton;
            }
        }
        #endregion

        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        ///   [dialac] 4/18/2010 Created
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
        ///   [dialac] 4/18/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNext()
        {
            this.Controls.NextButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Discover
        /// </summary>
        /// <history>
        ///   [dialac] 4/18/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickDiscover()
        {
            this.Controls.DiscoverButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        ///   [dialac] 4/18/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button AdvancedDiscoverySettings
        /// </summary>
        /// <history>
        ///   [dialac] 4/18/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAdvancedDiscoverySettings()
        {
            this.Controls.AdvancedDiscoverySettingsButton.Click();
        }

        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">MomConsoleApp owning the dialog.</param>
        /// <param name="timeout">timeout.</param>
        /// <history>
        ///   [dialac] 4/18/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app, int timeout)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, timeout);
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
                        UISynchronization.WaitForUIObjectReady(tempWindow, timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Mom.Test.UI.Core.Common.Utilities.LogMessage("Attempt " + numberOfTries + " of " + maxTries);


                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(timeout);
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
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        ///   [dialac] 4/18/2010 Created
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
            /// Control ID for DiscoverButton
            /// </summary>
            public const string DiscoverButton = "commitButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for AdvancedDiscoverySettingsButton
            /// </summary>
            public const string AdvancedDiscoverySettingsButton = "advancedButton";

            /// <summary>
            /// Control ID for deviceButtonsToolStrip
            /// </summary>
            public const string DeviceButtonsToolStrip = "toolStrip1";

            /// <summary>
            /// Control ID for DevicesListView
            /// </summary>
            public const string DevicesListView = "devicesList";

            /// <summary>
            /// Control Name for ToolbarImportButton
            /// </summary>
            public const string ToolbarImportButtonName = "importButton";

            /// <summary>
            /// Control Name for ToolbarAddButton
            /// </summary>
            public const string ToolbarAddButtonName = "AddButton";

            /// <summary>
            /// Control Name for ToolbarEditButton
            /// </summary>
            public const string ToolbarEditButtonName = "editButton";

            /// <summary>
            /// Control Name for ToolbarRemoveButton
            /// </summary>
            public const string ToolbarRemoveButtonName = "removeButton";
        }
        #endregion
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        ///   [dialac] 4/18/2010 Created
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
            private const string ResourceDialogTitle = ";Computer and Device Management Wizard;ManagedString;" +
                "Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;" +
                "DiscoveryWizardCaption";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrevious = ";< &Previous;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.Res" +
                "ources.dll;Microsoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel.en" +
                ";previousButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext = ";&Next >;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.Resourc" +
                "es.dll;Microsoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel.en;nex" +
                "tButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Discover
            /// </summary>
            /// -----------------------------------------------------------------------------
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// ;Discover;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;DiscoveryText
            /// ;Discover;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.AdminResources;DiscoverActionText
            /// ;Discover;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.AdminResources;DiscoveryText
            /// ;Discover;ManagedString;Microsoft.SystemCenter.CrossPlatform.UI.Administration.resources.dll;Microsoft.SystemCenter.CrossPlatform.UI.Administration.AdminResources;DiscoverActionText
            /// ;Discover;ManagedString;Microsoft.SystemCenter.CrossPlatform.UI.Administration.resources.dll;Microsoft.SystemCenter.CrossPlatform.UI.Administration.AdminResources;DiscoveryText
            /// </remark>
            private const string ResourceDiscover = ";&Discover;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resourc" +
                "es.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResour" +
                "ces;DiscoverActionText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources." +
                "dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.OKCancelForm;c" +
                "ancelBtn.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AdvancedDiscoverySettings
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdvancedDiscoverySettings = ";Ad&vanced Discovery Settings...;ManagedString;Microsoft.EnterpriseManagement.UI." +
                "Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Admi" +
                "nistration.NetworkDiscovery.Devices;advancedButton.Text";



            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 4/18/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    if (GeneralDialog.CurrentWizardTitle != null)
                        return GeneralDialog.CurrentWizardTitle;
                    return CoreManager.MomConsole.GetIntlStr(ResourceDialogTitle);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Previous translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 4/18/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Previous
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourcePrevious);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Next translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 4/18/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Next
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceNext);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Discover translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 4/18/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Discover
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceDiscover);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Cancel translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 4/18/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Cancel
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceCancel);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the AdvancedDiscoverySettings translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 4/18/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdvancedDiscoverySettings
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceAdvancedDiscoverySettings);
                }
            }

          

            
            #endregion
        }
        #endregion
    }
}
