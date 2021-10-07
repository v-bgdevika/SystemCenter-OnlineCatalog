// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SNMPSettingsProperties.cs">
// 	Copyright (c) Microsoft Corporation 2007
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// [v-bire] 31 DEC 2010 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.SNMPMonitor.Dialogs
{
    #region Using directive
    using System;
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console;
    #endregion

    #region Interface Definition - ISnmpProviderDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISnmpProviderDialogControls, for SnmpProviderDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[v-bire] 31 DEC 2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISnmpProviderDialogControls
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
        /// Read-only property to access UseDiscoveryCommunityStringRadioButton
        /// </summary>
        RadioButton UseDiscoveryCommunityStringRadioButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access UseCustomCommunityStringRadioButton
        /// </summary>
        RadioButton UseCustomCommunityStringRadioButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access CommunityStringTextBox
        /// </summary>
        TextBox CommunityStringTextBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access NumericDropDownSpinner
        /// </summary>
        Spinner NumericDropDownSpinner
        {
            get;
        }

        /// <summary>
        /// Read-only property to access UnitComboBox
        /// </summary>
        ComboBox UnitComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ObjectIdentifierDataGrid
        /// </summary>
        DataGrid ObjectIdentifierDataGrid
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AllTrapsCheckBox
        /// </summary>
        CheckBox AllTrapsCheckBox
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
    /// 	[v-bire] 31 DEC 2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SnmpProviderDialog : Dialog, ISnmpProviderDialogControls
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
        /// Cache to hold a reference to UseDiscoveryCommunityStringRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedUseDiscoveryCommunityStringRadioButton;

        /// <summary>
        /// Cache to hold a reference to UseCustomCommunityStringRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedUseCustomCommunityStringRadioButton;

        /// <summary>
        /// Cache to hold a reference to CommunityStringTextBox of type TextBox
        /// </summary>
        private TextBox cachedCommunityStringTextBox;

        /// <summary>
        /// Cache to hold a reference to NumericDropDownSpinner of type Spinner
        /// </summary>
        private Spinner cachedNumericDropDownSpinner;

        /// <summary>
        /// Cache to hold a reference to UnitComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedUnitComboBox;

        /// <summary>
        /// Cache to hold a reference to ObjectIdentifierDataGrid of type DataGrid
        /// </summary>
        private DataGrid cachedObjectIdentifierDataGrid;

        /// <summary>
        /// Cache to hold a reference to AllTrapsCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedAllTrapsCheckBox;

        /// <summary>
        /// member variable to remember the monitor type
        /// </summary>
        private SnmpMonitorType monitorType;

        /// <summary>
        /// member variable to indicate if current is back compat mode
        /// </summary>
        private bool isBackCompatMode = false;
        #endregion

        #region Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitorType
        /// </summary>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SnmpMonitorType MonitorType
        {
            get
            {
                return this.monitorType;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IsBackCompat
        /// </summary>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public bool IsBackCompat
        {
            get
            {
                return this.isBackCompatMode;
            }
        }
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of SnmpProviderDialog of type SnmpProviderDialog
        /// </param>
        /// <param name='monitorType'>monitor type</param>
        /// <param name="isBackCompat">boolean value to indicate if is back compat mode</param>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SnmpProviderDialog(ConsoleApp app, SnmpMonitorType monitorType)
            : this(app, monitorType, false)
        {
        }

        public SnmpProviderDialog(ConsoleApp app, SnmpMonitorType monitorType, bool isBackCompat)
            : base(app, Init(app))
        {
            Init(monitorType, isBackCompat);
        }

        public SnmpProviderDialog(ConsoleApp app, Window window, SnmpMonitorType monitorType)
            : this(app, window, monitorType, false)
        {
        }

        public SnmpProviderDialog(ConsoleApp app, Window window, SnmpMonitorType monitorType, bool isBackCompat)
            : base(app, window)
        {
            Init(monitorType, isBackCompat);
        }

        private void Init(SnmpMonitorType monitorType, bool isBackCompat)
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);

            this.monitorType = monitorType;

            this.isBackCompatMode = isBackCompat;
        }
        #endregion

        #region ISnmpProbeDialogControls Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISnmpProviderDialogControls Controls
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
        ///  Routine to set/get the text in control CommunityStringTextBox
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string CommunityStringText
        {
            get
            {
                return this.Controls.CommunityStringTextBox.Text;
            }

            set
            {
                this.Controls.CommunityStringTextBox.Text = value;
            }
        }
        #endregion

        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISnmpProviderDialogControls.PreviousButton
        {
            get
            {
                if (this.cachedPreviousButton == null)
                {
                    this.cachedPreviousButton = new Button(this, SnmpProviderDialog.ControlIDs.PreviousButton);
                }
                return this.cachedPreviousButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISnmpProviderDialogControls.NextButton
        {
            get
            {
                if (this.cachedNextButton == null)
                {
                    this.cachedNextButton = new Button(this, SnmpProviderDialog.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISnmpProviderDialogControls.CreateButton
        {
            get
            {
                if (this.cachedCreateButton == null)
                {
                    this.cachedCreateButton = new Button(this, SnmpProviderDialog.ControlIDs.CreateButton);
                }
                return this.cachedCreateButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISnmpProviderDialogControls.CancelButton
        {
            get
            {
                if (this.cachedCancelButton == null)
                {
                    this.cachedCancelButton = new Button(this, SnmpProviderDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UseDiscoveryCommunityStringRadioButton control
        /// </summary>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ISnmpProviderDialogControls.UseDiscoveryCommunityStringRadioButton
        {
            get
            {
                ValidateBackCompatMode("Use discovery community string radio button");
                ValidateMonitorType(SnmpMonitorType.Trap, "Use discovery community string radio button");

                if (this.cachedUseDiscoveryCommunityStringRadioButton == null)
                {
                    this.cachedUseDiscoveryCommunityStringRadioButton = new RadioButton(this, SnmpProviderDialog.ControlIDs.UseDiscoveryCommunityStringRadioButton);
                }
                return this.cachedUseDiscoveryCommunityStringRadioButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UseCustomCommunityStringRadioButton control
        /// </summary>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ISnmpProviderDialogControls.UseCustomCommunityStringRadioButton
        {
            get
            {
                ValidateBackCompatMode("Use custom community string radio button");
                ValidateMonitorType(SnmpMonitorType.Trap, "Use custom community string radio button");

                if (this.cachedUseCustomCommunityStringRadioButton == null)
                {
                    this.cachedUseCustomCommunityStringRadioButton = new RadioButton(this, SnmpProviderDialog.ControlIDs.UseCustomCommunityStringRadioButton);
                }
                return this.cachedUseCustomCommunityStringRadioButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CommunityStringTextBox control
        /// </summary>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ISnmpProviderDialogControls.CommunityStringTextBox
        {
            get
            {
                ValidateBackCompatMode("community string textbox");
                ValidateMonitorType(SnmpMonitorType.Trap, "community string textbox");

                if (this.cachedCommunityStringTextBox == null)
                {
                    this.cachedCommunityStringTextBox = new TextBox(this, SnmpProviderDialog.ControlIDs.CommunityStringTextBox);
                }
                return this.cachedCommunityStringTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NumericDropDownSpinner control
        /// </summary>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Spinner ISnmpProviderDialogControls.NumericDropDownSpinner
        {
            get
            {
                ValidateMonitorType(SnmpMonitorType.Probe, "numeric dropdown spinner");

                if (this.cachedNumericDropDownSpinner == null)
                {
                    this.cachedNumericDropDownSpinner = new Spinner(this, SnmpProviderDialog.ControlIDs.NumericDropDownSpinner);
                }
                return this.cachedNumericDropDownSpinner;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UnitComboBox control
        /// </summary>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ISnmpProviderDialogControls.UnitComboBox
        {
            get
            {
                ValidateMonitorType(SnmpMonitorType.Probe, "unit combobox");

                if (this.cachedUnitComboBox == null)
                {
                    this.cachedUnitComboBox = new ComboBox(this, SnmpProviderDialog.ControlIDs.UnitComboBox);
                }
                return this.cachedUnitComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ObjectIdentifierDataGrid control
        /// </summary>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        DataGrid ISnmpProviderDialogControls.ObjectIdentifierDataGrid
        {
            get
            {
                if (this.cachedObjectIdentifierDataGrid == null)
                {
                    this.cachedObjectIdentifierDataGrid = new DataGrid(this, SnmpProviderDialog.ControlIDs.ObjectIdentifierDataGrid);
                }
                return this.cachedObjectIdentifierDataGrid;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AllTrapsCheckBox control
        /// </summary>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox ISnmpProviderDialogControls.AllTrapsCheckBox
        {
            get
            {
                ValidateMonitorType(SnmpMonitorType.Trap, "All traps check box");

                if (this.cachedAllTrapsCheckBox == null)
                {
                    this.cachedAllTrapsCheckBox = new CheckBox(this, SnmpProviderDialog.ControlIDs.AllTrapsCheckBox);
                }
                return this.cachedAllTrapsCheckBox;
            }
        }

        /// <summary>
        /// Validate if this control can be accessed in current monitor type
        /// </summary>
        /// <param name="expectedMonitorType">expected monitor type</param>
        /// <param name="controlFriendlyName">control friendly name</param>
        private void ValidateMonitorType(SnmpMonitorType expectedMonitorType, string controlFriendlyName)
        {
            if (this.monitorType != expectedMonitorType)
            {
                throw new InvalidOperationException("Current monitor type is: " + this.monitorType + ", and should not access " + controlFriendlyName);
            }
        }

        /// <summary>
        /// Validate if this control can be accessed in current back compat mode
        /// </summary>
        /// <param name="controlFriendlyName">control friendly name</param>
        private void ValidateBackCompatMode(string controlFriendlyName)
        {
            if (!this.isBackCompatMode)
            {
                throw new InvalidOperationException("Current is not back compat mode, and should not access " + controlFriendlyName);
            }
        }
        #endregion

        #region Control Method

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Send keys Tab first to make sure the object identifier cell lost focus and then click Next button
        /// </summary>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public void ClickNext()
        {
            // Note: The tab makes the object identifier cell to lost focus and make sure Next button is enabled
            Keyboard.SendKeys("{TAB}");

            this.Controls.NextButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Add object identifier in the specified row
        /// </summary>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public void AddObjectIdentifier(string objectIdentifier, int rowPos)
        {
            // We'd better not assume the cell is empty by default
            this.Controls.ObjectIdentifierDataGrid.Rows[rowPos].Cells[0].ScreenElement.SendKeys(objectIdentifier);
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Validate if can access this control and then set its state if yes
        /// </summary>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public void SetAllTrapsCheckBoxState(bool state)
        {
            if (!this.isBackCompatMode)
            {
                Utilities.LogMessage("Current is not back compat mode, and should not access All traps check box");
                return;
            }

            if (monitorType != SnmpMonitorType.Trap)
            {
                Utilities.LogMessage("Current monitor type is: " + this.monitorType + ", and should not access All traps check box");
                return;
            }

            SNMPMonitor.SetCheckBoxState(this.Controls.AllTrapsCheckBox, state);
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Validate if can access this control and then set community string
        /// </summary>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public void SetCustomCommunityString(string customCommunityString)
        {
            if (!this.isBackCompatMode)
            {
                Utilities.LogMessage("Current is not back compat mode, and should not set custom community string");
                return;
            }

            if (this.monitorType != SnmpMonitorType.Trap)
            {
                Utilities.LogMessage("Current monitor type is: " + this.monitorType + ", and should not set custom community string");
                return;
            }

            Utilities.LogMessage("Try to click Use custom community string radio button to enable the community string textbox");
            for (int i = 0; !this.Controls.CommunityStringTextBox.IsEnabled && i < 3; i++)
            {
                this.Controls.UseCustomCommunityStringRadioButton.Click();
            }

            if (!this.Controls.CommunityStringTextBox.IsEnabled)
            {
                Utilities.LogMessage("Use custom community string radiobutton state: " + this.Controls.UseCustomCommunityStringRadioButton.ButtonState);
                throw new Exception("Community string text is not enabled after check use custom community radio button on");
            }

            Utilities.LogMessage("Set custom community string: " + customCommunityString);
            this.Controls.CommunityStringTextBox.Text = customCommunityString;
        }
        #endregion

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">SnmpProviderDialog owning the dialog.</param>)
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            string dialogTitle = Strings.DialogTitle;

            Window tempWindow = null;
            int numberOfTries = 0;
            const int MaxTries = 5;

            while (tempWindow == null && numberOfTries < MaxTries)
            {
                try
                {
                    // first try
                    if (numberOfTries == 0)
                    {
                        // Try to locate an existing instance of a dialog
                        tempWindow = new Window(dialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
                    }
                    else
                    {
                        // look for the window again using wildcards
                        tempWindow = new Window(dialogTitle + "*", StringMatchSyntax.WildCard);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(tempWindow, Timeout);
                    }
                }
                catch (Exceptions.WindowNotFoundException ex)
                {
                    // log the unsuccessful attempt
                    Core.Common.Utilities.LogMessage("Attempt " + numberOfTries + " of " + MaxTries);

                    if (numberOfTries == MaxTries - 1)
                    {
                        Core.Common.Utilities.LogMessage("Failed to find with title: " + dialogTitle);
                        throw ex;
                    }
                }

                numberOfTries++;
            }

            return tempWindow;
        }

        #region Strings Class
        public class Strings
        {
            #region Private Members

            /// <summary>
            /// Cache to hold a refernce of dialog title of String
            /// </summary>
            private static string cachedDialogTitle = null;
            #endregion

            #region Constants
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>            
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle =
                ";Create Monitor Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Extensibility.UISDKResources;CreateMonitorWizard";

            /// <summary>
            /// Contains resource string for use discovery community string
            /// </summary>
            private const string ResourceUseDiscoveryCommunityString = ";&Use discovery community string;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.SnmpTrapProviderPage;radioButtonDiscoveredCommunityString.Text";

            /// <summary>
            /// Contains resource string for use custom community string
            /// </summary>
            private const string ResourceUseCustomCommunityString = ";Use cus&tom community string;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.SnmpTrapProviderPage;radioButtonCustomCommunitryString.Text";
            #endregion

            #region Properties

            /// <summary>
            /// Read-only property to access DialogTitle
            /// </summary>
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
            #endregion
        }
        #endregion

        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
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
            /// Control ID for UseDiscoveryCommunityStringRadioButton
            /// </summary>
            public const string UseDiscoveryCommunityStringRadioButton = "radioButtonDiscoveredCommunityString";

            /// <summary>
            /// Control ID for UseCustomCommunityStringRadioButton
            /// </summary>
            public const string UseCustomCommunityStringRadioButton = "radioButtonCustomCommunitryString";

            /// <summary>
            /// Control ID for CommunityStringTextBox
            /// </summary>
            public const string CommunityStringTextBox = "idCommStringTextBox";

            /// <summary>
            /// Control ID for NumericDropDownSpinner
            /// </summary>
            public const string NumericDropDownSpinner = "numericDropDown";

            /// <summary>
            /// Control ID for UnitComboBox
            /// </summary>
            public const string UnitComboBox = "comboBoxUnit";

            /// <summary>
            /// Control ID for ObjectIdentifierDataGrid
            /// </summary>
            public const string ObjectIdentifierDataGrid = "oidGrid";

            /// <summary>
            /// Control ID for AllTrapsCheckBox
            /// </summary>
            public const string AllTrapsCheckBox = "idAllTraps";
        }
        #endregion
    }

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for SNMP monitor type
    /// </summary>
    /// <history>
    /// 	[v-bire] 31 DEC 2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum SnmpMonitorType
    {
        Trap,
        Probe
    }
}
