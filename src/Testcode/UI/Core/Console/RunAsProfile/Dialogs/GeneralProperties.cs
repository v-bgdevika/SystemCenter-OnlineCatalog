// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="GeneralProperties.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[sharatja] 8/7/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.RunAsProfile.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    
    #region Interface Definition - IGeneralPropertiesControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IGeneralPropertiesControls, for GeneralProperties.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[sharatja] 8/7/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IGeneralPropertiesControls
    {
        /// <summary>
        /// Read-only property to access ApplyButton
        /// </summary>
        Button ApplyButton
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
        /// Read-only property to access OKButton
        /// </summary>
        Button OKButton
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
        /// Read-only property to access SelectDestinationManagementPackStaticControl
        /// </summary>
        StaticControl SelectDestinationManagementPackStaticControl
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
        /// Read-only property to access DisplayNameTextBox
        /// </summary>
        TextBox DisplayNameTextBox
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
        /// Read-only property to access GeneralStaticControl
        /// </summary>
        StaticControl GeneralStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ProvideADisplayNameDescriptionOptionalStaticControl
        /// </summary>
        StaticControl ProvideADisplayNameDescriptionOptionalStaticControl
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
    /// 	[sharatja] 8/7/2008 Created
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
        /// Cache to hold a reference to Tab0TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab0TabControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectDestinationManagementPackStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectDestinationManagementPackStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to NewButton of type Button
        /// </summary>
        private Button cachedNewButton;

        /// <summary>
        /// Cache to hold a reference to NextButton of type Button
        /// </summary>
        private Button cachedNextButton;

        /// <summary>
        /// Cache to hold a reference to SelectDestinationManagementPackComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedSelectDestinationManagementPackComboBox;
        
        /// <summary>
        /// Cache to hold a reference to DisplayNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedDisplayNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to DescriptionTextBox of type TextBox
        /// </summary>
        private TextBox cachedDescriptionTextBox;
        
        /// <summary>
        /// Cache to hold a reference to DescriptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDescriptionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DisplayNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDisplayNameStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to GeneralStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ProvideADisplayNameDescriptionOptionalStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedProvideADisplayNameDescriptionOptionalStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of GeneralProperties of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public GeneralProperties(ConsoleApp app) : 
                base(app, Init(app))
        {
            //this.Extended.SetFocus();
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
        /// 	[sharatja] 8/7/2008 Created
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
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control SelectDestinationManagementPack
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
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
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control DisplayName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
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
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Description
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
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
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApplyButton control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IGeneralPropertiesControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, GeneralProperties.ControlIDs.ApplyButton);
                }
                return this.cachedApplyButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IGeneralPropertiesControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, GeneralProperties.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IGeneralPropertiesControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, GeneralProperties.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab0TabControl control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IGeneralPropertiesControls.Tab0TabControl
        {
            get
            {
                if ((this.cachedTab0TabControl == null))
                {
                    this.cachedTab0TabControl = new TabControl(this, GeneralProperties.ControlIDs.Tab0TabControl);
                }
                return this.cachedTab0TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectDestinationManagementPackStaticControl control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGeneralPropertiesControls.SelectDestinationManagementPackStaticControl
        {
            get
            {
                if ((this.cachedSelectDestinationManagementPackStaticControl == null))
                {
                    this.cachedSelectDestinationManagementPackStaticControl = new StaticControl(this, GeneralProperties.ControlIDs.SelectDestinationManagementPackStaticControl);
                }
                return this.cachedSelectDestinationManagementPackStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NewButton control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IGeneralPropertiesControls.NewButton
        {
            get
            {
                if ((this.cachedNewButton == null))
                {
                    this.cachedNewButton = new Button(this, GeneralProperties.ControlIDs.NewButton);
                }
                return this.cachedNewButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[nathd] 29JAN09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IGeneralPropertiesControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, GeneralProperties.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectDestinationManagementPackComboBox control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IGeneralPropertiesControls.SelectDestinationManagementPackComboBox
        {
            get
            {
                if ((this.cachedSelectDestinationManagementPackComboBox == null))
                {
                    this.cachedSelectDestinationManagementPackComboBox = new ComboBox(this, GeneralProperties.ControlIDs.SelectDestinationManagementPackComboBox);
                }
                return this.cachedSelectDestinationManagementPackComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DisplayNameTextBox control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IGeneralPropertiesControls.DisplayNameTextBox
        {
            get
            {
                if ((this.cachedDisplayNameTextBox == null))
                {
                    this.cachedDisplayNameTextBox = new TextBox(this, GeneralProperties.ControlIDs.DisplayNameTextBox);
                }
                return this.cachedDisplayNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionTextBox control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
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
        ///  Exposes access to the DescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGeneralPropertiesControls.DescriptionStaticControl
        {
            get
            {
                if ((this.cachedDescriptionStaticControl == null))
                {
                    this.cachedDescriptionStaticControl = new StaticControl(this, GeneralProperties.ControlIDs.DescriptionStaticControl);
                }
                return this.cachedDescriptionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DisplayNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGeneralPropertiesControls.DisplayNameStaticControl
        {
            get
            {
                if ((this.cachedDisplayNameStaticControl == null))
                {
                    this.cachedDisplayNameStaticControl = new StaticControl(this, GeneralProperties.ControlIDs.DisplayNameStaticControl);
                }
                return this.cachedDisplayNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralStaticControl control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGeneralPropertiesControls.GeneralStaticControl
        {
            get
            {
                if ((this.cachedGeneralStaticControl == null))
                {
                    this.cachedGeneralStaticControl = new StaticControl(this, GeneralProperties.ControlIDs.GeneralStaticControl);
                }
                return this.cachedGeneralStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ProvideADisplayNameDescriptionOptionalStaticControl control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGeneralPropertiesControls.ProvideADisplayNameDescriptionOptionalStaticControl
        {
            get
            {
                if ((this.cachedProvideADisplayNameDescriptionOptionalStaticControl == null))
                {
                    this.cachedProvideADisplayNameDescriptionOptionalStaticControl = new StaticControl(this, GeneralProperties.ControlIDs.ProvideADisplayNameDescriptionOptionalStaticControl);
                }
                return this.cachedProvideADisplayNameDescriptionOptionalStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Apply
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
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
        /// 	[sharatja] 8/7/2008 Created
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
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button New
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNew()
        {
            this.Controls.NewButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Next
        /// </summary>
        /// <history>
        /// 	[nathd] 29JAN09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNext()
        {
            this.Controls.NextButton.Click();
        }
        #endregion

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">ConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
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
                const int MAXTRIES = 7;
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
        /// 	[sharatja] 8/7/2008 Created
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
            // Dialog title changed with the R2 RunAs Improvement #131241.
            // TODO: Verify this resource is no longer needed and remove.
            // private const string ResourceDialogTitle = ";Run As Profile Properties -;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;RunAsProfilePropertiesCaption";
            private const string ResourceDialogTitle = ";Create Run As Profile Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;RunAsProfileWizardCaption";

            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Apply
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceApply = ";&Apply;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.PropertyDialogForm;buttonApply.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.Tr" +
                "anslucentColorPicker;buttonOk.Text";
            
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
            /// Contains resource string for:  SelectDestinationManagementPack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectDestinationManagementPack = ";Select destination &management pack:;ManagedString;Microsoft.EnterpriseManagemen" +
                "t.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administr" +
                "ation.RunAsProfile.ProfileGeneral;labelSelectMp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  New
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNew = ";N&ew...;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAsProfile.RunAsProfi" +
                "leComboBoxControl;buttonProfile.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Description
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDescription = ";De&scription:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAsProfile.Prof" +
                "ileGeneral;labelDescription.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DisplayName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDisplayName = ";&Display name:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dl" +
                "l;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAsProfile.Pro" +
                "fileGeneral;labelName.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  General
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneral = ";General;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;GeneralP" +
                "ropertyPageTabText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ProvideADisplayNameDescriptionOptional
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceProvideADisplayNameDescriptionOptional = ";Provide a display name, description (optional).;ManagedString;Microsoft.Enterpri" +
                "seManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.U" +
                "I.Administration.RunAsProfile.ProfileGeneral;labelTitle1.Text";
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
            /// Caches the translated resource string for:  Apply
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedApply;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Tab0
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab0;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectDestinationManagementPack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectDestinationManagementPack;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  New
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNew;
            
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
            /// Caches the translated resource string for:  General
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneral;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ProvideADisplayNameDescriptionOptional
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedProvideADisplayNameDescriptionOptional;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
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
            /// Exposes access to the Apply translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Apply
            {
                get
                {
                    if ((cachedApply == null))
                    {
                        cachedApply = CoreManager.MomConsole.GetIntlStr(ResourceApply);
                    }
                    return cachedApply;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
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
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OK
            {
                get
                {
                    if ((cachedOK == null))
                    {
                        cachedOK = CoreManager.MomConsole.GetIntlStr(ResourceOK);
                    }
                    return cachedOK;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Tab0 translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
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
            /// Exposes access to the SelectDestinationManagementPack translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
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
            /// Exposes access to the New translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
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
            /// Exposes access to the Description translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
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
            /// 	[sharatja] 8/7/2008 Created
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
            /// Exposes access to the General translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
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
            /// Exposes access to the ProvideADisplayNameDescriptionOptional translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ProvideADisplayNameDescriptionOptional
            {
                get
                {
                    if ((cachedProvideADisplayNameDescriptionOptional == null))
                    {
                        cachedProvideADisplayNameDescriptionOptional = CoreManager.MomConsole.GetIntlStr(ResourceProvideADisplayNameDescriptionOptional);
                    }
                    return cachedProvideADisplayNameDescriptionOptional;
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
        /// 	[sharatja] 8/7/2008 Created
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
            /// Control ID for NextButton
            /// </summary>
            public const string NextButton = "nextButton";

            /// <summary>
            /// Control ID for Tab0TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab0TabControl = "tabPages";
            
            /// <summary>
            /// Control ID for SelectDestinationManagementPackStaticControl
            /// </summary>
            public const string SelectDestinationManagementPackStaticControl = "labelSelectMp";
            
            /// <summary>
            /// Control ID for NewButton
            /// </summary>
            public const string NewButton = "newmpButton";
            
            /// <summary>
            /// Control ID for SelectDestinationManagementPackComboBox
            /// </summary>
            public const string SelectDestinationManagementPackComboBox = "comboBoxMp";
            
            /// <summary>
            /// Control ID for DisplayNameTextBox
            /// </summary>
            public const string DisplayNameTextBox = "textBoxName";
            
            /// <summary>
            /// Control ID for DescriptionTextBox
            /// </summary>
            public const string DescriptionTextBox = "textBoxDescription";
            
            /// <summary>
            /// Control ID for DescriptionStaticControl
            /// </summary>
            public const string DescriptionStaticControl = "labelDescription";
            
            /// <summary>
            /// Control ID for DisplayNameStaticControl
            /// </summary>
            public const string DisplayNameStaticControl = "labelName";
            
            /// <summary>
            /// Control ID for GeneralStaticControl
            /// </summary>
            public const string GeneralStaticControl = "labelTitle";
            
            /// <summary>
            /// Control ID for ProvideADisplayNameDescriptionOptionalStaticControl
            /// </summary>
            public const string ProvideADisplayNameDescriptionOptionalStaticControl = "labelTitle1";
        }
        #endregion
    }
}
