// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="EnterAndTestPortSettingsDialog.cs">
// 	Copyright (c) Microsoft Corporation 2007
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[faizalk] 4/13/2007 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Port.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IEnterAndTestPortSettingsDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IEnterAndTestPortSettingsDialogControls, for EnterAndTestPortSettingsDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[faizalk] 4/13/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IEnterAndTestPortSettingsDialogControls
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
        /// Read-only property to access MonitoringTypeStaticControl
        /// </summary>
        StaticControl MonitoringTypeStaticControl
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
        /// Read-only property to access TargetAndPortStaticControl
        /// </summary>
        StaticControl TargetAndPortStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WatcherNodeStaticControl
        /// </summary>
        StaticControl WatcherNodeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SummaryStaticControl
        /// </summary>
        StaticControl SummaryStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PortTextBox
        /// </summary>
        TextBox PortTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PortStaticControl
        /// </summary>
        StaticControl PortStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RequestProcessedSuccessfullyStaticControl
        /// </summary>
        StaticControl RequestProcessedSuccessfullyStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RequestProcessedSuccessfullyListView
        /// </summary>
        ListView RequestProcessedSuccessfullyListView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TestButton
        /// </summary>
        Button TestButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access IPAddressOrDeviceNameTextBox
        /// </summary>
        TextBox IPAddressOrDeviceNameTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access IPAddressOrDeviceNameStaticControl
        /// </summary>
        StaticControl IPAddressOrDeviceNameStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EnterTheIPAddressAndPortThatYouWantToMonitorStaticControl
        /// </summary>
        StaticControl EnterTheIPAddressAndPortThatYouWantToMonitorStaticControl
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
        /// Read-only property to access EnterAndTestPortSettingsStaticControl
        /// </summary>
        StaticControl EnterAndTestPortSettingsStaticControl
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
    /// 	[faizalk] 4/13/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class EnterAndTestPortSettingsDialog : Dialog, IEnterAndTestPortSettingsDialogControls
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
        /// Cache to hold a reference to MonitoringTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMonitoringTypeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to GeneralPropertiesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralPropertiesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to TargetAndPortStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTargetAndPortStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to WatcherNodeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWatcherNodeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SummaryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSummaryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to PortTextBox of type TextBox
        /// </summary>
        private TextBox cachedPortTextBox;
        
        /// <summary>
        /// Cache to hold a reference to PortStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPortStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to RequestProcessedSuccessfullyStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRequestProcessedSuccessfullyStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to RequestProcessedSuccessfullyListView of type ListView
        /// </summary>
        private ListView cachedRequestProcessedSuccessfullyListView;
        
        /// <summary>
        /// Cache to hold a reference to TestButton of type Button
        /// </summary>
        private Button cachedTestButton;
        
        /// <summary>
        /// Cache to hold a reference to IPAddressOrDeviceNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedIPAddressOrDeviceNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to IPAddressOrDeviceNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedIPAddressOrDeviceNameStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to EnterTheIPAddressAndPortThatYouWantToMonitorStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEnterTheIPAddressAndPortThatYouWantToMonitorStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to EnterAndTestPortSettingsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEnterAndTestPortSettingsStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of EnterAndTestPortSettingsDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[faizalk] 4/13/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public EnterAndTestPortSettingsDialog(ConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IEnterAndTestPortSettingsDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[faizalk] 4/13/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IEnterAndTestPortSettingsDialogControls Controls
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
        ///  Routine to set/get the text in control Port
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 4/13/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string PortText
        {
            get
            {
                return this.Controls.PortTextBox.Text;
            }
            
            set
            {
                this.Controls.PortTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control IPAddressOrDeviceName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 4/13/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string IPAddressOrDeviceNameText
        {
            get
            {
                return this.Controls.IPAddressOrDeviceNameTextBox.Text;
            }
            
            set
            {
                this.Controls.IPAddressOrDeviceNameTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/13/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEnterAndTestPortSettingsDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, EnterAndTestPortSettingsDialog.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/13/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEnterAndTestPortSettingsDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, EnterAndTestPortSettingsDialog.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/13/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEnterAndTestPortSettingsDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, EnterAndTestPortSettingsDialog.ControlIDs.CreateButton);
                }
                
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/13/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEnterAndTestPortSettingsDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, EnterAndTestPortSettingsDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitoringTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/13/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEnterAndTestPortSettingsDialogControls.MonitoringTypeStaticControl
        {
            get
            {
                if ((this.cachedMonitoringTypeStaticControl == null))
                {
                    this.cachedMonitoringTypeStaticControl = new StaticControl(this, EnterAndTestPortSettingsDialog.ControlIDs.MonitoringTypeStaticControl);
                }
                
                return this.cachedMonitoringTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralPropertiesStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/13/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEnterAndTestPortSettingsDialogControls.GeneralPropertiesStaticControl
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
        ///  Exposes access to the TargetAndPortStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/13/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEnterAndTestPortSettingsDialogControls.TargetAndPortStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedTargetAndPortStaticControl == null))
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
                    this.cachedTargetAndPortStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedTargetAndPortStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WatcherNodeStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/13/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEnterAndTestPortSettingsDialogControls.WatcherNodeStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedWatcherNodeStaticControl == null))
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
                    this.cachedWatcherNodeStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedWatcherNodeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SummaryStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/13/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEnterAndTestPortSettingsDialogControls.SummaryStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedSummaryStaticControl == null))
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
                    this.cachedSummaryStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedSummaryStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PortTextBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/13/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IEnterAndTestPortSettingsDialogControls.PortTextBox
        {
            get
            {
                if ((this.cachedPortTextBox == null))
                {
                    this.cachedPortTextBox = new TextBox(this, EnterAndTestPortSettingsDialog.ControlIDs.PortTextBox);
                }
                
                return this.cachedPortTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PortStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/13/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEnterAndTestPortSettingsDialogControls.PortStaticControl
        {
            get
            {
                if ((this.cachedPortStaticControl == null))
                {
                    this.cachedPortStaticControl = new StaticControl(this, EnterAndTestPortSettingsDialog.ControlIDs.PortStaticControl);
                }
                
                return this.cachedPortStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RequestProcessedSuccessfullyStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/13/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEnterAndTestPortSettingsDialogControls.RequestProcessedSuccessfullyStaticControl
        {
            get
            {
                if ((this.cachedRequestProcessedSuccessfullyStaticControl == null))
                {
                    this.cachedRequestProcessedSuccessfullyStaticControl = new StaticControl(this, EnterAndTestPortSettingsDialog.ControlIDs.RequestProcessedSuccessfullyStaticControl);
                }
                
                return this.cachedRequestProcessedSuccessfullyStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RequestProcessedSuccessfullyListView control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/13/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IEnterAndTestPortSettingsDialogControls.RequestProcessedSuccessfullyListView
        {
            get
            {
                if ((this.cachedRequestProcessedSuccessfullyListView == null))
                {
                    this.cachedRequestProcessedSuccessfullyListView = new ListView(this, EnterAndTestPortSettingsDialog.ControlIDs.RequestProcessedSuccessfullyListView);
                }
                
                return this.cachedRequestProcessedSuccessfullyListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TestButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/13/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEnterAndTestPortSettingsDialogControls.TestButton
        {
            get
            {
                if ((this.cachedTestButton == null))
                {
                    this.cachedTestButton = new Button(this, EnterAndTestPortSettingsDialog.ControlIDs.TestButton);
                }
                
                return this.cachedTestButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IPAddressOrDeviceNameTextBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/13/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IEnterAndTestPortSettingsDialogControls.IPAddressOrDeviceNameTextBox
        {
            get
            {
                if ((this.cachedIPAddressOrDeviceNameTextBox == null))
                {
                    this.cachedIPAddressOrDeviceNameTextBox = new TextBox(this, EnterAndTestPortSettingsDialog.ControlIDs.IPAddressOrDeviceNameTextBox);
                }
                
                return this.cachedIPAddressOrDeviceNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IPAddressOrDeviceNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/13/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEnterAndTestPortSettingsDialogControls.IPAddressOrDeviceNameStaticControl
        {
            get
            {
                if ((this.cachedIPAddressOrDeviceNameStaticControl == null))
                {
                    this.cachedIPAddressOrDeviceNameStaticControl = new StaticControl(this, EnterAndTestPortSettingsDialog.ControlIDs.IPAddressOrDeviceNameStaticControl);
                }
                
                return this.cachedIPAddressOrDeviceNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EnterTheIPAddressAndPortThatYouWantToMonitorStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/13/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEnterAndTestPortSettingsDialogControls.EnterTheIPAddressAndPortThatYouWantToMonitorStaticControl
        {
            get
            {
                if ((this.cachedEnterTheIPAddressAndPortThatYouWantToMonitorStaticControl == null))
                {
                    this.cachedEnterTheIPAddressAndPortThatYouWantToMonitorStaticControl = new StaticControl(this, EnterAndTestPortSettingsDialog.ControlIDs.EnterTheIPAddressAndPortThatYouWantToMonitorStaticControl);
                }
                
                return this.cachedEnterTheIPAddressAndPortThatYouWantToMonitorStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/13/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEnterAndTestPortSettingsDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, EnterAndTestPortSettingsDialog.ControlIDs.HelpStaticControl);
                }
                
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EnterAndTestPortSettingsStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/13/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEnterAndTestPortSettingsDialogControls.EnterAndTestPortSettingsStaticControl
        {
            get
            {
                if ((this.cachedEnterAndTestPortSettingsStaticControl == null))
                {
                    this.cachedEnterAndTestPortSettingsStaticControl = new StaticControl(this, EnterAndTestPortSettingsDialog.ControlIDs.EnterAndTestPortSettingsStaticControl);
                }
                
                return this.cachedEnterAndTestPortSettingsStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/13/2007 Created
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
        /// 	[faizalk] 4/13/2007 Created
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
        /// 	[faizalk] 4/13/2007 Created
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
        /// 	[faizalk] 4/13/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Test
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/13/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickTest()
        {
            this.Controls.TestButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">ConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[faizalk] 4/13/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
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
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/13/2007 Created
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
            private const string ResourceDialogTitle = ";Add Monitoring Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Common.PageCommonResources;TemplateWizard";
            
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
            /// Contains resource string for:  MonitoringType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMonitoringType = ";Monitoring Type;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Mi" +
                "crosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.TemplateListPage;$this." +
                "NavigationText";
            
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
            /// Contains resource string for:  TargetAndPort
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTargetAndPort = "Target and Port";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WatcherNode
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWatcherNode = ";Watcher Node;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micro" +
                "soft.EnterpriseManagement.Internal.UI.Authoring.Pages.ChooseWatcherNodesPage;$th" +
                "is.NavigationText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Summary
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSummary = ";Summary;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;SummaryT" +
                "itle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Port
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePort = ";P&ort:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.E" +
                "nterpriseManagement.Internal.UI.Authoring.Pages.ServerNameAndPortPage;labelPort." +
                "Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RequestProcessedSuccessfully
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRequestProcessedSuccessfully = ";Request processed successfully;ManagedString;Microsoft.EnterpriseManagement.UI.A" +
                "uthoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.TCPPortC" +
                "heckTemplate.TCPPortCheckTemplateResource;StatusSuccess";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Test
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTest = ";&Test;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.En" +
                "terpriseManagement.Internal.UI.Authoring.Pages.ChooseURLPage;buttonTest.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  IPAddressOrDeviceName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceIPAddressOrDeviceName = ";&IP address or device name:;ManagedString;Microsoft.EnterpriseManagement.UI.Auth" +
                "oring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ServerNameA" +
                "ndPortPage;labelIPAddress.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EnterTheIPAddressAndPortThatYouWantToMonitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEnterTheIPAddressAndPortThatYouWantToMonitor = ";Enter the IP address and port that you want to monitor;ManagedString;Microsoft.E" +
                "nterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI." +
                "Authoring.Pages.ServerNameAndPortPage;pageSectionLabel.Text";
            
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
            /// Contains resource string for:  EnterAndTestPortSettings
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceEnterAndTestPortSettings = "Enter and Test Port Settings";
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
            /// Caches the translated resource string for:  MonitoringType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonitoringType;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  GeneralProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneralProperties;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TargetAndPort
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTargetAndPort;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WatcherNode
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWatcherNode;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Summary
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSummary;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Port
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPort;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RequestProcessedSuccessfully
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRequestProcessedSuccessfully;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Test
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTest;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  IPAddressOrDeviceName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedIPAddressOrDeviceName;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EnterTheIPAddressAndPortThatYouWantToMonitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEnterTheIPAddressAndPortThatYouWantToMonitor;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EnterAndTestPortSettings
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEnterAndTestPortSettings;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/13/2007 Created
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
            /// 	[faizalk] 4/13/2007 Created
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
            /// 	[faizalk] 4/13/2007 Created
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
            /// 	[faizalk] 4/13/2007 Created
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
            /// 	[faizalk] 4/13/2007 Created
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
            /// Exposes access to the MonitoringType translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/13/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MonitoringType
            {
                get
                {
                    if ((cachedMonitoringType == null))
                    {
                        cachedMonitoringType = CoreManager.MomConsole.GetIntlStr(ResourceMonitoringType);
                    }
                    
                    return cachedMonitoringType;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the GeneralProperties translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/13/2007 Created
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
            /// Exposes access to the TargetAndPort translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/13/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TargetAndPort
            {
                get
                {
                    if ((cachedTargetAndPort == null))
                    {
                        cachedTargetAndPort = CoreManager.MomConsole.GetIntlStr(ResourceTargetAndPort);
                    }
                    
                    return cachedTargetAndPort;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WatcherNode translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/13/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WatcherNode
            {
                get
                {
                    if ((cachedWatcherNode == null))
                    {
                        cachedWatcherNode = CoreManager.MomConsole.GetIntlStr(ResourceWatcherNode);
                    }
                    
                    return cachedWatcherNode;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Summary translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/13/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Summary
            {
                get
                {
                    if ((cachedSummary == null))
                    {
                        cachedSummary = CoreManager.MomConsole.GetIntlStr(ResourceSummary);
                    }
                    
                    return cachedSummary;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Port translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/13/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Port
            {
                get
                {
                    if ((cachedPort == null))
                    {
                        cachedPort = CoreManager.MomConsole.GetIntlStr(ResourcePort);
                    }
                    
                    return cachedPort;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RequestProcessedSuccessfully translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/13/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RequestProcessedSuccessfully
            {
                get
                {
                    if ((cachedRequestProcessedSuccessfully == null))
                    {
                        cachedRequestProcessedSuccessfully = CoreManager.MomConsole.GetIntlStr(ResourceRequestProcessedSuccessfully);
                    }
                    
                    return cachedRequestProcessedSuccessfully;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Test translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/13/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Test
            {
                get
                {
                    if ((cachedTest == null))
                    {
                        cachedTest = CoreManager.MomConsole.GetIntlStr(ResourceTest);
                    }
                    
                    return cachedTest;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the IPAddressOrDeviceName translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/13/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string IPAddressOrDeviceName
            {
                get
                {
                    if ((cachedIPAddressOrDeviceName == null))
                    {
                        cachedIPAddressOrDeviceName = CoreManager.MomConsole.GetIntlStr(ResourceIPAddressOrDeviceName);
                    }
                    
                    return cachedIPAddressOrDeviceName;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EnterTheIPAddressAndPortThatYouWantToMonitor translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/13/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EnterTheIPAddressAndPortThatYouWantToMonitor
            {
                get
                {
                    if ((cachedEnterTheIPAddressAndPortThatYouWantToMonitor == null))
                    {
                        cachedEnterTheIPAddressAndPortThatYouWantToMonitor = CoreManager.MomConsole.GetIntlStr(ResourceEnterTheIPAddressAndPortThatYouWantToMonitor);
                    }
                    
                    return cachedEnterTheIPAddressAndPortThatYouWantToMonitor;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/13/2007 Created
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
            /// Exposes access to the EnterAndTestPortSettings translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/13/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EnterAndTestPortSettings
            {
                get
                {
                    if ((cachedEnterAndTestPortSettings == null))
                    {
                        cachedEnterAndTestPortSettings = CoreManager.MomConsole.GetIntlStr(ResourceEnterAndTestPortSettings);
                    }
                    
                    return cachedEnterAndTestPortSettings;
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
        /// 	[faizalk] 4/13/2007 Created
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
            /// Control ID for MonitoringTypeStaticControl
            /// </summary>
            public const string MonitoringTypeStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for GeneralPropertiesStaticControl
            /// </summary>
            public const string GeneralPropertiesStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for TargetAndPortStaticControl
            /// </summary>
            public const string TargetAndPortStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for WatcherNodeStaticControl
            /// </summary>
            public const string WatcherNodeStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for SummaryStaticControl
            /// </summary>
            public const string SummaryStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for PortTextBox
            /// </summary>
            public const string PortTextBox = "textBoxPort";
            
            /// <summary>
            /// Control ID for PortStaticControl
            /// </summary>
            public const string PortStaticControl = "labelPort";
            
            /// <summary>
            /// Control ID for RequestProcessedSuccessfullyStaticControl
            /// </summary>
            public const string RequestProcessedSuccessfullyStaticControl = "labelStatus";
            
            /// <summary>
            /// Control ID for RequestProcessedSuccessfullyListView
            /// </summary>
            public const string RequestProcessedSuccessfullyListView = "listView";
            
            /// <summary>
            /// Control ID for TestButton
            /// </summary>
            public const string TestButton = "buttonTest";
            
            /// <summary>
            /// Control ID for IPAddressOrDeviceNameTextBox
            /// </summary>
            public const string IPAddressOrDeviceNameTextBox = "textBoxServerName";
            
            /// <summary>
            /// Control ID for IPAddressOrDeviceNameStaticControl
            /// </summary>
            public const string IPAddressOrDeviceNameStaticControl = "labelIPAddress";
            
            /// <summary>
            /// Control ID for EnterTheIPAddressAndPortThatYouWantToMonitorStaticControl
            /// </summary>
            public const string EnterTheIPAddressAndPortThatYouWantToMonitorStaticControl = "pageSectionLabel";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for EnterAndTestPortSettingsStaticControl
            /// </summary>
            public const string EnterAndTestPortSettingsStaticControl = "headerLabel";
        }
        #endregion
    }
}
