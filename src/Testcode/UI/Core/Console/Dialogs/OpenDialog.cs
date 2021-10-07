// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="OpenDialog.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	MOMv3
// </project>
// <summary>
// 	Open Dialog
// </summary>
// <history>
// 	[mbickle] 13-Aug-05 StyleCop Fixes.
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Dialogs
{
    #region Using directives
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    #endregion

    #region Interface Definition - IOpenDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IOpenDialogControls, for OpenDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[mbickle] 13-Aug-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IOpenDialogControls
    {
        /// <summary>
        /// Read-only property to access LookInStaticControl
        /// </summary>
        StaticControl LookInStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access LookInComboBox
        /// </summary>
        ComboBox LookInComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access TopToolbar
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Toolbar TopToolbar
        {
            get;
        }

        /// <summary>
        /// Read-only property to access LookInToolbar
        /// </summary>
        Toolbar LookInToolbar
        {
            get;
        }

        /// <summary>
        /// Read-only property to access FolderView
        /// </summary>
        ListView FolderView
        {
            get;
        }

        /// <summary>
        /// Read-only property to access FileNameStaticControl
        /// </summary>
        StaticControl FileNameStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access FileNameTextBox
        /// </summary>
        TextBox FileNameTextBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access FileNameEditComboBox
        /// </summary>
        EditComboBox FileNameEditComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access FileNameEditComboBox2
        /// </summary>
        EditComboBox FileNameEditComboBox2
        {
            get;
        }

        /// <summary>
        /// Read-only property to access FilesOfTypeStaticControl
        /// </summary>
        StaticControl FilesOfTypeStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access FilesOfTypeComboBox
        /// </summary>
        ComboBox FilesOfTypeComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access OpenButton
        /// </summary>
        Button OpenButton
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
    /// OpenDialog Class
    /// </summary>
    /// <history>
    /// 	[mbickle] 13-Aug-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class OpenDialog : Dialog, IOpenDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;

        /// <summary>
        /// OpenDialog Title
        /// </summary>
        private static OpenDialogTitle title;
        #endregion

        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to LookInStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedLookInStaticControl;

        /// <summary>
        /// Cache to hold a reference to LookInComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedLookInComboBox;

        /// <summary>
        /// Cache to hold a reference to TopToolbar of type Toolbar
        /// </summary>
        private Toolbar cachedTopToolbar;

        /// <summary>
        /// Cache to hold a reference to LookInToolbar of type Toolbar
        /// </summary>
        private Toolbar cachedLookInToolbar;

        /// <summary>
        /// Cache to hold a reference to FolderView of type ListView
        /// </summary>
        private ListView cachedFolderView;

        /// <summary>
        /// Cache to hold a reference to FileNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedFileNameStaticControl;

        /// <summary>
        /// Cache to hold a reference to FileNameEditComboBox of type EditComboBox
        /// </summary>
        private EditComboBox cachedFileNameEditComboBox;

        /// <summary>
        /// Cache to hold a reference to FileNameEditComboBox2 of type EditComboBox
        /// </summary>
        private EditComboBox cachedFileNameEditComboBox2;

        /// <summary>
        /// Cache to hold a reference to FileNameEditComboBox2 of type EditComboBox
        /// </summary>
        private TextBox cachedFileNameTextBox;

        /// <summary>
        /// Cache to hold a reference to FilesOfTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedFilesOfTypeStaticControl;

        /// <summary>
        /// Cache to hold a reference to FilesOfTypeComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedFilesOfTypeComboBox;

        /// <summary>
        /// Cache to hold a reference to OpenButton of type Button
        /// </summary>
        private Button cachedOpenButton;

        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Open Dialog
        /// </summary>
        /// <param name='app'>ConsoleApp</param>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public OpenDialog(ConsoleApp app)
            : base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Open Dialog by specifying the name of the dialog.
        /// </summary>
        /// <param name="app">ConsoleApp</param>
        /// <param name="title">Title of Dialog</param>
        /// <example>
        /// For example to access the Install Management Packs Wizard open dialog: 
        /// OpenDialog openDialog = new OpenDialog(
        ///            CoreManager.MomConsole,
        ///            OpenDialog.OpenDialogTitle.ManagementPacksSelect);
        /// </example>
        /// -----------------------------------------------------------------------------
        public OpenDialog(ConsoleApp app, OpenDialogTitle title)
            : base(app, Init(app, title))
        {
            // TODO: Add Constructor logic here. 
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Open Dialog by specifying the name of the dialog.
        /// </summary>
        /// <param name="app">ConsoleApp</param>
        /// <param name="title">Title of Dialog</param>
        /// <example>
        /// For example to access the Install Management Packs Wizard open dialog: 
        /// OpenDialog openDialog = new OpenDialog(
        ///            CoreManager.Console,
        ///            OpenDialog.OpenDialogTitle.ManagementPacksSelect);
        /// </example>
        /// -----------------------------------------------------------------------------
        public OpenDialog(ConsoleApp app, string title)
            : base(app, Init(app, title))
        {
            // TODO: Add Constructor logic here. 
        }

        #endregion

        #region Enums section
        /// <summary>
        /// OpenDialog Title Enums.
        /// </summary>
        public enum OpenDialogTitle
        {
            /// <summary>
            /// Open
            /// </summary>
            Open,

            /// <summary>
            /// ManagementPacksSelect
            /// </summary>
            ManagementPacksSelect
        }
        #endregion

        #region IOpenDialog Controls Property
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// OpenDialog Title
        /// </summary>
        /// -----------------------------------------------------------------------------
        public static OpenDialogTitle Title
        {
            get
            {
                return title;
            }
            private set
            {
                title = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IOpenDialogControls Controls
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
        ///  Routine to set/get the text in control LookIn
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string LookInText
        {
            get
            {
                return this.Controls.LookInComboBox.Text;
            }

            set
            {
                this.Controls.LookInComboBox.SelectByText(value, true);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control FileName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string FileNameText
        {
            get
            {
                return this.Controls.FileNameEditComboBox.Text;
            }

            set
            {
                this.Controls.FileNameEditComboBox.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control FileName2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string FileName2Text
        {
            get
            {
                return this.Controls.FileNameEditComboBox2.Text;
            }

            set
            {
                this.Controls.FileNameEditComboBox2.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control FileName2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string FileName3Text
        {
            get
            {
                return this.Controls.FileNameTextBox.Text;
            }

            set
            {
                this.Controls.FileNameTextBox.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control FilesOfType
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string FilesOfTypeText
        {
            get
            {
                return this.Controls.FilesOfTypeComboBox.Text;
            }

            set
            {
                this.Controls.FilesOfTypeComboBox.SelectByText(value, true);
            }
        }
        #endregion

        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LookInStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOpenDialogControls.LookInStaticControl
        {
            get
            {
                if ((this.cachedLookInStaticControl == null))
                {
                    this.cachedLookInStaticControl = new StaticControl(this, OpenDialog.ControlIDs.LookInStaticControl);
                }
                return this.cachedLookInStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LookInComboBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IOpenDialogControls.LookInComboBox
        {
            get
            {
                if ((this.cachedLookInComboBox == null))
                {
                    this.cachedLookInComboBox = new ComboBox(this, OpenDialog.ControlIDs.LookInComboBox);
                }
                return this.cachedLookInComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TopToolbar control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IOpenDialogControls.TopToolbar
        {
            get
            {
                if ((this.cachedTopToolbar == null))
                {
                    this.cachedTopToolbar = new Toolbar(this, ControlIDs.TopToolbar.ToString());
                }
                return this.cachedTopToolbar;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LookInToolbar control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IOpenDialogControls.LookInToolbar
        {
            get
            {
                if ((this.cachedLookInToolbar == null))
                {
                    this.cachedLookInToolbar = new Toolbar(this, ControlIDs.LookInToolbar.ToString());
                }
                return this.cachedLookInToolbar;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FolderView control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IOpenDialogControls.FolderView
        {
            get
            {
                if ((this.cachedFolderView == null))
                {
                    this.cachedFolderView = new ListView(this, OpenDialog.ControlIDs.FolderView);
                }
                return this.cachedFolderView;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FileNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOpenDialogControls.FileNameStaticControl
        {
            get
            {
                if ((this.cachedFileNameStaticControl == null))
                {
                    this.cachedFileNameStaticControl = new StaticControl(this, OpenDialog.ControlIDs.FileNameStaticControl);
                }
                return this.cachedFileNameStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FileNameEditComboBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IOpenDialogControls.FileNameEditComboBox
        {
            get
            {
                if ((this.cachedFileNameEditComboBox == null))
                {
                    this.cachedFileNameEditComboBox = new EditComboBox(this, OpenDialog.ControlIDs.FileNameEditComboBox);
                }
                return this.cachedFileNameEditComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FileNameEditComboBox2 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IOpenDialogControls.FileNameEditComboBox2
        {
            get
            {
                if ((this.cachedFileNameEditComboBox2 == null))
                {
                    this.cachedFileNameEditComboBox2 = new EditComboBox(this, ControlIDs.FileNameEditComboBox2);
                }
                return this.cachedFileNameEditComboBox2;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FileNameEditComboBox2 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IOpenDialogControls.FileNameTextBox
        {
            get
            {
                if ((this.cachedFileNameTextBox == null))
                {
                    this.cachedFileNameTextBox = new TextBox(this, ControlIDs.FileNameTextBox);
                }
                return this.cachedFileNameTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FilesOfTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOpenDialogControls.FilesOfTypeStaticControl
        {
            get
            {
                if ((this.cachedFilesOfTypeStaticControl == null))
                {
                    this.cachedFilesOfTypeStaticControl = new StaticControl(this, OpenDialog.ControlIDs.FilesOfTypeStaticControl);
                }
                return this.cachedFilesOfTypeStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FilesOfTypeComboBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IOpenDialogControls.FilesOfTypeComboBox
        {
            get
            {
                if ((this.cachedFilesOfTypeComboBox == null))
                {
                    this.cachedFilesOfTypeComboBox = new ComboBox(this, OpenDialog.ControlIDs.FilesOfTypeComboBox);
                }
                return this.cachedFilesOfTypeComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OpenButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// 	[sunsingh] 05/04/09 added logic to get another resourse string for the open button  bug#142499 vista and higher version OS have dif resourse string
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IOpenDialogControls.OpenButton
        {
            get
            {
                if ((this.cachedOpenButton == null))
                {
                    //Search for Open Button via Window due to duplicate ControlID's
                    try
                    {
                        Window openButtonWindow = new Window(
                            Strings.Open,
                            WindowClassNames.Button,
                            this,
                            3000);

                        this.cachedOpenButton = new Button(openButtonWindow);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        if (this.cachedOpenButton == null)//if first string is not right try second string bug#142499
                        {
                            Window openButtonWindow = new Window(
                            Strings.OpenSecond,
                            WindowClassNames.Button,
                            this,
                            3000);

                            this.cachedOpenButton = new Button(openButtonWindow);
                        }

                    }
                }
                return this.cachedOpenButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IOpenDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, OpenDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        #endregion

        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Open
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOpen()
        {
            this.Controls.OpenButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        #endregion

        #region Private Methods
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">App owning the dialog.</param>)
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            Window tempWindow = Init(app, OpenDialogTitle.Open);
            return tempWindow;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a visible instance of the dialog.
        /// </summary>
        /// <param name="app">ConsoleApp owning the dialog.</param>
        /// <param name="title">The title of the dialog.</param>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <history>
        ///     [barryw]  7/20/2005 Created.
        ///  </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(
            ConsoleApp app,
            OpenDialogTitle title)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                Title = title;
                tempWindow = new Window(
                    Strings.DialogTitle,
                    StringMatchSyntax.ExactMatch,
                    WindowClassNames.Dialog,
                    StringMatchSyntax.ExactMatch,
                    app,
                    Core.Common.Constants.DefaultDialogTimeout);
                Common.Utilities.LogMessage("Init: " +
                    "Found dialog - " + Strings.DialogTitle);
            }
            catch (Exceptions.WindowNotFoundException e)
            {
                if (Title == OpenDialogTitle.Open)
                {
                    // Launch the Open Dialog - File\Open
                    Commands.FileOpen.Execute(app, CommandMethod.Default);

                    tempWindow = new Window(
                        Strings.DialogTitle,
                        StringMatchSyntax.ExactMatch,
                        WindowClassNames.Dialog,
                        StringMatchSyntax.ExactMatch,
                        app,
                        Core.Common.Constants.DefaultDialogTimeout);
                    if (tempWindow != null)
                    {
                        Common.Utilities.LogMessage("Init: " +
                            "Launched dialog - " + Strings.DialogTitle);
                        return tempWindow;
                    }
                    else
                    {
                        throw new Window.Exceptions.WindowNotFoundException("Init function could not find or bring up the dialog.", e);
                    }
                }
                else
                {
                    Common.Utilities.LogMessage("Init: " +
                        "Unable to find dialog - " + Strings.DialogTitle);
                    throw;
                }
            }
            return tempWindow;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a visible instance of the dialog.
        /// </summary>
        /// <param name="app">ConsoleApp owning the dialog.</param>
        /// <param name="title">The title of the dialog.</param>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <history>
        ///     [v-kayu]  18Nov09 Created.
        ///  </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(
            ConsoleApp app,
            string title)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                tempWindow = new Window(
                    title,
                    StringMatchSyntax.ExactMatch,
                    WindowClassNames.Dialog,
                    StringMatchSyntax.ExactMatch,
                    app,
                    2000);
                Common.Utilities.LogMessage("Init: " +
                    "Found dialog - " + title);
            }
            catch (Exceptions.WindowNotFoundException)
            {
                // Looking for the Dialog
                tempWindow = new Window(
                    "*",
                    StringMatchSyntax.WildCard,
                    WindowClassNames.Dialog,
                    StringMatchSyntax.ExactMatch,
                    app,
                    5000);

                if (tempWindow != null)
                {
                    return tempWindow;
                }

                throw new Window.Exceptions.WindowNotFoundException("Init function could not find or bring up the dialog.");
            }

            return tempWindow;
        }
        #endregion

        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
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
            private const string ResourceDialogTitle = ";Open;Win32DialogString;comdlg32.dll;1552";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Resource DialogTitle for Management Packs
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitleManagementPack = ";Select Management Pack(s) to import;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;MPSelectTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  LookIn
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLookIn = ";Look &in:;Win32DialogItemString;comdlg32.dll;1552;1091";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  FolderView
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFolderView = "FolderView";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  FileName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFileName = ";File &name:;Win32DialogItemString;comdlg32.dll;1552;1090";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  FilesOfType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFilesOfType = ";Files of &type:;Win32DialogItemString;comdlg32.dll;1552;1089";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Open
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOpen = ";&Open;Win32DialogItemString;comdlg32.dll;1552;1";


            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Open ; bug#142499 vista and higher version  OS have diff resourse string
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOpen2 = ";&Open;Win32DialogItemString;comdlg32.dll;1553;1";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;Win32DialogItemString;comdlg32.dll;1552;2";
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
            /// Caches the translated resource string for:  LookIn
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLookIn;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  FolderView
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFolderView;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  FileName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFileName;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  FilesOfType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFilesOfType;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Open
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOpen;
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for Second:  Open bug#142499 vista and higher version  OS have diff resourse string
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOpen2;

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
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 13-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    if (cachedDialogTitle == null)
                    {
                        string tempDialogTitle;
                        switch (Title)
                        {
                            case OpenDialogTitle.ManagementPacksSelect:
                                {
                                    tempDialogTitle =
                                        ResourceDialogTitleManagementPack;
                                    break;
                                }
                            default:
                                {
                                    tempDialogTitle = ResourceDialogTitle;
                                    break;
                                }
                        }
                        cachedDialogTitle = CoreManager.MomConsole.GetIntlStr(
                            tempDialogTitle);
                    }
                    return cachedDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the LookIn translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 13-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LookIn
            {
                get
                {
                    if ((cachedLookIn == null))
                    {
                        cachedLookIn = CoreManager.MomConsole.GetIntlStr(ResourceLookIn);
                    }
                    return cachedLookIn;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the FolderView translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 13-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FolderView
            {
                get
                {
                    if ((cachedFolderView == null))
                    {
                        cachedFolderView = CoreManager.MomConsole.GetIntlStr(ResourceFolderView);
                    }
                    return cachedFolderView;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the FileName translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 13-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FileName
            {
                get
                {
                    if ((cachedFileName == null))
                    {
                        cachedFileName = CoreManager.MomConsole.GetIntlStr(ResourceFileName);
                    }
                    return cachedFileName;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the FilesOfType translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 13-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FilesOfType
            {
                get
                {
                    if ((cachedFilesOfType == null))
                    {
                        cachedFilesOfType = CoreManager.MomConsole.GetIntlStr(ResourceFilesOfType);
                    }
                    return cachedFilesOfType;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Open translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 13-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Open
            {
                get
                {
                    if ((cachedOpen == null))
                    {
                        cachedOpen = CoreManager.MomConsole.GetIntlStr(ResourceOpen);
                    }
                    return cachedOpen;
                }
            }
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Second Open translated resource string ;Open bug#142499 vista and higher version OS have diif resourse string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 04-May-09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OpenSecond
            {
                get
                {
                    if ((cachedOpen2 == null))
                    {
                        cachedOpen2 = CoreManager.MomConsole.GetIntlStr(ResourceOpen2);
                    }
                    return cachedOpen2;
                }
            }
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 13-Aug-05 Created
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
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for LookInStaticControl
            /// </summary>
            public const int LookInStaticControl = 1091;

            /// <summary>
            /// Control ID for LookInComboBox
            /// </summary>
            public const int LookInComboBox = 1137;

            /// <summary>
            /// Control ID for TopToolbar
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const int TopToolbar = 1088;

            /// <summary>
            /// Control ID for LookInToolbar
            /// </summary>
            public const int LookInToolbar = 1184;

            /// <summary>
            /// Control ID for FolderView
            /// </summary>
            public const int FolderView = 1;

            /// <summary>
            /// Control ID for FileNameStaticControl
            /// </summary>
            public const int FileNameStaticControl = 1090;

            /// <summary>
            /// Control ID for FileNameEditComboBox
            /// </summary>
            public const int FileNameEditComboBox = 1148;

            /// <summary>
            /// Control ID for FileNameEditComboBox2
            /// </summary>
            public const int FileNameEditComboBox2 = 1148;

            /// <summary>
            /// Control ID for FilenameTextBox
            /// </summary>
            public const int FileNameTextBox = 1148;

            /// <summary>
            /// Control ID for FilesOfTypeStaticControl
            /// </summary>
            public const int FilesOfTypeStaticControl = 1089;

            /// <summary>
            /// Control ID for FilesOfTypeComboBox
            /// </summary>
            public const int FilesOfTypeComboBox = 1136;

            /// <summary>
            /// Control ID for OpenButton
            /// </summary>
            public const int OpenButton = 1;

            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const int CancelButton = 2;
        }
        #endregion
    }
}
