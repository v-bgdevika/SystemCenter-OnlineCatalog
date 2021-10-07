// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ScriptTaskConfiguration.cs">
// 	Copyright (c) Microsoft Corporation 2007
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[faizalk] 1/23/2007 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Tasks.Wizards
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Console;
    using Mom.Test.UI.Core.Common;
    
    #region Interface Definition - IScriptTaskConfigurationControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IScriptTaskConfigurationControls, for ScriptTaskConfiguration.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[faizalk] 1/23/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IScriptTaskConfigurationControls
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
        /// Read-only property to access TaskTypeStaticControl
        /// </summary>
        StaticControl TaskTypeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access GeneralPropertiesStaticControl
        /// </summary>
        StaticControl GeneralPropertiesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ScriptStaticControl
        /// </summary>
        StaticControl ScriptStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ClickTheParametersButtonToSpecifyTheScriptParametersStaticControl
        /// </summary>
        StaticControl ClickTheParametersButtonToSpecifyTheScriptParametersStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ExampleMyScriptvbsStaticControl
        /// </summary>
        StaticControl ExampleMyScriptvbsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ExampleMyScriptvbsComboBox
        /// </summary>
        ComboBox ExampleMyScriptvbsComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TimeoutComboBox
        /// </summary>
        TextBox TimeoutComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EnterScriptInformationStaticControl
        /// </summary>
        StaticControl EnterScriptInformationStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ParametersButton
        /// </summary>
        Button ParametersButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EditInFullScreenButton
        /// </summary>
        Button EditInFullScreenButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ScriptTextBox
        /// </summary>
        TextBox ScriptTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ScriptStaticControl2
        /// </summary>
        StaticControl ScriptStaticControl2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TimeoutStaticControl
        /// </summary>
        StaticControl TimeoutStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FileNameTextBox
        /// </summary>
        TextBox FileNameTextBox
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
        /// Read-only property to access HelpStaticControl
        /// </summary>
        StaticControl HelpStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ScriptStaticControl3
        /// </summary>
        StaticControl ScriptStaticControl3
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
    /// 	[faizalk] 1/23/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ScriptTaskConfiguration : Dialog, IScriptTaskConfigurationControls
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
        /// Cache to hold a reference to TaskTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTaskTypeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to GeneralPropertiesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralPropertiesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ScriptStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedScriptStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ClickTheParametersButtonToSpecifyTheScriptParametersStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedClickTheParametersButtonToSpecifyTheScriptParametersStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ExampleMyScriptvbsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedExampleMyScriptvbsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ExampleMyScriptvbsComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedExampleMyScriptvbsComboBox;
        
        /// <summary>
        /// Cache to hold a reference to TimeoutComboBox of type ComboBox
        /// </summary>
        private TextBox cachedTimeoutComboBox;
        
        /// <summary>
        /// Cache to hold a reference to EnterScriptInformationStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEnterScriptInformationStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ParametersButton of type Button
        /// </summary>
        private Button cachedParametersButton;
        
        /// <summary>
        /// Cache to hold a reference to EditInFullScreenButton of type Button
        /// </summary>
        private Button cachedEditInFullScreenButton;
        
        /// <summary>
        /// Cache to hold a reference to ScriptTextBox of type TextBox
        /// </summary>
        private TextBox cachedScriptTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ScriptStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedScriptStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to TimeoutStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTimeoutStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to FileNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedFileNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to FileNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedFileNameStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ScriptStaticControl3 of type StaticControl
        /// </summary>
        private StaticControl cachedScriptStaticControl3;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ScriptTaskConfiguration of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[faizalk] 1/23/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ScriptTaskConfiguration(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ScriptTaskConfiguration of type MomConsoleApp
        /// </param>
        /// <param name='windowCaption'>windows caption</param>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ScriptTaskConfiguration(MomConsoleApp app, Mom.Test.UI.Core.Console.MonitoringConfiguration.MonitoringConfiguration.WindowCaptions windowCaption)
            :
                base(app, Init(app, windowCaption))
        {
            //this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
        }
        #endregion
        
        #region IScriptTaskConfiguration Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[faizalk] 1/23/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IScriptTaskConfigurationControls Controls
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
        ///  Routine to set/get the text in control ExampleMyScriptvbs
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 1/23/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ExampleMyScriptvbsText
        {
            get
            {
                return this.Controls.ExampleMyScriptvbsComboBox.Text;
            }
            
            set
            {
                this.Controls.ExampleMyScriptvbsComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Timeout
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 1/23/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TimeoutText
        {
            get
            {
                return this.Controls.TimeoutComboBox.Text;
            }
            
            set
            {
                this.Controls.TimeoutComboBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Script
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 1/23/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ScriptText
        {
            get
            {
                return this.Controls.ScriptTextBox.Text;
            }
            
            set
            {
                this.Controls.ScriptTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control FileName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 1/23/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string FileNameText
        {
            get
            {
                return this.Controls.FileNameTextBox.Text;
            }
            
            set
            {
                this.Controls.FileNameTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 1/23/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IScriptTaskConfigurationControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, ScriptTaskConfiguration.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 1/23/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IScriptTaskConfigurationControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, ScriptTaskConfiguration.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 1/23/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IScriptTaskConfigurationControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, ScriptTaskConfiguration.ControlIDs.CreateButton);
                }
                
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 1/23/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IScriptTaskConfigurationControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ScriptTaskConfiguration.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TaskTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 1/23/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IScriptTaskConfigurationControls.TaskTypeStaticControl
        {
            get
            {
                if ((this.cachedTaskTypeStaticControl == null))
                {
                    this.cachedTaskTypeStaticControl = new StaticControl(this, ScriptTaskConfiguration.ControlIDs.TaskTypeStaticControl);
                }
                
                return this.cachedTaskTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralPropertiesStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 1/23/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IScriptTaskConfigurationControls.GeneralPropertiesStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedGeneralPropertiesStaticControl == null))
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
                    this.cachedGeneralPropertiesStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedGeneralPropertiesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ScriptStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 1/23/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IScriptTaskConfigurationControls.ScriptStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedScriptStaticControl == null))
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
                    this.cachedScriptStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedScriptStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ClickTheParametersButtonToSpecifyTheScriptParametersStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 1/23/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IScriptTaskConfigurationControls.ClickTheParametersButtonToSpecifyTheScriptParametersStaticControl
        {
            get
            {
                if ((this.cachedClickTheParametersButtonToSpecifyTheScriptParametersStaticControl == null))
                {
                    this.cachedClickTheParametersButtonToSpecifyTheScriptParametersStaticControl = new StaticControl(this, ScriptTaskConfiguration.ControlIDs.ClickTheParametersButtonToSpecifyTheScriptParametersStaticControl);
                }
                
                return this.cachedClickTheParametersButtonToSpecifyTheScriptParametersStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExampleMyScriptvbsStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 1/23/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IScriptTaskConfigurationControls.ExampleMyScriptvbsStaticControl
        {
            get
            {
                if ((this.cachedExampleMyScriptvbsStaticControl == null))
                {
                    this.cachedExampleMyScriptvbsStaticControl = new StaticControl(this, ScriptTaskConfiguration.ControlIDs.ExampleMyScriptvbsStaticControl);
                }
                
                return this.cachedExampleMyScriptvbsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExampleMyScriptvbsComboBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 1/23/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IScriptTaskConfigurationControls.ExampleMyScriptvbsComboBox
        {
            get
            {
                if ((this.cachedExampleMyScriptvbsComboBox == null))
                {
                    this.cachedExampleMyScriptvbsComboBox = new ComboBox(this, ScriptTaskConfiguration.ControlIDs.ExampleMyScriptvbsComboBox);
                }
                
                return this.cachedExampleMyScriptvbsComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TimeoutComboBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 1/23/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IScriptTaskConfigurationControls.TimeoutComboBox
        {
            get
            {
                if ((this.cachedTimeoutComboBox == null))
                {
                    this.cachedTimeoutComboBox = new TextBox(this, ScriptTaskConfiguration.ControlIDs.TimeoutComboBox);
                }
                
                return this.cachedTimeoutComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EnterScriptInformationStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 1/23/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IScriptTaskConfigurationControls.EnterScriptInformationStaticControl
        {
            get
            {
                if ((this.cachedEnterScriptInformationStaticControl == null))
                {
                    this.cachedEnterScriptInformationStaticControl = new StaticControl(this, ScriptTaskConfiguration.ControlIDs.EnterScriptInformationStaticControl);
                }
                
                return this.cachedEnterScriptInformationStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ParametersButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 1/23/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IScriptTaskConfigurationControls.ParametersButton
        {
            get
            {
                if ((this.cachedParametersButton == null))
                {
                    this.cachedParametersButton = new Button(this, ScriptTaskConfiguration.ControlIDs.ParametersButton);
                }
                
                return this.cachedParametersButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EditInFullScreenButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 1/23/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IScriptTaskConfigurationControls.EditInFullScreenButton
        {
            get
            {
                if ((this.cachedEditInFullScreenButton == null))
                {
                    this.cachedEditInFullScreenButton = new Button(this, ScriptTaskConfiguration.ControlIDs.EditInFullScreenButton);
                }
                
                return this.cachedEditInFullScreenButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ScriptTextBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 1/23/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IScriptTaskConfigurationControls.ScriptTextBox
        {
            get
            {
                if ((this.cachedScriptTextBox == null))
                {
                    this.cachedScriptTextBox = new TextBox(this, ScriptTaskConfiguration.ControlIDs.ScriptTextBox);
                }
                
                return this.cachedScriptTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ScriptStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[faizalk] 1/23/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IScriptTaskConfigurationControls.ScriptStaticControl2
        {
            get
            {
                if ((this.cachedScriptStaticControl2 == null))
                {
                    this.cachedScriptStaticControl2 = new StaticControl(this, ScriptTaskConfiguration.ControlIDs.ScriptStaticControl2);
                }
                
                return this.cachedScriptStaticControl2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TimeoutStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 1/23/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IScriptTaskConfigurationControls.TimeoutStaticControl
        {
            get
            {
                if ((this.cachedTimeoutStaticControl == null))
                {
                    this.cachedTimeoutStaticControl = new StaticControl(this, ScriptTaskConfiguration.ControlIDs.TimeoutStaticControl);
                }
                
                return this.cachedTimeoutStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FileNameTextBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 1/23/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IScriptTaskConfigurationControls.FileNameTextBox
        {
            get
            {
                if ((this.cachedFileNameTextBox == null))
                {
                    this.cachedFileNameTextBox = new TextBox(this, ScriptTaskConfiguration.ControlIDs.FileNameTextBox);
                }
                
                return this.cachedFileNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FileNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 1/23/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IScriptTaskConfigurationControls.FileNameStaticControl
        {
            get
            {
                if ((this.cachedFileNameStaticControl == null))
                {
                    this.cachedFileNameStaticControl = new StaticControl(this, ScriptTaskConfiguration.ControlIDs.FileNameStaticControl);
                }
                
                return this.cachedFileNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 1/23/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IScriptTaskConfigurationControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, ScriptTaskConfiguration.ControlIDs.HelpStaticControl);
                }
                
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ScriptStaticControl3 control
        /// </summary>
        /// <history>
        /// 	[faizalk] 1/23/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IScriptTaskConfigurationControls.ScriptStaticControl3
        {
            get
            {
                if ((this.cachedScriptStaticControl3 == null))
                {
                    this.cachedScriptStaticControl3 = new StaticControl(this, ScriptTaskConfiguration.ControlIDs.ScriptStaticControl3);
                }
                
                return this.cachedScriptStaticControl3;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[faizalk] 1/23/2007 Created
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
        /// 	[faizalk] 1/23/2007 Created
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
        /// 	[faizalk] 1/23/2007 Created
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
        /// 	[faizalk] 1/23/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Parameters
        /// </summary>
        /// <history>
        /// 	[faizalk] 1/23/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickParameters()
        {
            this.Controls.ParametersButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button EditInFullScreen
        /// </summary>
        /// <history>
        /// 	[faizalk] 1/23/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEditInFullScreen()
        {
            this.Controls.EditInFullScreenButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">MomConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[faizalk] 1/23/2007 Created
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
            catch (Exceptions.WindowNotFoundException windowNotFound)
            {
                // Reset the window reference
                tempWindow = null;

                // Maximum number of tries to find window
                int maxTries = 5;

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
                    catch (Exceptions.WindowNotFoundException )
                    {
                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage("Attempt "
                             + numberOfTries
                             + " of "
                             + maxTries
                             + "...");

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }
                
                // check for success
                if ((null == tempWindow))
                {
                    // log the failure

                    // rethrow the original exception
                    throw windowNotFound;
                }
            }
            
            return tempWindow;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">ScriptTaskConfigurationDialog owning the dialog.</param>)
        ///  <param name="windowCaption">window caption</param>)
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app, Mom.Test.UI.Core.Console.MonitoringConfiguration.MonitoringConfiguration.WindowCaptions windowCaption)
        {

            string DialogTitle = Mom.Test.UI.Core.Console.MonitoringConfiguration.MonitoringConfiguration.GetWindowCaption(windowCaption);
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
        /// 	[faizalk] 1/23/2007 Created
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
            private const string ResourceDialogTitle = ";Create Task Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Extensibility.UISDKResources;CreateTaskWizard";
            
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
            /// Contains resource string for:  TaskType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTaskType = ";Task Type;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsof" +
                "t.EnterpriseManagement.Internal.UI.Authoring.Pages.ChooseTaskTypePage;$this.Navi" +
                "gationText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  GeneralProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneralProperties = ";General Properties;ManagedString;Microsoft.EnterpriseManagement.UI.Administratio" +
                "n.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPInstall.Ru" +
                "leGeneralPage;$this.Title";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Script
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceScript = ";Script;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.E" +
                "nterpriseManagement.Internal.UI.Authoring.Pages.ScriptPage;$this.TabName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ClickTheParametersButtonToSpecifyTheScriptParameters
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceClickTheParametersButtonToSpecifyTheScriptParameters = ";Click the \"Parameters...\" button to specify the script parameters.;ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement." +
                "Internal.UI.Authoring.Pages.ScriptPage;label1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ExampleMyScriptvbs
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceExampleMyScriptvbs = ";Example:  MyScript.vbs;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring" +
                ".dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ScriptPage;idLab" +
                "elExample.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EnterScriptInformation
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEnterScriptInformation = ";Enter script information;ManagedString;Microsoft.EnterpriseManagement.UI.Authori" +
                "ng.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ScriptPage;pag" +
                "eSectionLabel1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Parameters
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceParameters = ";P&arameters...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Mic" +
                "rosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ScriptPage;btnParameters" +
                ".Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EditInFullScreen
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEditInFullScreen = ";&Edit in full screen...;ManagedString;Microsoft.EnterpriseManagement.UI.Authorin" +
                "g.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ScriptPage;btnE" +
                "dit.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Script2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceScript2 = ";&Script:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft" +
                ".EnterpriseManagement.Internal.UI.Authoring.Pages.ScriptPage;lblScript.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Timeout
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTimeout = ";&Timeout:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsof" +
                "t.EnterpriseManagement.Internal.UI.Authoring.Pages.CommandWriteActionPage;idLabe" +
                "lTimeout.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  FileName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFileName = ";File &Name:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micros" +
                "oft.EnterpriseManagement.Internal.UI.Authoring.Pages.ScriptPage;lblName.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsof" +
                "t.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.ErrorTransmi" +
                "ssionFilterForm;linkLabelHelp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Script3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceScript3 = ";Script;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.E" +
                "nterpriseManagement.Internal.UI.Authoring.Pages.ScriptPage;$this.TabName";
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
            /// Caches the translated resource string for:  TaskType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTaskType;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  GeneralProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneralProperties;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Script
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedScript;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ClickTheParametersButtonToSpecifyTheScriptParameters
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedClickTheParametersButtonToSpecifyTheScriptParameters;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ExampleMyScriptvbs
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedExampleMyScriptvbs;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EnterScriptInformation
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEnterScriptInformation;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Parameters
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedParameters;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EditInFullScreen
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEditInFullScreen;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Script2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedScript2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Timeout
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTimeout;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  FileName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFileName;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Script3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedScript3;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 1/23/2007 Created
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
            /// 	[faizalk] 1/23/2007 Created
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
            /// 	[faizalk] 1/23/2007 Created
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
            /// 	[faizalk] 1/23/2007 Created
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
            /// 	[faizalk] 1/23/2007 Created
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
            /// Exposes access to the TaskType translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 1/23/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TaskType
            {
                get
                {
                    if ((cachedTaskType == null))
                    {
                        cachedTaskType = CoreManager.MomConsole.GetIntlStr(ResourceTaskType);
                    }
                    
                    return cachedTaskType;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the GeneralProperties translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 1/23/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string GeneralProperties
            {
                get
                {
                    if ((cachedGeneralProperties == null))
                    {
                        cachedGeneralProperties = CoreManager.MomConsole.GetIntlStr(ResourceGeneralProperties);
                    }
                    
                    return cachedGeneralProperties;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Script translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 1/23/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Script
            {
                get
                {
                    if ((cachedScript == null))
                    {
                        cachedScript = CoreManager.MomConsole.GetIntlStr(ResourceScript);
                    }
                    
                    return cachedScript;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ClickTheParametersButtonToSpecifyTheScriptParameters translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 1/23/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ClickTheParametersButtonToSpecifyTheScriptParameters
            {
                get
                {
                    if ((cachedClickTheParametersButtonToSpecifyTheScriptParameters == null))
                    {
                        cachedClickTheParametersButtonToSpecifyTheScriptParameters = CoreManager.MomConsole.GetIntlStr(ResourceClickTheParametersButtonToSpecifyTheScriptParameters);
                    }
                    
                    return cachedClickTheParametersButtonToSpecifyTheScriptParameters;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ExampleMyScriptvbs translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 1/23/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ExampleMyScriptvbs
            {
                get
                {
                    if ((cachedExampleMyScriptvbs == null))
                    {
                        cachedExampleMyScriptvbs = CoreManager.MomConsole.GetIntlStr(ResourceExampleMyScriptvbs);
                    }
                    
                    return cachedExampleMyScriptvbs;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EnterScriptInformation translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 1/23/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EnterScriptInformation
            {
                get
                {
                    if ((cachedEnterScriptInformation == null))
                    {
                        cachedEnterScriptInformation = CoreManager.MomConsole.GetIntlStr(ResourceEnterScriptInformation);
                    }
                    
                    return cachedEnterScriptInformation;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Parameters translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 1/23/2007 Created
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
            /// Exposes access to the EditInFullScreen translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 1/23/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EditInFullScreen
            {
                get
                {
                    if ((cachedEditInFullScreen == null))
                    {
                        cachedEditInFullScreen = CoreManager.MomConsole.GetIntlStr(ResourceEditInFullScreen);
                    }
                    
                    return cachedEditInFullScreen;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Script2 translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 1/23/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Script2
            {
                get
                {
                    if ((cachedScript2 == null))
                    {
                        cachedScript2 = CoreManager.MomConsole.GetIntlStr(ResourceScript2);
                    }
                    
                    return cachedScript2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Timeout translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 1/23/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Timeout
            {
                get
                {
                    if ((cachedTimeout == null))
                    {
                        cachedTimeout = CoreManager.MomConsole.GetIntlStr(ResourceTimeout);
                    }
                    
                    return cachedTimeout;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the FileName translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 1/23/2007 Created
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
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 1/23/2007 Created
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
            /// Exposes access to the Script3 translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 1/23/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Script3
            {
                get
                {
                    if ((cachedScript3 == null))
                    {
                        cachedScript3 = CoreManager.MomConsole.GetIntlStr(ResourceScript3);
                    }
                    
                    return cachedScript3;
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
        /// 	[faizalk] 1/23/2007 Created
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
            /// Control ID for TaskTypeStaticControl
            /// </summary>
            public const string TaskTypeStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for GeneralPropertiesStaticControl
            /// </summary>
            public const string GeneralPropertiesStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ScriptStaticControl
            /// </summary>
            public const string ScriptStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ClickTheParametersButtonToSpecifyTheScriptParametersStaticControl
            /// </summary>
            public const string ClickTheParametersButtonToSpecifyTheScriptParametersStaticControl = "label1";
            
            /// <summary>
            /// Control ID for ExampleMyScriptvbsStaticControl
            /// </summary>
            public const string ExampleMyScriptvbsStaticControl = "idLabelExample";
            
            /// <summary>
            /// Control ID for ExampleMyScriptvbsComboBox
            /// </summary>
            public const string ExampleMyScriptvbsComboBox = "comboBoxUnit";
            
            /// <summary>
            /// Control ID for TimeoutComboBox
            /// </summary>
            public const string TimeoutComboBox = "numericDropDown";
            
            /// <summary>
            /// Control ID for EnterScriptInformationStaticControl
            /// </summary>
            public const string EnterScriptInformationStaticControl = "pageSectionLabel1";
            
            /// <summary>
            /// Control ID for ParametersButton
            /// </summary>
            public const string ParametersButton = "btnParameters";
            
            /// <summary>
            /// Control ID for EditInFullScreenButton
            /// </summary>
            public const string EditInFullScreenButton = "btnEdit";
            
            /// <summary>
            /// Control ID for ScriptTextBox
            /// </summary>
            public const string ScriptTextBox = "scriptSyntaxBox";
            
            /// <summary>
            /// Control ID for ScriptStaticControl2
            /// </summary>
            public const string ScriptStaticControl2 = "lblScript";
            
            /// <summary>
            /// Control ID for TimeoutStaticControl
            /// </summary>
            public const string TimeoutStaticControl = "lblTimeout";
            
            /// <summary>
            /// Control ID for FileNameTextBox
            /// </summary>
            public const string FileNameTextBox = "txtName";
            
            /// <summary>
            /// Control ID for FileNameStaticControl
            /// </summary>
            public const string FileNameStaticControl = "lblName";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for ScriptStaticControl3
            /// </summary>
            public const string ScriptStaticControl3 = "headerLabel";
        }
        #endregion
    }
}
