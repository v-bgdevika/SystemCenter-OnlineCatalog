// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="GeneralProperties.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	MOMv3 UI Test Automation
// </summary>
// <history>
// 	[ruhim] 01-Sep-05 Created
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
    using System;
    
    #region Interface Definition - IGeneralPropertiesControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IGeneralPropertiesControls, for GeneralProperties.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 01-Sep-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IGeneralPropertiesControls
    {
        /// <summary>
        /// Read-only property to access Tab2TabControl
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TabControl Tab2TabControl
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
        /// Read-only property to access DescriptionTextBox
        /// </summary>
        TextBox DescriptionTextBox
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
        
        /// <summary>
        /// Read-only property to access ToolStrip1
        /// </summary>
        Toolbar ToolStrip1
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
        /// Read-only property to access TargetTextBox
        /// </summary>
        TextBox TargetTextBox
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
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the "General" TAB of the Windows Service Monitor Properties.
    /// This class manages the advanced functions for the "General" Tab Properties
    /// </summary>
    /// <history>
    /// 	[ruhim] 01-Sep-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class GeneralProperties : Dialog, IGeneralPropertiesControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion

        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to Tab2TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab2TabControl;

        /// <summary>
        /// Cache to hold a reference to MonitorIsEnabledCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedMonitorIsEnabledCheckBox;

        /// <summary>
        /// Cache to hold a reference to DescriptionTextBox of type TextBox
        /// </summary>
        private TextBox cachedDescriptionTextBox;

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

        /// <summary>
        /// Cache to hold a reference to ToolStrip1 of type Toolbar
        /// </summary>
        private Toolbar cachedToolStrip1;

        /// <summary>
        /// Cache to hold a reference to SelectButton of type Button
        /// </summary>
        private Button cachedSelectButton;

        /// <summary>
        /// Cache to hold a reference to TargetTextBox of type TextBox
        /// </summary>
        private TextBox cachedTargetTextBox;

        /// <summary>
        /// Cache to hold a reference to ParentMonitorComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedParentMonitorComboBox;

        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of GeneralProperties of type App
        /// </param>
        /// <history>
        /// 	[ruhim] 01-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------        
        public GeneralProperties(Maui.Core.App app)
            :
                base(app, Init(app))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
        }
        #endregion

        #region IGeneralProperties Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 01-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IGeneralPropertiesControls Controls
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
        /// 	[ruhim] 01-Sep-05 Created
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
        ///  Routine to set/get the text in control NoteTheServiceMustExistInTheComputerWhereTheTargetManagedEntityIsHosted
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 01-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DescriptionText
        {
            get
            {
                return this.Controls.DescriptionTextBox.Text;
            }

            set
            {
                this.Controls.DescriptionTextBox.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Name
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 01-Sep-05 Created
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

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Routine to set/get the text in the control Target
        /// </summary>
        /// <history>
        /// 	[mbickle] 10/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TargetText
        {
            get
            {
                return this.Controls.TargetTextBox.Text;
            }

            set
            {
                this.ClickSelect();
                SelectTargetTypeDialog targetType = new SelectTargetTypeDialog(CoreManager.MomConsole);
                UISynchronization.WaitForUIObjectReady(targetType, Constants.DefaultDialogTimeout);

                ListViewItemCollection col = targetType.Controls.ListView0.FindAllByText(value);
                ListViewItem result = null;
                //The Result of the collection col is going to be only ONE item. 
                foreach (ListViewItem item in col)
                {
                    result = item;
                }

                if (result != null)
                {
                    result.Click();
                }

                targetType.ClickOK();
                CoreManager.MomConsole.WaitForDialogClose(targetType, 30);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ParentMonitor
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 10/11/2006 Created
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
                // If the value isn't already set, then we'll set it.
                if (string.Compare(this.Controls.ParentMonitorComboBox.Text, value) != 0)
                {
                    this.Controls.ParentMonitorComboBox.Click();
                    Sleeper.Delay(5000);

                    Utilities.LogMessage("ParentMonitorText:: Find DropDown Window");
                    Window windowTemp = new Window(WindowType.Active).Extended.AccessibleObject.FindChild("DropDown").Window;

                    Utilities.LogMessage("ParentMonitorText:: Found DropDown Window");

                    TreeView monitorTree = new TreeView(
                        windowTemp,
                        "*",
                        StringMatchSyntax.WildCard,
                        WindowClassNames.WinFormsTreeView,
                        StringMatchSyntax.WildCard);

                    Utilities.LogMessage("ParentMonitorText:: RootNode: " + monitorTree.Root.Text);
                    //CoreManager.MomConsole.ExpandTreePath(value, monitorTree).Click();                    
                    monitorTree.Find(value, 1, false, SearchMode.DepthFirst, true).Click();
                }
                ////this.Controls.ParentMonitorComboBox.SelectByText(value, true);
            }
        }
        #endregion

        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab2TabControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 01-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IGeneralPropertiesControls.Tab2TabControl
        {
            get
            {
                if ((this.cachedTab2TabControl == null))
                {
                    this.cachedTab2TabControl = new TabControl(this, GeneralProperties.ControlIDs.Tab2TabControl);
                }
                return this.cachedTab2TabControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitorIsEnabledCheckBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 01-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IGeneralPropertiesControls.MonitorIsEnabledCheckBox
        {
            get
            {
                if ((this.cachedMonitorIsEnabledCheckBox == null))
                {
                    this.cachedMonitorIsEnabledCheckBox = new CheckBox(this, new QID(";[UIA, VisibleOnly]AutomationId = '" + GeneralProperties.ControlIDs.MonitorIsEnabledCheckBox + "'"), Constants.DefaultDialogTimeout);
                }
                return this.cachedMonitorIsEnabledCheckBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionTextBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 01-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IGeneralPropertiesControls.DescriptionTextBox
        {
            get
            {
                if ((this.cachedDescriptionTextBox == null))
                {
                    this.cachedDescriptionTextBox = new TextBox(this, GeneralProperties.ControlIDs.DescriptionTextBox);
                }
                return this.cachedDescriptionTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionOptionalStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 01-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGeneralPropertiesControls.DescriptionOptionalStaticControl
        {
            get
            {
                if ((this.cachedDescriptionOptionalStaticControl == null))
                {
                    this.cachedDescriptionOptionalStaticControl = new StaticControl(this, GeneralProperties.ControlIDs.DescriptionOptionalStaticControl);
                }
                return this.cachedDescriptionOptionalStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameTextBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 01-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IGeneralPropertiesControls.NameTextBox
        {
            get
            {
                if ((this.cachedNameTextBox == null))
                {
                    this.cachedNameTextBox = new TextBox(this, GeneralProperties.ControlIDs.NameTextBox);
                }
                return this.cachedNameTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 01-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGeneralPropertiesControls.NameStaticControl
        {
            get
            {
                if ((this.cachedNameStaticControl == null))
                {
                    this.cachedNameStaticControl = new StaticControl(this, GeneralProperties.ControlIDs.NameStaticControl);
                }
                return this.cachedNameStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToolStrip1 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 01-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IGeneralPropertiesControls.ToolStrip1
        {
            get
            {
                if ((this.cachedToolStrip1 == null))
                {
                    this.cachedToolStrip1 = new Toolbar(this, GeneralProperties.ControlIDs.ToolStrip1);
                }
                return this.cachedToolStrip1;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 06/04/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IGeneralPropertiesControls.SelectButton
        {
            get
            {
                if ((this.cachedSelectButton == null))
                {
                    this.cachedSelectButton = new Button(this, GeneralProperties.ControlIDs.SelectButton);
                }

                return this.cachedSelectButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TargetTextBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 10/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IGeneralPropertiesControls.TargetTextBox
        {
            get
            {
                if ((this.cachedTargetTextBox == null))
                {
                    this.cachedTargetTextBox = new TextBox(this, GeneralProperties.ControlIDs.TargetTextBox);
                }

                return this.cachedTargetTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ParentMonitorComboBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 10/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IGeneralPropertiesControls.ParentMonitorComboBox
        {
            get
            {
                ////if ((this.cachedParentMonitorComboBox == null))
                ////{
                this.cachedParentMonitorComboBox = new ComboBox(this, "*", StringMatchSyntax.WildCard, WindowClassNames.WinFormsComboBox, StringMatchSyntax.WildCard);
                ////}

                return this.cachedParentMonitorComboBox;
            }
        }
        #endregion

        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button MonitorIsEnabled
        /// </summary>
        /// <history>
        /// 	[ruhim] 01-Sep-05 Created
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
        /// 	[mbickle] 10/11/2006 Created
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
        ///  <param name="app">App owning the dialog.</param>)
        /// <history>
        /// 	[ruhim] 01-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(Maui.Core.App app)
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
                // it takes longer time to launch the properties dialog especially when UI is on Vista/Longhorn machines, so increasing the MAXTRIES here to 20
                const int MAXTRIES = 30;
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
        /// 	[ruhim] 01-Sep-05 Created
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
            /// Contains resource string for:  Tab2
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTab2 = "Tab2";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MonitorIsEnabled
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMonitorIsEnabled = ";M&onitor is enabled;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Ente" +
                "rpriseManagement.Internal.UI.Authoring.Pages.MonitorGeneralPage;" +
                "enabledCheckbox.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DescriptionOptional
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDescriptionOptional = ";&Description (Optional):;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft" +
                ".EnterpriseManagement.Internal.UI.Authoring.Pages.MonitorGeneral" +
                "Page;descriptionLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceName = ";Na&me:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagem" +
                "ent.Internal.UI.Authoring.Pages.MonitorGeneralPage;nameLabel.Tex" +
                "t";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ToolStrip1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceToolStrip1 = ";toolStrip1;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagem" +
                "ent.Mom.Internal.UI.PageFrameworks.SheetFramework;stripTop.Text";
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
            /// Caches the translated resource string for:  Tab2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab2;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MonitorIsEnabled
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonitorIsEnabled;

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
            /// Caches the translated resource string for:  ToolStrip1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedToolStrip1;
            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 01-Sep-05 Created
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
            /// Exposes access to the Tab2 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 01-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tab2
            {
                get
                {
                    if ((cachedTab2 == null))
                    {
                        cachedTab2 = CoreManager.MomConsole.GetIntlStr(ResourceTab2);
                    }
                    return cachedTab2;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MonitorIsEnabled translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 01-Sep-05 Created
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
            /// Exposes access to the DescriptionOptional translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 01-Sep-05 Created
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
            /// 	[ruhim] 01-Sep-05 Created
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

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ToolStrip1 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 01-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ToolStrip1
            {
                get
                {
                    if ((cachedToolStrip1 == null))
                    {
                        cachedToolStrip1 = CoreManager.MomConsole.GetIntlStr(ResourceToolStrip1);
                    }
                    return cachedToolStrip1;
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
        /// 	[ruhim] 01-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for Tab2TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab2TabControl = "tabPages";

            /// <summary>
            /// Control ID for MonitorIsEnabledCheckBox
            /// </summary>
            public const string MonitorIsEnabledCheckBox = "enabledCheckbox";

            /// <summary>
            /// Control ID for DescriptionTextBox
            /// </summary>
            public const string DescriptionTextBox = "descriptionTextbox";

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

            /// <summary>
            /// Control ID for ToolStrip1
            /// </summary>
            public const string ToolStrip1 = "stripTop";

            /// <summary>
            /// Control ID for SelectButton
            /// </summary>
            public const string SelectButton = "browseButton";

            /// <summary>
            /// Control ID for TargetTextBox
            /// </summary>
            public const string TargetTextBox = "targetBox";
        }
        #endregion
    }
}
