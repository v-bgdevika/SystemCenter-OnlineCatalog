// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="GroupWizGeneralPropertiesPage.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	MOMv3 UI Test Automation
// </summary>
// <history>
// 	[HainingW] 3/9/2006 Created
// 	[HainingW] 3/24/2006 Fixed Resource string and add a second constructor which takes title string
//  [KellyMor] 12-Jun-08 Fixed missing delay bug in retry loop catch block 
//                       in Init method
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Groups.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    
    #region Interface Definition - IGroupWizGeneralPropertiesPageControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IGroupWizGeneralPropertiesPageControls, for GroupWizGeneralPropertiesPage.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[HainingW] 3/9/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IGroupWizGeneralPropertiesPageControls
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
        /// Read-only property to access FinishButton
        /// </summary>
        Button FinishButton
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
        /// Read-only property to access ExplicitMembersStaticControl
        /// </summary>
        StaticControl ExplicitMembersStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DynamicMembersStaticControl
        /// </summary>
        StaticControl DynamicMembersStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SubgroupsStaticControl
        /// </summary>
        StaticControl SubgroupsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ExcludedMembersStaticControl
        /// </summary>
        StaticControl ExcludedMembersStaticControl
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
        /// Read-only property to access GeneralPropertiesStaticControl2
        /// </summary>
        StaticControl GeneralPropertiesStaticControl2
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
        /// Read-only property to access EnterTheNameAndDescriptionForTheNewGroupStaticControl
        /// </summary>
        StaticControl EnterTheNameAndDescriptionForTheNewGroupStaticControl
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the "General Properties" page of the Create Group Wizard.
    /// </summary>
    /// <history>
    /// 	[HainingW] 3/9/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class GroupWizGeneralPropertiesPage : Dialog, IGroupWizGeneralPropertiesPageControls
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
        /// Cache to hold a reference to FinishButton of type Button
        /// </summary>
        private Button cachedFinishButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to GeneralPropertiesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralPropertiesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ExplicitMembersStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedExplicitMembersStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DynamicMembersStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDynamicMembersStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SubgroupsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSubgroupsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ExcludedMembersStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedExcludedMembersStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ManagementPackStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedManagementPackStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectDestinationManagementPackStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectDestinationManagementPackStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to NewButton of type Button
        /// </summary>
        private Button cachedNewButton;
        
        /// <summary>
        /// Cache to hold a reference to SelectDestinationManagementPackComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedSelectDestinationManagementPackComboBox;
        
        /// <summary>
        /// Cache to hold a reference to GeneralPropertiesStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralPropertiesStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to DescriptionTextBox of type TextBox
        /// </summary>
        private TextBox cachedDescriptionTextBox;
        
        /// <summary>
        /// Cache to hold a reference to DescriptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDescriptionStaticControl;
        
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
        /// Cache to hold a reference to EnterTheNameAndDescriptionForTheNewGroupStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEnterTheNameAndDescriptionForTheNewGroupStaticControl;

        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class constructor - with no dialog title passed in.
        /// </summary>
        /// <param name='app'>
        /// Owner of GroupWizGeneralPropertiesPage of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public GroupWizGeneralPropertiesPage(MomConsoleApp app) 
            : base(app, Init(app))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Timeout);
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class constructor - with dialog title passed in.
        /// </summary>
        /// <param name='app'>
        /// Owner of CreateGroupWizardFinishDialog of type Mom.Test.UI.Core.Console.MomConsoleApp
        /// </param>
        /// <param name="title">Alternative title of dialog</param>
        /// <history>
        /// 	[HainingW] 3/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public GroupWizGeneralPropertiesPage(MomConsoleApp app, string title) 
            : base(app, Init(app, title))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Timeout);
        }

        #endregion
        
        #region IGroupWizGeneralPropertiesPage Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IGroupWizGeneralPropertiesPageControls Controls
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
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
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
        ///  Routine to set/get the text in control Description
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
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
        ///  Routine to set/get the text in control NameTextBox
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
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
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IGroupWizGeneralPropertiesPageControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, GroupWizGeneralPropertiesPage.ControlIDs.PreviousButton);
                }
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IGroupWizGeneralPropertiesPageControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, GroupWizGeneralPropertiesPage.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FinishButton control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IGroupWizGeneralPropertiesPageControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, GroupWizGeneralPropertiesPage.ControlIDs.FinishButton);
                }
                return this.cachedFinishButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IGroupWizGeneralPropertiesPageControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, GroupWizGeneralPropertiesPage.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralPropertiesStaticControl control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGroupWizGeneralPropertiesPageControls.GeneralPropertiesStaticControl
        {
            get
            {
                if ((this.cachedGeneralPropertiesStaticControl == null))
                {
                    this.cachedGeneralPropertiesStaticControl = new StaticControl(this, GroupWizGeneralPropertiesPage.ControlIDs.GeneralPropertiesStaticControl);
                }
                return this.cachedGeneralPropertiesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExplicitMembersStaticControl control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGroupWizGeneralPropertiesPageControls.ExplicitMembersStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedExplicitMembersStaticControl == null))
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
                    this.cachedExplicitMembersStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedExplicitMembersStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DynamicMembersStaticControl control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGroupWizGeneralPropertiesPageControls.DynamicMembersStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedDynamicMembersStaticControl == null))
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
                    this.cachedDynamicMembersStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedDynamicMembersStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SubgroupsStaticControl control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGroupWizGeneralPropertiesPageControls.SubgroupsStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedSubgroupsStaticControl == null))
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
                    this.cachedSubgroupsStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedSubgroupsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExcludedMembersStaticControl control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGroupWizGeneralPropertiesPageControls.ExcludedMembersStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedExcludedMembersStaticControl == null))
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
                    this.cachedExcludedMembersStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedExcludedMembersStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementPackStaticControl control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGroupWizGeneralPropertiesPageControls.ManagementPackStaticControl
        {
            get
            {
                if ((this.cachedManagementPackStaticControl == null))
                {
                    this.cachedManagementPackStaticControl = new StaticControl(this, GroupWizGeneralPropertiesPage.ControlIDs.ManagementPackStaticControl);
                }
                return this.cachedManagementPackStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectDestinationManagementPackStaticControl control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGroupWizGeneralPropertiesPageControls.SelectDestinationManagementPackStaticControl
        {
            get
            {
                if ((this.cachedSelectDestinationManagementPackStaticControl == null))
                {
                    this.cachedSelectDestinationManagementPackStaticControl = new StaticControl(this, GroupWizGeneralPropertiesPage.ControlIDs.SelectDestinationManagementPackStaticControl);
                }
                return this.cachedSelectDestinationManagementPackStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NewButton control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IGroupWizGeneralPropertiesPageControls.NewButton
        {
            get
            {
                if ((this.cachedNewButton == null))
                {
                    this.cachedNewButton = new Button(this, GroupWizGeneralPropertiesPage.ControlIDs.NewButton);
                }
                return this.cachedNewButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectDestinationManagementPackComboBox control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IGroupWizGeneralPropertiesPageControls.SelectDestinationManagementPackComboBox
        {
            get
            {
                if ((this.cachedSelectDestinationManagementPackComboBox == null))
                {
                    this.cachedSelectDestinationManagementPackComboBox = new ComboBox(this, GroupWizGeneralPropertiesPage.ControlIDs.SelectDestinationManagementPackComboBox);
                }
                return this.cachedSelectDestinationManagementPackComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralPropertiesStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGroupWizGeneralPropertiesPageControls.GeneralPropertiesStaticControl2
        {
            get
            {
                // The ID for this control (pageSectionLabel1) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedGeneralPropertiesStaticControl2 == null))
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
                    wndTemp = wndTemp.Extended.NextSibling;
                    this.cachedGeneralPropertiesStaticControl2 = new StaticControl(wndTemp);
                }
                return this.cachedGeneralPropertiesStaticControl2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionTextBox control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IGroupWizGeneralPropertiesPageControls.DescriptionTextBox
        {
            get
            {
                if ((this.cachedDescriptionTextBox == null))
                {
                    this.cachedDescriptionTextBox = new TextBox(this, GroupWizGeneralPropertiesPage.ControlIDs.DescriptionTextBox);
                }
                return this.cachedDescriptionTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGroupWizGeneralPropertiesPageControls.DescriptionStaticControl
        {
            get
            {
                if ((this.cachedDescriptionStaticControl == null))
                {
                    this.cachedDescriptionStaticControl = new StaticControl(this, GroupWizGeneralPropertiesPage.ControlIDs.DescriptionStaticControl);
                }
                return this.cachedDescriptionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameTextBox control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IGroupWizGeneralPropertiesPageControls.NameTextBox
        {
            get
            {
                if ((this.cachedNameTextBox == null))
                {
                    this.cachedNameTextBox = new TextBox(this, GroupWizGeneralPropertiesPage.ControlIDs.NameTextBox);
                }
                return this.cachedNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameStaticControl control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGroupWizGeneralPropertiesPageControls.NameStaticControl
        {
            get
            {
                if ((this.cachedNameStaticControl == null))
                {
                    this.cachedNameStaticControl = new StaticControl(this, GroupWizGeneralPropertiesPage.ControlIDs.NameStaticControl);
                }
                return this.cachedNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGroupWizGeneralPropertiesPageControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, GroupWizGeneralPropertiesPage.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EnterTheNameAndDescriptionForTheNewGroupStaticControl control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGroupWizGeneralPropertiesPageControls.EnterTheNameAndDescriptionForTheNewGroupStaticControl
        {
            get
            {
                if ((this.cachedEnterTheNameAndDescriptionForTheNewGroupStaticControl == null))
                {
                    this.cachedEnterTheNameAndDescriptionForTheNewGroupStaticControl = new StaticControl(this, GroupWizGeneralPropertiesPage.ControlIDs.EnterTheNameAndDescriptionForTheNewGroupStaticControl);
                }
                return this.cachedEnterTheNameAndDescriptionForTheNewGroupStaticControl;
            }
        }

        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
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
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNext()
        {
            this.Controls.NextButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Finish
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickFinish()
        {
            this.Controls.FinishButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button New
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNew()
        {
            this.Controls.NewButton.Click();
        }

        #endregion

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a visible instance of the dialog
        /// using its default title.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">MomConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[HainingW] 3/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            Utilities.LogMessage("GroupWizGeneralPropertiesPage :: Init(app)");
            Window tempWindow = Init(app, Strings.DialogTitle);
            return tempWindow;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">MomConsoleApp owning the dialog.</param>)
        /// <param name="title">Alternative title of dialog</param>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app, string title)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            Utilities.LogMessage("GroupWizGeneralPropertiesPage :: Init(app, title)");

            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(title, 
                                        StringMatchSyntax.ExactMatch, 
                                        WindowClassNames.Dialog, 
                                        StringMatchSyntax.ExactMatch, 
                                        app.MainWindow, 
                                        Timeout);
            }
            catch (Exceptions.WindowNotFoundException)
            {
                tempWindow = null;
                int numberOfTries = 0;
                const int MaxTries = 25;

                while (tempWindow == null && numberOfTries < MaxTries)
                {
                    numberOfTries++;
                    try
                    {
                        // look for the window again using wildcards
                        tempWindow = new Window(title + "*", StringMatchSyntax.WildCard);
                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(tempWindow, Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Utilities.LogMessage("Attempt " + numberOfTries + " of " + MaxTries);

                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }

                // Check for success
                if (tempWindow == null)
                {
                    // Log the failure
                    Utilities.LogMessage("Failed to find window with title:  '" + title + "'");
                    // Throw the existing WindowNotFound exception
                    throw;
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
        /// 	[HainingW] 3/9/2006 Created
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
            //private const string ResourceDialogTitle = ";Create Group Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Common.CommonResources;CreateGroupWizard";

            private const string ResourceDialogTitle = ";Create Group Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Group.GroupResources;CreateGroupWizardCaption";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrevious = ";< &Previous;ManagedString;Microsoft.MOM." + 
                "UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.PageFramework." + 
                "WizardButtonsPanel;previousButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext = ";&Next >;ManagedString;Microsoft.MOM.UI.Common.dll;" + 
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.PageFrameworks.WizardFramework;buttonNext.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Finish
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFinish = ";&Finish;ManagedString;Microsoft.MOM.UI.Common.dll;" + 
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.PageFrameworks.WizardFramework;buttonFinish.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;DC01.bT;" + 
                "buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  GeneralProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneralProperties = ";General Properties;ManagedString;" +
                "Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI." + 
                "Authoring.Pages.NameAndDescriptionPage;$this.NavigationText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ExplicitMembers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceExplicitMembers = ";Explicit Members;ManagedString;Microsoft." + 
                "MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Group." + 
                "InstancesPage;$this.TabName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DynamicMembers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDynamicMembers = ";Dynamic Members;ManagedString;Microsoft." + 
                "MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Group." + 
                "MembershipFormulaPage;$this.NavigationText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Subgroups
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSubgroups = ";Subgroups;ManagedString;Microsoft.MOM.UI.Components.dll;" + 
                "Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Group.SubgroupsPage;$this.NavigationText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ExcludedMembers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceExcludedMembers = ";Excluded Members;ManagedString;Microsoft." + 
                "MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Group." + 
                "ExcludedMembersPage;$this.NavigationText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ManagementPack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceManagementPack = ";Management pack;ManagedString;Microsoft." + 
                "MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls." + 
                "ManagementPackComboBoxControl;pageSectionLabel1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectDestinationManagementPack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectDestinationManagementPack = ";&Select destination management pack:;" + 
                "ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI." + 
                "Controls.ManagementPackComboBoxControl;label1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  New
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNew = ";&New...;ManagedString;Microsoft.MOM.UI.Components.dll;" + 
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.ResolutionStates;" + 
                "toolStripButtonNew.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  GeneralProperties2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneralProperties2 = ";General properties;ManagedString;" +
                "Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI." + 
                "Authoring.Pages.NameAndDescriptionPage;pageSectionLabel1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Description
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDescription = ";&Description:;ManagedString;Microsoft.MOM.UI." + 
                "Components.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.NameAndDescriptionPage;" + 
                "descLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceName = ";Na&me:;ManagedString;Microsoft.MOM.UI.Components.dll;" + 
                "Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.NameAndDescriptionPage;nameLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;" + 
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EnterTheNameAndDescriptionForTheNewGroup
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceEnterTheNameAndDescriptionForTheNewGroup = "Enter the Name and Description for the new Group.";
            
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
            /// Caches the translated resource string for:  Finish
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFinish;
            
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
            /// Caches the translated resource string for:  ExplicitMembers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedExplicitMembers;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DynamicMembers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDynamicMembers;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Subgroups
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSubgroups;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ExcludedMembers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedExcludedMembers;
            
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
            /// Caches the translated resource string for:  New
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNew;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  GeneralProperties2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneralProperties2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Description
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDescription;
            
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
            /// Caches the translated resource string for:  EnterTheNameAndDescriptionForTheNewGroup
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEnterTheNameAndDescriptionForTheNewGroup;
            
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 3/9/2006 Created
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
            /// 	[HainingW] 3/9/2006 Created
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
            /// 	[HainingW] 3/9/2006 Created
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
            /// Exposes access to the Finish translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 3/9/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Finish
            {
                get
                {
                    if ((cachedFinish == null))
                    {
                        cachedFinish = CoreManager.MomConsole.GetIntlStr(ResourceFinish);
                    }
                    return cachedFinish;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 3/9/2006 Created
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
            /// 	[HainingW] 3/9/2006 Created
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
            /// Exposes access to the ExplicitMembers translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 3/9/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ExplicitMembers
            {
                get
                {
                    if ((cachedExplicitMembers == null))
                    {
                        cachedExplicitMembers = CoreManager.MomConsole.GetIntlStr(ResourceExplicitMembers);
                    }
                    return cachedExplicitMembers;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DynamicMembers translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 3/9/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DynamicMembers
            {
                get
                {
                    if ((cachedDynamicMembers == null))
                    {
                        cachedDynamicMembers = CoreManager.MomConsole.GetIntlStr(ResourceDynamicMembers);
                    }
                    return cachedDynamicMembers;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Subgroups translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 3/9/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Subgroups
            {
                get
                {
                    if ((cachedSubgroups == null))
                    {
                        cachedSubgroups = CoreManager.MomConsole.GetIntlStr(ResourceSubgroups);
                    }
                    return cachedSubgroups;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ExcludedMembers translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 3/9/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ExcludedMembers
            {
                get
                {
                    if ((cachedExcludedMembers == null))
                    {
                        cachedExcludedMembers = CoreManager.MomConsole.GetIntlStr(ResourceExcludedMembers);
                    }
                    return cachedExcludedMembers;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ManagementPack translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 3/9/2006 Created
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
            /// 	[HainingW] 3/9/2006 Created
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
            /// 	[HainingW] 3/9/2006 Created
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
            /// Exposes access to the GeneralProperties2 translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 3/9/2006 Created
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
            /// Exposes access to the Description translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 3/9/2006 Created
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
            /// Exposes access to the Name translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 3/9/2006 Created
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
            /// 	[HainingW] 3/9/2006 Created
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
            /// Exposes access to the EnterTheNameAndDescriptionForTheNewGroup translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 3/9/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EnterTheNameAndDescriptionForTheNewGroup
            {
                get
                {
                    if ((cachedEnterTheNameAndDescriptionForTheNewGroup == null))
                    {
                        cachedEnterTheNameAndDescriptionForTheNewGroup = CoreManager.MomConsole.GetIntlStr(ResourceEnterTheNameAndDescriptionForTheNewGroup);
                    }
                    return cachedEnterTheNameAndDescriptionForTheNewGroup;
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
        /// 	[HainingW] 3/9/2006 Created
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
            /// Control ID for FinishButton
            /// </summary>
            public const string FinishButton = "commitButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for GeneralPropertiesStaticControl
            /// </summary>
            public const string GeneralPropertiesStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ExplicitMembersStaticControl
            /// </summary>
            public const string ExplicitMembersStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for DynamicMembersStaticControl
            /// </summary>
            public const string DynamicMembersStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for SubgroupsStaticControl
            /// </summary>
            public const string SubgroupsStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ExcludedMembersStaticControl
            /// </summary>
            public const string ExcludedMembersStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ManagementPackStaticControl
            /// </summary>
            public const string ManagementPackStaticControl = "pageSectionLabel1";
            
            /// <summary>
            /// Control ID for SelectDestinationManagementPackStaticControl
            /// </summary>
            public const string SelectDestinationManagementPackStaticControl = "label1";
            
            /// <summary>
            /// Control ID for NewButton
            /// </summary>
            public const string NewButton = "newmpButton";
            
            /// <summary>
            /// Control ID for SelectDestinationManagementPackComboBox
            /// </summary>
            public const string SelectDestinationManagementPackComboBox = "comboBoxMp";
            
            /// <summary>
            /// Control ID for GeneralPropertiesStaticControl2
            /// </summary>
            public const string GeneralPropertiesStaticControl2 = "pageSectionLabel1";
            
            /// <summary>
            /// Control ID for DescriptionTextBox
            /// </summary>
            public const string DescriptionTextBox = "descriptionTextBox";
            
            /// <summary>
            /// Control ID for DescriptionStaticControl
            /// </summary>
            public const string DescriptionStaticControl = "descLabel";
            
            /// <summary>
            /// Control ID for NameTextBox
            /// </summary>
            public const string NameTextBox = "nameTextBox";
            
            /// <summary>
            /// Control ID for NameStaticControl
            /// </summary>
            public const string NameStaticControl = "nameLabel";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for EnterTheNameAndDescriptionForTheNewGroupStaticControl
            /// </summary>
            public const string EnterTheNameAndDescriptionForTheNewGroupStaticControl = "headerLabel";
        }

        #endregion
    }
}
