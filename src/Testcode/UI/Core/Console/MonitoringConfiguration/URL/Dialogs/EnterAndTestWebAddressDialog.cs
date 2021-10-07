// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="EnterAndTestWebAddressDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[faizalk] 4/30/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.URL.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IEnterAndTestWebAddressDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IEnterAndTestWebAddressDialogControls, for EnterAndTestWebAddressDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[faizalk] 4/30/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IEnterAndTestWebAddressDialogControls
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
        /// Read-only property to access WebAddressStaticControl
        /// </summary>
        StaticControl WebAddressStaticControl
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
        /// Read-only property to access URLComboBox
        /// </summary>
        ComboBox URLComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EnterAndTestYourURLTextBox
        /// </summary>
        TextBox EnterAndTestYourURLTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TheExecutionOfTheTaskReturnedAnErrorStaticControl
        /// </summary>
        StaticControl TheExecutionOfTheTaskReturnedAnErrorStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DetailsButton
        /// </summary>
        Button DetailsButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ErrorResultsListView
        /// </summary>
        ListView ErrorResultsListView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ErrorResultsStaticControl
        /// </summary>
        StaticControl ErrorResultsStaticControl
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
        /// Read-only property to access URLStaticControl
        /// </summary>
        StaticControl URLStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EnterAndTestYourURLStaticControl
        /// </summary>
        StaticControl EnterAndTestYourURLStaticControl
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
        /// Read-only property to access EnterAndTestWebAddressStaticControl
        /// </summary>
        StaticControl EnterAndTestWebAddressStaticControl
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
    /// 	[faizalk] 4/30/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class EnterAndTestWebAddressDialog : Dialog, IEnterAndTestWebAddressDialogControls
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
        /// Cache to hold a reference to WebAddressStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWebAddressStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to WatcherNodeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWatcherNodeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SummaryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSummaryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to URLComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedURLComboBox;
        
        /// <summary>
        /// Cache to hold a reference to EnterAndTestYourURLTextBox of type TextBox
        /// </summary>
        private TextBox cachedEnterAndTestYourURLTextBox;
        
        /// <summary>
        /// Cache to hold a reference to TheExecutionOfTheTaskReturnedAnErrorStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTheExecutionOfTheTaskReturnedAnErrorStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DetailsButton of type Button
        /// </summary>
        private Button cachedDetailsButton;
        
        /// <summary>
        /// Cache to hold a reference to ErrorResultsListView of type ListView
        /// </summary>
        private ListView cachedErrorResultsListView;
        
        /// <summary>
        /// Cache to hold a reference to ErrorResultsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedErrorResultsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to TestButton of type Button
        /// </summary>
        private Button cachedTestButton;
        
        /// <summary>
        /// Cache to hold a reference to URLStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedURLStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to EnterAndTestYourURLStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEnterAndTestYourURLStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to EnterAndTestWebAddressStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEnterAndTestWebAddressStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of EnterAndTestWebAddressDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[faizalk] 4/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public EnterAndTestWebAddressDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IEnterAndTestWebAddressDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[faizalk] 4/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IEnterAndTestWebAddressDialogControls Controls
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
        ///  Routine to set/get the text in control URL
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 4/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string URLText
        {
            get
            {
                return this.Controls.URLComboBox.Text;
            }
            
            set
            {
                this.Controls.URLComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control EnterAndTestYourURL
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 4/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string EnterAndTestYourURLText
        {
            get
            {
                return this.Controls.EnterAndTestYourURLTextBox.Text;
            }
            
            set
            {
                this.Controls.EnterAndTestYourURLTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEnterAndTestWebAddressDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, EnterAndTestWebAddressDialog.ControlIDs.PreviousButton);
                }
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEnterAndTestWebAddressDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, EnterAndTestWebAddressDialog.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEnterAndTestWebAddressDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, EnterAndTestWebAddressDialog.ControlIDs.CreateButton);
                }
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEnterAndTestWebAddressDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, EnterAndTestWebAddressDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitoringTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEnterAndTestWebAddressDialogControls.MonitoringTypeStaticControl
        {
            get
            {
                if ((this.cachedMonitoringTypeStaticControl == null))
                {
                    this.cachedMonitoringTypeStaticControl = new StaticControl(this, EnterAndTestWebAddressDialog.ControlIDs.MonitoringTypeStaticControl);
                }
                return this.cachedMonitoringTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralPropertiesStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEnterAndTestWebAddressDialogControls.GeneralPropertiesStaticControl
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
        ///  Exposes access to the WebAddressStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEnterAndTestWebAddressDialogControls.WebAddressStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedWebAddressStaticControl == null))
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
                    this.cachedWebAddressStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedWebAddressStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WatcherNodeStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEnterAndTestWebAddressDialogControls.WatcherNodeStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedWatcherNodeStaticControl == null))
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
        /// 	[faizalk] 4/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEnterAndTestWebAddressDialogControls.SummaryStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedSummaryStaticControl == null))
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
        ///  Exposes access to the URLComboBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IEnterAndTestWebAddressDialogControls.URLComboBox
        {
            get
            {
                if ((this.cachedURLComboBox == null))
                {
                    this.cachedURLComboBox = new ComboBox(this, EnterAndTestWebAddressDialog.ControlIDs.URLComboBox);
                }
                return this.cachedURLComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EnterAndTestYourURLTextBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IEnterAndTestWebAddressDialogControls.EnterAndTestYourURLTextBox
        {
            get
            {
                if ((this.cachedEnterAndTestYourURLTextBox == null))
                {
                    this.cachedEnterAndTestYourURLTextBox = new TextBox(this, EnterAndTestWebAddressDialog.ControlIDs.EnterAndTestYourURLTextBox);
                }
                return this.cachedEnterAndTestYourURLTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TheExecutionOfTheTaskReturnedAnErrorStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEnterAndTestWebAddressDialogControls.TheExecutionOfTheTaskReturnedAnErrorStaticControl
        {
            get
            {
                if ((this.cachedTheExecutionOfTheTaskReturnedAnErrorStaticControl == null))
                {
                    this.cachedTheExecutionOfTheTaskReturnedAnErrorStaticControl = new StaticControl(this, EnterAndTestWebAddressDialog.ControlIDs.TheExecutionOfTheTaskReturnedAnErrorStaticControl);
                }
                return this.cachedTheExecutionOfTheTaskReturnedAnErrorStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DetailsButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEnterAndTestWebAddressDialogControls.DetailsButton
        {
            get
            {
                if ((this.cachedDetailsButton == null))
                {
                    this.cachedDetailsButton = new Button(this, EnterAndTestWebAddressDialog.ControlIDs.DetailsButton);
                }
                return this.cachedDetailsButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ErrorResultsListView control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IEnterAndTestWebAddressDialogControls.ErrorResultsListView
        {
            get
            {
                if ((this.cachedErrorResultsListView == null))
                {
                    this.cachedErrorResultsListView = new ListView(this, EnterAndTestWebAddressDialog.ControlIDs.ErrorResultsListView);
                }
                return this.cachedErrorResultsListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ErrorResultsStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEnterAndTestWebAddressDialogControls.ErrorResultsStaticControl
        {
            get
            {
                if ((this.cachedErrorResultsStaticControl == null))
                {
                    this.cachedErrorResultsStaticControl = new StaticControl(this, EnterAndTestWebAddressDialog.ControlIDs.ErrorResultsStaticControl);
                }
                return this.cachedErrorResultsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TestButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEnterAndTestWebAddressDialogControls.TestButton
        {
            get
            {
                if ((this.cachedTestButton == null))
                {
                    this.cachedTestButton = new Button(this, EnterAndTestWebAddressDialog.ControlIDs.TestButton);
                }
                return this.cachedTestButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the URLStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEnterAndTestWebAddressDialogControls.URLStaticControl
        {
            get
            {
                if ((this.cachedURLStaticControl == null))
                {
                    this.cachedURLStaticControl = new StaticControl(this, EnterAndTestWebAddressDialog.ControlIDs.URLStaticControl);
                }
                return this.cachedURLStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EnterAndTestYourURLStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEnterAndTestWebAddressDialogControls.EnterAndTestYourURLStaticControl
        {
            get
            {
                if ((this.cachedEnterAndTestYourURLStaticControl == null))
                {
                    this.cachedEnterAndTestYourURLStaticControl = new StaticControl(this, EnterAndTestWebAddressDialog.ControlIDs.EnterAndTestYourURLStaticControl);
                }
                return this.cachedEnterAndTestYourURLStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEnterAndTestWebAddressDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, EnterAndTestWebAddressDialog.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EnterAndTestWebAddressStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEnterAndTestWebAddressDialogControls.EnterAndTestWebAddressStaticControl
        {
            get
            {
                if ((this.cachedEnterAndTestWebAddressStaticControl == null))
                {
                    this.cachedEnterAndTestWebAddressStaticControl = new StaticControl(this, EnterAndTestWebAddressDialog.ControlIDs.EnterAndTestWebAddressStaticControl);
                }
                return this.cachedEnterAndTestWebAddressStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/30/2006 Created
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
        /// 	[faizalk] 4/30/2006 Created
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
        /// 	[faizalk] 4/30/2006 Created
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
        /// 	[faizalk] 4/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Details
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickDetails()
        {
            this.Controls.DetailsButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Test
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/30/2006 Created
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
        ///  <param name="app">MomConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[faizalk] 4/30/2006 Created
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
                         // log the unsuccessful attempt
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
        /// 	[faizalk] 4/30/2006 Created
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
            private const string ResourceDialogTitle = ";Add Monitoring Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Common.PageCommonResources;TemplateWizard";
            
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
            private const string ResourceCreate = ";Create;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagem" +
                "ent.Internal.UI.Authoring.Pages.Common.PageCommonResources;CommitButtonText" +
                "";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;DC01.bT;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MonitoringType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMonitoringType = ";Monitoring Type;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpri" +
                "seManagement.Internal.UI.Authoring.Pages.TemplateListPage;$this.NavigationText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  GeneralProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneralProperties = ";General Properties;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enter" +
                "priseManagement.Internal.UI.Authoring.Pages.NameAndDescriptionPage;$this.NavigationT" +
                "ext";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WebAddress
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceWebAddress = "Web Address";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WatcherNode
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWatcherNode = ";Watcher Node;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseM" +
                "anagement.Internal.UI.Authoring.Pages.MonitorAppWizard.ChooseWatcherNodesPage;$this." +
                "NavigationText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Summary
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSummary = ";Summary;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.Administration.AdminResources;SummaryTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TheExecutionOfTheTaskReturnedAnError
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTheExecutionOfTheTaskReturnedAnError = ";The execution of the task returned an error.;ManagedString;Microsoft.MOM.UI.Comp" +
                "onents.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.PagesURLTe" +
                "mplatePage.UrlTemplateResource;ErrorTaskReturnedCode";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RequestProcessedSuccessfully
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRequestProcessedSuccessfully = ";Request processed successfully.;ManagedString;Microsoft.EnterpriseManagement.UI." +
                "Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.URLTemp" +
                "latePage.UrlTemplateResource;StatusSuccess";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Details
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDetails = ";&Details...;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMa" +
                "nagement.Internal.UI.Authoring.Pages.MonitorAppWizard.ChooseURLPage;buttonDetails.Te" +
                "xt";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ErrorResults
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceErrorResults = ";Error Results;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterprise" +
                "Management.Internal.UI.Authoring.PagesURLTemplatePage.UrlTemplateResource;" +
                "TestResultsError";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Test
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTest = ";&Test;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManageme" +
                "nt.Internal.UI.Authoring.Pages.MonitorAppWizard.ChooseURLPage;buttonTest.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  URL
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceURL = ";&URL:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManageme" +
                "nt.Internal.UI.Authoring.Pages.MonitorAppWizard.ChooseURLPage;labelUrl.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EnterAndTestYourURL
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEnterAndTestYourURL = ";Enter and test your URL;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft." +
                "EnterpriseManagement.Internal.UI.Authoring.Pages.MonitorAppWizard.ChooseURLPage;page" +
                "SectionLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mo" +
                "m.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EnterAndTestWebAddress
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceEnterAndTestWebAddress = "Enter and Test Web Address";
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
            /// Caches the translated resource string for:  WebAddress
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWebAddress;
            
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
            /// Caches the translated resource string for:  TheExecutionOfTheTaskReturnedAnError
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTheExecutionOfTheTaskReturnedAnError;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RequestProcessedSuccessfully
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRequestProcessedSuccessfully;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Details
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDetails;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ErrorResults
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedErrorResults;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Test
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTest;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  URL
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedURL;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EnterAndTestYourURL
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEnterAndTestYourURL;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EnterAndTestWebAddress
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEnterAndTestWebAddress;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/30/2006 Created
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
            /// 	[faizalk] 4/30/2006 Created
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
            /// 	[faizalk] 4/30/2006 Created
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
            /// 	[faizalk] 4/30/2006 Created
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
            /// 	[faizalk] 4/30/2006 Created
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
            /// 	[faizalk] 4/30/2006 Created
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
            /// 	[faizalk] 4/30/2006 Created
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
            /// Exposes access to the WebAddress translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/30/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WebAddress
            {
                get
                {
                    if ((cachedWebAddress == null))
                    {
                        cachedWebAddress = CoreManager.MomConsole.GetIntlStr(ResourceWebAddress);
                    }
                    return cachedWebAddress;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WatcherNode translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/30/2006 Created
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
            /// 	[faizalk] 4/30/2006 Created
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
            /// Exposes access to the TheExecutionOfTheTaskReturnedAnError translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/30/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TheExecutionOfTheTaskReturnedAnError
            {
                get
                {
                    if ((cachedTheExecutionOfTheTaskReturnedAnError == null))
                    {
                        cachedTheExecutionOfTheTaskReturnedAnError = CoreManager.MomConsole.GetIntlStr(ResourceTheExecutionOfTheTaskReturnedAnError);
                    }
                    return cachedTheExecutionOfTheTaskReturnedAnError;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RequestProcessedSuccessfully translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/18/2007 Created
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
            /// Exposes access to the Details translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/30/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Details
            {
                get
                {
                    if ((cachedDetails == null))
                    {
                        cachedDetails = CoreManager.MomConsole.GetIntlStr(ResourceDetails);
                    }
                    return cachedDetails;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ErrorResults translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/30/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ErrorResults
            {
                get
                {
                    if ((cachedErrorResults == null))
                    {
                        cachedErrorResults = CoreManager.MomConsole.GetIntlStr(ResourceErrorResults);
                    }
                    return cachedErrorResults;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Test translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/30/2006 Created
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
            /// Exposes access to the URL translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/30/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string URL
            {
                get
                {
                    if ((cachedURL == null))
                    {
                        cachedURL = CoreManager.MomConsole.GetIntlStr(ResourceURL);
                    }
                    return cachedURL;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EnterAndTestYourURL translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/30/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EnterAndTestYourURL
            {
                get
                {
                    if ((cachedEnterAndTestYourURL == null))
                    {
                        cachedEnterAndTestYourURL = CoreManager.MomConsole.GetIntlStr(ResourceEnterAndTestYourURL);
                    }
                    return cachedEnterAndTestYourURL;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/30/2006 Created
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
            /// Exposes access to the EnterAndTestWebAddress translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/30/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EnterAndTestWebAddress
            {
                get
                {
                    if ((cachedEnterAndTestWebAddress == null))
                    {
                        cachedEnterAndTestWebAddress = CoreManager.MomConsole.GetIntlStr(ResourceEnterAndTestWebAddress);
                    }
                    return cachedEnterAndTestWebAddress;
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
        /// 	[faizalk] 4/30/2006 Created
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
            /// Control ID for WebAddressStaticControl
            /// </summary>
            public const string WebAddressStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for WatcherNodeStaticControl
            /// </summary>
            public const string WatcherNodeStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for SummaryStaticControl
            /// </summary>
            public const string SummaryStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for URLComboBox
            /// </summary>
            public const string URLComboBox = "comboBoxScheme";
            
            /// <summary>
            /// Control ID for EnterAndTestYourURLTextBox
            /// </summary>
            public const string EnterAndTestYourURLTextBox = "textBoxUrl";
            
            /// <summary>
            /// Control ID for TheExecutionOfTheTaskReturnedAnErrorStaticControl
            /// </summary>
            public const string TheExecutionOfTheTaskReturnedAnErrorStaticControl = "labelStatus";
            
            /// <summary>
            /// Control ID for DetailsButton
            /// </summary>
            public const string DetailsButton = "buttonDetails";
            
            /// <summary>
            /// Control ID for ErrorResultsListView
            /// </summary>
            public const string ErrorResultsListView = "listView";
            
            /// <summary>
            /// Control ID for ErrorResultsStaticControl
            /// </summary>
            public const string ErrorResultsStaticControl = "pageSectionLabelResults";
            
            /// <summary>
            /// Control ID for TestButton
            /// </summary>
            public const string TestButton = "buttonTest";
            
            /// <summary>
            /// Control ID for URLStaticControl
            /// </summary>
            public const string URLStaticControl = "labelUrl";
            
            /// <summary>
            /// Control ID for EnterAndTestYourURLStaticControl
            /// </summary>
            public const string EnterAndTestYourURLStaticControl = "pageSectionLabel";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for EnterAndTestWebAddressStaticControl
            /// </summary>
            public const string EnterAndTestWebAddressStaticControl = "headerLabel";
        }
        #endregion
    }
}
