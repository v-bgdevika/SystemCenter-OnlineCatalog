// ----------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ResolutionStateDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	MOMv3 R2 test automation.
// </project>
// <summary>
// 	MOMv3 R2 test automation.
// </summary>
// <history>
// 	[KellyMor]  23-SEP-08   Created
//  [KellyMor]  22-OCT-08   Modified list box control to more descriptive name.
//                          Modified comboboxes to use more descriptive names.
//                          StyleCop fixes.
// </history>
// ----------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Administration.Notifications.Subscriptions.Wizards.AlertCriteria
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Radio Group Enumeration - MatchResolutionStatesOption

    /// -------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group MatchResolutionStatesOption
    /// </summary>
    /// <history>
    /// 	[KellyMor] 23-SEP-08 Created
    /// </history>
    /// -------------------------------------------------------------------
    public enum MatchResolutionStatesOption
    {
        /// <summary>
        /// SelectOnlySpecificResolutionState = 0
        /// </summary>
        SelectOnlySpecificResolutionState = 0,
        
        /// <summary>
        /// SelectResolutionStatesToSearchFor = 1
        /// </summary>
        SelectResolutionStatesToSearchFor = 1,
    }

    #endregion
    
    #region Interface Definition - IResolutionStateDialogControls

    /// -------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IResolutionStateDialogControls, for ResolutionStateDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 23-SEP-08 Created
    /// </history>
    /// -------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IResolutionStateDialogControls
    {
        /// <summary>
        /// Read-only property to access ResolutionStateCheckedListBox
        /// </summary>
        CheckedListBox ResolutionStateCheckedListBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ClearAllButton
        /// </summary>
        Button ClearAllButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectAllButton
        /// </summary>
        Button SelectAllButton
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
        /// Read-only property to access OperatorComboBox
        /// </summary>
        ComboBox OperatorComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectOnlySpecificResolutionStateRadioButton
        /// </summary>
        RadioButton SelectOnlySpecificResolutionStateRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectResolutionStatesToSearchForRadioButton
        /// </summary>
        RadioButton SelectResolutionStatesToSearchForRadioButton
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
        /// Read-only property to access StateValueComboBox
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        ComboBox StateValueComboBox
        {
            get;
        }
    }

    #endregion
    
    /// -----------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate dialog functionality of the alert resolution state
    /// criteria selection dialog.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 23-SEP-08 Created
    /// </history>
    /// -----------------------------------------------------------------------
    public class ResolutionStateDialog : Dialog, IResolutionStateDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ResolutionStateCheckedListBox of type ListBox
        /// </summary>
        private CheckedListBox cachedResolutionStateCheckedListBox;
        
        /// <summary>
        /// Cache to hold a reference to ClearAllButton of type Button
        /// </summary>
        private Button cachedClearAllButton;
        
        /// <summary>
        /// Cache to hold a reference to SelectAllButton of type Button
        /// </summary>
        private Button cachedSelectAllButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to OperatorComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedOperatorComboBox;
        
        /// <summary>
        /// Cache to hold a reference to SelectOnlySpecificResolutionStateRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedSelectOnlySpecificResolutionStateRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to SelectResolutionStatesToSearchForRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedSelectResolutionStatesToSearchForRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to StateValueComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedStateValueComboBox;

        #endregion
        
        #region Constructors

        /// -------------------------------------------------------------------
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ResolutionStateDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[KellyMor] 23-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public ResolutionStateDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }

        #endregion
        
        #region Radio Group Properties

        /// -------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group MatchResolutionStatesOption
        /// </summary>
        /// <history>
        /// 	[KellyMor] 23-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual MatchResolutionStatesOption MatchResolutionStatesOption
        {
            get
            {
                if ((this.Controls.SelectOnlySpecificResolutionStateRadioButton.ButtonState == ButtonState.Checked))
                {
                    return MatchResolutionStatesOption.SelectOnlySpecificResolutionState;
                }
                
                if ((this.Controls.SelectResolutionStatesToSearchForRadioButton.ButtonState == ButtonState.Checked))
                {
                    return MatchResolutionStatesOption.SelectResolutionStatesToSearchFor;
                }
                
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == MatchResolutionStatesOption.SelectOnlySpecificResolutionState))
                {
                    this.Controls.SelectOnlySpecificResolutionStateRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == MatchResolutionStatesOption.SelectResolutionStatesToSearchFor))
                    {
                        this.Controls.SelectResolutionStatesToSearchForRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }

        #endregion
        
        #region IResolutionStateDialog Controls Property

        /// -------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>
        /// An interface that groups all of the dialog's control properties 
        /// together
        /// </value>
        /// <history>
        /// 	[KellyMor] 23-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual IResolutionStateDialogControls Controls
        {
            get
            {
                return this;
            }
        }

        #endregion
        
        #region Text Field Properties

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control OperatorComboBox
        /// </summary>
        /// <history>
        /// 	[KellyMor] 23-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual string OperatorComboBoxText
        {
            get
            {
                return this.Controls.OperatorComboBox.Text;
            }
            
            set
            {
                this.Controls.OperatorComboBox.SelectByText(value, true);
            }
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control StateValueComboBox
        /// </summary>
        /// <history>
        /// 	[KellyMor] 23-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual string StateValueComboBoxText
        {
            get
            {
                return this.Controls.StateValueComboBox.Text;
            }
            
            set
            {
                this.Controls.StateValueComboBox.SelectByText(value, true);
            }
        }

        #endregion
        
        #region Control Properties

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ResolutionStateCheckedListBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 23-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        CheckedListBox IResolutionStateDialogControls.ResolutionStateCheckedListBox
        {
            get
            {
                if ((this.cachedResolutionStateCheckedListBox == null))
                {
                    this.cachedResolutionStateCheckedListBox = 
                        new CheckedListBox(
                            this, 
                            ResolutionStateDialog.ControlIDs.ResolutionStateCheckedListBox);
                }
                
                return this.cachedResolutionStateCheckedListBox;
            }
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ClearAllButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 23-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        Button IResolutionStateDialogControls.ClearAllButton
        {
            get
            {
                if ((this.cachedClearAllButton == null))
                {
                    this.cachedClearAllButton = 
                        new Button(
                            this, 
                            ResolutionStateDialog.ControlIDs.ClearAllButton);
                }
                
                return this.cachedClearAllButton;
            }
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectAllButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 23-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        Button IResolutionStateDialogControls.SelectAllButton
        {
            get
            {
                if ((this.cachedSelectAllButton == null))
                {
                    this.cachedSelectAllButton = 
                        new Button(
                            this, 
                            ResolutionStateDialog.ControlIDs.SelectAllButton);
                }
                
                return this.cachedSelectAllButton;
            }
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 23-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        Button IResolutionStateDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = 
                        new Button(
                            this, 
                            ResolutionStateDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OperatorComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 23-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        ComboBox IResolutionStateDialogControls.OperatorComboBox
        {
            get
            {
                if ((this.cachedOperatorComboBox == null))
                {
                    this.cachedOperatorComboBox = 
                        new ComboBox(
                            this, 
                            ResolutionStateDialog.ControlIDs.OperatorComboBox);
                }
                
                return this.cachedOperatorComboBox;
            }
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectOnlySpecificResolutionStateRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 23-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        RadioButton IResolutionStateDialogControls.SelectOnlySpecificResolutionStateRadioButton
        {
            get
            {
                if ((this.cachedSelectOnlySpecificResolutionStateRadioButton == null))
                {
                    this.cachedSelectOnlySpecificResolutionStateRadioButton = new RadioButton(this, ResolutionStateDialog.ControlIDs.SelectOnlySpecificResolutionStateRadioButton);
                }
                
                return this.cachedSelectOnlySpecificResolutionStateRadioButton;
            }
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectResolutionStatesToSearchForRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 23-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        RadioButton IResolutionStateDialogControls.SelectResolutionStatesToSearchForRadioButton
        {
            get
            {
                if ((this.cachedSelectResolutionStatesToSearchForRadioButton == null))
                {
                    this.cachedSelectResolutionStatesToSearchForRadioButton = new RadioButton(this, ResolutionStateDialog.ControlIDs.SelectResolutionStatesToSearchForRadioButton);
                }
                
                return this.cachedSelectResolutionStatesToSearchForRadioButton;
            }
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 23-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        Button IResolutionStateDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ResolutionStateDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StateValueComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 23-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        ComboBox IResolutionStateDialogControls.StateValueComboBox
        {
            get
            {
                if ((this.cachedStateValueComboBox == null))
                {
                    this.cachedStateValueComboBox = 
                        new ComboBox(
                            this, 
                            ResolutionStateDialog.ControlIDs.StateValueComboBox);
                }
                
                return this.cachedStateValueComboBox;
            }
        }

        #endregion
        
        #region Click Methods

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ClearAll
        /// </summary>
        /// <history>
        /// 	[KellyMor] 23-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual void ClickClearAll()
        {
            this.Controls.ClearAllButton.Click();
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button SelectAll
        /// </summary>
        /// <history>
        /// 	[KellyMor] 23-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual void ClickSelectAll()
        {
            this.Controls.SelectAllButton.Click();
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[KellyMor] 23-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[KellyMor] 23-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        #endregion
        
        /// -------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">MomConsoleApp owning the dialog.</param>
        /// <history>
        /// 	[KellyMor] 23-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = 
                    new Window(
                        Strings.DialogTitle, 
                        StringMatchSyntax.ExactMatch, 
                        WindowClassNames.WinForms10Window8, 
                        StringMatchSyntax.ExactMatch, 
                        app.MainWindow, 
                        Timeout);
            }
            catch (Exceptions.WindowNotFoundException windowNotFound)
            {
                // Reset the window reference
                tempWindow = null;

                // Maximum number of tries to find window
                int maxTries = 5;

                // Try several more times to find the window
                for (int numberOfTries = 0; 
                    ((null == tempWindow) && (numberOfTries < maxTries)); 
                    numberOfTries = (numberOfTries + 1))
                {
                    try
                    {
                        // Try to locate an existing instance of the window
                        tempWindow = 
                            new Window(
                                Strings.DialogTitle, 
                                StringMatchSyntax.WildCard);

                        // Wait for the window to become ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow, 
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage(
                            "Attempt " +
                            numberOfTries +
                            " of " +
                            maxTries +
                            "...");

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }
                
                // check for success
                if ((null == tempWindow))
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find the window with title := '" +
                        Strings.DialogTitle);

                    // rethrow the original exception
                    throw windowNotFound;
                }
            }
            
            return tempWindow;
        }
        
        #region Strings Class

        /// -------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 23-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -------------------------------------------------------------------
            private const string ResourceDialogTitle = 
                ";Resolution State" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.CriteriaControl.CriteriaControlResource" +
                ";ResolutionStateEditDialogTitle";
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ClearAll
            /// </summary>
            /// -------------------------------------------------------------------
            private const string ResourceClearAll =
                ";&Clear All" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.CheckedListEditDialogBase" +
                ";buttonClearAll.Text";
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectAll
            /// </summary>
            /// -------------------------------------------------------------------
            private const string ResourceSelectAll =
                ";&Select All" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.CheckedListEditDialogBase" +
                ";buttonSelectAll.Text";
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -------------------------------------------------------------------
            private const string ResourceOK =
                ";OK" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.SimpleChooserDialog" +
                ";okButton.Text";
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectOnlySpecificResolutionState
            /// </summary>
            /// -------------------------------------------------------------------
            private const string ResourceSelectOnlySpecificResolutionState =
                ";Select &only specific Resolution State:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.ResolutionStateEditDialog" +
                ";radioOnly.Text";
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectResolutionStatesToSearchFor
            /// </summary>
            /// -------------------------------------------------------------------
            private const string ResourceSelectResolutionStatesToSearchFor =
                ";Select &resolution states to search for:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.ResolutionStateEditDialog" +
                ";radioSelect.Text";
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -------------------------------------------------------------------
            private const string ResourceCancel =
                ";Cancel" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.SimpleChooserDialog" +
                ";cancelButton.Text";

            /// -------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  NewResolutionState 
            /// </summary>
            /// -------------------------------------------------------------------
            private const string ResourceNewResolutionState =
                ";New" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertResources" +
                ";ResolutionState0";

            /// -------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ClosedResolutionState 
            /// </summary>
            /// -------------------------------------------------------------------
            private const string ResourceClosedResolutionState =
                ";Closed" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertResources" +
                ";ResolutionState255";

            #endregion
            
            #region Private Members

            /// -------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -------------------------------------------------------------------
            private static string cachedDialogTitle;
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ClearAll
            /// </summary>
            /// -------------------------------------------------------------------
            private static string cachedClearAll;
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectAll
            /// </summary>
            /// -------------------------------------------------------------------
            private static string cachedSelectAll;
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -------------------------------------------------------------------
            private static string cachedOK;
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectOnlySpecificResolutionState
            /// </summary>
            /// -------------------------------------------------------------------
            private static string cachedSelectOnlySpecificResolutionState;
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectResolutionStatesToSearchFor
            /// </summary>
            /// -------------------------------------------------------------------
            private static string cachedSelectResolutionStatesToSearchFor;
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -------------------------------------------------------------------
            private static string cachedCancel;

            /// -------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  NewResolutionState 
            /// </summary>
            /// -------------------------------------------------------------------
            private static string cachedNewResolutionState;

            /// -------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ClosedResolutionState 
            /// </summary>
            /// -------------------------------------------------------------------
            private static string cachedClosedResolutionState;

            #endregion
            
            #region Properties

            /// -------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 23-SEP-08 Created
            /// </history>
            /// -------------------------------------------------------------------
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
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ClearAll translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 23-SEP-08 Created
            /// </history>
            /// -------------------------------------------------------------------
            public static string ClearAll
            {
                get
                {
                    if ((cachedClearAll == null))
                    {
                        cachedClearAll = CoreManager.MomConsole.GetIntlStr(ResourceClearAll);
                    }
                    
                    return cachedClearAll;
                }
            }
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectAll translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 23-SEP-08 Created
            /// </history>
            /// -------------------------------------------------------------------
            public static string SelectAll
            {
                get
                {
                    if ((cachedSelectAll == null))
                    {
                        cachedSelectAll = CoreManager.MomConsole.GetIntlStr(ResourceSelectAll);
                    }
                    
                    return cachedSelectAll;
                }
            }
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 23-SEP-08 Created
            /// </history>
            /// -------------------------------------------------------------------
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
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectOnlySpecificResolutionState translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 23-SEP-08 Created
            /// </history>
            /// -------------------------------------------------------------------
            public static string SelectOnlySpecificResolutionState
            {
                get
                {
                    if ((cachedSelectOnlySpecificResolutionState == null))
                    {
                        cachedSelectOnlySpecificResolutionState = CoreManager.MomConsole.GetIntlStr(ResourceSelectOnlySpecificResolutionState);
                    }
                    
                    return cachedSelectOnlySpecificResolutionState;
                }
            }
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectResolutionStatesToSearchFor translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 23-SEP-08 Created
            /// </history>
            /// -------------------------------------------------------------------
            public static string SelectResolutionStatesToSearchFor
            {
                get
                {
                    if ((cachedSelectResolutionStatesToSearchFor == null))
                    {
                        cachedSelectResolutionStatesToSearchFor = CoreManager.MomConsole.GetIntlStr(ResourceSelectResolutionStatesToSearchFor);
                    }
                    
                    return cachedSelectResolutionStatesToSearchFor;
                }
            }
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 23-SEP-08 Created
            /// </history>
            /// -------------------------------------------------------------------
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

            /// -------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NewResolutionState  translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 23-SEP-08 Created
            /// </history>
            /// -------------------------------------------------------------------
            public static string NewResolutionState 
            {
                get
                {
                    if ((cachedNewResolutionState == null))
                    {
                        cachedNewResolutionState = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceNewResolutionState);
                    }

                    return cachedNewResolutionState;
                }
            }

            /// -------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ClosedResolutionState  translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 23-SEP-08 Created
            /// </history>
            /// -------------------------------------------------------------------
            public static string ClosedResolutionState
            {
                get
                {
                    if ((cachedClosedResolutionState == null))
                    {
                        cachedClosedResolutionState = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceClosedResolutionState);
                    }

                    return cachedClosedResolutionState;
                }
            }

            #endregion
        }

        #endregion
        
        #region Control ID's

        /// -------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 23-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ResolutionStateCheckedListBox
            /// </summary>
            public const string ResolutionStateCheckedListBox = "checkedList";
            
            /// <summary>
            /// Control ID for ClearAllButton
            /// </summary>
            public const string ClearAllButton = "buttonClearAll";
            
            /// <summary>
            /// Control ID for SelectAllButton
            /// </summary>
            public const string SelectAllButton = "buttonSelectAll";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "buttonOK";
            
            /// <summary>
            /// Control ID for OperatorComboBox
            /// </summary>
            public const string OperatorComboBox = "comboOperator";
            
            /// <summary>
            /// Control ID for SelectOnlySpecificResolutionStateRadioButton
            /// </summary>
            public const string SelectOnlySpecificResolutionStateRadioButton = "radioOnly";
            
            /// <summary>
            /// Control ID for SelectResolutionStatesToSearchForRadioButton
            /// </summary>
            public const string SelectResolutionStatesToSearchForRadioButton = "radioSelect";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "buttonCancel";
            
            /// <summary>
            /// Control ID for StateValueComboBox
            /// </summary>
            public const string StateValueComboBox = "stateSpinner";
        }

        #endregion
    }
}
