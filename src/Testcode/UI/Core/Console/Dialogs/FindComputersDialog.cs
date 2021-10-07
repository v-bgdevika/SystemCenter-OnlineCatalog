// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="FindComputersDialog.cs">
//  Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
//  MOMv3 UI Test Automation
// </project>
// <summary>
//  MOMv3 UI Test Automation
// </summary>
// <history>
//  [KellyMor] 08-Aug-05 Created
//  [KellyMor] 13-Feb-06 Updated DialogTitle to concatenate the title string properly
//  [KellyMor] 20-Nov-06 Fixed issue in Init where loop didn't delay properly
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IFindComputersDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IFindComputersDialogControls, for FindComputersDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 08-Aug-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IFindComputersDialogControls
    {
        /// <summary>
        /// Read-only property to access ComputerNameStaticControl
        /// </summary>
        StaticControl ComputerNameStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ComputerNameTextBox
        /// </summary>
        TextBox ComputerNameTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access OwnerStaticControl
        /// </summary>
        StaticControl OwnerStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access OwnerTextBox
        /// </summary>
        TextBox OwnerTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RoleStaticControl
        /// </summary>
        StaticControl RoleStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RoleComboBox
        /// </summary>
        ComboBox RoleComboBox
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
        /// Read-only property to access Tab0TabControl
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TabControl Tab0TabControl
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the LDAP query builder, "Find Computers" dialog.
    /// This class manages the basic functions for simple LDAP queries.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 08-Aug-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class FindComputersDialog : Dialog, IFindComputersDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ComputerNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedComputerNameStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ComputerNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedComputerNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to OwnerStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedOwnerStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to OwnerTextBox of type TextBox
        /// </summary>
        private TextBox cachedOwnerTextBox;
        
        /// <summary>
        /// Cache to hold a reference to RoleStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRoleStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to RoleComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedRoleComboBox;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to Tab0TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab0TabControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of FindComputersDialog of type Maui.Core.App
        /// </param>
        /// <history>
        /// 	[KellyMor] 08-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public FindComputersDialog(Maui.Core.App app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IFindComputersDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[KellyMor] 08-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IFindComputersDialogControls Controls
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
        ///  Routine to set/get the text in control ComputerName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 08-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ComputerNameText
        {
            get
            {
                return this.Controls.ComputerNameTextBox.Text;
            }
            
            set
            {
                this.Controls.ComputerNameTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Owner
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 08-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string OwnerText
        {
            get
            {
                return this.Controls.OwnerTextBox.Text;
            }
            
            set
            {
                this.Controls.OwnerTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Role
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 08-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string RoleText
        {
            get
            {
                return this.Controls.RoleComboBox.Text;
            }
            
            set
            {
                this.Controls.RoleComboBox.SelectByText(value, true);
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ComputerNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 08-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IFindComputersDialogControls.ComputerNameStaticControl
        {
            get
            {
                if ((this.cachedComputerNameStaticControl == null))
                {
                    this.cachedComputerNameStaticControl = new StaticControl(this, FindComputersDialog.ControlIDs.ComputerNameStaticControl);
                }
                return this.cachedComputerNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ComputerNameTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 08-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IFindComputersDialogControls.ComputerNameTextBox
        {
            get
            {
                if ((this.cachedComputerNameTextBox == null))
                {
                    this.cachedComputerNameTextBox = new TextBox(this, FindComputersDialog.ControlIDs.ComputerNameTextBox);
                }
                return this.cachedComputerNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OwnerStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 08-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IFindComputersDialogControls.OwnerStaticControl
        {
            get
            {
                // The ID for this control (-1) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedOwnerStaticControl == null))
                {
                    Window wndTemp = this;

                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    this.cachedOwnerStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedOwnerStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OwnerTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 08-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IFindComputersDialogControls.OwnerTextBox
        {
            get
            {
                if ((this.cachedOwnerTextBox == null))
                {
                    this.cachedOwnerTextBox = new TextBox(this, FindComputersDialog.ControlIDs.OwnerTextBox);
                }
                return this.cachedOwnerTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RoleStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 08-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IFindComputersDialogControls.RoleStaticControl
        {
            get
            {
                // The ID for this control (-1) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedRoleStaticControl == null))
                {
                    Window wndTemp = this;

                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 3); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    this.cachedRoleStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedRoleStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RoleComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 08-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IFindComputersDialogControls.RoleComboBox
        {
            get
            {
                if ((this.cachedRoleComboBox == null))
                {
                    this.cachedRoleComboBox = new ComboBox(this, FindComputersDialog.ControlIDs.RoleComboBox);
                }
                return this.cachedRoleComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 08-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IFindComputersDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, FindComputersDialog.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 08-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IFindComputersDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, FindComputersDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab0TabControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 08-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IFindComputersDialogControls.Tab0TabControl
        {
            get
            {
                if ((this.cachedTab0TabControl == null))
                {
                    this.cachedTab0TabControl = new TabControl(this, FindComputersDialog.ControlIDs.Tab0TabControl);
                }
                return this.cachedTab0TabControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[KellyMor] 08-Aug-05 Created
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
        /// 	[KellyMor] 08-Aug-05 Created
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
        /// <param name="app">Maui.Core.App owning the dialog.</param>
        /// <history>
        /// 	[KellyMor] 08-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(Maui.Core.App app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
            }
            catch (Exceptions.WindowNotFoundException ex)
            {
                tempWindow = null;
                int numberOfTries = 0;
                const int MaxTries = 5;
                while (tempWindow == null && numberOfTries < MaxTries)
                {
                    numberOfTries++;
                    try
                    {
                        // look for the window again using wildcards
                        tempWindow =
                            new Window(
                                app.GetIntlStr(Strings.DialogTitle) + "*",
                                StringMatchSyntax.WildCard,
                                WindowClassNames.Dialog,
                                StringMatchSyntax.ExactMatch,
                                app,
                                Timeout);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        Core.Common.Utilities.LogMessage(
                            "Attempt " + numberOfTries + " of " + MaxTries);

                        Sleeper.Delay(Timeout);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find window with title:  '" +
                        Strings.DialogTitle + "'");

                    // throw the existing WindowNotFound exception
                    throw ex;
                }
            }
            return tempWindow;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Contains resource definitions.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 08-Aug-05 Created
        ///     [KellyMor] 13-Feb-06 Updated resources
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title prefix
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitlePrefix = ";Find %s;Win32String;dsquery.dll;3";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title suffix
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitleSuffix = ";Computers;Win32String;dsquery.dll;163";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ComputerName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceComputerName = "Computer n&ame:";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Owner
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOwner = "&Owner:";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Role
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRole = "&Role:";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;Win32DialogItemString;dsquery.dll;1013;1";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = "Cancel";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Tab0
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTab0 = "Tab0";
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
            /// Caches the translated resource string for:  ComputerName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedComputerName;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Owner
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOwner;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Role
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRole;
            
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
            /// Caches the translated resource string for:  Tab0
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab0;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 08-Aug-05 Created
            ///     [KellyMor] 13-Feb-06 Updated to concatenate the title string properly
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    if ((cachedDialogTitle == null))
                    {
                        // get the prefix
                        cachedDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceDialogTitlePrefix);

                        // search and replace %s with the suffix
                        cachedDialogTitle = 
                            cachedDialogTitle.Replace(
                                "%s", 
                                CoreManager.MomConsole.GetIntlStr(ResourceDialogTitleSuffix));
                    }
                    return cachedDialogTitle;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ComputerName translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 08-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ComputerName
            {
                get
                {
                    if ((cachedComputerName == null))
                    {
                        cachedComputerName = CoreManager.MomConsole.GetIntlStr(ResourceComputerName);
                    }
                    return cachedComputerName;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Owner translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 08-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Owner
            {
                get
                {
                    if ((cachedOwner == null))
                    {
                        cachedOwner = CoreManager.MomConsole.GetIntlStr(ResourceOwner);
                    }
                    return cachedOwner;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Role translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 08-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Role
            {
                get
                {
                    if ((cachedRole == null))
                    {
                        cachedRole = CoreManager.MomConsole.GetIntlStr(ResourceRole);
                    }
                    return cachedRole;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 08-Aug-05 Created
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
            /// 	[KellyMor] 08-Aug-05 Created
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
            /// Exposes access to the Tab0 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 08-Aug-05 Created
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
            #endregion
        }
        #endregion
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 08-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ComputerNameStaticControl
            /// </summary>
            public const int ComputerNameStaticControl = -1;
            
            /// <summary>
            /// Control ID for ComputerNameTextBox
            /// </summary>
            public const int ComputerNameTextBox = 1224;
            
            /// <summary>
            /// Control ID for OwnerStaticControl
            /// </summary>
            public const int OwnerStaticControl = -1;
            
            /// <summary>
            /// Control ID for OwnerTextBox
            /// </summary>
            public const int OwnerTextBox = 1220;
            
            /// <summary>
            /// Control ID for RoleStaticControl
            /// </summary>
            public const int RoleStaticControl = -1;
            
            /// <summary>
            /// Control ID for RoleComboBox
            /// </summary>
            public const int RoleComboBox = 1225;
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const int OKButton = 1;
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const int CancelButton = 2;
            
            /// <summary>
            /// Control ID for Tab0TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const int Tab0TabControl = 1024;
        }
        #endregion
    }
}
