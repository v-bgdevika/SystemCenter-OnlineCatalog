// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SNMPDSPropertiesDialog.cs">
//   Copyright (c) Microsoft Corporation 2010
// </copyright>
// <project>
//   MOMv3 UI Test Automation
// </project>
// <summary>
//   MOMv3 UI Test Automation
// </summary>
// <history>
//   [v-juli] 12/29/2010 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs
{
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Console;
    using Mom.Test.UI.Core.Common;

    #region Radio Group Enumeration - CommunityRadioGroup

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group CommunityRadioGroup
    /// </summary>
    /// <history>
    ///   [v-juli] 12/29/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum CommunityRadioGroup
    {
        /// <summary>
        /// This radio button enables you to use discovery community string
        /// </summary>
        UseDiscoveryCommunityString = 0,
        
        /// <summary>
        /// This radio button enables you to change to cunstom community string
        /// </summary>
        UseCustomCommunityString = 1,
    }
    #endregion
    
    #region Interface Definition - ISNMPDSPropertiesDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISNMPDSPropertiesDialogDialogControls, for SNMPDSPropertiesDialogDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-juli] 12/29/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISNMPDSPropertiesDialogControls
    {
        /// <summary>
        /// Gets read-only property to access ApplyButton
        /// </summary>
        Button ApplyButton
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
        /// Gets read-only property to access OKButton
        /// </summary>
        Button OKButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access UseDiscoveryCommunityStringRadioButton
        /// </summary>
        RadioButton UseDiscoveryCommunityStringRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access UseCustomCommunityStringRadioButton
        /// </summary>
        RadioButton UseCustomCommunityStringRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access Community String
        /// </summary>
        /// <remark>
        /// Cunstom Community String Text Box 
        /// </remark>
        TextBox CommunityStringTextBox
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access ObjectIdentifierPropertiesPropertyGridView
        /// </summary>
        PropertyGridView ObjectIdentifierPropertiesPropertyGridView
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access AllTrapsCheckBox
        /// </summary>
        CheckBox AllTrapsCheckBox
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// SNMP Rule Data Source Property
    /// </summary>
    /// <history>
    ///   [v-juli] 12/29/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class SNMPDSPropertiesDialog : Dialog, ISNMPDSPropertiesDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ApplyButton of type Button
        /// </summary>
        private Button cachedApplyButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;    
        
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
        /// Cache to hold a reference to ObjectIdentifierPropertiesPropertyGridView of type PropertyGridView
        /// </summary>
        private PropertyGridView cachedObjectIdentifierPropertiesPropertyGridView;
        
        /// <summary>
        /// Cache to hold a reference to AllTrapsCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedAllTrapsCheckBox;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the SNMPDSPropertiesDialogDialog class.
        /// </summary>
        /// <param name='app'>
        /// Owner of SNMPDSPropertiesDialogDialog of type App
        /// </param>
        /// <history>
        ///   [v-juli] 12/29/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SNMPDSPropertiesDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);  
        }
        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets functionality for radio group RadioGroup0
        /// </summary>
        /// <history>
        ///   [v-juli] 12/29/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual CommunityRadioGroup CommunityStringRadioGroup
        {
            get
            {
                if ((this.Controls.UseDiscoveryCommunityStringRadioButton.ButtonState == ButtonState.Checked))
                {
                    return CommunityRadioGroup.UseDiscoveryCommunityString;
                }
                
                if ((this.Controls.UseCustomCommunityStringRadioButton.ButtonState == ButtonState.Checked))
                {
                    return CommunityRadioGroup.UseCustomCommunityString;
                }
                
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == CommunityRadioGroup.UseDiscoveryCommunityString))
                {
                    this.Controls.UseDiscoveryCommunityStringRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == CommunityRadioGroup.UseCustomCommunityString))
                    {
                        this.Controls.UseCustomCommunityStringRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region ISNMPDSPropertiesDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [v-juli] 12/29/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISNMPDSPropertiesDialogControls Controls
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
        ///  Property to handle checkbox AllTraps
        /// </summary>
        /// <history>
        ///   [v-juli] 12/29/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool AllTraps
        {
            get
            {
                return this.Controls.AllTrapsCheckBox.Checked;
            }
            
            set
            {
                this.Controls.AllTrapsCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets or sets the text in control CommunityStringTextBox
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-juli] 12/29/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string CommunityStringTextBoxText
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
        ///  Gets access to the ApplyButton control
        /// </summary>
        /// <history>
        ///   [v-juli] 12/29/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISNMPDSPropertiesDialogControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, SNMPDSPropertiesDialog.ControlIDs.ApplyButton);
                }
                
                return this.cachedApplyButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the CancelButton control
        /// </summary>
        /// <history>
        ///   [v-juli] 12/29/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISNMPDSPropertiesDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, SNMPDSPropertiesDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the OKButton control
        /// </summary>
        /// <history>
        ///   [v-juli] 12/29/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISNMPDSPropertiesDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, SNMPDSPropertiesDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the UseDiscoveryCommunityStringRadioButton control
        /// </summary>
        /// <history>
        ///   [v-juli] 12/29/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ISNMPDSPropertiesDialogControls.UseDiscoveryCommunityStringRadioButton
        {
            get
            {
                if ((this.cachedUseDiscoveryCommunityStringRadioButton == null))
                {
                    this.cachedUseDiscoveryCommunityStringRadioButton = new RadioButton(this, SNMPDSPropertiesDialog.ControlIDs.UseDiscoveryCommunityStringRadioButton);
                }
                
                return this.cachedUseDiscoveryCommunityStringRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the UseCustomCommunityStringRadioButton control
        /// </summary>
        /// <history>
        ///   [v-juli] 12/29/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ISNMPDSPropertiesDialogControls.UseCustomCommunityStringRadioButton
        {
            get
            {
                if ((this.cachedUseCustomCommunityStringRadioButton == null))
                {
                    this.cachedUseCustomCommunityStringRadioButton = new RadioButton(this, SNMPDSPropertiesDialog.ControlIDs.UseCustomCommunityStringRadioButton);
                }
                
                return this.cachedUseCustomCommunityStringRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the cachedCommunityStringTextBox control
        /// </summary>
        /// <history>
        ///   [v-juli] 12/29/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ISNMPDSPropertiesDialogControls.CommunityStringTextBox
        {
            get
            {
                if ((this.cachedCommunityStringTextBox == null))
                {
                    this.cachedCommunityStringTextBox = new TextBox(this, SNMPDSPropertiesDialog.ControlIDs.CommunityStringTextBox);
                }

                return this.cachedCommunityStringTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ObjectIdentifierPropertiesPropertyGridView control
        /// </summary>
        /// <history>
        ///   [v-juli] 12/29/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        PropertyGridView ISNMPDSPropertiesDialogControls.ObjectIdentifierPropertiesPropertyGridView
        {
            get
            {
                if ((this.cachedObjectIdentifierPropertiesPropertyGridView == null))
                {
                    this.cachedObjectIdentifierPropertiesPropertyGridView = new PropertyGridView(this, SNMPDSPropertiesDialog.ControlIDs.ObjectIdentifierPropertiesPropertyGridView);
                }
                
                return this.cachedObjectIdentifierPropertiesPropertyGridView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the AllTrapsCheckBox control
        /// </summary>
        /// <history>
        ///   [v-juli] 12/29/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox ISNMPDSPropertiesDialogControls.AllTrapsCheckBox
        {
            get
            {
                if ((this.cachedAllTrapsCheckBox == null))
                {
                    this.cachedAllTrapsCheckBox = new CheckBox(this, SNMPDSPropertiesDialog.ControlIDs.AllTrapsCheckBox);
                }
                
                return this.cachedAllTrapsCheckBox;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Apply
        /// </summary>
        /// <history>
        ///   [v-juli] 12/29/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickApply()
        {
            this.Controls.ApplyButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        ///   [v-juli] 12/29/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        ///   [v-juli] 12/29/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button AllTraps
        /// </summary>
        /// <history>
        ///   [v-juli] 12/29/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAllTraps()
        {
            this.Controls.AllTrapsCheckBox.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">App owning the dialog.</param>
        /// <history>
        ///   [v-juli] 12/29/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(app.GetIntlStr(Strings.DialogTitle), StringMatchSyntax.WildCard, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
                
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
                        tempWindow = new Window(app.GetIntlStr(Strings.DialogTitle), StringMatchSyntax.WildCard);
                    }
                    catch (Exceptions.WindowNotFoundException )
                    {
                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage(
                            "Attempt " + numberOfTries + " of " + maxTries);
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }
                
                // check for success
                if ((null == tempWindow))
                {
                    Core.Common.Utilities.LogMessage(
                        "Failed to find window with title:  '" + Strings.DialogTitle + "'");
                    throw;
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
        ///   [v-juli] 12/29/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ApplyButton
            /// </summary>
            public const string ApplyButton = "applyButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
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
            /// Control ID for ObjectIdentifierPropertiesPropertyGridView
            /// </summary>
            public const string ObjectIdentifierPropertiesPropertyGridView = "oidGrid";
            
            /// <summary>
            /// Control ID for AllTrapsCheckBox
            /// </summary>
            public const string AllTrapsCheckBox = "idAllTraps";
        }
        #endregion
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        ///   [v-juli] 12/29/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            /// <summary>
            /// Resource string for DS - Properties
            /// </summary>
            /// TODO: UIClassMaker could not find the resource for this string.  Find it and replace literal created by tool.
            //public const string DialogTitle = "DS - Properties";
            public const string DialogTitle = ";Properties;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.AuthoringDialog;$this.Text";
           
            /// <summary>
            /// Resource string for Apply
            /// </summary>
            public const string Apply = ";Apply;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.WebApplicationPropertiesForm;buttonApply.Text";
            
            /// <summary>
            /// Resource string for Cancel
            /// </summary>            
            public const string Cancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.TranslucentColorPicker;buttonCancel.Text";
            
            /// <summary>
            /// Resource string for OK
            /// </summary>            
            public const string OK = ";OK;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.TranslucentColorPicker;buttonOk.Text";
            
            /// <summary>
            /// Resource string for Use discovery community string
            /// </summary>
            public const string UseDiscoveryCommunityString = ";&Use discovery community string;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;" +
                "Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.SnmpProbePropertyPage;radioButtonDiscoveredCommunityString.Text";
            
            /// <summary>
            /// Resource string for Use custom community string
            /// </summary>            
            public const string UseCustomCommunityString = ";Use cus&tom community string;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;" +
                "Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.SnmpProbePropertyPage;radioButtonCustomCommunitryString.Text";
            
            /// <summary>
            /// Resource string for All Traps
            /// </summary>
            public const string AllTraps = ";A&ll Traps;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;" +
                "Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.SnmpTrapProviderPage;idAllTraps.Text";
        }
        #endregion
    }
}
