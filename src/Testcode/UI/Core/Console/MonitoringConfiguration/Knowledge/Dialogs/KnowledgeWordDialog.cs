// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="KnowledgeWordDialog.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	Mom.Test.UI.Core.Console.MonitoringConfiguration.Knowledge
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[barryw] 12/18/2005 Created
//  [faizalk] 27MAR06 Change TaskPane to ActionsPane
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Knowledge.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    
    #region Interface Definition - IKnowledgeWordDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IKnowledgeWordDialogControls, for KnowledgeWordDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[barryw] 12/18/2005 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IKnowledgeWordDialogControls
    {
        /// <summary>
        /// Read-only property to access ActionsPane
        /// </summary>
        Toolbar ActionsPane
        {
            get;
        }

        /// <summary>
        /// Read-only property to access DocumentPane
        /// </summary>
        TextBox DocumentPane
        {
            get;
        }

        /// <summary>
        /// Read-only property to access LinkEditComboBox
        /// </summary>
        EditComboBox LinkEditComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LinkStaticControl
        /// </summary>
        StaticControl LinkStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AddLinkButton
        /// </summary>
        Button AddLinkButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LinkName
        /// </summary>
        TextBox LinkName
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LinkTypeEditComboBox
        /// </summary>
        EditComboBox LinkTypeEditComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LinkTypeTextBox
        /// </summary>
        TextBox LinkTypeTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NameStaticControl
        /// </summary>
        StaticControl NameStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LinkTypeStaticControl
        /// </summary>
        StaticControl LinkTypeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Formatting
        /// </summary>
        Toolbar Formatting
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
        /// Read-only property to access ComboBox2
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        ComboBox ComboBox2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Standard
        /// </summary>
        Toolbar Standard
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ComboBox3
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        ComboBox ComboBox3
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MainMenu
        /// </summary>
        Toolbar MainMenu
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StandardMenuBar
        /// </summary>
        Toolbar StandardMenuBar
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
    /// 	[barryw] 12/18/2005 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class KnowledgeWordDialog : Dialog, IKnowledgeWordDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ActionsPane of type Toolbar
        /// </summary>
        private Toolbar cachedActionsPane;

        /// <summary>
        /// Cache to hold a reference to DocumentPane of type Toolbar
        /// </summary>
        private TextBox cachedDocumentPane;

        /// <summary>
        /// Cache to hold a reference to LinkEditComboBox of type EditComboBox
        /// </summary>
        private EditComboBox cachedLinkEditComboBox;
        
        /// <summary>
        /// Cache to hold a reference to LinkStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedLinkStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AddLinkButton of type Button
        /// </summary>
        private Button cachedAddLinkButton;
        
        /// <summary>
        /// Cache to hold a reference to LinkName of type TextBox
        /// </summary>
        private TextBox cachedLinkName;
        
        /// <summary>
        /// Cache to hold a reference to LinkTypeEditComboBox of type EditComboBox
        /// </summary>
        private EditComboBox cachedLinkTypeEditComboBox;
        
        /// <summary>
        /// Cache to hold a reference to LinkTypeTextBox of type TextBox
        /// </summary>
        private TextBox cachedLinkTypeTextBox;
        
        /// <summary>
        /// Cache to hold a reference to NameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNameStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to LinkTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedLinkTypeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to Formatting of type Toolbar
        /// </summary>
        private Toolbar cachedFormatting;
        
        /// <summary>
        /// Cache to hold a reference to ComboBox1 of type ComboBox
        /// </summary>
        private ComboBox cachedComboBox1;
        
        /// <summary>
        /// Cache to hold a reference to ComboBox2 of type ComboBox
        /// </summary>
        private ComboBox cachedComboBox2;
        
        /// <summary>
        /// Cache to hold a reference to Standard of type Toolbar
        /// </summary>
        private Toolbar cachedStandard;
        
        /// <summary>
        /// Cache to hold a reference to ComboBox3 of type ComboBox
        /// </summary>
        private ComboBox cachedComboBox3;
        
        /// <summary>
        /// Cache to hold a reference to MainMenu of type Toolbar
        /// </summary>
        private Toolbar cachedMainMenu;
        
        /// <summary>
        /// Cache to hold a reference to StandardMenuBar of type Toolbar
        /// </summary>
        private Toolbar cachedStandardMenuBar;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of KnowledgeWordDialog of type MomConsoleApp.
        /// </param>
        /// <history>
        /// 	[barryw] 12/18/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public KnowledgeWordDialog(Mom.Test.UI.Core.Console.MomConsoleApp app) : 
                base(app, Init(app, Strings.DialogTitle))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
        }

        #endregion
        
        #region IKnowledgeWordDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[barryw] 12/18/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IKnowledgeWordDialogControls Controls
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
        ///  Routine to set/get the text in control Link
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[barryw] 12/18/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string LinkText
        {
            get
            {
                return this.Controls.LinkEditComboBox.Text;
            }
            
            set
            {
                this.Controls.LinkEditComboBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Name
        /// </summary>
        /// <value>Name of the link</value>
        /// <history>
        /// 	[barryw] 12/18/2005 Created
        /// 	[barryw] 01/20/2006 Renamed to LinkName.
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string LinkName
        {
            get
            {
                return this.Controls.LinkName.Text;
            }
            
            set
            {
                this.Controls.LinkName.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control LinkType
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[barryw] 12/18/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string LinkTypeText
        {
            get
            {
                return this.Controls.LinkTypeEditComboBox.Text;
            }
            
            set
            {
                this.Controls.LinkTypeEditComboBox.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set the text in control LinkType by clicking item in dropdown.
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[barryw] 01/20/2006 Created.
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string LinkTypeSelectByText
        {
            get
            {
                return this.Controls.LinkTypeEditComboBox.Text;
            }
            
            set
            {
                this.Controls.LinkTypeEditComboBox.SelectByText(value, true);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set the text in control Link 'action' by clicking item in dropdown.
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[barryw] 01/20/2006 Created.
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string LinkSelectByText
        {
            get
            {
                return this.Controls.LinkEditComboBox.Text;
            }

            set
            {
                this.Controls.LinkEditComboBox.SelectByText(value, true);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ComboBox1
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[barryw] 12/18/2005 Created
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
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ComboBox2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[barryw] 12/18/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ComboBox2Text
        {
            get
            {
                return this.Controls.ComboBox2.Text;
            }
            
            set
            {
                this.Controls.ComboBox2.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ComboBox3
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[barryw] 12/18/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ComboBox3Text
        {
            get
            {
                return this.Controls.ComboBox3.Text;
            }
            
            set
            {
                this.Controls.ComboBox3.SelectByText(value, true);
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ActionsPane control
        /// </summary>
        /// <history>
        /// 	[barryw] 12/18/2005 Created
        ///     [faizalk] 27MAR06 Change TaskPane to ActionsPane
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IKnowledgeWordDialogControls.ActionsPane
        {
            get
            {
                if ((this.cachedActionsPane == null))
                {
                    this.cachedActionsPane = new Toolbar(this, KnowledgeWordDialog.ControlIDs.ActionsPane);
                }
                return this.cachedActionsPane;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DocumentPane control
        /// </summary>
        /// <history>
        /// 	[barryw] 12/19/2005 Created
        /// 	[barryw] 01/20/2006 Using Textbox to represent the DocumentPane control.
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IKnowledgeWordDialogControls.DocumentPane
        {
            get
            {
                if ((this.cachedDocumentPane == null))
                {
                    this.cachedDocumentPane = new TextBox(this, KnowledgeWordDialog.ControlIDs.DocumentPane);
                }
                return this.cachedDocumentPane;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LinkEditComboBox control
        /// </summary>
        /// <history>
        /// 	[barryw] 12/18/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IKnowledgeWordDialogControls.LinkEditComboBox
        {
            get
            {
                if ((this.cachedLinkEditComboBox == null))
                {
                    this.cachedLinkEditComboBox = new EditComboBox(this, KnowledgeWordDialog.ControlIDs.LinkEditComboBox);
                }
                return this.cachedLinkEditComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LinkStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryw] 12/18/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IKnowledgeWordDialogControls.LinkStaticControl
        {
            get
            {
                if ((this.cachedLinkStaticControl == null))
                {
                    this.cachedLinkStaticControl = new StaticControl(this, KnowledgeWordDialog.ControlIDs.LinkStaticControl);
                }
                return this.cachedLinkStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddLinkButton control
        /// </summary>
        /// <history>
        /// 	[barryw] 12/18/2005 Created
        ///     [a-joelj]   09OCT09 Maui 2.0 Required Change: Calling the Button constructor with a QID.
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IKnowledgeWordDialogControls.AddLinkButton
        {
            get
            {
                if ((this.cachedAddLinkButton == null))
                {
                    // [a-joelj] - Maui 2.0 Required Change: Calling the button constructor with 'this' and the ControlID 
                    // is not returning the correct Button. Switching over to the UIA tree and using a QID with the AutomationId to
                    // get the correct button.

                    QID queryId = new QID(";[UIA]AutomationId='" + KnowledgeWordDialog.ControlIDs.AddLinkButton + "' && Role='push button'");
                    this.cachedAddLinkButton = new Button(this, queryId, Constants.DefaultContextMenuTimeout);
                }
                return this.cachedAddLinkButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LinkName control
        /// </summary>
        /// <history>
        /// 	[barryw] 12/18/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IKnowledgeWordDialogControls.LinkName
        {
            get
            {
                if ((this.cachedLinkName == null))
                {
                    this.cachedLinkName = new TextBox(this, KnowledgeWordDialog.ControlIDs.LinkName);
                }
                return this.cachedLinkName;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LinkTypeEditComboBox control
        /// </summary>
        /// <history>
        /// 	[barryw] 12/18/2005 Created
        ///     [a-joelj]   09OCT09 Maui 2.0 Required Change: Calling the ComboBox constructor with a QID.
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IKnowledgeWordDialogControls.LinkTypeEditComboBox
        {
            get
            {
                if ((this.cachedLinkTypeEditComboBox == null))
                {
                    // [a-joelj] - Maui 2.0 Required Change: Calling the ComboBox constructor with the localized string and not the ControlID
                    // is not returning the correct ComboBox. Switching over to the UIA tree and using a QID with the AutomationId to
                    // get the correct ComboBox.

                    QID queryId = new QID(";[UIA]AutomationId='" + KnowledgeWordDialog.ControlIDs.LinkTypeEditComboBox + "'");
                    this.cachedLinkTypeEditComboBox = new EditComboBox(this, queryId, Constants.DefaultContextMenuTimeout);
                }
                return this.cachedLinkTypeEditComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LinkTypeTextBox control
        /// </summary>
        /// <history>
        /// 	[barryw] 12/18/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IKnowledgeWordDialogControls.LinkTypeTextBox
        {
            get
            {
                // The ID for this control (1001) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedLinkTypeTextBox == null))
                {
                    Window wndTemp = this.App.MainWindow;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 3); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedLinkTypeTextBox = new TextBox(wndTemp);
                }
                return this.cachedLinkTypeTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryw] 12/18/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IKnowledgeWordDialogControls.NameStaticControl
        {
            get
            {
                if ((this.cachedNameStaticControl == null))
                {
                    this.cachedNameStaticControl = new StaticControl(this, KnowledgeWordDialog.ControlIDs.NameStaticControl);
                }
                return this.cachedNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LinkTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryw] 12/18/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IKnowledgeWordDialogControls.LinkTypeStaticControl
        {
            get
            {
                if ((this.cachedLinkTypeStaticControl == null))
                {
                    this.cachedLinkTypeStaticControl = new StaticControl(this, KnowledgeWordDialog.ControlIDs.LinkTypeStaticControl);
                }
                return this.cachedLinkTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Formatting control
        /// </summary>
        /// <history>
        /// 	[barryw] 12/18/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IKnowledgeWordDialogControls.Formatting
        {
            get
            {
                // The ID for this control (0) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedFormatting == null))
                {
                    Window wndTemp = this.App.MainWindow;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedFormatting = new Toolbar(wndTemp);
                }
                return this.cachedFormatting;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ComboBox1 control
        /// </summary>
        /// <history>
        /// 	[barryw] 12/18/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IKnowledgeWordDialogControls.ComboBox1
        {
            get
            {
                if ((this.cachedComboBox1 == null))
                {
                    this.cachedComboBox1 = new ComboBox(this, KnowledgeWordDialog.ControlIDs.ComboBox1);
                }
                return this.cachedComboBox1;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ComboBox2 control
        /// </summary>
        /// <history>
        /// 	[barryw] 12/18/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IKnowledgeWordDialogControls.ComboBox2
        {
            get
            {
                if ((this.cachedComboBox2 == null))
                {
                    this.cachedComboBox2 = new ComboBox(this, KnowledgeWordDialog.ControlIDs.ComboBox2);
                }
                return this.cachedComboBox2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Standard control
        /// </summary>
        /// <history>
        /// 	[barryw] 12/18/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IKnowledgeWordDialogControls.Standard
        {
            get
            {
                // The ID for this control (0) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedStandard == null))
                {
                    Window wndTemp = this.App.MainWindow;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    this.cachedStandard = new Toolbar(wndTemp);
                }
                return this.cachedStandard;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ComboBox3 control
        /// </summary>
        /// <history>
        /// 	[barryw] 12/18/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IKnowledgeWordDialogControls.ComboBox3
        {
            get
            {
                if ((this.cachedComboBox3 == null))
                {
                    this.cachedComboBox3 = new ComboBox(this, KnowledgeWordDialog.ControlIDs.ComboBox3);
                }
                return this.cachedComboBox3;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MainMenu control
        /// </summary>
        /// <history>
        /// 	[barryw] 12/18/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IKnowledgeWordDialogControls.MainMenu
        {
            get
            {
                // The ID for this control (0) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedMainMenu == null))
                {
                    Window wndTemp = this.App.MainWindow;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 4); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedMainMenu = new Toolbar(wndTemp);
                }
                return this.cachedMainMenu;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StandardMenuBar control
        /// </summary>
        /// <history>
        /// 	[barryw] 12/18/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IKnowledgeWordDialogControls.StandardMenuBar
        {
            get
            {
                // The ID for this control (0) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedStandardMenuBar == null))
                {
                    Window wndTemp = this.App.MainWindow;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 4); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    this.cachedStandardMenuBar = new Toolbar(wndTemp);
                }
                return this.cachedStandardMenuBar;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button AddLink
        /// </summary>
        /// <history>
        /// 	[barryw] 12/18/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAddLink()
        {
            this.Controls.AddLinkButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app"> owning the dialog.</param>)
        /// <param name="title">Caption for the window</param>
        /// <history>
        /// 	[barryw] 12/18/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(Mom.Test.UI.Core.Console.MomConsoleApp app, string title)
        {
            Common.Utilities.LogMessage("KnowledgeWordDialog.Init(...)");

            // First check if the dialog is already up.
            Window tempWindow = null;
            string dialogTitle = Strings.DialogTitle;
            try
            {
                // Try to locate an existing instance of a dialog
                // with a wildcard match on part of the window caption.
                tempWindow = new Window(
                    dialogTitle,
                    StringMatchSyntax.WildCard);
                ////Todo: change logmessage to display this class+function name.
                Common.Utilities.LogMessage("Console.GetWizardDialog: " +
                    "found dialog - " + dialogTitle +
                    " using only a wildcard match on the partial caption.");
            }
            catch (Dialog.Exceptions.WindowNotFoundException)
            {
                tempWindow = null;
                int numberOfTries = 0;
                const int maxTries = 5;
                while (tempWindow == null && numberOfTries < maxTries)
                {
                    numberOfTries++;
                    try
                    {
                        // look for the window again using wildcard
                        tempWindow = new Window(
                            dialogTitle + "*",
                            StringMatchSyntax.WildCard);
                        /*,
                            WindowClassNames.WinForms10Window8,
                            StringMatchSyntax.WildCard,
                            this,
                            timeout);
                         */ 
                        Common.Utilities.LogMessage("Console.GetWizardDialog: " +
                            "found window - " + dialogTitle + "*" +
                            " using wildcard match on caption only.");

                        // wait for the window to report ready
                        //UISynchronization.WaitForUIObjectReady(
                        //    tempWindow,
                        //    timeout);
                        tempWindow.ScreenElement.WaitForReady();
                    }
                    catch (Dialog.Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt(s)
                        Common.Utilities.LogMessage("Console.GetWizardDialog: " +
                            "Unable to find dialog - " + dialogTitle);
                    }
                }

                // check for success
                if (tempWindow != null)
                {
                    Common.Utilities.LogMessage("Console.GetWizardDialog: " +
                        "Window: caption - " + tempWindow.Caption);
                    Common.Utilities.LogMessage("Console.GetWizardDialog: " +
                        "Window: class name - " + tempWindow.ClassName);
                }
                else
                {
                    // log the failure
                    Common.Utilities.LogMessage("Console.GetWizardDialog: " +
                        "Unable to find dialog - " + dialogTitle +
                        " after " + numberOfTries.ToString() + " tries.");

                    // throw the first existing WindowNotFound exception
                    throw;
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
        /// 	[barryw] 12/18/2005 Created
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
            /// </remark>
            /// -----------------------------------------------------------------------------
            ////TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            ////Todo try 'Microsoft Word' as better partial caption "Document1 - Microsoft Word";
            private const string ResourceDialogTitle = "Word";  
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TaskPane
            /// </summary>
            /// <remark>
            /// </remark>
            /// -----------------------------------------------------------------------------
            ////TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            private const string ResourceActionsPane = "Task Pane";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: DocumentPane.
            /// </summary>
            /// <remarks>Created using 'Resource private string' snippet</remarks>
            /// -----------------------------------------------------------------------------
            ////Todo:Add the persistent id for this resource string.
            private const string ResourceDocumentPane = "Microsoft Word Document";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Link
            /// </summary>
            /// <remark>
            /// </remark>
            /// -----------------------------------------------------------------------------
            ////TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            private const string ResourceLink = "Link:";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AddLink
            /// </summary>
            /// <remark>
            /// </remark>
            /// -----------------------------------------------------------------------------
            ////TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            private const string ResourceAddLink = "Add Link";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Name
            /// </summary>
            /// <remark>
            /// </remark>
            /// -----------------------------------------------------------------------------
            ////TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            private const string ResourceName = "Name:";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  LinkType
            /// </summary>
            /// <remark>
            /// </remark>
            /// -----------------------------------------------------------------------------
            ////TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            private const string ResourceLinkType = "Link type:";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Formatting
            /// </summary>
            /// <remark>
            /// </remark>
            /// -----------------------------------------------------------------------------
            ////TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            private const string ResourceFormatting = "Formatting";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Standard
            /// </summary>
            /// <remark>
            /// </remark>
            /// -----------------------------------------------------------------------------
            ////TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            private const string ResourceStandard = "Standard";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MainMenu
            /// </summary>
            /// <remark>
            /// </remark>
            /// -----------------------------------------------------------------------------
            ////TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            private const string ResourceMainMenu = "MSO Generic Control Container";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  StandardMenuBar
            /// </summary>
            /// <remark>
            /// </remark>
            /// -----------------------------------------------------------------------------
            ////TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            private const string ResourceStandardMenuBar = "MSO Generic Control Container - StandardMenuBar";
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
            /// Caches the translated resource string for:  ActionsPane
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedActionsPane;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DocumentPane
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDocumentPane;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Link
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLink;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AddLink
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAddLink;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedName;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  LinkType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLinkType;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Formatting
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFormatting;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Standard
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedStandard;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MainMenu
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMainMenu;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  StandardMenuBar
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedStandardMenuBar;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 12/18/2005 Created
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
            /// Exposes access to the ActionsPane translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 12/18/2005 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ActionsPane
            {
                get
                {
                    if ((cachedActionsPane == null))
                    {
                        cachedActionsPane = CoreManager.MomConsole.GetIntlStr(ResourceActionsPane);
                    }
                    return cachedActionsPane;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DocumentPane translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 12/18/2005 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DocumentPane
            {
                get
                {
                    if ((cachedDocumentPane == null))
                    {
                        cachedDocumentPane = CoreManager.MomConsole.GetIntlStr(ResourceDocumentPane);
                    }
                    return cachedDocumentPane;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Link translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 12/18/2005 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Link
            {
                get
                {
                    if ((cachedLink == null))
                    {
                        cachedLink = CoreManager.MomConsole.GetIntlStr(ResourceLink);
                    }
                    return cachedLink;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AddLink translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 12/18/2005 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AddLink
            {
                get
                {
                    if ((cachedAddLink == null))
                    {
                        cachedAddLink = CoreManager.MomConsole.GetIntlStr(ResourceAddLink);
                    }
                    return cachedAddLink;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Name translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 12/18/2005 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Name
            {
                get
                {
                    if ((cachedName == null))
                    {
                        cachedName = CoreManager.MomConsole.GetIntlStr(ResourceName);
                    }
                    return cachedName;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the LinkType translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 12/18/2005 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LinkType
            {
                get
                {
                    if ((cachedLinkType == null))
                    {
                        cachedLinkType = CoreManager.MomConsole.GetIntlStr(ResourceLinkType);
                    }
                    return cachedLinkType;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Formatting translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 12/18/2005 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Formatting
            {
                get
                {
                    if ((cachedFormatting == null))
                    {
                        cachedFormatting = CoreManager.MomConsole.GetIntlStr(ResourceFormatting);
                    }
                    return cachedFormatting;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Standard translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 12/18/2005 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Standard
            {
                get
                {
                    if ((cachedStandard == null))
                    {
                        cachedStandard = CoreManager.MomConsole.GetIntlStr(ResourceStandard);
                    }
                    return cachedStandard;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MainMenu translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 12/18/2005 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MainMenu
            {
                get
                {
                    if ((cachedMainMenu == null))
                    {
                        cachedMainMenu = CoreManager.MomConsole.GetIntlStr(ResourceMainMenu);
                    }
                    return cachedMainMenu;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the StandardMenuBar translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 12/18/2005 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string StandardMenuBar
            {
                get
                {
                    if ((cachedStandardMenuBar == null))
                    {
                        cachedStandardMenuBar = CoreManager.MomConsole.GetIntlStr(ResourceStandardMenuBar);
                    }
                    return cachedStandardMenuBar;
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
        /// 	[barryw] 12/18/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for DocumentPane
            /// </summary>
            public const string DocumentPane = "Microsoft Word Document";

            /// <summary>
            /// Control ID for ActionsPane
            /// </summary>
            public const string ActionsPane = "Task Pane";

            /// <summary>
            /// Control ID for TextBox0
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            [System.Obsolete("Use LinkTypeTextBox")]
            public const int TextBox0 = 1001;
            
            /// <summary>
            /// Control ID for LinkStaticControl
            /// </summary>
            public const string LinkStaticControl = "linkLabel";
            
            /// <summary>
            /// Control ID for AddLinkButton
            /// </summary>
            public const string AddLinkButton = "addLink";
            
            /// <summary>
            /// Control ID for LinkName
            /// </summary>
            public const string LinkName = "nameBox";
            
            /// <summary>
            /// Control ID for LinkTypeEditComboBox
            /// </summary>
            public const string LinkTypeEditComboBox = "linkTypeCombo";

            /// <summary>
            /// Control ID for LinkEditComboBox
            /// </summary>
            public const string LinkEditComboBox = "linkCombo";

            /// <summary>
            /// Control ID for LinkTypeTextBox
            /// </summary>
            public const int LinkTypeTextBox = 1001;
            
            /// <summary>
            /// Control ID for NameStaticControl
            /// </summary>
            public const string NameStaticControl = "nameLabel";
            
            /// <summary>
            /// Control ID for LinkTypeStaticControl
            /// </summary>
            public const string LinkTypeStaticControl = "linkTypeLabel";
            
            /// <summary>
            /// Control ID for Formatting
            /// </summary>
            public const int Formatting = 0;
            
            /// <summary>
            /// Control ID for ComboBox1
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const int ComboBox1 = 35685892;
            
            /// <summary>
            /// Control ID for ComboBox2
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const int ComboBox2 = 35685212;
            
            /// <summary>
            /// Control ID for Standard
            /// </summary>
            public const int Standard = 0;
            
            /// <summary>
            /// Control ID for ComboBox3
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const int ComboBox3 = 17914476;
            
            /// <summary>
            /// Control ID for MainMenu
            /// </summary>
            public const string MainMenu = "Menu Bar";
            
            /// <summary>
            /// Control ID for StandardMenuBar
            /// </summary>
            public const string StandardMenuBar = "Standard";
        }
        #endregion

        #region Boundaries

        /// <summary>
        /// Field boundary sizes
        /// </summary>
        public class Boundaries
        {
            #region Constants section

            /// <summary>
            /// Minimum length of SomeField
            /// </summary>
            ////Todo: Add real fields and sizes 
            public const int MinLengthSomeField = 1;

            /// <summary>
            /// Maximum length of name
            /// </summary>
            public const int MaxLengthSomeField = 150;

            #endregion
        }
        #endregion
    }
}
