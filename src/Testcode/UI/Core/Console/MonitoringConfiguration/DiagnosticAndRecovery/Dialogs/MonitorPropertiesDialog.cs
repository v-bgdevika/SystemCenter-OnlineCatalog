// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="MonitorGeneralPropertiesDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[sunsingh] 7/31/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.DiagnosticAndRecovery.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IMonitorGeneralPropertiesDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IMonitorGeneralPropertiesDialogControls, for MonitorGeneralPropertiesDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[sunsingh] 7/31/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IMonitorGeneralPropertiesDialogControls
    {
        /// <summary>
        /// Read-only property to access CloseButton
        /// </summary>
        Button CloseButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Tab0TabControl
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TabControl Tab0TabControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ParentMonitorComboBox
        /// </summary>
        ComboBox ParentMonitorComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ParentMonitorStaticControl
        /// </summary>
        StaticControl ParentMonitorStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MonitorIsEnabledCheckBox
        /// </summary>
        CheckBox MonitorIsEnabledCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectButton
        /// </summary>
        Button SelectButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MonitorTargetTextBox
        /// </summary>
        TextBox MonitorTargetTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MonitorTargetStaticControl
        /// </summary>
        StaticControl MonitorTargetStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HealthLibraryStaticControl
        /// </summary>
        StaticControl HealthLibraryStaticControl
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
        /// Read-only property to access GeneralPropertiesStaticControl
        /// </summary>
        StaticControl GeneralPropertiesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SpecifyTheNameAndDescriptionForTheMonitorYouAreCreatingStaticControl
        /// </summary>
        StaticControl SpecifyTheNameAndDescriptionForTheMonitorYouAreCreatingStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DescriptionOptionalTextBox
        /// </summary>
        TextBox DescriptionOptionalTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DescriptionOptionalStaticControl
        /// </summary>
        StaticControl DescriptionOptionalStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NameTextBox
        /// </summary>
        TextBox NameTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NameStaticControl
        /// </summary>
        StaticControl NameStaticControl
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
    /// 	[sunsingh] 7/31/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class MonitorPropertiesDialog : Dialog, IMonitorGeneralPropertiesDialogControls
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
        /// Cache to hold a reference to Tab0TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab0TabControl;
        
        /// <summary>
        /// Cache to hold a reference to ParentMonitorComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedParentMonitorComboBox;
        
        /// <summary>
        /// Cache to hold a reference to ParentMonitorStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedParentMonitorStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to MonitorIsEnabledCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedMonitorIsEnabledCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to SelectButton of type Button
        /// </summary>
        private Button cachedSelectButton;
        
        /// <summary>
        /// Cache to hold a reference to MonitorTargetTextBox of type TextBox
        /// </summary>
        private TextBox cachedMonitorTargetTextBox;
        
        /// <summary>
        /// Cache to hold a reference to MonitorTargetStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMonitorTargetStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HealthLibraryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHealthLibraryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ManagementPackStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedManagementPackStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to GeneralPropertiesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralPropertiesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyTheNameAndDescriptionForTheMonitorYouAreCreatingStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyTheNameAndDescriptionForTheMonitorYouAreCreatingStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DescriptionOptionalTextBox of type TextBox
        /// </summary>
        private TextBox cachedDescriptionOptionalTextBox;
        
        /// <summary>
        /// Cache to hold a reference to DescriptionOptionalStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDescriptionOptionalStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to NameTextBox of type TextBox
        /// </summary>
        private TextBox cachedNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to NameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNameStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of MonitorGeneralPropertiesDialog of type MomConsole
        /// </param>
        /// <history>
        /// 	[sunsingh] 7/31/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public MonitorPropertiesDialog(MomConsoleApp app)
            : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IMonitorGeneralPropertiesDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[sunsingh] 7/31/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IMonitorGeneralPropertiesDialogControls Controls
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
        ///  Property to handle checkbox MonitorIsEnabled
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/31/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool MonitorIsEnabled
        {
            get
            {
                return this.Controls.MonitorIsEnabledCheckBox.Checked;
            }
            
            set
            {
                this.Controls.MonitorIsEnabledCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ParentMonitor
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[sunsingh] 7/31/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ParentMonitorText
        {
            get
            {
                return this.Controls.ParentMonitorComboBox.Text;
            }
            
            set
            {
                this.Controls.ParentMonitorComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control MonitorTarget
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[sunsingh] 7/31/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string MonitorTargetText
        {
            get
            {
                return this.Controls.MonitorTargetTextBox.Text;
            }
            
            set
            {
                this.Controls.MonitorTargetTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control DescriptionOptional
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[sunsingh] 7/31/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DescriptionOptionalText
        {
            get
            {
                return this.Controls.DescriptionOptionalTextBox.Text;
            }
            
            set
            {
                this.Controls.DescriptionOptionalTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Name
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[sunsingh] 7/31/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string NameText
        {
            get
            {
                return this.Controls.NameTextBox.Text;
            }
            
            set
            {
                this.Controls.NameTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CloseButton control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/31/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMonitorGeneralPropertiesDialogControls.CloseButton
        {
            get
            {
                if ((this.cachedCloseButton == null))
                {
                    this.cachedCloseButton = new Button(this, MonitorPropertiesDialog.ControlIDs.CloseButton);
                }
                return this.cachedCloseButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab0TabControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/31/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IMonitorGeneralPropertiesDialogControls.Tab0TabControl
        {
            get
            {
                if ((this.cachedTab0TabControl == null))
                {
                    this.cachedTab0TabControl = new TabControl(this, MonitorPropertiesDialog.ControlIDs.Tab0TabControl);
                }
                return this.cachedTab0TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ParentMonitorComboBox control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/31/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IMonitorGeneralPropertiesDialogControls.ParentMonitorComboBox
        {
            get
            {
                if ((this.cachedParentMonitorComboBox == null))
                {                   //app.mainwindow
                    Window wndTemp = this.App.MainWindow;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    this.cachedParentMonitorComboBox = new ComboBox(wndTemp);
                }
                return this.cachedParentMonitorComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ParentMonitorStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/31/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMonitorGeneralPropertiesDialogControls.ParentMonitorStaticControl
        {
            get
            {
                if ((this.cachedParentMonitorStaticControl == null))
                {
                    this.cachedParentMonitorStaticControl = new StaticControl(this, MonitorPropertiesDialog.ControlIDs.ParentMonitorStaticControl);
                }
                return this.cachedParentMonitorStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitorIsEnabledCheckBox control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/31/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IMonitorGeneralPropertiesDialogControls.MonitorIsEnabledCheckBox
        {
            get
            {
                if ((this.cachedMonitorIsEnabledCheckBox == null))
                {
                    this.cachedMonitorIsEnabledCheckBox = new CheckBox(this, MonitorPropertiesDialog.ControlIDs.MonitorIsEnabledCheckBox);
                }
                return this.cachedMonitorIsEnabledCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectButton control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/31/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMonitorGeneralPropertiesDialogControls.SelectButton
        {
            get
            {
                if ((this.cachedSelectButton == null))
                {
                    this.cachedSelectButton = new Button(this, MonitorPropertiesDialog.ControlIDs.SelectButton);
                }
                return this.cachedSelectButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitorTargetTextBox control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/31/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IMonitorGeneralPropertiesDialogControls.MonitorTargetTextBox
        {
            get
            {
                if ((this.cachedMonitorTargetTextBox == null))
                {
                    this.cachedMonitorTargetTextBox = new TextBox(this, MonitorPropertiesDialog.ControlIDs.MonitorTargetTextBox);
                }
                return this.cachedMonitorTargetTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitorTargetStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/31/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMonitorGeneralPropertiesDialogControls.MonitorTargetStaticControl
        {
            get
            {
                if ((this.cachedMonitorTargetStaticControl == null))
                {
                    this.cachedMonitorTargetStaticControl = new StaticControl(this, MonitorPropertiesDialog.ControlIDs.MonitorTargetStaticControl);
                }
                return this.cachedMonitorTargetStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HealthLibraryStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/31/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMonitorGeneralPropertiesDialogControls.HealthLibraryStaticControl
        {
            get
            {
                if ((this.cachedHealthLibraryStaticControl == null))
                {
                    this.cachedHealthLibraryStaticControl = new StaticControl(this, MonitorPropertiesDialog.ControlIDs.HealthLibraryStaticControl);
                }
                return this.cachedHealthLibraryStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementPackStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/31/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMonitorGeneralPropertiesDialogControls.ManagementPackStaticControl
        {
            get
            {
                if ((this.cachedManagementPackStaticControl == null))
                {
                    this.cachedManagementPackStaticControl = new StaticControl(this, MonitorPropertiesDialog.ControlIDs.ManagementPackStaticControl);
                }
                return this.cachedManagementPackStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralPropertiesStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/31/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMonitorGeneralPropertiesDialogControls.GeneralPropertiesStaticControl
        {
            get
            {
                if ((this.cachedGeneralPropertiesStaticControl == null))
                {
                    this.cachedGeneralPropertiesStaticControl = new StaticControl(this, MonitorPropertiesDialog.ControlIDs.GeneralPropertiesStaticControl);
                }
                return this.cachedGeneralPropertiesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyTheNameAndDescriptionForTheMonitorYouAreCreatingStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/31/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMonitorGeneralPropertiesDialogControls.SpecifyTheNameAndDescriptionForTheMonitorYouAreCreatingStaticControl
        {
            get
            {
                if ((this.cachedSpecifyTheNameAndDescriptionForTheMonitorYouAreCreatingStaticControl == null))
                {
                    this.cachedSpecifyTheNameAndDescriptionForTheMonitorYouAreCreatingStaticControl = new StaticControl(this, MonitorPropertiesDialog.ControlIDs.SpecifyTheNameAndDescriptionForTheMonitorYouAreCreatingStaticControl);
                }
                return this.cachedSpecifyTheNameAndDescriptionForTheMonitorYouAreCreatingStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionOptionalTextBox control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/31/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IMonitorGeneralPropertiesDialogControls.DescriptionOptionalTextBox
        {
            get
            {
                if ((this.cachedDescriptionOptionalTextBox == null))
                {
                    this.cachedDescriptionOptionalTextBox = new TextBox(this, MonitorPropertiesDialog.ControlIDs.DescriptionOptionalTextBox);
                }
                return this.cachedDescriptionOptionalTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionOptionalStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/31/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMonitorGeneralPropertiesDialogControls.DescriptionOptionalStaticControl
        {
            get
            {
                if ((this.cachedDescriptionOptionalStaticControl == null))
                {
                    this.cachedDescriptionOptionalStaticControl = new StaticControl(this, MonitorPropertiesDialog.ControlIDs.DescriptionOptionalStaticControl);
                }
                return this.cachedDescriptionOptionalStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameTextBox control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/31/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IMonitorGeneralPropertiesDialogControls.NameTextBox
        {
            get
            {
                if ((this.cachedNameTextBox == null))
                {
                    this.cachedNameTextBox = new TextBox(this, MonitorPropertiesDialog.ControlIDs.NameTextBox);
                }
                return this.cachedNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/31/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMonitorGeneralPropertiesDialogControls.NameStaticControl
        {
            get
            {
                if ((this.cachedNameStaticControl == null))
                {
                    this.cachedNameStaticControl = new StaticControl(this, MonitorPropertiesDialog.ControlIDs.NameStaticControl);
                }
                return this.cachedNameStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Close
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/31/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickClose()
        {
            this.Controls.CloseButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button MonitorIsEnabled
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/31/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickMonitorIsEnabled()
        {
            this.Controls.MonitorIsEnabledCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Select
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/31/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSelect()
        {
            this.Controls.SelectButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">MomConsole owning the dialog.</param>)
        /// <history>
        /// 	[sunsingh] 7/31/2008 Created
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


        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/31/2008 Created
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
            private const string ResourceDialogTitle = ";{0} Properties;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Extensibility.UISDKResources;MPObjectFormatString";
           //;{0} - Properties;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Common.PageCommonResources;ModulePropertiesFmtStr
           //;{0} Properties;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Extensibility.UISDKResources;MPObjectFormatString


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
            /// Contains resource string for:  Tab0
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTab0 = "Tab0";
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Tab3 DNR tab
            /// </summary>
            /// <remark>            
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceDiagnosticAndRecoveryTab = ";Diagnostic and Recovery;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.DiagAndRecoveryPage;$this.TabName";
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ParentMonitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceParentMonitor = ";Parent m&onitor:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;M" +
                "icrosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.MonitorGeneralPage;par" +
                "entMonitorLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MonitorIsEnabled
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMonitorIsEnabled = ";Monitor is ena&bled;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dl" +
                "l;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.MonitorGeneralPage;" +
                "enabledCheckbox.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Select
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelect = ";&Select...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microso" +
                "ft.EnterpriseManagement.Internal.UI.Authoring.Pages.MonitorGeneralPage;browseBut" +
                "ton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MonitorTarget
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMonitorTarget = ";Monitor tar&get:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;M" +
                "icrosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.MonitorGeneralPage;tar" +
                "getLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  HealthLibrary
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceHealthLibrary = "Health Library";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ManagementPack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceManagementPack = ";Management pack:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;M" +
                "icrosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.MonitorGeneralPage;mpL" +
                "abel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  GeneralProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneralProperties = ";General properties;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll" +
                ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.MonitorGeneralPage;p" +
                "ageSectionLabel1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpecifyTheNameAndDescriptionForTheMonitorYouAreCreating
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecifyTheNameAndDescriptionForTheMonitorYouAreCreating = ";Specify the name and description for the monitor you are creating.;ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement." +
                "Internal.UI.Authoring.Pages.MonitorGeneralPage;specifyLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DescriptionOptional
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDescriptionOptional = ";&Description (Optional):;ManagedString;Microsoft.EnterpriseManagement.UI.Authori" +
                "ng.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.MonitorGeneral" +
                "Page;descriptionLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceName = ";Na&me:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.E" +
                "nterpriseManagement.Internal.UI.Authoring.Pages.NameAndDescriptionPage;nameLabel" +
                ".Text";
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
            /// Caches the translated resource string for:  Tab0
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab0;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ParentMonitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedParentMonitor;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MonitorIsEnabled
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonitorIsEnabled;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Select
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelect;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MonitorTarget
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonitorTarget;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  HealthLibrary
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHealthLibrary;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ManagementPack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedManagementPack;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  GeneralProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneralProperties;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpecifyTheNameAndDescriptionForTheMonitorYouAreCreating
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpecifyTheNameAndDescriptionForTheMonitorYouAreCreating;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DescriptionOptional
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDescriptionOptional;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedName;
               /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the cachedDiagnosticAndRecoveryTab
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDiagnosticAndRecoveryTab;
            #endregion
            
            #region Properties
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the DNR Tab Title 
        /// </summary>
        /// <history>
        /// 	[sunsingh] 26june08 Created                 
        /// </history>
        /// -----------------------------------------------------------------------------
        public static string DiagnosticAndRecoveryTabTitle
        {
            get
            {
                if ((cachedDiagnosticAndRecoveryTab == null))
                {
                    cachedDiagnosticAndRecoveryTab = CoreManager.MomConsole.GetIntlStr(ResourceDiagnosticAndRecoveryTab);
                }
                return cachedDiagnosticAndRecoveryTab;
            }
        }
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/31/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    if ((cachedDialogTitle == null))
                    {
                        cachedDialogTitle = "*" + CoreManager.MomConsole.GetIntlStr(ResourceDialogTitle).Replace("{0}", "") + "*";//CoreManager.MomConsole.GetIntlStr(ResourceDialogTitle);
                    }
                    return cachedDialogTitle;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Close translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/31/2008 Created
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
            /// Exposes access to the Tab0 translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/31/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tab0
            {
                get
                {
                    if ((cachedTab0 == null))
                    {
                        cachedTab0 = CoreManager.MomConsole.GetIntlStr(ResourceTab0);
                    }
                    return cachedTab0;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ParentMonitor translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/31/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ParentMonitor
            {
                get
                {
                    if ((cachedParentMonitor == null))
                    {
                        cachedParentMonitor = CoreManager.MomConsole.GetIntlStr(ResourceParentMonitor);
                    }
                    return cachedParentMonitor;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MonitorIsEnabled translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/31/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MonitorIsEnabled
            {
                get
                {
                    if ((cachedMonitorIsEnabled == null))
                    {
                        cachedMonitorIsEnabled = CoreManager.MomConsole.GetIntlStr(ResourceMonitorIsEnabled);
                    }
                    return cachedMonitorIsEnabled;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Select translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/31/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Select
            {
                get
                {
                    if ((cachedSelect == null))
                    {
                        cachedSelect = CoreManager.MomConsole.GetIntlStr(ResourceSelect);
                    }
                    return cachedSelect;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MonitorTarget translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/31/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MonitorTarget
            {
                get
                {
                    if ((cachedMonitorTarget == null))
                    {
                        cachedMonitorTarget = CoreManager.MomConsole.GetIntlStr(ResourceMonitorTarget);
                    }
                    return cachedMonitorTarget;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the HealthLibrary translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/31/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string HealthLibrary
            {
                get
                {
                    if ((cachedHealthLibrary == null))
                    {
                        cachedHealthLibrary = CoreManager.MomConsole.GetIntlStr(ResourceHealthLibrary);
                    }
                    return cachedHealthLibrary;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ManagementPack translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/31/2008 Created
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
            /// Exposes access to the GeneralProperties translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/31/2008 Created
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
            /// Exposes access to the SpecifyTheNameAndDescriptionForTheMonitorYouAreCreating translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/31/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpecifyTheNameAndDescriptionForTheMonitorYouAreCreating
            {
                get
                {
                    if ((cachedSpecifyTheNameAndDescriptionForTheMonitorYouAreCreating == null))
                    {
                        cachedSpecifyTheNameAndDescriptionForTheMonitorYouAreCreating = CoreManager.MomConsole.GetIntlStr(ResourceSpecifyTheNameAndDescriptionForTheMonitorYouAreCreating);
                    }
                    return cachedSpecifyTheNameAndDescriptionForTheMonitorYouAreCreating;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DescriptionOptional translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/31/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DescriptionOptional
            {
                get
                {
                    if ((cachedDescriptionOptional == null))
                    {
                        cachedDescriptionOptional = CoreManager.MomConsole.GetIntlStr(ResourceDescriptionOptional);
                    }
                    return cachedDescriptionOptional;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Name translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/31/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Name
            {
                get
                {
                    if ((cachedName == null))
                    {
                        cachedName = CoreManager.MomConsole.GetIntlStr(ResourceName);
                    }
                    return cachedName;
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
        /// 	[sunsingh] 7/31/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for CloseButton
            /// </summary>
            public const string CloseButton = "cancelButton";
            
            /// <summary>
            /// Control ID for Tab0TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab0TabControl = "tabPages";
            
            /// <summary>
            /// Control ID for ParentMonitorStaticControl
            /// </summary>
            public const string ParentMonitorStaticControl = "parentMonitorLabel";
            
            /// <summary>
            /// Control ID for MonitorIsEnabledCheckBox
            /// </summary>
            public const string MonitorIsEnabledCheckBox = "enabledCheckbox";
            
            /// <summary>
            /// Control ID for SelectButton
            /// </summary>
            public const string SelectButton = "browseButton";
            
            /// <summary>
            /// Control ID for MonitorTargetTextBox
            /// </summary>
            public const string MonitorTargetTextBox = "targetBox";
            
            /// <summary>
            /// Control ID for MonitorTargetStaticControl
            /// </summary>
            public const string MonitorTargetStaticControl = "targetLabel";
            
            /// <summary>
            /// Control ID for HealthLibraryStaticControl
            /// </summary>
            public const string HealthLibraryStaticControl = "mpTextLabel";
            
            /// <summary>
            /// Control ID for ManagementPackStaticControl
            /// </summary>
            public const string ManagementPackStaticControl = "mpLabel";
            
            /// <summary>
            /// Control ID for GeneralPropertiesStaticControl
            /// </summary>
            public const string GeneralPropertiesStaticControl = "pageSectionLabel1";
            
            /// <summary>
            /// Control ID for SpecifyTheNameAndDescriptionForTheMonitorYouAreCreatingStaticControl
            /// </summary>
            public const string SpecifyTheNameAndDescriptionForTheMonitorYouAreCreatingStaticControl = "specifyLabel";
            
            /// <summary>
            /// Control ID for DescriptionOptionalTextBox
            /// </summary>
            public const string DescriptionOptionalTextBox = "descriptionTextbox";
            
            /// <summary>
            /// Control ID for DescriptionOptionalStaticControl
            /// </summary>
            public const string DescriptionOptionalStaticControl = "descriptionLabel";
            
            /// <summary>
            /// Control ID for NameTextBox
            /// </summary>
            public const string NameTextBox = "nameTextbox";
            
            /// <summary>
            /// Control ID for NameStaticControl
            /// </summary>
            public const string NameStaticControl = "nameLabel";
        }
        #endregion
    }
}
