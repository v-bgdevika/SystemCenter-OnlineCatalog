// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AssociationsProperties.cs">
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

namespace Mom.Test.UI.Core.Console.RunAsProfile
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    
    #region Interface Definition - IAssociationsPropertiesControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAssociationsPropertiesControls, for AssociationsProperties.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[sharatja] 8/7/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAssociationsPropertiesControls
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
        /// Read-only property to access CreateButton
        /// </summary>
        Button CreateButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access Tab1TabControl
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TabControl Tab1TabControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectManagedObjectToSeeDetailsStaticControl
        /// </summary>
        StaticControl SelectManagedObjectToSeeDetailsStaticControl
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
        /// Read-only property to access CreateRunAsAccountStaticControl
        /// </summary>
        StaticControl CreateRunAsAccountStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectedTargetsPropertyGridView
        /// </summary>
        PropertyGridView SelectedTargetsPropertyGridView
        {
            get;
        }

        /// <summary>
        /// Read-only property to access RunAsAccountsListView
        /// </summary>
        ListView RunAsAccountsListView
        {
            get;
        }

        /// <summary>
        /// Read-only property to access SelectedTargetsStaticControl
        /// </summary>
        StaticControl SelectedTargetsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ToolStrip1
        /// </summary>
        Toolbar ToolStrip1
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HeaderStaticControl
        /// </summary>
        StaticControl HeaderStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AssociationsStaticControl
        /// </summary>
        StaticControl AssociationsStaticControl
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
    /// 	[sharatja]  8/7/2008 Created
    /// 	[nathd]     29JAN09  Modified for RunAs Improvement 131241.
    /// </history>
    /// -----------------------------------------------------------------------------
    public class AssociationsProperties : Window, IAssociationsPropertiesControls
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
        /// Cache to hold a reference to CreateButton of type Button
        /// </summary>
        private Button cachedCreateButton;

        /// <summary>
        /// Cache to hold a reference to Tab1TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab1TabControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectManagedObjectToSeeDetailsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectManagedObjectToSeeDetailsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DescriptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDescriptionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CreateRunAsAccountStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCreateRunAsAccountStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectedTargetsPropertyGridView of type PropertyGridView
        /// </summary>
        private PropertyGridView cachedSelectedTargetsPropertyGridView;
        
        /// <summary>
        /// Cache to hold a reference to SelectedTargetsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectedTargetsStaticControl;

        /// <summary>
        /// Cache to hold a reference to RunAsAccountsListView of type ListView
        /// </summary>
        private ListView cachedRunAsAccountsListView;

        /// <summary>
        /// Cache to hold a reference to ToolStrip1 of type Toolbar
        /// </summary>
        private Toolbar cachedToolStrip1;
        
        /// <summary>
        /// Cache to hold a reference to HeaderStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHeaderStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AssociationsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAssociationsStaticControl;
        #endregion

        /// <summary>
        /// Index of the 'Associations' column in the RunAs Accounts List 
        /// </summary>
        public static int INDEX_COLUMN_ASSOCIATION = 0;

        /// <summary>
        /// Index of the 'Used For' column in the RunAs Accounts List 
        /// </summary>
        public static int INDEX_COLUMN_USEDFOR = 1;

        /// <summary>
        /// Index of the 'Path' column in the RunAs Accounts List 
        /// </summary>
        public static int INDEX_COLUMN_PATH = 2;

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name="ownerWindow">Owner Window</param>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// 	[nathd]    29JAN09  Modified for RunAs Improvement #131241 (RC milestone)
        /// </history>
        /// -----------------------------------------------------------------------------
        public AssociationsProperties(MomConsoleApp ownerWindow) :
            base(Init(ownerWindow))
        {
            //this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout); 
        }
        #endregion
        
        #region IAssociationsProperties Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAssociationsPropertiesControls Controls
        {
            get
            {
                return this;
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
        Button IAssociationsPropertiesControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, AssociationsProperties.ControlIDs.ApplyButton);
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
        Button IAssociationsPropertiesControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AssociationsProperties.ControlIDs.CancelButton);
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
        Button IAssociationsPropertiesControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, AssociationsProperties.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[nathd] 29JAN09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAssociationsPropertiesControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, AssociationsProperties.ControlIDs.CreateButton);
                }
                return this.cachedCreateButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab1TabControl control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IAssociationsPropertiesControls.Tab1TabControl
        {
            get
            {
                if ((this.cachedTab1TabControl == null))
                {
                    this.cachedTab1TabControl = new TabControl(this, AssociationsProperties.ControlIDs.Tab1TabControl);
                }
                return this.cachedTab1TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectManagedObjectToSeeDetailsStaticControl control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAssociationsPropertiesControls.SelectManagedObjectToSeeDetailsStaticControl
        {
            get
            {
                if ((this.cachedSelectManagedObjectToSeeDetailsStaticControl == null))
                {
                    this.cachedSelectManagedObjectToSeeDetailsStaticControl = new StaticControl(this, AssociationsProperties.ControlIDs.SelectManagedObjectToSeeDetailsStaticControl);
                }
                return this.cachedSelectManagedObjectToSeeDetailsStaticControl;
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
        StaticControl IAssociationsPropertiesControls.DescriptionStaticControl
        {
            get
            {
                if ((this.cachedDescriptionStaticControl == null))
                {
                    this.cachedDescriptionStaticControl = new StaticControl(this, AssociationsProperties.ControlIDs.DescriptionStaticControl);
                }
                return this.cachedDescriptionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateRunAsAccountStaticControl control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAssociationsPropertiesControls.CreateRunAsAccountStaticControl
        {
            get
            {
                if ((this.cachedCreateRunAsAccountStaticControl == null))
                {
                    this.cachedCreateRunAsAccountStaticControl = new StaticControl(this, AssociationsProperties.ControlIDs.CreateRunAsAccountStaticControl);
                }
                return this.cachedCreateRunAsAccountStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectedTargetsPropertyGridView control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        PropertyGridView IAssociationsPropertiesControls.SelectedTargetsPropertyGridView
        {
            get
            {
                if ((this.cachedSelectedTargetsPropertyGridView == null))
                {
                    this.cachedSelectedTargetsPropertyGridView = new PropertyGridView(this, AssociationsProperties.ControlIDs.SelectedTargetsPropertyGridView);
                }
                return this.cachedSelectedTargetsPropertyGridView;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RunAsAccountsListView control
        /// </summary>
        /// <history>
        /// 	[nathd] 01/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IAssociationsPropertiesControls.RunAsAccountsListView
        {
            get
            {
                if ((this.cachedRunAsAccountsListView == null))
                {
                    this.cachedRunAsAccountsListView = new ListView(this, new QID(";[UIA]AutomationId ='" + AssociationsProperties.ControlIDs.RunAsAccountsListView + "'"));
                }

                return this.cachedRunAsAccountsListView;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectedTargetsStaticControl control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAssociationsPropertiesControls.SelectedTargetsStaticControl
        {
            get
            {
                if ((this.cachedSelectedTargetsStaticControl == null))
                {
                    this.cachedSelectedTargetsStaticControl = new StaticControl(this, AssociationsProperties.ControlIDs.SelectedTargetsStaticControl);
                }
                return this.cachedSelectedTargetsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToolStrip1 control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IAssociationsPropertiesControls.ToolStrip1
        {
            get
            {
                if ((this.cachedToolStrip1 == null))
                {
                    this.cachedToolStrip1 = new Toolbar(this);//, AssociationsProperties.ControlIDs.ToolStrip1);
                }
                return this.cachedToolStrip1;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HeaderStaticControl control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAssociationsPropertiesControls.HeaderStaticControl
        {
            get
            {
                if ((this.cachedHeaderStaticControl == null))
                {
                    this.cachedHeaderStaticControl = new StaticControl(this, AssociationsProperties.ControlIDs.HeaderStaticControl);
                }
                return this.cachedHeaderStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AssociationsStaticControl control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAssociationsPropertiesControls.AssociationsStaticControl
        {
            get
            {
                if ((this.cachedAssociationsStaticControl == null))
                {
                    this.cachedAssociationsStaticControl = new StaticControl(this, AssociationsProperties.ControlIDs.AssociationsStaticControl);
                }
                return this.cachedAssociationsStaticControl;
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
        ///  Routine to click on button Create
        /// </summary>
        /// <history>
        /// 	[nathd] 29JAN09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCreate()
        {
            this.Controls.CreateButton.Click();
        }
        #endregion

        /// <summary>
        /// Click the Toolbar item: Add/Edit/Remove
        /// </summary>
        /// <throws>
        /// Maui.Core.WinControls.Control.Exceptions.UnknownWinControlException
        /// </throws>
        public void ClickToolbarItem(string itemText)
        {
            bool toolbarItemFound = false;

            Utilities.LogMessage("RunAsProfile.AssociationProperties.ClickToolbarItem :: ");

            foreach (ToolbarItem item in this.Controls.ToolStrip1.get_ToolbarItems(false))
            {
                Utilities.LogMessage("ClickToolbarItem :: Toolbar item '" + item.Text + "' found [Enabled = " + item.Enabled.ToString() + "]");

                if (item.Text.Equals(itemText) && item.Enabled)
                {
                    item.Click();
                    toolbarItemFound = true;
                }
            }

            if (toolbarItemFound == false)
            {
                throw new Maui.Core.WinControls.Control.Exceptions.UnknownWinControlException("'" + itemText + "' ToolStrip option not found or not enabled.");
            }
        }

        /// <summary>
        /// Finds the RunAs Account.
        /// </summary>
        /// <param name="accountName">RunAs account name</param>
        /// <param name="targetName">Target name</param>
        /// <param name="targetType">Target type</param>
        /// 
        /// <returns>DataGridRow if found, null if not</returns>
        public ListViewItem FindRunAsAccount(string accountName, string targetName, TargetType targetType)
        {
            int accountNameIndex = -1;
            int usedForIndex = -1;
            int typeIndex = -1;
            int pathIndex = -1;

            Utilities.LogMessage("RunAsProfile.AssociationProperties.FindRunAsAccount :: ");

            Utilities.LogMessage("Wait for ready to make sure Run As accounts loaded");
            CoreManager.MomConsole.Waiters.WaitForReady();

            if (this.Controls.RunAsAccountsListView.Items.Count == 0)
            {
                return null;
            }

            // Get indices
            foreach (HeaderItem header in this.Controls.RunAsAccountsListView.Columns)
            {
                if (header.Text.Equals(Strings.AccountName))
                {
                    accountNameIndex = header.Index;
                    Utilities.LogMessage("FindRunAsAccount :: '" + Strings.AccountName + "' column index = " + header.Index);
                }
                else if (header.Text.Equals(Strings.UsedFor))
                {
                    usedForIndex = header.Index;
                    Utilities.LogMessage("FindRunAsAccount :: '" + Strings.UsedFor + "' column index = " + header.Index);
                }
                else if (header.Text.Equals(Strings.Type))
                {
                    typeIndex = header.Index;
                    Utilities.LogMessage("FindRunAsAccount :: '" + Strings.Type + "' column index = " + header.Index);
                }
                else if (header.Text.Equals(Strings.Path))
                {
                    pathIndex = header.Index;
                    Utilities.LogMessage("FindRunAsAccount :: '" + Strings.Path + "' column index = " + header.Index);
                }
                else
                {
                    Utilities.LogMessage("FindRunAsAccount :: Unknown column header '" + header.Text + "' found.");
                }
            }

            string targetTypeString = string.Empty;

            // Get the correct resource for the target type: Class, Group or Object
            switch (targetType)
            {
                case TargetType.Class:
                    targetTypeString = RunAsProfile.Strings.ClassText;
                    break;

                case TargetType.Group:
                    targetTypeString = RunAsProfile.Strings.GroupText;
                    break;

                case TargetType.Object:
                    targetTypeString = RunAsProfile.Strings.ObjectText;
                    break;

                default:
                    throw new Maui.GlobalExceptions.InvalidEnumValueException(targetType.ToString());
            }

            foreach (ListViewItem item in this.Controls.RunAsAccountsListView.Items)
            {
                Utilities.LogMessage("FindRunAsAccount :: Comparing '" +
                    item.Text + "' to '" + accountName + "'");
                Utilities.LogMessage("FindRunAsAccount :: Comparing '" +
                    item[INDEX_COLUMN_USEDFOR].Text + "' to '" + targetName + "'");
                Utilities.LogMessage("FindRunAsAccount :: Comparing '" +
                    item[INDEX_COLUMN_ASSOCIATION].Text + "' to '" + targetTypeString + "'");

                if (item.Text == accountName &&
                    item[INDEX_COLUMN_USEDFOR].Text == targetName &&
                    item[INDEX_COLUMN_ASSOCIATION].Text == targetTypeString)
                {
                    Utilities.LogMessage("FindRunAsAccount :: Match Found - '" + accountName + "'");
                    return item;
                }
            }

            return null;
        }

        /// <summary>
        /// Selects the RunAs Account.
        /// </summary>
        /// <param name="accountName">RunAs account name</param>
        /// <param name="targetName">Target name</param>
        /// <param name="targetType">Target type</param>
        public void SelectRunAsAccount(string accountName, string targetName, TargetType targetType)
        {
            Utilities.LogMessage("RunAsProfile.AssociationProperties.SelectRunAsAccount :: ");
            ListViewItem item = this.FindRunAsAccount(accountName, targetName, targetType);

            if (item != null)
            {
                item.Select();
            }
        }

        /// <summary>
        /// Selects all the RunAs Accounts.
        /// </summary>
        public void SelectAllRunAsAccounts()
        {
            Utilities.LogMessage("RunAsProfile.AssociationProperties.SelectAllRunAsAccounts :: ");

            if (this.Controls.RunAsAccountsListView.Count.Equals(0))
            {
                Utilities.LogMessage("RunAsProfile.AssociationProperties.SelectAllRunAsAccounts :: RunAsAccountsListView.Count = " + 
                    this.Controls.RunAsAccountsListView.Count);
                return;
            }

            this.Controls.RunAsAccountsListView.SelectAll();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="ownerWindow">Owner of the Window</param>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// 	[nathd]    29JAN09  Modified for the RunAs Improvement #131241 (RC milestone).
        /// </history>
        /// -----------------------------------------------------------------------------
        private static System.IntPtr Init(MomConsoleApp ownerWindow)
        {
            // First check if the window is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a window
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.WildCard, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, ownerWindow, Timeout);
            }
            catch (Exceptions.WindowNotFoundException windowNotFound)
            {
                // Reset the window reference
                tempWindow = null;

                // Maximum number of tries to find window
                int maxTries = 5;

                // Try several more times to find the window
                for (int numberOfTries = 0; ((null == tempWindow) && (numberOfTries < maxTries)); numberOfTries = (numberOfTries + 1))
                {
                    try
                    {
                        // Try to locate an existing instance of the window
                        tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.WildCard);

                        // Wait for the window to become ready
                        UISynchronization.WaitForUIObjectReady(tempWindow, Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
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

            return tempWindow.Extended.HWnd;
        }
        /*private static Window Init(ConsoleApp app)
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
        */

        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        ///     [a-joelj]   13DEC08 Added correct resource string for hardcoded ResourceDialogTitle
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
            /// Contains resource string for:  Tab1
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTab1 = "Tab1";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectManagedObjectToSeeDetails
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectManagedObjectToSeeDetails = ";Select managed object to see details.;ManagedString;Microsoft.EnterpriseManageme" +
                "nt.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administ" +
                "ration.RunAsProfile.RunAsProfileAssociationsPage;label4.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Description
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDescription = ";Description:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAsProfile.RunAs" +
                "ProfileAssociationsPage;label3.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CreateRunAsAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCreateRunAsAccount = ";Create Run As account...;ManagedString;Microsoft.EnterpriseManagement.UI.Adminis" +
                "tration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAsP" +
                "rofile.RunAsProfileAssociationsPage;createAccountLink.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectedComputers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectedComputers = ";Selected computers:;ManagedString;Microsoft.EnterpriseManagement.UI.Administrati" +
                "on.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAsProfil" +
                "e.RunAsProfileAssociationsPage;label2.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ToolStrip1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceToolStrip1 = ";toolStrip1;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Mi" +
                "crosoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.Comman" +
                "dNotification;toolStrip.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  HeaderStaticControl
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceThisRunAsProfileManagesTheObjectsDisplayedBelowTheAssociatedRunAsAccountProvidesCredentialsNecessary = @";This Run As Profile manages the objects displayed below.  The associated Run As Account provides credentials necessary to execute management workfows.;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAsProfile.RunAsProfileAssociationsPage;label1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Associations
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAssociations = ";Associations;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAsProfile.RunAs" +
                "ProfileAssociationsPage;$this.TabName";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: RunAs Account ListView: 'Account Name' column text
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAccountName = ";Account Name;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAsProfile.RunAsProfileAssociationsPage;columnHeader1.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: RunAs Account ListView: 'Used For' column text
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUsedFor = ";Used For;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAsProfile.RunAsProfileAssociationsPage;columnHeader2.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: RunAs Account ListView: 'Type' column text
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceType = ";Type;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAsProfile.RunAsProfileAssociationsPage;columnHeader3.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: RunAs Account ListView: 'Path' column text
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePath = ";Path;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAsProfile.RunAsProfileAssociationsPage;columnHeader4.Text";
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
            /// Caches the translated resource string for:  Tab1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab1;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectManagedObjectToSeeDetails
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectManagedObjectToSeeDetails;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Description
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDescription;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CreateRunAsAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCreateRunAsAccount;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectedComputers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectedComputers;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ToolStrip1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedToolStrip1;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  HeaderStaticControl
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedThisRunAsProfileManagesTheObjectsDisplayedBelowTheAssociatedRunAsAccountProvidesCredentialsNecessary;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Associations
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAssociations;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: RunAs Account ListView: 'Account Name' column text
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAccountName;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: RunAs Account ListView: 'Used For' column text
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUsedFor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: RunAs Account ListView: 'Type' column text
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedType;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: RunAs Account ListView: 'Path' column text
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPath;
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
            /// Exposes access to the Tab1 translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tab1
            {
                get
                {
                    if ((cachedTab1 == null))
                    {
                        cachedTab1 = CoreManager.MomConsole.GetIntlStr(ResourceTab1);
                    }
                    return cachedTab1;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectManagedObjectToSeeDetails translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectManagedObjectToSeeDetails
            {
                get
                {
                    if ((cachedSelectManagedObjectToSeeDetails == null))
                    {
                        cachedSelectManagedObjectToSeeDetails = CoreManager.MomConsole.GetIntlStr(ResourceSelectManagedObjectToSeeDetails);
                    }
                    return cachedSelectManagedObjectToSeeDetails;
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
            /// Exposes access to the CreateRunAsAccount translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CreateRunAsAccount
            {
                get
                {
                    if ((cachedCreateRunAsAccount == null))
                    {
                        cachedCreateRunAsAccount = CoreManager.MomConsole.GetIntlStr(ResourceCreateRunAsAccount);
                    }
                    return cachedCreateRunAsAccount;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectedComputers translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectedComputers
            {
                get
                {
                    if ((cachedSelectedComputers == null))
                    {
                        cachedSelectedComputers = CoreManager.MomConsole.GetIntlStr(ResourceSelectedComputers);
                    }
                    return cachedSelectedComputers;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ToolStrip1 translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ToolStrip1
            {
                get
                {
                    if ((cachedToolStrip1 == null))
                    {
                        cachedToolStrip1 = CoreManager.MomConsole.GetIntlStr(ResourceToolStrip1);
                    }
                    return cachedToolStrip1;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the HeaderStaticControl translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ThisRunAsProfileManagesTheObjectsDisplayedBelowTheAssociatedRunAsAccountProvidesCredentialsNecessary
            {
                get
                {
                    if ((cachedThisRunAsProfileManagesTheObjectsDisplayedBelowTheAssociatedRunAsAccountProvidesCredentialsNecessary == null))
                    {
                        cachedThisRunAsProfileManagesTheObjectsDisplayedBelowTheAssociatedRunAsAccountProvidesCredentialsNecessary = CoreManager.MomConsole.GetIntlStr(ResourceThisRunAsProfileManagesTheObjectsDisplayedBelowTheAssociatedRunAsAccountProvidesCredentialsNecessary);
                    }
                    return cachedThisRunAsProfileManagesTheObjectsDisplayedBelowTheAssociatedRunAsAccountProvidesCredentialsNecessary;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Associations translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Associations
            {
                get
                {
                    if ((cachedAssociations == null))
                    {
                        cachedAssociations = CoreManager.MomConsole.GetIntlStr(ResourceAssociations);
                    }
                    return cachedAssociations;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Account Name translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 29JAN09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AccountName
            {
                get
                {
                    if ((cachedAccountName == null))
                    {
                        cachedAccountName = CoreManager.MomConsole.GetIntlStr(ResourceAccountName);
                    }
                    return cachedAccountName;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Used For translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 29JAN09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UsedFor
            {
                get
                {
                    if ((cachedUsedFor == null))
                    {
                        cachedUsedFor = CoreManager.MomConsole.GetIntlStr(ResourceUsedFor);
                    }
                    return cachedUsedFor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Type translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 29JAN09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Type
            {
                get
                {
                    if ((cachedType == null))
                    {
                        cachedType = CoreManager.MomConsole.GetIntlStr(ResourceType);
                    }
                    return cachedType;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Path translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 29JAN09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Path
            {
                get
                {
                    if ((cachedPath == null))
                    {
                        cachedPath = CoreManager.MomConsole.GetIntlStr(ResourcePath);
                    }
                    return cachedPath;
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
            /// Control ID for CreateButton
            /// </summary>
            public const string CreateButton = "commitButton";

            /// <summary>
            /// Control ID for Tab1TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab1TabControl = "tabPages";
            
            /// <summary>
            /// Control ID for SelectManagedObjectToSeeDetailsStaticControl
            /// </summary>
            public const string SelectManagedObjectToSeeDetailsStaticControl = "label4";
            
            /// <summary>
            /// Control ID for DescriptionStaticControl
            /// </summary>
            public const string DescriptionStaticControl = "label3";
            
            /// <summary>
            /// Control ID for CreateRunAsAccountStaticControl
            /// </summary>
            public const string CreateRunAsAccountStaticControl = "createAccountLink";
            
            /// <summary>
            /// Control ID for SelectedTargetsPropertyGridView
            /// </summary>
            public const string SelectedTargetsPropertyGridView = "mainGrid";

            /// <summary>
            /// Control ID for RunAsAccountsListView
            /// </summary>
            public const string RunAsAccountsListView = "overridesList";

            /// <summary>
            /// Control ID for SelectedTargetsStaticControl
            /// </summary>
            public const string SelectedTargetsStaticControl = "label2";
            
            /// <summary>
            /// Control ID for ToolStrip1
            /// </summary>
            public const string ToolStrip1 = "addRemoveStrip";
            
            /// <summary>
            /// Control ID for HeaderStaticControl
            /// </summary>
            public const string HeaderStaticControl = "label1";
            
            /// <summary>
            /// Control ID for AssociationsStaticControl
            /// </summary>
            public const string AssociationsStaticControl = "labelTitle";
        }
        #endregion
    }
}
