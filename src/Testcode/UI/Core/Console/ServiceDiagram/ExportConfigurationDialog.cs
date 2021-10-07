// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ExportConfigurationDialog.cs">
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
// </history>
// -----------------------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.ServiceDiagram
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IExportConfigurationDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IExportConfigurationDialogControls, for ExportConfigurationDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 9/17/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IExportConfigurationDialogControls
    {
        /// <summary>
        /// Read-only property to access LockAspectRatioCheckBox
        /// </summary>
        CheckBox LockAspectRatioCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WidthTextBox
        /// </summary>
        TextBox WidthTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WidthStaticControl
        /// </summary>
        StaticControl WidthStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HeightTextBox
        /// </summary>
        TextBox HeightTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HeightStaticControl
        /// </summary>
        StaticControl HeightStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DPIXTextBox
        /// </summary>
        TextBox DPIXTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DPIXStaticControl
        /// </summary>
        StaticControl DPIXStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DPIYStaticControl
        /// </summary>
        StaticControl DPIYStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LockResolutionCheckBox
        /// </summary>
        CheckBox LockResolutionCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DPIYTextBox
        /// </summary>
        TextBox DPIYTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LowQualityTextBox
        /// </summary>
        TextBox LowQualityTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LowQualityStaticControl
        /// </summary>
        StaticControl LowQualityStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CompressionSlider
        /// </summary>
        StaticControl CompressionSlider
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CompressionStaticControl
        /// </summary>
        StaticControl CompressionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HighQualityStaticControl
        /// </summary>
        StaticControl HighQualityStaticControl
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
        /// Read-only property to access ImageTypeStaticControl
        /// </summary>
        StaticControl ImageTypeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ImageTypeComboBox
        /// </summary>
        ComboBox ImageTypeComboBox
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
    /// Class to encapsulate the functionality of the "Export Configuration" dialog
    /// in the diagram view.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 9/17/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ExportConfigurationDialog : Dialog, IExportConfigurationDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to LockAspectRatioCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedLockAspectRatioCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to WidthTextBox of type TextBox
        /// </summary>
        private TextBox cachedWidthTextBox;
        
        /// <summary>
        /// Cache to hold a reference to WidthStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWidthStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HeightTextBox of type TextBox
        /// </summary>
        private TextBox cachedHeightTextBox;
        
        /// <summary>
        /// Cache to hold a reference to HeightStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHeightStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DPIXTextBox of type TextBox
        /// </summary>
        private TextBox cachedDPIXTextBox;
        
        /// <summary>
        /// Cache to hold a reference to DPIXStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDPIXStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DPIYStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDPIYStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to LockResolutionCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedLockResolutionCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to DPIYTextBox of type TextBox
        /// </summary>
        private TextBox cachedDPIYTextBox;
        
        /// <summary>
        /// Cache to hold a reference to LowQualityTextBox of type TextBox
        /// </summary>
        private TextBox cachedLowQualityTextBox;
        
        /// <summary>
        /// Cache to hold a reference to LowQualityStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedLowQualityStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CompressionSlider of type StaticControl
        /// </summary>
        private StaticControl cachedCompressionSlider;
        
        /// <summary>
        /// Cache to hold a reference to CompressionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCompressionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HighQualityStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHighQualityStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to ImageTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedImageTypeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ImageTypeComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedImageTypeComboBox;
        
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
        /// Owner of ExportConfigurationDialog of type App
        /// </param>
        /// <history>
        /// 	[KellyMor] 9/17/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ExportConfigurationDialog(App app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IExportConfigurationDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[KellyMor] 9/17/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IExportConfigurationDialogControls Controls
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
        ///  Property to handle checkbox LockAspectRatio
        /// </summary>
        /// <history>
        /// 	[KellyMor] 9/17/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool LockAspectRatio
        {
            get
            {
                return this.Controls.LockAspectRatioCheckBox.Checked;
            }
            
            set
            {
                this.Controls.LockAspectRatioCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox LockResolution
        /// </summary>
        /// <history>
        /// 	[KellyMor] 9/17/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool LockResolution
        {
            get
            {
                return this.Controls.LockResolutionCheckBox.Checked;
            }
            
            set
            {
                this.Controls.LockResolutionCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Width
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 9/17/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string WidthText
        {
            get
            {
                return this.Controls.WidthTextBox.Text;
            }
            
            set
            {
                this.Controls.WidthTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Height
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 9/17/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string HeightText
        {
            get
            {
                return this.Controls.HeightTextBox.Text;
            }
            
            set
            {
                this.Controls.HeightTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control DPIX
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 9/17/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DPIXText
        {
            get
            {
                return this.Controls.DPIXTextBox.Text;
            }
            
            set
            {
                this.Controls.DPIXTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control DPIY
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 9/17/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DPIYText
        {
            get
            {
                return this.Controls.DPIYTextBox.Text;
            }
            
            set
            {
                this.Controls.DPIYTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control LowQuality
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 9/17/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string LowQualityText
        {
            get
            {
                return this.Controls.LowQualityTextBox.Text;
            }
            
            set
            {
                this.Controls.LowQualityTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ImageType
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 9/17/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ImageTypeText
        {
            get
            {
                return this.Controls.ImageTypeComboBox.Text;
            }
            
            set
            {
                this.Controls.ImageTypeComboBox.SelectByText(value, true);
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LockAspectRatioCheckBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 9/17/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IExportConfigurationDialogControls.LockAspectRatioCheckBox
        {
            get
            {
                if ((this.cachedLockAspectRatioCheckBox == null))
                {
                    this.cachedLockAspectRatioCheckBox = new CheckBox(this, ExportConfigurationDialog.ControlIDs.LockAspectRatioCheckBox);
                }
                
                return this.cachedLockAspectRatioCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WidthTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 9/17/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IExportConfigurationDialogControls.WidthTextBox
        {
            get
            {
                if ((this.cachedWidthTextBox == null))
                {
                    this.cachedWidthTextBox = new TextBox(this, ExportConfigurationDialog.ControlIDs.WidthTextBox);
                }
                
                return this.cachedWidthTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WidthStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 9/17/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IExportConfigurationDialogControls.WidthStaticControl
        {
            get
            {
                if ((this.cachedWidthStaticControl == null))
                {
                    this.cachedWidthStaticControl = new StaticControl(this, ExportConfigurationDialog.ControlIDs.WidthStaticControl);
                }
                
                return this.cachedWidthStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HeightTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 9/17/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IExportConfigurationDialogControls.HeightTextBox
        {
            get
            {
                if ((this.cachedHeightTextBox == null))
                {
                    this.cachedHeightTextBox = new TextBox(this, ExportConfigurationDialog.ControlIDs.HeightTextBox);
                }
                
                return this.cachedHeightTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HeightStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 9/17/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IExportConfigurationDialogControls.HeightStaticControl
        {
            get
            {
                if ((this.cachedHeightStaticControl == null))
                {
                    this.cachedHeightStaticControl = new StaticControl(this, ExportConfigurationDialog.ControlIDs.HeightStaticControl);
                }
                
                return this.cachedHeightStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DPIXTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 9/17/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IExportConfigurationDialogControls.DPIXTextBox
        {
            get
            {
                if ((this.cachedDPIXTextBox == null))
                {
                    this.cachedDPIXTextBox = new TextBox(this, ExportConfigurationDialog.ControlIDs.DPIXTextBox);
                }
                
                return this.cachedDPIXTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DPIXStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 9/17/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IExportConfigurationDialogControls.DPIXStaticControl
        {
            get
            {
                if ((this.cachedDPIXStaticControl == null))
                {
                    this.cachedDPIXStaticControl = new StaticControl(this, ExportConfigurationDialog.ControlIDs.DPIXStaticControl);
                }
                
                return this.cachedDPIXStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DPIYStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 9/17/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IExportConfigurationDialogControls.DPIYStaticControl
        {
            get
            {
                if ((this.cachedDPIYStaticControl == null))
                {
                    this.cachedDPIYStaticControl = new StaticControl(this, ExportConfigurationDialog.ControlIDs.DPIYStaticControl);
                }
                
                return this.cachedDPIYStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LockResolutionCheckBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 9/17/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IExportConfigurationDialogControls.LockResolutionCheckBox
        {
            get
            {
                if ((this.cachedLockResolutionCheckBox == null))
                {
                    this.cachedLockResolutionCheckBox = new CheckBox(this, ExportConfigurationDialog.ControlIDs.LockResolutionCheckBox);
                }
                
                return this.cachedLockResolutionCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DPIYTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 9/17/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IExportConfigurationDialogControls.DPIYTextBox
        {
            get
            {
                if ((this.cachedDPIYTextBox == null))
                {
                    this.cachedDPIYTextBox = new TextBox(this, ExportConfigurationDialog.ControlIDs.DPIYTextBox);
                }
                
                return this.cachedDPIYTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LowQualityTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 9/17/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IExportConfigurationDialogControls.LowQualityTextBox
        {
            get
            {
                if ((this.cachedLowQualityTextBox == null))
                {
                    this.cachedLowQualityTextBox = new TextBox(this, ExportConfigurationDialog.ControlIDs.LowQualityTextBox);
                }
                
                return this.cachedLowQualityTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LowQualityStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 9/17/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IExportConfigurationDialogControls.LowQualityStaticControl
        {
            get
            {
                if ((this.cachedLowQualityStaticControl == null))
                {
                    this.cachedLowQualityStaticControl = new StaticControl(this, ExportConfigurationDialog.ControlIDs.LowQualityStaticControl);
                }
                
                return this.cachedLowQualityStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CompressionSlider control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 9/17/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IExportConfigurationDialogControls.CompressionSlider
        {
            get
            {
                if ((this.cachedCompressionSlider == null))
                {
                    this.cachedCompressionSlider = new StaticControl(this, ExportConfigurationDialog.ControlIDs.CompressionSlider);
                }
                
                return this.cachedCompressionSlider;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CompressionStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 9/17/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IExportConfigurationDialogControls.CompressionStaticControl
        {
            get
            {
                if ((this.cachedCompressionStaticControl == null))
                {
                    this.cachedCompressionStaticControl = new StaticControl(this, ExportConfigurationDialog.ControlIDs.CompressionStaticControl);
                }
                
                return this.cachedCompressionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HighQualityStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 9/17/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IExportConfigurationDialogControls.HighQualityStaticControl
        {
            get
            {
                if ((this.cachedHighQualityStaticControl == null))
                {
                    this.cachedHighQualityStaticControl = new StaticControl(this, ExportConfigurationDialog.ControlIDs.HighQualityStaticControl);
                }
                
                return this.cachedHighQualityStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 9/17/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IExportConfigurationDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, ExportConfigurationDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ImageTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 9/17/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IExportConfigurationDialogControls.ImageTypeStaticControl
        {
            get
            {
                if ((this.cachedImageTypeStaticControl == null))
                {
                    this.cachedImageTypeStaticControl = new StaticControl(this, ExportConfigurationDialog.ControlIDs.ImageTypeStaticControl);
                }
                
                return this.cachedImageTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ImageTypeComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 9/17/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IExportConfigurationDialogControls.ImageTypeComboBox
        {
            get
            {
                if ((this.cachedImageTypeComboBox == null))
                {
                    this.cachedImageTypeComboBox = new ComboBox(this, ExportConfigurationDialog.ControlIDs.ImageTypeComboBox);
                }
                
                return this.cachedImageTypeComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 9/17/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IExportConfigurationDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ExportConfigurationDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button LockAspectRatio
        /// </summary>
        /// <history>
        /// 	[KellyMor] 9/17/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickLockAspectRatio()
        {
            this.Controls.LockAspectRatioCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button LockResolution
        /// </summary>
        /// <history>
        /// 	[KellyMor] 9/17/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickLockResolution()
        {
            this.Controls.LockResolutionCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[KellyMor] 9/17/2007 Created
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
        /// 	[KellyMor] 9/17/2007 Created
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
        /// <history>
        /// 	[KellyMor] 17SEP07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow =
                    new Window(
                        Strings.DialogTitle, 
                        StringMatchSyntax.ExactMatch, 
                        WindowClassNames.WinForms10Window8, 
                        StringMatchSyntax.ExactMatch, 
                        app.MainWindow, 
                        Timeout);
            }
            catch (Exceptions.WindowNotFoundException windowNotFound)
            {
                Core.Common.Utilities.LogMessage(
                    "Looking for window with title:  '" +
                    Strings.DialogTitle +
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
                                Strings.DialogTitle, 
                                StringMatchSyntax.WildCard);

                        // Wait for the window to become ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow, 
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
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
                       ExportConfigurationDialog.Strings.DialogTitle +
                       "' window.");

                    try
                    {
                        // get top-most window title
                        Window topMostWindow =
                            new Window(WindowType.Foreground);

                        Core.Common.Utilities.LogMessage(
                            "Top-most window title found:  '" +
                            topMostWindow.Caption +
                            "'");
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        Core.Common.Utilities.LogMessage(
                            "Failed to find the top-most window.");
                    }

                    // rethrow the original exception
                    throw windowNotFound;
                }
            }
            
            return tempWindow;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Resource strings
        /// </summary>
        /// <history>
        /// 	[KellyMor] 9/17/2007 Created
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
            private const string ResourceDialogTitle = ";Export Configuration;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.ExportToImage.ExportConfiguration;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  LockAspectRatio
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLockAspectRatio = ";&Lock Aspect Ratio;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.ExportToImage.ExportConfiguration;lockAspectCheckBox.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Width
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWidth = ";&Width:;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.AppearanceProperties;label2.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Height
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHeight = ";&Height:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.ExportToImage.ExportConfiguration;heightLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DPIX
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDPIX = ";DPI &X:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.ExportToImage.ExportConfiguration;dpiXLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DPIY
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDPIY = ";DPI &Y:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.ExportToImage.ExportConfiguration;dpiYLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  LockResolution
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLockResolution = ";&Lock Resolution;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.ExportToImage.ExportConfiguration;lockDpiCheckBox.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  LowQuality
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLowQuality = ";Low Quality;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.ExportToImage.JpegExportOptions;lowQualityLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Compression
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCompression = ";&Compression:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.ExportToImage.JpegExportOptions;compressionLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  HighQuality
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHighQuality = ";High Quality;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.ExportToImage.JpegExportOptions;highQualityLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";&OK;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.PropertyDialogForm;buttonOk.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ImageType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceImageType = ";&Image Type:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.ExportToImage.ExportConfiguration;imageTypeLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";&Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.PropertyDialogForm;buttonCancel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  JPEG
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceJpegImageType = ";JPEG;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.ExportToImage.ExportConfiguration;imageTypeComboBox.Items1";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Bitmap (BMP)
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceBitmapImageType = ";Bitmap (BMP);ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.ExportToImage.ExportConfiguration;imageTypeComboBox.Items";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Portable Network Graphics (PNG)
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePngImageType = ";Portable Network Graphics (PNG);ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.ExportToImage.ExportConfiguration;imageTypeComboBox.Items2";

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
            /// Caches the translated resource string for:  LockAspectRatio
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLockAspectRatio;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Width
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWidth;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Height
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHeight;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DPIX
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDPIX;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DPIY
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDPIY;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  LockResolution
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLockResolution;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  LowQuality
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLowQuality;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Compression
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCompression;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  HighQuality
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHighQuality;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ImageType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedImageType;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  JPEG
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedJpegImageType;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Bitmap (BMP)
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBitmapImageType;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Portable Network Graphics (PNG)
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPngImageType;

            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 9/17/2007 Created
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
            /// Exposes access to the LockAspectRatio translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 9/17/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LockAspectRatio
            {
                get
                {
                    if ((cachedLockAspectRatio == null))
                    {
                        cachedLockAspectRatio = CoreManager.MomConsole.GetIntlStr(ResourceLockAspectRatio);
                    }
                    
                    return cachedLockAspectRatio;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Width translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 9/17/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Width
            {
                get
                {
                    if ((cachedWidth == null))
                    {
                        cachedWidth = CoreManager.MomConsole.GetIntlStr(ResourceWidth);
                    }
                    
                    return cachedWidth;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Height translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 9/17/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Height
            {
                get
                {
                    if ((cachedHeight == null))
                    {
                        cachedHeight = CoreManager.MomConsole.GetIntlStr(ResourceHeight);
                    }
                    
                    return cachedHeight;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DPIX translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 9/17/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DPIX
            {
                get
                {
                    if ((cachedDPIX == null))
                    {
                        cachedDPIX = CoreManager.MomConsole.GetIntlStr(ResourceDPIX);
                    }
                    
                    return cachedDPIX;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DPIY translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 9/17/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DPIY
            {
                get
                {
                    if ((cachedDPIY == null))
                    {
                        cachedDPIY = CoreManager.MomConsole.GetIntlStr(ResourceDPIY);
                    }
                    
                    return cachedDPIY;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the LockResolution translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 9/17/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LockResolution
            {
                get
                {
                    if ((cachedLockResolution == null))
                    {
                        cachedLockResolution = CoreManager.MomConsole.GetIntlStr(ResourceLockResolution);
                    }
                    
                    return cachedLockResolution;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the LowQuality translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 9/17/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LowQuality
            {
                get
                {
                    if ((cachedLowQuality == null))
                    {
                        cachedLowQuality = CoreManager.MomConsole.GetIntlStr(ResourceLowQuality);
                    }
                    
                    return cachedLowQuality;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Compression translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 9/17/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Compression
            {
                get
                {
                    if ((cachedCompression == null))
                    {
                        cachedCompression = CoreManager.MomConsole.GetIntlStr(ResourceCompression);
                    }
                    
                    return cachedCompression;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the HighQuality translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 9/17/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string HighQuality
            {
                get
                {
                    if ((cachedHighQuality == null))
                    {
                        cachedHighQuality = CoreManager.MomConsole.GetIntlStr(ResourceHighQuality);
                    }
                    
                    return cachedHighQuality;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 9/17/2007 Created
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
            /// Exposes access to the ImageType translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 9/17/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ImageType
            {
                get
                {
                    if ((cachedImageType == null))
                    {
                        cachedImageType = CoreManager.MomConsole.GetIntlStr(ResourceImageType);
                    }
                    
                    return cachedImageType;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 9/17/2007 Created
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
            /// Exposes access to the JPEG translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 9/17/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string JpegImageType
            {
                get
                {
                    if ((cachedJpegImageType == null))
                    {
                        cachedJpegImageType = CoreManager.MomConsole.GetIntlStr(ResourceJpegImageType);
                    }

                    return cachedJpegImageType;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Bitmap (BMP) translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 9/17/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string BitmapImageType
            {
                get
                {
                    if ((cachedBitmapImageType == null))
                    {
                        cachedBitmapImageType = CoreManager.MomConsole.GetIntlStr(ResourceBitmapImageType);
                    }

                    return cachedBitmapImageType;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Portable Network Graphics (PNG) translated resource 
            /// string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 9/17/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string PngImageType
            {
                get
                {
                    if ((cachedPngImageType == null))
                    {
                        cachedPngImageType = CoreManager.MomConsole.GetIntlStr(ResourcePngImageType);
                    }

                    return cachedPngImageType;
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
        /// 	[KellyMor] 9/17/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for LockAspectRatioCheckBox
            /// </summary>
            public const string LockAspectRatioCheckBox = "lockAspectCheckBox";
            
            /// <summary>
            /// Control ID for WidthTextBox
            /// </summary>
            public const string WidthTextBox = "widthTextBox";
            
            /// <summary>
            /// Control ID for WidthStaticControl
            /// </summary>
            public const string WidthStaticControl = "widthLabel";
            
            /// <summary>
            /// Control ID for HeightTextBox
            /// </summary>
            public const string HeightTextBox = "heightTextBox";
            
            /// <summary>
            /// Control ID for HeightStaticControl
            /// </summary>
            public const string HeightStaticControl = "heightLabel";
            
            /// <summary>
            /// Control ID for DPIXTextBox
            /// </summary>
            public const string DPIXTextBox = "dpiXTextBox";
            
            /// <summary>
            /// Control ID for DPIXStaticControl
            /// </summary>
            public const string DPIXStaticControl = "dpiXLabel";
            
            /// <summary>
            /// Control ID for DPIYStaticControl
            /// </summary>
            public const string DPIYStaticControl = "dpiYLabel";
            
            /// <summary>
            /// Control ID for LockResolutionCheckBox
            /// </summary>
            public const string LockResolutionCheckBox = "lockDpiCheckBox";
            
            /// <summary>
            /// Control ID for DPIYTextBox
            /// </summary>
            public const string DPIYTextBox = "dpiYTextBox";
            
            /// <summary>
            /// Control ID for LowQualityTextBox
            /// </summary>
            public const string LowQualityTextBox = "compressionTextBox";
            
            /// <summary>
            /// Control ID for LowQualityStaticControl
            /// </summary>
            public const string LowQualityStaticControl = "lowQualityLabel";
            
            /// <summary>
            /// Control ID for CompressionSlider
            /// </summary>
            public const string CompressionSlider = "compressionTrackBar";
            
            /// <summary>
            /// Control ID for CompressionStaticControl
            /// </summary>
            public const string CompressionStaticControl = "compressionLabel";
            
            /// <summary>
            /// Control ID for HighQualityStaticControl
            /// </summary>
            public const string HighQualityStaticControl = "highQualityLabel";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for ImageTypeStaticControl
            /// </summary>
            public const string ImageTypeStaticControl = "imageTypeLabel";
            
            /// <summary>
            /// Control ID for ImageTypeComboBox
            /// </summary>
            public const string ImageTypeComboBox = "imageTypeComboBox";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
        }
        #endregion
    }
}
