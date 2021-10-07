// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SelectUsersOrGroups.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	MOMv3 UI Test Automation
// </summary>
// <history>
// 	[ruhim] 22-Jul-05 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.UserRole.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;  
    
    #region Interface Definition - ISelectUsersOrGroupsControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISelectUsersOrGroupsControls, for SelectUsersOrGroups.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 22-Jul-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISelectUsersOrGroupsControls
    {
        /// <summary>
        /// Read-only property to access SelectThisObjectTypeStaticControl
        /// </summary>
        StaticControl SelectThisObjectTypeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access UserRoleNameTextBox
        /// </summary>
        TextBox UserRoleNameTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ObjectTypesButton
        /// </summary>
        Button ObjectTypesButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FromThisLocationStaticControl
        /// </summary>
        StaticControl FromThisLocationStaticControl
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
        /// Read-only property to access LocationsButton
        /// </summary>
        Button LocationsButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TextBox5
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TextBox TextBox5
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CheckNamesButton
        /// </summary>
        Button CheckNamesButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AdvancedButton
        /// </summary>
        Button AdvancedButton
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
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add window functionality description here.
    /// </summary>
    /// <history>
    /// 	[ruhim] 22-Jul-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SelectUsersOrGroups : Window, ISelectUsersOrGroupsControls
    {
        #region Protected Internal Variables

        /// <summary>
        /// Cache to hold a reference to the active window of type Maui.Core.Window
        /// </summary>
        protected internal static Window activeWindow;
        #endregion
        
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to SelectThisObjectTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectThisObjectTypeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to UserRoleNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedUserRoleNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ObjectTypesButton of type Button
        /// </summary>
        private Button cachedObjectTypesButton;
        
        /// <summary>
        /// Cache to hold a reference to FromThisLocationStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedFromThisLocationStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DescriptionTextBox of type TextBox
        /// </summary>
        private TextBox cachedDescriptionTextBox;
        
        /// <summary>
        /// Cache to hold a reference to LocationsButton of type Button
        /// </summary>
        private Button cachedLocationsButton;
        
        /// <summary>
        /// Cache to hold a reference to TextBox5 of type TextBox
        /// </summary>
        private TextBox cachedTextBox5;
        
        /// <summary>
        /// Cache to hold a reference to CheckNamesButton of type Button
        /// </summary>
        private Button cachedCheckNamesButton;
        
        /// <summary>
        /// Cache to hold a reference to AdvancedButton of type Button
        /// </summary>
        private Button cachedAdvancedButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        #endregion

        //public static SelectUsersOrGroups SelectUsers1;
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This window does not have a parent window as it is a non modal
        /// window derived from the user role wizard's dialogue
        /// </summary>        
        /// <history>
        /// 	[ruhim] 22-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------        
        public SelectUsersOrGroups()
            : base(Init(false))
        {
            // TODO: Add Constructor logic here. 
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This window does not have a parent window as it is a non modal
        /// window derived from the user role wizard's dialogue
        /// </summary>        
        /// <history>
        /// 	[v-yoz] 20-Feb-09 Created
        /// </history>
        /// -----------------------------------------------------------------------------        
        public SelectUsersOrGroups(bool isUserOrGroup)
            : base(Init(isUserOrGroup))
        {
            // TODO: Add Constructor logic here. 
        }

        /// -----------------------------------------------------------------------------
        ///  <summary>
        ///  This function will attempt to find a showing instance of the windows.
        ///  </summary>
        ///  <returns>The Window's handle</returns>        
        ///  <history>
        /// 	[ruhim] 7/21/2005 Created
        ///  </history>
        /// -----------------------------------------------------------------------------
        private static System.IntPtr Init(bool isUserOrGroup)
        {
            //Check if window title is 'Select User Or Group' or 'Select Users Or Groups'
            string windowTitle = Strings.WindowTitles;
            if (isUserOrGroup == true)
            {
                windowTitle = Strings.WindowTitle;
            }
            
            // First check if the window is already up.
            Window tempWindow = null;
            try
            {
                tempWindow = new Window(windowTitle
                    + "*",
                    StringMatchSyntax.WildCard);
                // These additional parameters were generated by DialogMaker
                // , however; they are not necessary and often cause the
                // window constructor to fail.
                // , WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, ownerWindow, Timeout);
            }
            catch (Exceptions.WindowNotFoundException ex)
            {
                // locate the wizard dialog
                tempWindow = null;
                int numberOfTries = 0;
                const int MaxTries = 25;
                Core.Common.Utilities.LogMessage("Looking for window with title:  '"
                    + windowTitle + "'");
                //app.LogMessage("Looking for window with title:  '"
                //    + windowTitle + "'");
                while (tempWindow == null && numberOfTries < MaxTries)
                {
                    // log the attempt
                    numberOfTries++;

                    try
                    {
                        // look for the window again using wildcard matching
                        tempWindow = new Window(
                            windowTitle + "*",
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
                            + MaxTries
                            + "...");
                        //app.LogMessage("Attempt "
                        //    + numberOfTries
                        //    + " of "
                        //    + MaxTries
                        //    + "...");
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    throw new Window.Exceptions.WindowNotFoundException(
                        "Init function could not find or bring up the window"
                        + "with a title of '" + windowTitle
                        + "'.\n\n" + ex.Message);
                }
            }
            return tempWindow.Extended.HWnd;
        }


        //private static SelectUsersOrGroups Init(string caption, StringMatchSyntax match)
        //{
        //    // First check if the dialog is already up.
        //    //Window tempWindow = new Window(WindowType.Active);
        //    SelectUsersOrGroups tempWindow = (SelectUsersOrGroups)new Window(SelectUsersOrGroups.Strings.WindowTitle, StringMatchSyntax.ExactMatch);
        //    //Window tempWindow = new Window(WindowParameters.Equals(SelectUsersOrGroups.Strings.WindowTitle, StringMatchSyntax.ExactMatch));
        //    if (tempWindow != null)
        //    {
        //        return tempWindow;
        //    }
        //    else
        //    {
        //        throw new Window.Exceptions.WindowNotFoundException
        //            ("Init function could not find or bring up the dialog.");
        //    }
        //}

       
        #endregion
        
        #region ISelectUsersOrGroups Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the window's control properties together</value>
        /// <history>
        /// 	[ruhim] 22-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISelectUsersOrGroupsControls Controls
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
        ///  Routine to set/get the text in control UserRoleName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 22-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string UserRoleNameText
        {
            get
            {
                return this.Controls.UserRoleNameTextBox.Text;
            }
            
            set
            {
                this.Controls.UserRoleNameTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Description
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 22-Jul-05 Created
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
        ///  Routine to set/get the text in control TextBox5
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 22-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TextBox5Text
        {
            get
            {
                return this.Controls.TextBox5.Text;
            }
            
            set
            {
                this.Controls.TextBox5.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectThisObjectTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 22-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectUsersOrGroupsControls.SelectThisObjectTypeStaticControl
        {
            get
            {
                if ((this.cachedSelectThisObjectTypeStaticControl == null))
                {
                    this.cachedSelectThisObjectTypeStaticControl = new StaticControl(this, SelectUsersOrGroups.ControlIDs.SelectThisObjectTypeStaticControl);
                }
                return this.cachedSelectThisObjectTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UserRoleNameTextBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 22-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ISelectUsersOrGroupsControls.UserRoleNameTextBox
        {
            get
            {
                if ((this.cachedUserRoleNameTextBox == null))
                {
                    this.cachedUserRoleNameTextBox = new TextBox(this, SelectUsersOrGroups.ControlIDs.UserRoleNameTextBox);
                }
                return this.cachedUserRoleNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ObjectTypesButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 22-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectUsersOrGroupsControls.ObjectTypesButton
        {
            get
            {
                if ((this.cachedObjectTypesButton == null))
                {
                    this.cachedObjectTypesButton = new Button(this, SelectUsersOrGroups.ControlIDs.ObjectTypesButton);
                }
                return this.cachedObjectTypesButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FromThisLocationStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 22-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectUsersOrGroupsControls.FromThisLocationStaticControl
        {
            get
            {
                if ((this.cachedFromThisLocationStaticControl == null))
                {
                    this.cachedFromThisLocationStaticControl = new StaticControl(this, SelectUsersOrGroups.ControlIDs.FromThisLocationStaticControl);
                }
                return this.cachedFromThisLocationStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionTextBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 22-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ISelectUsersOrGroupsControls.DescriptionTextBox
        {
            get
            {
                if ((this.cachedDescriptionTextBox == null))
                {
                    this.cachedDescriptionTextBox = new TextBox(this, SelectUsersOrGroups.ControlIDs.DescriptionTextBox);
                }
                return this.cachedDescriptionTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LocationsButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 22-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectUsersOrGroupsControls.LocationsButton
        {
            get
            {
                if ((this.cachedLocationsButton == null))
                {
                    this.cachedLocationsButton = new Button(this, SelectUsersOrGroups.ControlIDs.LocationsButton);
                }
                return this.cachedLocationsButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TextBox5 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 22-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ISelectUsersOrGroupsControls.TextBox5
        {
            get
            {
                if ((this.cachedTextBox5 == null))
                {
                    this.cachedTextBox5 = new TextBox(this, SelectUsersOrGroups.ControlIDs.TextBox5);
                }
                return this.cachedTextBox5;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CheckNamesButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 22-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectUsersOrGroupsControls.CheckNamesButton
        {
            get
            {
                if ((this.cachedCheckNamesButton == null))
                {
                    this.cachedCheckNamesButton = new Button(this, SelectUsersOrGroups.ControlIDs.CheckNamesButton);
                }
                return this.cachedCheckNamesButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AdvancedButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 22-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectUsersOrGroupsControls.AdvancedButton
        {
            get
            {
                if ((this.cachedAdvancedButton == null))
                {
                    this.cachedAdvancedButton = new Button(this, SelectUsersOrGroups.ControlIDs.AdvancedButton);
                }
                return this.cachedAdvancedButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 22-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectUsersOrGroupsControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, SelectUsersOrGroups.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 22-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectUsersOrGroupsControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, SelectUsersOrGroups.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ObjectTypes
        /// </summary>
        /// <history>
        /// 	[ruhim] 22-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickObjectTypes()
        {
            this.Controls.ObjectTypesButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Locations
        /// </summary>
        /// <history>
        /// 	[ruhim] 22-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickLocations()
        {
            this.Controls.LocationsButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button CheckNames
        /// </summary>
        /// <history>
        /// 	[ruhim] 22-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCheckNames()
        {
            this.Controls.CheckNamesButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Advanced
        /// </summary>
        /// <history>
        /// 	[ruhim] 22-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAdvanced()
        {
            this.Controls.AdvancedButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[ruhim] 22-Jul-05 Created
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
        /// 	[ruhim] 22-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        #endregion
        
        ///// -----------------------------------------------------------------------------
        ///// <summary>
        ///// This function will attempt to find the window.
        ///// </summary>
        ///// <returns>A System.IntPtr representing a handle to the window.</returns>
        /////  <param name="ownerWindow">SelectUsersOrGroups class instance that owns this window.</param>)
        ///// <history>
        ///// 	[ruhim] 22-Jul-05 Created
        ///// </history>
        ///// -----------------------------------------------------------------------------
        //private static System.IntPtr Init(SelectUsersOrGroups ownerWindow)
        //{
        //    // First check if the window is already up.
        //    Window tempWindow = null;
        //    try
        //    {
        //        // Try to locate an existing instance of a window
        //        tempWindow = new Window(CoreManager.MomConsole.GetIntlStr(Strings.WindowTitle), StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, ownerWindow, Timeout);
        //    }
            
        //    catch (Exceptions.WindowNotFoundException ex)
        //    {
        //        // TODO:  Uncomment the following code and apply the appropriate command for invoking the window.
        //        // tempWindow = null;
        //        // int numberOfTries = 0;
        //        // const int MaxTries = 5;
        //        // while (tempWindow == null && numberOfTries < MaxTries)
        //        // {
        //        //     numberOfTries++;
        //        //     try
        //        //     {
        //        //         // look for the window again using wildcards
        //        //         tempWindow =
        //        //             new Window(
        //        //                 Strings.WindowTitle + "*",
        //        //                 StringMatchSyntax.WildCard);
        //        // 
        //        //         // wait for the window to report ready
        //        //         UISynchronization.WaitForUIObjectReady(
        //        //             tempWindow,
        //        //             Timeout);
        //        //     }
        //        //     catch (Exceptions.WindowNotFoundException)
        //        //     {
        //        //         // log the unsuccessful attempt
        //        //     }
        //        // }
        //        // 
        //        // // check for success
        //        // if (tempWindow == null)
        //        // {
        //        //     // log the failure
        //        // 
        //        //     // throw the existing WindowNotFound exception
        //        //     throw;
        //        // }
        //    }
        //    return tempWindow.Extended.HWnd;
        //}
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[ruhim] 22-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for User in the dialog title
            /// </summary>           
            /// -----------------------------------------------------------------------------
            private const string ResourceUser = ";User;Win32String;objsel.dll;138";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Group in the dialog title
            /// </summary>           
            /// -----------------------------------------------------------------------------
            private const string ResourceGroup = ";Group;Win32String;objsel.dll;142";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Users in the dialog title
            /// </summary>           
            /// -----------------------------------------------------------------------------
            private const string ResourceUsers = ";Users;Win32String;objsel.dll;139";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Service Accounts in the dialog title
            /// </summary>           
            /// -----------------------------------------------------------------------------
            private const string ServiceAccount = ";Service Account;Win32String;objsel.dll;146";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Service Accounts in the dialog title
            /// </summary>           
            /// -----------------------------------------------------------------------------
            private const string ServiceAccounts = ";Service Accounts;Win32String;objsel.dll;147";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Groups in the dialog title
            /// </summary>           
            /// -----------------------------------------------------------------------------
            private const string ResourceGroups = ";Groups;Win32String;objsel.dll;143";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>           
            /// -----------------------------------------------------------------------------
            private const string ResourceWindowTitle = ";Select %1, %2, or %3;Win32String;objsel.dll;602";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectThisObjectType
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectThisObjectType = "&Select this object type:";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ObjectTypes
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceObjectTypes = "&Object Types...";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  FromThisLocation
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceFromThisLocation = "&From this location:";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Locations
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceLocations = "&Locations...";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CheckNames
            /// </summary>            
            /// -----------------------------------------------------------------------------
            private const string ResourceCheckNames = ";&Check Names;Win32DialogItemString;objsel.dll;237;235";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Advanced
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdvanced = "&Advanced...";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>           
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;Win32DialogItemString;objsel.dll;316;1";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>            
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;Win32DialogItemString;objsel.dll;316;2";
            #endregion
            
            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWindowTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWindowTitles;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectThisObjectType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectThisObjectType;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ObjectTypes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedObjectTypes;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  FromThisLocation
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFromThisLocation;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Locations
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLocations;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CheckNames
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCheckNames;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Advanced
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdvanced;
            
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
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WindowTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[v-yoz] 20-Feb-09 Created                 
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WindowTitle
            {
                get
                {
                    if ((cachedWindowTitle == null))
                    {
                        cachedWindowTitle = CoreManager.MomConsole.GetIntlStr(ResourceWindowTitle);
                        cachedWindowTitle = cachedWindowTitle.Replace("%1", CoreManager.MomConsole.GetIntlStr(ResourceUser));
                        cachedWindowTitle = cachedWindowTitle.Replace("%2", CoreManager.MomConsole.GetIntlStr(ServiceAccount));
                        cachedWindowTitle = cachedWindowTitle.Replace("%3", CoreManager.MomConsole.GetIntlStr(ResourceGroup));
                    }
                    return cachedWindowTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WindowTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 22-Jul-05 Created
            ///     [ruhim] 13Feb06   Updated the dialog title to concatenate 3 diff resource strings  
            ///     [v-yoz] 20-Feb-09 Updated the WindowTitle to WindowTitles
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WindowTitles
            {
                get
                {
                    if ((cachedWindowTitles == null))
                    {
                        cachedWindowTitles = CoreManager.MomConsole.GetIntlStr(ResourceWindowTitle);
                        cachedWindowTitles = cachedWindowTitles.Replace("%1", CoreManager.MomConsole.GetIntlStr(ResourceUsers));
                        cachedWindowTitles = cachedWindowTitles.Replace("%2", CoreManager.MomConsole.GetIntlStr(ServiceAccounts));
                        cachedWindowTitles = cachedWindowTitles.Replace("%3", CoreManager.MomConsole.GetIntlStr(ResourceGroups));
                    }                    
                    return cachedWindowTitles;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectThisObjectType translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 22-Jul-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectThisObjectType
            {
                get
                {
                    if ((cachedSelectThisObjectType == null))
                    {
                        cachedSelectThisObjectType = CoreManager.MomConsole.GetIntlStr(ResourceSelectThisObjectType);
                    }
                    return cachedSelectThisObjectType;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ObjectTypes translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 22-Jul-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ObjectTypes
            {
                get
                {
                    if ((cachedObjectTypes == null))
                    {
                        cachedObjectTypes = CoreManager.MomConsole.GetIntlStr(ResourceObjectTypes);
                    }
                    return cachedObjectTypes;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the FromThisLocation translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 22-Jul-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FromThisLocation
            {
                get
                {
                    if ((cachedFromThisLocation == null))
                    {
                        cachedFromThisLocation = CoreManager.MomConsole.GetIntlStr(ResourceFromThisLocation);
                    }
                    return cachedFromThisLocation;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Locations translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 22-Jul-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Locations
            {
                get
                {
                    if ((cachedLocations == null))
                    {
                        cachedLocations = CoreManager.MomConsole.GetIntlStr(ResourceLocations);
                    }
                    return cachedLocations;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CheckNames translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 22-Jul-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CheckNames
            {
                get
                {
                    if ((cachedCheckNames == null))
                    {
                        cachedCheckNames = CoreManager.MomConsole.GetIntlStr(ResourceCheckNames);
                    }
                    return cachedCheckNames;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Advanced translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 22-Jul-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Advanced
            {
                get
                {
                    if ((cachedAdvanced == null))
                    {
                        cachedAdvanced = CoreManager.MomConsole.GetIntlStr(ResourceAdvanced);
                    }
                    return cachedAdvanced;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 22-Jul-05 Created
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
            /// 	[ruhim] 22-Jul-05 Created
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
            #endregion
        }
        #endregion
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[ruhim] 22-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for SelectThisObjectTypeStaticControl
            /// </summary>
            public const int SelectThisObjectTypeStaticControl = 323;
            
            /// <summary>
            /// Control ID for UserRoleNameTextBox
            /// </summary>
            public const int UserRoleNameTextBox = 231;
            
            /// <summary>
            /// Control ID for ObjectTypesButton
            /// </summary>
            public const int ObjectTypesButton = 230;
            
            /// <summary>
            /// Control ID for FromThisLocationStaticControl
            /// </summary>
            public const int FromThisLocationStaticControl = 324;
            
            /// <summary>
            /// Control ID for DescriptionTextBox
            /// </summary>
            public const int DescriptionTextBox = 233;
            
            /// <summary>
            /// Control ID for LocationsButton
            /// </summary>
            public const int LocationsButton = 232;
            
            /// <summary>
            /// Control ID for TextBox5
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const int TextBox5 = 214;
            
            /// <summary>
            /// Control ID for CheckNamesButton
            /// </summary>
            public const int CheckNamesButton = 235;
            
            /// <summary>
            /// Control ID for AdvancedButton
            /// </summary>
            public const int AdvancedButton = 236;
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const int OKButton = 1;
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const int CancelButton = 2;
        }
        #endregion
    }
}
