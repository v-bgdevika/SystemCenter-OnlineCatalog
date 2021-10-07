// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="PerformanceMapperDialog.cs">
// 	Copyright (c) Microsoft Corporation 2007
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	Performance Mapper dialog is used in script, wmi performance ruls
// </summary>
// <history>
// 	[barryli] 20JUN07 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Performance.Dialogs
{
    #region Using directives
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    #endregion

    
    #region Interface Definition - IPerformanceMapperDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IPerformanceMapperDialogControls, for PerformanceMapperDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[barryli] 20JUN07 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IPerformanceMapperDialogControls
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
        /// Read-only property to access CreateButton
        /// </summary>
        Button CreateButton
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
        /// Read-only property to access RuleTypeStaticControl
        /// </summary>
        StaticControl RuleTypeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access GeneralStaticControl
        /// </summary>
        StaticControl GeneralStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WMIConfigurationStaticControl
        /// </summary>
        StaticControl WMIConfigurationStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PerformanceMapperStaticControl
        /// </summary>
        StaticControl PerformanceMapperStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Ellipsis0Button
        /// </summary>
        Button Ellipsis0Button
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Ellipsis1Button
        /// </summary>
        Button Ellipsis1Button
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Ellipsis2Button
        /// </summary>
        Button Ellipsis2Button
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Ellipsis3Button
        /// </summary>
        Button Ellipsis3Button
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ValueTextBox
        /// </summary>
        TextBox ValueTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access InstanceTextBox
        /// </summary>
        TextBox InstanceTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CounterTextBox
        /// </summary>
        TextBox CounterTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ObjectTextBox
        /// </summary>
        TextBox ObjectTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ValueStaticControl
        /// </summary>
        StaticControl ValueStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access InstanceStaticControl
        /// </summary>
        StaticControl InstanceStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CounterStaticControl
        /// </summary>
        StaticControl CounterStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ObjectStaticControl
        /// </summary>
        StaticControl ObjectStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EnterPerformanceMappingInformationStaticControl
        /// </summary>
        StaticControl EnterPerformanceMappingInformationStaticControl
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
        /// Read-only property to access PerformanceMapperStaticControl2
        /// </summary>
        StaticControl PerformanceMapperStaticControl2
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
    /// 	[barryli] 20JUN07 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class PerformanceMapperDialog : Dialog, IPerformanceMapperDialogControls
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
        /// Cache to hold a reference to CreateButton of type Button
        /// </summary>
        private Button cachedCreateButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to RuleTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRuleTypeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to GeneralStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to WMIConfigurationStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWMIConfigurationStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to PerformanceMapperStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPerformanceMapperStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to Ellipsis0Button of type Button
        /// </summary>
        private Button cachedEllipsis0Button;
        
        /// <summary>
        /// Cache to hold a reference to Ellipsis1Button of type Button
        /// </summary>
        private Button cachedEllipsis1Button;
        
        /// <summary>
        /// Cache to hold a reference to Ellipsis2Button of type Button
        /// </summary>
        private Button cachedEllipsis2Button;
        
        /// <summary>
        /// Cache to hold a reference to Ellipsis3Button of type Button
        /// </summary>
        private Button cachedEllipsis3Button;
        
        /// <summary>
        /// Cache to hold a reference to ValueTextBox of type TextBox
        /// </summary>
        private TextBox cachedValueTextBox;
        
        /// <summary>
        /// Cache to hold a reference to InstanceTextBox of type TextBox
        /// </summary>
        private TextBox cachedInstanceTextBox;
        
        /// <summary>
        /// Cache to hold a reference to CounterTextBox of type TextBox
        /// </summary>
        private TextBox cachedCounterTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ObjectTextBox of type TextBox
        /// </summary>
        private TextBox cachedObjectTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ValueStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedValueStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to InstanceStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedInstanceStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CounterStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCounterStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ObjectStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedObjectStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to EnterPerformanceMappingInformationStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEnterPerformanceMappingInformationStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to PerformanceMapperStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedPerformanceMapperStaticControl2;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of PerformanceMapperDialog of type PerformanceMapperDialog
        /// </param>
        /// <param name='windowCaption'>windows caption</param>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public PerformanceMapperDialog(MomConsoleApp app, MonitoringConfiguration.WindowCaptions windowCaption)
            :
                base(app, Init(app, windowCaption))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
        }
        #endregion
        
        #region IPerformanceMapperDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IPerformanceMapperDialogControls Controls
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
        ///  Routine to set/get the text in control Value
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ValueText
        {
            get
            {
                return this.Controls.ValueTextBox.Text;
            }
            
            set
            {
                this.Controls.ValueTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Instance
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string InstanceText
        {
            get
            {
                return this.Controls.InstanceTextBox.Text;
            }
            
            set
            {
                this.Controls.InstanceTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Counter
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string CounterText
        {
            get
            {
                return this.Controls.CounterTextBox.Text;
            }
            
            set
            {
                this.Controls.CounterTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Object
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ObjectText
        {
            get
            {
                return this.Controls.ObjectTextBox.Text;
            }
            
            set
            {
                this.Controls.ObjectTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceMapperDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, PerformanceMapperDialog.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceMapperDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, PerformanceMapperDialog.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceMapperDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, PerformanceMapperDialog.ControlIDs.CreateButton);
                }
                
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceMapperDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, PerformanceMapperDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RuleTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceMapperDialogControls.RuleTypeStaticControl
        {
            get
            {
                if ((this.cachedRuleTypeStaticControl == null))
                {
                    this.cachedRuleTypeStaticControl = new StaticControl(this, PerformanceMapperDialog.ControlIDs.RuleTypeStaticControl);
                }
                
                return this.cachedRuleTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceMapperDialogControls.GeneralStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedGeneralStaticControl == null))
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
                    this.cachedGeneralStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedGeneralStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WMIConfigurationStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceMapperDialogControls.WMIConfigurationStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedWMIConfigurationStaticControl == null))
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
                    this.cachedWMIConfigurationStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedWMIConfigurationStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PerformanceMapperStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceMapperDialogControls.PerformanceMapperStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedPerformanceMapperStaticControl == null))
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
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedPerformanceMapperStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedPerformanceMapperStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Ellipsis0Button control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceMapperDialogControls.Ellipsis0Button
        {
            get
            {
                if ((this.cachedEllipsis0Button == null))
                {
                    this.cachedEllipsis0Button = new Button(this, PerformanceMapperDialog.ControlIDs.Ellipsis0Button);
                }
                
                return this.cachedEllipsis0Button;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Ellipsis1Button control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceMapperDialogControls.Ellipsis1Button
        {
            get
            {
                if ((this.cachedEllipsis1Button == null))
                {
                    this.cachedEllipsis1Button = new Button(this, PerformanceMapperDialog.ControlIDs.Ellipsis1Button);
                }
                
                return this.cachedEllipsis1Button;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Ellipsis2Button control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceMapperDialogControls.Ellipsis2Button
        {
            get
            {
                if ((this.cachedEllipsis2Button == null))
                {
                    this.cachedEllipsis2Button = new Button(this, PerformanceMapperDialog.ControlIDs.Ellipsis2Button);
                }
                
                return this.cachedEllipsis2Button;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Ellipsis3Button control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceMapperDialogControls.Ellipsis3Button
        {
            get
            {
                if ((this.cachedEllipsis3Button == null))
                {
                    this.cachedEllipsis3Button = new Button(this, PerformanceMapperDialog.ControlIDs.Ellipsis3Button);
                }
                
                return this.cachedEllipsis3Button;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ValueTextBox control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IPerformanceMapperDialogControls.ValueTextBox
        {
            get
            {
                if ((this.cachedValueTextBox == null))
                {
                    this.cachedValueTextBox = new TextBox(this, PerformanceMapperDialog.ControlIDs.ValueTextBox);
                }
                
                return this.cachedValueTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the InstanceTextBox control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IPerformanceMapperDialogControls.InstanceTextBox
        {
            get
            {
                if ((this.cachedInstanceTextBox == null))
                {
                    this.cachedInstanceTextBox = new TextBox(this, PerformanceMapperDialog.ControlIDs.InstanceTextBox);
                }
                
                return this.cachedInstanceTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CounterTextBox control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IPerformanceMapperDialogControls.CounterTextBox
        {
            get
            {
                if ((this.cachedCounterTextBox == null))
                {
                    this.cachedCounterTextBox = new TextBox(this, PerformanceMapperDialog.ControlIDs.CounterTextBox);
                }
                
                return this.cachedCounterTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ObjectTextBox control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IPerformanceMapperDialogControls.ObjectTextBox
        {
            get
            {
                if ((this.cachedObjectTextBox == null))
                {
                    this.cachedObjectTextBox = new TextBox(this, PerformanceMapperDialog.ControlIDs.ObjectTextBox);
                }
                
                return this.cachedObjectTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ValueStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceMapperDialogControls.ValueStaticControl
        {
            get
            {
                if ((this.cachedValueStaticControl == null))
                {
                    this.cachedValueStaticControl = new StaticControl(this, PerformanceMapperDialog.ControlIDs.ValueStaticControl);
                }
                
                return this.cachedValueStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the InstanceStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceMapperDialogControls.InstanceStaticControl
        {
            get
            {
                if ((this.cachedInstanceStaticControl == null))
                {
                    this.cachedInstanceStaticControl = new StaticControl(this, PerformanceMapperDialog.ControlIDs.InstanceStaticControl);
                }
                
                return this.cachedInstanceStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CounterStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceMapperDialogControls.CounterStaticControl
        {
            get
            {
                if ((this.cachedCounterStaticControl == null))
                {
                    this.cachedCounterStaticControl = new StaticControl(this, PerformanceMapperDialog.ControlIDs.CounterStaticControl);
                }
                
                return this.cachedCounterStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ObjectStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceMapperDialogControls.ObjectStaticControl
        {
            get
            {
                if ((this.cachedObjectStaticControl == null))
                {
                    this.cachedObjectStaticControl = new StaticControl(this, PerformanceMapperDialog.ControlIDs.ObjectStaticControl);
                }
                
                return this.cachedObjectStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EnterPerformanceMappingInformationStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceMapperDialogControls.EnterPerformanceMappingInformationStaticControl
        {
            get
            {
                if ((this.cachedEnterPerformanceMappingInformationStaticControl == null))
                {
                    this.cachedEnterPerformanceMappingInformationStaticControl = new StaticControl(this, PerformanceMapperDialog.ControlIDs.EnterPerformanceMappingInformationStaticControl);
                }
                
                return this.cachedEnterPerformanceMappingInformationStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceMapperDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, PerformanceMapperDialog.ControlIDs.HelpStaticControl);
                }
                
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PerformanceMapperStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceMapperDialogControls.PerformanceMapperStaticControl2
        {
            get
            {
                if ((this.cachedPerformanceMapperStaticControl2 == null))
                {
                    this.cachedPerformanceMapperStaticControl2 = new StaticControl(this, PerformanceMapperDialog.ControlIDs.PerformanceMapperStaticControl2);
                }
                
                return this.cachedPerformanceMapperStaticControl2;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
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
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNext()
        {
            this.Controls.NextButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Create
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCreate()
        {
            this.Controls.CreateButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Ellipsis0
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEllipsis0()
        {
            this.Controls.Ellipsis0Button.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Ellipsis1
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEllipsis1()
        {
            this.Controls.Ellipsis1Button.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Ellipsis2
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEllipsis2()
        {
            this.Controls.Ellipsis2Button.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Ellipsis3
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEllipsis3()
        {
            this.Controls.Ellipsis3Button.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">PerformanceMapperDialog owning the dialog.</param>)
        ///  <param name="windowCaption">window caption</param>)
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app, MonitoringConfiguration.WindowCaptions windowCaption)
        {

            string DialogTitle = MonitoringConfiguration.GetWindowCaption(windowCaption);
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
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
                                DialogTitle + "*", StringMatchSyntax.WildCard);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage(
                            "Attempt " + numberOfTries + " of " + MaxTries);
                    }
                }

                
                // check for success
                if ((null == tempWindow))
                {
                    // log the failure
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find window with title:  '" + DialogTitle + "'");
                    // rethrow the original exception
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
        /// 	[barryli] 20JUN07 Created
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
            private const string ResourceDialogTitle = "Create Rule Wizard";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrevious = ";< &Previous;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll" +
                ";Microsoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel;previousButt" +
                "on.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext = ";&Next >;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Mic" +
                "rosoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel;nextButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Create
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCreate = ";C&reate;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;CreateMP" +
                "Action";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RuleType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRuleType = ";Rule Type;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsof" +
                "t.EnterpriseManagement.Internal.UI.Authoring.Pages.ChooseRuleTypePage;$this.Navi" +
                "gationText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  General
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneral = ";General;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;GeneralP" +
                "ropertyPageTabText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WMIConfiguration
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWMIConfiguration = ";WMI Configuration;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;" +
                "Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.WMIDataSource;$this.T" +
                "abName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  PerformanceMapper
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePerformanceMapper = ";Performance Mapper;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll" +
                ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.MappingValueDialog;$" +
                "this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Ellipsis0
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEllipsis0 = ";...;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.A" +
                "ppearanceProperties;buttonBackColor.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Ellipsis1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEllipsis1 = ";...;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.A" +
                "ppearanceProperties;buttonBackColor.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Ellipsis2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEllipsis2 = ";...;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.A" +
                "ppearanceProperties;buttonBackColor.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Ellipsis3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEllipsis3 = ";...;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.A" +
                "ppearanceProperties;buttonBackColor.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Value
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceValue = ";&Value:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft." +
                "EnterpriseManagement.Internal.UI.Authoring.Pages.MappingValueDialog;lblValue.Tex" +
                "t";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Instance
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceInstance = ";&Instance:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microso" +
                "ft.EnterpriseManagement.Internal.UI.Authoring.Pages.PerformanceMapperPage;lblIns" +
                "tance.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Counter
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCounter = ";&Counter:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsof" +
                "t.EnterpriseManagement.Internal.UI.Authoring.Pages.PerformanceMapperPage;lblCoun" +
                "ter.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Object
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceObject = ";&Object:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft" +
                ".EnterpriseManagement.Internal.UI.Authoring.Pages.PerfCounterBrowser;objectLabel" +
                ".Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EnterPerformanceMappingInformation
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEnterPerformanceMappingInformation = ";Enter performance mapping information;ManagedString;Microsoft.EnterpriseManageme" +
                "nt.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.P" +
                "erformanceMapperPage;pageSectionLabel1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsof" +
                "t.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;HelpSubFold" +
                "erName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  PerformanceMapper2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePerformanceMapper2 = ";Performance Mapper;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll" +
                ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.MappingValueDialog;$" +
                "this.Text";
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
            /// Caches the translated resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPrevious;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNext;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Create
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCreate;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RuleType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRuleType;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  General
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneral;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WMIConfiguration
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWMIConfiguration;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  PerformanceMapper
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPerformanceMapper;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Ellipsis0
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEllipsis0;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Ellipsis1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEllipsis1;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Ellipsis2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEllipsis2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Ellipsis3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEllipsis3;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Value
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedValue;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Instance
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedInstance;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Counter
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCounter;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Object
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedObject;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EnterPerformanceMappingInformation
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEnterPerformanceMappingInformation;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  PerformanceMapper2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPerformanceMapper2;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
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
            /// Exposes access to the Previous translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
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
            /// 	[barryli] 20JUN07 Created
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
            /// Exposes access to the Create translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Create
            {
                get
                {
                    if ((cachedCreate == null))
                    {
                        cachedCreate = CoreManager.MomConsole.GetIntlStr(ResourceCreate);
                    }
                    
                    return cachedCreate;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
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
            /// Exposes access to the RuleType translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RuleType
            {
                get
                {
                    if ((cachedRuleType == null))
                    {
                        cachedRuleType = CoreManager.MomConsole.GetIntlStr(ResourceRuleType);
                    }
                    
                    return cachedRuleType;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the General translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string General
            {
                get
                {
                    if ((cachedGeneral == null))
                    {
                        cachedGeneral = CoreManager.MomConsole.GetIntlStr(ResourceGeneral);
                    }
                    
                    return cachedGeneral;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WMIConfiguration translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WMIConfiguration
            {
                get
                {
                    if ((cachedWMIConfiguration == null))
                    {
                        cachedWMIConfiguration = CoreManager.MomConsole.GetIntlStr(ResourceWMIConfiguration);
                    }
                    
                    return cachedWMIConfiguration;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the PerformanceMapper translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string PerformanceMapper
            {
                get
                {
                    if ((cachedPerformanceMapper == null))
                    {
                        cachedPerformanceMapper = CoreManager.MomConsole.GetIntlStr(ResourcePerformanceMapper);
                    }
                    
                    return cachedPerformanceMapper;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Ellipsis0 translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Ellipsis0
            {
                get
                {
                    if ((cachedEllipsis0 == null))
                    {
                        cachedEllipsis0 = CoreManager.MomConsole.GetIntlStr(ResourceEllipsis0);
                    }
                    
                    return cachedEllipsis0;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Ellipsis1 translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Ellipsis1
            {
                get
                {
                    if ((cachedEllipsis1 == null))
                    {
                        cachedEllipsis1 = CoreManager.MomConsole.GetIntlStr(ResourceEllipsis1);
                    }
                    
                    return cachedEllipsis1;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Ellipsis2 translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Ellipsis2
            {
                get
                {
                    if ((cachedEllipsis2 == null))
                    {
                        cachedEllipsis2 = CoreManager.MomConsole.GetIntlStr(ResourceEllipsis2);
                    }
                    
                    return cachedEllipsis2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Ellipsis3 translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Ellipsis3
            {
                get
                {
                    if ((cachedEllipsis3 == null))
                    {
                        cachedEllipsis3 = CoreManager.MomConsole.GetIntlStr(ResourceEllipsis3);
                    }
                    
                    return cachedEllipsis3;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Value translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Value
            {
                get
                {
                    if ((cachedValue == null))
                    {
                        cachedValue = CoreManager.MomConsole.GetIntlStr(ResourceValue);
                    }
                    
                    return cachedValue;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Instance translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Instance
            {
                get
                {
                    if ((cachedInstance == null))
                    {
                        cachedInstance = CoreManager.MomConsole.GetIntlStr(ResourceInstance);
                    }
                    
                    return cachedInstance;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Counter translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Counter
            {
                get
                {
                    if ((cachedCounter == null))
                    {
                        cachedCounter = CoreManager.MomConsole.GetIntlStr(ResourceCounter);
                    }
                    
                    return cachedCounter;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Object translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Object
            {
                get
                {
                    if ((cachedObject == null))
                    {
                        cachedObject = CoreManager.MomConsole.GetIntlStr(ResourceObject);
                    }
                    
                    return cachedObject;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EnterPerformanceMappingInformation translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EnterPerformanceMappingInformation
            {
                get
                {
                    if ((cachedEnterPerformanceMappingInformation == null))
                    {
                        cachedEnterPerformanceMappingInformation = CoreManager.MomConsole.GetIntlStr(ResourceEnterPerformanceMappingInformation);
                    }
                    
                    return cachedEnterPerformanceMappingInformation;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
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
            /// Exposes access to the PerformanceMapper2 translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string PerformanceMapper2
            {
                get
                {
                    if ((cachedPerformanceMapper2 == null))
                    {
                        cachedPerformanceMapper2 = CoreManager.MomConsole.GetIntlStr(ResourcePerformanceMapper2);
                    }
                    
                    return cachedPerformanceMapper2;
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
        /// 	[barryli] 20JUN07 Created
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
            /// Control ID for CreateButton
            /// </summary>
            public const string CreateButton = "commitButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for RuleTypeStaticControl
            /// </summary>
            public const string RuleTypeStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for GeneralStaticControl
            /// </summary>
            public const string GeneralStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for WMIConfigurationStaticControl
            /// </summary>
            public const string WMIConfigurationStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for PerformanceMapperStaticControl
            /// </summary>
            public const string PerformanceMapperStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for Ellipsis0Button
            /// </summary>
            public const string Ellipsis0Button = "btnValueBrowse";
            
            /// <summary>
            /// Control ID for Ellipsis1Button
            /// </summary>
            public const string Ellipsis1Button = "btnInstanceBrowse";
            
            /// <summary>
            /// Control ID for Ellipsis2Button
            /// </summary>
            public const string Ellipsis2Button = "btnCounterBrowse";
            
            /// <summary>
            /// Control ID for Ellipsis3Button
            /// </summary>
            public const string Ellipsis3Button = "btnObjectBrowse";
            
            /// <summary>
            /// Control ID for ValueTextBox
            /// </summary>
            public const string ValueTextBox = "txtValue";
            
            /// <summary>
            /// Control ID for InstanceTextBox
            /// </summary>
            public const string InstanceTextBox = "txtInstance";
            
            /// <summary>
            /// Control ID for CounterTextBox
            /// </summary>
            public const string CounterTextBox = "txtCounter";
            
            /// <summary>
            /// Control ID for ObjectTextBox
            /// </summary>
            public const string ObjectTextBox = "txtObject";
            
            /// <summary>
            /// Control ID for ValueStaticControl
            /// </summary>
            public const string ValueStaticControl = "lblValue";
            
            /// <summary>
            /// Control ID for InstanceStaticControl
            /// </summary>
            public const string InstanceStaticControl = "lblInstance";
            
            /// <summary>
            /// Control ID for CounterStaticControl
            /// </summary>
            public const string CounterStaticControl = "lblCounter";
            
            /// <summary>
            /// Control ID for ObjectStaticControl
            /// </summary>
            public const string ObjectStaticControl = "lblObject";
            
            /// <summary>
            /// Control ID for EnterPerformanceMappingInformationStaticControl
            /// </summary>
            public const string EnterPerformanceMappingInformationStaticControl = "pageSectionLabel1";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for PerformanceMapperStaticControl2
            /// </summary>
            public const string PerformanceMapperStaticControl2 = "headerLabel";
        }
        #endregion
    }
}
