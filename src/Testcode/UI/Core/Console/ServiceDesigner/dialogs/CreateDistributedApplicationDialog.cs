// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="CreateDistributedApplicationDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[mcorning] 5/11/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.ServiceDesigner
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using Microsoft.EnterpriseManagement.Mom.Internal;
    using Mom.Test.UI.Core.Common;
    using System;
    using System.ComponentModel;
    
    #region Interface Definition - ICreateDistributedApplicationDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ICreateDistributedApplicationDialogControls, for CreateDistributedApplicationDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[mcorning] 5/11/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ICreateDistributedApplicationDialogControls
    {
        /// <summary>
        /// Read-only property to access NewButton
        /// </summary>
        Button NewButton
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
        /// Read-only property to access ManagementPackStaticControl
        /// </summary>
        StaticControl ManagementPackStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectAManagementPackWhereYourDistributedApplicationAndItsComponentsWillBeSavedStaticControl
        /// </summary>
        StaticControl SelectAManagementPackWhereYourDistributedApplicationAndItsComponentsWillBeSavedStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access _3SaveToAManagementPackStaticControl
        /// </summary>
        StaticControl _3SaveToAManagementPackStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TemplateListBox
        /// </summary>
        ListBox TemplateListBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ViewDetailsStaticControl
        /// </summary>
        StaticControl ViewDetailsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StaticControl0
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        StaticControl StaticControl0
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
        /// Read-only property to access TemplateStaticControl
        /// </summary>
        StaticControl TemplateStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectATemplateThatMostCloselyMatchesTheDistributedApplicationYouHaveDeployedADistributedApplication
        /// </summary>
        StaticControl SelectATemplateThatMostCloselyMatchesTheDistributedApplicationYouHaveDeployedADistributedApplication
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access _2ChooseDistributedApplicationTemplateStaticControl
        /// </summary>
        StaticControl _2ChooseDistributedApplicationTemplateStaticControl
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
        /// Read-only property to access DescriptionOptionalStaticControl
        /// </summary>
        StaticControl DescriptionOptionalStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ChooseANameThatBestMatchesTheDistributedApplicationYouWantToCreateYouCanFillADescriptionForItIfYouLi
        /// </summary>
        StaticControl ChooseANameThatBestMatchesTheDistributedApplicationYouWantToCreateYouCanFillADescriptionForItIfYouLi
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access _1NameYourDistributedApplicationStaticControl
        /// </summary>
        StaticControl _1NameYourDistributedApplicationStaticControl
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
        /// Read-only property to access NameTextBox
        /// </summary>
        TextBox NameTextBox
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
        /// Read-only property to access CancelButton
        /// </summary>
        Button CancelButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CreateADistributedApplicationStaticControl
        /// </summary>
        StaticControl CreateADistributedApplicationStaticControl
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
    /// 	[mcorning] 5/11/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class CreateDistributedApplicationDialog : Dialog, ICreateDistributedApplicationDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to NewButton of type Button
        /// </summary>
        private Button cachedNewButton;
        
        /// <summary>
        /// Cache to hold a reference to ManagementPackComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedManagementPackComboBox;
        
        /// <summary>
        /// Cache to hold a reference to ManagementPackStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedManagementPackStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectAManagementPackWhereYourDistributedApplicationAndItsComponentsWillBeSavedStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectAManagementPackWhereYourDistributedApplicationAndItsComponentsWillBeSavedStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to _3SaveToAManagementPackStaticControl of type StaticControl
        /// </summary>
        private StaticControl cached_3SaveToAManagementPackStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to TemplateListBox of type ListBox
        /// </summary>
        private ListBox cachedTemplateListBox;
        
        /// <summary>
        /// Cache to hold a reference to ViewDetailsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedViewDetailsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to StaticControl0 of type StaticControl
        /// </summary>
        private StaticControl cachedStaticControl0;
        
        /// <summary>
        /// Cache to hold a reference to DescriptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDescriptionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to TemplateStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTemplateStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectATemplateThatMostCloselyMatchesTheDistributedApplicationYouHaveDeployedADistributedApplication of type StaticControl
        /// </summary>
        private StaticControl cachedSelectATemplateThatMostCloselyMatchesTheDistributedApplicationYouHaveDeployedADistributedApplication;
        
        /// <summary>
        /// Cache to hold a reference to _2ChooseDistributedApplicationTemplateStaticControl of type StaticControl
        /// </summary>
        private StaticControl cached_2ChooseDistributedApplicationTemplateStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to NameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNameStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DescriptionOptionalStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDescriptionOptionalStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ChooseANameThatBestMatchesTheDistributedApplicationYouWantToCreateYouCanFillADescriptionForItIfYouLi of type StaticControl
        /// </summary>
        private StaticControl cachedChooseANameThatBestMatchesTheDistributedApplicationYouWantToCreateYouCanFillADescriptionForItIfYouLi;
        
        /// <summary>
        /// Cache to hold a reference to _1NameYourDistributedApplicationStaticControl of type StaticControl
        /// </summary>
        private StaticControl cached_1NameYourDistributedApplicationStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DescriptionOptionalTextBox of type TextBox
        /// </summary>
        private TextBox cachedDescriptionOptionalTextBox;
        
        /// <summary>
        /// Cache to hold a reference to NameTextBox of type TextBox
        /// </summary>
        private TextBox cachedNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to CreateADistributedApplicationStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCreateADistributedApplicationStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of CreateDistributedApplicationDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public CreateDistributedApplicationDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region ICreateDistributedApplicationDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ICreateDistributedApplicationDialogControls Controls
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
        /// 	[mcorning] 5/11/2006 Created
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
        ///  Routine to set/get the text in control DescriptionOptional
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
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
        /// 	[mcorning] 5/11/2006 Created
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
        ///  Exposes access to the NewButton control
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICreateDistributedApplicationDialogControls.NewButton
        {
            get
            {
                if ((this.cachedNewButton == null))
                {
                    this.cachedNewButton = new Button(this, CreateDistributedApplicationDialog.ControlIDs.NewButton);
                }
                return this.cachedNewButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementPackComboBox control
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ICreateDistributedApplicationDialogControls.ManagementPackComboBox
        {
            get
            {
                if ((this.cachedManagementPackComboBox == null))
                {
                    this.cachedManagementPackComboBox = new ComboBox(this, CreateDistributedApplicationDialog.ControlIDs.ManagementPackComboBox);
                }
                return this.cachedManagementPackComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementPackStaticControl control
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateDistributedApplicationDialogControls.ManagementPackStaticControl
        {
            get
            {
                if ((this.cachedManagementPackStaticControl == null))
                {
                    this.cachedManagementPackStaticControl = new StaticControl(this, CreateDistributedApplicationDialog.ControlIDs.ManagementPackStaticControl);
                }
                return this.cachedManagementPackStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectAManagementPackWhereYourDistributedApplicationAndItsComponentsWillBeSavedStaticControl control
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateDistributedApplicationDialogControls.SelectAManagementPackWhereYourDistributedApplicationAndItsComponentsWillBeSavedStaticControl
        {
            get
            {
                if ((this.cachedSelectAManagementPackWhereYourDistributedApplicationAndItsComponentsWillBeSavedStaticControl == null))
                {
                    this.cachedSelectAManagementPackWhereYourDistributedApplicationAndItsComponentsWillBeSavedStaticControl = new StaticControl(this, CreateDistributedApplicationDialog.ControlIDs.SelectAManagementPackWhereYourDistributedApplicationAndItsComponentsWillBeSavedStaticControl);
                }
                return this.cachedSelectAManagementPackWhereYourDistributedApplicationAndItsComponentsWillBeSavedStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the _3SaveToAManagementPackStaticControl control
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateDistributedApplicationDialogControls._3SaveToAManagementPackStaticControl
        {
            get
            {
                if ((this.cached_3SaveToAManagementPackStaticControl == null))
                {
                    this.cached_3SaveToAManagementPackStaticControl = new StaticControl(this, CreateDistributedApplicationDialog.ControlIDs._3SaveToAManagementPackStaticControl);
                }
                return this.cached_3SaveToAManagementPackStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TemplateListBox control
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListBox ICreateDistributedApplicationDialogControls.TemplateListBox
        {
            get
            {
                if ((this.cachedTemplateListBox == null))
                {
                    this.cachedTemplateListBox = new ListBox(this, CreateDistributedApplicationDialog.ControlIDs.TemplateListBox);
                }
                return this.cachedTemplateListBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ViewDetailsStaticControl control
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateDistributedApplicationDialogControls.ViewDetailsStaticControl
        {
            get
            {
                if ((this.cachedViewDetailsStaticControl == null))
                {
                    this.cachedViewDetailsStaticControl = new StaticControl(this, CreateDistributedApplicationDialog.ControlIDs.ViewDetailsStaticControl);
                }
                return this.cachedViewDetailsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StaticControl0 control
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateDistributedApplicationDialogControls.StaticControl0
        {
            get
            {
                if ((this.cachedStaticControl0 == null))
                {
                    this.cachedStaticControl0 = new StaticControl(this, CreateDistributedApplicationDialog.ControlIDs.StaticControl0);
                }
                return this.cachedStaticControl0;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateDistributedApplicationDialogControls.DescriptionStaticControl
        {
            get
            {
                if ((this.cachedDescriptionStaticControl == null))
                {
                    this.cachedDescriptionStaticControl = new StaticControl(this, CreateDistributedApplicationDialog.ControlIDs.DescriptionStaticControl);
                }
                return this.cachedDescriptionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TemplateStaticControl control
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateDistributedApplicationDialogControls.TemplateStaticControl
        {
            get
            {
                if ((this.cachedTemplateStaticControl == null))
                {
                    this.cachedTemplateStaticControl = new StaticControl(this, CreateDistributedApplicationDialog.ControlIDs.TemplateStaticControl);
                }
                return this.cachedTemplateStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectATemplateThatMostCloselyMatchesTheDistributedApplicationYouHaveDeployedADistributedApplication control
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateDistributedApplicationDialogControls.SelectATemplateThatMostCloselyMatchesTheDistributedApplicationYouHaveDeployedADistributedApplication
        {
            get
            {
                if ((this.cachedSelectATemplateThatMostCloselyMatchesTheDistributedApplicationYouHaveDeployedADistributedApplication == null))
                {
                    this.cachedSelectATemplateThatMostCloselyMatchesTheDistributedApplicationYouHaveDeployedADistributedApplication = new StaticControl(this, CreateDistributedApplicationDialog.ControlIDs.SelectATemplateThatMostCloselyMatchesTheDistributedApplicationYouHaveDeployedADistributedApplication);
                }
                return this.cachedSelectATemplateThatMostCloselyMatchesTheDistributedApplicationYouHaveDeployedADistributedApplication;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the _2ChooseDistributedApplicationTemplateStaticControl control
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateDistributedApplicationDialogControls._2ChooseDistributedApplicationTemplateStaticControl
        {
            get
            {
                if ((this.cached_2ChooseDistributedApplicationTemplateStaticControl == null))
                {
                    this.cached_2ChooseDistributedApplicationTemplateStaticControl = new StaticControl(this, CreateDistributedApplicationDialog.ControlIDs._2ChooseDistributedApplicationTemplateStaticControl);
                }
                return this.cached_2ChooseDistributedApplicationTemplateStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameStaticControl control
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateDistributedApplicationDialogControls.NameStaticControl
        {
            get
            {
                if ((this.cachedNameStaticControl == null))
                {
                    this.cachedNameStaticControl = new StaticControl(this, CreateDistributedApplicationDialog.ControlIDs.NameStaticControl);
                }
                return this.cachedNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionOptionalStaticControl control
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateDistributedApplicationDialogControls.DescriptionOptionalStaticControl
        {
            get
            {
                if ((this.cachedDescriptionOptionalStaticControl == null))
                {
                    this.cachedDescriptionOptionalStaticControl = new StaticControl(this, CreateDistributedApplicationDialog.ControlIDs.DescriptionOptionalStaticControl);
                }
                return this.cachedDescriptionOptionalStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ChooseANameThatBestMatchesTheDistributedApplicationYouWantToCreateYouCanFillADescriptionForItIfYouLi control
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateDistributedApplicationDialogControls.ChooseANameThatBestMatchesTheDistributedApplicationYouWantToCreateYouCanFillADescriptionForItIfYouLi
        {
            get
            {
                if ((this.cachedChooseANameThatBestMatchesTheDistributedApplicationYouWantToCreateYouCanFillADescriptionForItIfYouLi == null))
                {
                    this.cachedChooseANameThatBestMatchesTheDistributedApplicationYouWantToCreateYouCanFillADescriptionForItIfYouLi = new StaticControl(this, CreateDistributedApplicationDialog.ControlIDs.ChooseANameThatBestMatchesTheDistributedApplicationYouWantToCreateYouCanFillADescriptionForItIfYouLi);
                }
                return this.cachedChooseANameThatBestMatchesTheDistributedApplicationYouWantToCreateYouCanFillADescriptionForItIfYouLi;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the _1NameYourDistributedApplicationStaticControl control
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateDistributedApplicationDialogControls._1NameYourDistributedApplicationStaticControl
        {
            get
            {
                if ((this.cached_1NameYourDistributedApplicationStaticControl == null))
                {
                    this.cached_1NameYourDistributedApplicationStaticControl = new StaticControl(this, CreateDistributedApplicationDialog.ControlIDs._1NameYourDistributedApplicationStaticControl);
                }
                return this.cached_1NameYourDistributedApplicationStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionOptionalTextBox control
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ICreateDistributedApplicationDialogControls.DescriptionOptionalTextBox
        {
            get
            {
                if ((this.cachedDescriptionOptionalTextBox == null))
                {
                    this.cachedDescriptionOptionalTextBox = new TextBox(this, CreateDistributedApplicationDialog.ControlIDs.DescriptionOptionalTextBox);
                }
                return this.cachedDescriptionOptionalTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameTextBox control
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ICreateDistributedApplicationDialogControls.NameTextBox
        {
            get
            {
                if ((this.cachedNameTextBox == null))
                {
                    this.cachedNameTextBox = new TextBox(this, CreateDistributedApplicationDialog.ControlIDs.NameTextBox);
                }
                return this.cachedNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICreateDistributedApplicationDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, CreateDistributedApplicationDialog.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICreateDistributedApplicationDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, CreateDistributedApplicationDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateADistributedApplicationStaticControl control
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateDistributedApplicationDialogControls.CreateADistributedApplicationStaticControl
        {
            get
            {
                if ((this.cachedCreateADistributedApplicationStaticControl == null))
                {
                    this.cachedCreateADistributedApplicationStaticControl = new StaticControl(this, CreateDistributedApplicationDialog.ControlIDs.CreateADistributedApplicationStaticControl);
                }
                return this.cachedCreateADistributedApplicationStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button New
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNew()
        {
            this.Controls.NewButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">MomConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            return (Window)Utility.GetDialogOrWindow(app, Strings.DialogTitle, 1000, false, true);

        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[mcorning] 5/11/2006 Created
        ///     [a-joelj]   24MAR09  Added some Resources to fetch localized strings from MP
        ///                          for Web Application Designer
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
            private const string ResourceDialogTitle = ";Distributed Application Designer;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.CreateServiceForm;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  New
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNew = ";N&ew...;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.Controls.ManagementPackBasicComboBoxControl;newmpButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ManagementPack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceManagementPack = ";&Management Pack:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterp" +
                "riseManagement.Internal.UI.Authoring.ServiceDesignerEditor.CreateSe" +
                "rviceForm;labelManagementPack.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectAManagementPackWhereYourDistributedApplicationAndItsComponentsWillBeSaved
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectAManagementPackWhereYourDistributedApplicationAndItsComponentsWillBeSaved = @";Select a management pack where your distributed application and its components will be saved.;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.CreateServiceForm;labelSelectManagementPack.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  _3SaveToAManagementPack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string Resource_3SaveToAManagementPack = ";3. Save to a Management Pack;ManagedString;Microsoft.MOM.UI.Components.dll;Micro" +
                "soft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEdit" +
                "or.CreateServiceForm;labelSaveToMP.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ViewDetails
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceViewDetails = ";&View Details;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterprise" +
                "Management.Internal.UI.Authoring.ServiceDesignerEditor.CreateServic" +
                "eForm;linkLabelViewDetail.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Description
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDescription = ";Description:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseM" +
                "anagement.Mom.Internal.UI.Views.AdminNodeDetailView;descriptionLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Template
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTemplate = ";&Template:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMan" +
                "agement.Internal.UI.Authoring.ServiceDesignerEditor.CreateServiceFo" +
                "rm;labelTemplate.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectATemplateThatMostCloselyMatchesTheDistributedApplicationYouHaveDeployedADistributedApplication
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectATemplateThatMostCloselyMatchesTheDistributedApplicationYouHaveDeployedADistributedApplication = @";Select a template that most closely matches the distributed application you have deployed. A distributed application object will be created along with a set of monitors, rules, views, and reports.;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.CreateServiceForm;labelSelectService.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  _2ChooseDistributedApplicationTemplate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string Resource_2ChooseDistributedApplicationTemplate = ";2. Choose Distributed Application Template;ManagedString;Microsoft.MOM.UI.Compon" +
                "ents.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Servi" +
                "ceDesignerEditor.CreateServiceForm;labelChooseTemplate.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceName = ";&Name:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagem" +
                "ent.Internal.UI.Authoring.Pages.EditRegistryProbeDialog;idLabelName.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DescriptionOptional
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDescriptionOptional = ";&Description (optional):;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft" +
                ".EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.C" +
                "reateServiceForm;labelDescription.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ChooseANameThatBestMatchesTheDistributedApplicationYouWantToCreateYouCanFillADescriptionForItIfYouLi
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceChooseANameThatBestMatchesTheDistributedApplicationYouWantToCreateYouCanFillADescriptionForItIfYouLi = @";Choose a name that best matches the distributed application you want to create. You can fill a description for it if you like.;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.CreateServiceForm;labelChoose.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  _1NameYourDistributedApplication
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string Resource_1NameYourDistributedApplication = ";1. Name Your Distributed Application;ManagedString;Microsoft.MOM.UI.Components.d" +
                "ll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesi" +
                "gnerEditor.CreateServiceForm;labeNameYourService.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;DC01.bT;buttonOk.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;DC01.bT;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CreateADistributedApplication
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCreateADistributedApplication = ";Create a Distributed Application;ManagedString;Microsoft.MOM.UI.Components.dll;M" +
                "icrosoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesigner" +
                "Editor.CreateServiceForm;labelCreateAService.Text";            
            #endregion

            #region Private GUIDs

            /// <summary>
            /// Messaging Guid(Stored in ManagedType table)
            /// </summary>          
            private static Guid MessagingGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterServiceDesignerLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.ServiceDesignerMessaging);

            /// <summary>
            /// Generic Service Guid(Stored in ManagedType table)
            /// </summary>
            private static Guid GenericGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterServiceDesignerLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.ServiceDesignerGenericService);

            /// <summary>
            /// Line of Business Web Application Guid(Stored in ManagedType table)
            /// </summary>
            private static Guid LineOfBusinessWebAppGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterServiceDesignerLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.ServiceDesignerWebApplicationName);

            /// <summary>
            /// Web Application Databases Group Guid(Stored in ManagedType table)
            /// </summary>
            private static Guid WebApplicationDatabasesGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterServiceDesignerLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.ServiceDesignerWebApplicationDatabaseGroupName);

            /// <summary>
            /// Web Application Web Sites Group Guid(Stored in ManagedType table)
            /// </summary>
            private static Guid WebApplicationWebSitesGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterServiceDesignerLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.ServiceDesignerWebApplicationWebSiteGroupName);

            /// <summary>
            /// 3-Tier Application (360) Guid(Stored in ManagedType table)
            /// </summary>
            private static Guid _3TierApplicationGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.MicrosoftSystemCenterApplicationMonitoring360TemplateLibrary, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.ApplicationMonitoring360Template3TierApplicationName);

            /// <summary>
            /// Data Tier Guid(Stored in ManagedType table)
            /// </summary>
            private static Guid DataTierGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.MicrosoftSystemCenterApplicationMonitoring360TemplateLibrary, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.ApplicationMonitoring360Template3TierApplicationDataTierName);
            
            /// <summary>
            /// Client Perpective Guid(Stored in ManagedType table)
            /// </summary>
            private static Guid ClientPerpectiveGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.MicrosoftSystemCenterApplicationMonitoring360TemplateLibrary, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.ApplicationMonitoring360Template3TierApplicationClientPerspectiveName);

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
            /// Caches the translated resource string for:  SelectAManagementPackWhereYourDistributedApplicationAndItsComponentsWillBeSaved
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectAManagementPackWhereYourDistributedApplicationAndItsComponentsWillBeSaved;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  _3SaveToAManagementPack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cached_3SaveToAManagementPack;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ViewDetails
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedViewDetails;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Description
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDescription;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Template
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTemplate;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectATemplateThatMostCloselyMatchesTheDistributedApplicationYouHaveDeployedADistributedApplication
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectATemplateThatMostCloselyMatchesTheDistributedApplicationYouHaveDeployedADistributedApplication;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  _2ChooseDistributedApplicationTemplate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cached_2ChooseDistributedApplicationTemplate;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedName;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DescriptionOptional
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDescriptionOptional;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ChooseANameThatBestMatchesTheDistributedApplicationYouWantToCreateYouCanFillADescriptionForItIfYouLi
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedChooseANameThatBestMatchesTheDistributedApplicationYouWantToCreateYouCanFillADescriptionForItIfYouLi;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  _1NameYourDistributedApplication
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cached_1NameYourDistributedApplication;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CreateADistributedApplication
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCreateADistributedApplication;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Line of Business Application
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLineOfBusinessWebApp;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  3-Tier Application (360)
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cached3Tier;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Web Application Databases
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWebApplicationDatabases;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Web Application Databases
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedClientPerpective;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Web Application Databases
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDataTier;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Web Application Web Sites
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWebApplicationWebSites;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Generic Application
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGenericApplication;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Messaging Application
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMessagingApplication;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 5/11/2006 Created
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
            /// Exposes access to the New translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 5/11/2006 Created
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
            /// 	[mcorning] 5/11/2006 Created
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
            /// Exposes access to the SelectAManagementPackWhereYourDistributedApplicationAndItsComponentsWillBeSaved translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 5/11/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectAManagementPackWhereYourDistributedApplicationAndItsComponentsWillBeSaved
            {
                get
                {
                    if ((cachedSelectAManagementPackWhereYourDistributedApplicationAndItsComponentsWillBeSaved == null))
                    {
                        cachedSelectAManagementPackWhereYourDistributedApplicationAndItsComponentsWillBeSaved = CoreManager.MomConsole.GetIntlStr(ResourceSelectAManagementPackWhereYourDistributedApplicationAndItsComponentsWillBeSaved);
                    }
                    return cachedSelectAManagementPackWhereYourDistributedApplicationAndItsComponentsWillBeSaved;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the _3SaveToAManagementPack translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 5/11/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string _3SaveToAManagementPack
            {
                get
                {
                    if ((cached_3SaveToAManagementPack == null))
                    {
                        cached_3SaveToAManagementPack = CoreManager.MomConsole.GetIntlStr(Resource_3SaveToAManagementPack);
                    }
                    return cached_3SaveToAManagementPack;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ViewDetails translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 5/11/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ViewDetails
            {
                get
                {
                    if ((cachedViewDetails == null))
                    {
                        cachedViewDetails = CoreManager.MomConsole.GetIntlStr(ResourceViewDetails);
                    }
                    return cachedViewDetails;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Description translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 5/11/2006 Created
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
            /// Exposes access to the Template translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 5/11/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Template
            {
                get
                {
                    if ((cachedTemplate == null))
                    {
                        cachedTemplate = CoreManager.MomConsole.GetIntlStr(ResourceTemplate);
                    }
                    return cachedTemplate;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectATemplateThatMostCloselyMatchesTheDistributedApplicationYouHaveDeployedADistributedApplication translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 5/11/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectATemplateThatMostCloselyMatchesTheDistributedApplicationYouHaveDeployedADistributedApplication
            {
                get
                {
                    if ((cachedSelectATemplateThatMostCloselyMatchesTheDistributedApplicationYouHaveDeployedADistributedApplication == null))
                    {
                        cachedSelectATemplateThatMostCloselyMatchesTheDistributedApplicationYouHaveDeployedADistributedApplication = CoreManager.MomConsole.GetIntlStr(ResourceSelectATemplateThatMostCloselyMatchesTheDistributedApplicationYouHaveDeployedADistributedApplication);
                    }
                    return cachedSelectATemplateThatMostCloselyMatchesTheDistributedApplicationYouHaveDeployedADistributedApplication;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the _2ChooseDistributedApplicationTemplate translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 5/11/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string _2ChooseDistributedApplicationTemplate
            {
                get
                {
                    if ((cached_2ChooseDistributedApplicationTemplate == null))
                    {
                        cached_2ChooseDistributedApplicationTemplate = CoreManager.MomConsole.GetIntlStr(Resource_2ChooseDistributedApplicationTemplate);
                    }
                    return cached_2ChooseDistributedApplicationTemplate;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Name translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 5/11/2006 Created
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
            /// Exposes access to the DescriptionOptional translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 5/11/2006 Created
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
            /// Exposes access to the ChooseANameThatBestMatchesTheDistributedApplicationYouWantToCreateYouCanFillADescriptionForItIfYouLi translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 5/11/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ChooseANameThatBestMatchesTheDistributedApplicationYouWantToCreateYouCanFillADescriptionForItIfYouLi
            {
                get
                {
                    if ((cachedChooseANameThatBestMatchesTheDistributedApplicationYouWantToCreateYouCanFillADescriptionForItIfYouLi == null))
                    {
                        cachedChooseANameThatBestMatchesTheDistributedApplicationYouWantToCreateYouCanFillADescriptionForItIfYouLi = CoreManager.MomConsole.GetIntlStr(ResourceChooseANameThatBestMatchesTheDistributedApplicationYouWantToCreateYouCanFillADescriptionForItIfYouLi);
                    }
                    return cachedChooseANameThatBestMatchesTheDistributedApplicationYouWantToCreateYouCanFillADescriptionForItIfYouLi;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the _1NameYourDistributedApplication translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 5/11/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string _1NameYourDistributedApplication
            {
                get
                {
                    if ((cached_1NameYourDistributedApplication == null))
                    {
                        cached_1NameYourDistributedApplication = CoreManager.MomConsole.GetIntlStr(Resource_1NameYourDistributedApplication);
                    }
                    return cached_1NameYourDistributedApplication;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 5/11/2006 Created
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
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 5/11/2006 Created
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
            /// Exposes access to the CreateADistributedApplication translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 5/11/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CreateADistributedApplication
            {
                get
                {
                    if ((cachedCreateADistributedApplication == null))
                    {
                        cachedCreateADistributedApplication = CoreManager.MomConsole.GetIntlStr(ResourceCreateADistributedApplication);
                    }
                    return cachedCreateADistributedApplication;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Generic Application translated resource string
            /// </summary>
            /// <history>
            /// 	[a-mujtch] 22JUN09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string GenericApplication
            {
                get
                {
                    if ((cachedGenericApplication == null))
                    {
                        cachedGenericApplication = Common.Utilities.GetEntityName(Convert.ToString(GenericGuid));
                    }
                    return cachedGenericApplication;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Messaging Application translated resource string
            /// </summary>
            /// <history>
            /// 	[a-mujtch] 22JUN09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Messaging
            {
                get
                {
                    if ((cachedMessagingApplication == null))
                    {
                        cachedMessagingApplication = Common.Utilities.GetEntityName(Convert.ToString(MessagingGuid));
                    }
                    return cachedMessagingApplication;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Line of Business Web Application translated resource string
            /// </summary>
            /// <history>
            /// 	[a-joelj] 23MAR09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LineOfBusinessWebApp
            {
                get
                {
                    if ((cachedLineOfBusinessWebApp == null))
                    {
                        cachedLineOfBusinessWebApp = Common.Utilities.GetEntityName(Convert.ToString(LineOfBusinessWebAppGuid));
                    }
                    return cachedLineOfBusinessWebApp;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the 3-Tier Application(360) translated resource string
            /// </summary>
            /// <history>
            /// 	[v-tfeng] 12OCT11 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tier
            {
                get
                {
                    if ((cached3Tier == null))
                    {
                        cached3Tier = Common.Utilities.GetEntityName(Convert.ToString(_3TierApplicationGuid));
                    }
                    return cached3Tier;
                }
            }
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Client Perpective translated resource string
            /// </summary>
            /// <history>
            /// 	
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ClientPerpective
            {
                get
                {
                    if ((cachedClientPerpective == null))
                    {
                        cachedClientPerpective = Common.Utilities.GetEntityName(Convert.ToString(ClientPerpectiveGuid));
                    }
                    return cachedClientPerpective;
                }
            }
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Data Tier translated resource string
            /// </summary>
            /// <history>
            /// 	
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DataTier
            {
                get
                {
                    if ((cachedDataTier == null))
                    {
                        cachedDataTier = Common.Utilities.GetEntityName(Convert.ToString(DataTierGuid));
                    }
                    return cachedDataTier;
                }
            }
            
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Web Application Databases translated resource string
            /// </summary>
            /// <history>
            /// 	[a-joelj] 24MAR09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WebApplicationDatabases
            {
                get
                {
                    if ((cachedWebApplicationDatabases == null))
                    {
                        cachedWebApplicationDatabases = Common.Utilities.GetEntityName(Convert.ToString(WebApplicationDatabasesGuid));
                    }
                    return cachedWebApplicationDatabases;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Web Application Web Sites translated resource string
            /// </summary>
            /// <history>
            /// 	[a-joelj] 24MAR09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WebApplicationWebSites
            {
                get
                {
                    if ((cachedWebApplicationWebSites == null))
                    {
                        cachedWebApplicationWebSites = Common.Utilities.GetEntityName(Convert.ToString(WebApplicationWebSitesGuid));
                    }
                    return cachedWebApplicationWebSites;
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
        /// 	[mcorning] 5/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for NewButton
            /// </summary>
            public const string NewButton = "newmpButton";
            
            /// <summary>
            /// Control ID for ManagementPackComboBox
            /// </summary>
            public const string ManagementPackComboBox = "comboBoxMp";
            
            /// <summary>
            /// Control ID for ManagementPackStaticControl
            /// </summary>
            public const string ManagementPackStaticControl = "labelManagementPack";
            
            /// <summary>
            /// Control ID for SelectAManagementPackWhereYourDistributedApplicationAndItsComponentsWillBeSavedStaticControl
            /// </summary>
            public const string SelectAManagementPackWhereYourDistributedApplicationAndItsComponentsWillBeSavedStaticControl = "labelSelectManagementPack";
            
            /// <summary>
            /// Control ID for _3SaveToAManagementPackStaticControl
            /// </summary>
            public const string _3SaveToAManagementPackStaticControl = "labelSaveToMP";
            
            /// <summary>
            /// Control ID for TemplateListBox
            /// </summary>
            public const string TemplateListBox = "listBoxTemplate";
            
            /// <summary>
            /// Control ID for ViewDetailsStaticControl
            /// </summary>
            public const string ViewDetailsStaticControl = "linkLabelViewDetail";
            
            /// <summary>
            /// Control ID for StaticControl0
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string StaticControl0 = "labelTemplateDescription";
            
            /// <summary>
            /// Control ID for DescriptionStaticControl
            /// </summary>
            public const string DescriptionStaticControl = "labelTempDescription";
            
            /// <summary>
            /// Control ID for TemplateStaticControl
            /// </summary>
            public const string TemplateStaticControl = "labelTemplate";
            
            /// <summary>
            /// Control ID for SelectATemplateThatMostCloselyMatchesTheDistributedApplicationYouHaveDeployedADistributedApplication
            /// </summary>
            public const string SelectATemplateThatMostCloselyMatchesTheDistributedApplicationYouHaveDeployedADistributedApplication = "labelSelectService";
            
            /// <summary>
            /// Control ID for _2ChooseDistributedApplicationTemplateStaticControl
            /// </summary>
            public const string _2ChooseDistributedApplicationTemplateStaticControl = "labelChooseTemplate";
            
            /// <summary>
            /// Control ID for NameStaticControl
            /// </summary>
            public const string NameStaticControl = "labelName";
            
            /// <summary>
            /// Control ID for DescriptionOptionalStaticControl
            /// </summary>
            public const string DescriptionOptionalStaticControl = "labelDescription";
            
            /// <summary>
            /// Control ID for ChooseANameThatBestMatchesTheDistributedApplicationYouWantToCreateYouCanFillADescriptionForItIfYouLi
            /// </summary>
            public const string ChooseANameThatBestMatchesTheDistributedApplicationYouWantToCreateYouCanFillADescriptionForItIfYouLi = "labelChoose";
            
            /// <summary>
            /// Control ID for _1NameYourDistributedApplicationStaticControl
            /// </summary>
            public const string _1NameYourDistributedApplicationStaticControl = "labeNameYourService";
            
            /// <summary>
            /// Control ID for DescriptionOptionalTextBox
            /// </summary>
            public const string DescriptionOptionalTextBox = "textBoxDescription";
            
            /// <summary>
            /// Control ID for NameTextBox
            /// </summary>
            public const string NameTextBox = "textBoxName";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "buttonOk";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "buttonCancel";
            
            /// <summary>
            /// Control ID for CreateADistributedApplicationStaticControl
            /// </summary>
            public const string CreateADistributedApplicationStaticControl = "labelCreateAService";
        }
        #endregion
    }
}
