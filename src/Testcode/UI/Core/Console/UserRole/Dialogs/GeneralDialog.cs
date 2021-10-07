// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="GeneralDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	MOMv3 UI Test Automation
// </summary>
// <history>
// 	[ruhim] 1/25/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.UserRole.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    
    #region Interface Definition - IGeneralDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IGeneralDialogControls, for GeneralDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 1/25/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IGeneralDialogControls
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
        /// Read-only property to access GeneralStaticControl
        /// </summary>
        StaticControl GeneralStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access GroupScopeStaticControl
        /// </summary>
        StaticControl GroupScopeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TasksStaticControl
        /// </summary>
        StaticControl TasksStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ViewsStaticControl
        /// </summary>
        StaticControl ViewsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SummaryStaticControl
        /// </summary>
        StaticControl SummaryStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access UserRoleMembersToolbar
        /// </summary>
        Toolbar UserRoleMembersToolbar
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ProfileDescriptionTextBox
        /// </summary>
        TextBox ProfileDescriptionTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ProfileDescriptionStaticControl
        /// </summary>
        StaticControl ProfileDescriptionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ProfileTextBox
        /// </summary>
        TextBox ProfileTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ProfileStaticControl
        /// </summary>
        StaticControl ProfileStaticControl
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
        /// Read-only property to access UserRoleNameStaticControl
        /// </summary>
        StaticControl UserRoleNameStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access UserRoleMembersListView
        /// </summary>
        ListView UserRoleMembersListView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access UserRoleMembersStaticControl
        /// </summary>
        StaticControl UserRoleMembersStaticControl
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
        /// Read-only property to access GeneralStaticControl2
        /// </summary>
        StaticControl GeneralStaticControl2
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
    /// 	[ruhim] 1/25/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class GeneralDialog : Dialog, IGeneralDialogControls
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
        /// Cache to hold a reference to GeneralStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to GroupScopeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGroupScopeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to TasksStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTasksStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ViewsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedViewsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SummaryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSummaryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to UserRoleMembersToolbar of type Toolbar
        /// </summary>
        private Toolbar cachedUserRoleMembersToolbar;
        
        /// <summary>
        /// Cache to hold a reference to ProfileDescriptionTextBox of type TextBox
        /// </summary>
        private TextBox cachedProfileDescriptionTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ProfileDescriptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedProfileDescriptionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ProfileTextBox of type TextBox
        /// </summary>
        private TextBox cachedProfileTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ProfileStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedProfileStaticControl;
        
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
        /// Cache to hold a reference to UserRoleNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedUserRoleNameStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to UserRoleMembersListView of type ListView
        /// </summary>
        private ListView cachedUserRoleMembersListView;
        
        /// <summary>
        /// Cache to hold a reference to UserRoleMembersStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedUserRoleMembersStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to GeneralStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralStaticControl2;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of GeneralDialog of type App
        /// </param>
        /// <history>
        /// 	[ruhim] 1/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public GeneralDialog(ConsoleApp app)
            : 
                base(app, Init(app))
        {
            //this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
        }
        #endregion
        
        #region IGeneralDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 1/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IGeneralDialogControls Controls
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
        ///  Routine to set/get the text in control ProfileDescription
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 1/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ProfileDescriptionText
        {
            get
            {
                return this.Controls.ProfileDescriptionTextBox.Text;
            }
            
            set
            {
                this.Controls.ProfileDescriptionTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Profile
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 1/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ProfileText
        {
            get
            {
                return this.Controls.ProfileTextBox.Text;
            }
            
            set
            {
                this.Controls.ProfileTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Summary
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 1/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DescriptionTextBox
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
        ///  Routine to set/get the text in control Tasks
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 1/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string NameTextBox
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
        /// 	[ruhim] 1/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IGeneralDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, GeneralDialog.ControlIDs.PreviousButton);
                }
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 1/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IGeneralDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, GeneralDialog.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 1/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IGeneralDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, GeneralDialog.ControlIDs.CreateButton);
                }
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 1/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IGeneralDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, GeneralDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 1/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGeneralDialogControls.GeneralStaticControl
        {
            get
            {
                if ((this.cachedGeneralStaticControl == null))
                {
                    this.cachedGeneralStaticControl = new StaticControl(this, GeneralDialog.ControlIDs.GeneralStaticControl);
                }
                return this.cachedGeneralStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GroupScopeStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 1/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGeneralDialogControls.GroupScopeStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedGroupScopeStaticControl == null))
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
                    this.cachedGroupScopeStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedGroupScopeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TasksStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 1/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGeneralDialogControls.TasksStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedTasksStaticControl == null))
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
                    this.cachedTasksStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedTasksStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ViewsStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 1/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGeneralDialogControls.ViewsStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedViewsStaticControl == null))
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
                    this.cachedViewsStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedViewsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SummaryStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 1/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGeneralDialogControls.SummaryStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedSummaryStaticControl == null))
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
                    this.cachedSummaryStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedSummaryStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UserRoleMembersToolbar control
        /// </summary>
        /// <history>
        /// 	[ruhim] 1/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IGeneralDialogControls.UserRoleMembersToolbar
        {
            get
            {
                if ((this.cachedUserRoleMembersToolbar == null))
                {
                    this.cachedUserRoleMembersToolbar = new Toolbar(this/*, GeneralDialog.ControlIDs.UserRoleMembersToolbar*/);
                }
                return this.cachedUserRoleMembersToolbar;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ProfileDescriptionTextBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 1/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IGeneralDialogControls.ProfileDescriptionTextBox
        {
            get
            {
                if ((this.cachedProfileDescriptionTextBox == null))
                {
                    this.cachedProfileDescriptionTextBox = new TextBox(this, GeneralDialog.ControlIDs.ProfileDescriptionTextBox);
                }
                return this.cachedProfileDescriptionTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ProfileDescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 1/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGeneralDialogControls.ProfileDescriptionStaticControl
        {
            get
            {
                if ((this.cachedProfileDescriptionStaticControl == null))
                {
                    this.cachedProfileDescriptionStaticControl = new StaticControl(this, GeneralDialog.ControlIDs.ProfileDescriptionStaticControl);
                }
                return this.cachedProfileDescriptionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ProfileTextBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 1/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IGeneralDialogControls.ProfileTextBox
        {
            get
            {
                if ((this.cachedProfileTextBox == null))
                {
                    this.cachedProfileTextBox = new TextBox(this, GeneralDialog.ControlIDs.ProfileTextBox);
                }
                return this.cachedProfileTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ProfileStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 1/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGeneralDialogControls.ProfileStaticControl
        {
            get
            {
                if ((this.cachedProfileStaticControl == null))
                {
                    this.cachedProfileStaticControl = new StaticControl(this, GeneralDialog.ControlIDs.ProfileStaticControl);
                }
                return this.cachedProfileStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionTextBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 1/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IGeneralDialogControls.DescriptionTextBox
        {
            get
            {
                if ((this.cachedDescriptionTextBox == null))
                {
                    this.cachedDescriptionTextBox = new TextBox(this, GeneralDialog.ControlIDs.DescriptionTextBox);
                }
                return this.cachedDescriptionTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 1/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGeneralDialogControls.DescriptionStaticControl
        {
            get
            {
                if ((this.cachedDescriptionStaticControl == null))
                {
                    this.cachedDescriptionStaticControl = new StaticControl(this, GeneralDialog.ControlIDs.DescriptionStaticControl);
                }
                return this.cachedDescriptionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameTextBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 1/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IGeneralDialogControls.NameTextBox
        {
            get
            {
                if ((this.cachedNameTextBox == null))
                {
                    this.cachedNameTextBox = new TextBox(this, GeneralDialog.ControlIDs.NameTextBox);
                }
                return this.cachedNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UserRoleNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 1/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGeneralDialogControls.UserRoleNameStaticControl
        {
            get
            {
                if ((this.cachedUserRoleNameStaticControl == null))
                {
                    this.cachedUserRoleNameStaticControl = new StaticControl(this, GeneralDialog.ControlIDs.UserRoleNameStaticControl);
                }
                return this.cachedUserRoleNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UserRoleMembersListView control
        /// </summary>
        /// <history>
        /// 	[ruhim] 1/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IGeneralDialogControls.UserRoleMembersListView
        {
            get
            {
                if ((this.cachedUserRoleMembersListView == null))
                {
                    this.cachedUserRoleMembersListView = new ListView(this, GeneralDialog.ControlIDs.UserRoleMembersListView);
                }
                return this.cachedUserRoleMembersListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UserRoleMembersStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 1/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGeneralDialogControls.UserRoleMembersStaticControl
        {
            get
            {
                if ((this.cachedUserRoleMembersStaticControl == null))
                {
                    this.cachedUserRoleMembersStaticControl = new StaticControl(this, GeneralDialog.ControlIDs.UserRoleMembersStaticControl);
                }
                return this.cachedUserRoleMembersStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 1/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGeneralDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, GeneralDialog.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 1/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGeneralDialogControls.GeneralStaticControl2
        {
            get
            {
                if ((this.cachedGeneralStaticControl2 == null))
                {
                    this.cachedGeneralStaticControl2 = new StaticControl(this, GeneralDialog.ControlIDs.GeneralStaticControl2);
                }
                return this.cachedGeneralStaticControl2;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[ruhim] 1/25/2006 Created
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
        /// 	[ruhim] 1/25/2006 Created
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
        /// 	[ruhim] 1/25/2006 Created
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
        /// 	[ruhim] 1/25/2006 Created
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
        ///  <param name="app">App owning the dialog.</param>)
        /// <history>
        /// 	[ruhim] 20-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;             
            int index = Strings.DialogTitle.IndexOf("{0}");
            string newDialogTitle = Strings.DialogTitle.Remove(index);
            try
            {
                // Try to locate an existing instance of a dialog
                Utilities.LogMessage("substring :" + Strings.DialogTitle.Remove(index));
                //Removing the characters including and after {0} from dialog title
                //this is because the resource string translates to "Create User Role Wizard - {0} Profile"
                tempWindow = new Window(newDialogTitle, StringMatchSyntax.WildCard, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
            }

            catch (Exceptions.WindowNotFoundException ex)
            {
                tempWindow = null;
                int numberOfTries = 0;
                const int MaxTries = 30;
                while (tempWindow == null && numberOfTries < MaxTries)
                {
                    numberOfTries++;
                    try
                    {
                        // look for the window again using wildcards
                        tempWindow =
                            new Window(
                                Strings.DialogTitle.Remove(index) + "*",
                                StringMatchSyntax.WildCard);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        //sleep to wait for window search
                        Maui.Core.Utilities.Sleeper.Delay(1000);

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
                        newDialogTitle + "'");

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
        /// 	[ruhim] 1/25/2006 Created
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
                ";Create User Role Wizard - {0} Profile;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;UserRoleWizardCaption";
                //";Create User Role Wizard - {0} Profile;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.AdminResources;UserRoleWizardCaption";
            
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
            private const string ResourceCreate = ";C&reate;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagemen" +
                "t.Mom.Internal.UI.Console.Administration.AdminResources;CreateText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;DC01.bU;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  General
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneral = ";General;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.Administration.AdminResources;GeneralPropertyPageTabText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  GroupScope
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGroupScope = ";Group Scope;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManag" +
                "ement.Mom.Internal.UI.Console.Administration.AdminResources;UserRoleGro" +
                "upScopeTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Tasks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTasks = ";Tasks;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.M" +
                "om.Internal.UI.Tasks.TaskResources;DefaultItemTasksTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Views
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceViews = ";Views;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManageme" +
                "nt.Internal.UI.Authoring.ServiceDesignerEditor.DetailsPanel;labelSC" +
                "IViews.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Summary
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSummary = ";Summary;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagemen" +
                "t.Mom.Internal.UI.Console.Administration.AdminResources;UserRoleFinishT" +
                "itle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ProfileDescription
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceProfileDescription = ";Profile de&scription:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.Enter" +
                "priseManagement.Mom.Internal.UI.Console.Administration.UserRoleGeneral;labelProf" +
                "ileDescription.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Profile
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceProfile = ";&Profile:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagem" +
                "ent.Mom.Internal.UI.Console.Administration.UserRoleGeneral;labelProfileName.Text" +
                "";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Description
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDescription = ";D&escription;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseMana" +
                "gement.Mom.Internal.UI.Console.Administration.UserRoleGeneral;labelDescription.T" +
                "ext";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  UserRoleName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUserRoleName = ";&User role name:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.Enterprise" +
                "Management.Mom.Internal.UI.Console.Administration.UserRoleGeneral;labelName.Text" +
                "";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  UserRoleMembers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUserRoleMembers = ";User role &members:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.Enterpr" +
                "iseManagement.Mom.Internal.UI.Console.Administration.UserRoleGeneral;membersLabe" +
                "l.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mo" +
                "m.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  General2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneral2 = ";General;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.Administration.AdminResources;GeneralPropertyPageTabText";
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
            /// Caches the translated resource string for:  General
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneral;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  GroupScope
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGroupScope;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Tasks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTasks;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Views
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedViews;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Summary
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSummary;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ProfileDescription
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedProfileDescription;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Profile
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedProfile;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Description
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDescription;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  UserRoleName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUserRoleName;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  UserRoleMembers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUserRoleMembers;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  General2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneral2;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 1/25/2006 Created
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
            /// 	[ruhim] 1/25/2006 Created
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
            /// 	[ruhim] 1/25/2006 Created
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
            /// 	[ruhim] 1/25/2006 Created
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
            /// 	[ruhim] 1/25/2006 Created
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
            /// Exposes access to the General translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 1/25/2006 Created
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
            /// Exposes access to the GroupScope translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 1/25/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string GroupScope
            {
                get
                {
                    if ((cachedGroupScope == null))
                    {
                        cachedGroupScope = CoreManager.MomConsole.GetIntlStr(ResourceGroupScope);
                    }
                    return cachedGroupScope;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Tasks translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 1/25/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tasks
            {
                get
                {
                    if ((cachedTasks == null))
                    {
                        cachedTasks = CoreManager.MomConsole.GetIntlStr(ResourceTasks);
                    }
                    return cachedTasks;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Views translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 1/25/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Views
            {
                get
                {
                    if ((cachedViews == null))
                    {
                        cachedViews = CoreManager.MomConsole.GetIntlStr(ResourceViews);
                    }
                    return cachedViews;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Summary translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 1/25/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Summary
            {
                get
                {
                    if ((cachedSummary == null))
                    {
                        cachedSummary = CoreManager.MomConsole.GetIntlStr(ResourceSummary);
                    }
                    return cachedSummary;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ProfileDescription translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 1/25/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ProfileDescription
            {
                get
                {
                    if ((cachedProfileDescription == null))
                    {
                        cachedProfileDescription = CoreManager.MomConsole.GetIntlStr(ResourceProfileDescription);
                    }
                    return cachedProfileDescription;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Profile translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 1/25/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Profile
            {
                get
                {
                    if ((cachedProfile == null))
                    {
                        cachedProfile = CoreManager.MomConsole.GetIntlStr(ResourceProfile);
                    }
                    return cachedProfile;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Description translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 1/25/2006 Created
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
            /// Exposes access to the UserRoleName translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 1/25/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UserRoleName
            {
                get
                {
                    if ((cachedUserRoleName == null))
                    {
                        cachedUserRoleName = CoreManager.MomConsole.GetIntlStr(ResourceUserRoleName);
                    }
                    return cachedUserRoleName;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the UserRoleMembers translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 1/25/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UserRoleMembers
            {
                get
                {
                    if ((cachedUserRoleMembers == null))
                    {
                        cachedUserRoleMembers = CoreManager.MomConsole.GetIntlStr(ResourceUserRoleMembers);
                    }
                    return cachedUserRoleMembers;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 1/25/2006 Created
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
            /// Exposes access to the General2 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 1/25/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string General2
            {
                get
                {
                    if ((cachedGeneral2 == null))
                    {
                        cachedGeneral2 = CoreManager.MomConsole.GetIntlStr(ResourceGeneral2);
                    }
                    return cachedGeneral2;
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
        /// 	[ruhim] 1/25/2006 Created
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
            /// Control ID for GeneralStaticControl
            /// </summary>
            public const string GeneralStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for GroupScopeStaticControl
            /// </summary>
            public const string GroupScopeStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for TasksStaticControl
            /// </summary>
            public const string TasksStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ViewsStaticControl
            /// </summary>
            public const string ViewsStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for SummaryStaticControl
            /// </summary>
            public const string SummaryStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for UserRoleMembersToolbar
            /// </summary>
            public const string UserRoleMembersToolbar = "toolStripAddRemove";
            
            /// <summary>
            /// Control ID for ProfileDescriptionTextBox
            /// </summary>
            public const string ProfileDescriptionTextBox = "textBoxProfileDescription";
            
            /// <summary>
            /// Control ID for ProfileDescriptionStaticControl
            /// </summary>
            public const string ProfileDescriptionStaticControl = "labelProfileDescription";
            
            /// <summary>
            /// Control ID for ProfileTextBox
            /// </summary>
            public const string ProfileTextBox = "textBoxProfileName";
            
            /// <summary>
            /// Control ID for ProfileStaticControl
            /// </summary>
            public const string ProfileStaticControl = "labelProfileName";
            
            /// <summary>
            /// Control ID for DescriptionTextBox
            /// </summary>
            public const string DescriptionTextBox = "textBoxDescription";
            
            /// <summary>
            /// Control ID for DescriptionStaticControl
            /// </summary>
            public const string DescriptionStaticControl = "labelDescription";
            
            /// <summary>
            /// Control ID for NameTextBox
            /// </summary>
            public const string NameTextBox = "textBoxName";
            
            /// <summary>
            /// Control ID for UserRoleNameStaticControl
            /// </summary>
            public const string UserRoleNameStaticControl = "labelName";
            
            /// <summary>
            /// Control ID for UserRoleMembersListView
            /// </summary>
            public const string UserRoleMembersListView = "listViewUsers";
            
            /// <summary>
            /// Control ID for UserRoleMembersStaticControl
            /// </summary>
            public const string UserRoleMembersStaticControl = "membersLabel";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for GeneralStaticControl2
            /// </summary>
            public const string GeneralStaticControl2 = "headerLabel";
        }
        #endregion
    }
}
