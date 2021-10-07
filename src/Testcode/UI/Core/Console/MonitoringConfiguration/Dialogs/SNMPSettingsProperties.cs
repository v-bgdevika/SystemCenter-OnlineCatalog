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
// [barryli] 20JUN07 Created
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
    
    #region Radio Group Enumeration - SNMPRadioGroup0

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group SNMPRadioGroup0
    /// </summary>
    /// <history>
    /// 	[barryli] 20JUN07 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum SNMPRadioGroup0
    {
        /// <summary>
        /// UseCustomCommunityString = 0
        /// </summary>
        UseCustomCommunityString = 0,
        
        /// <summary>
        /// UseDiscoveryCommunityString = 1
        /// </summary>
        UseDiscoveryCommunityString = 1,
    }
    #endregion
    
    #region Interface Definition - ISNMPSettingsPropertiesControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISNMPSettingsPropertiesControls, for SNMPSettingsProperties.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[barryli] 20JUN07 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISNMPSettingsPropertiesControls
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
        /// Read-only property to access RuleTypeStaticControl
        /// </summary>
        StaticControl RuleTypeStaticControl
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
        /// Read-only property to access SNMPTrapProviderStaticControl
        /// </summary>
        StaticControl SNMPTrapProviderStaticControl
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
        /// Read-only property to access UseCustomCommunityStringRadioButton
        /// </summary>
        RadioButton UseCustomCommunityStringRadioButton
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
        /// Read-only property to access TextBox2
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TextBox TextBox2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ObjectIdentifierPropertiesPropertyGridView
        /// </summary>
        PropertyGridView ObjectIdentifierPropertiesPropertyGridView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TextBox3
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TextBox TextBox3
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
        
        /// <summary>
        /// Read-only property to access ObjectIdentifierPropertiesStaticControl
        /// </summary>
        StaticControl ObjectIdentifierPropertiesStaticControl
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
        /// Read-only property to access ConfigureTheTrapOIDsToCollectStaticControl
        /// </summary>
        StaticControl ConfigureTheTrapOIDsToCollectStaticControl
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
    /// 	[barryli] 20JUN07 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SNMPSettingsProperties : Dialog, ISNMPSettingsPropertiesControls
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
        /// Cache to hold a reference to RuleTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRuleTypeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to GeneralStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SNMPTrapProviderStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSNMPTrapProviderStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureAlertsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureAlertsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to UseCustomCommunityStringRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedUseCustomCommunityStringRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to UseDiscoveryCommunityStringRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedUseDiscoveryCommunityStringRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to TextBox2 of type TextBox
        /// </summary>
        private TextBox cachedTextBox2;
        
        /// <summary>
        /// Cache to hold a reference to ObjectIdentifierPropertiesPropertyGridView of type PropertyGridView
        /// </summary>
        private PropertyGridView cachedObjectIdentifierPropertiesPropertyGridView;
        
        /// <summary>
        /// Cache to hold a reference to TextBox3 of type TextBox
        /// </summary>
        private TextBox cachedTextBox3;
        
        /// <summary>
        /// Cache to hold a reference to AllTrapsCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedAllTrapsCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to ObjectIdentifierPropertiesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedObjectIdentifierPropertiesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureTheTrapOIDsToCollectStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureTheTrapOIDsToCollectStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of SNMPSettingsProperties of type SNMPSettingsProperty
        /// </param>
        /// <param name='windowCaption'>Dialog Title </param>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SNMPSettingsProperties(MomConsoleApp app, MonitoringConfiguration.WindowCaptions windowCaption) : 
                base(app, Init(app, windowCaption))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout); 
        }
        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group SNMPRadioGroup0
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual SNMPRadioGroup0 SNMPRadioGroup0
        {
            get
            {
                if ((this.Controls.UseCustomCommunityStringRadioButton.ButtonState == ButtonState.Checked))
                {
                    return SNMPRadioGroup0.UseCustomCommunityString;
                }
                
                if ((this.Controls.UseDiscoveryCommunityStringRadioButton.ButtonState == ButtonState.Checked))
                {
                    return SNMPRadioGroup0.UseDiscoveryCommunityString;
                }
                
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == SNMPRadioGroup0.UseCustomCommunityString))
                {
                    this.Controls.UseCustomCommunityStringRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == SNMPRadioGroup0.UseDiscoveryCommunityString))
                    {
                        this.Controls.UseDiscoveryCommunityStringRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region ISNMPSettingsProperties Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISNMPSettingsPropertiesControls Controls
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
        /// 	[barryli] 20JUN07 Created
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
        ///  Routine to set/get the text in control TextBox2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TextBox2Text
        {
            get
            {
                return this.Controls.TextBox2.Text;
            }
            
            set
            {
                this.Controls.TextBox2.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TextBox3
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TextBox3Text
        {
            get
            {
                return this.Controls.TextBox3.Text;
            }
            
            set
            {
                this.Controls.TextBox3.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISNMPSettingsPropertiesControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, SNMPSettingsProperties.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISNMPSettingsPropertiesControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, SNMPSettingsProperties.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISNMPSettingsPropertiesControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, SNMPSettingsProperties.ControlIDs.CreateButton);
                }
                
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISNMPSettingsPropertiesControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, SNMPSettingsProperties.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RuleTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISNMPSettingsPropertiesControls.RuleTypeStaticControl
        {
            get
            {
                if ((this.cachedRuleTypeStaticControl == null))
                {
                    this.cachedRuleTypeStaticControl = new StaticControl(this, SNMPSettingsProperties.ControlIDs.RuleTypeStaticControl);
                }
                
                return this.cachedRuleTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISNMPSettingsPropertiesControls.GeneralStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedGeneralStaticControl == null))
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
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedGeneralStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedGeneralStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SNMPTrapProviderStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISNMPSettingsPropertiesControls.SNMPTrapProviderStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedSNMPTrapProviderStaticControl == null))
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
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedSNMPTrapProviderStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedSNMPTrapProviderStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureAlertsStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISNMPSettingsPropertiesControls.ConfigureAlertsStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedConfigureAlertsStaticControl == null))
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
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 2); i = (i + 1))
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
        ///  Exposes access to the UseCustomCommunityStringRadioButton control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ISNMPSettingsPropertiesControls.UseCustomCommunityStringRadioButton
        {
            get
            {
                if ((this.cachedUseCustomCommunityStringRadioButton == null))
                {
                    this.cachedUseCustomCommunityStringRadioButton = new RadioButton(this, SNMPSettingsProperties.ControlIDs.UseCustomCommunityStringRadioButton);
                }
                
                return this.cachedUseCustomCommunityStringRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UseDiscoveryCommunityStringRadioButton control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ISNMPSettingsPropertiesControls.UseDiscoveryCommunityStringRadioButton
        {
            get
            {
                if ((this.cachedUseDiscoveryCommunityStringRadioButton == null))
                {
                    this.cachedUseDiscoveryCommunityStringRadioButton = new RadioButton(this, SNMPSettingsProperties.ControlIDs.UseDiscoveryCommunityStringRadioButton);
                }
                
                return this.cachedUseDiscoveryCommunityStringRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TextBox2 control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ISNMPSettingsPropertiesControls.TextBox2
        {
            get
            {
                if ((this.cachedTextBox2 == null))
                {
                    this.cachedTextBox2 = new TextBox(this, SNMPSettingsProperties.ControlIDs.TextBox2);
                }
                
                return this.cachedTextBox2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ObjectIdentifierPropertiesPropertyGridView control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        PropertyGridView ISNMPSettingsPropertiesControls.ObjectIdentifierPropertiesPropertyGridView
        {
            get
            {
                if ((this.cachedObjectIdentifierPropertiesPropertyGridView == null))
                {
                    this.cachedObjectIdentifierPropertiesPropertyGridView = new PropertyGridView(this, SNMPSettingsProperties.ControlIDs.ObjectIdentifierPropertiesPropertyGridView);
                }
                
                return this.cachedObjectIdentifierPropertiesPropertyGridView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TextBox3 control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ISNMPSettingsPropertiesControls.TextBox3
        {
            get
            {
                if ((this.cachedTextBox3 == null))
                {
                    Window wndTemp = this;
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
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedTextBox3 = new TextBox(wndTemp);
                }
                
                return this.cachedTextBox3;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AllTrapsCheckBox control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox ISNMPSettingsPropertiesControls.AllTrapsCheckBox
        {
            get
            {
                if ((this.cachedAllTrapsCheckBox == null))
                {
                    this.cachedAllTrapsCheckBox = new CheckBox(this, SNMPSettingsProperties.ControlIDs.AllTrapsCheckBox);
                }
                
                return this.cachedAllTrapsCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ObjectIdentifierPropertiesStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISNMPSettingsPropertiesControls.ObjectIdentifierPropertiesStaticControl
        {
            get
            {
                if ((this.cachedObjectIdentifierPropertiesStaticControl == null))
                {
                    this.cachedObjectIdentifierPropertiesStaticControl = new StaticControl(this, SNMPSettingsProperties.ControlIDs.ObjectIdentifierPropertiesStaticControl);
                }
                
                return this.cachedObjectIdentifierPropertiesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISNMPSettingsPropertiesControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, SNMPSettingsProperties.ControlIDs.HelpStaticControl);
                }
                
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureTheTrapOIDsToCollectStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISNMPSettingsPropertiesControls.ConfigureTheTrapOIDsToCollectStaticControl
        {
            get
            {
                if ((this.cachedConfigureTheTrapOIDsToCollectStaticControl == null))
                {
                    this.cachedConfigureTheTrapOIDsToCollectStaticControl = new StaticControl(this, SNMPSettingsProperties.ControlIDs.ConfigureTheTrapOIDsToCollectStaticControl);
                }
                
                return this.cachedConfigureTheTrapOIDsToCollectStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
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
        /// 	[barryli] 20JUN07 Created
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
        /// 	[barryli] 20JUN07 Created
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
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button AllTraps
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
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
        ///  <param name="app">SNMPSettingsProperty owning the dialog.</param>)
        ///  <param name='windowCaption'>Dialog Title </param>
        /// <history>
        /// 	[barryli] 20JUN07 Created
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
                tempWindow = new Window(app.GetIntlStr(Strings.DialogTitle), StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
            }
            catch (Exceptions.WindowNotFoundException ex)
            {
                // Reset the window reference
                tempWindow = null;
                int numberOfTries = 0;
                // Maximum number of tries to find window
                int maxTries = 5;

                while (tempWindow == null && numberOfTries < maxTries)
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
                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage(
                            "Attempt " + numberOfTries + " of " + maxTries);
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
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            /// <summary>
            /// Resource string for Create Rule Wizard
            /// </summary>
            // Create Rule Wizard
            public const string DialogTitle = ";Create Rule Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll" +
                ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.Extensibility.UISDKResourc" +
                "es;CreateRuleWizard";
            
            /// <summary>
            /// Resource string for Previous
            /// </summary>
            public const string Previous = ";< &Previous;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll" +
                ";Microsoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel;previousButt" +
                "on.Text";
            
            /// <summary>
            /// Resource string for Next
            /// </summary>
            public const string Next = ";&Next >;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Mic" +
                "rosoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel;nextButton.Text";
            
            /// <summary>
            /// Resource string for Create
            /// </summary>
            public const string Create = ";C&reate;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;CreateMP" +
                "Action";
            
            /// <summary>
            /// Resource string for Cancel
            /// </summary>
            public const string Cancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";
            
            /// <summary>
            /// Resource string for Rule Type
            /// </summary>
            // Rule Type
            public const string RuleType = ";Rule Type;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsof" +
                "t.EnterpriseManagement.Internal.UI.Authoring.Pages.ChooseRuleTypePage;$this.Navi" +
                "gationText";
            
            /// <summary>
            /// Resource string for General
            /// </summary>
            // General
            public const string General = ";General;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;GeneralP" +
                "ropertyPageTabText";
            
            /// <summary>
            /// Resource string for SNMP Trap Provider
            /// </summary>
            // SNMP Trap Provider
            public const string SNMPTrapProvider = ";SNMP Trap Provider;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll" +
                ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Snmp.SnmpStrings;Tit" +
                "leTrapDataSourceProbe";
            
            /// <summary>
            /// Resource string for Configure Alerts
            /// </summary>
            // Configure Alerts
            public const string ConfigureAlerts = ";Configure Alerts;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;M" +
                "icrosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.AlertConfiguration;$th" +
                "is.NavigationText";
            
            /// <summary>
            /// Resource string for Use custom community string
            /// </summary>
            // Use cus&tom community string
            public const string UseCustomCommunityString = ";Use cus&tom community string;ManagedString;Microsoft.EnterpriseManagement.UI.Aut" +
                "horing.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.SnmpProbeP" +
                "ropertyPage;radioButtonCustomCommunitryString.Text";
            
            /// <summary>
            /// Resource string for Use discovery community string
            /// </summary>
            // &Use discovery community string
            public const string UseDiscoveryCommunityString = ";&Use discovery community string;ManagedString;Microsoft.EnterpriseManagement.UI." +
                "Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.SnmpPro" +
                "bePropertyPage;radioButtonDiscoveredCommunityString.Text";
            
            /// <summary>
            /// Resource string for All Traps
            /// </summary>
            // A&ll Traps
            public const string AllTraps = ";A&ll Traps;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microso" +
                "ft.EnterpriseManagement.Internal.UI.Authoring.Pages.SnmpTrapProviderPage;idAllTr" +
                "aps.Text";
            
            /// <summary>
            /// Resource string for Object Identifier Properties
            /// </summary>
            // O&bject Identifier Properties
            public const string ObjectIdentifierProperties = ";O&bject Identifier Properties;ManagedString;Microsoft.EnterpriseManagement.UI.Au" +
                "thoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.SnmpProbe" +
                "PropertyPage;labelProperties.Text";
            
            /// <summary>
            /// Resource string for Help
            /// </summary>
            // Help
            public const string Help = ";Help;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsof" +
                "t.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;HelpSubFold" +
                "erName";
            
            /// <summary>
            /// Resource string for Configure the trap OIDs to collect
            /// </summary>
            // Configure the trap OIDs to collect
            public const string ConfigureTheTrapOIDsToCollect = ";Configure the trap OIDs to collect;ManagedString;Microsoft.EnterpriseManagement." +
                "UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Snmp" +
                ".SnmpStrings;SubTitleTrapDataSourceProbe";
        }
        #endregion
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
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
            /// Control ID for RuleTypeStaticControl
            /// </summary>
            public const string RuleTypeStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for GeneralStaticControl
            /// </summary>
            public const string GeneralStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for SNMPTrapProviderStaticControl
            /// </summary>
            public const string SNMPTrapProviderStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ConfigureAlertsStaticControl
            /// </summary>
            public const string ConfigureAlertsStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for UseCustomCommunityStringRadioButton
            /// </summary>
            public const string UseCustomCommunityStringRadioButton = "radioButtonCustomCommunitryString";
            
            /// <summary>
            /// Control ID for UseDiscoveryCommunityStringRadioButton
            /// </summary>
            public const string UseDiscoveryCommunityStringRadioButton = "radioButtonDiscoveredCommunityString";
            
            /// <summary>
            /// Control ID for TextBox2
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string TextBox2 = "idCommStringTextBox";
            
            /// <summary>
            /// Control ID for ObjectIdentifierPropertiesPropertyGridView
            /// </summary>
            public const string ObjectIdentifierPropertiesPropertyGridView = "oidGrid";
            
            /// <summary>
            /// Control ID for AllTrapsCheckBox
            /// </summary>
            public const string AllTrapsCheckBox = "idAllTraps";
            
            /// <summary>
            /// Control ID for ObjectIdentifierPropertiesStaticControl
            /// </summary>
            public const string ObjectIdentifierPropertiesStaticControl = "labelProperties";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for ConfigureTheTrapOIDsToCollectStaticControl
            /// </summary>
            public const string ConfigureTheTrapOIDsToCollectStaticControl = "headerLabel";
        }
        #endregion
    }
}
