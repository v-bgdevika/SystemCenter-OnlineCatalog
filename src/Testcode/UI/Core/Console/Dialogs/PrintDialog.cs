// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="PrintDialog.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	MOMv3
// </project>
// <summary>
// 	Print Dialog
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

    #region Radio Group Enumeration - PrintRange

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group PrintRange
    /// </summary>
    /// <history>
    /// 	[mbickle] 13-Aug-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum PrintRange
    {
        /// <summary>
        /// All = 0
        /// </summary>
        All = 0,

        /// <summary>
        /// Pages = 1
        /// </summary>
        Pages = 1,

        /// <summary>
        /// Selection = 2
        /// </summary>
        Selection = 2,
    }
    #endregion

    #region Interface Definition - IPrintDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IPrintDialogControls, for PrintDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[mbickle] 13-Aug-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IPrintDialogControls
    {
        /// <summary>
        /// Read-only property to access NameStaticControl
        /// </summary>
        StaticControl NameStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access NameComboBox
        /// </summary>
        ComboBox NameComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access PropertiesButton
        /// </summary>
        Button PropertiesButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access StatusStaticControl
        /// </summary>
        StaticControl StatusStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ReadyStaticControl
        /// </summary>
        StaticControl ReadyStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access TypeStaticControl
        /// </summary>
        StaticControl TypeStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access XeroxWCP55PSStaticControl
        /// </summary>
        StaticControl XeroxWCP55PSStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access WhereStaticControl
        /// </summary>
        StaticControl WhereStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access USAREDMONDWA44FLOOR11851StaticControl
        /// </summary>
        StaticControl USAREDMONDWA44FLOOR11851StaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access CommentStaticControl
        /// </summary>
        StaticControl CommentStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access DCA1150838Bldg44Rm1851XeroxBETAWCP55PSBWCORPStaticControl
        /// </summary>
        StaticControl DCA1150838Bldg44Rm1851XeroxBETAWCP55PSBWCORPStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access PrintToFileCheckBox
        /// </summary>
        CheckBox PrintToFileCheckBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AllRadioButton
        /// </summary>
        RadioButton AllRadioButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access PagesRadioButton
        /// </summary>
        RadioButton PagesRadioButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access SelectionRadioButton
        /// </summary>
        RadioButton SelectionRadioButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access FromStaticControl
        /// </summary>
        StaticControl FromStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access FromTextBox
        /// </summary>
        TextBox FromTextBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ToStaticControl
        /// </summary>
        StaticControl ToStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ToTextBox
        /// </summary>
        TextBox ToTextBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access NumberOfCopiesStaticControl
        /// </summary>
        StaticControl NumberOfCopiesStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access NumberOfCopiesTextBox
        /// </summary>
        TextBox NumberOfCopiesTextBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access CollateCheckBox
        /// </summary>
        CheckBox CollateCheckBox
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
        /// Read-only property to access CancelButton
        /// </summary>
        Button CancelButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access Spinner2
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Spinner Spinner2
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
    public class PrintDialog : Dialog, IPrintDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion

        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to NameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNameStaticControl;

        /// <summary>
        /// Cache to hold a reference to NameComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedNameComboBox;

        /// <summary>
        /// Cache to hold a reference to PropertiesButton of type Button
        /// </summary>
        private Button cachedPropertiesButton;

        /// <summary>
        /// Cache to hold a reference to StatusStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedStatusStaticControl;

        /// <summary>
        /// Cache to hold a reference to ReadyStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedReadyStaticControl;

        /// <summary>
        /// Cache to hold a reference to TypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTypeStaticControl;

        /// <summary>
        /// Cache to hold a reference to XeroxWCP55PSStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedXeroxWCP55PSStaticControl;

        /// <summary>
        /// Cache to hold a reference to WhereStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWhereStaticControl;

        /// <summary>
        /// Cache to hold a reference to USAREDMONDWA44FLOOR11851StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedUSAREDMONDWA44FLOOR11851StaticControl;

        /// <summary>
        /// Cache to hold a reference to CommentStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCommentStaticControl;

        /// <summary>
        /// Cache to hold a reference to DCA1150838Bldg44Rm1851XeroxBETAWCP55PSBWCORPStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDCA1150838Bldg44Rm1851XeroxBETAWCP55PSBWCORPStaticControl;

        /// <summary>
        /// Cache to hold a reference to PrintToFileCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedPrintToFileCheckBox;

        /// <summary>
        /// Cache to hold a reference to AllRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedAllRadioButton;

        /// <summary>
        /// Cache to hold a reference to PagesRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedPagesRadioButton;

        /// <summary>
        /// Cache to hold a reference to SelectionRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedSelectionRadioButton;

        /// <summary>
        /// Cache to hold a reference to FromStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedFromStaticControl;

        /// <summary>
        /// Cache to hold a reference to FromTextBox of type TextBox
        /// </summary>
        private TextBox cachedFromTextBox;

        /// <summary>
        /// Cache to hold a reference to ToStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedToStaticControl;

        /// <summary>
        /// Cache to hold a reference to ToTextBox of type TextBox
        /// </summary>
        private TextBox cachedToTextBox;

        /// <summary>
        /// Cache to hold a reference to NumberOfCopiesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNumberOfCopiesStaticControl;

        /// <summary>
        /// Cache to hold a reference to NumberOfCopiesTextBox of type TextBox
        /// </summary>
        private TextBox cachedNumberOfCopiesTextBox;

        /// <summary>
        /// Cache to hold a reference to CollateCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedCollateCheckBox;

        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;

        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;

        /// <summary>
        /// Cache to hold a reference to Spinner2 of type Spinner
        /// </summary>
        private Spinner cachedSpinner2;
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of PrintDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public PrintDialog(ConsoleApp app)
            : base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion

        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group PrintRange
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual PrintRange PrintRange
        {
            get
            {
                if ((this.Controls.AllRadioButton.ButtonState == ButtonState.Checked))
                {
                    return PrintRange.All;
                }

                if ((this.Controls.PagesRadioButton.ButtonState == ButtonState.Checked))
                {
                    return PrintRange.Pages;
                }

                if ((this.Controls.SelectionRadioButton.ButtonState == ButtonState.Checked))
                {
                    return PrintRange.Selection;
                }
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }

            set
            {
                if ((value == PrintRange.All))
                {
                    this.Controls.AllRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == PrintRange.Pages))
                    {
                        this.Controls.PagesRadioButton.ButtonState = ButtonState.Checked;
                    }
                    else
                    {
                        if ((value == PrintRange.Selection))
                        {
                            this.Controls.SelectionRadioButton.ButtonState = ButtonState.Checked;
                        }
                    }
                }
            }
        }
        #endregion

        #region IPrintDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IPrintDialogControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion

        #region Checkbox Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox PrintToFile
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool PrintToFile
        {
            get
            {
                return this.Controls.PrintToFileCheckBox.Checked;
            }

            set
            {
                this.Controls.PrintToFileCheckBox.Checked = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox Collate
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool Collate
        {
            get
            {
                return this.Controls.CollateCheckBox.Checked;
            }

            set
            {
                this.Controls.CollateCheckBox.Checked = value;
            }
        }
        #endregion

        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Name
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string NameText
        {
            get
            {
                return this.Controls.NameComboBox.Text;
            }

            set
            {
                this.Controls.NameComboBox.SelectByText(value, true);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control From
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string FromText
        {
            get
            {
                return this.Controls.FromTextBox.Text;
            }

            set
            {
                this.Controls.FromTextBox.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control To
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ToText
        {
            get
            {
                return this.Controls.ToTextBox.Text;
            }

            set
            {
                this.Controls.ToTextBox.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control NumberOfCopies
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string NumberOfCopiesText
        {
            get
            {
                return this.Controls.NumberOfCopiesTextBox.Text;
            }

            set
            {
                this.Controls.NumberOfCopiesTextBox.Text = value;
            }
        }
        #endregion

        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPrintDialogControls.NameStaticControl
        {
            get
            {
                if ((this.cachedNameStaticControl == null))
                {
                    this.cachedNameStaticControl = new StaticControl(this, PrintDialog.ControlIDs.NameStaticControl);
                }
                return this.cachedNameStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameComboBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IPrintDialogControls.NameComboBox
        {
            get
            {
                if ((this.cachedNameComboBox == null))
                {
                    this.cachedNameComboBox = new ComboBox(this, PrintDialog.ControlIDs.NameComboBox);
                }
                return this.cachedNameComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PropertiesButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPrintDialogControls.PropertiesButton
        {
            get
            {
                if ((this.cachedPropertiesButton == null))
                {
                    this.cachedPropertiesButton = new Button(this, PrintDialog.ControlIDs.PropertiesButton);
                }
                return this.cachedPropertiesButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StatusStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPrintDialogControls.StatusStaticControl
        {
            get
            {
                if ((this.cachedStatusStaticControl == null))
                {
                    this.cachedStatusStaticControl = new StaticControl(this, PrintDialog.ControlIDs.StatusStaticControl);
                }
                return this.cachedStatusStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ReadyStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPrintDialogControls.ReadyStaticControl
        {
            get
            {
                if ((this.cachedReadyStaticControl == null))
                {
                    this.cachedReadyStaticControl = new StaticControl(this, PrintDialog.ControlIDs.ReadyStaticControl);
                }
                return this.cachedReadyStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPrintDialogControls.TypeStaticControl
        {
            get
            {
                if ((this.cachedTypeStaticControl == null))
                {
                    this.cachedTypeStaticControl = new StaticControl(this, PrintDialog.ControlIDs.TypeStaticControl);
                }
                return this.cachedTypeStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the XeroxWCP55PSStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPrintDialogControls.XeroxWCP55PSStaticControl
        {
            get
            {
                if ((this.cachedXeroxWCP55PSStaticControl == null))
                {
                    this.cachedXeroxWCP55PSStaticControl = new StaticControl(this, PrintDialog.ControlIDs.XeroxWCP55PSStaticControl);
                }
                return this.cachedXeroxWCP55PSStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WhereStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPrintDialogControls.WhereStaticControl
        {
            get
            {
                if ((this.cachedWhereStaticControl == null))
                {
                    this.cachedWhereStaticControl = new StaticControl(this, PrintDialog.ControlIDs.WhereStaticControl);
                }
                return this.cachedWhereStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the USAREDMONDWA44FLOOR11851StaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPrintDialogControls.USAREDMONDWA44FLOOR11851StaticControl
        {
            get
            {
                if ((this.cachedUSAREDMONDWA44FLOOR11851StaticControl == null))
                {
                    this.cachedUSAREDMONDWA44FLOOR11851StaticControl = new StaticControl(this, PrintDialog.ControlIDs.USAREDMONDWA44FLOOR11851StaticControl);
                }
                return this.cachedUSAREDMONDWA44FLOOR11851StaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CommentStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPrintDialogControls.CommentStaticControl
        {
            get
            {
                if ((this.cachedCommentStaticControl == null))
                {
                    this.cachedCommentStaticControl = new StaticControl(this, PrintDialog.ControlIDs.CommentStaticControl);
                }
                return this.cachedCommentStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DCA1150838Bldg44Rm1851XeroxBETAWCP55PSBWCORPStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPrintDialogControls.DCA1150838Bldg44Rm1851XeroxBETAWCP55PSBWCORPStaticControl
        {
            get
            {
                if ((this.cachedDCA1150838Bldg44Rm1851XeroxBETAWCP55PSBWCORPStaticControl == null))
                {
                    this.cachedDCA1150838Bldg44Rm1851XeroxBETAWCP55PSBWCORPStaticControl = new StaticControl(this, PrintDialog.ControlIDs.DCA1150838Bldg44Rm1851XeroxBETAWCP55PSBWCORPStaticControl);
                }
                return this.cachedDCA1150838Bldg44Rm1851XeroxBETAWCP55PSBWCORPStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PrintToFileCheckBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IPrintDialogControls.PrintToFileCheckBox
        {
            get
            {
                if ((this.cachedPrintToFileCheckBox == null))
                {
                    this.cachedPrintToFileCheckBox = new CheckBox(this, PrintDialog.ControlIDs.PrintToFileCheckBox);
                }
                return this.cachedPrintToFileCheckBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AllRadioButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IPrintDialogControls.AllRadioButton
        {
            get
            {
                if ((this.cachedAllRadioButton == null))
                {
                    this.cachedAllRadioButton = new RadioButton(this, PrintDialog.ControlIDs.AllRadioButton);
                }
                return this.cachedAllRadioButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PagesRadioButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IPrintDialogControls.PagesRadioButton
        {
            get
            {
                if ((this.cachedPagesRadioButton == null))
                {
                    this.cachedPagesRadioButton = new RadioButton(this, PrintDialog.ControlIDs.PagesRadioButton);
                }
                return this.cachedPagesRadioButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectionRadioButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IPrintDialogControls.SelectionRadioButton
        {
            get
            {
                if ((this.cachedSelectionRadioButton == null))
                {
                    this.cachedSelectionRadioButton = new RadioButton(this, PrintDialog.ControlIDs.SelectionRadioButton);
                }
                return this.cachedSelectionRadioButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FromStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPrintDialogControls.FromStaticControl
        {
            get
            {
                if ((this.cachedFromStaticControl == null))
                {
                    this.cachedFromStaticControl = new StaticControl(this, PrintDialog.ControlIDs.FromStaticControl);
                }
                return this.cachedFromStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FromTextBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IPrintDialogControls.FromTextBox
        {
            get
            {
                if ((this.cachedFromTextBox == null))
                {
                    this.cachedFromTextBox = new TextBox(this, PrintDialog.ControlIDs.FromTextBox);
                }
                return this.cachedFromTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPrintDialogControls.ToStaticControl
        {
            get
            {
                if ((this.cachedToStaticControl == null))
                {
                    this.cachedToStaticControl = new StaticControl(this, PrintDialog.ControlIDs.ToStaticControl);
                }
                return this.cachedToStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToTextBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IPrintDialogControls.ToTextBox
        {
            get
            {
                if ((this.cachedToTextBox == null))
                {
                    this.cachedToTextBox = new TextBox(this, PrintDialog.ControlIDs.ToTextBox);
                }
                return this.cachedToTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NumberOfCopiesStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPrintDialogControls.NumberOfCopiesStaticControl
        {
            get
            {
                if ((this.cachedNumberOfCopiesStaticControl == null))
                {
                    this.cachedNumberOfCopiesStaticControl = new StaticControl(this, PrintDialog.ControlIDs.NumberOfCopiesStaticControl);
                }
                return this.cachedNumberOfCopiesStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NumberOfCopiesTextBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IPrintDialogControls.NumberOfCopiesTextBox
        {
            get
            {
                if ((this.cachedNumberOfCopiesTextBox == null))
                {
                    this.cachedNumberOfCopiesTextBox = new TextBox(this, PrintDialog.ControlIDs.NumberOfCopiesTextBox);
                }
                return this.cachedNumberOfCopiesTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CollateCheckBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IPrintDialogControls.CollateCheckBox
        {
            get
            {
                if ((this.cachedCollateCheckBox == null))
                {
                    this.cachedCollateCheckBox = new CheckBox(this, PrintDialog.ControlIDs.CollateCheckBox);
                }
                return this.cachedCollateCheckBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPrintDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, PrintDialog.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
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
        Button IPrintDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, PrintDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Spinner2 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Spinner IPrintDialogControls.Spinner2
        {
            get
            {
                if ((this.cachedSpinner2 == null))
                {
                    this.cachedSpinner2 = new Spinner(this, PrintDialog.ControlIDs.Spinner2);
                }
                return this.cachedSpinner2;
            }
        }
        #endregion

        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Properties
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickProperties()
        {
            this.Controls.PropertiesButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button PrintToFile
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickPrintToFile()
        {
            this.Controls.PrintToFileCheckBox.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Collate
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCollate()
        {
            this.Controls.CollateCheckBox.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[mbickle] 13-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
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
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.Alert, StringMatchSyntax.ExactMatch, app.MainWindow, 3000);
            }
            catch (Exceptions.WindowNotFoundException ex)
            {
                // TODO:  Cannot find Print Dialog
                throw new Window.Exceptions.WindowNotFoundException("Init function could not find or bring up the dialog.", ex);
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
            private const string ResourceDialogTitle = ";Print;Win32DialogString;comdlg32.dll;1538";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceName = ";&Name:;Win32DialogItemString;comdlg32.dll;1538;1093";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Properties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceProperties = ";&Properties...;Win32DialogItemString;comdlg32.dll;1538;1025";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Status
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceStatus = ";Status:;Win32DialogItemString;comdlg32.dll;1538;1095";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Ready
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceReady = "Ready";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Type
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceType = ";Type:;Win32DialogItemString;comdlg32.dll;1538;1094";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  XeroxWCP55PS
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceXeroxWCP55PS = "Xerox WCP 55 PS";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Where
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWhere = ";Where:;Win32DialogItemString;comdlg32.dll;1538;1097";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  USAREDMONDWA44FLOOR11851
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUSAREDMONDWA44FLOOR11851 = "USA/REDMOND, WA/44/FLOOR1/1851";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Comment
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceComment = ";Comment:;Win32DialogItemString;comdlg32.dll;1538;1096";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DCA1150838Bldg44Rm1851XeroxBETAWCP55PSBWCORP
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDCA1150838Bldg44Rm1851XeroxBETAWCP55PSBWCORP = "DCA# 1150838 - Bldg 44, rm 1851; Xerox BETA WCP 55 PS B/W - CORP";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  PrintToFile
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrintToFile = ";Print to fi&le;Win32DialogItemString;comdlg32.dll;1538;1040";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  All
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAll = ";&All;Win32DialogItemString;comdlg32.dll;1538;1056";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Pages
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePages = ";Pa&ges;Win32DialogItemString;comdlg32.dll;1538;1058";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Selection
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelection = ";&Selection;Win32DialogItemString;comdlg32.dll;1538;1057";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  From
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFrom = ";&from:;Win32DialogItemString;comdlg32.dll;1538;1089";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  To
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTo = ";&to:;Win32DialogItemString;comdlg32.dll;1538;1090";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  NumberOfCopies
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNumberOfCopies = ";Number of &copies:;Win32DialogItemString;comdlg32.dll;1538;1092";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Collate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCollate = ";C&ollate;Win32DialogItemString;comdlg32.dll;1538;1041";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;Win32DialogItemString;comdlg32.dll;1538;1";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;Win32DialogItemString;comdlg32.dll;1538;2";
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
            /// Caches the translated resource string for:  Name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedName;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Properties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedProperties;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Status
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedStatus;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Ready
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedReady;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Type
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedType;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  XeroxWCP55PS
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedXeroxWCP55PS;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Where
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWhere;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  USAREDMONDWA44FLOOR11851
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUSAREDMONDWA44FLOOR11851;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Comment
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedComment;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DCA1150838Bldg44Rm1851XeroxBETAWCP55PSBWCORP
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDCA1150838Bldg44Rm1851XeroxBETAWCP55PSBWCORP;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  PrintToFile
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPrintToFile;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  All
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAll;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Pages
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPages;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Selection
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelection;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  From
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFrom;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  To
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTo;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  NumberOfCopies
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNumberOfCopies;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Collate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCollate;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;

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
            /// Exposes access to the Name translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 13-Aug-05 Created
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
            /// Exposes access to the Properties translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 13-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Properties
            {
                get
                {
                    if ((cachedProperties == null))
                    {
                        cachedProperties = CoreManager.MomConsole.GetIntlStr(ResourceProperties);
                    }
                    return cachedProperties;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Status translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 13-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Status
            {
                get
                {
                    if ((cachedStatus == null))
                    {
                        cachedStatus = CoreManager.MomConsole.GetIntlStr(ResourceStatus);
                    }
                    return cachedStatus;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Ready translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 13-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Ready
            {
                get
                {
                    if ((cachedReady == null))
                    {
                        cachedReady = CoreManager.MomConsole.GetIntlStr(ResourceReady);
                    }
                    return cachedReady;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Type translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 13-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Type
            {
                get
                {
                    if ((cachedType == null))
                    {
                        cachedType = CoreManager.MomConsole.GetIntlStr(ResourceType);
                    }
                    return cachedType;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the XeroxWCP55PS translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 13-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string XeroxWCP55PS
            {
                get
                {
                    if ((cachedXeroxWCP55PS == null))
                    {
                        cachedXeroxWCP55PS = CoreManager.MomConsole.GetIntlStr(ResourceXeroxWCP55PS);
                    }
                    return cachedXeroxWCP55PS;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Where translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 13-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Where
            {
                get
                {
                    if ((cachedWhere == null))
                    {
                        cachedWhere = CoreManager.MomConsole.GetIntlStr(ResourceWhere);
                    }
                    return cachedWhere;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the USAREDMONDWA44FLOOR11851 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 13-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string USAREDMONDWA44FLOOR11851
            {
                get
                {
                    if ((cachedUSAREDMONDWA44FLOOR11851 == null))
                    {
                        cachedUSAREDMONDWA44FLOOR11851 = CoreManager.MomConsole.GetIntlStr(ResourceUSAREDMONDWA44FLOOR11851);
                    }
                    return cachedUSAREDMONDWA44FLOOR11851;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Comment translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 13-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Comment
            {
                get
                {
                    if ((cachedComment == null))
                    {
                        cachedComment = CoreManager.MomConsole.GetIntlStr(ResourceComment);
                    }
                    return cachedComment;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DCA1150838Bldg44Rm1851XeroxBETAWCP55PSBWCORP translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 13-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DCA1150838Bldg44Rm1851XeroxBETAWCP55PSBWCORP
            {
                get
                {
                    if ((cachedDCA1150838Bldg44Rm1851XeroxBETAWCP55PSBWCORP == null))
                    {
                        cachedDCA1150838Bldg44Rm1851XeroxBETAWCP55PSBWCORP = CoreManager.MomConsole.GetIntlStr(ResourceDCA1150838Bldg44Rm1851XeroxBETAWCP55PSBWCORP);
                    }
                    return cachedDCA1150838Bldg44Rm1851XeroxBETAWCP55PSBWCORP;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the PrintToFile translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 13-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string PrintToFile
            {
                get
                {
                    if ((cachedPrintToFile == null))
                    {
                        cachedPrintToFile = CoreManager.MomConsole.GetIntlStr(ResourcePrintToFile);
                    }
                    return cachedPrintToFile;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the All translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 13-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string All
            {
                get
                {
                    if ((cachedAll == null))
                    {
                        cachedAll = CoreManager.MomConsole.GetIntlStr(ResourceAll);
                    }
                    return cachedAll;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Pages translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 13-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Pages
            {
                get
                {
                    if ((cachedPages == null))
                    {
                        cachedPages = CoreManager.MomConsole.GetIntlStr(ResourcePages);
                    }
                    return cachedPages;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Selection translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 13-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Selection
            {
                get
                {
                    if ((cachedSelection == null))
                    {
                        cachedSelection = CoreManager.MomConsole.GetIntlStr(ResourceSelection);
                    }
                    return cachedSelection;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the From translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 13-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string From
            {
                get
                {
                    if ((cachedFrom == null))
                    {
                        cachedFrom = CoreManager.MomConsole.GetIntlStr(ResourceFrom);
                    }
                    return cachedFrom;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the To translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 13-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string To
            {
                get
                {
                    if ((cachedTo == null))
                    {
                        cachedTo = CoreManager.MomConsole.GetIntlStr(ResourceTo);
                    }
                    return cachedTo;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NumberOfCopies translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 13-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NumberOfCopies
            {
                get
                {
                    if ((cachedNumberOfCopies == null))
                    {
                        cachedNumberOfCopies = CoreManager.MomConsole.GetIntlStr(ResourceNumberOfCopies);
                    }
                    return cachedNumberOfCopies;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Collate translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 13-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Collate
            {
                get
                {
                    if ((cachedCollate == null))
                    {
                        cachedCollate = CoreManager.MomConsole.GetIntlStr(ResourceCollate);
                    }
                    return cachedCollate;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 13-Aug-05 Created
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
            /// Control ID for NameStaticControl
            /// </summary>
            public const int NameStaticControl = 1093;

            /// <summary>
            /// Control ID for NameComboBox
            /// </summary>
            public const int NameComboBox = 1139;

            /// <summary>
            /// Control ID for PropertiesButton
            /// </summary>
            public const int PropertiesButton = 1025;

            /// <summary>
            /// Control ID for StatusStaticControl
            /// </summary>
            public const int StatusStaticControl = 1095;

            /// <summary>
            /// Control ID for ReadyStaticControl
            /// </summary>
            public const int ReadyStaticControl = 1099;

            /// <summary>
            /// Control ID for TypeStaticControl
            /// </summary>
            public const int TypeStaticControl = 1094;

            /// <summary>
            /// Control ID for XeroxWCP55PSStaticControl
            /// </summary>
            public const int XeroxWCP55PSStaticControl = 1098;

            /// <summary>
            /// Control ID for WhereStaticControl
            /// </summary>
            public const int WhereStaticControl = 1097;

            /// <summary>
            /// Control ID for USAREDMONDWA44FLOOR11851StaticControl
            /// </summary>
            public const int USAREDMONDWA44FLOOR11851StaticControl = 1101;

            /// <summary>
            /// Control ID for CommentStaticControl
            /// </summary>
            public const int CommentStaticControl = 1096;

            /// <summary>
            /// Control ID for DCA1150838Bldg44Rm1851XeroxBETAWCP55PSBWCORPStaticControl
            /// </summary>
            public const int DCA1150838Bldg44Rm1851XeroxBETAWCP55PSBWCORPStaticControl = 1100;

            /// <summary>
            /// Control ID for PrintToFileCheckBox
            /// </summary>
            public const int PrintToFileCheckBox = 1040;

            /// <summary>
            /// Control ID for AllRadioButton
            /// </summary>
            public const int AllRadioButton = 1056;

            /// <summary>
            /// Control ID for PagesRadioButton
            /// </summary>
            public const int PagesRadioButton = 1058;

            /// <summary>
            /// Control ID for SelectionRadioButton
            /// </summary>
            public const int SelectionRadioButton = 1057;

            /// <summary>
            /// Control ID for FromStaticControl
            /// </summary>
            public const int FromStaticControl = 1089;

            /// <summary>
            /// Control ID for FromTextBox
            /// </summary>
            public const int FromTextBox = 1152;

            /// <summary>
            /// Control ID for ToStaticControl
            /// </summary>
            public const int ToStaticControl = 1090;

            /// <summary>
            /// Control ID for ToTextBox
            /// </summary>
            public const int ToTextBox = 1153;

            /// <summary>
            /// Control ID for NumberOfCopiesStaticControl
            /// </summary>
            public const int NumberOfCopiesStaticControl = 1092;

            /// <summary>
            /// Control ID for NumberOfCopiesTextBox
            /// </summary>
            public const int NumberOfCopiesTextBox = 1154;

            /// <summary>
            /// Control ID for CollateCheckBox
            /// </summary>
            public const int CollateCheckBox = 1041;

            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const int OKButton = 1;

            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const int CancelButton = 2;

            /// <summary>
            /// Control ID for Spinner2
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const int Spinner2 = 9999;
        }
        #endregion
    }
}
