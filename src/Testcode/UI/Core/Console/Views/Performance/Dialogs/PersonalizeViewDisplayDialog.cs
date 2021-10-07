// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="PersonalizeViewDisplayDialog.cs">
// 	Copyright (c) Microsoft Corporation 2007
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[mbickle] 5/31/2007 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.Performance.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console;

    
    #region Radio Group Enumeration - Tab0

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group Tab0
    /// </summary>
    /// <history>
    /// 	[mbickle] 5/31/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum Tab0
    {
        /// <summary>
        /// ManuallySetYAxisLimits = 0
        /// </summary>
        ManuallySetYAxisLimits = 0,
        
        /// <summary>
        /// AutomaticallySetYAxisLimits = 1
        /// </summary>
        AutomaticallySetYAxisLimits = 1,
    }
    #endregion
    
    #region Interface Definition - IPersonalizeViewDisplayDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IPersonalizeViewDisplayDialogControls, for PersonalizeViewDisplayDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[mbickle] 5/31/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IPersonalizeViewDisplayDialogControls
    {
        /// <summary>
        /// Read-only property to access Tab0TabControl
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TabControl Tab0TabControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ManuallySetYAxisLimitsRadioButton
        /// </summary>
        RadioButton ManuallySetYAxisLimitsRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AutomaticallySetYAxisLimitsRadioButton
        /// </summary>
        RadioButton AutomaticallySetYAxisLimitsRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MaximumStaticControl
        /// </summary>
        StaticControl MaximumStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MaximumComboBox
        /// </summary>
        ComboBox MaximumComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MinimumStaticControl
        /// </summary>
        StaticControl MinimumStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MinimumComboBox
        /// </summary>
        ComboBox MinimumComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RightAngleAxesObliqueCheckBox
        /// </summary>
        CheckBox RightAngleAxesObliqueCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access VerticalComboBox
        /// </summary>
        ComboBox VerticalComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ClusterSeriesCheckBox
        /// </summary>
        CheckBox ClusterSeriesCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HorizontalComboBox
        /// </summary>
        ComboBox HorizontalComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DepthComboBox
        /// </summary>
        ComboBox DepthComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access VerticalStaticControl
        /// </summary>
        StaticControl VerticalStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SinceComboBox
        /// </summary>
        ComboBox SinceComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HorizontalStaticControl
        /// </summary>
        StaticControl HorizontalStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AndBeforeComboBox
        /// </summary>
        ComboBox AndBeforeComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RotationStaticControl
        /// </summary>
        StaticControl RotationStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DepthStaticControl
        /// </summary>
        StaticControl DepthStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PerspectiveStaticControl
        /// </summary>
        StaticControl PerspectiveStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access GapDepthStaticControl
        /// </summary>
        StaticControl GapDepthStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Enable3DCheckBox
        /// </summary>
        CheckBox Enable3DCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ChartTypeComboBox
        /// </summary>
        ComboBox ChartTypeComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ChartTypeStaticControl
        /// </summary>
        StaticControl ChartTypeStaticControl
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
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add dialog functionality description here.
    /// </summary>
    /// <history>
    /// 	[mbickle] 5/31/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class PersonalizeViewDisplayDialog : Dialog, IPersonalizeViewDisplayDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to Tab0TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab0TabControl;
        
        /// <summary>
        /// Cache to hold a reference to ManuallySetYAxisLimitsRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedManuallySetYAxisLimitsRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to AutomaticallySetYAxisLimitsRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedAutomaticallySetYAxisLimitsRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to MaximumStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMaximumStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to MaximumComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedMaximumComboBox;
        
        /// <summary>
        /// Cache to hold a reference to MinimumStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMinimumStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to MinimumComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedMinimumComboBox;
        
        /// <summary>
        /// Cache to hold a reference to RightAngleAxesObliqueCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedRightAngleAxesObliqueCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to VerticalComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedVerticalComboBox;
        
        /// <summary>
        /// Cache to hold a reference to ClusterSeriesCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedClusterSeriesCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to HorizontalComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedHorizontalComboBox;
        
        /// <summary>
        /// Cache to hold a reference to DepthComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedDepthComboBox;
        
        /// <summary>
        /// Cache to hold a reference to VerticalStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedVerticalStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SinceComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedSinceComboBox;
        
        /// <summary>
        /// Cache to hold a reference to HorizontalStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHorizontalStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AndBeforeComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedAndBeforeComboBox;
        
        /// <summary>
        /// Cache to hold a reference to RotationStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRotationStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DepthStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDepthStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to PerspectiveStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPerspectiveStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to GapDepthStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGapDepthStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to Enable3DCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedEnable3DCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to ChartTypeComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedChartTypeComboBox;
        
        /// <summary>
        /// Cache to hold a reference to ChartTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedChartTypeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
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
        /// Owner of PersonalizeViewDisplayDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public PersonalizeViewDisplayDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group Tab0
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual Tab0 Tab0
        {
            get
            {
                if ((this.Controls.ManuallySetYAxisLimitsRadioButton.ButtonState == ButtonState.Checked))
                {
                    return Tab0.ManuallySetYAxisLimits;
                }
                
                if ((this.Controls.AutomaticallySetYAxisLimitsRadioButton.ButtonState == ButtonState.Checked))
                {
                    return Tab0.AutomaticallySetYAxisLimits;
                }
                
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == Tab0.ManuallySetYAxisLimits))
                {
                    this.Controls.ManuallySetYAxisLimitsRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == Tab0.AutomaticallySetYAxisLimits))
                    {
                        this.Controls.AutomaticallySetYAxisLimitsRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region IPersonalizeViewDisplayDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IPersonalizeViewDisplayDialogControls Controls
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
        ///  Property to handle checkbox RightAngleAxesOblique
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool RightAngleAxesOblique
        {
            get
            {
                return this.Controls.RightAngleAxesObliqueCheckBox.Checked;
            }
            
            set
            {
                this.Controls.RightAngleAxesObliqueCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox ClusterSeries
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool ClusterSeries
        {
            get
            {
                return this.Controls.ClusterSeriesCheckBox.Checked;
            }
            
            set
            {
                this.Controls.ClusterSeriesCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox Enable3D
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool Enable3D
        {
            get
            {
                return this.Controls.Enable3DCheckBox.Checked;
            }
            
            set
            {
                this.Controls.Enable3DCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Maximum
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string MaximumText
        {
            get
            {
                return this.Controls.MaximumComboBox.Text;
            }
            
            set
            {
                this.Controls.MaximumComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Minimum
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string MinimumText
        {
            get
            {
                return this.Controls.MinimumComboBox.Text;
            }
            
            set
            {
                this.Controls.MinimumComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Vertical
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string VerticalText
        {
            get
            {
                return this.Controls.VerticalComboBox.Text;
            }
            
            set
            {
                this.Controls.VerticalComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Horizontal
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string HorizontalText
        {
            get
            {
                return this.Controls.HorizontalComboBox.Text;
            }
            
            set
            {
                this.Controls.HorizontalComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Depth
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DepthText
        {
            get
            {
                return this.Controls.DepthComboBox.Text;
            }
            
            set
            {
                this.Controls.DepthComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Since
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SinceText
        {
            get
            {
                return this.Controls.SinceComboBox.Text;
            }
            
            set
            {
                this.Controls.SinceComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control AndBefore
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string AndBeforeText
        {
            get
            {
                return this.Controls.AndBeforeComboBox.Text;
            }
            
            set
            {
                this.Controls.AndBeforeComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ChartType
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ChartTypeText
        {
            get
            {
                return this.Controls.ChartTypeComboBox.Text;
            }
            
            set
            {
                this.Controls.ChartTypeComboBox.SelectByText(value, true);
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab0TabControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IPersonalizeViewDisplayDialogControls.Tab0TabControl
        {
            get
            {
                if ((this.cachedTab0TabControl == null))
                {
                    this.cachedTab0TabControl = new TabControl(this, PersonalizeViewDisplayDialog.ControlIDs.Tab0TabControl);
                }
                
                return this.cachedTab0TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManuallySetYAxisLimitsRadioButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IPersonalizeViewDisplayDialogControls.ManuallySetYAxisLimitsRadioButton
        {
            get
            {
                if ((this.cachedManuallySetYAxisLimitsRadioButton == null))
                {
                    this.cachedManuallySetYAxisLimitsRadioButton = new RadioButton(this, PersonalizeViewDisplayDialog.ControlIDs.ManuallySetYAxisLimitsRadioButton);
                }
                
                return this.cachedManuallySetYAxisLimitsRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AutomaticallySetYAxisLimitsRadioButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IPersonalizeViewDisplayDialogControls.AutomaticallySetYAxisLimitsRadioButton
        {
            get
            {
                if ((this.cachedAutomaticallySetYAxisLimitsRadioButton == null))
                {
                    this.cachedAutomaticallySetYAxisLimitsRadioButton = new RadioButton(this, PersonalizeViewDisplayDialog.ControlIDs.AutomaticallySetYAxisLimitsRadioButton);
                }
                
                return this.cachedAutomaticallySetYAxisLimitsRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MaximumStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPersonalizeViewDisplayDialogControls.MaximumStaticControl
        {
            get
            {
                if ((this.cachedMaximumStaticControl == null))
                {
                    this.cachedMaximumStaticControl = new StaticControl(this, PersonalizeViewDisplayDialog.ControlIDs.MaximumStaticControl);
                }
                
                return this.cachedMaximumStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MaximumComboBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IPersonalizeViewDisplayDialogControls.MaximumComboBox
        {
            get
            {
                if ((this.cachedMaximumComboBox == null))
                {
                    this.cachedMaximumComboBox = new ComboBox(this, PersonalizeViewDisplayDialog.ControlIDs.MaximumComboBox);
                }
                
                return this.cachedMaximumComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MinimumStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPersonalizeViewDisplayDialogControls.MinimumStaticControl
        {
            get
            {
                if ((this.cachedMinimumStaticControl == null))
                {
                    this.cachedMinimumStaticControl = new StaticControl(this, PersonalizeViewDisplayDialog.ControlIDs.MinimumStaticControl);
                }
                
                return this.cachedMinimumStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MinimumComboBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IPersonalizeViewDisplayDialogControls.MinimumComboBox
        {
            get
            {
                if ((this.cachedMinimumComboBox == null))
                {
                    this.cachedMinimumComboBox = new ComboBox(this, PersonalizeViewDisplayDialog.ControlIDs.MinimumComboBox);
                }
                
                return this.cachedMinimumComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RightAngleAxesObliqueCheckBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IPersonalizeViewDisplayDialogControls.RightAngleAxesObliqueCheckBox
        {
            get
            {
                if ((this.cachedRightAngleAxesObliqueCheckBox == null))
                {
                    this.cachedRightAngleAxesObliqueCheckBox = new CheckBox(this, PersonalizeViewDisplayDialog.ControlIDs.RightAngleAxesObliqueCheckBox);
                }
                
                return this.cachedRightAngleAxesObliqueCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the VerticalComboBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IPersonalizeViewDisplayDialogControls.VerticalComboBox
        {
            get
            {
                if ((this.cachedVerticalComboBox == null))
                {
                    this.cachedVerticalComboBox = new ComboBox(this, PersonalizeViewDisplayDialog.ControlIDs.VerticalComboBox);
                }
                
                return this.cachedVerticalComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ClusterSeriesCheckBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IPersonalizeViewDisplayDialogControls.ClusterSeriesCheckBox
        {
            get
            {
                if ((this.cachedClusterSeriesCheckBox == null))
                {
                    this.cachedClusterSeriesCheckBox = new CheckBox(this, PersonalizeViewDisplayDialog.ControlIDs.ClusterSeriesCheckBox);
                }
                
                return this.cachedClusterSeriesCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HorizontalComboBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IPersonalizeViewDisplayDialogControls.HorizontalComboBox
        {
            get
            {
                if ((this.cachedHorizontalComboBox == null))
                {
                    this.cachedHorizontalComboBox = new ComboBox(this, PersonalizeViewDisplayDialog.ControlIDs.HorizontalComboBox);
                }
                
                return this.cachedHorizontalComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DepthComboBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IPersonalizeViewDisplayDialogControls.DepthComboBox
        {
            get
            {
                if ((this.cachedDepthComboBox == null))
                {
                    this.cachedDepthComboBox = new ComboBox(this, PersonalizeViewDisplayDialog.ControlIDs.DepthComboBox);
                }
                
                return this.cachedDepthComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the VerticalStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPersonalizeViewDisplayDialogControls.VerticalStaticControl
        {
            get
            {
                if ((this.cachedVerticalStaticControl == null))
                {
                    this.cachedVerticalStaticControl = new StaticControl(this, PersonalizeViewDisplayDialog.ControlIDs.VerticalStaticControl);
                }
                
                return this.cachedVerticalStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SinceComboBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IPersonalizeViewDisplayDialogControls.SinceComboBox
        {
            get
            {
                if ((this.cachedSinceComboBox == null))
                {
                    this.cachedSinceComboBox = new ComboBox(this, PersonalizeViewDisplayDialog.ControlIDs.SinceComboBox);
                }
                
                return this.cachedSinceComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HorizontalStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPersonalizeViewDisplayDialogControls.HorizontalStaticControl
        {
            get
            {
                if ((this.cachedHorizontalStaticControl == null))
                {
                    this.cachedHorizontalStaticControl = new StaticControl(this, PersonalizeViewDisplayDialog.ControlIDs.HorizontalStaticControl);
                }
                
                return this.cachedHorizontalStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AndBeforeComboBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IPersonalizeViewDisplayDialogControls.AndBeforeComboBox
        {
            get
            {
                if ((this.cachedAndBeforeComboBox == null))
                {
                    this.cachedAndBeforeComboBox = new ComboBox(this, PersonalizeViewDisplayDialog.ControlIDs.AndBeforeComboBox);
                }
                
                return this.cachedAndBeforeComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RotationStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPersonalizeViewDisplayDialogControls.RotationStaticControl
        {
            get
            {
                if ((this.cachedRotationStaticControl == null))
                {
                    this.cachedRotationStaticControl = new StaticControl(this, PersonalizeViewDisplayDialog.ControlIDs.RotationStaticControl);
                }
                
                return this.cachedRotationStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DepthStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPersonalizeViewDisplayDialogControls.DepthStaticControl
        {
            get
            {
                if ((this.cachedDepthStaticControl == null))
                {
                    this.cachedDepthStaticControl = new StaticControl(this, PersonalizeViewDisplayDialog.ControlIDs.DepthStaticControl);
                }
                
                return this.cachedDepthStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PerspectiveStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPersonalizeViewDisplayDialogControls.PerspectiveStaticControl
        {
            get
            {
                if ((this.cachedPerspectiveStaticControl == null))
                {
                    this.cachedPerspectiveStaticControl = new StaticControl(this, PersonalizeViewDisplayDialog.ControlIDs.PerspectiveStaticControl);
                }
                
                return this.cachedPerspectiveStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GapDepthStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPersonalizeViewDisplayDialogControls.GapDepthStaticControl
        {
            get
            {
                if ((this.cachedGapDepthStaticControl == null))
                {
                    this.cachedGapDepthStaticControl = new StaticControl(this, PersonalizeViewDisplayDialog.ControlIDs.GapDepthStaticControl);
                }
                
                return this.cachedGapDepthStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Enable3DCheckBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IPersonalizeViewDisplayDialogControls.Enable3DCheckBox
        {
            get
            {
                if ((this.cachedEnable3DCheckBox == null))
                {
                    this.cachedEnable3DCheckBox = new CheckBox(this, PersonalizeViewDisplayDialog.ControlIDs.Enable3DCheckBox);
                }
                
                return this.cachedEnable3DCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ChartTypeComboBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IPersonalizeViewDisplayDialogControls.ChartTypeComboBox
        {
            get
            {
                if ((this.cachedChartTypeComboBox == null))
                {
                    this.cachedChartTypeComboBox = new ComboBox(this, PersonalizeViewDisplayDialog.ControlIDs.ChartTypeComboBox);
                }
                
                return this.cachedChartTypeComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ChartTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPersonalizeViewDisplayDialogControls.ChartTypeStaticControl
        {
            get
            {
                if ((this.cachedChartTypeStaticControl == null))
                {
                    this.cachedChartTypeStaticControl = new StaticControl(this, PersonalizeViewDisplayDialog.ControlIDs.ChartTypeStaticControl);
                }
                
                return this.cachedChartTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPersonalizeViewDisplayDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, PersonalizeViewDisplayDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPersonalizeViewDisplayDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, PersonalizeViewDisplayDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button RightAngleAxesOblique
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickRightAngleAxesOblique()
        {
            this.Controls.RightAngleAxesObliqueCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ClusterSeries
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickClusterSeries()
        {
            this.Controls.ClusterSeriesCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Enable3D
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEnable3D()
        {
            this.Controls.Enable3DCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
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
        /// 	[mbickle] 5/31/2007 Created
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
        ///  <param name="app">MomConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
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
            catch (Exceptions.WindowNotFoundException ex)
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
                        Utilities.LogMessage("Attempt " + numberOfTries + " of " + MaxTries);

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure

                    // throw the existing WindowNotFound exception
                    throw ex;
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
        /// 	[mbickle] 5/31/2007 Created
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
            private const string ResourceDialogTitle = ";Personalize View;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.PerformanceViewPropertiesDialog;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Tab0
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTab0 = "Tab0";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ManuallySetYAxisLimits
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceManuallySetYAxisLimits = ";Manually set Y-Axis limits;ManagedString;Microsoft.MOM.UI.Components.dll;Microso" +
                "ft.EnterpriseManagement.Mom.UI.PerformanceViewPropertiesDialog;manualLimitRadioB" +
                "utton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AutomaticallySetYAxisLimits
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAutomaticallySetYAxisLimits = ";Automatically set Y-Axis limits;ManagedString;Microsoft.MOM.UI.Components.dll;Mi" +
                "crosoft.EnterpriseManagement.Mom.UI.PerformanceViewPropertiesDialog;automaticLim" +
                "itRadioButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Maximum
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMaximum = ";Maximum;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.UI.PerformanceViewPropertiesDialog;yMaxLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Minimum
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMinimum = ";Minimum;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.UI.PerformanceViewPropertiesDialog;yMinLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RightAngleAxesOblique
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRightAngleAxesOblique = ";Right-angle axes (oblique);ManagedString;Microsoft.MOM.UI.Components.dll;Microso" +
                "ft.EnterpriseManagement.Mom.UI.PerformanceViewPropertiesDialog;rightAngleAxesChe" +
                "ckBox.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ClusterSeries
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceClusterSeries = ";Cluster series;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpris" +
                "eManagement.Mom.UI.PerformanceViewPropertiesDialog;clusterSeriesCheckBox.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Vertical
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceVertical = ";Vertical;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManag" +
                "ement.Mom.UI.PerformanceViewPropertiesDialog;vRotationLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Horizontal
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHorizontal = ";Horizontal;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMan" +
                "agement.Mom.UI.PerformanceViewPropertiesDialog;hRotationLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Rotation
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRotation = ";Rotation:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMana" +
                "gement.Mom.UI.PerformanceViewPropertiesDialog;rotationLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Depth
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDepth = ";Depth;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManageme" +
                "nt.Mom.UI.PerformanceViewPropertiesDialog;depthLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Perspective
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePerspective = ";Perspective;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.SourceCo" +
                "de.Commands.Strings;Modify3DPerspectiveGroup.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  GapDepth
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGapDepth = ";Gap depth;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMana" +
                "gement.Mom.UI.PerformanceViewPropertiesDialog;gapDepthLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Enable3D
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEnable3D = ";Enable 3D;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMana" +
                "gement.Mom.UI.PerformanceViewPropertiesDialog;enable3DCheckBox.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ChartType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceChartType = ";Chart type:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMa" +
                "nagement.Mom.UI.PerformanceViewPropertiesDialog;chartTypeLabel.Text";
            
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
            /// Caches the translated resource string for:  Tab0
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab0;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ManuallySetYAxisLimits
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedManuallySetYAxisLimits;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AutomaticallySetYAxisLimits
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAutomaticallySetYAxisLimits;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Maximum
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMaximum;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Minimum
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMinimum;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RightAngleAxesOblique
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRightAngleAxesOblique;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ClusterSeries
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedClusterSeries;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Vertical
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedVertical;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Horizontal
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHorizontal;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Rotation
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRotation;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Depth
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDepth;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Perspective
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPerspective;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  GapDepth
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGapDepth;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Enable3D
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEnable3D;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ChartType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedChartType;
            
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
            /// 	[mbickle] 5/31/2007 Created
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
            /// Exposes access to the Tab0 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tab0
            {
                get
                {
                    if ((cachedTab0 == null))
                    {
                        cachedTab0 = CoreManager.MomConsole.GetIntlStr(ResourceTab0);
                    }
                    
                    return cachedTab0;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ManuallySetYAxisLimits translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ManuallySetYAxisLimits
            {
                get
                {
                    if ((cachedManuallySetYAxisLimits == null))
                    {
                        cachedManuallySetYAxisLimits = CoreManager.MomConsole.GetIntlStr(ResourceManuallySetYAxisLimits);
                    }
                    
                    return cachedManuallySetYAxisLimits;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AutomaticallySetYAxisLimits translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AutomaticallySetYAxisLimits
            {
                get
                {
                    if ((cachedAutomaticallySetYAxisLimits == null))
                    {
                        cachedAutomaticallySetYAxisLimits = CoreManager.MomConsole.GetIntlStr(ResourceAutomaticallySetYAxisLimits);
                    }
                    
                    return cachedAutomaticallySetYAxisLimits;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Maximum translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Maximum
            {
                get
                {
                    if ((cachedMaximum == null))
                    {
                        cachedMaximum = CoreManager.MomConsole.GetIntlStr(ResourceMaximum);
                    }
                    
                    return cachedMaximum;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Minimum translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Minimum
            {
                get
                {
                    if ((cachedMinimum == null))
                    {
                        cachedMinimum = CoreManager.MomConsole.GetIntlStr(ResourceMinimum);
                    }
                    
                    return cachedMinimum;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RightAngleAxesOblique translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RightAngleAxesOblique
            {
                get
                {
                    if ((cachedRightAngleAxesOblique == null))
                    {
                        cachedRightAngleAxesOblique = CoreManager.MomConsole.GetIntlStr(ResourceRightAngleAxesOblique);
                    }
                    
                    return cachedRightAngleAxesOblique;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ClusterSeries translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ClusterSeries
            {
                get
                {
                    if ((cachedClusterSeries == null))
                    {
                        cachedClusterSeries = CoreManager.MomConsole.GetIntlStr(ResourceClusterSeries);
                    }
                    
                    return cachedClusterSeries;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Vertical translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Vertical
            {
                get
                {
                    if ((cachedVertical == null))
                    {
                        cachedVertical = CoreManager.MomConsole.GetIntlStr(ResourceVertical);
                    }
                    
                    return cachedVertical;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Horizontal translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Horizontal
            {
                get
                {
                    if ((cachedHorizontal == null))
                    {
                        cachedHorizontal = CoreManager.MomConsole.GetIntlStr(ResourceHorizontal);
                    }
                    
                    return cachedHorizontal;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Rotation translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Rotation
            {
                get
                {
                    if ((cachedRotation == null))
                    {
                        cachedRotation = CoreManager.MomConsole.GetIntlStr(ResourceRotation);
                    }
                    
                    return cachedRotation;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Depth translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Depth
            {
                get
                {
                    if ((cachedDepth == null))
                    {
                        cachedDepth = CoreManager.MomConsole.GetIntlStr(ResourceDepth);
                    }
                    
                    return cachedDepth;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Perspective translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Perspective
            {
                get
                {
                    if ((cachedPerspective == null))
                    {
                        cachedPerspective = CoreManager.MomConsole.GetIntlStr(ResourcePerspective);
                    }
                    
                    return cachedPerspective;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the GapDepth translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string GapDepth
            {
                get
                {
                    if ((cachedGapDepth == null))
                    {
                        cachedGapDepth = CoreManager.MomConsole.GetIntlStr(ResourceGapDepth);
                    }
                    
                    return cachedGapDepth;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Enable3D translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Enable3D
            {
                get
                {
                    if ((cachedEnable3D == null))
                    {
                        cachedEnable3D = CoreManager.MomConsole.GetIntlStr(ResourceEnable3D);
                    }
                    
                    return cachedEnable3D;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ChartType translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ChartType
            {
                get
                {
                    if ((cachedChartType == null))
                    {
                        cachedChartType = CoreManager.MomConsole.GetIntlStr(ResourceChartType);
                    }
                    
                    return cachedChartType;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
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
            /// 	[mbickle] 5/31/2007 Created
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
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for Tab0TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab0TabControl = "mainTabControl";
            
            /// <summary>
            /// Control ID for ManuallySetYAxisLimitsRadioButton
            /// </summary>
            public const string ManuallySetYAxisLimitsRadioButton = "manualLimitRadioButton";
            
            /// <summary>
            /// Control ID for AutomaticallySetYAxisLimitsRadioButton
            /// </summary>
            public const string AutomaticallySetYAxisLimitsRadioButton = "automaticLimitRadioButton";
            
            /// <summary>
            /// Control ID for MaximumStaticControl
            /// </summary>
            public const string MaximumStaticControl = "yMaxLabel";
            
            /// <summary>
            /// Control ID for MaximumComboBox
            /// </summary>
            public const string MaximumComboBox = "yMaximumSpinner";
            
            /// <summary>
            /// Control ID for MinimumStaticControl
            /// </summary>
            public const string MinimumStaticControl = "yMinLabel";
            
            /// <summary>
            /// Control ID for MinimumComboBox
            /// </summary>
            public const string MinimumComboBox = "yMinimumSpinner";
            
            /// <summary>
            /// Control ID for RightAngleAxesObliqueCheckBox
            /// </summary>
            public const string RightAngleAxesObliqueCheckBox = "rightAngleAxesCheckBox";
            
            /// <summary>
            /// Control ID for VerticalComboBox
            /// </summary>
            public const string VerticalComboBox = "vRotationSpinner";
            
            /// <summary>
            /// Control ID for ClusterSeriesCheckBox
            /// </summary>
            public const string ClusterSeriesCheckBox = "clusterSeriesCheckBox";
            
            /// <summary>
            /// Control ID for HorizontalComboBox
            /// </summary>
            public const string HorizontalComboBox = "hRotationSpinner";
            
            /// <summary>
            /// Control ID for DepthComboBox
            /// </summary>
            public const string DepthComboBox = "depthSpinner";
            
            /// <summary>
            /// Control ID for VerticalStaticControl
            /// </summary>
            public const string VerticalStaticControl = "vRotationLabel";
            
            /// <summary>
            /// Control ID for SinceComboBox
            /// </summary>
            public const string SinceComboBox = "gapDepthSpinner";
            
            /// <summary>
            /// Control ID for HorizontalStaticControl
            /// </summary>
            public const string HorizontalStaticControl = "hRotationLabel";
            
            /// <summary>
            /// Control ID for AndBeforeComboBox
            /// </summary>
            public const string AndBeforeComboBox = "perspectiveSpinner";
            
            /// <summary>
            /// Control ID for RotationStaticControl
            /// </summary>
            public const string RotationStaticControl = "rotationLabel";
            
            /// <summary>
            /// Control ID for DepthStaticControl
            /// </summary>
            public const string DepthStaticControl = "depthLabel";
            
            /// <summary>
            /// Control ID for PerspectiveStaticControl
            /// </summary>
            public const string PerspectiveStaticControl = "perspectiveLabel";
            
            /// <summary>
            /// Control ID for GapDepthStaticControl
            /// </summary>
            public const string GapDepthStaticControl = "gapDepthLabel";
            
            /// <summary>
            /// Control ID for Enable3DCheckBox
            /// </summary>
            public const string Enable3DCheckBox = "enable3DCheckBox";
            
            /// <summary>
            /// Control ID for ChartTypeComboBox
            /// </summary>
            public const string ChartTypeComboBox = "chartTypeCombo";
            
            /// <summary>
            /// Control ID for ChartTypeStaticControl
            /// </summary>
            public const string ChartTypeStaticControl = "chartTypeLabel";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
        }
        #endregion
    }
}
