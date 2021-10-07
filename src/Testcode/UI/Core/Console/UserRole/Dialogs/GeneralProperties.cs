// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="GeneralProperties.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	MOMv3 UI Test Automation
// </summary>
// <history>
// 	[ruhim] 1/26/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.UserRole.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IGeneralPropertiesControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IGeneralPropertiesControls, for GeneralProperties.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 1/26/2006 Created
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
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add dialog functionality description here.
    /// </summary>
    /// <history>
    /// 	[ruhim] 1/26/2006 Created
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
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of GeneralProperties of type Maui.Core.App
        /// </param>
        /// <history>
        /// 	[ruhim] 1/26/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public GeneralProperties(ConsoleApp app)
            : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IGeneralProperties Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 1/26/2006 Created
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
        ///  Routine to set/get the text in control ProfileDescription
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 1/26/2006 Created
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
        /// 	[ruhim] 1/26/2006 Created
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
        /// 	[ruhim] 1/26/2006 Created
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
        /// 	[ruhim] 1/26/2006 Created
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
        ///  Exposes access to the ApplyButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 1/26/2006 Created
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
        /// 	[ruhim] 1/26/2006 Created
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
        /// 	[ruhim] 1/26/2006 Created
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
        /// 	[ruhim] 1/26/2006 Created
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
        ///  Exposes access to the UserRoleMembersToolbar control
        /// </summary>
        /// <history>
        /// 	[ruhim] 1/26/2006 Created
        /// 	[nathd] 24SEP2009 Maui 2.0: Calling the Toolbar constructor with a QID.
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IGeneralPropertiesControls.UserRoleMembersToolbar
        {
            get
            {
                if ((this.cachedUserRoleMembersToolbar == null))
                {
                    // [nathd] - Maui 2.0: Calling the Toolbar constructor with 'this' being the only parameter is returning 
                    // the wrong toolbar. For example, it is returning the "View Group Members" toolbar rather than the
                    // "AddRemoveToolbar". There is no caption/name defined for these toolbars therefore we cannot call the 
                    // constructor with the caption/name. Switching over to the UIA tree and using a QID with the AutomationId.
                    QID queryId = new QID(";[UIA]AutomationId=\'" + GeneralProperties.ControlIDs.UserRoleMembersToolbar + "\'");
                    this.cachedUserRoleMembersToolbar = new Toolbar(this, queryId, Common.Constants.DefaultContextMenuTimeout);
                }
                return this.cachedUserRoleMembersToolbar;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ProfileDescriptionTextBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 1/26/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IGeneralPropertiesControls.ProfileDescriptionTextBox
        {
            get
            {
                if ((this.cachedProfileDescriptionTextBox == null))
                {
                    this.cachedProfileDescriptionTextBox = new TextBox(this, GeneralProperties.ControlIDs.ProfileDescriptionTextBox);
                }
                return this.cachedProfileDescriptionTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ProfileDescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 1/26/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGeneralPropertiesControls.ProfileDescriptionStaticControl
        {
            get
            {
                if ((this.cachedProfileDescriptionStaticControl == null))
                {
                    this.cachedProfileDescriptionStaticControl = new StaticControl(this, GeneralProperties.ControlIDs.ProfileDescriptionStaticControl);
                }
                return this.cachedProfileDescriptionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ProfileTextBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 1/26/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IGeneralPropertiesControls.ProfileTextBox
        {
            get
            {
                if ((this.cachedProfileTextBox == null))
                {
                    this.cachedProfileTextBox = new TextBox(this, GeneralProperties.ControlIDs.ProfileTextBox);
                }
                return this.cachedProfileTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ProfileStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 1/26/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGeneralPropertiesControls.ProfileStaticControl
        {
            get
            {
                if ((this.cachedProfileStaticControl == null))
                {
                    this.cachedProfileStaticControl = new StaticControl(this, GeneralProperties.ControlIDs.ProfileStaticControl);
                }
                return this.cachedProfileStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionTextBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 1/26/2006 Created
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
        /// 	[ruhim] 1/26/2006 Created
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
        ///  Exposes access to the NameTextBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 1/26/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IGeneralPropertiesControls.NameTextBox
        {
            get
            {
                if ((this.cachedNameTextBox == null))
                {
                    this.cachedNameTextBox = new TextBox(this, GeneralProperties.ControlIDs.NameTextBox);
                }
                return this.cachedNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UserRoleNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 1/26/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGeneralPropertiesControls.UserRoleNameStaticControl
        {
            get
            {
                if ((this.cachedUserRoleNameStaticControl == null))
                {
                    this.cachedUserRoleNameStaticControl = new StaticControl(this, GeneralProperties.ControlIDs.UserRoleNameStaticControl);
                }
                return this.cachedUserRoleNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UserRoleMembersListView control
        /// </summary>
        /// <history>
        /// 	[ruhim] 1/26/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IGeneralPropertiesControls.UserRoleMembersListView
        {
            get
            {
                if ((this.cachedUserRoleMembersListView == null))
                {
                    this.cachedUserRoleMembersListView = new ListView(this, GeneralProperties.ControlIDs.UserRoleMembersListView);
                }
                return this.cachedUserRoleMembersListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UserRoleMembersStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 1/26/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGeneralPropertiesControls.UserRoleMembersStaticControl
        {
            get
            {
                if ((this.cachedUserRoleMembersStaticControl == null))
                {
                    this.cachedUserRoleMembersStaticControl = new StaticControl(this, GeneralProperties.ControlIDs.UserRoleMembersStaticControl);
                }
                return this.cachedUserRoleMembersStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Apply
        /// </summary>
        /// <history>
        /// 	[ruhim] 1/26/2006 Created
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
        /// 	[ruhim] 1/26/2006 Created
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
        /// 	[ruhim] 1/26/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">Maui.Core.App owning the dialog.</param>)
        /// <history>
        /// 	[ruhim] 1/26/2006 Created
        /// 	[nathd] 24SEP2009 Maui 2.0: I modified the call to the Window constructor to 
        /// 	                  include a wildcard at the beginning of the dialog title. 
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.            
            Window tempWindow = null;
            try
            {
                // [nathd] - Maui 2.0: After upgrading to Maui 2.0 automation
                // was no longer able to get the General Properties dialog by
                // title. I modified the call to the Window constructor to 
                // include a wildcard at the beginning of the dialog title. 
                // Possible titles for this dialog are such that a wildcard 
                // needs to be prepended and appended to the dialog title. 
                tempWindow = new Window("*" + Strings.DialogTitle + "*",
                    StringMatchSyntax.WildCard);
            }
            catch (Exceptions.WindowNotFoundException ex)
            {
                // locate the dialog
                tempWindow = null;
                int numberOfTries = 0;
                const int MAXTRIES = 10;
                Core.Common.Utilities.LogMessage("Looking for window with title:  '"
                    + Strings.DialogTitle + "'");

                while (tempWindow == null && numberOfTries < MAXTRIES)
                {
                    // log the attempt
                    numberOfTries++;

                    try
                    {
                        // [nathd] - Maui 2.0: After upgrading to Maui 2.0 automation
                        // was no longer able to get the General Properties dialog by
                        // title. I modified the call to the Window constructor to 
                        // include a wildcard at the beginning of the dialog title. 
                        // Possible titles for this dialog are such that a wildcard 
                        // needs to be prepended and appended to the dialog title. 
                        tempWindow = new Window("*" + Strings.DialogTitle + "*",
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
        /// 	[ruhim] 1/26/2006 Created
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
                "; - User Role Properties;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;UserRolePropertiesTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Apply
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceApply = ";&Apply;ManagedString;DundasWinChart.dll;DC01.bR;buttonApply.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;DC01.bU;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;DC01.bU;buttonOk.Text";
            
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
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 1/26/2006 Created
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
            /// 	[ruhim] 1/26/2006 Created
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
            /// 	[ruhim] 1/26/2006 Created
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
            /// 	[ruhim] 1/26/2006 Created
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
            /// 	[ruhim] 1/26/2006 Created
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
            /// Exposes access to the ProfileDescription translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 1/26/2006 Created
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
            /// 	[ruhim] 1/26/2006 Created
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
            /// 	[ruhim] 1/26/2006 Created
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
            /// 	[ruhim] 1/26/2006 Created
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
            /// 	[ruhim] 1/26/2006 Created
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
            #endregion
        }
        #endregion
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[ruhim] 1/26/2006 Created
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
            /// Control ID for Tab0TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab0TabControl = "tabPages";
            
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
        }
        #endregion
    }
}
