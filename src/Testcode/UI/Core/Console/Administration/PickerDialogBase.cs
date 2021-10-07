// ----------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="PickerDialogBase.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	MOMv3 R2 test automation.
// </project>
// <summary>
// 	MOMv3 R2 test automation.
// </summary>
// <history>
// 	[KellyMor]  04-OCT-08   Created
//  [KellyMor]  09-OCT-08   Added additional logging to WaitForSearchResults.
//  [KellyMor]  21-OCT-08   Renamed text fields to match control names.
//                          StyleCop fixes.
// </history>
// ----------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Administration
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IPickerDialogBaseControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IPickerDialogBaseControls, for PickerDialogBase.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 04-OCT-08 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IPickerDialogBaseControls
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
        /// Read-only property to access SelectedItemsListView
        /// </summary>
        ListView SelectedItemsListView
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AvailableItemsStaticControl
        /// </summary>
        StaticControl AvailableItemsStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access SelectedItemsListview
        /// </summary>
        ListView AvailableItemsListView
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AddButton
        /// </summary>
        Button AddButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access RemoveButton
        /// </summary>
        Button RemoveButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access SelectedItemsStaticControl
        /// </summary>
        StaticControl SelectedItemsStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access LookForComboBox
        /// </summary>
        ComboBox LookForComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access FilterByTextBox
        /// </summary>
        TextBox FilterByTextBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access LookForStaticControl
        /// </summary>
        StaticControl LookForStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access FilterByStaticControl
        /// </summary>
        StaticControl FilterByStaticControl
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
        /// Read-only property to access SearchButton
        /// </summary>
        Button SearchButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AsyncCancelButton
        /// </summary>
        Button AsyncCancelButton
        {
            get;
        }
    }

    #endregion
    
    /// -----------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the base functionality of the Picker Dialog.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 04-OCT-08 Created
    /// </history>
    /// -----------------------------------------------------------------------
    public class PickerDialogBase : Dialog, IPickerDialogBaseControls
    {
        #region Public Constants

        /// <summary>
        /// Maximum wait time:  60 seconds.
        /// </summary>
        public const int MaxSearchWaitTime = 60000;

        #endregion

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
        /// Cache to hold a reference to SelectedItemsListView of type ListView
        /// </summary>
        private ListView cachedSelectedItemsListView;
        
        /// <summary>
        /// Cache to hold a reference to AvailableItemsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAvailableItemsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectedItemsListview of type ListView
        /// </summary>
        private ListView cachedAvailableItemsListView;
        
        /// <summary>
        /// Cache to hold a reference to AddButton of type Button
        /// </summary>
        private Button cachedAddButton;
        
        /// <summary>
        /// Cache to hold a reference to RemoveButton of type Button
        /// </summary>
        private Button cachedRemoveButton;
        
        /// <summary>
        /// Cache to hold a reference to SelectedItemsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectedObjectsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to LookForComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedLookForComboBox;
        
        /// <summary>
        /// Cache to hold a reference to FilterByTextBox of type TextBox
        /// </summary>
        private TextBox cachedFilterByTextBox;
        
        /// <summary>
        /// Cache to hold a reference to LookForStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedLookForStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to FilterByStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedFilterByStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HeaderStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHeaderStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SearchButton of type Button
        /// </summary>
        private Button cachedSearchButton;
        
        /// <summary>
        /// Cache to hold a reference to AsyncCancelButton of type Button
        /// </summary>
        private Button cachedAsyncCancelButton;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Default constructor.  During initialization of the base class, this class
        /// checks to see if the specified dialog title is null or empty string.  If it
        /// is, it will supply this dialog class's dialog title as the argument to the
        /// base class, Maui.Core.Dialog.  The terinary operator allows this to happen
        /// inline ({condition check} ? {true condition} : {false condition}).
        /// </summary>
        /// <param name='app'>
        /// Owner of PickerDialogBase of type ConsoleApp
        /// </param>
        /// <param name="dialogTitle">
        /// Title string of the dialog that derives from this parent dialog.
        /// </param>
        /// <history>
        /// 	[KellyMor] 04-OCT-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public PickerDialogBase(ConsoleApp app, string dialogTitle) :
                base(app, Init(app, (System.String.IsNullOrEmpty(dialogTitle) ? Strings.DialogTitle : dialogTitle)))
        {
        }

        #endregion
        
        #region IPickerDialogBase Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[KellyMor] 04-OCT-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IPickerDialogBaseControls Controls
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
        ///  Routine to set/get the text in control LookForComboBox
        /// </summary>
        /// <history>
        /// 	[KellyMor] 04-OCT-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string LookForComboBoxText
        {
            get
            {
                return this.Controls.LookForComboBox.Text;
            }
            
            set
            {
                this.Controls.LookForComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control FilterByTextBox
        /// </summary>
        /// <history>
        /// 	[KellyMor] 04-OCT-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string FilterByTextBoxText
        {
            get
            {
                return this.Controls.FilterByTextBox.Text;
            }
            
            set
            {
                this.Controls.FilterByTextBox.Text = value;
            }
        }

        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 04-OCT-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPickerDialogBaseControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = 
                        new Button(
                            this, 
                            PickerDialogBase.ControlIDs.CancelButton);
                }

                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 04-OCT-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPickerDialogBaseControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = 
                        new Button(this, PickerDialogBase.ControlIDs.OKButton);
                }

                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectedItemsListView control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 04-OCT-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IPickerDialogBaseControls.SelectedItemsListView
        {
            get
            {
                if ((this.cachedSelectedItemsListView == null))
                {
                    this.cachedSelectedItemsListView = 
                        new ListView(
                            this, 
                            PickerDialogBase.ControlIDs.SelectedItemsListview);
                }

                return this.cachedSelectedItemsListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AvailableItemsStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 04-OCT-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPickerDialogBaseControls.AvailableItemsStaticControl
        {
            get
            {
                if ((this.cachedAvailableItemsStaticControl == null))
                {
                    this.cachedAvailableItemsStaticControl = 
                        new StaticControl(
                            this, 
                            PickerDialogBase.ControlIDs.AvailableItemsStaticControl);
                }

                return this.cachedAvailableItemsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectedItemsListview control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 04-OCT-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IPickerDialogBaseControls.AvailableItemsListView
        {
            get
            {
                if ((this.cachedAvailableItemsListView == null))
                {
                    cachedAvailableItemsListView = new ListView(this, new QID(";[UIA]AutomationId ='" + PickerDialogBase.ControlIDs.AvailableItemsListView + "'"));
                }

                return this.cachedAvailableItemsListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 04-OCT-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPickerDialogBaseControls.AddButton
        {
            get
            {
                if ((this.cachedAddButton == null))
                {
                    this.cachedAddButton = 
                        new Button(
                            this, 
                            PickerDialogBase.ControlIDs.AddButton);
                }

                return this.cachedAddButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RemoveButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 04-OCT-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPickerDialogBaseControls.RemoveButton
        {
            get
            {
                if ((this.cachedRemoveButton == null))
                {
                    this.cachedRemoveButton = 
                        new Button(
                            this, 
                            PickerDialogBase.ControlIDs.RemoveButton);
                }

                return this.cachedRemoveButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectedItemsStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 04-OCT-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPickerDialogBaseControls.SelectedItemsStaticControl
        {
            get
            {
                if ((this.cachedSelectedObjectsStaticControl == null))
                {
                    this.cachedSelectedObjectsStaticControl = 
                        new StaticControl(
                            this, 
                            PickerDialogBase.ControlIDs.SelectedItemsStaticControl);
                }

                return this.cachedSelectedObjectsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LookForComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 04-OCT-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IPickerDialogBaseControls.LookForComboBox
        {
            get
            {
                if ((this.cachedLookForComboBox == null))
                {
                    this.cachedLookForComboBox = 
                        new ComboBox(
                            this, 
                            PickerDialogBase.ControlIDs.LookForComboBox);
                }

                return this.cachedLookForComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FilterByTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 04-OCT-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IPickerDialogBaseControls.FilterByTextBox
        {
            get
            {
                if ((this.cachedFilterByTextBox == null))
                {
                    this.cachedFilterByTextBox = 
                        new TextBox(
                            this, 
                            PickerDialogBase.ControlIDs.FilterByTextBox);
                }

                return this.cachedFilterByTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LookForStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 04-OCT-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPickerDialogBaseControls.LookForStaticControl
        {
            get
            {
                if ((this.cachedLookForStaticControl == null))
                {
                    this.cachedLookForStaticControl = 
                        new StaticControl(
                            this, 
                            PickerDialogBase.ControlIDs.LookForStaticControl);
                }

                return this.cachedLookForStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FilterByStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 04-OCT-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPickerDialogBaseControls.FilterByStaticControl
        {
            get
            {
                if ((this.cachedFilterByStaticControl == null))
                {
                    this.cachedFilterByStaticControl = 
                        new StaticControl(
                            this, 
                            PickerDialogBase.ControlIDs.FilterByStaticControl);
                }

                return this.cachedFilterByStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HeaderStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 04-OCT-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPickerDialogBaseControls.HeaderStaticControl
        {
            get
            {
                if ((this.cachedHeaderStaticControl == null))
                {
                    this.cachedHeaderStaticControl = 
                        new StaticControl(
                            this, 
                            PickerDialogBase.ControlIDs.HeaderStaticControl);
                }

                return this.cachedHeaderStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SearchButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 04-OCT-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPickerDialogBaseControls.SearchButton
        {
            get
            {
                if ((this.cachedSearchButton == null))
                {
                    this.cachedSearchButton = 
                        new Button(
                            this, 
                            PickerDialogBase.ControlIDs.SearchButton);
                }

                return this.cachedSearchButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AsyncCancelButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 9/10/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPickerDialogBaseControls.AsyncCancelButton
        {
            get
            {
                // The ID for this control (cancelButton) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedAsyncCancelButton == null))
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
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    this.cachedAsyncCancelButton = new Button(wndTemp);
                }

                return this.cachedAsyncCancelButton;
            }
        }

        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[KellyMor] 04-OCT-08 Created
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
        /// 	[KellyMor] 04-OCT-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Add
        /// </summary>
        /// <history>
        /// 	[KellyMor] 04-OCT-08 Created
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
        /// 	[KellyMor] 04-OCT-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickRemove()
        {
            this.Controls.RemoveButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Search
        /// </summary>
        /// <history>
        /// 	[KellyMor] 04-OCT-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSearch()
        {
            this.Controls.SearchButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button AsyncCancel
        /// </summary>
        /// <history>
        /// 	[KellyMor] 9/10/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAsyncCancel()
        {
            this.Controls.AsyncCancelButton.Click();
        }

        #endregion

        #region Public Methods

        /// -------------------------------------------------------------------
        /// <summary>
        /// Mehtod to wait for a search request to return results or until the
        /// maximum wait time, in milliseconds, expires.
        /// </summary>
        /// <param name="maxWaitMilliseconds">
        /// Maximum wait time, in milliseconds.
        /// </param>
        /// -------------------------------------------------------------------
        public virtual void WaitForSearchResults(
            int maxWaitMilliseconds)
        {
            // check for valid wait time between 0 and max wait time
            if (0 <= maxWaitMilliseconds || 
                PickerDialogBase.MaxSearchWaitTime < maxWaitMilliseconds)
            {
                maxWaitMilliseconds = PickerDialogBase.MaxSearchWaitTime;
            }

            Core.Common.Utilities.LogMessage(
                "PickerDialogBase.WaitForSearchResults::Waiting for search to complete, waiting := " +
                (maxWaitMilliseconds / Core.Common.Constants.OneSecond));

            // loop over the max wait time and poll the search/cancel button for its text
            int totalTime = 0;
            for (int timer = 0; 
                (timer < maxWaitMilliseconds && 
                this.Controls.SearchButton.Caption.Equals(Strings.AsyncCancel)); 
                timer += 100)
            {
                Maui.Core.Utilities.Sleeper.Delay(100);
                totalTime = timer;
            }

            Core.Common.Utilities.LogMessage(
                "PickerDialogBase.WaitForSearchResults::Total search time (+/- 100 ms) := '" +
                ((float)totalTime / (float)Core.Common.Constants.OneSecond));
        }

        #endregion

        /// -------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the 
        /// dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">ConsoleApp owning the dialog.</param>)
        /// <param name="dialogTitle">
        /// Title string of the dialog that derives from this parent dialog.
        /// </param>
        /// <history>
        /// 	[KellyMor] 04-OCT-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        private static Window Init(
            ConsoleApp app,
            string dialogTitle)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                UI.Core.Common.Utilities.LogMessage(
                    "PickerDialogBase::Looking for window with title := '" +
                    dialogTitle +
                    "'");

                // Try to locate an existing instance of a dialog
                tempWindow = new Window(
                    dialogTitle,
                    StringMatchSyntax.ExactMatch,
                    WindowClassNames.WinForms10Window8,
                    StringMatchSyntax.ExactMatch,
                    app.MainWindow,
                    Timeout);
            }
            catch (Exceptions.WindowNotFoundException windowNotFound)
            {
                UI.Core.Common.Utilities.LogMessage(
                    "PickerDialogBase::Second chance to find window with title := '" +
                    dialogTitle +
                    "'");

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
                                dialogTitle,
                                StringMatchSyntax.WildCard);

                        // Wait for the window to become ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        UI.Core.Common.Utilities.LogMessage(
                            "Attempt " +
                            numberOfTries +
                            " of " +
                            maxTries);

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }

                // check for success
                if ((null == tempWindow))
                {
                    // log the failure
                    UI.Core.Common.Utilities.LogMessage(
                        "Failed to find the dialog with title := '" +
                        dialogTitle +
                        "'");

                    // rethrow the original exception
                    throw windowNotFound;
                }
            }

            return tempWindow;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// String resource definitions.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 04-OCT-08 Created
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
            private const string ResourceDialogTitle =
                ";Object Search" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Dialogs.PickerDialogs.PickerDialogBase" +
                ";$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel =
                ";Cancel" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Dialogs.PickerDialogs.PickerDialogResources" +
                ";CancelText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK =
                ";OK" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.SimpleChooserDialog" +
                ";okButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AvailableItems
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAvailableItems =
                ";Available items" +
                ";ManagedString" +
                ";Microsoft.Mom.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.ChooserControl" +
                ";availableObjects.CaptionText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Add
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdd =
                ";&Add" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.SelectedObjectsControl" +
                ";addButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Remove
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRemove =
                ";&Remove" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.SelectedObjectsControl" +
                ";removeButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectedObjects
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectedObjects =
                ";Selected &objects" +
                ";ManagedString" +
                ";Microsoft.Mom.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.ChooserControl" +
                ";selectedObjects.CaptionText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  LookFor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLookFor =
                ";&Look for:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Dialogs.PickerDialogs.ObjectPickerControl" +
                ";label3.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  FilterBy
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFilterBy =
                ";Filter by:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Dialogs.PickerDialogs.ObjectPickerControl" +
                ";label2.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  HeaderText
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHeaderText =
                @";To add objects, search for the objects and then add them to the selected objects list." +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Dialogs.PickerDialogs.ObjectPickerControl" +
                ";label1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Search
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSearch =
                ";&Search" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.AsyncChooserDialogItemProvider" +
                ";searchButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AsyncCancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAsyncCancel = 
                ";Cancel" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Dialogs.PickerDialogs.PickerDialogResources" +
                ";CancelText";

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
            /// Caches the translated resource string for:  AvailableItems
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAvailableItems;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Add
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdd;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Remove
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRemove;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectedObjects
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectedObjects;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  LookFor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLookFor;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  FilterBy
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFilterBy;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  HeaderText
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHeaderText;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Search
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSearch;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AsyncCancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAsyncCancel;
            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 04-OCT-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    if ((cachedDialogTitle == null))
                    {
                        cachedDialogTitle = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceDialogTitle);
                    }

                    return cachedDialogTitle;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 04-OCT-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Cancel
            {
                get
                {
                    if ((cachedCancel == null))
                    {
                        cachedCancel = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCancel);
                    }

                    return cachedCancel;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 04-OCT-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OK
            {
                get
                {
                    if ((cachedOK == null))
                    {
                        cachedOK = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceOK);
                    }

                    return cachedOK;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AvailableItems translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 04-OCT-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AvailableItems
            {
                get
                {
                    if ((cachedAvailableItems == null))
                    {
                        cachedAvailableItems = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAvailableItems);
                    }

                    return cachedAvailableItems;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Add translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 04-OCT-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Add
            {
                get
                {
                    if ((cachedAdd == null))
                    {
                        cachedAdd = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAdd);
                    }

                    return cachedAdd;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Remove translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 04-OCT-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Remove
            {
                get
                {
                    if ((cachedRemove == null))
                    {
                        cachedRemove = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceRemove);
                    }

                    return cachedRemove;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectedObjects translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 04-OCT-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectedObjects
            {
                get
                {
                    if ((cachedSelectedObjects == null))
                    {
                        cachedSelectedObjects = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceSelectedObjects);
                    }

                    return cachedSelectedObjects;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the LookFor translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 04-OCT-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LookFor
            {
                get
                {
                    if ((cachedLookFor == null))
                    {
                        cachedLookFor = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceLookFor);
                    }

                    return cachedLookFor;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the FilterBy translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 04-OCT-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FilterBy
            {
                get
                {
                    if ((cachedFilterBy == null))
                    {
                        cachedFilterBy = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceFilterBy);
                    }

                    return cachedFilterBy;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the HeaderText translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 04-OCT-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string HeaderText
            {
                get
                {
                    if ((cachedHeaderText == null))
                    {
                        cachedHeaderText = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceHeaderText);
                    }

                    return cachedHeaderText;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Search translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 04-OCT-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Search
            {
                get
                {
                    if ((cachedSearch == null))
                    {
                        cachedSearch = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceSearch);
                    }

                    return cachedSearch;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AsyncCancel translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 9/10/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AsyncCancel
            {
                get
                {
                    if ((cachedAsyncCancel == null))
                    {
                        cachedAsyncCancel = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAsyncCancel);
                    }

                    return cachedAsyncCancel;
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
        /// 	[KellyMor] 04-OCT-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelBtn";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for AvailableItemsListView
            /// </summary>
            public const string AvailableItemsListView = "availableItemsListView";
            
            /// <summary>
            /// Control ID for AvailableItemsStaticControl
            /// </summary>
            public const string AvailableItemsStaticControl = "availableItemsLabel";
            
            /// <summary>
            /// Control ID for SelectedItemsListview
            /// </summary>
            public const string SelectedItemsListview = "selectedItemsListview";
            
            /// <summary>
            /// Control ID for AddButton
            /// </summary>
            public const string AddButton = "addButton";
            
            /// <summary>
            /// Control ID for RemoveButton
            /// </summary>
            public const string RemoveButton = "removeButton";
            
            /// <summary>
            /// Control ID for SelectedItemsStaticControl
            /// </summary>
            public const string SelectedItemsStaticControl = "selectedObjectsLabel";
            
            /// <summary>
            /// Control ID for LookForComboBox
            /// </summary>
            public const string LookForComboBox = "classSelector";
            
            /// <summary>
            /// Control ID for FilterByTextBox
            /// </summary>
            public const string FilterByTextBox = "filterEntry";
            
            /// <summary>
            /// Control ID for LookForStaticControl
            /// </summary>
            public const string LookForStaticControl = "label3";
            
            /// <summary>
            /// Control ID for FilterByStaticControl
            /// </summary>
            public const string FilterByStaticControl = "label2";
            
            /// <summary>
            /// Control ID for HeaderStaticControl
            /// </summary>
            public const string HeaderStaticControl = "label1";
            
            /// <summary>
            /// Control ID for SearchButton
            /// </summary>
            public const string SearchButton = "searchButton";
            
            /// <summary>
            /// Control ID for AsyncCancelButton
            /// </summary>
            public const string AsyncCancelButton = "cancelButton";
        }

        #endregion
    }
}
