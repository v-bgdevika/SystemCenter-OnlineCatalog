// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SelectMPsFromCatalogDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[zhihaoq] 10/18/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MP.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;

    #region Interface Definition - ISelectMPsFromCatalogDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISelectMPsFromCatalogDialogControls, for SelectMPsFromCatalogDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[zhihaoq] 10/18/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISelectMPsFromCatalogDialogControls
    {
        /// <summary>
        /// Read-only property to access ClearButton
        /// </summary>
        Button ClearButton
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
        /// Read-only property to access FindTextBox
        /// </summary>
        TextBox FindTextBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access FindToolStrip
        /// </summary>
        Toolbar FindToolStrip
        {
            get;
        }

        /// <summary>
        /// Read-only property to access TextBoxLookFor
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TextBox TextBoxLookFor
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ComboBox1
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        ComboBox ComboBox1
        {
            get;
        }

        /// <summary>
        /// Read-only property to access SelectOneOrMoreManagementPacksInTheCatalogListAndClickSelectStaticControl
        /// </summary>
        StaticControl SelectOneOrMoreManagementPacksInTheCatalogListAndClickSelectStaticControl
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
        /// Read-only property to access AddButton
        /// </summary>
        Button AddButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ManagementPacksInTheCatalogStaticControl
        /// </summary>
        StaticControl ManagementPacksInTheCatalogStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access SelectButton
        /// </summary>
        Button SelectButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access SelectedManagementPacksStaticControl
        /// </summary>
        StaticControl SelectedManagementPacksStaticControl
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
        /// Read-only property to access SelectedManagementPacksPropertyGridView
        /// </summary>
        PropertyGridView SelectedManagementPacksPropertyGridView
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
        /// Read-only property to access ManagementPacksInTheCatalogPropertyGridView
        /// </summary>
        PropertyGridView ManagementPacksInTheCatalogPropertyGridView
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
    /// 	[zhihaoq] 10/18/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SelectMPsFromCatalogDialog : Dialog, ISelectMPsFromCatalogDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion

        #region Private Member Variables
        /// <summary>
        /// Cache to hold a reference to ClearButton of type Button
        /// </summary>
        private Button cachedClearButton;

        /// <summary>
        /// Cache to hold a reference to SearchButton of type Button
        /// </summary>
        private Button cachedSearchButton;
        /// <summary>
        /// Cache to hold a reference to FindTextBox of type TextBox
        /// </summary>
        private TextBox cachedFindTextBox;

        /// <summary>
        /// Cache to hold a reference to FindToolStrip of type Toolbar
        /// </summary>
        private Toolbar cachedFindToolStrip;

        /// <summary>
        /// Cache to hold a reference to TextBoxLookFor of type TextBox
        /// </summary>
        private TextBox cachedTextBoxLookFor;

        /// <summary>
        /// Cache to hold a reference to ComboBox1 of type ComboBox
        /// </summary>
        private ComboBox cachedComboBox1;

        /// <summary>
        /// Cache to hold a reference to SelectOneOrMoreManagementPacksInTheCatalogListAndClickSelectStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectOneOrMoreManagementPacksInTheCatalogListAndClickSelectStaticControl;

        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;

        /// <summary>
        /// Cache to hold a reference to AddButton of type Button
        /// </summary>
        private Button cachedAddButton;

        /// <summary>
        /// Cache to hold a reference to ManagementPacksInTheCatalogStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedManagementPacksInTheCatalogStaticControl;

        /// <summary>
        /// Cache to hold a reference to SelectButton of type Button
        /// </summary>
        private Button cachedSelectButton;

        /// <summary>
        /// Cache to hold a reference to SelectedManagementPacksStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectedManagementPacksStaticControl;

        /// <summary>
        /// Cache to hold a reference to RemoveButton of type Button
        /// </summary>
        private Button cachedRemoveButton;

        /// <summary>
        /// Cache to hold a reference to SelectedManagementPacksPropertyGridView of type PropertyGridView
        /// </summary>
        private PropertyGridView cachedSelectedManagementPacksPropertyGridView;

        /// <summary>
        /// Cache to hold a reference to ToolStrip1 of type Toolbar
        /// </summary>
        private Toolbar cachedToolStrip1;

        /// <summary>
        /// Cache to hold a reference to ManagementPacksInTheCatalogPropertyGridView of type PropertyGridView
        /// </summary>
        private PropertyGridView cachedManagementPacksInTheCatalogPropertyGridView;
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of SelectMPsFromCatalogDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SelectMPsFromCatalogDialog(ConsoleApp app) :
            base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion

        #region ISelectMPsFromCatalogDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISelectMPsFromCatalogDialogControls Controls
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
        ///  Routine to set/get the text in control Find
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[asttest] 2/5/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string FindText
        {
            get
            {
                return this.Controls.FindTextBox.Text;
            }

            set
            {
                this.Controls.FindTextBox.Text = value;
            }
        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TextBoxLookFor
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TextBoxLookForText
        {
            get
            {
                return this.Controls.TextBoxLookFor.Text;
            }

            set
            {
                this.Controls.TextBoxLookFor.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ComboBox1
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ComboBox1Text
        {
            get
            {
                return this.Controls.ComboBox1.Text;
            }

            set
            {
                this.Controls.ComboBox1.SelectByText(value, true);
            }
        }
        #endregion

        #region Control Properties
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ClearButton control
        /// </summary>
        /// <history>
        /// 	[asttest] 2/5/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectMPsFromCatalogDialogControls.ClearButton
        {
            get
            {
                if ((this.cachedClearButton == null))
                {
                    this.cachedClearButton = new Button(this, SelectMPsFromCatalogDialog.ControlIDs.ClearButton);
                }
                return this.cachedClearButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SearchButton control
        /// </summary>
        /// <history>
        /// 	[asttest] 2/5/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectMPsFromCatalogDialogControls.SearchButton
        {
            get
            {
                if ((this.cachedSearchButton == null))
                {
                    this.cachedSearchButton = new Button(this, SelectMPsFromCatalogDialog.ControlIDs.SearchButton);
                }
                return this.cachedSearchButton;
            }
        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FindTextBox control
        /// </summary>
        /// <history>
        /// 	[asttest] 2/5/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ISelectMPsFromCatalogDialogControls.FindTextBox
        {
            get
            {
                if ((this.cachedFindTextBox == null))
                {
                    this.cachedFindTextBox = new TextBox(this, SelectMPsFromCatalogDialog.ControlIDs.FindTextBox);
                }
                return this.cachedFindTextBox;
            }
        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FindToolStrip control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar ISelectMPsFromCatalogDialogControls.FindToolStrip
        {
            get
            {
                if ((this.cachedFindToolStrip == null))
                {
                    this.cachedFindToolStrip = new Toolbar(this);
                }
                return this.cachedFindToolStrip;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TextBoxLookFor control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ISelectMPsFromCatalogDialogControls.TextBoxLookFor
        {
            get
            {
                if ((this.cachedTextBoxLookFor == null))
                {
                    Window wndTemp = this;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedTextBoxLookFor = new TextBox(wndTemp);
                }
                return this.cachedTextBoxLookFor;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ComboBox1 control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ISelectMPsFromCatalogDialogControls.ComboBox1
        {
            get
            {
                if ((this.cachedComboBox1 == null))
                {
                    this.cachedComboBox1 = new ComboBox(this, SelectMPsFromCatalogDialog.ControlIDs.FilterComboBox);
                }
                return this.cachedComboBox1;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectOneOrMoreManagementPacksInTheCatalogListAndClickSelectStaticControl control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectMPsFromCatalogDialogControls.SelectOneOrMoreManagementPacksInTheCatalogListAndClickSelectStaticControl
        {
            get
            {
                if ((this.cachedSelectOneOrMoreManagementPacksInTheCatalogListAndClickSelectStaticControl == null))
                {
                    this.cachedSelectOneOrMoreManagementPacksInTheCatalogListAndClickSelectStaticControl = new StaticControl(this, SelectMPsFromCatalogDialog.ControlIDs.SelectOneOrMoreManagementPacksInTheCatalogListAndClickSelectStaticControl);
                }
                return this.cachedSelectOneOrMoreManagementPacksInTheCatalogListAndClickSelectStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectMPsFromCatalogDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, SelectMPsFromCatalogDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddButton control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectMPsFromCatalogDialogControls.AddButton
        {
            get
            {
                if ((this.cachedAddButton == null))
                {
                    this.cachedAddButton = new Button(this, SelectMPsFromCatalogDialog.ControlIDs.AddButton);
                }
                return this.cachedAddButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementPacksInTheCatalogStaticControl control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectMPsFromCatalogDialogControls.ManagementPacksInTheCatalogStaticControl
        {
            get
            {
                if ((this.cachedManagementPacksInTheCatalogStaticControl == null))
                {
                    this.cachedManagementPacksInTheCatalogStaticControl = new StaticControl(this, SelectMPsFromCatalogDialog.ControlIDs.ManagementPacksInTheCatalogStaticControl);
                }
                return this.cachedManagementPacksInTheCatalogStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectButton control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectMPsFromCatalogDialogControls.SelectButton
        {
            get
            {
                if ((this.cachedSelectButton == null))
                {
                    this.cachedSelectButton = new Button(this, SelectMPsFromCatalogDialog.ControlIDs.SelectButton);
                }
                return this.cachedSelectButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectedManagementPacksStaticControl control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectMPsFromCatalogDialogControls.SelectedManagementPacksStaticControl
        {
            get
            {
                if ((this.cachedSelectedManagementPacksStaticControl == null))
                {
                    this.cachedSelectedManagementPacksStaticControl = new StaticControl(this, SelectMPsFromCatalogDialog.ControlIDs.SelectedManagementPacksStaticControl);
                }
                return this.cachedSelectedManagementPacksStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RemoveButton control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectMPsFromCatalogDialogControls.RemoveButton
        {
            get
            {
                if ((this.cachedRemoveButton == null))
                {
                    this.cachedRemoveButton = new Button(this, SelectMPsFromCatalogDialog.ControlIDs.RemoveButton);
                }
                return this.cachedRemoveButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectedManagementPacksPropertyGridView control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        PropertyGridView ISelectMPsFromCatalogDialogControls.SelectedManagementPacksPropertyGridView
        {
            get
            {
                if ((this.cachedSelectedManagementPacksPropertyGridView == null))
                {
                    this.cachedSelectedManagementPacksPropertyGridView = new PropertyGridView(this, SelectMPsFromCatalogDialog.ControlIDs.SelectedManagementPacksPropertyGridView);
                }
                return this.cachedSelectedManagementPacksPropertyGridView;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToolStrip1 control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar ISelectMPsFromCatalogDialogControls.ToolStrip1
        {
            get
            {
                if ((this.cachedToolStrip1 == null))
                {
                    this.cachedToolStrip1 = new Toolbar(this, SelectMPsFromCatalogDialog.ControlIDs.ToolStrip1);
                }
                return this.cachedToolStrip1;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementPacksInTheCatalogPropertyGridView control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        PropertyGridView ISelectMPsFromCatalogDialogControls.ManagementPacksInTheCatalogPropertyGridView
        {
            get
            {
                if ((this.cachedManagementPacksInTheCatalogPropertyGridView == null))
                {
                    this.cachedManagementPacksInTheCatalogPropertyGridView = new PropertyGridView(this, SelectMPsFromCatalogDialog.ControlIDs.ManagementPacksInTheCatalogPropertyGridView);
                }
                return this.cachedManagementPacksInTheCatalogPropertyGridView;
            }
        }
        #endregion

        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }


        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Clear
        /// </summary>
        /// <history>
        /// 	[asttest] 2/5/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickClear()
        {
            this.Controls.ClearButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Search
        /// </summary>
        /// <history>
        /// 	[asttest] 2/5/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSearch()
        {
            this.Controls.SearchButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Add
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAdd()
        {
            this.Controls.AddButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Select
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSelect()
        {
            this.Controls.SelectButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Remove
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickRemove()
        {
            this.Controls.RemoveButton.Click();
        }
        #endregion

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">ConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
            }

            catch (Exceptions.WindowNotFoundException windowNotFound)
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
                                Strings.DialogTitle + "*",
                                StringMatchSyntax.WildCard
                                );

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage(
                            "Attempt" + numberOfTries + " of " + MaxTries);

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find window with title: '" + Strings.DialogTitle + "'");

                    // throw the existing WindowNotFound exception
                    throw windowNotFound;
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
        /// 	[zhihaoq] 10/18/2008 Created
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
            /// <history>
            ///  [sunsingh] 1/27/2009 Updated ResourceDialogTitle to correct resource string
            /// </history>
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle = ";Select Management Packs from Catalog;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.Dialogs.MPCatalogDialog;$this.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  FindToolStrip
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFindToolStrip = ";toolStrip2;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Mi" +
                "crosoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall" +
                ".Dialogs.MPCatalogDialog;toolStrip2.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectOneOrMoreManagementPacksInTheCatalogListAndClickSelect
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectOneOrMoreManagementPacksInTheCatalogListAndClickSelect = @";Select one or more management packs in the catalog list and click Select.;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.Dialogs.MPCatalogDialog;infoLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Add
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdd = ";&Add;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsof" +
                "t.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.Wizar" +
                "ds.Install.SelectInstallMPsPage;addButton.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ManagementPacksInTheCatalog
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceManagementPacksInTheCatalog = ";&Management packs in the catalog;ManagedString;Microsoft.EnterpriseManagement.UI" +
                ".Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administratio" +
                "n.MPDownloadAndInstall.Dialogs.MPCatalogDialog;catalogListLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Select
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelect = ";&Select;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.Di" +
                "alogs.MPCatalogDialog;selectButton.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectedManagementPacks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectedManagementPacks = ";S&elected management packs : ;ManagedString;Microsoft.EnterpriseManagement.UI.Ad" +
                "ministration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.M" +
                "PDownloadAndInstall.Dialogs.MPCatalogDialog;selectedListLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Remove
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRemove = ";&Remove;ManagedString;Corgent.Diagramming.CommandResources.dll;Corgent.Diagrammi" +
                "ng.CommandResources.Properties.Resources;Command_Remove";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ToolStrip1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceToolStrip1 = ";toolStrip1;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Mi" +
                "crosoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall" +
                ".Wizards.Install.SelectInstallMPsPage;buttonsToolStrip.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  FilterViewAllMPsInCatalog
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFilterViewAllMPsInCatalog = ";All management packs in the catalog;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.Dialogs.MPCatalogDialog;filterComboBox.Items";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  FilterViewMPUPdatesAvailable
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFilterViewMPUPdatesAvailable = ";Updates available for installed management packs;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.Dialogs.MPCatalogDialog;filterComboBox.Items1";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  FilterViewMPReleasedLast3Month
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFilterViewMPReleasedLast3Month = ";All management packs released within last 3 months;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.Dialogs.MPCatalogDialog;filterComboBox.Items2";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  FilterViewMPReleasedLast6Month
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFilterViewMPReleasedLast6Month = ";All management packs released within last 6 months;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.Dialogs.MPCatalogDialog;filterComboBox.Items3";

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
            /// Caches the translated resource string for:  FindToolStrip
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFindToolStrip;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectOneOrMoreManagementPacksInTheCatalogListAndClickSelect
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectOneOrMoreManagementPacksInTheCatalogListAndClickSelect;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Add
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdd;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ManagementPacksInTheCatalog
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedManagementPacksInTheCatalog;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Select
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelect;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectedManagementPacks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectedManagementPacks;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Remove
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRemove;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ToolStrip1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedToolStrip1;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  FilterViewAllMPsInCatalog
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFilterViewAllMPsInCatalog;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  FilterViewMPUPdatesAvailable
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFilterViewMPUPdatesAvailable;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  FilterViewMPReleasedLast3Month
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFilterViewMPReleasedLast3Month;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  FilterViewMPReleasedLast6Month
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFilterViewMPReleasedLast6Month;
            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 10/18/2008 Created
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
            /// Exposes access to the FindToolStrip translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 10/18/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FindToolStrip
            {
                get
                {
                    if ((cachedFindToolStrip == null))
                    {
                        cachedFindToolStrip = CoreManager.MomConsole.GetIntlStr(ResourceFindToolStrip);
                    }
                    return cachedFindToolStrip;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectOneOrMoreManagementPacksInTheCatalogListAndClickSelect translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 10/18/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectOneOrMoreManagementPacksInTheCatalogListAndClickSelect
            {
                get
                {
                    if ((cachedSelectOneOrMoreManagementPacksInTheCatalogListAndClickSelect == null))
                    {
                        cachedSelectOneOrMoreManagementPacksInTheCatalogListAndClickSelect = CoreManager.MomConsole.GetIntlStr(ResourceSelectOneOrMoreManagementPacksInTheCatalogListAndClickSelect);
                    }
                    return cachedSelectOneOrMoreManagementPacksInTheCatalogListAndClickSelect;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 10/18/2008 Created
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
            /// Exposes access to the Add translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 10/18/2008 Created
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
            /// Exposes access to the ManagementPacksInTheCatalog translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 10/18/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ManagementPacksInTheCatalog
            {
                get
                {
                    if ((cachedManagementPacksInTheCatalog == null))
                    {
                        cachedManagementPacksInTheCatalog = CoreManager.MomConsole.GetIntlStr(ResourceManagementPacksInTheCatalog);
                    }
                    return cachedManagementPacksInTheCatalog;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Select translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 10/18/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Select
            {
                get
                {
                    if ((cachedSelect == null))
                    {
                        cachedSelect = CoreManager.MomConsole.GetIntlStr(ResourceSelect);
                    }
                    return cachedSelect;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectedManagementPacks translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 10/18/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectedManagementPacks
            {
                get
                {
                    if ((cachedSelectedManagementPacks == null))
                    {
                        cachedSelectedManagementPacks = CoreManager.MomConsole.GetIntlStr(ResourceSelectedManagementPacks);
                    }
                    return cachedSelectedManagementPacks;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Remove translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 10/18/2008 Created
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
            /// Exposes access to the FilterViewAllMPsInCatalog translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 10/18/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FilterViewAllMPsInCatalog
            {
                get
                {
                    if ((cachedFilterViewAllMPsInCatalog == null))
                    {
                        cachedFilterViewAllMPsInCatalog = CoreManager.MomConsole.GetIntlStr(ResourceFilterViewAllMPsInCatalog);
                    }
                    return cachedFilterViewAllMPsInCatalog;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the FilterViewMPUPdatesAvailable translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 10/18/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FilterViewMPUPdatesAvailable
            {
                get
                {
                    if ((cachedFilterViewMPUPdatesAvailable == null))
                    {
                        cachedFilterViewMPUPdatesAvailable = CoreManager.MomConsole.GetIntlStr(ResourceFilterViewMPUPdatesAvailable);
                    }
                    return cachedFilterViewMPUPdatesAvailable;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the FilterViewMPReleasedLast3Month translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 10/18/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FilterViewMPReleasedLast3Month
            {
                get
                {
                    if ((cachedFilterViewMPReleasedLast3Month == null))
                    {
                        cachedFilterViewMPReleasedLast3Month = CoreManager.MomConsole.GetIntlStr(ResourceFilterViewMPReleasedLast3Month);
                    }
                    return cachedFilterViewMPReleasedLast3Month;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the FilterViewMPReleasedLast6Month translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 10/18/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FilterViewMPReleasedLast6Month
            {
                get
                {
                    if ((cachedFilterViewMPReleasedLast6Month == null))
                    {
                        cachedFilterViewMPReleasedLast6Month = CoreManager.MomConsole.GetIntlStr(ResourceFilterViewMPReleasedLast6Month);
                    }
                    return cachedFilterViewMPReleasedLast6Month;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ToolStrip1 translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 10/18/2008 Created
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
            #endregion
        }
        #endregion

        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ClearButton
            /// </summary>
            public const string ClearButton = "clearButton";

            /// <summary>
            /// Control ID for SearchButton
            /// </summary>
            public const string SearchButton = "searchButton";

            /// <summary>
            /// Control ID for FindTextBox
            /// </summary>
            public const string FindTextBox = "findTextBox";
            /// <summary>
            /// Control ID for FindToolStrip
            /// </summary>
            public const string FindToolStrip = "toolStrip2";

            /// <summary>
            /// Control ID for SelectOneOrMoreManagementPacksInTheCatalogListAndClickSelectStaticControl
            /// </summary>
            public const string SelectOneOrMoreManagementPacksInTheCatalogListAndClickSelectStaticControl = "infoLabel";

            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";

            /// <summary>
            /// Control ID for AddButton
            /// </summary>
            public const string AddButton = "addButton";

            /// <summary>
            /// Control ID for ManagementPacksInTheCatalogStaticControl
            /// </summary>
            public const string ManagementPacksInTheCatalogStaticControl = "catalogListLabel";

            /// <summary>
            /// Control ID for SelectButton
            /// </summary>
            public const string SelectButton = "selectButton";

            /// <summary>
            /// Control ID for SelectedManagementPacksStaticControl
            /// </summary>
            public const string SelectedManagementPacksStaticControl = "selectedListLabel";

            /// <summary>
            /// Control ID for RemoveButton
            /// </summary>
            public const string RemoveButton = "removeButton";

            /// <summary>
            /// Control ID for SelectedManagementPacksPropertyGridView
            /// </summary>
            public const string SelectedManagementPacksPropertyGridView = "selectedGrid";

            /// <summary>
            /// Control ID for ToolStrip1
            /// </summary>
            public const string ToolStrip1 = "toolStrip1";

            /// <summary>
            /// Control ID for ManagementPacksInTheCatalogPropertyGridView
            /// </summary>
            public const string ManagementPacksInTheCatalogPropertyGridView = "catalogGrid";

            /// <summary>
            /// Control ID for FilterComboBox
            /// </summary>
            public const string FilterComboBox = "filterComboBox";
        }
        #endregion
    }
}
