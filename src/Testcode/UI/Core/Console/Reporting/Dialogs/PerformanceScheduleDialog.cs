// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SubscribetoaReport-PerformanceDialog.cs">
// 	Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[v-liqluo] 8/24/2009 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Reporting.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;


    #region Interface Definition - IPerformanceScheduleDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISubscribetoaReport_PerformanceDialogControls, for SubscribetoaReport_PerformanceDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[v-liqluo] 8/26/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IPerformanceScheduleDialogControls
    {
        /// <summary>
        /// Read-only property to access PreviousButton
        /// </summary>
        Button PreviousButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access NextButton
        /// </summary>
        Button NextButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access FinishButton
        /// </summary>
        Button FinishButton
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
        /// Read-only property to access DeliveryStaticControl
        /// </summary>
        StaticControl DeliveryStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ScheduleStaticControl
        /// </summary>
        StaticControl ScheduleStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ParametersStaticControl
        /// </summary>
        StaticControl ParametersStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ScheduleTextBox
        /// </summary>
        TextBox ScheduleTextBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access FileNameRequiredStaticControl
        /// </summary>
        StaticControl FileNameRequiredStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access FileNameRequiredTextBox
        /// </summary>
        TextBox FileNameRequiredTextBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access PathRequiredStaticControl
        /// </summary>
        StaticControl PathRequiredStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access PathRequiredTextBox
        /// </summary>
        TextBox PathRequiredTextBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access RenderFormatRequiredStaticControl
        /// </summary>
        StaticControl RenderFormatRequiredStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access RenderFormatRequiredComboBox
        /// </summary>
        ComboBox RenderFormatRequiredComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access WriteModeStaticControl
        /// </summary>
        StaticControl WriteModeStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access WriteModeComboBox
        /// </summary>
        ComboBox WriteModeComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access FileExtensionCheckBox
        /// </summary>
        CheckBox FileExtensionCheckBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access UserNameRequiredStaticControl
        /// </summary>
        StaticControl UserNameRequiredStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access UserNameRequiredTextBox
        /// </summary>
        TextBox UserNameRequiredTextBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access PasswordRequiredStaticControl
        /// </summary>
        StaticControl PasswordRequiredStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access PasswordRequiredTextBox
        /// </summary>
        TextBox PasswordRequiredTextBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access DeliveryMethodComboBox
        /// </summary>
        ComboBox DeliveryMethodComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access DeliveryMethodStaticControl
        /// </summary>
        StaticControl DeliveryMethodStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access DescriptionStaticControl
        /// </summary>
        StaticControl DescriptionStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access HelpStaticControl
        /// </summary>
        StaticControl HelpStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access DeliverySettingsStaticControl
        /// </summary>
        StaticControl DeliverySettingsStaticControl
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
    /// 	[v-liqluo] 8/26/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class PerformanceScheduleDialog : Dialog, IPerformanceScheduleDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion

        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to PreviousButton of type Button
        /// </summary>
        private Button cachedPreviousButton;

        /// <summary>
        /// Cache to hold a reference to NextButton of type Button
        /// </summary>
        private Button cachedNextButton;

        /// <summary>
        /// Cache to hold a reference to FinishButton of type Button
        /// </summary>
        private Button cachedFinishButton;

        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;

        /// <summary>
        /// Cache to hold a reference to DeliveryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDeliveryStaticControl;

        /// <summary>
        /// Cache to hold a reference to ScheduleStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedScheduleStaticControl;

        /// <summary>
        /// Cache to hold a reference to ParametersStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedParametersStaticControl;

        /// <summary>
        /// Cache to hold a reference to ScheduleTextBox of type TextBox
        /// </summary>
        private TextBox cachedScheduleTextBox;

        /// <summary>
        /// Cache to hold a reference to FileNameRequiredStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedFileNameRequiredStaticControl;

        /// <summary>
        /// Cache to hold a reference to FileNameRequiredTextBox of type TextBox
        /// </summary>
        private TextBox cachedFileNameRequiredTextBox;

        /// <summary>
        /// Cache to hold a reference to PathRequiredStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPathRequiredStaticControl;

        /// <summary>
        /// Cache to hold a reference to PathRequiredTextBox of type TextBox
        /// </summary>
        private TextBox cachedPathRequiredTextBox;

        /// <summary>
        /// Cache to hold a reference to RenderFormatRequiredStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRenderFormatRequiredStaticControl;

        /// <summary>
        /// Cache to hold a reference to RenderFormatRequiredComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedRenderFormatRequiredComboBox;

        /// <summary>
        /// Cache to hold a reference to WriteModeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWriteModeStaticControl;

        /// <summary>
        /// Cache to hold a reference to WriteModeComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedWriteModeComboBox;

        /// <summary>
        /// Cache to hold a reference to FileExtensionCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedFileExtensionCheckBox;

        /// <summary>
        /// Cache to hold a reference to UserNameRequiredStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedUserNameRequiredStaticControl;

        /// <summary>
        /// Cache to hold a reference to UserNameRequiredTextBox of type TextBox
        /// </summary>
        private TextBox cachedUserNameRequiredTextBox;

        /// <summary>
        /// Cache to hold a reference to PasswordRequiredStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPasswordRequiredStaticControl;

        /// <summary>
        /// Cache to hold a reference to PasswordRequiredTextBox of type TextBox
        /// </summary>
        private TextBox cachedPasswordRequiredTextBox;

        /// <summary>
        /// Cache to hold a reference to DeliveryMethodComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedDeliveryMethodComboBox;

        /// <summary>
        /// Cache to hold a reference to DeliveryMethodStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDeliveryMethodStaticControl;

        /// <summary>
        /// Cache to hold a reference to DescriptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDescriptionStaticControl;

        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;

        /// <summary>
        /// Cache to hold a reference to DeliverySettingsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDeliverySettingsStaticControl;
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of SubscribetoaReport_PerformanceDialog of type App
        /// </param>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public PerformanceScheduleDialog(MomConsoleApp app) :
            base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion

        #region IPerformanceScheduleDialogControls Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IPerformanceScheduleDialogControls Controls
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
        ///  Property to handle checkbox FileExtension
        /// </summary>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool FileExtension
        {
            get
            {
                return this.Controls.FileExtensionCheckBox.Checked;
            }

            set
            {
                this.Controls.FileExtensionCheckBox.Checked = value;
            }
        }
        #endregion

        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Schedule
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ScheduleText
        {
            get
            {
                return this.Controls.ScheduleTextBox.Text;
            }

            set
            {
                this.Controls.ScheduleTextBox.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control FileNameRequired
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string FileNameRequiredText
        {
            get
            {
                return this.Controls.FileNameRequiredTextBox.Text;
            }

            set
            {
                this.Controls.FileNameRequiredTextBox.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control PathRequired
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string PathRequiredText
        {
            get
            {
                return this.Controls.PathRequiredTextBox.Text;
            }

            set
            {
                this.Controls.PathRequiredTextBox.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control RenderFormatRequired
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string RenderFormatRequiredText
        {
            get
            {
                return this.Controls.RenderFormatRequiredComboBox.Text;
            }

            set
            {
                this.Controls.RenderFormatRequiredComboBox.SelectByText(value, true);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control WriteMode
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string WriteModeText
        {
            get
            {
                return this.Controls.WriteModeComboBox.Text;
            }

            set
            {
                this.Controls.WriteModeComboBox.SelectByText(value, true);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control UserNameRequired
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string UserNameRequiredText
        {
            get
            {
                return this.Controls.UserNameRequiredTextBox.Text;
            }

            set
            {
                this.Controls.UserNameRequiredTextBox.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control PasswordRequired
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string PasswordRequiredText
        {
            get
            {
                return this.Controls.PasswordRequiredTextBox.Text;
            }

            set
            {
                this.Controls.PasswordRequiredTextBox.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control DeliveryMethod
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DeliveryMethodText
        {
            get
            {
                return this.Controls.DeliveryMethodComboBox.Text;
            }

            set
            {
                this.Controls.DeliveryMethodComboBox.SelectByText(value, true);
            }
        }
        #endregion

        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceScheduleDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, PerformanceScheduleDialog.ControlIDs.PreviousButton);
                }

                return this.cachedPreviousButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceScheduleDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, PerformanceScheduleDialog.ControlIDs.NextButton);
                }

                return this.cachedNextButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FinishButton control
        /// </summary>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceScheduleDialogControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, PerformanceScheduleDialog.ControlIDs.FinishButton);
                }

                return this.cachedFinishButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceScheduleDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, PerformanceScheduleDialog.ControlIDs.CancelButton);
                }

                return this.cachedCancelButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DeliveryStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceScheduleDialogControls.DeliveryStaticControl
        {
            get
            {
                if ((this.cachedDeliveryStaticControl == null))
                {
                    this.cachedDeliveryStaticControl = new StaticControl(this, PerformanceScheduleDialog.ControlIDs.DeliveryStaticControl);
                }

                return this.cachedDeliveryStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ScheduleStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceScheduleDialogControls.ScheduleStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedScheduleStaticControl == null))
                {
                    Window wndTemp = this;

                    // Required to navigate to control
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
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedScheduleStaticControl = new StaticControl(wndTemp);
                }

                return this.cachedScheduleStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ParametersStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceScheduleDialogControls.ParametersStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedParametersStaticControl == null))
                {
                    Window wndTemp = this;

                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedParametersStaticControl = new StaticControl(wndTemp);
                }

                return this.cachedParametersStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ScheduleTextBox control
        /// </summary>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IPerformanceScheduleDialogControls.ScheduleTextBox
        {
            get
            {
                if ((this.cachedScheduleTextBox == null))
                {
                    this.cachedScheduleTextBox = new TextBox(this, PerformanceScheduleDialog.ControlIDs.ScheduleTextBox);
                }

                return this.cachedScheduleTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FileNameRequiredStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceScheduleDialogControls.FileNameRequiredStaticControl
        {
            get
            {
                if ((this.cachedFileNameRequiredStaticControl == null))
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
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedFileNameRequiredStaticControl = new StaticControl(wndTemp);
                }

                return this.cachedFileNameRequiredStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FileNameRequiredTextBox control
        /// </summary>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IPerformanceScheduleDialogControls.FileNameRequiredTextBox
        {
            get
            {
                if ((this.cachedFileNameRequiredTextBox == null))
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
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    this.cachedFileNameRequiredTextBox = new TextBox(wndTemp);
                }

                return this.cachedFileNameRequiredTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PathRequiredStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceScheduleDialogControls.PathRequiredStaticControl
        {
            get
            {
                if ((this.cachedPathRequiredStaticControl == null))
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
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    this.cachedPathRequiredStaticControl = new StaticControl(wndTemp);
                }

                return this.cachedPathRequiredStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PathRequiredTextBox control
        /// </summary>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IPerformanceScheduleDialogControls.PathRequiredTextBox
        {
            get
            {
                if ((this.cachedPathRequiredTextBox == null))
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
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    this.cachedPathRequiredTextBox = new TextBox(wndTemp);
                }

                return this.cachedPathRequiredTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RenderFormatRequiredStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceScheduleDialogControls.RenderFormatRequiredStaticControl
        {
            get
            {
                if ((this.cachedRenderFormatRequiredStaticControl == null))
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
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 3); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    this.cachedRenderFormatRequiredStaticControl = new StaticControl(wndTemp);
                }

                return this.cachedRenderFormatRequiredStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RenderFormatRequiredComboBox control
        /// </summary>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IPerformanceScheduleDialogControls.RenderFormatRequiredComboBox
        {
            get
            {
                if ((this.cachedRenderFormatRequiredComboBox == null))
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
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 4); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    this.cachedRenderFormatRequiredComboBox = new ComboBox(wndTemp);
                }

                return this.cachedRenderFormatRequiredComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WriteModeStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceScheduleDialogControls.WriteModeStaticControl
        {
            get
            {
                if ((this.cachedWriteModeStaticControl == null))
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
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 5); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    this.cachedWriteModeStaticControl = new StaticControl(wndTemp);
                }

                return this.cachedWriteModeStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WriteModeComboBox control
        /// </summary>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IPerformanceScheduleDialogControls.WriteModeComboBox
        {
            get
            {
                if ((this.cachedWriteModeComboBox == null))
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
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 6); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    this.cachedWriteModeComboBox = new ComboBox(wndTemp);
                }

                return this.cachedWriteModeComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FileExtensionCheckBox control
        /// </summary>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IPerformanceScheduleDialogControls.FileExtensionCheckBox
        {
            get
            {
                if ((this.cachedFileExtensionCheckBox == null))
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
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 7); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    this.cachedFileExtensionCheckBox = new CheckBox(wndTemp);
                }

                return this.cachedFileExtensionCheckBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UserNameRequiredStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceScheduleDialogControls.UserNameRequiredStaticControl
        {
            get
            {
                if ((this.cachedUserNameRequiredStaticControl == null))
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
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 8); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    this.cachedUserNameRequiredStaticControl = new StaticControl(wndTemp);
                }

                return this.cachedUserNameRequiredStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UserNameRequiredTextBox control
        /// </summary>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IPerformanceScheduleDialogControls.UserNameRequiredTextBox
        {
            get
            {
                if ((this.cachedUserNameRequiredTextBox == null))
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
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 9); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    this.cachedUserNameRequiredTextBox = new TextBox(wndTemp);
                }

                return this.cachedUserNameRequiredTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PasswordRequiredStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceScheduleDialogControls.PasswordRequiredStaticControl
        {
            get
            {
                if ((this.cachedPasswordRequiredStaticControl == null))
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
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 10); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    this.cachedPasswordRequiredStaticControl = new StaticControl(wndTemp);
                }

                return this.cachedPasswordRequiredStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PasswordRequiredTextBox control
        /// </summary>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IPerformanceScheduleDialogControls.PasswordRequiredTextBox
        {
            get
            {
                if ((this.cachedPasswordRequiredTextBox == null))
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
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 11); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    this.cachedPasswordRequiredTextBox = new TextBox(wndTemp);
                }

                return this.cachedPasswordRequiredTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DeliveryMethodComboBox control
        /// </summary>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IPerformanceScheduleDialogControls.DeliveryMethodComboBox
        {
            get
            {
                if ((this.cachedDeliveryMethodComboBox == null))
                {
                    this.cachedDeliveryMethodComboBox = new ComboBox(this, PerformanceScheduleDialog.ControlIDs.DeliveryMethodComboBox);
                }

                return this.cachedDeliveryMethodComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DeliveryMethodStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceScheduleDialogControls.DeliveryMethodStaticControl
        {
            get
            {
                if ((this.cachedDeliveryMethodStaticControl == null))
                {
                    this.cachedDeliveryMethodStaticControl = new StaticControl(this, PerformanceScheduleDialog.ControlIDs.DeliveryMethodStaticControl);
                }

                return this.cachedDeliveryMethodStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceScheduleDialogControls.DescriptionStaticControl
        {
            get
            {
                if ((this.cachedDescriptionStaticControl == null))
                {
                    this.cachedDescriptionStaticControl = new StaticControl(this, PerformanceScheduleDialog.ControlIDs.DescriptionStaticControl);
                }

                return this.cachedDescriptionStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceScheduleDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, PerformanceScheduleDialog.ControlIDs.HelpStaticControl);
                }

                return this.cachedHelpStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DeliverySettingsStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceScheduleDialogControls.DeliverySettingsStaticControl
        {
            get
            {
                if ((this.cachedDeliverySettingsStaticControl == null))
                {
                    this.cachedDeliverySettingsStaticControl = new StaticControl(this, PerformanceScheduleDialog.ControlIDs.DeliverySettingsStaticControl);
                }

                return this.cachedDeliverySettingsStaticControl;
            }
        }
        #endregion

        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickPrevious()
        {
            this.Controls.PreviousButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Next
        /// </summary>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNext()
        {
            this.Controls.NextButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Finish
        /// </summary>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickFinish()
        {
            this.Controls.FinishButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button FileExtension
        /// </summary>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickFileExtension()
        {
            this.Controls.FileExtensionCheckBox.Click();
        }
        #endregion

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">App owning the dialog.</param>
        /// <history>
        /// 	[v-liqluo] 8/26/2009 Created
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
            catch (Exceptions.WindowNotFoundException)
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
                        Mom.Test.UI.Core.Common.Utilities.LogMessage("Attempt " + numberOfTries + " of " + maxTries);
                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
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
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            private const string ResourceDialogTitle = ";Subscribe to a Report - {0};ManagedString;Microsoft.EnterpriseManag"+
                "ement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Wizards.Schedule.ReportSubs"+
                "criptionResources;SubscriptionWizardTitle";

            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            private const string ResourcePrevious = @";< &Previous;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFra"+
                "mework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel;previousButton.Text";

            /// <summary>
            /// Contains resource string for: Next >
            /// </summary>
            private const string ResourceNext = @";&Next >;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;"+
                "Microsoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel;nextButton.Text";

            /// <summary>
            /// Contains resource string for: Finish
            /// </summary>
            private const string ResourceFinish = @";&Finish;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll"+
                ";Microsoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel;commitButton.Text";

            /// <summary>
            /// Contains resource string for: Cancel
            /// </summary>
            private const string ResourceCancel = ";Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;"+
                "Microsoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel;cancelButton.Text";

            /// <summary>
            /// Contains resource string for: Delivery
            /// </summary>
            private const string ResourceDelivery = ";Delivery;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Micr"+
                "osoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Wizards.Schedule.ReportSubscriptionDeliveryPage;$this.TabName";

            /// <summary>
            /// Contains resource string for: Schedule
            /// </summary>
            private const string ResourceSchedule = ";Schedule;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Micr"+
                "osoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Wizards.Schedule.ReportSubscriptionSchedulePage;$this.TabName";

            /// <summary>
            /// Contains resource string for: Parameters
            /// </summary>
            private const string ResourceParameters = ";Parameters;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;M"+
                "icrosoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Wizards.Schedule.ReportSubscriptionParametersPage;$this."+
                "TabName";

            /// <summary>
            /// Contains resource string for: File name (required):
            /// </summary>
            private const string ResourceFileNameRequired = "File name (required):";

            /// <summary>
            /// Contains resource string for: Path (required):
            /// </summary>
            private const string ResourcePathRequired = "Path (required):";

            /// <summary>
            /// Contains resource string for: Render Format (required):
            /// </summary>
            private const string ResourceRenderFormatRequired = "Render Format (required):";

            /// <summary>
            /// Contains resource string for: Write mode:
            /// </summary>
            private const string ResourceWriteMode = "Write mode:";

            /// <summary>
            /// Contains resource string for: File Extension
            /// </summary>
            private const string ResourceFileExtension = "File Extension";

            /// <summary>
            /// Contains resource string for: User name (required):
            /// </summary>
            private const string ResourceUserNameRequired = "User name (required):";

            /// <summary>
            /// Contains resource string for: Password (required):
            /// </summary>
            private const string ResourcePasswordRequired = "Password (required):";

            /// <summary>
            /// Contains resource string for: Delivery method:
            /// </summary>
            private const string ResourceDeliveryMethod = ";Delivery method:;ManagedString;Microsoft.EnterpriseManagement.UI."+
                "Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Wizards.Schedule.ReportSubscriptionDel"+
                "iveryPage;label2.Text";

            /// <summary>
            /// Contains resource string for: Description:
            /// </summary>
            private const string ResourceDescription = ";descriptionEditor;ManagedString;Microsoft.EnterpriseManagement.UI.Repor"+
                "ting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Wizards.Schedule.ReportSubscriptionDeliveryPag"+
                "e;>>descriptionEditor.Name";

            /// <summary>
            /// Contains resource string for: Help
            /// </summary>
            private const string ResourceHelp = "Help";

            /// <summary>
            /// Contains resource string for: Delivery Settings
            /// </summary>
            private const string ResourceDeliverySettings = ";Delivery Settings;ManagedString;Microsoft.EnterpriseManagement.UI."+
                "Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Wizards.Schedule.ReportSubscriptionDelive"+
                "ryPage;$this.Title";
            #endregion

            #region Private Members
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            private static string cachedDialogTitle;

            /// <summary>
            /// Caches the translated resource string for: Previous
            /// </summary>
            private static string cachedPrevious;

            /// <summary>
            /// Caches the translated resource string for: Next >
            /// </summary>
            private static string cachedNext;

            /// <summary>
            /// Caches the translated resource string for: Finish
            /// </summary>
            private static string cachedFinish;

            /// <summary>
            /// Caches the translated resource string for: Cancel
            /// </summary>
            private static string cachedCancel;

            /// <summary>
            /// Caches the translated resource string for: Delivery
            /// </summary>
            private static string cachedDelivery;

            /// <summary>
            /// Caches the translated resource string for: Schedule
            /// </summary>
            private static string cachedSchedule;

            /// <summary>
            /// Caches the translated resource string for: Parameters
            /// </summary>
            private static string cachedParameters;

            /// <summary>
            /// Caches the translated resource string for: File name (required):
            /// </summary>
            private static string cachedFileNameRequired;

            /// <summary>
            /// Caches the translated resource string for: Path (required):
            /// </summary>
            private static string cachedPathRequired;

            /// <summary>
            /// Caches the translated resource string for: Render Format (required):
            /// </summary>
            private static string cachedRenderFormatRequired;

            /// <summary>
            /// Caches the translated resource string for: Write mode:
            /// </summary>
            private static string cachedWriteMode;

            /// <summary>
            /// Caches the translated resource string for: File Extension
            /// </summary>
            private static string cachedFileExtension;

            /// <summary>
            /// Caches the translated resource string for: User name (required):
            /// </summary>
            private static string cachedUserNameRequired;

            /// <summary>
            /// Caches the translated resource string for: Password (required):
            /// </summary>
            private static string cachedPasswordRequired;

            /// <summary>
            /// Caches the translated resource string for: Delivery method:
            /// </summary>
            private static string cachedDeliveryMethod;

            /// <summary>
            /// Caches the translated resource string for: Description:
            /// </summary>
            private static string cachedDescription;

            /// <summary>
            /// Caches the translated resource string for: Help
            /// </summary>
            private static string cachedHelp;

            /// <summary>
            /// Caches the translated resource string for: Delivery Settings
            /// </summary>
            private static string cachedDeliverySettings;
            #endregion

            #region Properties
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[v-liqluo] 8/26/2009 Created
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

                    Mom.Test.UI.Core.Common.Utilities.LogMessage("cachedDialogTitle is " + cachedDialogTitle);
                    System.Text.StringBuilder newDialogTitle = new System.Text.StringBuilder(cachedDialogTitle);

                    // Check if ReportDisplayName is not null
                    if (Reporting.ReportDisplayName == null)
                    {
                        throw new Maui.GlobalExceptions.MauiException("Exception in getting Dialog Title for Performance Dialog! Cannot use ReportDisplayName as it is null!");
                    }

                    // Replace {0} with the report name: Performance
                    newDialogTitle.Replace("{0}", Reporting.ReportDisplayName);
                    Mom.Test.UI.Core.Common.Utilities.LogMessage("Remove 0 cachedDialogTitle is " + newDialogTitle);

                    cachedDialogTitle = newDialogTitle.ToString();
                    Mom.Test.UI.Core.Common.Utilities.LogMessage("cachedDialogTitle is " + cachedDialogTitle);
                    return cachedDialogTitle;
                }
            }
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Previous translated resource string
            /// </summary>
            /// <history>
            /// 	[v-liqluo] 8/26/2009 Created
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
            /// Exposes access to the Next translated resource string
            /// </summary>
            /// <history>
            /// 	[v-liqluo] 8/26/2009 Created
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
            /// Exposes access to the Finish translated resource string
            /// </summary>
            /// <history>
            /// 	[v-liqluo] 8/26/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Finish
            {
                get
                {
                    if ((cachedFinish == null))
                    {
                        cachedFinish = CoreManager.MomConsole.GetIntlStr(ResourceFinish);
                    }

                    return cachedFinish;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[v-liqluo] 8/26/2009 Created
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
            /// Exposes access to the Delivery translated resource string
            /// </summary>
            /// <history>
            /// 	[v-liqluo] 8/26/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Delivery
            {
                get
                {
                    if ((cachedDelivery == null))
                    {
                        cachedDelivery = CoreManager.MomConsole.GetIntlStr(ResourceDelivery);
                    }

                    return cachedDelivery;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Schedule translated resource string
            /// </summary>
            /// <history>
            /// 	[v-liqluo] 8/26/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Schedule
            {
                get
                {
                    if ((cachedSchedule == null))
                    {
                        cachedSchedule = CoreManager.MomConsole.GetIntlStr(ResourceSchedule);
                    }

                    return cachedSchedule;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Parameters translated resource string
            /// </summary>
            /// <history>
            /// 	[v-liqluo] 8/26/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Parameters
            {
                get
                {
                    if ((cachedParameters == null))
                    {
                        cachedParameters = CoreManager.MomConsole.GetIntlStr(ResourceParameters);
                    }

                    return cachedParameters;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the FileNameRequired translated resource string
            /// </summary>
            /// <history>
            /// 	[v-liqluo] 8/26/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FileNameRequired
            {
                get
                {
                    if ((cachedFileNameRequired == null))
                    {
                        cachedFileNameRequired = CoreManager.MomConsole.GetIntlStr(ResourceFileNameRequired);
                    }

                    return cachedFileNameRequired;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the PathRequired translated resource string
            /// </summary>
            /// <history>
            /// 	[v-liqluo] 8/26/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string PathRequired
            {
                get
                {
                    if ((cachedPathRequired == null))
                    {
                        cachedPathRequired = CoreManager.MomConsole.GetIntlStr(ResourcePathRequired);
                    }

                    return cachedPathRequired;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RenderFormatRequired translated resource string
            /// </summary>
            /// <history>
            /// 	[v-liqluo] 8/26/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RenderFormatRequired
            {
                get
                {
                    if ((cachedRenderFormatRequired == null))
                    {
                        cachedRenderFormatRequired = CoreManager.MomConsole.GetIntlStr(ResourceRenderFormatRequired);
                    }

                    return cachedRenderFormatRequired;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WriteMode translated resource string
            /// </summary>
            /// <history>
            /// 	[v-liqluo] 8/26/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WriteMode
            {
                get
                {
                    if ((cachedWriteMode == null))
                    {
                        cachedWriteMode = CoreManager.MomConsole.GetIntlStr(ResourceWriteMode);
                    }

                    return cachedWriteMode;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the FileExtension translated resource string
            /// </summary>
            /// <history>
            /// 	[v-liqluo] 8/26/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FileExtension
            {
                get
                {
                    if ((cachedFileExtension == null))
                    {
                        cachedFileExtension = CoreManager.MomConsole.GetIntlStr(ResourceFileExtension);
                    }

                    return cachedFileExtension;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the UserNameRequired translated resource string
            /// </summary>
            /// <history>
            /// 	[v-liqluo] 8/26/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UserNameRequired
            {
                get
                {
                    if ((cachedUserNameRequired == null))
                    {
                        cachedUserNameRequired = CoreManager.MomConsole.GetIntlStr(ResourceUserNameRequired);
                    }

                    return cachedUserNameRequired;
                }
            }
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the PasswordRequired translated resource string
            /// </summary>
            /// <history>
            /// 	[v-liqluo] 8/26/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string PasswordRequired
            {
                get
                {
                    if ((cachedPasswordRequired == null))
                    {
                        cachedPasswordRequired = CoreManager.MomConsole.GetIntlStr(ResourcePasswordRequired);
                    }

                    return cachedPasswordRequired;
                }
            }
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DeliveryMethod translated resource string
            /// </summary>
            /// <history>
            /// 	[v-liqluo] 8/26/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DeliveryMethod
            {
                get
                {
                    if ((cachedDeliveryMethod == null))
                    {
                        cachedDeliveryMethod = CoreManager.MomConsole.GetIntlStr(ResourceDeliveryMethod);
                    }

                    return cachedDeliveryMethod;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Description translated resource string
            /// </summary>
            /// <history>
            /// 	[v-liqluo] 8/26/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Description
            {
                get
                {
                    if ((cachedDescription == null))
                    {
                        cachedDescription = CoreManager.MomConsole.GetIntlStr(ResourceDescription);
                    }

                    return cachedDescription;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[v-liqluo] 8/26/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Help
            {
                get
                {
                    if ((cachedHelp == null))
                    {
                        cachedHelp = CoreManager.MomConsole.GetIntlStr(ResourceHelp);
                    }

                    return cachedHelp;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DeliverySettings translated resource string
            /// </summary>
            /// <history>
            /// 	[v-liqluo] 8/26/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DeliverySettings
            {
                get
                {
                    if ((cachedDeliverySettings == null))
                    {
                        cachedDeliverySettings = CoreManager.MomConsole.GetIntlStr(ResourceDeliverySettings);
                    }

                    return cachedDeliverySettings;
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
        /// 	[v-liqluo] 8/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for PreviousButton
            /// </summary>
            public const string PreviousButton = "previousButton";

            /// <summary>
            /// Control ID for NextButton
            /// </summary>
            public const string NextButton = "nextButton";

            /// <summary>
            /// Control ID for FinishButton
            /// </summary>
            public const string FinishButton = "commitButton";

            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";

            /// <summary>
            /// Control ID for DeliveryStaticControl
            /// </summary>
            public const string DeliveryStaticControl = "textLinkLabel";

            /// <summary>
            /// Control ID for ScheduleStaticControl
            /// </summary>
            public const string ScheduleStaticControl = "textLinkLabel";

            /// <summary>
            /// Control ID for ParametersStaticControl
            /// </summary>
            public const string ParametersStaticControl = "textLinkLabel";

            /// <summary>
            /// Control ID for ScheduleTextBox
            /// </summary>
            public const string ScheduleTextBox = "descriptionEditor";

            /// <summary>
            /// Control ID for DeliveryMethodComboBox
            /// </summary>
            public const string DeliveryMethodComboBox = "methodSelector";

            /// <summary>
            /// Control ID for DeliveryMethodStaticControl
            /// </summary>
            public const string DeliveryMethodStaticControl = "label2";

            /// <summary>
            /// Control ID for DescriptionStaticControl
            /// </summary>
            public const string DescriptionStaticControl = "label1";

            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";

            /// <summary>
            /// Control ID for DeliverySettingsStaticControl
            /// </summary>
            public const string DeliverySettingsStaticControl = "headerLabel";
        }
        #endregion
    }
}
