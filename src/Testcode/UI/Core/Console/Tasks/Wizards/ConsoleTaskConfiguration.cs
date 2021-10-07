// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ConsoleTaskConfiguration.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[faizalk] 4/24/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Tasks.Wizards
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IConsoleTaskConfigurationControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IConsoleTaskConfigurationControls, for ConsoleTaskConfiguration.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[faizalk] 4/24/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IConsoleTaskConfigurationControls
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
        /// Read-only property to access CommandLineStaticControl
        /// </summary>
        StaticControl CommandLineStaticControl
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
        /// Read-only property to access Button1
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Button Button1
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DisplayOutputCheckBox
        /// </summary>
        CheckBox DisplayOutputCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TotalResponseTimeMillisecondsTextBox
        /// </summary>
        TextBox TotalResponseTimeMillisecondsTextBox
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
        /// Read-only property to access RequestProcessedSuccessfullyTextBox
        /// </summary>
        TextBox RequestProcessedSuccessfullyTextBox
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
        /// Read-only property to access ProviderTextBox
        /// </summary>
        TextBox ProviderTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ApplicationStaticControl
        /// </summary>
        StaticControl ApplicationStaticControl
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
        /// Read-only property to access GeneralPropertiesStaticControl2
        /// </summary>
        StaticControl GeneralPropertiesStaticControl2
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
    /// 	[faizalk] 4/24/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ConsoleTaskConfiguration : Dialog, IConsoleTaskConfigurationControls
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
        /// Cache to hold a reference to CommandLineStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCommandLineStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to Ellipsis0Button of type Button
        /// </summary>
        private Button cachedEllipsis0Button;
        
        /// <summary>
        /// Cache to hold a reference to Button1 of type Button
        /// </summary>
        private Button cachedButton1;
        
        /// <summary>
        /// Cache to hold a reference to DisplayOutputCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedDisplayOutputCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to TotalResponseTimeMillisecondsTextBox of type TextBox
        /// </summary>
        private TextBox cachedTotalResponseTimeMillisecondsTextBox;
        
        /// <summary>
        /// Cache to hold a reference to DirectoryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDirectoryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to RequestProcessedSuccessfullyTextBox of type TextBox
        /// </summary>
        private TextBox cachedRequestProcessedSuccessfullyTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ParametersStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedParametersStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ProviderTextBox of type TextBox
        /// </summary>
        private TextBox cachedProviderTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ApplicationStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedApplicationStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to GeneralPropertiesStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralPropertiesStaticControl2;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ConsoleTaskConfiguration of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ConsoleTaskConfiguration(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IConsoleTaskConfiguration Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IConsoleTaskConfigurationControls Controls
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
        ///  Property to handle checkbox DisplayOutput
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool DisplayOutput
        {
            get
            {
                return this.Controls.DisplayOutputCheckBox.Checked;
            }
            
            set
            {
                this.Controls.DisplayOutputCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TotalResponseTimeMilliseconds
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TotalResponseTimeMillisecondsText
        {
            get
            {
                return this.Controls.TotalResponseTimeMillisecondsTextBox.Text;
            }
            
            set
            {
                this.Controls.TotalResponseTimeMillisecondsTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control RequestProcessedSuccessfully
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string RequestProcessedSuccessfullyText
        {
            get
            {
                return this.Controls.RequestProcessedSuccessfullyTextBox.Text;
            }
            
            set
            {
                this.Controls.RequestProcessedSuccessfullyTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Provider
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ProviderText
        {
            get
            {
                return this.Controls.ProviderTextBox.Text;
            }
            
            set
            {
                this.Controls.ProviderTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConsoleTaskConfigurationControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, ConsoleTaskConfiguration.ControlIDs.PreviousButton);
                }
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConsoleTaskConfigurationControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, ConsoleTaskConfiguration.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConsoleTaskConfigurationControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, ConsoleTaskConfiguration.ControlIDs.CreateButton);
                }
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConsoleTaskConfigurationControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ConsoleTaskConfiguration.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TaskTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConsoleTaskConfigurationControls.TaskTypeStaticControl
        {
            get
            {
                if ((this.cachedTaskTypeStaticControl == null))
                {
                    this.cachedTaskTypeStaticControl = new StaticControl(this, ConsoleTaskConfiguration.ControlIDs.TaskTypeStaticControl);
                }
                return this.cachedTaskTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralPropertiesStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConsoleTaskConfigurationControls.GeneralPropertiesStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedGeneralPropertiesStaticControl == null))
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
        ///  Exposes access to the CommandLineStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConsoleTaskConfigurationControls.CommandLineStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedCommandLineStaticControl == null))
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
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedCommandLineStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedCommandLineStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Ellipsis0Button control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConsoleTaskConfigurationControls.Ellipsis0Button
        {
            get
            {
                if ((this.cachedEllipsis0Button == null))
                {
                    this.cachedEllipsis0Button = new Button(this, ConsoleTaskConfiguration.ControlIDs.Ellipsis0Button);
                }
                return this.cachedEllipsis0Button;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Button1 control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConsoleTaskConfigurationControls.Button1
        {
            get
            {
                if ((this.cachedButton1 == null))
                {
                    this.cachedButton1 = new Button(this, ConsoleTaskConfiguration.ControlIDs.Button1);
                }
                return this.cachedButton1;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DisplayOutputCheckBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IConsoleTaskConfigurationControls.DisplayOutputCheckBox
        {
            get
            {
                if ((this.cachedDisplayOutputCheckBox == null))
                {
                    this.cachedDisplayOutputCheckBox = new CheckBox(this, ConsoleTaskConfiguration.ControlIDs.DisplayOutputCheckBox);
                }
                return this.cachedDisplayOutputCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TotalResponseTimeMillisecondsTextBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IConsoleTaskConfigurationControls.TotalResponseTimeMillisecondsTextBox
        {
            get
            {
                if ((this.cachedTotalResponseTimeMillisecondsTextBox == null))
                {
                    this.cachedTotalResponseTimeMillisecondsTextBox = new TextBox(this, ConsoleTaskConfiguration.ControlIDs.TotalResponseTimeMillisecondsTextBox);
                }
                return this.cachedTotalResponseTimeMillisecondsTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DirectoryStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConsoleTaskConfigurationControls.DirectoryStaticControl
        {
            get
            {
                if ((this.cachedDirectoryStaticControl == null))
                {
                    this.cachedDirectoryStaticControl = new StaticControl(this, ConsoleTaskConfiguration.ControlIDs.DirectoryStaticControl);
                }
                return this.cachedDirectoryStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RequestProcessedSuccessfullyTextBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IConsoleTaskConfigurationControls.RequestProcessedSuccessfullyTextBox
        {
            get
            {
                if ((this.cachedRequestProcessedSuccessfullyTextBox == null))
                {
                    this.cachedRequestProcessedSuccessfullyTextBox = new TextBox(this, ConsoleTaskConfiguration.ControlIDs.RequestProcessedSuccessfullyTextBox);
                }
                return this.cachedRequestProcessedSuccessfullyTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ParametersStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConsoleTaskConfigurationControls.ParametersStaticControl
        {
            get
            {
                if ((this.cachedParametersStaticControl == null))
                {
                    this.cachedParametersStaticControl = new StaticControl(this, ConsoleTaskConfiguration.ControlIDs.ParametersStaticControl);
                }
                return this.cachedParametersStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ProviderTextBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IConsoleTaskConfigurationControls.ProviderTextBox
        {
            get
            {
                if ((this.cachedProviderTextBox == null))
                {
                    this.cachedProviderTextBox = new TextBox(this, ConsoleTaskConfiguration.ControlIDs.ProviderTextBox);
                }
                return this.cachedProviderTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApplicationStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConsoleTaskConfigurationControls.ApplicationStaticControl
        {
            get
            {
                if ((this.cachedApplicationStaticControl == null))
                {
                    this.cachedApplicationStaticControl = new StaticControl(this, ConsoleTaskConfiguration.ControlIDs.ApplicationStaticControl);
                }
                return this.cachedApplicationStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConsoleTaskConfigurationControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, ConsoleTaskConfiguration.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralPropertiesStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConsoleTaskConfigurationControls.GeneralPropertiesStaticControl2
        {
            get
            {
                if ((this.cachedGeneralPropertiesStaticControl2 == null))
                {
                    this.cachedGeneralPropertiesStaticControl2 = new StaticControl(this, ConsoleTaskConfiguration.ControlIDs.GeneralPropertiesStaticControl2);
                }
                return this.cachedGeneralPropertiesStaticControl2;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
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
        /// 	[faizalk] 4/24/2006 Created
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
        /// 	[faizalk] 4/24/2006 Created
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
        /// 	[faizalk] 4/24/2006 Created
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
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEllipsis0()
        {
            this.Controls.Ellipsis0Button.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Button1
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickButton1()
        {
            this.Controls.Button1.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button DisplayOutput
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickDisplayOutput()
        {
            this.Controls.DisplayOutputCheckBox.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">MomConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(app.GetIntlStr(Strings.DialogTitle), StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
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
                                app.GetIntlStr(Strings.DialogTitle) + "*",
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
                        //sleep to wait for window search
                        Sleeper.Delay(Timeout);

                        // log the outcome of this attempt
                        Core.Common.Utilities.LogMessage("Attempt "
                            + numberOfTries
                            + " of "
                            + MaxTries
                            + "...");
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure

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
        /// 	[faizalk] 4/24/2006 Created
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
            private const string ResourcePrevious = ";< &Previous;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.Enterp" +
                "riseManagement.Mom.Internal.UI.PageFramework.WizardButtonsPanel;previousButton.T" +
                "ext";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext = ";&Next >;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement" +
                ".Mom.Internal.UI.PageFrameworks.WizardFramework;buttonNext.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Create
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCreate = ";C&reate;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft." +
                "EnterpriseManagement.Internal.UI.Authoring.Common.CommonResources;CreateMPAction" +
                "";

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
            private const string ResourceGeneralProperties = ";General Properties;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll" +
                ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.NameAndDescriptionPa" +
                "ge;$this.NavigationText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CommandLine
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCommandLine = ";Command Line;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micro" +
                "soft.EnterpriseManagement.Internal.UI.Authoring.Pages.CommandWriteActionPage;$th" +
                "is.TabName";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Ellipsis3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEllipsis0 = ";...;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.A" +
                "ppearanceProperties;buttonBackColor.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DisplayOutput
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDisplayOutput = ";Display Output;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Mic" +
                "rosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ConsoleTaskCommandPage;d" +
                "isplayOutput.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Directory
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDirectory = ";Directory:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microso" +
                "ft.EnterpriseManagement.Internal.UI.Authoring.Pages.ConsoleTaskCommandPage;direc" +
                "toryLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Parameters
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceParameters = ";Parameters:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micros" +
                "oft.EnterpriseManagement.Internal.UI.Authoring.Pages.ConsoleTaskCommandPage;para" +
                "metersLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Application
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceApplication = ";Application:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micro" +
                "soft.EnterpriseManagement.Internal.UI.Authoring.Pages.ConsoleTaskCommandPage;app" +
                "licationLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.Ent" +
                "erpriseManagement.Internal.UI.Authoring.Common.CommonResources;CommandHelp";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  GeneralProperties2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneralProperties2 = ";General Properties;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll" +
                ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.NameAndDescriptionPa" +
                "ge;$this.NavigationText";
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
            /// Caches the translated resource string for:  CommandLine
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCommandLine;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Ellipsis0
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEllipsis0;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DisplayOutput
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDisplayOutput;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Directory
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDirectory;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Parameters
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedParameters;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Application
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedApplication;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  GeneralProperties2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneralProperties2;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/24/2006 Created
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
            /// 	[faizalk] 4/24/2006 Created
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
            /// 	[faizalk] 4/24/2006 Created
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
            /// 	[faizalk] 4/24/2006 Created
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
            /// 	[faizalk] 4/24/2006 Created
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
            /// 	[faizalk] 4/24/2006 Created
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
            /// 	[faizalk] 4/24/2006 Created
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
            /// Exposes access to the CommandLine translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CommandLine
            {
                get
                {
                    if ((cachedCommandLine == null))
                    {
                        cachedCommandLine = CoreManager.MomConsole.GetIntlStr(ResourceCommandLine);
                    }
                    return cachedCommandLine;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Ellipsis0 translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/24/2006 Created
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
            /// Exposes access to the DisplayOutput translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DisplayOutput
            {
                get
                {
                    if ((cachedDisplayOutput == null))
                    {
                        cachedDisplayOutput = CoreManager.MomConsole.GetIntlStr(ResourceDisplayOutput);
                    }
                    return cachedDisplayOutput;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Directory translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/24/2006 Created
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
            /// Exposes access to the Parameters translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/24/2006 Created
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
            /// Exposes access to the Application translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Application
            {
                get
                {
                    if ((cachedApplication == null))
                    {
                        cachedApplication = CoreManager.MomConsole.GetIntlStr(ResourceApplication);
                    }
                    return cachedApplication;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/24/2006 Created
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
            /// Exposes access to the GeneralProperties2 translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string GeneralProperties2
            {
                get
                {
                    if ((cachedGeneralProperties2 == null))
                    {
                        cachedGeneralProperties2 = CoreManager.MomConsole.GetIntlStr(ResourceGeneralProperties2);
                    }
                    return cachedGeneralProperties2;
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
        /// 	[faizalk] 4/24/2006 Created
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
            /// Control ID for CommandLineStaticControl
            /// </summary>
            public const string CommandLineStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for Ellipsis0Button
            /// </summary>
            public const string Ellipsis0Button = "browse";
            
            /// <summary>
            /// Control ID for Button1
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Button1 = "placeHolder";
            
            /// <summary>
            /// Control ID for DisplayOutputCheckBox
            /// </summary>
            public const string DisplayOutputCheckBox = "displayOutput";
            
            /// <summary>
            /// Control ID for TotalResponseTimeMillisecondsTextBox
            /// </summary>
            public const string TotalResponseTimeMillisecondsTextBox = "directoryBox";
            
            /// <summary>
            /// Control ID for DirectoryStaticControl
            /// </summary>
            public const string DirectoryStaticControl = "directoryLabel";
            
            /// <summary>
            /// Control ID for RequestProcessedSuccessfullyTextBox
            /// </summary>
            public const string RequestProcessedSuccessfullyTextBox = "parametersBox";
            
            /// <summary>
            /// Control ID for ParametersStaticControl
            /// </summary>
            public const string ParametersStaticControl = "parametersLabel";
            
            /// <summary>
            /// Control ID for ProviderTextBox
            /// </summary>
            public const string ProviderTextBox = "applicationBox";
            
            /// <summary>
            /// Control ID for ApplicationStaticControl
            /// </summary>
            public const string ApplicationStaticControl = "applicationLabel";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for GeneralPropertiesStaticControl2
            /// </summary>
            public const string GeneralPropertiesStaticControl2 = "headerLabel";
        }
        #endregion
    }
}
