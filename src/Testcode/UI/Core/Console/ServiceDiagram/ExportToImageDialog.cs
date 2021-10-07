// ----------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ExportToImageDialog.cs">
// 	Copyright (c) Microsoft Corporation 2007
// </copyright>
// <project>
// 	MOMv3 UI Automation
// </project>
// <summary>
// 	MOMv3 UI Automation
// </summary>
// <history>
// 	[KellyMor]  17SEP07 Created
//  [KellyMor]  18SEP07 Updated resource strings
//  [KellyMor]  17OCT07 Updated resource strings for Export dialog title string
//  [KellyMor]  25MAR08 Modified FileNameComboBox to use a different constructor
//                      call on Vista/Longhorn/VistaSp1
//                      Fixed issue finding save button, now uses resource string
//                      Fixed issue finding cancel button, now uses resource string
// </history>
// ----------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.ServiceDiagram
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IExportToImageDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IExportToImageDialogControls, for ExportToImageDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 9/18/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IExportToImageDialogControls
    {
        /// <summary>
        /// Read-only property to access SaveInStaticControl
        /// </summary>
        StaticControl SaveInStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SaveInComboBox
        /// </summary>
        ComboBox SaveInComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Toolbar0
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Toolbar Toolbar0
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SaveInToolbar
        /// </summary>
        Toolbar SaveInToolbar
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
        /// Read-only property to access SaveAsTypeComboBox
        /// </summary>
        ComboBox SaveAsTypeComboBox
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
    /// Class to encpasulate the functionality of the "Export to Image" and
    /// "Export Page to Visio VDX" dialogs
    /// </summary>
    /// <history>
    /// 	[KellyMor] 9/18/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ExportToImageDialog : Dialog, IExportToImageDialogControls
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
        /// Cache to hold a reference to SaveInComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedSaveInComboBox;
        
        /// <summary>
        /// Cache to hold a reference to Toolbar0 of type Toolbar
        /// </summary>
        private Toolbar cachedToolbar0;
        
        /// <summary>
        /// Cache to hold a reference to SaveInToolbar of type Toolbar
        /// </summary>
        private Toolbar cachedSaveInToolbar;
        
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
        /// Cache to hold a reference to SaveAsTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSaveAsTypeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SaveAsTypeComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedSaveAsTypeComboBox;
        
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
        /// Owner of ExportToImageDialog of type App
        /// </param>
        /// <history>
        /// 	[KellyMor] 9/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ExportToImageDialog(App app) : 
                base(app, Init(app, Strings.ExportToImageDialogTitle))
        {
            // TODO: Add Constructor logic here. 
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Overloaded constructor that takes a custom dialog title
        /// </summary>
        /// <param name='app'>
        /// Owner of ExportToImageDialog of type App
        /// </param>
        /// <param name="dialogTitle">
        /// Dialog title
        /// </param>
        /// <history>
        /// 	[KellyMor] 9/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ExportToImageDialog(App app, string dialogTitle)
            :
                base(app, Init(app, dialogTitle))
        {
            // TODO: Add Constructor logic here. 
        }

        #endregion
        
        #region IExportToImageDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[KellyMor] 9/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IExportToImageDialogControls Controls
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
        ///  Routine to set/get the text in control SaveIn
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 9/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SaveInText
        {
            get
            {
                return this.Controls.SaveInComboBox.Text;
            }
            
            set
            {
                this.Controls.SaveInComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control FileName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 9/18/2007 Created
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
        /// 	[KellyMor] 9/18/2007 Created
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
        ///  Routine to set/get the text in control SaveAsType
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 9/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SaveAsTypeText
        {
            get
            {
                return this.Controls.SaveAsTypeComboBox.Text;
            }
            
            set
            {
                this.Controls.SaveAsTypeComboBox.SelectByText(value, true);
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SaveInStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 9/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IExportToImageDialogControls.SaveInStaticControl
        {
            get
            {
                if ((this.cachedSaveInStaticControl == null))
                {
                    this.cachedSaveInStaticControl = new StaticControl(this, ExportToImageDialog.ControlIDs.SaveInStaticControl);
                }
                
                return this.cachedSaveInStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SaveInComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 9/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IExportToImageDialogControls.SaveInComboBox
        {
            get
            {
                if ((this.cachedSaveInComboBox == null))
                {
                    this.cachedSaveInComboBox = new ComboBox(this, ExportToImageDialog.ControlIDs.SaveInComboBox);
                }
                
                return this.cachedSaveInComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Toolbar0 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 9/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IExportToImageDialogControls.Toolbar0
        {
            get
            {
                if ((this.cachedToolbar0 == null))
                {
                    this.cachedToolbar0 = new Toolbar(this, ExportToImageDialog.ControlIDs.Toolbar0.ToString());
                }
                
                return this.cachedToolbar0;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SaveInToolbar control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 9/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IExportToImageDialogControls.SaveInToolbar
        {
            get
            {
                if ((this.cachedSaveInToolbar == null))
                {
                    this.cachedSaveInToolbar = new Toolbar(this, ExportToImageDialog.ControlIDs.SaveInToolbar.ToString());
                }
                
                return this.cachedSaveInToolbar;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FolderView control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 9/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IExportToImageDialogControls.FolderView
        {
            get
            {
                if ((this.cachedFolderView == null))
                {
                    this.cachedFolderView = new ListView(this, ExportToImageDialog.ControlIDs.FolderView);
                }
                
                return this.cachedFolderView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FileNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 9/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IExportToImageDialogControls.FileNameStaticControl
        {
            get
            {
                if ((this.cachedFileNameStaticControl == null))
                {
                    this.cachedFileNameStaticControl = new StaticControl(this, ExportToImageDialog.ControlIDs.FileNameStaticControl);
                }
                
                return this.cachedFileNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FileNameEditComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 9/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IExportToImageDialogControls.FileNameEditComboBox
        {
            get
            {
                if ((this.cachedFileNameEditComboBox == null))
                {
                    // check for vista/longhorn base OS version
                    if (this.IsRunningVistaLonghorn())
                    {
                        // Vista RTM or Vista SP1/Longhorn 
                        this.cachedFileNameEditComboBox =
                           new EditComboBox(this);
                    }
                    else
                    {
                        // Windows Server 2003/Windows XP
                        this.cachedFileNameEditComboBox = 
                            new EditComboBox(
                                this, 
                                ExportToImageDialog.ControlIDs.FileNameEditComboBox);
                    }
                }
                
                return this.cachedFileNameEditComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FileNameEditComboBox2 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 9/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IExportToImageDialogControls.FileNameEditComboBox2
        {
            get
            {
                // The ID for this control (1148) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedFileNameEditComboBox2 == null))
                {
                    Window wndTemp = this;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 7); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedFileNameEditComboBox2 = new EditComboBox(wndTemp);
                }
                
                return this.cachedFileNameEditComboBox2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SaveAsTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 9/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IExportToImageDialogControls.SaveAsTypeStaticControl
        {
            get
            {
                if ((this.cachedSaveAsTypeStaticControl == null))
                {
                    this.cachedSaveAsTypeStaticControl = new StaticControl(this, ExportToImageDialog.ControlIDs.SaveAsTypeStaticControl);
                }
                
                return this.cachedSaveAsTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SaveAsTypeComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 9/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IExportToImageDialogControls.SaveAsTypeComboBox
        {
            get
            {
                if ((this.cachedSaveAsTypeComboBox == null))
                {
                    this.cachedSaveAsTypeComboBox = new ComboBox(this, ExportToImageDialog.ControlIDs.SaveAsTypeComboBox);
                }
                
                return this.cachedSaveAsTypeComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SaveButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 9/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IExportToImageDialogControls.SaveButton
        {
            get
            {
                // The ID for this control (1) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedSaveButton == null))
                {                    
                    this.cachedSaveButton = 
                        new Button(
                            this,
                            ExportToImageDialog.Strings.Save,
                            StringMatchSyntax.ExactMatch,
                            Maui.Core.WindowClassNames.Button,
                            StringMatchSyntax.ExactMatch);
                }
                
                return this.cachedSaveButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 9/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IExportToImageDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = 
                        new Button(
                            this,
                            ExportToImageDialog.Strings.Save,
                            StringMatchSyntax.ExactMatch,
                            Maui.Core.WindowClassNames.Button,
                            StringMatchSyntax.ExactMatch);
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
        /// 	[KellyMor] 9/18/2007 Created
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
        /// 	[KellyMor] 9/18/2007 Created
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
        /// <param name="app">App owning the dialog.</param>
        /// <param name="dialogTitle">String containing the dialog title text</param>
        /// <history>
        /// 	[KellyMor] 9/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app, string dialogTitle)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = 
                    new Window(
                        dialogTitle, 
                        StringMatchSyntax.ExactMatch, 
                        WindowClassNames.Dialog, 
                        StringMatchSyntax.ExactMatch, 
                        app.MainWindow, 
                        Timeout);
            }
            catch (Exceptions.WindowNotFoundException windowNotFound)
            {
                Core.Common.Utilities.LogMessage(
                    "Looking for window with title:  '" +
                    dialogTitle +
                    "'...");

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
                    catch (Exceptions.WindowNotFoundException )
                    {
                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage(
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
                    Core.Common.Utilities.LogMessage(
                       "Failed to find the '" +
                       dialogTitle +
                       "' window.");

                    // rethrow the original exception
                    throw windowNotFound;
                }
            }
            
            return tempWindow;
        }

        #region Private Methods

        /// <summary>
        /// Method to determine if the current OS is Vista/Longhorn
        /// </summary>
        /// <returns>True if OS is Vista/Longhorn</returns>
        private bool IsRunningVistaLonghorn()
        {
            if (System.Environment.OSVersion.Version.Major > 5)
            {
                // Vista RTM or Vista SP1/Longhorn 
                return true;
            }
            else
            {
                // Windows Server 2003/Windows XP
                return false;
            }
        }

        #endregion

        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Resource strings
        /// </summary>
        /// <history>
        /// 	[KellyMor] 9/18/2007 Created
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
            private const string ResourceExportToImageDialogTitle =
                ";Export to Image..." + 
                ";ManagedString" + 
                ";Microsoft.MOM.UI.Components.dll" + 
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramViewResources" + 
                ";ExportToImageTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceExportToVisioDialogTitle =
                ";Export Page to Visio VDX" +
                ";ManagedString;Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramViewResources" +
                ";ExportVisioTitle";

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
            private static string cachedExportToImageDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedExportToVisioDialogTitle;
            
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
            /// Exposes access to the ExportToImageDialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 9/18/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ExportToImageDialogTitle
            {
                get
                {
                    if ((cachedExportToImageDialogTitle == null))
                    {
                        cachedExportToImageDialogTitle = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceExportToImageDialogTitle);
                    }

                    return cachedExportToImageDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ExportToVisioDialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 9/18/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ExportToVisioDialogTitle
            {
                get
                {
                    if ((cachedExportToVisioDialogTitle == null))
                    {
                        cachedExportToVisioDialogTitle = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceExportToVisioDialogTitle);
                    }

                    return cachedExportToVisioDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SaveIn translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 9/18/2007 Created
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
            /// 	[KellyMor] 9/18/2007 Created
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
            /// 	[KellyMor] 9/18/2007 Created
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
            /// 	[KellyMor] 9/18/2007 Created
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
            /// 	[KellyMor] 9/18/2007 Created
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
            /// 	[KellyMor] 9/18/2007 Created
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
        /// 	[KellyMor] 9/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for SaveInStaticControl
            /// </summary>
            public const int SaveInStaticControl = 1091;
            
            /// <summary>
            /// Control ID for SaveInComboBox
            /// </summary>
            public const int SaveInComboBox = 1137;
            
            /// <summary>
            /// Control ID for Toolbar0
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const int Toolbar0 = 1088;
            
            /// <summary>
            /// Control ID for SaveInToolbar
            /// </summary>
            public const int SaveInToolbar = 1184;
            
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
            /// Control ID for SaveAsTypeStaticControl
            /// </summary>
            public const int SaveAsTypeStaticControl = 1089;
            
            /// <summary>
            /// Control ID for SaveAsTypeComboBox
            /// </summary>
            public const int SaveAsTypeComboBox = 1136;
            
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
