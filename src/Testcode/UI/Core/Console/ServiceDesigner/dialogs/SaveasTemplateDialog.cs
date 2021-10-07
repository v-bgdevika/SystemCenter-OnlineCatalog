// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SaveasTemplateDialog.cs">
//   Copyright (c) Microsoft Corporation 2011
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//   [asttest] 10/12/2011 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.ServiceDesigner
{
    #region
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    #endregion

    #region Interface Definition - ISaveasTemplateDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISaveasTemplateDialogControls, for SaveasTemplateDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-tfeng] 10/12/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISaveasTemplateDialogControls
    {
        /// <summary>
        /// Gets read-only property to access CommandModule
        /// </summary>
        Toolbar CommandModule
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access HelpButton
        /// </summary>
        Button HelpButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access ViewsButton
        /// </summary>
        Button ViewsButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access ViewSliderButton
        /// </summary>
        Button ViewSliderButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access OrganizeButton
        /// </summary>
        Button OrganizeButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access NewFolderButton
        /// </summary>
        Button NewFolderButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access NamespaceTreeControl
        /// </summary>
        TreeView NamespaceTreeControl
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access ItemsView
        /// </summary>
        ListView ItemsView
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access ColumnLeftButton
        /// </summary>
        Button ColumnLeftButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access PageRightButton
        /// </summary>
        Button PageRightButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access ColumnRightButton
        /// </summary>
        Button ColumnRightButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access Header
        /// </summary>
        Header Header
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access NameButton
        /// </summary>
        Button NameButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access FilterDropdownButton
        /// </summary>
        Button FilterDropdownButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access DateModifiedButton
        /// </summary>
        Button DateModifiedButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access FilterDropdownButton2
        /// </summary>
        Button FilterDropdownButton2
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access TypeButton
        /// </summary>
        Button TypeButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access FilterDropdownButton3
        /// </summary>
        Button FilterDropdownButton3
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access SizeButton
        /// </summary>
        Button SizeButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access FilterDropdownButton4
        /// </summary>
        Button FilterDropdownButton4
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access FileName
        /// </summary>
        EditComboBox FileName
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access FileName3TextBox2
        /// </summary>
        TextBox FileName3TextBox2
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access FileName4ListView2
        /// </summary>
        ListView FileName4ListView2
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access SaveAsType
        /// </summary>
        ComboBox SaveAsType
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access SaveAsType3ListView2
        /// </summary>
        ListView SaveAsType3ListView2
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access SaveFields
        /// </summary>
        TreeView SaveFields
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access ApplicationControls
        /// </summary>
        TreeView ApplicationControls
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access Toolbar0
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Toolbar Toolbar0
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access SaveButton
        /// </summary>
        Button SaveButton
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
        /// Gets read-only property to access Toolbar1
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Toolbar Toolbar1
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access ProgressBar2
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        ProgressBar ProgressBar2
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access AddressCUsersasttestAppDataLocalTemp1
        /// </summary>
        Toolbar AddressCUsersasttestAppDataLocalTemp1
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access Toolbar3
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Toolbar Toolbar3
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access SearchBox
        /// </summary>
        TextBox SearchBox
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
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add dialog functionality description here.
    /// </summary>
    /// <history>
    ///   [v-tfeng] 10/12/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class SaveasTemplateDialog : Dialog, ISaveasTemplateDialogControls
    {
        #region Private Constants
        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion

        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to CommandModule of type Toolbar
        /// </summary>
        private Toolbar cachedCommandModule;
        
        /// <summary>
        /// Cache to hold a reference to HelpButton of type Button
        /// </summary>
        private Button cachedHelpButton;
        
        /// <summary>
        /// Cache to hold a reference to ViewsButton of type Button
        /// </summary>
        private Button cachedViewsButton;
        
        /// <summary>
        /// Cache to hold a reference to ViewSliderButton of type Button
        /// </summary>
        private Button cachedViewSliderButton;
        
        /// <summary>
        /// Cache to hold a reference to OrganizeButton of type Button
        /// </summary>
        private Button cachedOrganizeButton;
        
        /// <summary>
        /// Cache to hold a reference to NewFolderButton of type Button
        /// </summary>
        private Button cachedNewFolderButton;
        
        /// <summary>
        /// Cache to hold a reference to NamespaceTreeControl of type TreeView
        /// </summary>
        private TreeView cachedNamespaceTreeControl;
        
        /// <summary>
        /// Cache to hold a reference to ItemsView of type ListView
        /// </summary>
        private ListView cachedItemsView;
        
        /// <summary>
        /// Cache to hold a reference to ColumnLeftButton of type Button
        /// </summary>
        private Button cachedColumnLeftButton;
        
        /// <summary>
        /// Cache to hold a reference to PageRightButton of type Button
        /// </summary>
        private Button cachedPageRightButton;
        
        /// <summary>
        /// Cache to hold a reference to ColumnRightButton of type Button
        /// </summary>
        private Button cachedColumnRightButton;
        
        /// <summary>
        /// Cache to hold a reference to Header of type Header
        /// </summary>
        private Header cachedHeader;
        
        /// <summary>
        /// Cache to hold a reference to NameButton of type Button
        /// </summary>
        private Button cachedNameButton;
        
        /// <summary>
        /// Cache to hold a reference to FilterDropdownButton of type Button
        /// </summary>
        private Button cachedFilterDropdownButton;
        
        /// <summary>
        /// Cache to hold a reference to DateModifiedButton of type Button
        /// </summary>
        private Button cachedDateModifiedButton;
        
        /// <summary>
        /// Cache to hold a reference to FilterDropdownButton2 of type Button
        /// </summary>
        private Button cachedFilterDropdownButton2;
        
        /// <summary>
        /// Cache to hold a reference to TypeButton of type Button
        /// </summary>
        private Button cachedTypeButton;
        
        /// <summary>
        /// Cache to hold a reference to FilterDropdownButton3 of type Button
        /// </summary>
        private Button cachedFilterDropdownButton3;
        
        /// <summary>
        /// Cache to hold a reference to SizeButton of type Button
        /// </summary>
        private Button cachedSizeButton;
        
        /// <summary>
        /// Cache to hold a reference to FilterDropdownButton4 of type Button
        /// </summary>
        private Button cachedFilterDropdownButton4;
        
        /// <summary>
        /// Cache to hold a reference to FileName of type EditComboBox
        /// </summary>
        private EditComboBox cachedFileName;
        
        /// <summary>
        /// Cache to hold a reference to FileName3TextBox2 of type TextBox
        /// </summary>
        private TextBox cachedFileName3TextBox2;
        
        /// <summary>
        /// Cache to hold a reference to FileName4ListView2 of type ListView
        /// </summary>
        private ListView cachedFileName4ListView2;
        
        /// <summary>
        /// Cache to hold a reference to SaveAsType of type ComboBox
        /// </summary>
        private ComboBox cachedSaveAsType;
        
        /// <summary>
        /// Cache to hold a reference to SaveAsType3ListView2 of type ListView
        /// </summary>
        private ListView cachedSaveAsType3ListView2;
        
        /// <summary>
        /// Cache to hold a reference to SaveFields of type TreeView
        /// </summary>
        private TreeView cachedSaveFields;
        
        /// <summary>
        /// Cache to hold a reference to ApplicationControls of type TreeView
        /// </summary>
        private TreeView cachedApplicationControls;
        
        /// <summary>
        /// Cache to hold a reference to Toolbar0 of type Toolbar
        /// </summary>
        private Toolbar cachedToolbar0;
        
        /// <summary>
        /// Cache to hold a reference to SaveButton of type Button
        /// </summary>
        private Button cachedSaveButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to Toolbar1 of type Toolbar
        /// </summary>
        private Toolbar cachedToolbar1;
        
        /// <summary>
        /// Cache to hold a reference to ProgressBar2 of type ProgressBar
        /// </summary>
        private ProgressBar cachedProgressBar2;
        
        /// <summary>
        /// Cache to hold a reference to AddressCUsersasttestAppDataLocalTemp1 of type Toolbar
        /// </summary>
        private Toolbar cachedAddressCUsersasttestAppDataLocalTemp1;
        
        /// <summary>
        /// Cache to hold a reference to Toolbar3 of type Toolbar
        /// </summary>
        private Toolbar cachedToolbar3;
        
        /// <summary>
        /// Cache to hold a reference to SearchBox of type TextBox
        /// </summary>
        private TextBox cachedSearchBox;
        
        /// <summary>
        /// Cache to hold a reference to SearchButton of type Button
        /// </summary>
        private Button cachedSearchButton;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the SaveasTemplateDialog class.
        /// </summary>
        /// <param name='app'>
        /// Owner of SaveasTemplateDialog of type App
        /// </param>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SaveasTemplateDialog(App app, int timeout) : 
                base(app, Init(app, timeout))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region ISaveasTemplateDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISaveasTemplateDialogControls Controls
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
        ///  Gets or sets the text in control FileName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string FileNameText
        {
            get
            {
                return this.Controls.FileName.Text;
            }
            
            set
            {
                this.Controls.FileName.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets or sets the text in control FileName3
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [asttest] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string FileName3Text
        {
            get
            {
                return this.Controls.FileName3TextBox2.Text;
            }
            
            set
            {
                this.Controls.FileName3TextBox2.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets or sets the text in control SaveAsType
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [asttest] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SaveAsTypeText
        {
            get
            {
                return this.Controls.SaveAsType.Text;
            }
            
            set
            {
                this.Controls.SaveAsType.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets or sets the text in control SearchBox
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [asttest] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SearchBoxText
        {
            get
            {
                return this.Controls.SearchBox.Text;
            }
            
            set
            {
                this.Controls.SearchBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the CommandModule control
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar ISaveasTemplateDialogControls.CommandModule
        {
            get
            {
                if ((this.cachedCommandModule == null))
                {
                    this.cachedCommandModule = new Toolbar(this, SaveasTemplateDialog.QueryIds.CommandModule,ConsoleConstants.DefaultControlTimeout);
                }
                
                return this.cachedCommandModule;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the HelpButton control
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISaveasTemplateDialogControls.HelpButton
        {
            get
            {
                if ((this.cachedHelpButton == null))
                {
                    this.cachedHelpButton = new Button(this, SaveasTemplateDialog.QueryIds.HelpButton);
                }
                
                return this.cachedHelpButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ViewsButton control
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISaveasTemplateDialogControls.ViewsButton
        {
            get
            {
                if ((this.cachedViewsButton == null))
                {
                    this.cachedViewsButton = new Button(this, SaveasTemplateDialog.QueryIds.ViewsButton);
                }
                
                return this.cachedViewsButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ViewSliderButton control
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISaveasTemplateDialogControls.ViewSliderButton
        {
            get
            {
                if ((this.cachedViewSliderButton == null))
                {
                    this.cachedViewSliderButton = new Button(this, SaveasTemplateDialog.QueryIds.ViewSliderButton);
                }
                
                return this.cachedViewSliderButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the OrganizeButton control
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISaveasTemplateDialogControls.OrganizeButton
        {
            get
            {
                if ((this.cachedOrganizeButton == null))
                {
                    this.cachedOrganizeButton = new Button(this, SaveasTemplateDialog.QueryIds.OrganizeButton);
                }
                
                return this.cachedOrganizeButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the NewFolderButton control
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISaveasTemplateDialogControls.NewFolderButton
        {
            get
            {
                if ((this.cachedNewFolderButton == null))
                {
                    this.cachedNewFolderButton = new Button(this, SaveasTemplateDialog.QueryIds.NewFolderButton);
                }
                
                return this.cachedNewFolderButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the NamespaceTreeControl control
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TreeView ISaveasTemplateDialogControls.NamespaceTreeControl
        {
            get
            {
                if ((this.cachedNamespaceTreeControl == null))
                {
                    this.cachedNamespaceTreeControl = new TreeView(this, SaveasTemplateDialog.QueryIds.NamespaceTreeControl);
                }
                
                return this.cachedNamespaceTreeControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ItemsView control
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// <remarks>
        ///  TODO: This control (ItemsView) does not have a valid ID.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        ListView ISaveasTemplateDialogControls.ItemsView
        {
            get
            {
                if ((this.cachedItemsView == null))
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
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedItemsView = new ListView(wndTemp);
                }
                
                return this.cachedItemsView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ColumnLeftButton control
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISaveasTemplateDialogControls.ColumnLeftButton
        {
            get
            {
                if ((this.cachedColumnLeftButton == null))
                {
                    this.cachedColumnLeftButton = new Button(this, SaveasTemplateDialog.QueryIds.ColumnLeftButton);
                }
                
                return this.cachedColumnLeftButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the PageRightButton control
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// <remarks>
        ///  TODO: The ID for this control (0) is used multiple times in this dialog.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        Button ISaveasTemplateDialogControls.PageRightButton
        {
            get
            {
                // TODO: The ID for this control (0) is used multiple times in this dialog.
                // Investigate why and report a bug if necessary.  The generated code follows the window
                // hierarchy path to find the control to work around this problem.
                if ((this.cachedPageRightButton == null))
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
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    this.cachedPageRightButton = new Button(wndTemp);
                }
                
                return this.cachedPageRightButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ColumnRightButton control
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// <remarks>
        ///  TODO: The ID for this control (0) is used multiple times in this dialog.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        Button ISaveasTemplateDialogControls.ColumnRightButton
        {
            get
            {
                // TODO: The ID for this control (0) is used multiple times in this dialog.
                // Investigate why and report a bug if necessary.  The generated code follows the window
                // hierarchy path to find the control to work around this problem.
                if ((this.cachedColumnRightButton == null))
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
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    this.cachedColumnRightButton = new Button(wndTemp);
                }
                
                return this.cachedColumnRightButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the Header control
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// <remarks>
        ///  TODO: This control (Header) does not have a valid ID.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        Header ISaveasTemplateDialogControls.Header
        {
            get
            {
                if ((this.cachedHeader == null))
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
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    this.cachedHeader = new Header(wndTemp);
                }
                
                return this.cachedHeader;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the NameButton control
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISaveasTemplateDialogControls.NameButton
        {
            get
            {
                if ((this.cachedNameButton == null))
                {
                    this.cachedNameButton = new Button(this, SaveasTemplateDialog.QueryIds.NameButton);
                }
                
                return this.cachedNameButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the FilterDropdownButton control
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISaveasTemplateDialogControls.FilterDropdownButton
        {
            get
            {
                if ((this.cachedFilterDropdownButton == null))
                {
                    this.cachedFilterDropdownButton = new Button(this, SaveasTemplateDialog.QueryIds.FilterDropdownButton);
                }
                
                return this.cachedFilterDropdownButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the DateModifiedButton control
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISaveasTemplateDialogControls.DateModifiedButton
        {
            get
            {
                if ((this.cachedDateModifiedButton == null))
                {
                    this.cachedDateModifiedButton = new Button(this, SaveasTemplateDialog.QueryIds.DateModifiedButton);
                }
                
                return this.cachedDateModifiedButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the FilterDropdownButton2 control
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// <remarks>
        ///  TODO: The ID for this control (DropDown) is used multiple times in this dialog.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        Button ISaveasTemplateDialogControls.FilterDropdownButton2
        {
            get
            {
                // TODO: The ID for this control (DropDown) is used multiple times in this dialog.
                // Investigate why and report a bug if necessary.  The generated code follows the window
                // hierarchy path to find the control to work around this problem.
                if ((this.cachedFilterDropdownButton2 == null))
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
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedFilterDropdownButton2 = new Button(wndTemp);
                }
                
                return this.cachedFilterDropdownButton2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the TypeButton control
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISaveasTemplateDialogControls.TypeButton
        {
            get
            {
                if ((this.cachedTypeButton == null))
                {
                    this.cachedTypeButton = new Button(this, SaveasTemplateDialog.QueryIds.TypeButton);
                }
                
                return this.cachedTypeButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the FilterDropdownButton3 control
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// <remarks>
        ///  TODO: The ID for this control (DropDown) is used multiple times in this dialog.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        Button ISaveasTemplateDialogControls.FilterDropdownButton3
        {
            get
            {
                // TODO: The ID for this control (DropDown) is used multiple times in this dialog.
                // Investigate why and report a bug if necessary.  The generated code follows the window
                // hierarchy path to find the control to work around this problem.
                if ((this.cachedFilterDropdownButton3 == null))
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
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedFilterDropdownButton3 = new Button(wndTemp);
                }
                
                return this.cachedFilterDropdownButton3;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SizeButton control
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISaveasTemplateDialogControls.SizeButton
        {
            get
            {
                if ((this.cachedSizeButton == null))
                {
                    this.cachedSizeButton = new Button(this, SaveasTemplateDialog.QueryIds.SizeButton);
                }
                
                return this.cachedSizeButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the FilterDropdownButton4 control
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// <remarks>
        ///  TODO: The ID for this control (DropDown) is used multiple times in this dialog.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        Button ISaveasTemplateDialogControls.FilterDropdownButton4
        {
            get
            {
                // TODO: The ID for this control (DropDown) is used multiple times in this dialog.
                // Investigate why and report a bug if necessary.  The generated code follows the window
                // hierarchy path to find the control to work around this problem.
                if ((this.cachedFilterDropdownButton4 == null))
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
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedFilterDropdownButton4 = new Button(wndTemp);
                }
                
                return this.cachedFilterDropdownButton4;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the FileName control
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox ISaveasTemplateDialogControls.FileName
        {
            get
            {
                if ((this.cachedFileName == null))
                {
                    this.cachedFileName = new EditComboBox(this, SaveasTemplateDialog.QueryIds.FileName);
                }
                
                return this.cachedFileName;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the FileName3TextBox2 control
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ISaveasTemplateDialogControls.FileName3TextBox2
        {
            get
            {
                if ((this.cachedFileName3TextBox2 == null))
                {
                    this.cachedFileName3TextBox2 = new TextBox(this, SaveasTemplateDialog.QueryIds.FileName3TextBox2);
                }
                
                return this.cachedFileName3TextBox2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the FileName4ListView2 control
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView ISaveasTemplateDialogControls.FileName4ListView2
        {
            get
            {
                if ((this.cachedFileName4ListView2 == null))
                {
                    this.cachedFileName4ListView2 = new ListView(this, SaveasTemplateDialog.QueryIds.FileName4ListView2);
                }
                
                return this.cachedFileName4ListView2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SaveAsType control
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ISaveasTemplateDialogControls.SaveAsType
        {
            get
            {
                if ((this.cachedSaveAsType == null))
                {
                    this.cachedSaveAsType = new ComboBox(this, SaveasTemplateDialog.QueryIds.SaveAsType);
                }
                
                return this.cachedSaveAsType;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SaveAsType3ListView2 control
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// <remarks>
        ///  TODO: The ID for this control (1000) is used multiple times in this dialog.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        ListView ISaveasTemplateDialogControls.SaveAsType3ListView2
        {
            get
            {
                // TODO: The ID for this control (1000) is used multiple times in this dialog.
                // Investigate why and report a bug if necessary.  The generated code follows the window
                // hierarchy path to find the control to work around this problem.
                if ((this.cachedSaveAsType3ListView2 == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 5); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedSaveAsType3ListView2 = new ListView(wndTemp);
                }
                
                return this.cachedSaveAsType3ListView2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SaveFields control
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TreeView ISaveasTemplateDialogControls.SaveFields
        {
            get
            {
                if ((this.cachedSaveFields == null))
                {
                    this.cachedSaveFields = new TreeView(this, SaveasTemplateDialog.QueryIds.SaveFields);
                }
                
                return this.cachedSaveFields;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ApplicationControls control
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TreeView ISaveasTemplateDialogControls.ApplicationControls
        {
            get
            {
                if ((this.cachedApplicationControls == null))
                {
                    this.cachedApplicationControls = new TreeView(this, SaveasTemplateDialog.QueryIds.ApplicationControls);
                }
                
                return this.cachedApplicationControls;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the Toolbar0 control
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// <remarks>
        ///  TODO: The ID for this control (0) is used multiple times in this dialog.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        Toolbar ISaveasTemplateDialogControls.Toolbar0
        {
            get
            {
                // TODO: The ID for this control (0) is used multiple times in this dialog.
                // Investigate why and report a bug if necessary.  The generated code follows the window
                // hierarchy path to find the control to work around this problem.
                if ((this.cachedToolbar0 == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    this.cachedToolbar0 = new Toolbar(wndTemp);
                }
                
                return this.cachedToolbar0;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SaveButton control
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISaveasTemplateDialogControls.SaveButton
        {
            get
            {
                if ((this.cachedSaveButton == null))
                {
                    this.cachedSaveButton = new Button(this, SaveasTemplateDialog.QueryIds.SaveButton);
                }
                
                return this.cachedSaveButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the CancelButton control
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISaveasTemplateDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, SaveasTemplateDialog.QueryIds.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the Toolbar1 control
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// <remarks>
        ///  TODO: The ID for this control (0) is used multiple times in this dialog.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        Toolbar ISaveasTemplateDialogControls.Toolbar1
        {
            get
            {
                // TODO: The ID for this control (0) is used multiple times in this dialog.
                // Investigate why and report a bug if necessary.  The generated code follows the window
                // hierarchy path to find the control to work around this problem.
                if ((this.cachedToolbar1 == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 4); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedToolbar1 = new Toolbar(wndTemp);
                }
                
                return this.cachedToolbar1;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ProgressBar2 control
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// <remarks>
        ///  TODO: The ID for this control (0) is used multiple times in this dialog.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        ProgressBar ISaveasTemplateDialogControls.ProgressBar2
        {
            get
            {
                // TODO: The ID for this control (0) is used multiple times in this dialog.
                // Investigate why and report a bug if necessary.  The generated code follows the window
                // hierarchy path to find the control to work around this problem.
                if ((this.cachedProgressBar2 == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 4); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    this.cachedProgressBar2 = new ProgressBar(wndTemp);
                }
                
                return this.cachedProgressBar2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the AddressCUsersasttestAppDataLocalTemp1 control
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// <remarks>
        ///  TODO: The ID for this control (1001) is used multiple times in this dialog.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        Toolbar ISaveasTemplateDialogControls.AddressCUsersasttestAppDataLocalTemp1
        {
            get
            {
                // TODO: The ID for this control (1001) is used multiple times in this dialog.
                // Investigate why and report a bug if necessary.  The generated code follows the window
                // hierarchy path to find the control to work around this problem.
                if ((this.cachedAddressCUsersasttestAppDataLocalTemp1 == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 4); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedAddressCUsersasttestAppDataLocalTemp1 = new Toolbar(wndTemp);
                }
                
                return this.cachedAddressCUsersasttestAppDataLocalTemp1;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the Toolbar3 control
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// <remarks>
        ///  TODO: The ID for this control (0) is used multiple times in this dialog.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        Toolbar ISaveasTemplateDialogControls.Toolbar3
        {
            get
            {
                // TODO: The ID for this control (0) is used multiple times in this dialog.
                // Investigate why and report a bug if necessary.  The generated code follows the window
                // hierarchy path to find the control to work around this problem.
                if ((this.cachedToolbar3 == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 4); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    this.cachedToolbar3 = new Toolbar(wndTemp);
                }
                
                return this.cachedToolbar3;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SearchBox control
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ISaveasTemplateDialogControls.SearchBox
        {
            get
            {
                if ((this.cachedSearchBox == null))
                {
                    this.cachedSearchBox = new TextBox(this, SaveasTemplateDialog.QueryIds.SearchBox);
                }
                
                return this.cachedSearchBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SearchButton control
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISaveasTemplateDialogControls.SearchButton
        {
            get
            {
                if ((this.cachedSearchButton == null))
                {
                    this.cachedSearchButton = new Button(this, SaveasTemplateDialog.QueryIds.SearchButton);
                }
                
                return this.cachedSearchButton;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Help
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickHelp()
        {
            this.Controls.HelpButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Views
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickViews()
        {
            this.Controls.ViewsButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ViewSlider
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickViewSlider()
        {
            this.Controls.ViewSliderButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Organize
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOrganize()
        {
            this.Controls.OrganizeButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button NewFolder
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNewFolder()
        {
            this.Controls.NewFolderButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ColumnLeft
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickColumnLeft()
        {
            this.Controls.ColumnLeftButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button PageRight
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickPageRight()
        {
            this.Controls.PageRightButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ColumnRight
        /// </summary>
        /// <history>
        ///   [asttest] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickColumnRight()
        {
            this.Controls.ColumnRightButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Name
        /// </summary>
        /// <history>
        ///   [asttest] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickName()
        {
            this.Controls.NameButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button FilterDropdown
        /// </summary>
        /// <history>
        ///   [asttest] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickFilterDropdown()
        {
            this.Controls.FilterDropdownButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button DateModified
        /// </summary>
        /// <history>
        ///   [asttest] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickDateModified()
        {
            this.Controls.DateModifiedButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button FilterDropdown2
        /// </summary>
        /// <history>
        ///   [asttest] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickFilterDropdown2()
        {
            this.Controls.FilterDropdownButton2.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Type
        /// </summary>
        /// <history>
        ///   [asttest] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickType()
        {
            this.Controls.TypeButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button FilterDropdown3
        /// </summary>
        /// <history>
        ///   [asttest] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickFilterDropdown3()
        {
            this.Controls.FilterDropdownButton3.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Size
        /// </summary>
        /// <history>
        ///   [asttest] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSize()
        {
            this.Controls.SizeButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button FilterDropdown4
        /// </summary>
        /// <history>
        ///   [asttest] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickFilterDropdown4()
        {
            this.Controls.FilterDropdownButton4.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Save
        /// </summary>
        /// <history>
        ///   [asttest] 10/12/2011 Created
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
        ///   [asttest] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Search
        /// </summary>
        /// <history>
        ///   [asttest] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSearch()
        {
            this.Controls.SearchButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">App owning the dialog.</param>
        /// <param name="timeout">timeout.</param>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app, int timeout)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(app.MainWindow, new QID(";[UIA]Name = '" + Strings.DialogTitle + "'"), timeout);
            }
            catch (Exceptions.WindowNotFoundException )
            {
                // TODO:  Add any specific logic here to handle the case when the
                // dialog is not found in the specified timeout.
                // otherwise rethrow the exception.
                throw;
            }
            
            return tempWindow;
        }
        
        #region Query ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all query ID's.
        /// </summary>
        /// <history>
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class QueryIds
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for CommandModule query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCommandModule = ";[UIA]AutomationId=\'FolderBandModuleInner\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for HelpButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelpButton = ";[UIA]AutomationId=\'HelpButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for ViewsButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceViewsButton = ";[UIA]AutomationId=\'ViewControl\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for ViewSliderButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceViewSliderButton = ";[UIA]AutomationId=\'SplitMenuButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for OrganizeButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOrganizeButton = ";[UIA]AutomationId=\'{7DDC1264-7E4D-4F74-BBC0-D191987C8D0F}\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for NewFolderButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNewFolderButton = ";[UIA]AutomationId=\'{E44616AD-6DF1-4B94-85A4-E465AE8A19DB}\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for NamespaceTreeControl query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNamespaceTreeControl = ";[UIA]AutomationId=\'100\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for ColumnLeftButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceColumnLeftButton = ";[UIA]AutomationId=\'0\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for PageRightButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePageRightButton = ";[UIA]AutomationId=\'0\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for ColumnRightButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceColumnRightButton = ";[UIA]AutomationId=\'0\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for NameButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNameButton = ";[UIA]AutomationId=\'System.ItemNameDisplay\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for FilterDropdownButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFilterDropdownButton = ";[UIA]AutomationId=\'DropDown\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for DateModifiedButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDateModifiedButton = ";[UIA]AutomationId=\'System.DateModified\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for FilterDropdownButton2 query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFilterDropdownButton2 = ";[UIA]AutomationId=\'DropDown\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for TypeButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTypeButton = ";[UIA]AutomationId=\'System.ItemTypeText\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for FilterDropdownButton3 query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFilterDropdownButton3 = ";[UIA]AutomationId=\'DropDown\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for SizeButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSizeButton = ";[UIA]AutomationId=\'System.Size\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for FilterDropdownButton4 query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFilterDropdownButton4 = ";[UIA]AutomationId=\'DropDown\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for FileName query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFileName = ";[UIA]AutomationId=\'FileNameControlHost\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for FileName3TextBox2 query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFileName3TextBox2 = ";[UIA]AutomationId=\'1001\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for FileName4ListView2 query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFileName4ListView2 = ";[UIA]AutomationId=\'1000\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for SaveAsType query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSaveAsType = ";[UIA]AutomationId=\'FileTypeControlHost\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for SaveAsType3ListView2 query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSaveAsType3ListView2 = ";[UIA]AutomationId=\'1000\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for SaveFields query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSaveFields = ";[UIA]AutomationId=\'SaveDialogPreviewMetadataInner\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for ApplicationControls query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceApplicationControls = ";[UIA]AutomationId=\'AppControlsModuleInner\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Toolbar0 query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceToolbar0 = ";[UIA]AutomationId=\'0\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for SaveButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSaveButton = ";[UIA]AutomationId=\'1\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for CancelButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancelButton = ";[UIA]AutomationId=\'2\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Toolbar1 query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceToolbar1 = ";[UIA]AutomationId=\'0\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for ProgressBar2 query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceProgressBar2 = ";[UIA]AutomationId=\'0\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for AddressCUsersasttestAppDataLocalTemp1 query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAddressCUsersasttestAppDataLocalTemp1 = ";[UIA]AutomationId=\'1001\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Toolbar3 query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceToolbar3 = ";[UIA]AutomationId=\'0\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for SearchBox query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSearchBox = ";[UIA]AutomationId=\'SearchEditBox\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for SearchButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSearchButton = ";[UIA]AutomationId=\'SearchBoxSearchButton\'";
            #endregion
            
            #region Properties
                             
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the CommandModule resource qid string
            /// </summary>
            /// <history>
            ///   [v-tfeng] 10/12/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID CommandModule
            {
                get
                {
                    return new QID(ResourceCommandModule);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the HelpButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-tfeng] 10/12/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID HelpButton
            {
                get
                {
                    return new QID(ResourceHelpButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ViewsButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-tfeng] 10/12/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ViewsButton
            {
                get
                {
                    return new QID(ResourceViewsButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ViewSliderButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-tfeng] 10/12/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ViewSliderButton
            {
                get
                {
                    return new QID(ResourceViewSliderButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the OrganizeButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-tfeng] 10/12/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID OrganizeButton
            {
                get
                {
                    return new QID(ResourceOrganizeButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the NewFolderButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-tfeng] 10/12/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID NewFolderButton
            {
                get
                {
                    return new QID(ResourceNewFolderButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the NamespaceTreeControl resource qid string
            /// </summary>
            /// <history>
            ///   [v-tfeng] 10/12/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID NamespaceTreeControl
            {
                get
                {
                    return new QID(ResourceNamespaceTreeControl);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ColumnLeftButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-tfeng] 10/12/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ColumnLeftButton
            {
                get
                {
                    return new QID(ResourceColumnLeftButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the PageRightButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-tfeng] 10/12/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID PageRightButton
            {
                get
                {
                    return new QID(ResourcePageRightButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ColumnRightButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-tfeng] 10/12/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ColumnRightButton
            {
                get
                {
                    return new QID(ResourceColumnRightButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the NameButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-tfeng] 10/12/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID NameButton
            {
                get
                {
                    return new QID(ResourceNameButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the FilterDropdownButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-tfeng] 10/12/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID FilterDropdownButton
            {
                get
                {
                    return new QID(ResourceFilterDropdownButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the DateModifiedButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-tfeng] 10/12/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID DateModifiedButton
            {
                get
                {
                    return new QID(ResourceDateModifiedButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the FilterDropdownButton2 resource qid string
            /// </summary>
            /// <history>
            ///   [v-tfeng] 10/12/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID FilterDropdownButton2
            {
                get
                {
                    return new QID(ResourceFilterDropdownButton2);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the TypeButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-tfeng] 10/12/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID TypeButton
            {
                get
                {
                    return new QID(ResourceTypeButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the FilterDropdownButton3 resource qid string
            /// </summary>
            /// <history>
            ///   [v-tfeng] 10/12/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID FilterDropdownButton3
            {
                get
                {
                    return new QID(ResourceFilterDropdownButton3);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the SizeButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-tfeng] 10/12/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SizeButton
            {
                get
                {
                    return new QID(ResourceSizeButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the FilterDropdownButton4 resource qid string
            /// </summary>
            /// <history>
            ///   [v-tfeng] 10/12/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID FilterDropdownButton4
            {
                get
                {
                    return new QID(ResourceFilterDropdownButton4);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the FileName resource qid string
            /// </summary>
            /// <history>
            ///   [v-tfeng] 10/12/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID FileName
            {
                get
                {
                    return new QID(ResourceFileName);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the FileName3TextBox2 resource qid string
            /// </summary>
            /// <history>
            ///   [v-tfeng] 10/12/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID FileName3TextBox2
            {
                get
                {
                    return new QID(ResourceFileName3TextBox2);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the FileName4ListView2 resource qid string
            /// </summary>
            /// <history>
            ///   [v-tfeng] 10/12/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID FileName4ListView2
            {
                get
                {
                    return new QID(ResourceFileName4ListView2);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the SaveAsType resource qid string
            /// </summary>
            /// <history>
            ///   [v-tfeng] 10/12/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SaveAsType
            {
                get
                {
                    return new QID(ResourceSaveAsType);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the SaveAsType3ListView2 resource qid string
            /// </summary>
            /// <history>
            ///   [v-tfeng] 10/12/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SaveAsType3ListView2
            {
                get
                {
                    return new QID(ResourceSaveAsType3ListView2);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the SaveFields resource qid string
            /// </summary>
            /// <history>
            ///   [v-tfeng] 10/12/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SaveFields
            {
                get
                {
                    return new QID(ResourceSaveFields);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ApplicationControls resource qid string
            /// </summary>
            /// <history>
            ///   [v-tfeng] 10/12/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ApplicationControls
            {
                get
                {
                    return new QID(ResourceApplicationControls);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Toolbar0 resource qid string
            /// </summary>
            /// <history>
            ///   [v-tfeng] 10/12/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID Toolbar0
            {
                get
                {
                    return new QID(ResourceToolbar0);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the SaveButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-tfeng] 10/12/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SaveButton
            {
                get
                {
                    return new QID(ResourceSaveButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the CancelButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-tfeng] 10/12/2011 Created
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
            /// Gets access to the Toolbar1 resource qid string
            /// </summary>
            /// <history>
            ///   [v-tfeng] 10/12/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID Toolbar1
            {
                get
                {
                    return new QID(ResourceToolbar1);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ProgressBar2 resource qid string
            /// </summary>
            /// <history>
            ///   [v-tfeng] 10/12/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ProgressBar2
            {
                get
                {
                    return new QID(ResourceProgressBar2);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the AddressCUsersasttestAppDataLocalTemp1 resource qid string
            /// </summary>
            /// <history>
            ///   [v-tfeng] 10/12/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID AddressCUsersasttestAppDataLocalTemp1
            {
                get
                {
                    return new QID(ResourceAddressCUsersasttestAppDataLocalTemp1);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Toolbar3 resource qid string
            /// </summary>
            /// <history>
            ///   [v-tfeng] 10/12/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID Toolbar3
            {
                get
                {
                    return new QID(ResourceToolbar3);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the SearchBox resource qid string
            /// </summary>
            /// <history>
            ///   [v-tfeng] 10/12/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SearchBox
            {
                get
                {
                    return new QID(ResourceSearchBox);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the SearchButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-tfeng] 10/12/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SearchButton
            {
                get
                {
                    return new QID(ResourceSearchButton);
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
        ///   [v-tfeng] 10/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            /// <summary>
            /// Resource string for Save Distributed Application as Template
            /// </summary>
            /// TODO: UIClassMaker could not find the resource for this string.  Find it and replace literal created by tool.
            public const string DialogTitle = "Save Distributed Application as Template";
            
            /// <summary>
            /// Resource string for Command Module
            /// </summary>
            public const string CommandModule = ";Command Module;Win32String;SHELL32.dll;31747";
            
            /// <summary>
            /// Resource string for Help
            /// </summary>
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// ;Help;Win32DialogItemString;comctl32.dll;200;205
            /// ;Help;Win32DialogItemString;comctl32.dll;1006;9
            /// ;Help;Win32DialogItemString;comctl32.dll;1020;9
            /// ;Help;Win32DialogItemString;Comctl32.dll;200;205
            /// ;Help;Win32DialogItemString;Comctl32.dll;1006;9
            /// ;Help;Win32DialogItemString;Comctl32.dll;1020;9
            /// ;Help;Win32DialogItemString;comdlg32.dll;CHOOSECOLOR;1038
            /// ;Help;Win32DialogItemString;comdlg32.dll;CHOOSECOLORFLIPPED;1038
            /// ;Help;Win32DialogItemString;comdlg32.dll;1536;1038
            /// ;Help;Win32DialogItemString;comdlg32.dll;1537;1038
            /// ;Help;Win32DialogItemString;comdlg32.dll;1538;1038
            /// ;Help;Win32DialogItemString;comdlg32.dll;1539;1038
            /// ;Help;Win32DialogItemString;comdlg32.dll;1540;1038
            /// ;Help;Win32DialogItemString;comdlg32.dll;1541;1038
            /// ;Help;Win32DialogItemString;comdlg32.dll;1543;1038
            /// ;Help;Win32DialogItemString;comdlg32.dll;1546;1038
            /// ;Help;Win32DialogItemString;comdlg32.dll;1547;1038
            /// ;Help;Win32DialogItemString;comdlg32.dll;1552;1038
            /// ;Help;Win32DialogItemString;comdlg32.dll;1553;1038
            /// ;Help;Win32DialogItemString;comdlg32.dll;1554;1038
            /// ;Help;Win32DialogItemString;comdlg32.dll;1555;1038
            /// ;Help;Win32DialogItemString;comdlg32.dll;1556;1038
            /// ;Help;Win32DialogItemString;comdlg32.dll;1557;1038
            /// ;Help;Win32DialogItemString;comdlg32.dll;1558;1038
            /// ;Help;Win32DialogItemString;comdlg32.dll;1559;1038
            /// ;Help;Win32DialogItemString;comdlg32.dll;1560;1038
            /// ;Help;Win32DialogItemString;comdlg32.dll;1561;1038
            /// ;Help;Win32DialogItemString;comdlg32.dll;1562;1038
            /// ;Help;Win32DialogItemString;comdlg32.dll;1563;1038
            /// ;Help;Win32DialogItemString;comdlg32.dll;1565;1038
            /// ;Help;Win32DialogItemString;comdlg32.dll;1567;1038
            /// ;Help;Win32DialogItemString;comdlg32.dll;1569;1038
            /// ;Help;Win32DialogItemString;comdlg32.dll;1570;1038
            /// ;Help;Win32DialogItemString;comdlg32.dll;1591;1038
            /// ;Help;NativeMenuString;explorerframe.dll;263;7p
            /// ;Help;NativeMenuString;explorerframe.dll;266;8p
            /// ;Help;Win32String;ieframe.dll;18001
            /// ;Help;Win32DialogItemString;ieframe.dll;8155;1038
            /// ;Help;NativeMenuString;ieframe.dll;266;4p
            /// ;Help;NativeMenuString;ieframe.dll;267;6p
            /// ;Help;NativeMenuString;ieframe.dll;338;1p
            /// ;Help;NativeMenuString;ieframe.dll;907;9p
            /// ;Help;NativeMenuString;ieframe.dll;908;5p
            /// ;Help;Win32DialogItemString;InoShell.dll;30721;-7866
            /// ;Help;Win32String;MSCTF.dll;227
            /// ;Help;Win32String;MSCTF.dll;228
            /// ;Help;Win32String;SHELL32.dll;30489
            /// ;Help;Win32String;SHELL32.dll;31150
            /// ;Help;NativeMenuString;SHELL32.dll;506;4
            /// ;Help;Win32String;USER32.dll;808
            /// ;Help;Win32String;USER32.dll;904
            /// ;Help;Win32DialogItemString;WININET.dll;104;1012
            /// </remark>
            public const string Help = ";Help;Win32String;comctl32.dll;4357";
            
            /// <summary>
            /// Resource string for Views
            /// </summary>
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// ;Views;Win32String;SHELL32.dll;31296
            /// ;Views;Win32String;SHELL32.dll;33585
            /// </remark>
            public const string Views = ";Views;Win32String;SHELL32.dll;31145";
            
            /// <summary>
            /// Resource string for View Slider
            /// </summary>
            public const string ViewSlider = ";View Slider;Win32String;SHELL32.dll;31147";
            
            /// <summary>
            /// Resource string for Organize
            /// </summary>
            public const string Organize = ";Organize;Win32String;SHELL32.dll;31411";
            
            /// <summary>
            /// Resource string for New folder
            /// </summary>
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// ;New folder;Win32String;SHELL32.dll;30396
            /// ;New folder;Win32String;SHELL32.dll;31236
            /// </remark>
            public const string NewFolder = ";New folder;Win32DialogItemString;ieframe.dll;336;339";
            
            /// <summary>
            /// Resource string for Namespace Tree Control
            /// </summary>
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// ;Namespace Tree Control;Win32String;ieframe.dll;3009
            /// </remark>
            public const string NamespaceTreeControl = ";Namespace Tree Control;Win32String;explorerframe.dll;3009";
            
            /// <summary>
            /// Resource string for Items View
            /// </summary>
            public const string ItemsView = ";Items View;Win32String;explorerframe.dll;41219";
            
            /// <summary>
            /// Resource string for Column left
            /// </summary>
            /// TODO: UIClassMaker could not find the resource for this string.  Find it and replace literal created by tool.
            public const string ColumnLeft = "Column left";
            
            /// <summary>
            /// Resource string for Page right
            /// </summary>
            /// TODO: UIClassMaker could not find the resource for this string.  Find it and replace literal created by tool.
            public const string PageRight = "Page right";
            
            /// <summary>
            /// Resource string for Column right
            /// </summary>
            /// TODO: UIClassMaker could not find the resource for this string.  Find it and replace literal created by tool.
            public const string ColumnRight = "Column right";
            
            /// <summary>
            /// Resource string for Header
            /// </summary>
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// ;Header;Win32DialogItemString;ieframe.dll;1546;8146
            /// </remark>
            public const string Header = ";Header;Win32String;explorerframe.dll;41222";
            
            /// <summary>
            /// Resource string for Name
            /// </summary>
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// ;Name;Win32DialogItemString;comdlg32.dll;1538;1093
            /// ;Name;Win32DialogItemString;comdlg32.dll;1539;1093
            /// ;Name;Win32DialogItemString;comdlg32.dll;1556;1093
            /// ;Name;Win32DialogItemString;comdlg32.dll;1557;1093
            /// ;Name;Win32String;ieframe.dll;12481
            /// ;Name;Win32String;ieframe.dll;20845
            /// ;Name;Win32String;ieframe.dll;39232
            /// ;Name;Win32String;ieframe.dll;40960
            /// ;Name;Win32DialogItemString;ieframe.dll;336;-1
            /// ;Name;Win32DialogItemString;ieframe.dll;1538;1093
            /// ;Name;Win32DialogItemString;ieframe.dll;2001;2011
            /// ;Name;Win32DialogItemString;ieframe.dll;2101;2011
            /// ;Name;Win32DialogItemString;ieframe.dll;3856;16384
            /// ;Name;Win32DialogItemString;ieframe.dll;3857;16384
            /// ;Name;Win32DialogItemString;ieframe.dll;4416;65535
            /// ;Name;Win32DialogItemString;ieframe.dll;21400;-1
            /// ;Name;Win32DialogItemString;ieframe.dll;21403;-1
            /// ;Name;Win32DialogItemString;ieframe.dll;30800;-1
            /// ;Name;Win32DialogItemString;ieframe.dll;30832;-1
            /// ;Name;Win32DialogItemString;ieframe.dll;37378;65535
            /// ;Name;Win32DialogItemString;ieframe.dll;38144;-1
            /// ;Name;Win32String;NetworkExplorer.dll;1002
            /// ;Name;Win32String;NetworkExplorer.dll;1010
            /// ;Name;Win32String;ntshrui.dll;3324
            /// ;Name;Win32String;PROPSYS.dll;38671
            /// ;Name;Win32String;PROPSYS.dll;38927
            /// ;Name;Win32DialogItemString;SHDOCVW.dll;4416;65535
            /// ;Name;Win32String;SHELL32.dll;8976
            /// ;Name;Win32String;SHELL32.dll;13631
            /// ;Name;Win32String;SHELL32.dll;34839
            /// ;Name;Win32String;WININET.dll;4023
            /// ;Name;Win32DialogItemString;WININET.dll;104;65535
            /// </remark>
            public const string Name = ";Name;Win32String;comdlg32.dll;900";
            
            /// <summary>
            /// Resource string for Filter dropdown
            /// </summary>
            public const string FilterDropdown = ";Filter dropdown;Win32String;explorerframe.dll;41223";
            
            /// <summary>
            /// Resource string for Date modified
            /// </summary>
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// ;Date modified;Win32String;SHELL32.dll;34819
            /// </remark>
            public const string DateModified = ";Date modified;Win32String;PROPSYS.dll;38407";
            
            /// <summary>
            /// Resource string for Filter dropdown
            /// </summary>
            public const string FilterDropdown2 = ";Filter dropdown;Win32String;explorerframe.dll;41223";
            
            /// <summary>
            /// Resource string for Type
            /// </summary>
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// ;Type;Win32DialogItemString;comdlg32.dll;1539;1094
            /// ;Type;Win32DialogItemString;comdlg32.dll;1556;1094
            /// ;Type;Win32DialogItemString;comdlg32.dll;1557;1094
            /// ;Type;Win32String;ieframe.dll;20831
            /// ;Type;Win32String;ieframe.dll;39236
            /// ;Type;Win32String;ieframe.dll;39282
            /// ;Type;Win32String;ieframe.dll;40962
            /// ;Type;Win32DialogItemString;ieframe.dll;1538;1094
            /// ;Type;Win32DialogItemString;ieframe.dll;4416;4422
            /// ;Type;Win32DialogItemString;ieframe.dll;21080;65535
            /// ;Type;Win32DialogItemString;ieframe.dll;21180;21084
            /// ;Type;Win32DialogItemString;ieframe.dll;37378;65535
            /// ;Type;Win32String;NetworkExplorer.dll;1021
            /// ;Type;Win32String;PROPSYS.dll;38636
            /// ;Type;Win32String;PROPSYS.dll;38942
            /// ;Type;Win32String;PROPSYS.dll;40981
            /// ;Type;Win32String;PROPSYS.dll;41226
            /// ;Type;Win32DialogItemString;SHDOCVW.dll;4416;4422
            /// ;Type;Win32String;SHELL32.dll;8979
            /// ;Type;Win32String;SHELL32.dll;12549
            /// ;Type;Win32String;SHELL32.dll;34821
            /// ;Type;Win32String;SHELL32.dll;37120
            /// ;Type;Win32DialogItemString;SHELL32.dll;1042;13080
            /// ;Type;Win32DialogItemString;SHELL32.dll;1044;13080
            /// ;Type;Win32DialogItemString;SHELL32.dll;1047;13080
            /// ;Type;Win32DialogItemString;SHELL32.dll;1048;13080
            /// ;Type;Win32DialogItemString;SHELL32.dll;1080;14414
            /// ;Type;Win32DialogItemString;SHELL32.dll;1098;13080
            /// </remark>
            public const string Type = ";Type;Win32DialogItemString;comdlg32.dll;1538;1094";
            
            /// <summary>
            /// Resource string for Filter dropdown
            /// </summary>
            public const string FilterDropdown3 = ";Filter dropdown;Win32String;explorerframe.dll;41223";
            
            /// <summary>
            /// Resource string for Size
            /// </summary>
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// ;Size;Win32DialogItemString;comdlg32.dll;1543;1090
            /// ;Size;Win32DialogItemString;comdlg32.dll;1546;1089
            /// ;Size;Win32DialogItemString;comdlg32.dll;1557;1089
            /// ;Size;Win32DialogItemString;comdlg32.dll;1560;1090
            /// ;Size;Win32DialogItemString;comdlg32.dll;1561;1089
            /// ;Size;Win32DialogItemString;comdlg32.dll;1567;1090
            /// ;Size;Win32DialogItemString;comdlg32.dll;1569;1090
            /// ;Size;Win32DialogItemString;comdlg32.dll;1570;1090
            /// ;Size;Win32DialogItemString;comdlg32.dll;1591;1090
            /// ;Size;Win32String;ieframe.dll;20830
            /// ;Size;Win32DialogItemString;ieframe.dll;8155;1090
            /// ;Size;Win32DialogItemString;ieframe.dll;21080;65535
            /// ;Size;Win32String;PROPSYS.dll;38657
            /// ;Size;Win32String;SHELL32.dll;8978
            /// ;Size;Win32DialogItemString;SHELL32.dll;1041;13081
            /// ;Size;Win32DialogItemString;SHELL32.dll;1042;13081
            /// ;Size;Win32DialogItemString;SHELL32.dll;1044;13081
            /// ;Size;Win32DialogItemString;SHELL32.dll;1047;13081
            /// ;Size;Win32DialogItemString;SHELL32.dll;32805;32817
            /// ;Size;NativeMenuString;SHELL32.dll;502;2p
            /// ;Size;NativeMenuString;USER32.dll;16;61440
            /// ;Size;NativeMenuString;USER32.dll;32;61440
            /// </remark>
            public const string Size = ";Size;Win32DialogItemString;comdlg32.dll;1539;1089";
            
            /// <summary>
            /// Resource string for Filter dropdown
            /// </summary>
            public const string FilterDropdown4 = ";Filter dropdown;Win32String;explorerframe.dll;41223";
            
            /// <summary>
            /// Resource string for File name:
            /// </summary>
            /// TODO: UIClassMaker could not find the resource for this string.  Find it and replace literal created by tool.
            public const string FileName4 = "File name:";
            
            /// <summary>
            /// Resource string for Save as type:
            /// </summary>
            /// TODO: UIClassMaker could not find the resource for this string.  Find it and replace literal created by tool.
            public const string SaveAsType = "Save as type:";
            
            /// <summary>
            /// Resource string for Save as type:
            /// </summary>
            /// TODO: UIClassMaker could not find the resource for this string.  Find it and replace literal created by tool.
            public const string SaveAsType3 = "Save as type:";
            
            /// <summary>
            /// Resource string for Save Fields
            /// </summary>
            public const string SaveFields = ";Save Fields;Win32String;SHELL32.dll;38225";
            
            /// <summary>
            /// Resource string for Application Controls
            /// </summary>
            public const string ApplicationControls = ";Application Controls;Win32String;SHELL32.dll;38233";
            
            /// <summary>
            /// Resource string for Save
            /// </summary>
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// ;Save;Win32String;ieframe.dll;20070
            /// ;Save;Win32DialogItemString;ieframe.dll;4416;4427
            /// ;Save;Win32DialogItemString;ieframe.dll;4496;4504
            /// ;Save;Win32DialogItemString;ieframe.dll;37378;4427
            /// ;Save;Win32DialogItemString;inetres.dll;104;1
            /// ;Save;Win32DialogItemString;SHDOCVW.dll;4416;4427
            /// ;Save;Win32String;SHELL32.dll;38243
            /// </remark>
            public const string Save = ";Save;Win32String;comdlg32.dll;369";
            
            /// <summary>
            /// Resource string for Cancel
            /// </summary>
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// ;Cancel;Win32String;comctl32.dll;6882
            /// ;Cancel;Win32DialogItemString;comctl32.dll;1006;2
            /// ;Cancel;Win32DialogItemString;comctl32.dll;1020;2
            /// ;Cancel;Win32DialogItemString;Comctl32.dll;1006;2
            /// ;Cancel;Win32DialogItemString;Comctl32.dll;1020;2
            /// ;Cancel;Win32String;comdlg32.dll;372
            /// ;Cancel;Win32DialogItemString;comdlg32.dll;CHOOSECOLOR;2
            /// ;Cancel;Win32DialogItemString;comdlg32.dll;CHOOSECOLORFLIPPED;2
            /// ;Cancel;Win32DialogItemString;comdlg32.dll;1536;2
            /// ;Cancel;Win32DialogItemString;comdlg32.dll;1537;2
            /// ;Cancel;Win32DialogItemString;comdlg32.dll;1538;2
            /// ;Cancel;Win32DialogItemString;comdlg32.dll;1539;2
            /// ;Cancel;Win32DialogItemString;comdlg32.dll;1540;2
            /// ;Cancel;Win32DialogItemString;comdlg32.dll;1541;2
            /// ;Cancel;Win32DialogItemString;comdlg32.dll;1543;2
            /// ;Cancel;Win32DialogItemString;comdlg32.dll;1546;2
            /// ;Cancel;Win32DialogItemString;comdlg32.dll;1547;2
            /// ;Cancel;Win32DialogItemString;comdlg32.dll;1552;2
            /// ;Cancel;Win32DialogItemString;comdlg32.dll;1553;2
            /// ;Cancel;Win32DialogItemString;comdlg32.dll;1554;2
            /// ;Cancel;Win32DialogItemString;comdlg32.dll;1555;2
            /// ;Cancel;Win32DialogItemString;comdlg32.dll;1556;2
            /// ;Cancel;Win32DialogItemString;comdlg32.dll;1557;2
            /// ;Cancel;Win32DialogItemString;comdlg32.dll;1558;2
            /// ;Cancel;Win32DialogItemString;comdlg32.dll;1559;2
            /// ;Cancel;Win32DialogItemString;comdlg32.dll;1560;2
            /// ;Cancel;Win32DialogItemString;comdlg32.dll;1561;2
            /// ;Cancel;Win32DialogItemString;comdlg32.dll;1562;2
            /// ;Cancel;Win32DialogItemString;comdlg32.dll;1563;2
            /// ;Cancel;Win32DialogItemString;comdlg32.dll;1565;2
            /// ;Cancel;Win32DialogItemString;comdlg32.dll;1567;2
            /// ;Cancel;Win32DialogItemString;comdlg32.dll;1569;2
            /// ;Cancel;Win32DialogItemString;comdlg32.dll;1570;2
            /// ;Cancel;Win32DialogItemString;comdlg32.dll;1591;2
            /// ;Cancel;Win32String;ieframe.dll;41609
            /// ;Cancel;Win32String;ieframe.dll;42122
            /// ;Cancel;Win32DialogItemString;ieframe.dll;336;2
            /// ;Cancel;Win32DialogItemString;ieframe.dll;340;2
            /// ;Cancel;Win32DialogItemString;ieframe.dll;344;2
            /// ;Cancel;Win32DialogItemString;ieframe.dll;1538;2
            /// ;Cancel;Win32DialogItemString;ieframe.dll;1546;2
            /// ;Cancel;Win32DialogItemString;ieframe.dll;3255;2
            /// ;Cancel;Win32DialogItemString;ieframe.dll;3856;2
            /// ;Cancel;Win32DialogItemString;ieframe.dll;3857;2
            /// ;Cancel;Win32DialogItemString;ieframe.dll;4352;2
            /// ;Cancel;Win32DialogItemString;ieframe.dll;4416;2
            /// ;Cancel;Win32DialogItemString;ieframe.dll;4464;2
            /// ;Cancel;Win32DialogItemString;ieframe.dll;4480;2
            /// ;Cancel;Win32DialogItemString;ieframe.dll;4496;2
            /// ;Cancel;Win32DialogItemString;ieframe.dll;4608;2
            /// ;Cancel;Win32DialogItemString;ieframe.dll;8131;2
            /// ;Cancel;Win32DialogItemString;ieframe.dll;8143;2
            /// ;Cancel;Win32DialogItemString;ieframe.dll;8155;2
            /// ;Cancel;Win32DialogItemString;ieframe.dll;8192;2
            /// ;Cancel;Win32DialogItemString;ieframe.dll;10505;2
            /// ;Cancel;Win32DialogItemString;ieframe.dll;13121;2
            /// ;Cancel;Win32DialogItemString;ieframe.dll;16897;2
            /// ;Cancel;Win32DialogItemString;ieframe.dll;17154;7
            /// ;Cancel;Win32DialogItemString;ieframe.dll;17232;2
            /// ;Cancel;Win32DialogItemString;ieframe.dll;17424;2
            /// ;Cancel;Win32DialogItemString;ieframe.dll;21135;2
            /// ;Cancel;Win32DialogItemString;ieframe.dll;21400;2
            /// ;Cancel;Win32DialogItemString;ieframe.dll;21402;2
            /// ;Cancel;Win32DialogItemString;ieframe.dll;21403;2
            /// ;Cancel;Win32DialogItemString;ieframe.dll;30800;2
            /// ;Cancel;Win32DialogItemString;ieframe.dll;30832;2
            /// ;Cancel;Win32DialogItemString;ieframe.dll;37378;2
            /// ;Cancel;Win32DialogItemString;ieframe.dll;37440;2
            /// ;Cancel;Win32DialogItemString;ieframe.dll;41088;2
            /// ;Cancel;Win32DialogItemString;ieframe.dll;41216;2
            /// ;Cancel;Win32DialogItemString;ieframe.dll;41760;2
            /// ;Cancel;Win32DialogItemString;ieframe.dll;41984;2
            /// ;Cancel;Win32DialogItemString;ieframe.dll;41989;2
            /// ;Cancel;Win32DialogItemString;ieframe.dll;42065;2
            /// ;Cancel;NativeMenuString;ieframe.dll;24645;0
            /// ;Cancel;Win32DialogItemString;inetres.dll;102;2
            /// ;Cancel;Win32DialogItemString;inetres.dll;103;2
            /// ;Cancel;Win32DialogItemString;inetres.dll;104;2
            /// ;Cancel;Win32DialogItemString;inetres.dll;105;2
            /// ;Cancel;Win32DialogItemString;inetres.dll;106;2
            /// ;Cancel;Win32DialogItemString;inetres.dll;107;2
            /// ;Cancel;Win32DialogItemString;InoShell.dll;30721;2
            /// ;Cancel;Win32DialogItemString;MPR.dll;7015;2
            /// ;Cancel;Win32String;MSCTF.dll;101
            /// ;Cancel;Win32DialogItemString;MSOERT2.dll;101;2
            /// ;Cancel;Win32DialogItemString;ntshrui.dll;1009;2
            /// ;Cancel;Win32DialogItemString;ntshrui.dll;1018;2
            /// ;Cancel;Win32DialogItemString;ole32.dll;101;2
            /// ;Cancel;Win32String;SearchFolder.dll;38276
            /// ;Cancel;Win32String;SearchFolder.dll;38284
            /// ;Cancel;Win32DialogItemString;SETUPAPI.dll;57;2
            /// ;Cancel;Win32DialogItemString;SETUPAPI.dll;100;2
            /// ;Cancel;Win32DialogItemString;SETUPAPI.dll;200;2
            /// ;Cancel;Win32DialogItemString;SETUPAPI.dll;300;2
            /// ;Cancel;Win32DialogItemString;SETUPAPI.dll;350;2
            /// ;Cancel;Win32DialogItemString;SETUPAPI.dll;2100;2
            /// ;Cancel;Win32DialogItemString;SHDOCVW.dll;4416;2
            /// ;Cancel;Win32String;SHELL32.dll;13588
            /// ;Cancel;Win32String;SHELL32.dll;13603
            /// ;Cancel;Win32String;SHELL32.dll;28743
            /// ;Cancel;Win32String;SHELL32.dll;38244
            /// ;Cancel;Win32String;SHELL32.dll;38317
            /// ;Cancel;Win32String;SHELL32.dll;50117
            /// ;Cancel;Win32String;SHELL32.dll;61955
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;1003;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;1004;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;1005;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;1006;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;1008;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;1011;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;1024;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;1049;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;1054;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;1055;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;1056;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;1058;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;1060;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;1063;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;1070;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;1072;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;1079;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;1087;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;1091;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;1096;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;1103;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;1104;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;1119;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;8192;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;14369;14529
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;16817;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;16896;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;16897;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;16898;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;16900;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;16901;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;16902;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;16903;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;16904;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;16905;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;16907;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;16908;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;16909;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;16913;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;16914;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;16918;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;16919;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;16920;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;16922;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;16935;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;16936;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;16939;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;16940;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;20480;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;20481;2
            /// ;Cancel;Win32DialogItemString;SHELL32.dll;28800;2
            /// ;Cancel;NativeMenuString;SHELL32.dll;195;0
            /// ;Cancel;NativeMenuString;SHELL32.dll;196;0
            /// ;Cancel;NativeMenuString;SHELL32.dll;197;0
            /// ;Cancel;NativeMenuString;SHELL32.dll;198;0
            /// ;Cancel;NativeMenuString;SHELL32.dll;199;0
            /// ;Cancel;NativeMenuString;SHELL32.dll;200;0
            /// ;Cancel;NativeMenuString;SHELL32.dll;201;0
            /// ;Cancel;NativeMenuString;SHELL32.dll;202;0
            /// ;Cancel;NativeMenuString;SHELL32.dll;203;0
            /// ;Cancel;NativeMenuString;SHELL32.dll;204;0
            /// ;Cancel;NativeMenuString;SHELL32.dll;205;0
            /// ;Cancel;NativeMenuString;SHELL32.dll;206;0
            /// ;Cancel;NativeMenuString;SHELL32.dll;207;0
            /// ;Cancel;NativeMenuString;SHELL32.dll;208;0
            /// ;Cancel;NativeMenuString;SHELL32.dll;209;0
            /// ;Cancel;NativeMenuString;SHELL32.dll;269;0
            /// ;Cancel;NativeMenuString;SHELL32.dll;277;0
            /// ;Cancel;Win32String;USER32.dll;801
            /// ;Cancel;Win32DialogItemString;USER32.dll;9;2
            /// ;Cancel;Win32String;WININET.dll;2007
            /// ;Cancel;Win32DialogItemString;WININET.dll;101;2
            /// ;Cancel;Win32DialogItemString;WINSPOOL.DRV;100;2
            /// </remark>
            public const string Cancel = ";Cancel;Win32String;comctl32.dll;4241";
            
            /// <summary>
            /// Resource string for Address: C:\Users\asttest\AppData\Local\Temp\1
            /// </summary>
            /// TODO: UIClassMaker could not find the resource for this string.  Find it and replace literal created by tool.
            public const string AddressCUsersasttestAppDataLocalTemp1 = "Address: C:\\Users\\asttest\\AppData\\Local\\Temp\\1";
            
            /// <summary>
            /// Resource string for Search
            /// </summary>
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// ;Search;Win32String;ieframe.dll;13824
            /// ;Search;Win32String;SearchFolder.dll;30523
            /// ;Search;Win32String;SHELL32.dll;8503
            /// ;Search;Win32String;SHELL32.dll;12708
            /// ;Search;Win32String;SHELL32.dll;30517
            /// ;Search;Win32DialogString;SHELL32.dll;29961
            /// </remark>
            public const string Search = ";Search;Win32String;ieframe.dll;12897";
        }
        #endregion
    }
}
