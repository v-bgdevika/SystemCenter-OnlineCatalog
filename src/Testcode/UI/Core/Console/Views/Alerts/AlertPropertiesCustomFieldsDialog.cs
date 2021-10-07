// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AlertPropertiesCustomFieldsDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[lucyra] 7/24/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.Alerts
{
    #region Using directives

    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Maui.Core.HtmlControls;

    #endregion

    #region Interface Definition - IAlertPropertiesCustomFieldsDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAlertPropertiesCustomFieldsDialogControls, for AlertPropertiesCustomFieldsDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[lucyra] 7/24/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAlertPropertiesCustomFieldsDialogControls
    {
        /// <summary>
        /// Read-only property to access NextButton
        /// </summary>
        Button NextButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access PreviousButton
        /// </summary>
        Button PreviousButton
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
        /// Read-only property to access ApplyButton
        /// </summary>
        Button ApplyButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access Tab5TabControl
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TabControl Tab5TabControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access TextBox9
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TextBox TextBox9
        {
            get;
        }

        /// <summary>
        /// Read-only property to access CustomField10StaticControl
        /// </summary>
        StaticControl CustomField10StaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access TextBox10
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TextBox TextBox10
        {
            get;
        }

        /// <summary>
        /// Read-only property to access CustomField9StaticControl
        /// </summary>
        StaticControl CustomField9StaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access TextBox11
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TextBox TextBox11
        {
            get;
        }

        /// <summary>
        /// Read-only property to access CustomField8StaticControl
        /// </summary>
        StaticControl CustomField8StaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access TextBox12
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TextBox TextBox12
        {
            get;
        }

        /// <summary>
        /// Read-only property to access CustomField7StaticControl
        /// </summary>
        StaticControl CustomField7StaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access TextBox13
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TextBox TextBox13
        {
            get;
        }

        /// <summary>
        /// Read-only property to access CustomField6StaticControl
        /// </summary>
        StaticControl CustomField6StaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access TextBox14
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TextBox TextBox14
        {
            get;
        }

        /// <summary>
        /// Read-only property to access CustomField5StaticControl
        /// </summary>
        StaticControl CustomField5StaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access TextBox15
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TextBox TextBox15
        {
            get;
        }

        /// <summary>
        /// Read-only property to access CustomField4StaticControl
        /// </summary>
        StaticControl CustomField4StaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access TextBox16
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TextBox TextBox16
        {
            get;
        }

        /// <summary>
        /// Read-only property to access CustomField3StaticControl
        /// </summary>
        StaticControl CustomField3StaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access TextBox17
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TextBox TextBox17
        {
            get;
        }

        /// <summary>
        /// Read-only property to access CustomField2StaticControl
        /// </summary>
        StaticControl CustomField2StaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access CustomFieldsTextBox
        /// </summary>
        TextBox CustomFieldsTextBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access CustomFieldsStaticControl
        /// </summary>
        StaticControl CustomFieldsStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access CustomField1StaticControl
        /// </summary>
        StaticControl CustomField1StaticControl
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
    /// 	[lucyra] 7/24/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class AlertPropertiesCustomFieldsDialog : Dialog, IAlertPropertiesCustomFieldsDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion

        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to NextButton of type Button
        /// </summary>
        private Button cachedNextButton;

        /// <summary>
        /// Cache to hold a reference to PreviousButton of type Button
        /// </summary>
        private Button cachedPreviousButton;

        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;

        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;

        /// <summary>
        /// Cache to hold a reference to ApplyButton of type Button
        /// </summary>
        private Button cachedApplyButton;

        /// <summary>
        /// Cache to hold a reference to Tab5TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab5TabControl;

        /// <summary>
        /// Cache to hold a reference to TextBox9 of type TextBox
        /// </summary>
        private TextBox cachedTextBox9;

        /// <summary>
        /// Cache to hold a reference to CustomField10StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCustomField10StaticControl;

        /// <summary>
        /// Cache to hold a reference to TextBox10 of type TextBox
        /// </summary>
        private TextBox cachedTextBox10;

        /// <summary>
        /// Cache to hold a reference to CustomField9StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCustomField9StaticControl;

        /// <summary>
        /// Cache to hold a reference to TextBox11 of type TextBox
        /// </summary>
        private TextBox cachedTextBox11;

        /// <summary>
        /// Cache to hold a reference to CustomField8StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCustomField8StaticControl;

        /// <summary>
        /// Cache to hold a reference to TextBox12 of type TextBox
        /// </summary>
        private TextBox cachedTextBox12;

        /// <summary>
        /// Cache to hold a reference to CustomField7StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCustomField7StaticControl;

        /// <summary>
        /// Cache to hold a reference to TextBox13 of type TextBox
        /// </summary>
        private TextBox cachedTextBox13;

        /// <summary>
        /// Cache to hold a reference to CustomField6StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCustomField6StaticControl;

        /// <summary>
        /// Cache to hold a reference to TextBox14 of type TextBox
        /// </summary>
        private TextBox cachedTextBox14;

        /// <summary>
        /// Cache to hold a reference to CustomField5StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCustomField5StaticControl;

        /// <summary>
        /// Cache to hold a reference to TextBox15 of type TextBox
        /// </summary>
        private TextBox cachedTextBox15;

        /// <summary>
        /// Cache to hold a reference to CustomField4StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCustomField4StaticControl;

        /// <summary>
        /// Cache to hold a reference to TextBox16 of type TextBox
        /// </summary>
        private TextBox cachedTextBox16;

        /// <summary>
        /// Cache to hold a reference to CustomField3StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCustomField3StaticControl;

        /// <summary>
        /// Cache to hold a reference to TextBox17 of type TextBox
        /// </summary>
        private TextBox cachedTextBox17;

        /// <summary>
        /// Cache to hold a reference to CustomField2StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCustomField2StaticControl;

        /// <summary>
        /// Cache to hold a reference to CustomFieldsTextBox of type TextBox
        /// </summary>
        private TextBox cachedCustomFieldsTextBox;

        /// <summary>
        /// Cache to hold a reference to CustomFieldsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCustomFieldsStaticControl;

        /// <summary>
        /// Cache to hold a reference to CustomField1StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCustomField1StaticControl;
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of AlertPropertiesCustomFieldsDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AlertPropertiesCustomFieldsDialog(ConsoleApp app)
            :
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion

        #region IAlertPropertiesCustomFieldsDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAlertPropertiesCustomFieldsDialogControls Controls
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
        ///  Routine to set/get the text in control TextBox9
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TextBox9Text
        {
            get
            {
                return this.Controls.TextBox9.Text;
            }

            set
            {
                this.Controls.TextBox9.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TextBox10
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TextBox10Text
        {
            get
            {
                return this.Controls.TextBox10.Text;
            }

            set
            {
                this.Controls.TextBox10.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TextBox11
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TextBox11Text
        {
            get
            {
                return this.Controls.TextBox11.Text;
            }

            set
            {
                this.Controls.TextBox11.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TextBox12
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TextBox12Text
        {
            get
            {
                return this.Controls.TextBox12.Text;
            }

            set
            {
                this.Controls.TextBox12.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TextBox13
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TextBox13Text
        {
            get
            {
                return this.Controls.TextBox13.Text;
            }

            set
            {
                this.Controls.TextBox13.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TextBox14
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TextBox14Text
        {
            get
            {
                return this.Controls.TextBox14.Text;
            }

            set
            {
                this.Controls.TextBox14.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TextBox15
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TextBox15Text
        {
            get
            {
                return this.Controls.TextBox15.Text;
            }

            set
            {
                this.Controls.TextBox15.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TextBox16
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TextBox16Text
        {
            get
            {
                return this.Controls.TextBox16.Text;
            }

            set
            {
                this.Controls.TextBox16.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TextBox17
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TextBox17Text
        {
            get
            {
                return this.Controls.TextBox17.Text;
            }

            set
            {
                this.Controls.TextBox17.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control CustomFields
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string CustomFieldsText
        {
            get
            {
                return this.Controls.CustomFieldsTextBox.Text;
            }

            set
            {
                this.Controls.CustomFieldsTextBox.Text = value;
            }
        }
        #endregion

        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertPropertiesCustomFieldsDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, AlertPropertiesCustomFieldsDialog.ControlIDs.NextButton);
                }

                return this.cachedNextButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertPropertiesCustomFieldsDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, AlertPropertiesCustomFieldsDialog.ControlIDs.PreviousButton);
                }

                return this.cachedPreviousButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertPropertiesCustomFieldsDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, AlertPropertiesCustomFieldsDialog.ControlIDs.OKButton);
                }

                return this.cachedOKButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertPropertiesCustomFieldsDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AlertPropertiesCustomFieldsDialog.ControlIDs.CancelButton);
                }

                return this.cachedCancelButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApplyButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertPropertiesCustomFieldsDialogControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, AlertPropertiesCustomFieldsDialog.ControlIDs.ApplyButton);
                }

                return this.cachedApplyButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab5TabControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IAlertPropertiesCustomFieldsDialogControls.Tab5TabControl
        {
            get
            {
                if ((this.cachedTab5TabControl == null))
                {
                    this.cachedTab5TabControl = new TabControl(this, AlertPropertiesCustomFieldsDialog.ControlIDs.Tab5TabControl);
                }

                return this.cachedTab5TabControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TextBox9 control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAlertPropertiesCustomFieldsDialogControls.TextBox9
        {
            get
            {
                if ((this.cachedTextBox9 == null))
                {
                    this.cachedTextBox9 = new TextBox(this, AlertPropertiesCustomFieldsDialog.ControlIDs.TextBox9);
                }

                return this.cachedTextBox9;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CustomField10StaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertPropertiesCustomFieldsDialogControls.CustomField10StaticControl
        {
            get
            {
                if ((this.cachedCustomField10StaticControl == null))
                {
                    this.cachedCustomField10StaticControl = new StaticControl(this, AlertPropertiesCustomFieldsDialog.ControlIDs.CustomField10StaticControl);
                }

                return this.cachedCustomField10StaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TextBox10 control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAlertPropertiesCustomFieldsDialogControls.TextBox10
        {
            get
            {
                if ((this.cachedTextBox10 == null))
                {
                    this.cachedTextBox10 = new TextBox(this, AlertPropertiesCustomFieldsDialog.ControlIDs.TextBox10);
                }

                return this.cachedTextBox10;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CustomField9StaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertPropertiesCustomFieldsDialogControls.CustomField9StaticControl
        {
            get
            {
                if ((this.cachedCustomField9StaticControl == null))
                {
                    this.cachedCustomField9StaticControl = new StaticControl(this, AlertPropertiesCustomFieldsDialog.ControlIDs.CustomField9StaticControl);
                }

                return this.cachedCustomField9StaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TextBox11 control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAlertPropertiesCustomFieldsDialogControls.TextBox11
        {
            get
            {
                if ((this.cachedTextBox11 == null))
                {
                    this.cachedTextBox11 = new TextBox(this, AlertPropertiesCustomFieldsDialog.ControlIDs.TextBox11);
                }

                return this.cachedTextBox11;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CustomField8StaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertPropertiesCustomFieldsDialogControls.CustomField8StaticControl
        {
            get
            {
                if ((this.cachedCustomField8StaticControl == null))
                {
                    this.cachedCustomField8StaticControl = new StaticControl(this, AlertPropertiesCustomFieldsDialog.ControlIDs.CustomField8StaticControl);
                }

                return this.cachedCustomField8StaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TextBox12 control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAlertPropertiesCustomFieldsDialogControls.TextBox12
        {
            get
            {
                if ((this.cachedTextBox12 == null))
                {
                    this.cachedTextBox12 = new TextBox(this, AlertPropertiesCustomFieldsDialog.ControlIDs.TextBox12);
                }

                return this.cachedTextBox12;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CustomField7StaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertPropertiesCustomFieldsDialogControls.CustomField7StaticControl
        {
            get
            {
                if ((this.cachedCustomField7StaticControl == null))
                {
                    this.cachedCustomField7StaticControl = new StaticControl(this, AlertPropertiesCustomFieldsDialog.ControlIDs.CustomField7StaticControl);
                }

                return this.cachedCustomField7StaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TextBox13 control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAlertPropertiesCustomFieldsDialogControls.TextBox13
        {
            get
            {
                if ((this.cachedTextBox13 == null))
                {
                    this.cachedTextBox13 = new TextBox(this, AlertPropertiesCustomFieldsDialog.ControlIDs.TextBox13);
                }

                return this.cachedTextBox13;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CustomField6StaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertPropertiesCustomFieldsDialogControls.CustomField6StaticControl
        {
            get
            {
                if ((this.cachedCustomField6StaticControl == null))
                {
                    this.cachedCustomField6StaticControl = new StaticControl(this, AlertPropertiesCustomFieldsDialog.ControlIDs.CustomField6StaticControl);
                }

                return this.cachedCustomField6StaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TextBox14 control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAlertPropertiesCustomFieldsDialogControls.TextBox14
        {
            get
            {
                if ((this.cachedTextBox14 == null))
                {
                    this.cachedTextBox14 = new TextBox(this, AlertPropertiesCustomFieldsDialog.ControlIDs.TextBox14);
                }

                return this.cachedTextBox14;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CustomField5StaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertPropertiesCustomFieldsDialogControls.CustomField5StaticControl
        {
            get
            {
                if ((this.cachedCustomField5StaticControl == null))
                {
                    this.cachedCustomField5StaticControl = new StaticControl(this, AlertPropertiesCustomFieldsDialog.ControlIDs.CustomField5StaticControl);
                }

                return this.cachedCustomField5StaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TextBox15 control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAlertPropertiesCustomFieldsDialogControls.TextBox15
        {
            get
            {
                if ((this.cachedTextBox15 == null))
                {
                    this.cachedTextBox15 = new TextBox(this, AlertPropertiesCustomFieldsDialog.ControlIDs.TextBox15);
                }

                return this.cachedTextBox15;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CustomField4StaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertPropertiesCustomFieldsDialogControls.CustomField4StaticControl
        {
            get
            {
                if ((this.cachedCustomField4StaticControl == null))
                {
                    this.cachedCustomField4StaticControl = new StaticControl(this, AlertPropertiesCustomFieldsDialog.ControlIDs.CustomField4StaticControl);
                }

                return this.cachedCustomField4StaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TextBox16 control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAlertPropertiesCustomFieldsDialogControls.TextBox16
        {
            get
            {
                if ((this.cachedTextBox16 == null))
                {
                    this.cachedTextBox16 = new TextBox(this, AlertPropertiesCustomFieldsDialog.ControlIDs.TextBox16);
                }

                return this.cachedTextBox16;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CustomField3StaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertPropertiesCustomFieldsDialogControls.CustomField3StaticControl
        {
            get
            {
                if ((this.cachedCustomField3StaticControl == null))
                {
                    this.cachedCustomField3StaticControl = new StaticControl(this, AlertPropertiesCustomFieldsDialog.ControlIDs.CustomField3StaticControl);
                }

                return this.cachedCustomField3StaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TextBox17 control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAlertPropertiesCustomFieldsDialogControls.TextBox17
        {
            get
            {
                if ((this.cachedTextBox17 == null))
                {
                    this.cachedTextBox17 = new TextBox(this, AlertPropertiesCustomFieldsDialog.ControlIDs.TextBox17);
                }

                return this.cachedTextBox17;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CustomField2StaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertPropertiesCustomFieldsDialogControls.CustomField2StaticControl
        {
            get
            {
                if ((this.cachedCustomField2StaticControl == null))
                {
                    this.cachedCustomField2StaticControl = new StaticControl(this, AlertPropertiesCustomFieldsDialog.ControlIDs.CustomField2StaticControl);
                }

                return this.cachedCustomField2StaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CustomFieldsTextBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAlertPropertiesCustomFieldsDialogControls.CustomFieldsTextBox
        {
            get
            {
                if ((this.cachedCustomFieldsTextBox == null))
                {
                    this.cachedCustomFieldsTextBox = new TextBox(this, AlertPropertiesCustomFieldsDialog.ControlIDs.CustomFieldsTextBox);
                }

                return this.cachedCustomFieldsTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CustomFieldsStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertPropertiesCustomFieldsDialogControls.CustomFieldsStaticControl
        {
            get
            {
                if ((this.cachedCustomFieldsStaticControl == null))
                {
                    this.cachedCustomFieldsStaticControl = new StaticControl(this, AlertPropertiesCustomFieldsDialog.ControlIDs.CustomFieldsStaticControl);
                }

                return this.cachedCustomFieldsStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CustomField1StaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertPropertiesCustomFieldsDialogControls.CustomField1StaticControl
        {
            get
            {
                if ((this.cachedCustomField1StaticControl == null))
                {
                    this.cachedCustomField1StaticControl = new StaticControl(this, AlertPropertiesCustomFieldsDialog.ControlIDs.CustomField1StaticControl);
                }

                return this.cachedCustomField1StaticControl;
            }
        }
        #endregion

        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Next
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNext()
        {
            this.Controls.NextButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickPrevious()
        {
            this.Controls.PreviousButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
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
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Apply
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickApply()
        {
            this.Controls.ApplyButton.Click();
        }
        #endregion

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">ConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(
                    Strings.DialogTitle,
                    StringMatchSyntax.WildCard,
                    WindowClassNames.WinForms10Window8,
                    StringMatchSyntax.WildCard,
                    app,
                    Timeout);
            }
            catch (Exceptions.WindowNotFoundException)
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
                                StringMatchSyntax.WildCard,
                                WindowClassNames.WinForms10Window8,
                                StringMatchSyntax.WildCard,
                                app,
                                Timeout);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage(
                            "AlertPropertiesCustomFieldsDialog:: Attempt " + numberOfTries + " of " + MaxTries);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "AlertPropertiesCustomFieldsDialog:: Failed to find window with title:  '" +
                        Strings.DialogTitle + "'");

                    // throw the existing WindowNotFound exception
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
        /// 	[lucyra] 7/24/2006 Created
        ///     [a-joelj] 19MAR09 Added DialogTitle resource
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
            private const string ResourceDialogTitle = 
                ";Alert Properties;" +
                "ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertResources;" +
                "BulkAlertPropertiesTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext = ";&Next;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManageme" +
                "nt.Mom.UI.AlertPropertyDialog;nextButton.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrevious = ";&Previous;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMana" +
                "gement.Mom.UI.AlertPropertyDialog;prevButton.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.Tr" +
                "anslucentColorPicker;buttonOk.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Apply
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceApply = ";&Apply;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.PropertyDialogForm;buttonApply.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Tab5
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTab5 = "Tab5";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField10
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField10 = ";Custom Field 10:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpr" +
                "iseManagement.Mom.UI.AlertPropertyDialog;customField10Label.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField9
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField9 = ";Custom Field 9:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpri" +
                "seManagement.Mom.UI.AlertPropertyDialog;customField9Label.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField8
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField8 = ";Custom Field 8:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpri" +
                "seManagement.Mom.UI.AlertPropertyDialog;customField8Label.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField7
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField7 = ";Custom Field 7:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpri" +
                "seManagement.Mom.UI.AlertPropertyDialog;customField7Label.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField6
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField6 = ";Custom Field 6:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpri" +
                "seManagement.Mom.UI.AlertPropertyDialog;customField6Label.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField5
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField5 = ";Custom Field 5:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpri" +
                "seManagement.Mom.UI.AlertPropertyDialog;customField5Label.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField4
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField4 = ";Custom Field 4:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpri" +
                "seManagement.Mom.UI.AlertPropertyDialog;customField4Label.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField3 = ";Custom Field 3:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpri" +
                "seManagement.Mom.UI.AlertPropertyDialog;customField3Label.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField2 = ";Custom Field 2:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpri" +
                "seManagement.Mom.UI.AlertPropertyDialog;customField2Label.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomFields
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomFields = ";Custom Fields;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterprise" +
                "Management.Mom.UI.AlertPropertyDialog;customFieldTab.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField1 = ";Custom Field 1:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpri" +
                "seManagement.Mom.UI.AlertPropertyDialog;customField1Label.Text";
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
            /// Caches the translated resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNext;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPrevious;

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

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Apply
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedApply;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Tab5
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab5;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField10
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField10;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField9
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField9;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField8
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField8;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField7
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField7;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField6
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField6;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField5
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField5;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField4
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField4;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField3;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField2;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomFields
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomFields;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField1;
            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/24/2006 Created
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
            /// Exposes access to the Next translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Next
            {
                get
                {
                    if ((cachedNext == null))
                    {
                        cachedNext = CoreManager.MomConsole.GetIntlStr(ResourceNext);
                    }

                    return cachedNext;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Previous translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Previous
            {
                get
                {
                    if ((cachedPrevious == null))
                    {
                        cachedPrevious = CoreManager.MomConsole.GetIntlStr(ResourcePrevious);
                    }

                    return cachedPrevious;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/24/2006 Created
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
            /// 	[lucyra] 7/24/2006 Created
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
            /// Exposes access to the Apply translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Apply
            {
                get
                {
                    if ((cachedApply == null))
                    {
                        cachedApply = CoreManager.MomConsole.GetIntlStr(ResourceApply);
                    }

                    return cachedApply;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Tab5 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tab5
            {
                get
                {
                    if ((cachedTab5 == null))
                    {
                        cachedTab5 = CoreManager.MomConsole.GetIntlStr(ResourceTab5);
                    }

                    return cachedTab5;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField10 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CustomField10
            {
                get
                {
                    if ((cachedCustomField10 == null))
                    {
                        cachedCustomField10 = CoreManager.MomConsole.GetIntlStr(ResourceCustomField10);
                    }

                    return cachedCustomField10;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField9 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CustomField9
            {
                get
                {
                    if ((cachedCustomField9 == null))
                    {
                        cachedCustomField9 = CoreManager.MomConsole.GetIntlStr(ResourceCustomField9);
                    }

                    return cachedCustomField9;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField8 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CustomField8
            {
                get
                {
                    if ((cachedCustomField8 == null))
                    {
                        cachedCustomField8 = CoreManager.MomConsole.GetIntlStr(ResourceCustomField8);
                    }

                    return cachedCustomField8;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField7 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CustomField7
            {
                get
                {
                    if ((cachedCustomField7 == null))
                    {
                        cachedCustomField7 = CoreManager.MomConsole.GetIntlStr(ResourceCustomField7);
                    }

                    return cachedCustomField7;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField6 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CustomField6
            {
                get
                {
                    if ((cachedCustomField6 == null))
                    {
                        cachedCustomField6 = CoreManager.MomConsole.GetIntlStr(ResourceCustomField6);
                    }

                    return cachedCustomField6;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField5 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CustomField5
            {
                get
                {
                    if ((cachedCustomField5 == null))
                    {
                        cachedCustomField5 = CoreManager.MomConsole.GetIntlStr(ResourceCustomField5);
                    }

                    return cachedCustomField5;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField4 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CustomField4
            {
                get
                {
                    if ((cachedCustomField4 == null))
                    {
                        cachedCustomField4 = CoreManager.MomConsole.GetIntlStr(ResourceCustomField4);
                    }

                    return cachedCustomField4;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField3 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CustomField3
            {
                get
                {
                    if ((cachedCustomField3 == null))
                    {
                        cachedCustomField3 = CoreManager.MomConsole.GetIntlStr(ResourceCustomField3);
                    }

                    return cachedCustomField3;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField2 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CustomField2
            {
                get
                {
                    if ((cachedCustomField2 == null))
                    {
                        cachedCustomField2 = CoreManager.MomConsole.GetIntlStr(ResourceCustomField2);
                    }

                    return cachedCustomField2;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomFields translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CustomFields
            {
                get
                {
                    if ((cachedCustomFields == null))
                    {
                        cachedCustomFields = CoreManager.MomConsole.GetIntlStr(ResourceCustomFields);
                    }

                    return cachedCustomFields;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField1 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CustomField1
            {
                get
                {
                    if ((cachedCustomField1 == null))
                    {
                        cachedCustomField1 = CoreManager.MomConsole.GetIntlStr(ResourceCustomField1);
                    }

                    return cachedCustomField1;
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
        /// 	[lucyra] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for NextButton
            /// </summary>
            public const string NextButton = "nextButton";

            /// <summary>
            /// Control ID for PreviousButton
            /// </summary>
            public const string PreviousButton = "prevButton";

            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";

            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";

            /// <summary>
            /// Control ID for ApplyButton
            /// </summary>
            public const string ApplyButton = "applyButton";

            /// <summary>
            /// Control ID for Tab5TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab5TabControl = "mainTabControl";

            /// <summary>
            /// Control ID for TextBox9
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string TextBox9 = "customField10Textbox";

            /// <summary>
            /// Control ID for CustomField10StaticControl
            /// </summary>
            public const string CustomField10StaticControl = "customField10Label";

            /// <summary>
            /// Control ID for TextBox10
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string TextBox10 = "customField9Textbox";

            /// <summary>
            /// Control ID for CustomField9StaticControl
            /// </summary>
            public const string CustomField9StaticControl = "customField9Label";

            /// <summary>
            /// Control ID for TextBox11
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string TextBox11 = "customField8Textbox";

            /// <summary>
            /// Control ID for CustomField8StaticControl
            /// </summary>
            public const string CustomField8StaticControl = "customField8Label";

            /// <summary>
            /// Control ID for TextBox12
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string TextBox12 = "customField7Textbox";

            /// <summary>
            /// Control ID for CustomField7StaticControl
            /// </summary>
            public const string CustomField7StaticControl = "customField7Label";

            /// <summary>
            /// Control ID for TextBox13
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string TextBox13 = "customField6Textbox";

            /// <summary>
            /// Control ID for CustomField6StaticControl
            /// </summary>
            public const string CustomField6StaticControl = "customField6Label";

            /// <summary>
            /// Control ID for TextBox14
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string TextBox14 = "customField5Textbox";

            /// <summary>
            /// Control ID for CustomField5StaticControl
            /// </summary>
            public const string CustomField5StaticControl = "customField5Label";

            /// <summary>
            /// Control ID for TextBox15
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string TextBox15 = "customField4Textbox";

            /// <summary>
            /// Control ID for CustomField4StaticControl
            /// </summary>
            public const string CustomField4StaticControl = "customField4Label";

            /// <summary>
            /// Control ID for TextBox16
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string TextBox16 = "customField3Textbox";

            /// <summary>
            /// Control ID for CustomField3StaticControl
            /// </summary>
            public const string CustomField3StaticControl = "customField3Label";

            /// <summary>
            /// Control ID for TextBox17
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string TextBox17 = "customField2Textbox";

            /// <summary>
            /// Control ID for CustomField2StaticControl
            /// </summary>
            public const string CustomField2StaticControl = "customField2Label";

            /// <summary>
            /// Control ID for CustomFieldsTextBox
            /// </summary>
            public const string CustomFieldsTextBox = "customField1Textbox";

            /// <summary>
            /// Control ID for CustomFieldsStaticControl
            /// </summary>
            public const string CustomFieldsStaticControl = "customFieldsSectionLabel";

            /// <summary>
            /// Control ID for CustomField1StaticControl
            /// </summary>
            public const string CustomField1StaticControl = "customField1Label";
        }
        #endregion
    }
}
