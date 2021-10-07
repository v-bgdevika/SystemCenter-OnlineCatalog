// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="MonitorGeneralPropertiesDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	MOMv3 UI Test Automation
// </summary>
// <history>
// 	[ruhim] 3/23/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    
    #region Interface Definition - IMonitorGeneralPropertiesDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IMonitorGeneralPropertiesDialogControls, for MonitorGeneralPropertiesDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 3/23/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IMonitorGeneralPropertiesDialogControls
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
        /// Read-only property to access EventLogTypeStaticControl
        /// </summary>
        StaticControl EventLogTypeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access BuildEventExpressionStaticControl
        /// </summary>
        StaticControl BuildEventExpressionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConfigureHealthStaticControl
        /// </summary>
        StaticControl ConfigureHealthStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConfigureAlertsStaticControl
        /// </summary>
        StaticControl ConfigureAlertsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access KnowledgeStaticControl
        /// </summary>
        StaticControl KnowledgeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access GeneralStaticControl
        /// </summary>
        StaticControl GeneralStaticControl
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
        /// Read-only property to access MonitorIsEnabledCheckBox
        /// </summary>
        CheckBox MonitorIsEnabledCheckBox
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
        
        /// <summary>
        /// Read-only property to access HelpStaticControl
        /// </summary>
        StaticControl HelpStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access GeneralPropertiesStaticControl2
        /// </summary>
        StaticControl GeneralPropertiesStaticControl2
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
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add dialog functionality description here.
    /// </summary>
    /// <history>
    /// 	[ruhim] 3/23/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class MonitorGeneralPropertiesDialog : Dialog, IMonitorGeneralPropertiesDialogControls
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
        /// Cache to hold a reference to EventLogTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEventLogTypeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to BuildEventExpressionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedBuildEventExpressionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureHealthStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureHealthStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureAlertsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureAlertsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to KnowledgeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedKnowledgeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to GeneralStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to GeneralPropertiesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralPropertiesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyTheNameAndDescriptionForTheMonitorYouAreCreatingStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyTheNameAndDescriptionForTheMonitorYouAreCreatingStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to MonitorIsEnabledCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedMonitorIsEnabledCheckBox;
        
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
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to GeneralPropertiesStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralPropertiesStaticControl2;

        /// <summary>
        /// Cache to hold a reference to ParentMonitorComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedParentMonitorComboBox;

        /// <summary>
        /// Cache to hold a reference to ParentMonitorStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedParentMonitorStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectButton of type Button
        /// </summary>
        private Button cachedSelectButton;

        /// <summary>
        /// Cache to hold a reference to MonitorTargetTextBox of type TextBox
        /// </summary>
        private TextBox cachedMonitorTargetTextBox;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of MonitorGeneralPropertiesDialog of type App
        /// </param>
        /// <history>
        /// 	[ruhim] 3/23/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public MonitorGeneralPropertiesDialog(ConsoleApp app)
            : 
                base(app, Init(app))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);  
        }
        #endregion
        
        #region IMonitorGeneralPropertiesDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 3/23/2006 Created
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
        /// 	[ruhim] 3/23/2006 Created
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
        ///  Routine to set/get the text in control DescriptionOptional
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 3/23/2006 Created
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
        /// 	[ruhim] 3/23/2006 Created
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

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Routine to set/get the text in the control MonitorTarget
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 10/11/2006 Created
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


        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/23/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMonitorGeneralPropertiesDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, MonitorGeneralPropertiesDialog.ControlIDs.PreviousButton);
                }
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/23/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMonitorGeneralPropertiesDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, MonitorGeneralPropertiesDialog.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/23/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMonitorGeneralPropertiesDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, MonitorGeneralPropertiesDialog.ControlIDs.CreateButton);
                }
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/23/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMonitorGeneralPropertiesDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, MonitorGeneralPropertiesDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitorTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/23/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMonitorGeneralPropertiesDialogControls.MonitorTypeStaticControl
        {
            get
            {
                if ((this.cachedMonitorTypeStaticControl == null))
                {
                    this.cachedMonitorTypeStaticControl = new StaticControl(this, MonitorGeneralPropertiesDialog.ControlIDs.MonitorTypeStaticControl);
                }
                return this.cachedMonitorTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EventLogTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/23/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMonitorGeneralPropertiesDialogControls.EventLogTypeStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedEventLogTypeStaticControl == null))
                {
                    Window wndTemp = this.App.MainWindow;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedEventLogTypeStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedEventLogTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BuildEventExpressionStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/23/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMonitorGeneralPropertiesDialogControls.BuildEventExpressionStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedBuildEventExpressionStaticControl == null))
                {
                    Window wndTemp = this.App.MainWindow;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedBuildEventExpressionStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedBuildEventExpressionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureHealthStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/23/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMonitorGeneralPropertiesDialogControls.ConfigureHealthStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedConfigureHealthStaticControl == null))
                {
                    Window wndTemp = this.App.MainWindow;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedConfigureHealthStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedConfigureHealthStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureAlertsStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/23/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMonitorGeneralPropertiesDialogControls.ConfigureAlertsStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedConfigureAlertsStaticControl == null))
                {
                    Window wndTemp = this.App.MainWindow;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 3); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedConfigureAlertsStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedConfigureAlertsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the KnowledgeStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/23/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMonitorGeneralPropertiesDialogControls.KnowledgeStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedKnowledgeStaticControl == null))
                {
                    Window wndTemp = this.App.MainWindow;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 4); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedKnowledgeStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedKnowledgeStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/23/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMonitorGeneralPropertiesDialogControls.GeneralStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedGeneralStaticControl == null))
                {
                    Window wndTemp = this.App.MainWindow;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 5); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedGeneralStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedGeneralStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralPropertiesStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/23/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMonitorGeneralPropertiesDialogControls.GeneralPropertiesStaticControl
        {
            get
            {
                if ((this.cachedGeneralPropertiesStaticControl == null))
                {
                    this.cachedGeneralPropertiesStaticControl = new StaticControl(this, MonitorGeneralPropertiesDialog.ControlIDs.GeneralPropertiesStaticControl);
                }
                return this.cachedGeneralPropertiesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyTheNameAndDescriptionForTheMonitorYouAreCreatingStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/23/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMonitorGeneralPropertiesDialogControls.SpecifyTheNameAndDescriptionForTheMonitorYouAreCreatingStaticControl
        {
            get
            {
                if ((this.cachedSpecifyTheNameAndDescriptionForTheMonitorYouAreCreatingStaticControl == null))
                {
                    this.cachedSpecifyTheNameAndDescriptionForTheMonitorYouAreCreatingStaticControl = new StaticControl(this, MonitorGeneralPropertiesDialog.ControlIDs.SpecifyTheNameAndDescriptionForTheMonitorYouAreCreatingStaticControl);
                }
                return this.cachedSpecifyTheNameAndDescriptionForTheMonitorYouAreCreatingStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitorIsEnabledCheckBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/23/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IMonitorGeneralPropertiesDialogControls.MonitorIsEnabledCheckBox
        {
            get
            {
                if ((this.cachedMonitorIsEnabledCheckBox == null))
                {
                    this.cachedMonitorIsEnabledCheckBox = new CheckBox(this, MonitorGeneralPropertiesDialog.ControlIDs.MonitorIsEnabledCheckBox);
                }
                return this.cachedMonitorIsEnabledCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionOptionalTextBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/23/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IMonitorGeneralPropertiesDialogControls.DescriptionOptionalTextBox
        {
            get
            {
                if ((this.cachedDescriptionOptionalTextBox == null))
                {
                    this.cachedDescriptionOptionalTextBox = new TextBox(this, MonitorGeneralPropertiesDialog.ControlIDs.DescriptionOptionalTextBox);
                }
                return this.cachedDescriptionOptionalTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionOptionalStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/23/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMonitorGeneralPropertiesDialogControls.DescriptionOptionalStaticControl
        {
            get
            {
                if ((this.cachedDescriptionOptionalStaticControl == null))
                {
                    this.cachedDescriptionOptionalStaticControl = new StaticControl(this, MonitorGeneralPropertiesDialog.ControlIDs.DescriptionOptionalStaticControl);
                }
                return this.cachedDescriptionOptionalStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameTextBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/23/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IMonitorGeneralPropertiesDialogControls.NameTextBox
        {
            get
            {
                if ((this.cachedNameTextBox == null))
                {
                    this.cachedNameTextBox = new TextBox(this, MonitorGeneralPropertiesDialog.ControlIDs.NameTextBox);
                }
                return this.cachedNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/23/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMonitorGeneralPropertiesDialogControls.NameStaticControl
        {
            get
            {
                if ((this.cachedNameStaticControl == null))
                {
                    this.cachedNameStaticControl = new StaticControl(this, MonitorGeneralPropertiesDialog.ControlIDs.NameStaticControl);
                }
                return this.cachedNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/23/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMonitorGeneralPropertiesDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, MonitorGeneralPropertiesDialog.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralPropertiesStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/23/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMonitorGeneralPropertiesDialogControls.GeneralPropertiesStaticControl2
        {
            get
            {
                if ((this.cachedGeneralPropertiesStaticControl2 == null))
                {
                    this.cachedGeneralPropertiesStaticControl2 = new StaticControl(this, MonitorGeneralPropertiesDialog.ControlIDs.GeneralPropertiesStaticControl2);
                }
                return this.cachedGeneralPropertiesStaticControl2;
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
        ComboBox IMonitorGeneralPropertiesDialogControls.ParentMonitorComboBox
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

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ParentMonitorStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 10/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMonitorGeneralPropertiesDialogControls.ParentMonitorStaticControl
        {
            get
            {
                if ((this.cachedParentMonitorStaticControl == null))
                {
                    this.cachedParentMonitorStaticControl = new StaticControl(this, MonitorGeneralPropertiesDialog.ControlIDs.ParentMonitorStaticControl);
                }

                return this.cachedParentMonitorStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 10/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMonitorGeneralPropertiesDialogControls.SelectButton
        {
            get
            {
                if ((this.cachedSelectButton == null))
                {
                    this.cachedSelectButton = new Button(this, MonitorGeneralPropertiesDialog.ControlIDs.SelectButton);
                }

                return this.cachedSelectButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitorTargetTextBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 10/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IMonitorGeneralPropertiesDialogControls.MonitorTargetTextBox
        {
            get
            {
                if ((this.cachedMonitorTargetTextBox == null))
                {
                    this.cachedMonitorTargetTextBox = new TextBox(this, MonitorGeneralPropertiesDialog.ControlIDs.MonitorTargetTextBox);
                }

                return this.cachedMonitorTargetTextBox;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/23/2006 Created
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
        /// 	[ruhim] 3/23/2006 Created
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
        /// 	[ruhim] 3/23/2006 Created
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
        /// 	[ruhim] 3/23/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button MonitorIsEnabled
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/23/2006 Created
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
        /// 	[ruhim] 3/23/2006 Created
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
                const int MAXTRIES = 10;
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
        /// 	[ruhim] 3/23/2006 Created
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
            private const string ResourceMonitorType = ";Monitor Type;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseM" +
                "anagement.Internal.UI.Authoring.Pages.ChooseMonitorTypePage;$this.TabName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EventLogType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEventLogType = ";Event Log Type;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpris" +
                "eManagement.Internal.UI.Authoring.Pages.EvtLogDataSource;$this.NavigationText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  BuildEventExpression
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceBuildEventExpression = ";Build Event Expression;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.E" +
                "nterpriseManagement.Internal.UI.Authoring.Pages.ExpressionEvaluatorCondition;$this.N" +
                "avigationText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureHealth
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureHealth = ";Configure Health;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpr" +
                "iseManagement.Internal.UI.Authoring.Pages.OperationalStatesMappi" +
                "ngPage;$this.NavigationText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureAlerts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureAlerts = ";Configure Alerts;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpr" +
                "iseManagement.Internal.UI.Authoring.Pages.AlertConfiguration;$this.NavigationText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Knowledge
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceKnowledge = ";Knowledge;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMana" +
                "gement.Internal.UI.Authoring.Pages.MonitorKnowledgePage;$this.TabName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  General
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneral = ";General;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.Administration.AdminResources;GeneralPropertyPageTabText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  GeneralProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneralProperties = ";General properties;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enter" +
                "priseManagement.Internal.UI.Authoring.Pages.MonitorGeneralPage;p" +
                "ageSectionLabel1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpecifyTheNameAndDescriptionForTheMonitorYouAreCreating
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecifyTheNameAndDescriptionForTheMonitorYouAreCreating = ";Specify the name and description for the monitor you are creating.;ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI." +
                "Authoring.Pages.MonitorGeneralPage;label1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MonitorIsEnabled
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMonitorIsEnabled = ";M&onitor is enabled;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.Ente" +
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
                "ent.Internal.UI.Authoring.Pages.NameAndDescriptionPage;nameLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mo" +
                "m.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  GeneralProperties2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneralProperties2 = ";General Properties;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enter" +
                "priseManagement.Internal.UI.Authoring.Pages.NameAndDescriptionPage;$this.NavigationT" +
                "ext";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ParentMonitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceParentMonitor = ";&Parent monitor:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;M" +
                "icrosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.MonitorGeneralPage;par" +
                "entMonitorLabel.Text";
            
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
            /// Caches the translated resource string for:  EventLogType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEventLogType;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  BuildEventExpression
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBuildEventExpression;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureHealth
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigureHealth;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureAlerts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigureAlerts;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Knowledge
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedKnowledge;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  General
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneral;
            
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
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  GeneralProperties2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneralProperties2;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ParentMonitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedParentMonitor;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/23/2006 Created
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
            /// 	[ruhim] 3/23/2006 Created
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
            /// 	[ruhim] 3/23/2006 Created
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
            /// 	[ruhim] 3/23/2006 Created
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
            /// 	[ruhim] 3/23/2006 Created
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
            /// 	[ruhim] 3/23/2006 Created
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
            /// Exposes access to the EventLogType translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/23/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EventLogType
            {
                get
                {
                    if ((cachedEventLogType == null))
                    {
                        cachedEventLogType = CoreManager.MomConsole.GetIntlStr(ResourceEventLogType);
                    }
                    return cachedEventLogType;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the BuildEventExpression translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/23/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string BuildEventExpression
            {
                get
                {
                    if ((cachedBuildEventExpression == null))
                    {
                        cachedBuildEventExpression = CoreManager.MomConsole.GetIntlStr(ResourceBuildEventExpression);
                    }
                    return cachedBuildEventExpression;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfigureHealth translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/23/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfigureHealth
            {
                get
                {
                    if ((cachedConfigureHealth == null))
                    {
                        cachedConfigureHealth = CoreManager.MomConsole.GetIntlStr(ResourceConfigureHealth);
                    }
                    return cachedConfigureHealth;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfigureAlerts translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/23/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfigureAlerts
            {
                get
                {
                    if ((cachedConfigureAlerts == null))
                    {
                        cachedConfigureAlerts = CoreManager.MomConsole.GetIntlStr(ResourceConfigureAlerts);
                    }
                    return cachedConfigureAlerts;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Knowledge translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/23/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Knowledge
            {
                get
                {
                    if ((cachedKnowledge == null))
                    {
                        cachedKnowledge = CoreManager.MomConsole.GetIntlStr(ResourceKnowledge);
                    }
                    return cachedKnowledge;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the General translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/23/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string General
            {
                get
                {
                    if ((cachedGeneral == null))
                    {
                        cachedGeneral = CoreManager.MomConsole.GetIntlStr(ResourceGeneral);
                    }
                    return cachedGeneral;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the GeneralProperties translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/23/2006 Created
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
            /// 	[ruhim] 3/23/2006 Created
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
            /// Exposes access to the MonitorIsEnabled translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/23/2006 Created
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
            /// 	[ruhim] 3/23/2006 Created
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
            /// 	[ruhim] 3/23/2006 Created
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
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/23/2006 Created
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
            /// Exposes access to the GeneralProperties2 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/23/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string GeneralProperties2
            {
                get
                {
                    if ((cachedGeneralProperties2 == null))
                    {
                        cachedGeneralProperties2 = CoreManager.MomConsole.GetIntlStr(ResourceGeneralProperties2);
                    }
                    return cachedGeneralProperties2;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ParentMonitor translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 10/11/2006 Created
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
            #endregion
        }
        #endregion
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[ruhim] 3/23/2006 Created
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
            /// Control ID for EventLogTypeStaticControl
            /// </summary>
            public const string EventLogTypeStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for BuildEventExpressionStaticControl
            /// </summary>
            public const string BuildEventExpressionStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ConfigureHealthStaticControl
            /// </summary>
            public const string ConfigureHealthStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ConfigureAlertsStaticControl
            /// </summary>
            public const string ConfigureAlertsStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for KnowledgeStaticControl
            /// </summary>
            public const string KnowledgeStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for GeneralStaticControl
            /// </summary>
            public const string GeneralStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for GeneralPropertiesStaticControl
            /// </summary>
            public const string GeneralPropertiesStaticControl = "pageSectionLabel1";
            
            /// <summary>
            /// Control ID for SpecifyTheNameAndDescriptionForTheMonitorYouAreCreatingStaticControl
            /// </summary>
            public const string SpecifyTheNameAndDescriptionForTheMonitorYouAreCreatingStaticControl = "label1";
            
            /// <summary>
            /// Control ID for MonitorIsEnabledCheckBox
            /// </summary>
            public const string MonitorIsEnabledCheckBox = "enabledCheckbox";
            
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
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for GeneralPropertiesStaticControl2
            /// </summary>
            public const string GeneralPropertiesStaticControl2 = "headerLabel";

            /// <summary>
            /// Control ID for ParentMonitorStaticControl
            /// </summary>
            public const string ParentMonitorStaticControl = "parentMonitorLabel";

            /// <summary>
            /// Control ID for SelectButton
            /// </summary>
            public const string SelectButton = "browseButton";

            /// <summary>
            /// Control ID for MonitorTargetTextBox
            /// </summary>
            public const string MonitorTargetTextBox = "targetBox";
        }
        #endregion
    }
}
