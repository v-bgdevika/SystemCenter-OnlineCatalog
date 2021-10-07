// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="RollupMonitorGeneralPropertiesDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3 Project
// </project>
// <summary>
// 	MOMv3 Project
// </summary>
// <history>
// 	[ruhim] 4/13/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;

    #region Interface Definition - IRollupMonitorGeneralPropertiesDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IRollupMonitorGeneralPropertiesDialogControls, for RollupMonitorGeneralPropertiesDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 4/13/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IRollupMonitorGeneralPropertiesDialogControls
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
        /// Read-only property to access GeneralPropertiesStaticControl
        /// </summary>
        StaticControl GeneralPropertiesStaticControl
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
        /// Read-only property to access SpecifyTheNameAndDescriptionForTheMonitorStaticControl
        /// </summary>
        StaticControl SpecifyTheNameAndDescriptionForTheMonitorStaticControl
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
        /// Read-only property to access HelpStaticControl
        /// </summary>
        StaticControl HelpStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access GeneralPropertiesStaticControl3
        /// </summary>
        StaticControl GeneralPropertiesStaticControl3
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
    /// 	[ruhim] 4/13/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class RollupMonitorGeneralPropertiesDialog : Dialog, IRollupMonitorGeneralPropertiesDialogControls
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
        /// Cache to hold a reference to GeneralPropertiesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralPropertiesStaticControl;

        /// <summary>
        /// Cache to hold a reference to GeneralPropertiesStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralPropertiesStaticControl2;

        /// <summary>
        /// Cache to hold a reference to SpecifyTheNameAndDescriptionForTheMonitorStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyTheNameAndDescriptionForTheMonitorStaticControl;

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
        /// Cache to hold a reference to NewButton of type Button
        /// </summary>
        private Button cachedNewButton;

        /// <summary>
        /// Cache to hold a reference to SelectDestinationManagementPackComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedSelectDestinationManagementPackComboBox;

        /// <summary>
        /// Cache to hold a reference to ManagementPackStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedManagementPackStaticControl;

        /// <summary>
        /// Cache to hold a reference to SelectDestinationManagementPackStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectDestinationManagementPackStaticControl;

        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;

        /// <summary>
        /// Cache to hold a reference to GeneralPropertiesStaticControl3 of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralPropertiesStaticControl3;

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
        /// Owner of RollupMonitorGeneralPropertiesDialog of type App
        /// </param>
        /// <param name='windowCaption'>Dialog Title </param>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public RollupMonitorGeneralPropertiesDialog(ConsoleApp app, MonitoringConfiguration.WindowCaptions windowCaption)
            :
                base(app, Init(app, windowCaption))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
        }
        #endregion

        #region IRollupMonitorGeneralPropertiesDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IRollupMonitorGeneralPropertiesDialogControls Controls
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
        /// 	[ruhim] 4/13/2006 Created
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
        /// 	[ruhim] 4/13/2006 Created
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
        /// 	[ruhim] 4/13/2006 Created
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
        ///  Routine to set/get the text in control SelectDestinationManagementPack
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
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
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRollupMonitorGeneralPropertiesDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, RollupMonitorGeneralPropertiesDialog.ControlIDs.PreviousButton);
                }
                return this.cachedPreviousButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRollupMonitorGeneralPropertiesDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, RollupMonitorGeneralPropertiesDialog.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRollupMonitorGeneralPropertiesDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, RollupMonitorGeneralPropertiesDialog.ControlIDs.CreateButton);
                }
                return this.cachedCreateButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRollupMonitorGeneralPropertiesDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, RollupMonitorGeneralPropertiesDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralPropertiesStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRollupMonitorGeneralPropertiesDialogControls.GeneralPropertiesStaticControl
        {
            get
            {
                if ((this.cachedGeneralPropertiesStaticControl == null))
                {
                    this.cachedGeneralPropertiesStaticControl = new StaticControl(this, RollupMonitorGeneralPropertiesDialog.ControlIDs.GeneralPropertiesStaticControl);
                }
                return this.cachedGeneralPropertiesStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralPropertiesStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRollupMonitorGeneralPropertiesDialogControls.GeneralPropertiesStaticControl2
        {
            get
            {
                if ((this.cachedGeneralPropertiesStaticControl2 == null))
                {
                    this.cachedGeneralPropertiesStaticControl2 = new StaticControl(this, RollupMonitorGeneralPropertiesDialog.ControlIDs.GeneralPropertiesStaticControl2);
                }
                return this.cachedGeneralPropertiesStaticControl2;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyTheNameAndDescriptionForTheMonitorStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRollupMonitorGeneralPropertiesDialogControls.SpecifyTheNameAndDescriptionForTheMonitorStaticControl
        {
            get
            {
                if ((this.cachedSpecifyTheNameAndDescriptionForTheMonitorStaticControl == null))
                {
                    this.cachedSpecifyTheNameAndDescriptionForTheMonitorStaticControl = new StaticControl(this, RollupMonitorGeneralPropertiesDialog.ControlIDs.SpecifyTheNameAndDescriptionForTheMonitorStaticControl);
                }
                return this.cachedSpecifyTheNameAndDescriptionForTheMonitorStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitorIsEnabledCheckBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IRollupMonitorGeneralPropertiesDialogControls.MonitorIsEnabledCheckBox
        {
            get
            {
                if ((this.cachedMonitorIsEnabledCheckBox == null))
                {
                    this.cachedMonitorIsEnabledCheckBox = new CheckBox(this, RollupMonitorGeneralPropertiesDialog.ControlIDs.MonitorIsEnabledCheckBox);
                }
                return this.cachedMonitorIsEnabledCheckBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionOptionalTextBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IRollupMonitorGeneralPropertiesDialogControls.DescriptionOptionalTextBox
        {
            get
            {
                if ((this.cachedDescriptionOptionalTextBox == null))
                {
                    this.cachedDescriptionOptionalTextBox = new TextBox(this, RollupMonitorGeneralPropertiesDialog.ControlIDs.DescriptionOptionalTextBox);
                }
                return this.cachedDescriptionOptionalTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionOptionalStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRollupMonitorGeneralPropertiesDialogControls.DescriptionOptionalStaticControl
        {
            get
            {
                if ((this.cachedDescriptionOptionalStaticControl == null))
                {
                    this.cachedDescriptionOptionalStaticControl = new StaticControl(this, RollupMonitorGeneralPropertiesDialog.ControlIDs.DescriptionOptionalStaticControl);
                }
                return this.cachedDescriptionOptionalStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameTextBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IRollupMonitorGeneralPropertiesDialogControls.NameTextBox
        {
            get
            {
                if ((this.cachedNameTextBox == null))
                {
                    this.cachedNameTextBox = new TextBox(this, RollupMonitorGeneralPropertiesDialog.ControlIDs.NameTextBox);
                }
                return this.cachedNameTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRollupMonitorGeneralPropertiesDialogControls.NameStaticControl
        {
            get
            {
                if ((this.cachedNameStaticControl == null))
                {
                    this.cachedNameStaticControl = new StaticControl(this, RollupMonitorGeneralPropertiesDialog.ControlIDs.NameStaticControl);
                }
                return this.cachedNameStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NewButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRollupMonitorGeneralPropertiesDialogControls.NewButton
        {
            get
            {
                if ((this.cachedNewButton == null))
                {
                    this.cachedNewButton = new Button(this, RollupMonitorGeneralPropertiesDialog.ControlIDs.NewButton);
                }
                return this.cachedNewButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectDestinationManagementPackComboBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IRollupMonitorGeneralPropertiesDialogControls.SelectDestinationManagementPackComboBox
        {
            get
            {
                if ((this.cachedSelectDestinationManagementPackComboBox == null))
                {
                    this.cachedSelectDestinationManagementPackComboBox = new ComboBox(this, RollupMonitorGeneralPropertiesDialog.ControlIDs.SelectDestinationManagementPackComboBox);
                }
                return this.cachedSelectDestinationManagementPackComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementPackStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRollupMonitorGeneralPropertiesDialogControls.ManagementPackStaticControl
        {
            get
            {
                // The ID for this control (pageSectionLabel1) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedManagementPackStaticControl == null))
                {
                    Window wndTemp = this.App.MainWindow;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 6); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    this.cachedManagementPackStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedManagementPackStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectDestinationManagementPackStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRollupMonitorGeneralPropertiesDialogControls.SelectDestinationManagementPackStaticControl
        {
            get
            {
                // The ID for this control (label1) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedSelectDestinationManagementPackStaticControl == null))
                {
                    Window wndTemp = this.App.MainWindow;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 6); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    this.cachedSelectDestinationManagementPackStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedSelectDestinationManagementPackStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRollupMonitorGeneralPropertiesDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, RollupMonitorGeneralPropertiesDialog.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralPropertiesStaticControl3 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRollupMonitorGeneralPropertiesDialogControls.GeneralPropertiesStaticControl3
        {
            get
            {
                if ((this.cachedGeneralPropertiesStaticControl3 == null))
                {
                    this.cachedGeneralPropertiesStaticControl3 = new StaticControl(this, RollupMonitorGeneralPropertiesDialog.ControlIDs.GeneralPropertiesStaticControl3);
                }
                return this.cachedGeneralPropertiesStaticControl3;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectButton control
        /// </summary>
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRollupMonitorGeneralPropertiesDialogControls.SelectButton
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
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IRollupMonitorGeneralPropertiesDialogControls.MonitorTargetTextBox
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
        /// 	[ruhim] 4/13/2006 Created
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
        /// 	[ruhim] 4/13/2006 Created
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
        /// 	[ruhim] 4/13/2006 Created
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
        /// 	[ruhim] 4/13/2006 Created
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
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickMonitorIsEnabled()
        {
            this.Controls.MonitorIsEnabledCheckBox.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button New
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNew()
        {
            this.Controls.NewButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Select
        /// </summary>
        /// <history>
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
        ///  <param name="app">App owning the dialog.</param>
        /// <param name='windowCaption'>Dialog Title </param>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app, MonitoringConfiguration.WindowCaptions windowCaption)
        {
            string DialogTitle = MonitoringConfiguration.GetWindowCaption(windowCaption);
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
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
                        tempWindow =
                            new Window(
                                DialogTitle + "*", StringMatchSyntax.WildCard);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        //sleep to wait for window search
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);

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
                        "Failed to find window with title:  '" + DialogTitle + "'");

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
        /// 	[ruhim] 4/13/2006 Created
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
            private const string ResourceDialogTitle = "Create a new aggregate rollup monitor";

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
            /// Contains resource string for:  GeneralProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneralProperties = ";General Properties;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enter" +
                "priseManagement.Internal.UI.Authoring.Pages.NameAndDescriptionPage;$this.NavigationT" +
                "ext";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  GeneralProperties2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneralProperties2 = ";General properties;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enter" +
                "priseManagement.Internal.UI.Authoring.Pages.MonitorGeneralPage;p" +
                "ageSectionLabel1.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpecifyTheNameAndDescriptionForTheMonitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecifyTheNameAndDescriptionForTheMonitor = ";Specify the name and description for the monitor;ManagedString;Microsoft.MOM.UI." +
                "Components.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.SelectMana" +
                "gementPackPage;label1.Text";

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
                "ent.Internal.UI.Authoring.Pages.NameAndDescriptionPage;nameLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  New
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNew = ";&New...;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.Administration.GroupSettings.ResolutionStates;toolStripButt" +
                "onNew.Text";

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
            private const string ResourceSelectDestinationManagementPack = ";&Select destination management pack:;ManagedString;Microsoft.MOM.UI.Components.d" +
                "ll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.ManagementPackComboBo" +
                "xControl;label1.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mo" +
                "m.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  GeneralProperties3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneralProperties3 = ";General Properties;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enter" +
                "priseManagement.Internal.UI.Authoring.Pages.NameAndDescriptionPage;$this.NavigationT" +
                "ext";
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
            /// Caches the translated resource string for:  GeneralProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneralProperties;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  GeneralProperties2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneralProperties2;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpecifyTheNameAndDescriptionForTheMonitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpecifyTheNameAndDescriptionForTheMonitor;

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
            /// Caches the translated resource string for:  New
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNew;

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
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  GeneralProperties3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneralProperties3;
            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/13/2006 Created
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
            /// 	[ruhim] 4/13/2006 Created
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
            /// 	[ruhim] 4/13/2006 Created
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
            /// 	[ruhim] 4/13/2006 Created
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
            /// 	[ruhim] 4/13/2006 Created
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
            /// Exposes access to the GeneralProperties translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/13/2006 Created
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
            /// Exposes access to the GeneralProperties2 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/13/2006 Created
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
            /// Exposes access to the SpecifyTheNameAndDescriptionForTheMonitor translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/13/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpecifyTheNameAndDescriptionForTheMonitor
            {
                get
                {
                    if ((cachedSpecifyTheNameAndDescriptionForTheMonitor == null))
                    {
                        cachedSpecifyTheNameAndDescriptionForTheMonitor = CoreManager.MomConsole.GetIntlStr(ResourceSpecifyTheNameAndDescriptionForTheMonitor);
                    }
                    return cachedSpecifyTheNameAndDescriptionForTheMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MonitorIsEnabled translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/13/2006 Created
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
            /// 	[ruhim] 4/13/2006 Created
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
            /// 	[ruhim] 4/13/2006 Created
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
            /// Exposes access to the New translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/13/2006 Created
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
            /// Exposes access to the ManagementPack translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/13/2006 Created
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
            /// 	[ruhim] 4/13/2006 Created
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
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/13/2006 Created
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
            /// Exposes access to the GeneralProperties3 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/13/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string GeneralProperties3
            {
                get
                {
                    if ((cachedGeneralProperties3 == null))
                    {
                        cachedGeneralProperties3 = CoreManager.MomConsole.GetIntlStr(ResourceGeneralProperties3);
                    }
                    return cachedGeneralProperties3;
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
        /// 	[ruhim] 4/13/2006 Created
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
            /// Control ID for GeneralPropertiesStaticControl
            /// </summary>
            public const string GeneralPropertiesStaticControl = "textLinkLabel";

            /// <summary>
            /// Control ID for GeneralPropertiesStaticControl2
            /// </summary>
            public const string GeneralPropertiesStaticControl2 = "pageSectionLabel1";

            /// <summary>
            /// Control ID for SpecifyTheNameAndDescriptionForTheMonitorStaticControl
            /// </summary>
            public const string SpecifyTheNameAndDescriptionForTheMonitorStaticControl = "label1";

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
            /// Control ID for NewButton
            /// </summary>
            public const string NewButton = "newmpButton";

            /// <summary>
            /// Control ID for SelectDestinationManagementPackComboBox
            /// </summary>
            public const string SelectDestinationManagementPackComboBox = "comboBoxMp";

            /// <summary>
            /// Control ID for ManagementPackStaticControl
            /// </summary>
            public const string ManagementPackStaticControl = "pageSectionLabel1";

            /// <summary>
            /// Control ID for SelectDestinationManagementPackStaticControl
            /// </summary>
            public const string SelectDestinationManagementPackStaticControl = "label1";

            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";

            /// <summary>
            /// Control ID for GeneralPropertiesStaticControl3
            /// </summary>
            public const string GeneralPropertiesStaticControl3 = "headerLabel";

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
