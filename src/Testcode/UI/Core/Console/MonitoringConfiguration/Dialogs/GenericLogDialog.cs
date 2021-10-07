// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="GenericLogDialog.cs">
// 	Copyright (c) Microsoft Corporation 2007
// </copyright>
// <project>
// 	MOMv3 UI Console
// </project>
// <summary>
// 	Generic Log Setting Dialog used in Rule/Monitor Wizard.
// </summary>
// <history>
// 	[barryli] 13JUN07 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Console;
    using Mom.Test.UI.Core.Common;
    
    #region Interface Definition - IGenericLogDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IGenericLogDialogControls, for GenericLogDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[barryli] 13JUN07 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IGenericLogDialogControls
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
        /// Read-only property to access ApplicationLogDataSourceStaticControl
        /// </summary>
        StaticControl ApplicationLogDataSourceStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access BuildEventExpressionStaticControl
        /// </summary>
        StaticControl BuildEventExpressionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConfigureAlertsStaticControl
        /// </summary>
        StaticControl ConfigureAlertsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TextBox0
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TextBox TextBox0
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SeparatorStaticControl
        /// </summary>
        StaticControl SeparatorStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SeparatorTextBox
        /// </summary>
        TextBox SeparatorTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DirectoryStaticControl
        /// </summary>
        StaticControl DirectoryStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DirectoryTextBox
        /// </summary>
        TextBox DirectoryTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PatternStaticControl
        /// </summary>
        StaticControl PatternStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PatternTextBox
        /// </summary>
        TextBox PatternTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TextBox1
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TextBox TextBox1
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access UTF8CheckBox
        /// </summary>
        CheckBox UTF8CheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DefineTheApplicationLogDataSourceStaticControl
        /// </summary>
        StaticControl DefineTheApplicationLogDataSourceStaticControl
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
        /// Read-only property to access ApplicationLogDataSourceStaticControl2
        /// </summary>
        StaticControl ApplicationLogDataSourceStaticControl2
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
    /// 	[barryli] 13JUN07 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class GenericLogDialog : Dialog, IGenericLogDialogControls
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
        /// Cache to hold a reference to ApplicationLogDataSourceStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedApplicationLogDataSourceStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to BuildEventExpressionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedBuildEventExpressionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureAlertsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureAlertsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to TextBox0 of type TextBox
        /// </summary>
        private TextBox cachedTextBox0;
        
        /// <summary>
        /// Cache to hold a reference to SeparatorStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSeparatorStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SeparatorTextBox of type TextBox
        /// </summary>
        private TextBox cachedSeparatorTextBox;
        
        /// <summary>
        /// Cache to hold a reference to DirectoryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDirectoryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DirectoryTextBox of type TextBox
        /// </summary>
        private TextBox cachedDirectoryTextBox;
        
        /// <summary>
        /// Cache to hold a reference to PatternStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPatternStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to PatternTextBox of type TextBox
        /// </summary>
        private TextBox cachedPatternTextBox;
        
        /// <summary>
        /// Cache to hold a reference to TextBox1 of type TextBox
        /// </summary>
        private TextBox cachedTextBox1;
        
        /// <summary>
        /// Cache to hold a reference to UTF8CheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedUTF8CheckBox;
        
        /// <summary>
        /// Cache to hold a reference to DefineTheApplicationLogDataSourceStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDefineTheApplicationLogDataSourceStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ApplicationLogDataSourceStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedApplicationLogDataSourceStaticControl2;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of GenericLogDialog of type GenericLogDialog
        /// </param>
        /// <param name='windowCaption'>Dialog Title </param>
        /// <history>
        /// 	[barryli] 13JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public GenericLogDialog(MomConsoleApp app, MonitoringConfiguration.WindowCaptions windowCaption)
            :
                base(app, Init(app, windowCaption))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout); 
        }
        #endregion
        
        #region IGenericLogDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[barryli] 13JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IGenericLogDialogControls Controls
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
        ///  Property to handle checkbox UTF8
        /// </summary>
        /// <history>
        /// 	[barryli] 13JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool UTF8
        {
            get
            {
                return this.Controls.UTF8CheckBox.Checked;
            }
            
            set
            {
                this.Controls.UTF8CheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TextBox0
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[barryli] 13JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TextBox0Text
        {
            get
            {
                return this.Controls.TextBox0.Text;
            }
            
            set
            {
                this.Controls.TextBox0.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Separator
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[barryli] 13JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SeparatorText
        {
            get
            {
                return this.Controls.SeparatorTextBox.Text;
            }
            
            set
            {
                this.Controls.SeparatorTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Directory
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[barryli] 13JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DirectoryText
        {
            get
            {
                return this.Controls.DirectoryTextBox.Text;
            }
            
            set
            {
                this.Controls.DirectoryTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Pattern
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[barryli] 13JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string PatternText
        {
            get
            {
                return this.Controls.PatternTextBox.Text;
            }
            
            set
            {
                this.Controls.PatternTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TextBox1
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[barryli] 13JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TextBox1Text
        {
            get
            {
                return this.Controls.TextBox1.Text;
            }
            
            set
            {
                this.Controls.TextBox1.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[barryli] 13JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IGenericLogDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, GenericLogDialog.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[barryli] 13JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IGenericLogDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, GenericLogDialog.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[barryli] 13JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IGenericLogDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, GenericLogDialog.ControlIDs.CreateButton);
                }
                
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[barryli] 13JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IGenericLogDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, GenericLogDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RuleTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 13JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGenericLogDialogControls.RuleTypeStaticControl
        {
            get
            {
                if ((this.cachedRuleTypeStaticControl == null))
                {
                    this.cachedRuleTypeStaticControl = new StaticControl(this, GenericLogDialog.ControlIDs.RuleTypeStaticControl);
                }
                
                return this.cachedRuleTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 13JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGenericLogDialogControls.GeneralStaticControl
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
        ///  Exposes access to the ApplicationLogDataSourceStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 13JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGenericLogDialogControls.ApplicationLogDataSourceStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedApplicationLogDataSourceStaticControl == null))
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
                    this.cachedApplicationLogDataSourceStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedApplicationLogDataSourceStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BuildEventExpressionStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 13JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGenericLogDialogControls.BuildEventExpressionStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedBuildEventExpressionStaticControl == null))
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
                    this.cachedBuildEventExpressionStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedBuildEventExpressionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureAlertsStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 13JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGenericLogDialogControls.ConfigureAlertsStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedConfigureAlertsStaticControl == null))
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
                    for (i = 0; (i <= 3); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedConfigureAlertsStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedConfigureAlertsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TextBox0 control
        /// </summary>
        /// <history>
        /// 	[barryli] 13JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IGenericLogDialogControls.TextBox0
        {
            get
            {
                if ((this.cachedTextBox0 == null))
                {
                    this.cachedTextBox0 = new TextBox(this, GenericLogDialog.ControlIDs.TextBox0);
                }
                
                return this.cachedTextBox0;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SeparatorStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 13JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGenericLogDialogControls.SeparatorStaticControl
        {
            get
            {
                if ((this.cachedSeparatorStaticControl == null))
                {
                    this.cachedSeparatorStaticControl = new StaticControl(this, GenericLogDialog.ControlIDs.SeparatorStaticControl);
                }
                
                return this.cachedSeparatorStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SeparatorTextBox control
        /// </summary>
        /// <history>
        /// 	[barryli] 13JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IGenericLogDialogControls.SeparatorTextBox
        {
            get
            {
                if ((this.cachedSeparatorTextBox == null))
                {
                    this.cachedSeparatorTextBox = new TextBox(this, GenericLogDialog.ControlIDs.SeparatorTextBox);
                }
                
                return this.cachedSeparatorTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DirectoryStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 13JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGenericLogDialogControls.DirectoryStaticControl
        {
            get
            {
                if ((this.cachedDirectoryStaticControl == null))
                {
                    this.cachedDirectoryStaticControl = new StaticControl(this, GenericLogDialog.ControlIDs.DirectoryStaticControl);
                }
                
                return this.cachedDirectoryStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DirectoryTextBox control
        /// </summary>
        /// <history>
        /// 	[barryli] 13JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IGenericLogDialogControls.DirectoryTextBox
        {
            get
            {
                if ((this.cachedDirectoryTextBox == null))
                {
                    this.cachedDirectoryTextBox = new TextBox(this, GenericLogDialog.ControlIDs.DirectoryTextBox);
                }
                
                return this.cachedDirectoryTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PatternStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 13JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGenericLogDialogControls.PatternStaticControl
        {
            get
            {
                if ((this.cachedPatternStaticControl == null))
                {
                    this.cachedPatternStaticControl = new StaticControl(this, GenericLogDialog.ControlIDs.PatternStaticControl);
                }
                
                return this.cachedPatternStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PatternTextBox control
        /// </summary>
        /// <history>
        /// 	[barryli] 13JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IGenericLogDialogControls.PatternTextBox
        {
            get
            {
                if ((this.cachedPatternTextBox == null))
                {
                    this.cachedPatternTextBox = new TextBox(this, GenericLogDialog.ControlIDs.PatternTextBox);
                }
                
                return this.cachedPatternTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TextBox1 control
        /// </summary>
        /// <history>
        /// 	[barryli] 13JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IGenericLogDialogControls.TextBox1
        {
            get
            {
                if ((this.cachedTextBox1 == null))
                {
                    this.cachedTextBox1 = new TextBox(this, GenericLogDialog.ControlIDs.TextBox1);
                }
                
                return this.cachedTextBox1;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UTF8CheckBox control
        /// </summary>
        /// <history>
        /// 	[barryli] 13JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IGenericLogDialogControls.UTF8CheckBox
        {
            get
            {
                if ((this.cachedUTF8CheckBox == null))
                {
                    this.cachedUTF8CheckBox = new CheckBox(this, GenericLogDialog.ControlIDs.UTF8CheckBox);
                }
                
                return this.cachedUTF8CheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DefineTheApplicationLogDataSourceStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 13JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGenericLogDialogControls.DefineTheApplicationLogDataSourceStaticControl
        {
            get
            {
                if ((this.cachedDefineTheApplicationLogDataSourceStaticControl == null))
                {
                    this.cachedDefineTheApplicationLogDataSourceStaticControl = new StaticControl(this, GenericLogDialog.ControlIDs.DefineTheApplicationLogDataSourceStaticControl);
                }
                
                return this.cachedDefineTheApplicationLogDataSourceStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 13JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGenericLogDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, GenericLogDialog.ControlIDs.HelpStaticControl);
                }
                
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApplicationLogDataSourceStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[barryli] 13JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGenericLogDialogControls.ApplicationLogDataSourceStaticControl2
        {
            get
            {
                if ((this.cachedApplicationLogDataSourceStaticControl2 == null))
                {
                    this.cachedApplicationLogDataSourceStaticControl2 = new StaticControl(this, GenericLogDialog.ControlIDs.ApplicationLogDataSourceStaticControl2);
                }
                
                return this.cachedApplicationLogDataSourceStaticControl2;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[barryli] 13JUN07 Created
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
        /// 	[barryli] 13JUN07 Created
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
        /// 	[barryli] 13JUN07 Created
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
        /// 	[barryli] 13JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button UTF8
        /// </summary>
        /// <history>
        /// 	[barryli] 13JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickUTF8()
        {
            this.Controls.UTF8CheckBox.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">GenericLogDialog owning the dialog.</param>
        ///  <param name='windowCaption'>Dialog Title </param>
        /// <history>
        /// 	[barryli] 13JUN07 Created
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
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
            }
            catch (Exceptions.WindowNotFoundException ex)
            {
                // Reset the window reference
                tempWindow = null;
                int numberOfTries = 0;
                // Maximum number of tries to find window
                int maxTries = 5;

                while (tempWindow == null && numberOfTries < maxTries)
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
                            "Attempt " + numberOfTries + " of " + maxTries);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find window with title:  '" + DialogTitle + "'");

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
        /// 	[barryli] 13JUN07 Created
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
            private const string ResourceDialogTitle = ";Create Rule Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Extensibility.UISDKResources;CreateRuleWizard";

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
            /// Contains resource string for:  ApplicationLogDataSource
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceApplicationLogDataSource = ";Application Log Data Source;ManagedString;Microsoft.EnterpriseManagement.UI.Auth" +
                "oring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Application" +
                "LogDataSource;$this.TabName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  BuildEventExpression
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceBuildEventExpression = ";Build Event Expression;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring" +
                ".dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ExpressionEvalua" +
                "torCondition;$this.NavigationText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureAlerts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureAlerts = ";Configure Alerts;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;M" +
                "icrosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.AlertConfiguration;$th" +
                "is.NavigationText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Separator
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSeparator = ";&Separator:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micros" +
                "oft.EnterpriseManagement.Internal.UI.Authoring.Pages.ApplicationLogDataSource;Se" +
                "paratorLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Directory
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDirectory = ";&Directory:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micros" +
                "oft.EnterpriseManagement.Internal.UI.Authoring.Pages.ApplicationLogDataSource;Di" +
                "rectoryLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Pattern
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePattern = ";&Pattern:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsof" +
                "t.EnterpriseManagement.Internal.UI.Authoring.Pages.ApplicationLogDataSource;Patt" +
                "ernLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  UTF8
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUTF8 = ";&UTF8;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.En" +
                "terpriseManagement.Internal.UI.Authoring.Pages.ApplicationLogDataSource;UTF8Chec" +
                "kBox.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DefineTheApplicationLogDataSource
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDefineTheApplicationLogDataSource = ";Define the application log data source;ManagedString;Microsoft.EnterpriseManagem" +
                "ent.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages." +
                "ApplicationLogDataSource;pageSectionLabel1.Text";
            
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
            /// Contains resource string for:  ApplicationLogDataSource2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceApplicationLogDataSource2 = ";Application Log Data Source;ManagedString;Microsoft.EnterpriseManagement.UI.Auth" +
                "oring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Application" +
                "LogDataSource;$this.TabName";
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
            /// Caches the translated resource string for:  ApplicationLogDataSource
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedApplicationLogDataSource;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  BuildEventExpression
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBuildEventExpression;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureAlerts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigureAlerts;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Separator
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSeparator;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Directory
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDirectory;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Pattern
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPattern;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  UTF8
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUTF8;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DefineTheApplicationLogDataSource
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDefineTheApplicationLogDataSource;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ApplicationLogDataSource2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedApplicationLogDataSource2;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 13JUN07 Created
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
            /// 	[barryli] 13JUN07 Created
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
            /// 	[barryli] 13JUN07 Created
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
            /// 	[barryli] 13JUN07 Created
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
            /// 	[barryli] 13JUN07 Created
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
            /// 	[barryli] 13JUN07 Created
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
            /// 	[barryli] 13JUN07 Created
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
            /// Exposes access to the ApplicationLogDataSource translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 13JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ApplicationLogDataSource
            {
                get
                {
                    if ((cachedApplicationLogDataSource == null))
                    {
                        cachedApplicationLogDataSource = CoreManager.MomConsole.GetIntlStr(ResourceApplicationLogDataSource);
                    }
                    
                    return cachedApplicationLogDataSource;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the BuildEventExpression translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 13JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string BuildEventExpression
            {
                get
                {
                    if ((cachedBuildEventExpression == null))
                    {
                        cachedBuildEventExpression = CoreManager.MomConsole.GetIntlStr(ResourceBuildEventExpression);
                    }
                    
                    return cachedBuildEventExpression;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfigureAlerts translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 13JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfigureAlerts
            {
                get
                {
                    if ((cachedConfigureAlerts == null))
                    {
                        cachedConfigureAlerts = CoreManager.MomConsole.GetIntlStr(ResourceConfigureAlerts);
                    }
                    
                    return cachedConfigureAlerts;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Separator translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 13JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Separator
            {
                get
                {
                    if ((cachedSeparator == null))
                    {
                        cachedSeparator = CoreManager.MomConsole.GetIntlStr(ResourceSeparator);
                    }
                    
                    return cachedSeparator;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Directory translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 13JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Directory
            {
                get
                {
                    if ((cachedDirectory == null))
                    {
                        cachedDirectory = CoreManager.MomConsole.GetIntlStr(ResourceDirectory);
                    }
                    
                    return cachedDirectory;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Pattern translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 13JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Pattern
            {
                get
                {
                    if ((cachedPattern == null))
                    {
                        cachedPattern = CoreManager.MomConsole.GetIntlStr(ResourcePattern);
                    }
                    
                    return cachedPattern;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the UTF8 translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 13JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UTF8
            {
                get
                {
                    if ((cachedUTF8 == null))
                    {
                        cachedUTF8 = CoreManager.MomConsole.GetIntlStr(ResourceUTF8);
                    }
                    
                    return cachedUTF8;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DefineTheApplicationLogDataSource translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 13JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DefineTheApplicationLogDataSource
            {
                get
                {
                    if ((cachedDefineTheApplicationLogDataSource == null))
                    {
                        cachedDefineTheApplicationLogDataSource = CoreManager.MomConsole.GetIntlStr(ResourceDefineTheApplicationLogDataSource);
                    }
                    
                    return cachedDefineTheApplicationLogDataSource;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 13JUN07 Created
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
            /// Exposes access to the ApplicationLogDataSource2 translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 13JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ApplicationLogDataSource2
            {
                get
                {
                    if ((cachedApplicationLogDataSource2 == null))
                    {
                        cachedApplicationLogDataSource2 = CoreManager.MomConsole.GetIntlStr(ResourceApplicationLogDataSource2);
                    }
                    
                    return cachedApplicationLogDataSource2;
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
        /// 	[barryli] 13JUN07 Created
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
            /// Control ID for ApplicationLogDataSourceStaticControl
            /// </summary>
            public const string ApplicationLogDataSourceStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for BuildEventExpressionStaticControl
            /// </summary>
            public const string BuildEventExpressionStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ConfigureAlertsStaticControl
            /// </summary>
            public const string ConfigureAlertsStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for TextBox0
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string TextBox0 = "textBox2";
            
            /// <summary>
            /// Control ID for SeparatorStaticControl
            /// </summary>
            public const string SeparatorStaticControl = "SeparatorLabel";
            
            /// <summary>
            /// Control ID for SeparatorTextBox
            /// </summary>
            public const string SeparatorTextBox = "SeparatorTextBox";
            
            /// <summary>
            /// Control ID for DirectoryStaticControl
            /// </summary>
            public const string DirectoryStaticControl = "DirectoryLabel";
            
            /// <summary>
            /// Control ID for DirectoryTextBox
            /// </summary>
            public const string DirectoryTextBox = "DirectoryTextBox";
            
            /// <summary>
            /// Control ID for PatternStaticControl
            /// </summary>
            public const string PatternStaticControl = "PatternLabel";
            
            /// <summary>
            /// Control ID for PatternTextBox
            /// </summary>
            public const string PatternTextBox = "PatternTextBox";
            
            /// <summary>
            /// Control ID for TextBox1
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string TextBox1 = "textBox1";
            
            /// <summary>
            /// Control ID for UTF8CheckBox
            /// </summary>
            public const string UTF8CheckBox = "UTF8CheckBox";
            
            /// <summary>
            /// Control ID for DefineTheApplicationLogDataSourceStaticControl
            /// </summary>
            public const string DefineTheApplicationLogDataSourceStaticControl = "pageSectionLabel1";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for ApplicationLogDataSourceStaticControl2
            /// </summary>
            public const string ApplicationLogDataSourceStaticControl2 = "headerLabel";
        }
        #endregion
    }
}
