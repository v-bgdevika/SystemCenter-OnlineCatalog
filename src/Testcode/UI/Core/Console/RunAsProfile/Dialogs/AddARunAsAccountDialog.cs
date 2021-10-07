// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AddARunAsAccountDialog.cs">
// 	Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[nathd] 1/30/2009 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.RunAsProfile
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Radio Group Enumeration - RadioGroup0

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group ManagedObjectsRadioGroup
    /// </summary>
    /// <history>
    /// 	[nathd] 1/30/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum ManagedObjectsRadioGroup
    {
        /// <summary>
        /// ASelectedClassGroupOrObject = 0
        /// </summary>
        ASelectedClassGroupOrObject = 0,
        
        /// <summary>
        /// AllObjectsManagedByThisRunAsProfile = 1
        /// </summary>
        AllObjectsManagedByThisRunAsProfile = 1,

        /// <summary>
        /// Default = 2
        /// </summary>
        Default = 2,
    }
    #endregion
    
    #region Interface Definition - IAddARunAsAccountDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAddARunAsAccountDialogControls, for AddARunAsAccountDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[nathd] 1/30/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAddARunAsAccountDialogControls
    {
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
        /// Read-only property to access MoreAboutSelectingAndUsingRunAsAccountsStaticControl
        /// </summary>
        StaticControl MoreAboutSelectingAndUsingRunAsAccountsStaticControl
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
        /// Read-only property to access UseThisWizardToCreateARunAsProfileAndAssociateItWithOneOrMoreRunAsAccountsIfYouHaveNotYetCreatedASet
        /// </summary>
        TextBox UseThisWizardToCreateARunAsProfileAndAssociateItWithOneOrMoreRunAsAccountsIfYouHaveNotYetCreatedASet
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ASelectedClassGroupOrObjectRadioButton
        /// </summary>
        RadioButton ASelectedClassGroupOrObjectRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AllObjectsManagedByThisRunAsProfileRadioButton
        /// </summary>
        RadioButton AllObjectsManagedByThisRunAsProfileRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ThisRunAsAccountWillBeUsedToManageTheFollowingObjectsStaticControl
        /// </summary>
        StaticControl ThisRunAsAccountWillBeUsedToManageTheFollowingObjectsStaticControl
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
        /// Read-only property to access AccountDistributionComboBox
        /// </summary>
        ComboBox AccountDistributionComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RunAsAccountStaticControl
        /// </summary>
        StaticControl RunAsAccountStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectARunAsAccountToAddToThisProfileChooseAnAccountWithPrivilegesThatAreSufficientToMonitorTheObjec
        /// </summary>
        StaticControl SelectARunAsAccountToAddToThisProfileChooseAnAccountWithPrivilegesThatAreSufficientToMonitorTheObjec
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
    /// 	[nathd] 1/30/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class AddARunAsAccountDialog : Dialog, IAddARunAsAccountDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to MoreAboutSelectingAndUsingRunAsAccountsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMoreAboutSelectingAndUsingRunAsAccountsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectButton of type Button
        /// </summary>
        private Button cachedSelectButton;
        
        /// <summary>
        /// Cache to hold a reference to UseThisWizardToCreateARunAsProfileAndAssociateItWithOneOrMoreRunAsAccountsIfYouHaveNotYetCreatedASet of type TextBox
        /// </summary>
        private TextBox cachedUseThisWizardToCreateARunAsProfileAndAssociateItWithOneOrMoreRunAsAccountsIfYouHaveNotYetCreatedASet;
        
        /// <summary>
        /// Cache to hold a reference to ASelectedClassGroupOrObjectRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedASelectedClassGroupOrObjectRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to AllObjectsManagedByThisRunAsProfileRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedAllObjectsManagedByThisRunAsProfileRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to ThisRunAsAccountWillBeUsedToManageTheFollowingObjectsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedThisRunAsAccountWillBeUsedToManageTheFollowingObjectsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to NewButton of type Button
        /// </summary>
        private Button cachedNewButton;
        
        /// <summary>
        /// Cache to hold a reference to AccountDistributionComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedAccountDistributionComboBox;
        
        /// <summary>
        /// Cache to hold a reference to RunAsAccountStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRunAsAccountStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectARunAsAccountToAddToThisProfileChooseAnAccountWithPrivilegesThatAreSufficientToMonitorTheObjec of type StaticControl
        /// </summary>
        private StaticControl cachedSelectARunAsAccountToAddToThisProfileChooseAnAccountWithPrivilegesThatAreSufficientToMonitorTheObjec;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of AddARunAsAccountDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AddARunAsAccountDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group RadioGroup0
        /// </summary>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ManagedObjectsRadioGroup ManagedObjectsRadioGroup
        {
            get
            {
                if ((this.Controls.ASelectedClassGroupOrObjectRadioButton.ButtonState == ButtonState.Checked))
                {
                    return ManagedObjectsRadioGroup.ASelectedClassGroupOrObject;
                }
                
                if ((this.Controls.AllObjectsManagedByThisRunAsProfileRadioButton.ButtonState == ButtonState.Checked))
                {
                    return ManagedObjectsRadioGroup.AllObjectsManagedByThisRunAsProfile;
                }
                
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == ManagedObjectsRadioGroup.ASelectedClassGroupOrObject))
                {
                    this.Controls.ASelectedClassGroupOrObjectRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == ManagedObjectsRadioGroup.AllObjectsManagedByThisRunAsProfile))
                    {
                        this.Controls.AllObjectsManagedByThisRunAsProfileRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region IAddARunAsAccountDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAddARunAsAccountDialogControls Controls
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
        ///  Routine to set/get the text in control UseThisWizardToCreateARunAsProfileAndAssociateItWithOneOrMoreRunAsAccountsIfYouHaveNotYetCreatedASet
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string UseThisWizardToCreateARunAsProfileAndAssociateItWithOneOrMoreRunAsAccountsIfYouHaveNotYetCreatedASetText
        {
            get
            {
                return this.Controls.UseThisWizardToCreateARunAsProfileAndAssociateItWithOneOrMoreRunAsAccountsIfYouHaveNotYetCreatedASet.Text;
            }
            
            set
            {
                this.Controls.UseThisWizardToCreateARunAsProfileAndAssociateItWithOneOrMoreRunAsAccountsIfYouHaveNotYetCreatedASet.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control AccountDistribution
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string AccountDistributionText
        {
            get
            {
                return this.Controls.AccountDistributionComboBox.Text;
            }
            
            set
            {
                this.Controls.AccountDistributionComboBox.SelectByText(value, true);
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddARunAsAccountDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AddARunAsAccountDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddARunAsAccountDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, AddARunAsAccountDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MoreAboutSelectingAndUsingRunAsAccountsStaticControl control
        /// </summary>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddARunAsAccountDialogControls.MoreAboutSelectingAndUsingRunAsAccountsStaticControl
        {
            get
            {
                if ((this.cachedMoreAboutSelectingAndUsingRunAsAccountsStaticControl == null))
                {
                    this.cachedMoreAboutSelectingAndUsingRunAsAccountsStaticControl = new StaticControl(this, AddARunAsAccountDialog.ControlIDs.MoreAboutSelectingAndUsingRunAsAccountsStaticControl);
                }
                
                return this.cachedMoreAboutSelectingAndUsingRunAsAccountsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectButton control
        /// </summary>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddARunAsAccountDialogControls.SelectButton
        {
            get
            {
                if ((this.cachedSelectButton == null))
                {
                    this.cachedSelectButton = new Button(this, AddARunAsAccountDialog.ControlIDs.SelectButton);
                }
                
                return this.cachedSelectButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UseThisWizardToCreateARunAsProfileAndAssociateItWithOneOrMoreRunAsAccountsIfYouHaveNotYetCreatedASet control
        /// </summary>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAddARunAsAccountDialogControls.UseThisWizardToCreateARunAsProfileAndAssociateItWithOneOrMoreRunAsAccountsIfYouHaveNotYetCreatedASet
        {
            get
            {
                if ((this.cachedUseThisWizardToCreateARunAsProfileAndAssociateItWithOneOrMoreRunAsAccountsIfYouHaveNotYetCreatedASet == null))
                {
                    this.cachedUseThisWizardToCreateARunAsProfileAndAssociateItWithOneOrMoreRunAsAccountsIfYouHaveNotYetCreatedASet = new TextBox(this, AddARunAsAccountDialog.ControlIDs.UseThisWizardToCreateARunAsProfileAndAssociateItWithOneOrMoreRunAsAccountsIfYouHaveNotYetCreatedASet);
                }
                
                return this.cachedUseThisWizardToCreateARunAsProfileAndAssociateItWithOneOrMoreRunAsAccountsIfYouHaveNotYetCreatedASet;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ASelectedClassGroupOrObjectRadioButton control
        /// </summary>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IAddARunAsAccountDialogControls.ASelectedClassGroupOrObjectRadioButton
        {
            get
            {
                if ((this.cachedASelectedClassGroupOrObjectRadioButton == null))
                {
                    this.cachedASelectedClassGroupOrObjectRadioButton = new RadioButton(this, AddARunAsAccountDialog.ControlIDs.ASelectedClassGroupOrObjectRadioButton);
                }
                
                return this.cachedASelectedClassGroupOrObjectRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AllObjectsManagedByThisRunAsProfileRadioButton control
        /// </summary>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IAddARunAsAccountDialogControls.AllObjectsManagedByThisRunAsProfileRadioButton
        {
            get
            {
                if ((this.cachedAllObjectsManagedByThisRunAsProfileRadioButton == null))
                {
                    this.cachedAllObjectsManagedByThisRunAsProfileRadioButton = new RadioButton(this, AddARunAsAccountDialog.ControlIDs.AllObjectsManagedByThisRunAsProfileRadioButton);
                }
                
                return this.cachedAllObjectsManagedByThisRunAsProfileRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ThisRunAsAccountWillBeUsedToManageTheFollowingObjectsStaticControl control
        /// </summary>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddARunAsAccountDialogControls.ThisRunAsAccountWillBeUsedToManageTheFollowingObjectsStaticControl
        {
            get
            {
                if ((this.cachedThisRunAsAccountWillBeUsedToManageTheFollowingObjectsStaticControl == null))
                {
                    this.cachedThisRunAsAccountWillBeUsedToManageTheFollowingObjectsStaticControl = new StaticControl(this, AddARunAsAccountDialog.ControlIDs.ThisRunAsAccountWillBeUsedToManageTheFollowingObjectsStaticControl);
                }
                
                return this.cachedThisRunAsAccountWillBeUsedToManageTheFollowingObjectsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NewButton control
        /// </summary>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddARunAsAccountDialogControls.NewButton
        {
            get
            {
                if ((this.cachedNewButton == null))
                {
                    this.cachedNewButton = new Button(this, AddARunAsAccountDialog.ControlIDs.NewButton);
                }
                
                return this.cachedNewButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AccountDistributionComboBox control
        /// </summary>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IAddARunAsAccountDialogControls.AccountDistributionComboBox
        {
            get
            {
                if ((this.cachedAccountDistributionComboBox == null))
                {
                    this.cachedAccountDistributionComboBox = new ComboBox(this, AddARunAsAccountDialog.ControlIDs.AccountDistributionComboBox);
                }
                
                return this.cachedAccountDistributionComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RunAsAccountStaticControl control
        /// </summary>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddARunAsAccountDialogControls.RunAsAccountStaticControl
        {
            get
            {
                if ((this.cachedRunAsAccountStaticControl == null))
                {
                    this.cachedRunAsAccountStaticControl = new StaticControl(this, AddARunAsAccountDialog.ControlIDs.RunAsAccountStaticControl);
                }
                
                return this.cachedRunAsAccountStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectARunAsAccountToAddToThisProfileChooseAnAccountWithPrivilegesThatAreSufficientToMonitorTheObjec control
        /// </summary>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddARunAsAccountDialogControls.SelectARunAsAccountToAddToThisProfileChooseAnAccountWithPrivilegesThatAreSufficientToMonitorTheObjec
        {
            get
            {
                if ((this.cachedSelectARunAsAccountToAddToThisProfileChooseAnAccountWithPrivilegesThatAreSufficientToMonitorTheObjec == null))
                {
                    this.cachedSelectARunAsAccountToAddToThisProfileChooseAnAccountWithPrivilegesThatAreSufficientToMonitorTheObjec = new StaticControl(this, AddARunAsAccountDialog.ControlIDs.SelectARunAsAccountToAddToThisProfileChooseAnAccountWithPrivilegesThatAreSufficientToMonitorTheObjec);
                }
                
                return this.cachedSelectARunAsAccountToAddToThisProfileChooseAnAccountWithPrivilegesThatAreSufficientToMonitorTheObjec;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
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
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Select
        /// </summary>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSelect()
        {
            this.Controls.SelectButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button New
        /// </summary>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNew()
        {
            this.Controls.NewButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">MomConsoleApp owning the dialog.</param>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
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
                    catch (Exceptions.WindowNotFoundException )
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
        /// 	[nathd] 1/30/2009 Created
        ///     [a-joelj]   16MAR09 Corrected hardcoded DialogTitle resource
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
            private const string ResourceDialogTitle = ";Add a Run As Account;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AddAccountDialog;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";&Cancel;ManagedString;Corgent.Diagramming.Dom.dll;Corgent.Diagramming.Dom.Diagra" +
                "mTemplateProperties;cancelButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";&OK;ManagedString;Corgent.Diagramming.Dom.dll;Corgent.Diagramming.Dom.DiagramTem" +
                "plateProperties;okButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MoreAboutSelectingAndUsingRunAsAccounts
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceMoreAboutSelectingAndUsingRunAsAccounts = "More about selecting and using Run As accounts";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Select
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelect = "S&elect...";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ASelectedClassGroupOrObject
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceASelectedClassGroupOrObject = "A &selected class, group, or object";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AllObjectsManagedByThisRunAsProfile
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAllObjectsManagedByThisRunAsProfile = "&All objects managed by this Run As profile";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ThisRunAsAccountWillBeUsedToManageTheFollowingObjects
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceThisRunAsAccountWillBeUsedToManageTheFollowingObjects = "This Run As Account will be used to manage the following objects:";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  New
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNew = ";&New...;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.Resolutio" +
                "nStates;toolStripButtonNew.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RunAsAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRunAsAccount = ";&Run As Account:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration." +
                "dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAsProfile.A" +
                "lternateAccount;labelAccounts.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectARunAsAccountToAddToThisProfileChooseAnAccountWithPrivilegesThatAreSufficientToMonitorTheObjec
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectARunAsAccountToAddToThisProfileChooseAnAccountWithPrivilegesThatAreSufficientToMonitorTheObjec = "Select a Run As Account to add to this profile.  Choose an account with privilege" +
                "s that are sufficient to monitor the objects you specify.";
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
            /// Caches the translated resource string for:  MoreAboutSelectingAndUsingRunAsAccounts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMoreAboutSelectingAndUsingRunAsAccounts;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Select
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelect;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ASelectedClassGroupOrObject
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedASelectedClassGroupOrObject;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AllObjectsManagedByThisRunAsProfile
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAllObjectsManagedByThisRunAsProfile;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ThisRunAsAccountWillBeUsedToManageTheFollowingObjects
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedThisRunAsAccountWillBeUsedToManageTheFollowingObjects;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  New
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNew;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RunAsAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRunAsAccount;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectARunAsAccountToAddToThisProfileChooseAnAccountWithPrivilegesThatAreSufficientToMonitorTheObjec
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectARunAsAccountToAddToThisProfileChooseAnAccountWithPrivilegesThatAreSufficientToMonitorTheObjec;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 1/30/2009 Created
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
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 1/30/2009 Created
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
            /// 	[nathd] 1/30/2009 Created
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
            /// Exposes access to the MoreAboutSelectingAndUsingRunAsAccounts translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 1/30/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MoreAboutSelectingAndUsingRunAsAccounts
            {
                get
                {
                    if ((cachedMoreAboutSelectingAndUsingRunAsAccounts == null))
                    {
                        cachedMoreAboutSelectingAndUsingRunAsAccounts = CoreManager.MomConsole.GetIntlStr(ResourceMoreAboutSelectingAndUsingRunAsAccounts);
                    }
                    
                    return cachedMoreAboutSelectingAndUsingRunAsAccounts;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Select translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 1/30/2009 Created
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
            /// Exposes access to the ASelectedClassGroupOrObject translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 1/30/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ASelectedClassGroupOrObject
            {
                get
                {
                    if ((cachedASelectedClassGroupOrObject == null))
                    {
                        cachedASelectedClassGroupOrObject = CoreManager.MomConsole.GetIntlStr(ResourceASelectedClassGroupOrObject);
                    }
                    
                    return cachedASelectedClassGroupOrObject;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AllObjectsManagedByThisRunAsProfile translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 1/30/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AllObjectsManagedByThisRunAsProfile
            {
                get
                {
                    if ((cachedAllObjectsManagedByThisRunAsProfile == null))
                    {
                        cachedAllObjectsManagedByThisRunAsProfile = CoreManager.MomConsole.GetIntlStr(ResourceAllObjectsManagedByThisRunAsProfile);
                    }
                    
                    return cachedAllObjectsManagedByThisRunAsProfile;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ThisRunAsAccountWillBeUsedToManageTheFollowingObjects translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 1/30/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ThisRunAsAccountWillBeUsedToManageTheFollowingObjects
            {
                get
                {
                    if ((cachedThisRunAsAccountWillBeUsedToManageTheFollowingObjects == null))
                    {
                        cachedThisRunAsAccountWillBeUsedToManageTheFollowingObjects = CoreManager.MomConsole.GetIntlStr(ResourceThisRunAsAccountWillBeUsedToManageTheFollowingObjects);
                    }
                    
                    return cachedThisRunAsAccountWillBeUsedToManageTheFollowingObjects;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the New translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 1/30/2009 Created
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
            /// Exposes access to the RunAsAccount translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 1/30/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RunAsAccount
            {
                get
                {
                    if ((cachedRunAsAccount == null))
                    {
                        cachedRunAsAccount = CoreManager.MomConsole.GetIntlStr(ResourceRunAsAccount);
                    }
                    
                    return cachedRunAsAccount;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectARunAsAccountToAddToThisProfileChooseAnAccountWithPrivilegesThatAreSufficientToMonitorTheObjec translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 1/30/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectARunAsAccountToAddToThisProfileChooseAnAccountWithPrivilegesThatAreSufficientToMonitorTheObjec
            {
                get
                {
                    if ((cachedSelectARunAsAccountToAddToThisProfileChooseAnAccountWithPrivilegesThatAreSufficientToMonitorTheObjec == null))
                    {
                        cachedSelectARunAsAccountToAddToThisProfileChooseAnAccountWithPrivilegesThatAreSufficientToMonitorTheObjec = CoreManager.MomConsole.GetIntlStr(ResourceSelectARunAsAccountToAddToThisProfileChooseAnAccountWithPrivilegesThatAreSufficientToMonitorTheObjec);
                    }
                    
                    return cachedSelectARunAsAccountToAddToThisProfileChooseAnAccountWithPrivilegesThatAreSufficientToMonitorTheObjec;
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
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for MoreAboutSelectingAndUsingRunAsAccountsStaticControl
            /// </summary>
            public const string MoreAboutSelectingAndUsingRunAsAccountsStaticControl = "moreLink";
            
            /// <summary>
            /// Control ID for SelectButton
            /// </summary>
            public const string SelectButton = "selectButton";
            
            /// <summary>
            /// Control ID for UseThisWizardToCreateARunAsProfileAndAssociateItWithOneOrMoreRunAsAccountsIfYouHaveNotYetCreatedASet
            /// </summary>
            public const string UseThisWizardToCreateARunAsProfileAndAssociateItWithOneOrMoreRunAsAccountsIfYouHaveNotYetCreatedASet = "selectedTextBox";
            
            /// <summary>
            /// Control ID for ASelectedClassGroupOrObjectRadioButton
            /// </summary>
            public const string ASelectedClassGroupOrObjectRadioButton = "selectedOption";
            
            /// <summary>
            /// Control ID for AllObjectsManagedByThisRunAsProfileRadioButton
            /// </summary>
            public const string AllObjectsManagedByThisRunAsProfileRadioButton = "allOption";
            
            /// <summary>
            /// Control ID for ThisRunAsAccountWillBeUsedToManageTheFollowingObjectsStaticControl
            /// </summary>
            public const string ThisRunAsAccountWillBeUsedToManageTheFollowingObjectsStaticControl = "label3";
            
            /// <summary>
            /// Control ID for NewButton
            /// </summary>
            public const string NewButton = "newButton";
            
            /// <summary>
            /// Control ID for AccountDistributionComboBox
            /// </summary>
            public const string AccountDistributionComboBox = "accountDropdown";
            
            /// <summary>
            /// Control ID for RunAsAccountStaticControl
            /// </summary>
            public const string RunAsAccountStaticControl = "label2";
            
            /// <summary>
            /// Control ID for SelectARunAsAccountToAddToThisProfileChooseAnAccountWithPrivilegesThatAreSufficientToMonitorTheObjec
            /// </summary>
            public const string SelectARunAsAccountToAddToThisProfileChooseAnAccountWithPrivilegesThatAreSufficientToMonitorTheObjec = "label1";
        }
        #endregion
    }
}
