// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SaveAsDialog.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[mbickle] 13-Aug-05 Created
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

    #region Interface Definition - ISaveAsDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISaveAsDialogControls, for SaveAsDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[mbickle] 13-Aug-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISaveAsDialogControls
    {
        /// <summary>
        /// Read-only property to access SaveInStaticControl
        /// </summary>
        StaticControl SaveInStaticControl
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
        /// Read-only property to access FileNameEditComboBox
        /// </summary>
        EditComboBox FileNameEditComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access FileNameEditTextBox
        /// </summary>
        TextBox FileNameEditTextBox
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
        /// Read-only property to access SaveAsTypeStaticControl
        /// </summary>
        StaticControl SaveAsTypeStaticControl
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
        /// Read-only property to access SaveButton
        /// </summary>
        Button SaveButton
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
    /// TODO: Add dialog functionality description here.
    /// </summary>
    /// <history>
    /// 	[mbickle] 13-Aug-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SaveAsDialog : Dialog, ISaveAsDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion

        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to SaveInStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSaveInStaticControl;

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
        /// Cache to hold a reference to FileNameEditTextBox of type EditTextBox
        /// </summary>
        private TextBox cachedFileNameEditTextBox;

        /// <summary>
        /// Cache to hold a reference to FileNameEditComboBox2 of type EditComboBox
        /// </summary>
        private EditComboBox cachedFileNameEditComboBox2;

        /// <summary>
        /// Cache to hold a reference to SaveAsTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSaveAsTypeStaticControl;

        /// <summary>
        /// Cache to hold a reference to FilesOfTypeComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedFilesOfTypeComboBox;

        /// <summary>
        /// Cache to hold a reference to SaveButton of type Button
        /// </summary>
        private Button cachedSaveButton;

        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of SaveAsDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SaveAsDialog(ConsoleApp app)
            : base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Save As Dialog by specifying the name of the dialog.
        /// </summary>
        /// <param name="app">ConsoleApp</param>
        /// <param name="title">Title of Dialog</param>
        /// <example>
        /// For example to access the Install Management Packs Wizard open dialog: 
        /// SaveAsDialog saveAsDialog = new SaveAsDialog(
        ///            CoreManager.Console,
        ///            DialogTitle);
        /// </example>
        /// -----------------------------------------------------------------------------
        public SaveAsDialog(ConsoleApp app, string title)
            : base(app, Init(app, title))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion

        #region ISaveAsDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISaveAsDialogControls Controls
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
        ///  Routine to set/get the text in control FileName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-kayu] 18Nov09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string FileNameTextEdit
        {
            get
            {
                return this.Controls.FileNameEditTextBox.Text;
            }

            set
            {
                this.Controls.FileNameEditTextBox.Text = value;
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
        ///  Exposes access to the SaveInStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISaveAsDialogControls.SaveInStaticControl
        {
            get
            {
                if ((this.cachedSaveInStaticControl == null))
                {
                    this.cachedSaveInStaticControl = new StaticControl(this, SaveAsDialog.ControlIDs.SaveInStaticControl);
                }
                return this.cachedSaveInStaticControl;
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
        ComboBox ISaveAsDialogControls.LookInComboBox
        {
            get
            {
                if ((this.cachedLookInComboBox == null))
                {
                    this.cachedLookInComboBox = new ComboBox(this, SaveAsDialog.ControlIDs.LookInComboBox);
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
        Toolbar ISaveAsDialogControls.TopToolbar
        {
            get
            {
                if ((this.cachedTopToolbar == null))
                {
                    this.cachedTopToolbar = new Toolbar(this, SaveAsDialog.ControlIDs.TopToolbar.ToString());
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
        Toolbar ISaveAsDialogControls.LookInToolbar
        {
            get
            {
                if ((this.cachedLookInToolbar == null))
                {
                    this.cachedLookInToolbar = new Toolbar(this, SaveAsDialog.ControlIDs.LookInToolbar.ToString());
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
        ListView ISaveAsDialogControls.FolderView
        {
            get
            {
                if ((this.cachedFolderView == null))
                {
                    this.cachedFolderView = new ListView(this, SaveAsDialog.ControlIDs.FolderView);
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
        StaticControl ISaveAsDialogControls.FileNameStaticControl
        {
            get
            {
                if ((this.cachedFileNameStaticControl == null))
                {
                    this.cachedFileNameStaticControl = new StaticControl(this, SaveAsDialog.ControlIDs.FileNameStaticControl);
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
        EditComboBox ISaveAsDialogControls.FileNameEditComboBox
        {
            get
            {
                if ((this.cachedFileNameEditComboBox == null))
                {
                    this.cachedFileNameEditComboBox = new EditComboBox(this, SaveAsDialog.ControlIDs.FileNameEditComboBox);
                }
                return this.cachedFileNameEditComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FileNameEditTextBox control
        /// </summary>
        /// <history>
        /// 	[v-kayu] 18Nov09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ISaveAsDialogControls.FileNameEditTextBox
        {
            get
            {
                if ((this.cachedFileNameEditTextBox == null))
                {
                    this.cachedFileNameEditTextBox = new TextBox(this, SaveAsDialog.ControlIDs.FileNameEditTextBox);
                }

                return this.cachedFileNameEditTextBox;
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
        EditComboBox ISaveAsDialogControls.FileNameEditComboBox2
        {
            get
            {
                // The ID for this control (1148) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedFileNameEditComboBox2 == null))
                {
                    this.cachedFileNameEditComboBox2 = new EditComboBox(this, SaveAsDialog.ControlIDs.FileNameEditComboBox2);
                }
                return this.cachedFileNameEditComboBox2;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SaveAsTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISaveAsDialogControls.SaveAsTypeStaticControl
        {
            get
            {
                if ((this.cachedSaveAsTypeStaticControl == null))
                {
                    this.cachedSaveAsTypeStaticControl = new StaticControl(this, SaveAsDialog.ControlIDs.SaveAsTypeStaticControl);
                }
                return this.cachedSaveAsTypeStaticControl;
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
        ComboBox ISaveAsDialogControls.FilesOfTypeComboBox
        {
            get
            {
                if ((this.cachedFilesOfTypeComboBox == null))
                {
                    this.cachedFilesOfTypeComboBox = new ComboBox(this, SaveAsDialog.ControlIDs.FilesOfTypeComboBox);
                }
                return this.cachedFilesOfTypeComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SaveButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISaveAsDialogControls.SaveButton
        {
            get
            {
                // The ID for this control (1) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedSaveButton == null))
                {
                    Window saveButtonWindow = new Window(
                        Strings.Save,
                        WindowClassNames.Button,
                        this,
                        3000);
                    this.cachedSaveButton = new Button(saveButtonWindow);
                }
                return this.cachedSaveButton;
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
        Button ISaveAsDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, SaveAsDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        #endregion

        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Save
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSave()
        {
            this.Controls.SaveButton.Click();
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

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">ConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                //Looking for Dialog
                tempWindow = new Window(
                    app.GetIntlStr(Strings.DialogTitle), 
                    StringMatchSyntax.ExactMatch,
                    WindowClassNames.Dialog, 
                    StringMatchSyntax.ExactMatch,
                    app,
                    2000);
            }
            catch (Exceptions.WindowNotFoundException)
            {
                // Looking for the Dialog
                tempWindow = new Window(
                    app.GetIntlStr(Strings.DialogTitle), 
                    StringMatchSyntax.ExactMatch,
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
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle = ";Save As;Win32String;comdlg32.dll;385";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SaveIn
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSaveIn = ";Save &in:;Win32String;comdlg32.dll;368";

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
            private const string ResourceFileName = ";File &name:;Win32DialogItemString;comdlg32.dll;1547;1090";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SaveAsType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSaveAsType = ";Save as &type:;Win32String;comdlg32.dll;412";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Save
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSave = ";&Save;Win32String;comdlg32.dll;369";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;Win32DialogItemString;comdlg32.dll;1547;2";
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
            /// Caches the translated resource string for:  SaveIn
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSaveIn;

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
            /// Caches the translated resource string for:  SaveAsType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSaveAsType;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Save
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSave;

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
                    if ((cachedDialogTitle == null))
                    {
                        cachedDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceDialogTitle);
                    }
                    return cachedDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SaveIn translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 13-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SaveIn
            {
                get
                {
                    if ((cachedSaveIn == null))
                    {
                        cachedSaveIn = CoreManager.MomConsole.GetIntlStr(ResourceSaveIn);
                    }
                    return cachedSaveIn;
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
            /// Exposes access to the SaveAsType translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 13-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SaveAsType
            {
                get
                {
                    if ((cachedSaveAsType == null))
                    {
                        cachedSaveAsType = CoreManager.MomConsole.GetIntlStr(ResourceSaveAsType);
                    }
                    return cachedSaveAsType;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Save translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 13-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Save
            {
                get
                {
                    if ((cachedSave == null))
                    {
                        cachedSave = CoreManager.MomConsole.GetIntlStr(ResourceSave);
                    }
                    return cachedSave;
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
            /// Control ID for SaveInStaticControl
            /// </summary>
            public const int SaveInStaticControl = 1091;

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
            /// Control ID for FileNameEditTextBox
            /// </summary>
            public const int FileNameEditTextBox = 1001;

            /// <summary>
            /// Control ID for FileNameEditComboBox2
            /// </summary>
            public const int FileNameEditComboBox2 = 1148;

            /// <summary>
            /// Control ID for SaveAsTypeStaticControl
            /// </summary>
            public const int SaveAsTypeStaticControl = 1089;

            /// <summary>
            /// Control ID for FilesOfTypeComboBox
            /// </summary>
            public const int FilesOfTypeComboBox = 1136;

            /// <summary>
            /// Control ID for SaveButton
            /// </summary>
            public const int SaveButton = 1;

            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const int CancelButton = 2;
        }
        #endregion
    }
}