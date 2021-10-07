// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="MemberSelectionDialog.cs">
//   Copyright (c) Microsoft Corporation 2010
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//   [asttest] 11/8/2010 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.ResourcePool
{
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    
    #region Interface Definition - IMemberSelectionDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IMemberSelectionDialogControls, for MemberSelectionDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [asttest] 11/8/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IMemberSelectionDialogControls
    {
        /// <summary>
        /// Gets read-only property to access AvailableItems
        /// </summary>
        DataGrid AvailableItems
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access SelectedItems
        /// </summary>
        DataGrid SelectedItems
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access AddButton
        /// </summary>
        Button AddButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access RemoveButton
        /// </summary>
        Button RemoveButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access CancelButton
        /// </summary>
        Button CancelButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access OKButton
        /// </summary>
        Button OKButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access SelectManagementServersOrGatewayServersForThisResourcePool
        /// </summary>
        TextBox SelectManagementServersOrGatewayServersForThisResourcePool
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access SearchButton
        /// </summary>
        Button SearchButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access CancelButton2
        /// </summary>
        Button CancelButton2
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
    ///   [asttest] 11/8/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class MemberSelectionDialog : Dialog, IMemberSelectionDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to AvailableItems of type DataGrid
        /// </summary>
        private DataGrid cachedAvailableItems;
        
        /// <summary>
        /// Cache to hold a reference to SelectedItems of type DataGrid
        /// </summary>
        private DataGrid cachedSelectedItems;
        
        /// <summary>
        /// Cache to hold a reference to AddButton of type Button
        /// </summary>
        private Button cachedAddButton;
        
        /// <summary>
        /// Cache to hold a reference to RemoveButton of type Button
        /// </summary>
        private Button cachedRemoveButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to SelectManagementServersOrGatewayServersForThisResourcePool of type TextBox
        /// </summary>
        private TextBox cachedSelectManagementServersOrGatewayServersForThisResourcePool;
        
        /// <summary>
        /// Cache to hold a reference to SearchButton of type Button
        /// </summary>
        private Button cachedSearchButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton2 of type Button
        /// </summary>
        private Button cachedCancelButton2;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the MemberSelectionDialog class.
        /// </summary>
        /// <param name='app'>
        /// Owner of MemberSelectionDialog of type App
        /// </param>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public MemberSelectionDialog(App app, bool created, string poolName = "") :
            base(app, Init(app, created, poolName))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IMemberSelectionDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IMemberSelectionDialogControls Controls
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
        ///  Gets or sets the text in control SelectManagementServersOrGatewayServersForThisResourcePool
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SelectManagementServersOrGatewayServersForThisResourcePoolText
        {
            get
            {
                return this.Controls.SelectManagementServersOrGatewayServersForThisResourcePool.Text;
            }
            
            set
            {
                this.Controls.SelectManagementServersOrGatewayServersForThisResourcePool.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the AvailableItems control
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        DataGrid IMemberSelectionDialogControls.AvailableItems
        {
            get
            {
                if ((this.cachedAvailableItems == null))
                {
                    this.cachedAvailableItems = new DataGrid(this, MemberSelectionDialog.QueryIds.AvailableItems);
                }
                
                return this.cachedAvailableItems;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SelectedItems control
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        DataGrid IMemberSelectionDialogControls.SelectedItems
        {
            get
            {
                if ((this.cachedSelectedItems == null))
                {
                    this.cachedSelectedItems = new DataGrid(this, MemberSelectionDialog.QueryIds.SelectedItems);
                }
                
                return this.cachedSelectedItems;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the AddButton control
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMemberSelectionDialogControls.AddButton
        {
            get
            {
                if ((this.cachedAddButton == null))
                {
                    this.cachedAddButton = new Button(this, MemberSelectionDialog.QueryIds.AddButton);
                }
                
                return this.cachedAddButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the RemoveButton control
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMemberSelectionDialogControls.RemoveButton
        {
            get
            {
                if ((this.cachedRemoveButton == null))
                {
                    this.cachedRemoveButton = new Button(this, MemberSelectionDialog.QueryIds.RemoveButton);
                }
                
                return this.cachedRemoveButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the CancelButton control
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMemberSelectionDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, MemberSelectionDialog.QueryIds.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the OKButton control
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMemberSelectionDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, MemberSelectionDialog.QueryIds.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SelectManagementServersOrGatewayServersForThisResourcePool control
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IMemberSelectionDialogControls.SelectManagementServersOrGatewayServersForThisResourcePool
        {
            get
            {
                if ((this.cachedSelectManagementServersOrGatewayServersForThisResourcePool == null))
                {
                    this.cachedSelectManagementServersOrGatewayServersForThisResourcePool = new TextBox(this, MemberSelectionDialog.QueryIds.SelectManagementServersOrGatewayServersForThisResourcePool);
                }
                
                return this.cachedSelectManagementServersOrGatewayServersForThisResourcePool;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SearchButton control
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMemberSelectionDialogControls.SearchButton
        {
            get
            {
                if ((this.cachedSearchButton == null))
                {
                    this.cachedSearchButton = new Button(this, MemberSelectionDialog.QueryIds.SearchButton);
                }
                
                return this.cachedSearchButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the CancelButton2 control
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMemberSelectionDialogControls.CancelButton2
        {
            get
            {
                if ((this.cachedCancelButton2 == null))
                {
                    this.cachedCancelButton2 = new Button(this, MemberSelectionDialog.QueryIds.CancelButton2);
                }
                
                return this.cachedCancelButton2;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Add
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAdd()
        {
            this.Controls.AddButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Remove
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickRemove()
        {
            this.Controls.RemoveButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
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
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Search
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSearch()
        {
            this.Controls.SearchButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel2
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel2()
        {
            this.Controls.CancelButton2.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">App owning the dialog.</param>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app, bool created, string poolName)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            string dialogTitle;

            if (created == true)
            {
                dialogTitle = Strings.CreatedMemberSelectionDialogTitle;
            }
            else
            {
                dialogTitle = string.Format(Strings.EditMemberSelectionDialogTitle, poolName);
            }
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(app.MainWindow, new QID(";[UIA, VisibleOnly]Name = '" + dialogTitle + "' && Role = 'window'"), Timeout);
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
                        tempWindow = new Window(dialogTitle, StringMatchSyntax.WildCard);
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
                    throw;
                }
            }
            
            return tempWindow;
        }
        
        #region Query ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all query ID's.
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class QueryIds
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for AvailableItems query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAvailableItems = ";[UIA]AutomationId=\'availableItemsListView\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for SelectedItems query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectedItems = ";[UIA]AutomationId=\'selectedItemsListview\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for AddButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAddButton = ";[UIA]AutomationId=\'addButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for RemoveButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRemoveButton = ";[UIA]AutomationId=\'removeButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for CancelButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancelButton = ";[UIA]AutomationId=\'cancelBtn\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for OKButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOKButton = ";[UIA]AutomationId=\'okButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for SelectManagementServersOrGatewayServersForThisResourcePool query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectManagementServersOrGatewayServersForThisResourcePool = ";[UIA]AutomationId=\'filterEntry\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for SearchButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSearchButton = ";[UIA]AutomationId=\'searchButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for CancelButton2 query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancelButton2 = ";[UIA]AutomationId=\'cancelButton\'";
            #endregion
            
            #region Properties
                             
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the AvailableItems resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/8/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID AvailableItems
            {
                get
                {
                    return new QID(ResourceAvailableItems);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the SelectedItems resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/8/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SelectedItems
            {
                get
                {
                    return new QID(ResourceSelectedItems);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the AddButton resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/8/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID AddButton
            {
                get
                {
                    return new QID(ResourceAddButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the RemoveButton resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/8/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID RemoveButton
            {
                get
                {
                    return new QID(ResourceRemoveButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the CancelButton resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/8/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID CancelButton
            {
                get
                {
                    return new QID(ResourceCancelButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the OKButton resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/8/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID OKButton
            {
                get
                {
                    return new QID(ResourceOKButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the SelectManagementServersOrGatewayServersForThisResourcePool resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/8/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SelectManagementServersOrGatewayServersForThisResourcePool
            {
                get
                {
                    return new QID(ResourceSelectManagementServersOrGatewayServersForThisResourcePool);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the SearchButton resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/8/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SearchButton
            {
                get
                {
                    return new QID(ResourceSearchButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the CancelButton2 resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 11/8/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID CancelButton2
            {
                get
                {
                    return new QID(ResourceCancelButton2);
                }
            }
            #endregion
        }
        #endregion
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        ///   [asttest] 11/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
             #region Constants
            /// <summary>
            /// Contains Resource string for: "Create a Resource Pool Wizard"
            /// </summary>            
            private const string ResourceCreatedMemberSelectionDialogTitle =
                ";Create a Resource Pool Wizard - Member Selection;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;Pools_Wizard_Page_Membership_Picker_Title_Create";

            /// <summary>
            /// Contains Resource string for: "{0} Properties"
            /// </summary>            
            private const string ResourceEditMemberSelectionDialogTitle =
                ";{0} Properties - Member Selection;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;Pools_Wizard_Page_Membership_Picker_Title_Edit";
            

            #endregion

            #region Private members
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  "Create a Resource Pool Wizard"
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCreatedMemberSelectionDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  "{0} Properties"
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEditMemberSelectionDialogTitle;

            #endregion

            #region Properties
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to "Create a Resource Pool Wizard"
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string CreatedMemberSelectionDialogTitle
            {
                get
                {
                    if ((cachedCreatedMemberSelectionDialogTitle == null))
                    {
                        cachedCreatedMemberSelectionDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceCreatedMemberSelectionDialogTitle);
                    }

                    return cachedCreatedMemberSelectionDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to "{0} Properties"
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string EditMemberSelectionDialogTitle
            {
                get
                {
                    if ((cachedEditMemberSelectionDialogTitle == null))
                    {
                        cachedEditMemberSelectionDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceEditMemberSelectionDialogTitle);
                    }

                    return cachedEditMemberSelectionDialogTitle;
                }
            }
            #endregion
            
            /// <summary>
            /// Resource string for Available items:
            /// </summary>
            public const string AvailableItems = "Available items:";
            
            /// <summary>
            /// Resource string for Selected items:
            /// </summary>
            public const string SelectedItems = "Selected items:";
            
            /// <summary>
            /// Resource string for Add
            /// </summary>
            public const string Add = "Add";
            
            /// <summary>
            /// Resource string for Remove
            /// </summary>
            public const string Remove = "Remove";
            
            /// <summary>
            /// Resource string for Cancel
            /// </summary>
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// Cancel
            /// </remark>
            public const string Cancel = "Cancel";
            
            /// <summary>
            /// Resource string for OK
            /// </summary>
            public const string OK = "OK";
            
            /// <summary>
            /// Resource string for Search
            /// </summary>
            public const string Search = "Search";
            
            /// <summary>
            /// Resource string for Cancel
            /// </summary>
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// Cancel
            /// </remark>
            public const string Cancel2 = "Cancel";
        }
        #endregion
    }
}
