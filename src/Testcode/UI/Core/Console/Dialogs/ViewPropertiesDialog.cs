// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ViewPropertiesDialog.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[lucyra] 8/28/2005 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Dialogs
{
    #region Using directives

    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console;
    using System.Drawing;

    #endregion
    
    #region Interface Definition - IViewPropertiesDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IViewPropertiesDialogControls, for ViewPropertiesDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[lucyra] 8/28/2005 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IViewPropertiesDialogControls
    {
        /// <summary>
        /// Read-only property to access NewMPButton
        /// </summary>
        Button NewMPButton
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
        /// Read-only property to access ManagementPackComboBox
        /// </summary>
        ComboBox ManagementPackComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ManagementPackTextBox
        /// </summary>
        TextBox ManagementPackTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TargetThisViewAtStaticControl
        /// </summary>
        StaticControl TargetThisViewAtStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TargetThisViewAtEditComboBox
        /// </summary>
        EditComboBox TargetThisViewAtEditComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TargetThisViewAtTextBox
        /// </summary>
        TextBox TargetThisViewAtTextBox
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
        /// Read-only property to access DisplayNameStaticControl
        /// </summary>
        StaticControl DisplayNameStaticControl
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
        /// Read-only property to access DisplayNameTextBox
        /// </summary>
        TextBox DisplayNameTextBox
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
        /// Read-only property to access CriteriaListBox
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        ListBox CriteriaListBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl
        /// </summary>
        StaticControl CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ViewAllEventsStaticControl
        /// </summary>
        StaticControl ViewAllEventsStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ShowAllStateStaticControl
        /// </summary>
        StaticControl ShowAllStateStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ViewAllAlertsStaticControl
        /// </summary>
        StaticControl ViewAllAlertsStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ViewPerformanceStaticControl
        /// </summary>
        StaticControl ViewPerformanceStaticControl
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
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add dialog functionality description here.
    /// </summary>
    /// <history>
    /// 	[lucyra] 8/28/2005 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ViewPropertiesDialog : Dialog, IViewPropertiesDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to NewMPButton of type Button
        /// </summary>
        private Button cachedNewMPButton;
        
        /// <summary>
        /// Cache to hold a reference to ManagementPackStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedManagementPackStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ManagementPackComboBox of type EditComboBox
        /// </summary>
        private ComboBox cachedManagementPackComboBox;
        
        /// <summary>
        /// Cache to hold a reference to ManagementPackTextBox of type TextBox
        /// </summary>
        private TextBox cachedManagementPackTextBox;
        
        /// <summary>
        /// Cache to hold a reference to TargetThisViewAtStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTargetThisViewAtStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to TargetThisViewAtEditComboBox of type EditComboBox
        /// </summary>
        private EditComboBox cachedTargetThisViewAtEditComboBox;
        
        /// <summary>
        /// Cache to hold a reference to TargetThisViewAtTextBox of type TextBox
        /// </summary>
        private TextBox cachedTargetThisViewAtTextBox;
        
        /// <summary>
        /// Cache to hold a reference to DescriptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDescriptionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DisplayNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDisplayNameStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DescriptionTextBox of type TextBox
        /// </summary>
        private TextBox cachedDescriptionTextBox;
        
        /// <summary>
        /// Cache to hold a reference to DisplayNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedDisplayNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to Tab0TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab0TabControl;
        
        /// <summary>
        /// Cache to hold a reference to CriteriaListBox of type ListBox
        /// </summary>
        private ListBox cachedCriteriaListBox;
        
        /// <summary>
        /// Cache to hold a reference to CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCriteriaDescriptionClickTheUnderlinedValueToEditStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ViewAllEventsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedViewAllEventsStaticControl;

        /// <summary>
        /// Cache to hold a reference to ShowAllStateStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedShowAllStateStaticControl;

        /// <summary>
        /// Cache to hold a reference to ViewAllAlertsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedViewAllAlertsStaticControl;

        /// <summary>
        /// Cache to hold a reference to ViewPerformanceStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedViewPerformanceStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ToolStrip1 of type Toolbar
        /// </summary>
        private Toolbar cachedToolStrip1;
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ViewPropertiesDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[lucyra] 8/28/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ViewPropertiesDialog(ConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IViewPropertiesDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[lucyra] 8/28/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IViewPropertiesDialogControls Controls
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
        ///  Routine to set/get the text in control ManagementPack
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 8/28/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ManagementPackText
        {
            get
            {
                return this.Controls.ManagementPackComboBox.Text;
            }
            
            set
            {
                this.Controls.ManagementPackComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ManagementPack2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 8/28/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ManagementPack2Text
        {
            get
            {
                return this.Controls.ManagementPackTextBox.Text;
            }
            
            set
            {
                this.Controls.ManagementPackTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TargetThisViewAt
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 8/28/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TargetThisViewAtText
        {
            get
            {
                return this.Controls.TargetThisViewAtEditComboBox.Text;
            }
            
            set
            {
                this.Controls.TargetThisViewAtEditComboBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TargetThisViewAt2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 8/28/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TargetThisViewAt2Text
        {
            get
            {
                return this.Controls.TargetThisViewAtTextBox.Text;
            }
            
            set
            {
                this.Controls.TargetThisViewAtTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Description
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 8/28/2005 Created
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
        ///  Routine to set/get the text in control DisplayName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 8/28/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DisplayNameText
        {
            get
            {
                return this.Controls.DisplayNameTextBox.Text;
            }
            
            set
            {
                this.Controls.DisplayNameTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NewMPButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 8/28/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IViewPropertiesDialogControls.NewMPButton
        {
            get
            {
                if ((this.cachedNewMPButton == null))
                {
                    this.cachedNewMPButton = new Button(this, ViewPropertiesDialog.ControlIDs.NewMPButton);
                }
                return this.cachedNewMPButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementPackStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 8/28/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IViewPropertiesDialogControls.ManagementPackStaticControl
        {
            get
            {
                if ((this.cachedManagementPackStaticControl == null))
                {
                    this.cachedManagementPackStaticControl = new StaticControl(this, ViewPropertiesDialog.ControlIDs.ManagementPackStaticControl);
                }
                return this.cachedManagementPackStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementPackComboBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 8/28/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IViewPropertiesDialogControls.ManagementPackComboBox
        {
            get
            {
                if ((this.cachedManagementPackComboBox == null))
                {
                    this.cachedManagementPackComboBox = new ComboBox(this, ViewPropertiesDialog.ControlIDs.ManagementPackComboBox);
                }
                return this.cachedManagementPackComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementPackTextBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 8/28/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IViewPropertiesDialogControls.ManagementPackTextBox
        {
            get
            {
                if ((this.cachedManagementPackTextBox == null))
                {
                    Window wndTemp = this;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedManagementPackTextBox = new TextBox(wndTemp);
                }
                return this.cachedManagementPackTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TargetThisViewAtStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 8/28/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IViewPropertiesDialogControls.TargetThisViewAtStaticControl
        {
            get
            {
                if ((this.cachedTargetThisViewAtStaticControl == null))
                {
                    this.cachedTargetThisViewAtStaticControl = new StaticControl(this, ViewPropertiesDialog.ControlIDs.TargetThisViewAtStaticControl);
                }
                return this.cachedTargetThisViewAtStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TargetThisViewAtEditComboBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 8/28/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IViewPropertiesDialogControls.TargetThisViewAtEditComboBox
        {
            get
            {
                if ((this.cachedTargetThisViewAtEditComboBox == null))
                {
                    Window wndTemp = this;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 3); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    this.cachedTargetThisViewAtEditComboBox = new EditComboBox(wndTemp);
                }
                return this.cachedTargetThisViewAtEditComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TargetThisViewAtTextBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 8/28/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IViewPropertiesDialogControls.TargetThisViewAtTextBox
        {
            get
            {
                if ((this.cachedTargetThisViewAtTextBox == null))
                {
                    Window wndTemp = this;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 3); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedTargetThisViewAtTextBox = new TextBox(wndTemp);
                }
                return this.cachedTargetThisViewAtTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 8/28/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IViewPropertiesDialogControls.DescriptionStaticControl
        {
            get
            {
                if ((this.cachedDescriptionStaticControl == null))
                {
                    this.cachedDescriptionStaticControl = new StaticControl(this, ViewPropertiesDialog.ControlIDs.DescriptionStaticControl);
                }
                return this.cachedDescriptionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DisplayNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 8/28/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IViewPropertiesDialogControls.DisplayNameStaticControl
        {
            get
            {
                if ((this.cachedDisplayNameStaticControl == null))
                {
                    this.cachedDisplayNameStaticControl = new StaticControl(this, ViewPropertiesDialog.ControlIDs.DisplayNameStaticControl);
                }
                return this.cachedDisplayNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionTextBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 8/28/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IViewPropertiesDialogControls.DescriptionTextBox
        {
            get
            {
                if ((this.cachedDescriptionTextBox == null))
                {
                    this.cachedDescriptionTextBox = new TextBox(this, ViewPropertiesDialog.ControlIDs.DescriptionTextBox);
                }
                return this.cachedDescriptionTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DisplayNameTextBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 8/28/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IViewPropertiesDialogControls.DisplayNameTextBox
        {
            get
            {
                if ((this.cachedDisplayNameTextBox == null))
                {
                    this.cachedDisplayNameTextBox = new TextBox(this, ViewPropertiesDialog.ControlIDs.DisplayNameTextBox);
                }
                return this.cachedDisplayNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab0TabControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 8/28/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IViewPropertiesDialogControls.Tab0TabControl
        {
            get
            {
                if ((this.cachedTab0TabControl == null))
                {
                    this.cachedTab0TabControl = new TabControl(this, ViewPropertiesDialog.ControlIDs.Tab0TabControl);
                }
                return this.cachedTab0TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CriteriaListBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 8/28/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListBox IViewPropertiesDialogControls.CriteriaListBox
        {
            get
            {
                if ((this.cachedCriteriaListBox == null))
                {
                    this.cachedCriteriaListBox = new ListBox(this, ViewPropertiesDialog.ControlIDs.CriteriaListBox);
                }
                return this.cachedCriteriaListBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 8/28/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IViewPropertiesDialogControls.CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl
        {
            get
            {
                if ((this.cachedCriteriaDescriptionClickTheUnderlinedValueToEditStaticControl == null))
                {
                    this.cachedCriteriaDescriptionClickTheUnderlinedValueToEditStaticControl = new StaticControl(this, ViewPropertiesDialog.ControlIDs.CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl);
                }
                return this.cachedCriteriaDescriptionClickTheUnderlinedValueToEditStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ViewAllEventsStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 8/28/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IViewPropertiesDialogControls.ViewAllEventsStaticControl
        {
            get
            {
                if ((this.cachedViewAllEventsStaticControl == null))
                {
                    this.cachedViewAllEventsStaticControl = new StaticControl(this, ViewPropertiesDialog.ControlIDs.ViewAllEventsStaticControl);
                }
                return this.cachedViewAllEventsStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ShowAllStateStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 8/28/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IViewPropertiesDialogControls.ShowAllStateStaticControl
        {
            get
            {
                if ((this.cachedShowAllStateStaticControl == null))
                {
                    this.cachedShowAllStateStaticControl = new StaticControl(this, ViewPropertiesDialog.ControlIDs.ShowAllStateStaticControl);
                }
                return this.cachedShowAllStateStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ViewAllAlertsStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 8/28/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IViewPropertiesDialogControls.ViewAllAlertsStaticControl
        {
            get
            {
                if ((this.cachedViewAllAlertsStaticControl == null))
                {
                    this.cachedViewAllAlertsStaticControl = new StaticControl(this, ViewPropertiesDialog.ControlIDs.ViewAllAlertsStaticControl);
                }
                return this.cachedViewAllAlertsStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ViewPerformanceStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 8/28/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IViewPropertiesDialogControls.ViewPerformanceStaticControl
        {
            get
            {
                if ((this.cachedViewPerformanceStaticControl == null))
                {
                    this.cachedViewPerformanceStaticControl = new StaticControl(this);
                }
                return this.cachedViewPerformanceStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToolStrip1 control
        /// </summary>
        /// <history>
        /// 	[lucyra] 8/28/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IViewPropertiesDialogControls.ToolStrip1
        {
            get
            {
                if ((this.cachedToolStrip1 == null))
                {
                    this.cachedToolStrip1 = new Toolbar(this);
                }
                return this.cachedToolStrip1;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on Save and Close button
        /// </summary>
        /// <history>
        /// 	[lucyra] 8/30/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSaveAndClose()
        {
            try
            {
                this.Controls.ToolStrip1[Strings.SaveAndClose].Click();
                UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow);
                CoreManager.MomConsole.MainWindow.WaitForResponse();
            }
            catch (Maui.Core.Window.Exceptions.InvalidHWndException)
            {
                //Currently hitting this issue, even though dialog is closing.
                Utilities.LogMessage("Invalid HWnd was hit, but should be ok");
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click TitleBar close button
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/16/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public new virtual void ClickTitleBarClose()
        {
            try
            {
                this.AccessibleObject.Window.ClickTitleBarClose();
                UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow);
                CoreManager.MomConsole.MainWindow.WaitForResponse();
            }
            catch (Maui.Core.Window.Exceptions.InvalidHWndException)
            {
                //Currently hitting this issue, even though dialog is closing.
                Utilities.LogMessage("Invalid HWnd was hit, but should be ok");
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button NewMP
        /// </summary>
        /// <history>
        /// 	[lucyra] 8/28/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNewMP()
        {
            this.Controls.NewMPButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">ConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[lucyra] 8/28/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(
                    Strings.DialogTitle,
                    StringMatchSyntax.ExactMatch,
                    WindowClassNames.WinForms10Window8,
                    StringMatchSyntax.WildCard,
                    app,
                    Timeout);
            }

            catch (Exceptions.WindowNotFoundException ex)
            {
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
                        Strings.DialogTitle + "'");

                    // throw the existing WindowNotFound exception
                    throw ex;
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
        /// 	[lucyra] 8/28/2005 Created
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
            private const string ResourceDialogTitle = 
                ";Properties;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.SheetFramework;$this.Text";

            /// <summary>
            /// Contains resource string for: SaveAndClose
            /// </summary>
            private const string ResourceSaveAndClose = ";&Save and Close;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.AuthoringDialog;saveAndCloseButton.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  NewMP
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNewMP = ";New MP...;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMana" +
                "gement.Mom.UI.AuthoringDialog;newManagementPackButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ManagementPack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceManagementPack = ";Management Pack;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpri" +
                "seManagement.Mom.Internal.UI.Administration.TasksAndViews;taskMPColumnHeader.Tex" +
                "t";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TargetThisViewAt
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTargetThisViewAt = ";&Target this view at:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.En" +
                "terpriseManagement.Mom.UI.AuthoringDialog;targetTypeLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Description
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDescription = ";&Description;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseM" +
                "anagement.Mom.UI.AuthoringDialog;descriptionLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DisplayName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDisplayName = ";Display Na&me;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterprise" +
                "Management.Mom.UI.AuthoringDialog;nameLabel.Text";
            
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
            /// Contains resource string for:  CriteriaDescriptionClickTheUnderlinedValueToEdit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCriteriaDescriptionClickTheUnderlinedValueToEdit = ";Criteria description (click the underlined value to edit):;ManagedString;Microso" +
                "ft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.Cri" +
                "teriaControl.CriteriaControlResource;Description";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ViewAllEvents
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceViewAllEvents = ";View all events:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpr" +
                "iseManagement.Mom.Internal.UI.Views.EventViewCriteriaResource;CriteriaDescriptio" +
                "n";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ShowAllState
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceShowAllState = ";Show all state;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpris" +
                "eManagement.Mom.Internal.UI.Views.StateViewCriteriaResource;CriteriaDescription";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ViewAllAlerts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceViewAllAlerts = ";View all alerts:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpr" +
                "iseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;CriteriaDescriptio" +
                "n";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ViewPerformance
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceViewPerformance = ";View performance;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpr" +
                "iseManagement.Mom.Internal.UI.Views.PerformanceViewCriteriaResource;CriteriaDesc" +
                "ription";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ToolStrip1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceToolStrip1 = ";toolStrip1;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagem" +
                "ent.Mom.Internal.UI.PageFrameworks.SheetFramework;stripTop.Text";
            #endregion
            
            #region Private Members

            /// <summary>
            /// Caches the translated resource fir Save and Close
            /// </summary>
            private static string cachedSaveAndClose;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitle;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  NewMP
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNewMP;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ManagementPack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedManagementPack;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TargetThisViewAt
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTargetThisViewAt;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Description
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDescription;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DisplayName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDisplayName;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Tab0
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab0;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CriteriaDescriptionClickTheUnderlinedValueToEdit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCriteriaDescriptionClickTheUnderlinedValueToEdit;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ViewAllEvents
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedViewAllEvents;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ShowAllState
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedShowAllState;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ViewAllAlerts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedViewAllAlerts;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ViewPerformance
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedViewPerformance;
            
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
            /// 	[lucyra] 8/28/2005 Created
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
            /// Exposes access to the NewMP translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 8/28/2005 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NewMP
            {
                get
                {
                    if ((cachedNewMP == null))
                    {
                        cachedNewMP = CoreManager.MomConsole.GetIntlStr(ResourceNewMP);
                    }
                    return cachedNewMP;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ManagementPack translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 8/28/2005 Created
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
            /// Exposes access to the TargetThisViewAt translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 8/28/2005 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TargetThisViewAt
            {
                get
                {
                    if ((cachedTargetThisViewAt == null))
                    {
                        cachedTargetThisViewAt = CoreManager.MomConsole.GetIntlStr(ResourceTargetThisViewAt);
                    }
                    return cachedTargetThisViewAt;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Description translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 8/28/2005 Created
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
            /// Exposes access to the DisplayName translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 8/28/2005 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DisplayName
            {
                get
                {
                    if ((cachedDisplayName == null))
                    {
                        cachedDisplayName = CoreManager.MomConsole.GetIntlStr(ResourceDisplayName);
                    }
                    return cachedDisplayName;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Tab0 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 8/28/2005 Created
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
            /// Exposes access to the CriteriaDescriptionClickTheUnderlinedValueToEdit translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 8/28/2005 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CriteriaDescriptionClickTheUnderlinedValueToEdit
            {
                get
                {
                    if ((cachedCriteriaDescriptionClickTheUnderlinedValueToEdit == null))
                    {
                        cachedCriteriaDescriptionClickTheUnderlinedValueToEdit = CoreManager.MomConsole.GetIntlStr(ResourceCriteriaDescriptionClickTheUnderlinedValueToEdit);
                    }
                    return cachedCriteriaDescriptionClickTheUnderlinedValueToEdit;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ViewAllEvents translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 8/28/2005 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ViewAllEvents
            {
                get
                {
                    if ((cachedViewAllEvents == null))
                    {
                        cachedViewAllEvents = CoreManager.MomConsole.GetIntlStr(ResourceViewAllEvents);
                    }
                    return cachedViewAllEvents;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ShowAllState translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 8/28/2005 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ShowAllState
            {
                get
                {
                    if ((cachedShowAllState == null))
                    {
                        cachedShowAllState = CoreManager.MomConsole.GetIntlStr(ResourceShowAllState);
                    }
                    return cachedShowAllState;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ViewAllAlerts translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 8/28/2005 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ViewAllAlerts
            {
                get
                {
                    if ((cachedViewAllAlerts == null))
                    {
                        cachedViewAllAlerts = CoreManager.MomConsole.GetIntlStr(ResourceViewAllAlerts);
                    }
                    return cachedViewAllAlerts;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ViewPerformance translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 8/28/2005 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ViewPerformance
            {
                get
                {
                    if ((cachedViewPerformance == null))
                    {
                        cachedViewPerformance = CoreManager.MomConsole.GetIntlStr(ResourceViewPerformance);
                    }
                    return cachedViewPerformance;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ToolStrip1 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 8/28/2005 Created
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

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Save and Close translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 8/30/2005 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SaveAndClose
            {
                get
                {
                    if ((cachedSaveAndClose == null))
                    {
                        cachedSaveAndClose = CoreManager.MomConsole.GetIntlStr(ResourceSaveAndClose);
                    }
                    return cachedSaveAndClose;
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
        /// 	[lucyra] 8/28/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for NewMPButton
            /// </summary>
            public const string NewMPButton = "newManagementPackButton";
            
            /// <summary>
            /// Control ID for ManagementPackStaticControl
            /// </summary>
            public const string ManagementPackStaticControl = "managementPackLabel";
            
            /// <summary>
            /// Control ID for ManagementPackComboBox
            /// </summary>
            public const string ManagementPackComboBox = "managementPackCombo";
            
            /// <summary>
            /// Control ID for TargetThisViewAtStaticControl
            /// </summary>
            public const string TargetThisViewAtStaticControl = "targetTypeLabel";
            
            /// <summary>
            /// Control ID for DescriptionStaticControl
            /// </summary>
            public const string DescriptionStaticControl = "descriptionLabel";
            
            /// <summary>
            /// Control ID for DisplayNameStaticControl
            /// </summary>
            public const string DisplayNameStaticControl = "nameLabel";
            
            /// <summary>
            /// Control ID for DescriptionTextBox
            /// </summary>
            public const string DescriptionTextBox = "descriptionTextbox";
            
            /// <summary>
            /// Control ID for DisplayNameTextBox
            /// </summary>
            public const string DisplayNameTextBox = "nameTextBox";
            
            /// <summary>
            /// Control ID for Tab0TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab0TabControl = "mainTabControl";
            
            /// <summary>
            /// Control ID for CriteriaListBox
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string CriteriaListBox = "checkboxes";
            
            /// <summary>
            /// Control ID for CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl
            /// </summary>
            public const string CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl = "labelDescription";
            
            /// <summary>
            /// Control ID for ViewAllEventsStaticControl
            /// </summary>
            public const string ViewAllEventsStaticControl = "labelHeader";

            /// <summary>
            /// Control ID for ShowAllStateStaticControl
            /// </summary>
            public const string ShowAllStateStaticControl = "labelHeader";

            /// <summary>
            /// Control ID for ViewAllAlertsStaticControl
            /// </summary>
            public const string ViewAllAlertsStaticControl = "labelHeader";
            
            /// <summary>
            /// Control ID for ToolStrip1
            /// </summary>
            public const string ToolStrip1 = "mainToolstrip";
        }
        #endregion
    }
}
