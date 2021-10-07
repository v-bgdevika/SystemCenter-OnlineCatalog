// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="OptionsInAddGroupDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[a-omkasi] 8/12/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Reporting.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;

    #region Interface Definition - IOptionsInAddGroupDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IOptionsInAddGroupDialogControls, for OptionsInAddGroupDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[a-omkasi] 8/12/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IOptionsInAddGroupDialogControls
    {
        /// <summary>
        /// Read-only property to access SearchTimeIntervalStartDateStaticControl
        /// </summary>
        StaticControl SearchTimeIntervalStartDateStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access IncludeObjectsFromTheFollowingManagementGroupsStaticControl
        /// </summary>
        StaticControl IncludeObjectsFromTheFollowingManagementGroupsStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access SearchTimeIntervalEndDateListBox
        /// </summary>
        ListBox SearchTimeIntervalEndDateListBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access SearchTimeIntervalStartDateComboBox
        /// </summary>
        ComboBox SearchTimeIntervalStartDateComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access SearchTimeIntervalEndDateComboBox
        /// </summary>
        ComboBox SearchTimeIntervalEndDateComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access SearchTimeIntervalEndDateStaticControl
        /// </summary>
        StaticControl SearchTimeIntervalEndDateStaticControl
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
        /// Read-only property to access IncludeGroupsOfTheFollowingTypesStaticControl
        /// </summary>
        StaticControl IncludeGroupsOfTheFollowingTypesStaticControl
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
        /// Read-only property to access IncludeGroupsOfTheFollowingTypesListView
        /// </summary>
        ListView IncludeGroupsOfTheFollowingTypesListView
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
        /// Read-only property to access RemoveButton2
        /// </summary>
        Button RemoveButton2
        {
            get;
        }

        /// <summary>
        /// Read-only property to access IncludeObjectsOfTheFollowingTypesStaticControl
        /// </summary>
        StaticControl IncludeObjectsOfTheFollowingTypesStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AddButton2
        /// </summary>
        Button AddButton2
        {
            get;
        }

        /// <summary>
        /// Read-only property to access IncludeObjectsOfTheFollowingTypesListView
        /// </summary>
        ListView IncludeObjectsOfTheFollowingTypesListView
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
    }
    #endregion

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add dialog functionality description here.
    /// </summary>
    /// <history>
    /// 	[a-omkasi] 8/12/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class OptionsInAddGroupDialog : Dialog, IOptionsInAddGroupDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion

        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to SearchTimeIntervalStartDateStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSearchTimeIntervalStartDateStaticControl;

        /// <summary>
        /// Cache to hold a reference to IncludeObjectsFromTheFollowingManagementGroupsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedIncludeObjectsFromTheFollowingManagementGroupsStaticControl;

        /// <summary>
        /// Cache to hold a reference to SearchTimeIntervalEndDateListBox of type ListBox
        /// </summary>
        private ListBox cachedSearchTimeIntervalEndDateListBox;

        /// <summary>
        /// Cache to hold a reference to SearchTimeIntervalStartDateComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedSearchTimeIntervalStartDateComboBox;

        /// <summary>
        /// Cache to hold a reference to SearchTimeIntervalEndDateComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedSearchTimeIntervalEndDateComboBox;

        /// <summary>
        /// Cache to hold a reference to SearchTimeIntervalEndDateStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSearchTimeIntervalEndDateStaticControl;

        /// <summary>
        /// Cache to hold a reference to RemoveButton of type Button
        /// </summary>
        private Button cachedRemoveButton;

        /// <summary>
        /// Cache to hold a reference to IncludeGroupsOfTheFollowingTypesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedIncludeGroupsOfTheFollowingTypesStaticControl;

        /// <summary>
        /// Cache to hold a reference to AddButton of type Button
        /// </summary>
        private Button cachedAddButton;

        /// <summary>
        /// Cache to hold a reference to IncludeGroupsOfTheFollowingTypesListView of type ListView
        /// </summary>
        private ListView cachedIncludeGroupsOfTheFollowingTypesListView;

        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;

        /// <summary>
        /// Cache to hold a reference to RemoveButton2 of type Button
        /// </summary>
        private Button cachedRemoveButton2;

        /// <summary>
        /// Cache to hold a reference to IncludeObjectsOfTheFollowingTypesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedIncludeObjectsOfTheFollowingTypesStaticControl;

        /// <summary>
        /// Cache to hold a reference to AddButton2 of type Button
        /// </summary>
        private Button cachedAddButton2;

        /// <summary>
        /// Cache to hold a reference to IncludeObjectsOfTheFollowingTypesListView of type ListView
        /// </summary>
        private ListView cachedIncludeObjectsOfTheFollowingTypesListView;

        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of OptionsInAddGroupDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[a-omkasi] 8/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public OptionsInAddGroupDialog(MomConsoleApp app)
            :
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion

        #region IOptionsInAddGroupDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[a-omkasi] 8/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IOptionsInAddGroupDialogControls Controls
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
        ///  Routine to set/get the text in control SearchTimeIntervalStartDate
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[a-omkasi] 8/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SearchTimeIntervalStartDateText
        {
            get
            {
                return this.Controls.SearchTimeIntervalStartDateComboBox.Text;
            }

            set
            {
                this.Controls.SearchTimeIntervalStartDateComboBox.SelectByText(value, true);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control SearchTimeIntervalEndDate
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[a-omkasi] 8/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SearchTimeIntervalEndDateText
        {
            get
            {
                return this.Controls.SearchTimeIntervalEndDateComboBox.Text;
            }

            set
            {
                this.Controls.SearchTimeIntervalEndDateComboBox.SelectByText(value, true);
            }
        }
        #endregion

        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SearchTimeIntervalStartDateStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptionsInAddGroupDialogControls.SearchTimeIntervalStartDateStaticControl
        {
            get
            {
                if ((this.cachedSearchTimeIntervalStartDateStaticControl == null))
                {
                    this.cachedSearchTimeIntervalStartDateStaticControl = new StaticControl(this, OptionsInAddGroupDialog.ControlIDs.SearchTimeIntervalStartDateStaticControl);
                }

                return this.cachedSearchTimeIntervalStartDateStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IncludeObjectsFromTheFollowingManagementGroupsStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptionsInAddGroupDialogControls.IncludeObjectsFromTheFollowingManagementGroupsStaticControl
        {
            get
            {
                if ((this.cachedIncludeObjectsFromTheFollowingManagementGroupsStaticControl == null))
                {
                    this.cachedIncludeObjectsFromTheFollowingManagementGroupsStaticControl = new StaticControl(this, OptionsInAddGroupDialog.ControlIDs.IncludeObjectsFromTheFollowingManagementGroupsStaticControl);
                }

                return this.cachedIncludeObjectsFromTheFollowingManagementGroupsStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SearchTimeIntervalEndDateListBox control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListBox IOptionsInAddGroupDialogControls.SearchTimeIntervalEndDateListBox
        {
            get
            {
                if ((this.cachedSearchTimeIntervalEndDateListBox == null))
                {
                    this.cachedSearchTimeIntervalEndDateListBox = new ListBox(this, OptionsInAddGroupDialog.ControlIDs.SearchTimeIntervalEndDateListBox);
                }

                return this.cachedSearchTimeIntervalEndDateListBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SearchTimeIntervalStartDateComboBox control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IOptionsInAddGroupDialogControls.SearchTimeIntervalStartDateComboBox
        {
            get
            {
                if ((this.cachedSearchTimeIntervalStartDateComboBox == null))
                {
                    this.cachedSearchTimeIntervalStartDateComboBox = new ComboBox(this, OptionsInAddGroupDialog.ControlIDs.SearchTimeIntervalStartDateComboBox);
                }

                return this.cachedSearchTimeIntervalStartDateComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SearchTimeIntervalEndDateComboBox control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IOptionsInAddGroupDialogControls.SearchTimeIntervalEndDateComboBox
        {
            get
            {
                if ((this.cachedSearchTimeIntervalEndDateComboBox == null))
                {
                    this.cachedSearchTimeIntervalEndDateComboBox = new ComboBox(this, OptionsInAddGroupDialog.ControlIDs.SearchTimeIntervalEndDateComboBox);
                }

                return this.cachedSearchTimeIntervalEndDateComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SearchTimeIntervalEndDateStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptionsInAddGroupDialogControls.SearchTimeIntervalEndDateStaticControl
        {
            get
            {
                if ((this.cachedSearchTimeIntervalEndDateStaticControl == null))
                {
                    this.cachedSearchTimeIntervalEndDateStaticControl = new StaticControl(this, OptionsInAddGroupDialog.ControlIDs.SearchTimeIntervalEndDateStaticControl);
                }

                return this.cachedSearchTimeIntervalEndDateStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RemoveButton control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IOptionsInAddGroupDialogControls.RemoveButton
        {
            get
            {
                if ((this.cachedRemoveButton == null))
                {
                    this.cachedRemoveButton = new Button(this, OptionsInAddGroupDialog.ControlIDs.RemoveButton);
                }

                return this.cachedRemoveButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IncludeGroupsOfTheFollowingTypesStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptionsInAddGroupDialogControls.IncludeGroupsOfTheFollowingTypesStaticControl
        {
            get
            {
                if ((this.cachedIncludeGroupsOfTheFollowingTypesStaticControl == null))
                {
                    this.cachedIncludeGroupsOfTheFollowingTypesStaticControl = new StaticControl(this, OptionsInAddGroupDialog.ControlIDs.IncludeGroupsOfTheFollowingTypesStaticControl);
                }

                return this.cachedIncludeGroupsOfTheFollowingTypesStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddButton control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IOptionsInAddGroupDialogControls.AddButton
        {
            get
            {
                if ((this.cachedAddButton == null))
                {
                    CoreManager.MomConsole.Waiters.WaitForWindowAppeared(this, new QID(";[UIA]AutomationId = '" + OptionsInAddGroupDialog.ControlIDs.AddButton + "'"), 10); 
                    this.cachedAddButton = new Button(this, OptionsInAddGroupDialog.ControlIDs.AddButton);
                }

                return this.cachedAddButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IncludeGroupsOfTheFollowingTypesListView control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IOptionsInAddGroupDialogControls.IncludeGroupsOfTheFollowingTypesListView
        {
            get
            {
                if ((this.cachedIncludeGroupsOfTheFollowingTypesListView == null))
                {
                    this.cachedIncludeGroupsOfTheFollowingTypesListView = new ListView(this, OptionsInAddGroupDialog.ControlIDs.IncludeGroupsOfTheFollowingTypesListView);
                }

                return this.cachedIncludeGroupsOfTheFollowingTypesListView;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IOptionsInAddGroupDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, OptionsInAddGroupDialog.ControlIDs.CancelButton);
                }

                return this.cachedCancelButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RemoveButton2 control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IOptionsInAddGroupDialogControls.RemoveButton2
        {
            get
            {
                // The ID for this control (RemoveTypes) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedRemoveButton2 == null))
                {
                    Window wndTemp = this;

                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i < 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedRemoveButton2 = new Button(wndTemp);
                }

                return this.cachedRemoveButton2;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IncludeObjectsOfTheFollowingTypesStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptionsInAddGroupDialogControls.IncludeObjectsOfTheFollowingTypesStaticControl
        {
            get
            {
                // The ID for this control (typeLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedIncludeObjectsOfTheFollowingTypesStaticControl == null))
                {
                    Window wndTemp = this;

                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    this.cachedIncludeObjectsOfTheFollowingTypesStaticControl = new StaticControl(wndTemp);
                }

                return this.cachedIncludeObjectsOfTheFollowingTypesStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddButton2 control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IOptionsInAddGroupDialogControls.AddButton2
        {
            get
            {
                // The ID for this control (AddTypes) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedAddButton2 == null))
                {
                    Window wndTemp = this;

                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i < 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    this.cachedAddButton2 = new Button(wndTemp);
                }

                return this.cachedAddButton2;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IncludeObjectsOfTheFollowingTypesListView control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IOptionsInAddGroupDialogControls.IncludeObjectsOfTheFollowingTypesListView
        {
            get
            {
                // The ID for this control (typeDisplayView) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedIncludeObjectsOfTheFollowingTypesListView == null))
                {
                    Window wndTemp = this;

                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i < 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    this.cachedIncludeObjectsOfTheFollowingTypesListView = new ListView(wndTemp);
                }

                return this.cachedIncludeObjectsOfTheFollowingTypesListView;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IOptionsInAddGroupDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, OptionsInAddGroupDialog.ControlIDs.OKButton);
                }

                return this.cachedOKButton;
            }
        }
        #endregion

        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Remove
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickRemove()
        {
            if (this.Controls.RemoveButton.IsEnabled)
            {
                this.Controls.RemoveButton.Click();
            }
            else
            {
                System.Console.WriteLine("Button: " + this.Controls.RemoveButton.Caption + " is NOT enabled");
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Add
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAdd()
        {
            if (this.Controls.AddButton.IsEnabled)
            {
                this.Controls.AddButton.Click();
            }
            else
            {
                System.Console.WriteLine("Button: " + this.Controls.AddButton.Caption + " is NOT enabled");
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            if (this.Controls.CancelButton.IsEnabled)
            {
                this.Controls.CancelButton.Click();
            }
            else
            {
                System.Console.WriteLine("Button: " + this.Controls.CancelButton.Caption + " is NOT enabled");
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Remove2
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickRemove2()
        {
            if (this.Controls.RemoveButton2.IsEnabled)
            {
                this.Controls.RemoveButton2.Click();
            }
            else
            {
                System.Console.WriteLine("Button: " + this.Controls.RemoveButton2.Caption + " is NOT enabled");
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Add2
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAdd2()
        {
            if (this.Controls.AddButton2.IsEnabled)
            {
                this.Controls.AddButton2.Click();
            }
            else
            {
                System.Console.WriteLine("Button: " + this.Controls.AddButton2.Caption + " is NOT enabled");
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            if (this.Controls.OKButton.IsEnabled)
            {
                this.Controls.OKButton.Click();
            }
            else
            {
                System.Console.WriteLine("Button: " + this.Controls.OKButton.Caption + " is NOT enabled");
            }
        }
        #endregion

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">MomConsoleApp owning the dialog.</param>
        /// <history>
        /// 	[a-omkasi] 8/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
            }
            catch (Exceptions.WindowNotFoundException )
            {
                // Reset the window reference
                tempWindow = null;

                // Maximum number of tries to find window
                int maxTries = 15;

                // Try several more times to find the window
                for (int numberOfTries = 0; ((null == tempWindow)
                            && (numberOfTries < maxTries)); numberOfTries = (numberOfTries + 1))
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
                        // log the unsuccessful attempt
                        Mom.Test.UI.Core.Common.Utilities.LogMessage("Attempt " + numberOfTries + " of " + maxTries);
                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }

                //// check for success
                //if ((null == tempWindow))
                //{
                //    // log the failure

                //    // rethrow the original exception
                //    throw windowNotFound;
                //}
            }

            return tempWindow;
        }

        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/12/2008 Created
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
            private const string ResourceDialogTitle = ";Options;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitoring.ReportMonitoringOptionDialog;$this.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SearchTimeIntervalStartDate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSearchTimeIntervalStartDate = ";Search time interval start date:;ManagedString;Microsoft.EnterpriseManagement.UI" +
                ".Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Paramete" +
                "rs.Controls.Monitoring.ReportMonitoringPerformanceRuleSearchCriteria;startDateLa" +
                "bel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  IncludeObjectsFromTheFollowingManagementGroups
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceIncludeObjectsFromTheFollowingManagementGroups = @";Include objects from the following Management Groups:;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitoring.ReportMonitoringSearchTypesCriteria;groupLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SearchTimeIntervalEndDate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSearchTimeIntervalEndDate = ";Search time interval end date:;ManagedString;Microsoft.EnterpriseManagement.UI.R" +
                "eporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters" +
                ".Controls.Monitoring.ReportMonitoringPerformanceRuleSearchCriteria;endDateLabel." +
                "Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Remove
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRemove = ";R&emove;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft." +
                "EnterpriseManagement.Internal.UI.Authoring.Pages.DiagAndRecoveryPage;diagRemoveB" +
                "utton.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  IncludeGroupsOfTheFollowingTypes
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceIncludeGroupsOfTheFollowingTypes = "Include groups of the following types:";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Add
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdd = ";A&dd...;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.EmailNoti" +
                "fication;add.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Remove2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRemove2 = ";&Remove;ManagedString;Corgent.Diagramming.CommandResources.dll;Corgent.Diagrammi" +
                "ng.CommandResources.Properties.Resources;Command_Remove";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  IncludeObjectsOfTheFollowingTypes
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceIncludeObjectsOfTheFollowingTypes = "Include objects of the following types:";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Add2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdd2 = ";&Add...;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.MPInstall.MPInstallDial" +
                "og;menuAdd.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.Tr" +
                "anslucentColorPicker;buttonOk.Text";
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
            /// Caches the translated resource string for:  SearchTimeIntervalStartDate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSearchTimeIntervalStartDate;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  IncludeObjectsFromTheFollowingManagementGroups
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedIncludeObjectsFromTheFollowingManagementGroups;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SearchTimeIntervalEndDate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSearchTimeIntervalEndDate;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Remove
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRemove;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  IncludeGroupsOfTheFollowingTypes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedIncludeGroupsOfTheFollowingTypes;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Add
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdd;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Remove2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRemove2;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  IncludeObjectsOfTheFollowingTypes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedIncludeObjectsOfTheFollowingTypes;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Add2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdd2;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;
            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 8/12/2008 Created
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
            /// Exposes access to the SearchTimeIntervalStartDate translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 8/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SearchTimeIntervalStartDate
            {
                get
                {
                    if ((cachedSearchTimeIntervalStartDate == null))
                    {
                        cachedSearchTimeIntervalStartDate = CoreManager.MomConsole.GetIntlStr(ResourceSearchTimeIntervalStartDate);
                    }

                    return cachedSearchTimeIntervalStartDate;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the IncludeObjectsFromTheFollowingManagementGroups translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 8/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string IncludeObjectsFromTheFollowingManagementGroups
            {
                get
                {
                    if ((cachedIncludeObjectsFromTheFollowingManagementGroups == null))
                    {
                        cachedIncludeObjectsFromTheFollowingManagementGroups = CoreManager.MomConsole.GetIntlStr(ResourceIncludeObjectsFromTheFollowingManagementGroups);
                    }

                    return cachedIncludeObjectsFromTheFollowingManagementGroups;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SearchTimeIntervalEndDate translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 8/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SearchTimeIntervalEndDate
            {
                get
                {
                    if ((cachedSearchTimeIntervalEndDate == null))
                    {
                        cachedSearchTimeIntervalEndDate = CoreManager.MomConsole.GetIntlStr(ResourceSearchTimeIntervalEndDate);
                    }

                    return cachedSearchTimeIntervalEndDate;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Remove translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 8/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Remove
            {
                get
                {
                    if ((cachedRemove == null))
                    {
                        cachedRemove = CoreManager.MomConsole.GetIntlStr(ResourceRemove);
                    }

                    return cachedRemove;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the IncludeGroupsOfTheFollowingTypes translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 8/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string IncludeGroupsOfTheFollowingTypes
            {
                get
                {
                    if ((cachedIncludeGroupsOfTheFollowingTypes == null))
                    {
                        cachedIncludeGroupsOfTheFollowingTypes = CoreManager.MomConsole.GetIntlStr(ResourceIncludeGroupsOfTheFollowingTypes);
                    }

                    return cachedIncludeGroupsOfTheFollowingTypes;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Add translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 8/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Add
            {
                get
                {
                    if ((cachedAdd == null))
                    {
                        cachedAdd = CoreManager.MomConsole.GetIntlStr(ResourceAdd);
                    }

                    return cachedAdd;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 8/12/2008 Created
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
            /// Exposes access to the Remove2 translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 8/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Remove2
            {
                get
                {
                    if ((cachedRemove2 == null))
                    {
                        cachedRemove2 = CoreManager.MomConsole.GetIntlStr(ResourceRemove2);
                    }

                    return cachedRemove2;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the IncludeObjectsOfTheFollowingTypes translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 8/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string IncludeObjectsOfTheFollowingTypes
            {
                get
                {
                    if ((cachedIncludeObjectsOfTheFollowingTypes == null))
                    {
                        cachedIncludeObjectsOfTheFollowingTypes = CoreManager.MomConsole.GetIntlStr(ResourceIncludeObjectsOfTheFollowingTypes);
                    }

                    return cachedIncludeObjectsOfTheFollowingTypes;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Add2 translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 8/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Add2
            {
                get
                {
                    if ((cachedAdd2 == null))
                    {
                        cachedAdd2 = CoreManager.MomConsole.GetIntlStr(ResourceAdd2);
                    }

                    return cachedAdd2;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 8/12/2008 Created
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
            #endregion
        }
        #endregion

        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for SearchTimeIntervalStartDateStaticControl
            /// </summary>
            public const string SearchTimeIntervalStartDateStaticControl = "startDateLabel";

            /// <summary>
            /// Control ID for IncludeObjectsFromTheFollowingManagementGroupsStaticControl
            /// </summary>
            public const string IncludeObjectsFromTheFollowingManagementGroupsStaticControl = "groupLabel";

            /// <summary>
            /// Control ID for SearchTimeIntervalEndDateListBox
            /// </summary>
            public const string SearchTimeIntervalEndDateListBox = "groupEditor";

            /// <summary>
            /// Control ID for SearchTimeIntervalStartDateComboBox
            /// </summary>
            public const string SearchTimeIntervalStartDateComboBox = "startDateEditor";

            /// <summary>
            /// Control ID for SearchTimeIntervalEndDateComboBox
            /// </summary>
            public const string SearchTimeIntervalEndDateComboBox = "endDateEditor";

            /// <summary>
            /// Control ID for SearchTimeIntervalEndDateStaticControl
            /// </summary>
            public const string SearchTimeIntervalEndDateStaticControl = "endDateLabel";

            /// <summary>
            /// Control ID for RemoveButton
            /// </summary>
            public const string RemoveButton = "RemoveTypes";

            /// <summary>
            /// Control ID for IncludeGroupsOfTheFollowingTypesStaticControl
            /// </summary>
            public const string IncludeGroupsOfTheFollowingTypesStaticControl = "typeLabel";

            /// <summary>
            /// Control ID for AddButton
            /// </summary>
            public const string AddButton = "AddTypes";

            /// <summary>
            /// Control ID for IncludeGroupsOfTheFollowingTypesListView
            /// </summary>
            public const string IncludeGroupsOfTheFollowingTypesListView = "typeDisplayView";

            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "Cancel_Options";

            /// <summary>
            /// Control ID for RemoveButton2
            /// </summary>
            public const string RemoveButton2 = "RemoveTypes";

            /// <summary>
            /// Control ID for IncludeObjectsOfTheFollowingTypesStaticControl
            /// </summary>
            public const string IncludeObjectsOfTheFollowingTypesStaticControl = "typeLabel";

            /// <summary>
            /// Control ID for AddButton2
            /// </summary>
            public const string AddButton2 = "AddTypes";

            /// <summary>
            /// Control ID for IncludeObjectsOfTheFollowingTypesListView
            /// </summary>
            public const string IncludeObjectsOfTheFollowingTypesListView = "typeDisplayView";

            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "OK_Options";
        }
        #endregion
    }
}
