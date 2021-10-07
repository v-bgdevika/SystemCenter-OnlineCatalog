// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="EnterAndTestOleDbSettingsDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[dialac] 8/5/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.OleDb.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IEnterAndTestOleDbSettingsDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IEnterAndTestOleDbSettingsDialogControls, for EnterAndTestOleDbSettingsDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[dialac] 8/5/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IEnterAndTestOleDbSettingsDialogControls
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
        /// Read-only property to access ConnectionStringStaticControl
        /// </summary>
        StaticControl ConnectionStringStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access QueryPerformanceStaticControl
        /// </summary>
        StaticControl QueryPerformanceStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WatcherNodesStaticControl
        /// </summary>
        StaticControl WatcherNodesStaticControl
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
        /// Read-only property to access ListView
        /// </summary>
        ListView ListView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access BuildButton
        /// </summary>
        Button BuildButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access QueryExecutionTimeoutInSecondsComboBox
        /// </summary>
        ComboBox QueryExecutionTimeoutInSecondsComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access QueryExecutionTimeoutInSecondsStaticControl
        /// </summary>
        StaticControl QueryExecutionTimeoutInSecondsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access QueryToExecuteTextBox
        /// </summary>
        TextBox QueryToExecuteTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TypeInTheQueryToExecuteCheckBox
        /// </summary>
        CheckBox TypeInTheQueryToExecuteCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConnectionStringTextBox
        /// </summary>
        TextBox ConnectionStringTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConnectionStringStaticControl2
        /// </summary>
        StaticControl ConnectionStringStaticControl2
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
        /// Read-only property to access TestConnectivityUsingOLEDBProviderToDatabasesEtcStaticControl
        /// </summary>
        StaticControl TestConnectivityUsingOLEDBProviderToDatabasesEtcStaticControl
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
        /// Read-only property to access HelpStaticControl
        /// </summary>
        StaticControl HelpStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EnterAndTestOLEDBDataSourceSettingsStaticControl
        /// </summary>
        StaticControl EnterAndTestOLEDBDataSourceSettingsStaticControl
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
    /// 	[dialac] 8/5/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class EnterAndTestOleDbSettingsDialog : Dialog, IEnterAndTestOleDbSettingsDialogControls
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
        /// Cache to hold a reference to ConnectionStringStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConnectionStringStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to QueryPerformanceStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedQueryPerformanceStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to WatcherNodesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWatcherNodesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SummaryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSummaryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ListView of type ListView
        /// </summary>
        private ListView cachedListView;
        
        /// <summary>
        /// Cache to hold a reference to BuildButton of type Button
        /// </summary>
        private Button cachedBuildButton;
        
        /// <summary>
        /// Cache to hold a reference to QueryExecutionTimeoutInSecondsComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedQueryExecutionTimeoutInSecondsComboBox;
        
        /// <summary>
        /// Cache to hold a reference to QueryExecutionTimeoutInSecondsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedQueryExecutionTimeoutInSecondsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to QueryToExecuteTextBox of type TextBox
        /// </summary>
        private TextBox cachedQueryToExecuteTextBox;
        
        /// <summary>
        /// Cache to hold a reference to TypeInTheQueryToExecuteCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedTypeInTheQueryToExecuteCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to ConnectionStringTextBox of type TextBox
        /// </summary>
        private TextBox cachedConnectionStringTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ConnectionStringStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedConnectionStringStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to TestButton of type Button
        /// </summary>
        private Button cachedTestButton;
        
        /// <summary>
        /// Cache to hold a reference to TestConnectivityUsingOLEDBProviderToDatabasesEtcStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTestConnectivityUsingOLEDBProviderToDatabasesEtcStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to RequestProcessedSuccessfullyStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRequestProcessedSuccessfullyStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to EnterAndTestOLEDBDataSourceSettingsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEnterAndTestOLEDBDataSourceSettingsStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of EnterAndTestOleDbSettingsDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public EnterAndTestOleDbSettingsDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IEnterAndTestOleDbSettingsDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IEnterAndTestOleDbSettingsDialogControls Controls
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
        ///  Property to handle checkbox TypeInTheQueryToExecute
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool TypeInTheQueryToExecute
        {
            get
            {
                return this.Controls.TypeInTheQueryToExecuteCheckBox.Checked;
            }
            
            set
            {
                this.Controls.TypeInTheQueryToExecuteCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control QueryExecutionTimeoutInSeconds
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string QueryExecutionTimeoutInSecondsText
        {
            get
            {
                return this.Controls.QueryExecutionTimeoutInSecondsComboBox.Text;
            }
            
            set
            {
                this.Controls.QueryExecutionTimeoutInSecondsComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control IPAddressOrDeviceName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string QueryToExecuteText
        {
            get
            {
                return this.Controls.QueryToExecuteTextBox.Text;
            }
            
            set
            {
                this.Controls.QueryToExecuteTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ConnectionString
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ConnectionStringText
        {
            get
            {
                return this.Controls.ConnectionStringTextBox.Text;
            }
            
            set
            {
                this.Controls.ConnectionStringTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEnterAndTestOleDbSettingsDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, EnterAndTestOleDbSettingsDialog.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEnterAndTestOleDbSettingsDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, EnterAndTestOleDbSettingsDialog.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEnterAndTestOleDbSettingsDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, EnterAndTestOleDbSettingsDialog.ControlIDs.CreateButton);
                }
                
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEnterAndTestOleDbSettingsDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, EnterAndTestOleDbSettingsDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitoringTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEnterAndTestOleDbSettingsDialogControls.MonitoringTypeStaticControl
        {
            get
            {
                if ((this.cachedMonitoringTypeStaticControl == null))
                {
                    this.cachedMonitoringTypeStaticControl = new StaticControl(this, EnterAndTestOleDbSettingsDialog.ControlIDs.MonitoringTypeStaticControl);
                }
                
                return this.cachedMonitoringTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralPropertiesStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEnterAndTestOleDbSettingsDialogControls.GeneralPropertiesStaticControl
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
        ///  Exposes access to the ConnectionStringStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEnterAndTestOleDbSettingsDialogControls.ConnectionStringStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedConnectionStringStaticControl == null))
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
                    this.cachedConnectionStringStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedConnectionStringStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the QueryPerformanceStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEnterAndTestOleDbSettingsDialogControls.QueryPerformanceStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedQueryPerformanceStaticControl == null))
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
                    this.cachedQueryPerformanceStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedQueryPerformanceStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WatcherNodesStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEnterAndTestOleDbSettingsDialogControls.WatcherNodesStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedWatcherNodesStaticControl == null))
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
                    this.cachedWatcherNodesStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedWatcherNodesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SummaryStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEnterAndTestOleDbSettingsDialogControls.SummaryStaticControl
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
                    for (i = 0; (i <= 4); i = (i + 1))
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
        ///  Exposes access to the ListView control
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IEnterAndTestOleDbSettingsDialogControls.ListView
        {
            get
            {
                if ((this.cachedListView == null))
                {
                    this.cachedListView = new ListView(this, EnterAndTestOleDbSettingsDialog.ControlIDs.ListView);
                }
                
                return this.cachedListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BuildButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEnterAndTestOleDbSettingsDialogControls.BuildButton
        {
            get
            {
                if ((this.cachedBuildButton == null))
                {
                    this.cachedBuildButton = new Button(this, EnterAndTestOleDbSettingsDialog.ControlIDs.BuildButton);
                }
                
                return this.cachedBuildButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the QueryExecutionTimeoutInSecondsComboBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IEnterAndTestOleDbSettingsDialogControls.QueryExecutionTimeoutInSecondsComboBox
        {
            get
            {
                if ((this.cachedQueryExecutionTimeoutInSecondsComboBox == null))
                {
                    this.cachedQueryExecutionTimeoutInSecondsComboBox = new ComboBox(this, EnterAndTestOleDbSettingsDialog.ControlIDs.QueryExecutionTimeoutInSecondsComboBox);
                }
                
                return this.cachedQueryExecutionTimeoutInSecondsComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the QueryExecutionTimeoutInSecondsStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEnterAndTestOleDbSettingsDialogControls.QueryExecutionTimeoutInSecondsStaticControl
        {
            get
            {
                if ((this.cachedQueryExecutionTimeoutInSecondsStaticControl == null))
                {
                    this.cachedQueryExecutionTimeoutInSecondsStaticControl = new StaticControl(this, EnterAndTestOleDbSettingsDialog.ControlIDs.QueryExecutionTimeoutInSecondsStaticControl);
                }
                
                return this.cachedQueryExecutionTimeoutInSecondsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the QueryToExecuteTextBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IEnterAndTestOleDbSettingsDialogControls.QueryToExecuteTextBox
        {
            get
            {
                if ((this.cachedQueryToExecuteTextBox == null))
                {
                    this.cachedQueryToExecuteTextBox = new TextBox(this, EnterAndTestOleDbSettingsDialog.ControlIDs.QueryToExecuteTextBox);
                }
                
                return this.cachedQueryToExecuteTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TypeInTheQueryToExecuteCheckBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IEnterAndTestOleDbSettingsDialogControls.TypeInTheQueryToExecuteCheckBox
        {
            get
            {
                if ((this.cachedTypeInTheQueryToExecuteCheckBox == null))
                {
                    this.cachedTypeInTheQueryToExecuteCheckBox = new CheckBox(this, EnterAndTestOleDbSettingsDialog.ControlIDs.TypeInTheQueryToExecuteCheckBox);
                }
                
                return this.cachedTypeInTheQueryToExecuteCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConnectionStringTextBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IEnterAndTestOleDbSettingsDialogControls.ConnectionStringTextBox
        {
            get
            {
                if ((this.cachedConnectionStringTextBox == null))
                {
                    this.cachedConnectionStringTextBox = new TextBox(this, EnterAndTestOleDbSettingsDialog.ControlIDs.ConnectionStringTextBox);
                }
                
                return this.cachedConnectionStringTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConnectionStringStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEnterAndTestOleDbSettingsDialogControls.ConnectionStringStaticControl2
        {
            get
            {
                if ((this.cachedConnectionStringStaticControl2 == null))
                {
                    this.cachedConnectionStringStaticControl2 = new StaticControl(this, EnterAndTestOleDbSettingsDialog.ControlIDs.ConnectionStringStaticControl2);
                }
                
                return this.cachedConnectionStringStaticControl2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TestButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEnterAndTestOleDbSettingsDialogControls.TestButton
        {
            get
            {
                if ((this.cachedTestButton == null))
                {
                    this.cachedTestButton = new Button(this, EnterAndTestOleDbSettingsDialog.ControlIDs.TestButton);
                }
                
                return this.cachedTestButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TestConnectivityUsingOLEDBProviderToDatabasesEtcStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEnterAndTestOleDbSettingsDialogControls.TestConnectivityUsingOLEDBProviderToDatabasesEtcStaticControl
        {
            get
            {
                if ((this.cachedTestConnectivityUsingOLEDBProviderToDatabasesEtcStaticControl == null))
                {
                    this.cachedTestConnectivityUsingOLEDBProviderToDatabasesEtcStaticControl = new StaticControl(this, EnterAndTestOleDbSettingsDialog.ControlIDs.TestConnectivityUsingOLEDBProviderToDatabasesEtcStaticControl);
                }
                
                return this.cachedTestConnectivityUsingOLEDBProviderToDatabasesEtcStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RequestProcessedSuccessfullyStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEnterAndTestOleDbSettingsDialogControls.RequestProcessedSuccessfullyStaticControl
        {
            get
            {
                if ((this.cachedRequestProcessedSuccessfullyStaticControl == null))
                {
                    this.cachedRequestProcessedSuccessfullyStaticControl = new StaticControl(this, EnterAndTestOleDbSettingsDialog.ControlIDs.RequestProcessedSuccessfullyStaticControl);
                }
                
                return this.cachedRequestProcessedSuccessfullyStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEnterAndTestOleDbSettingsDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, EnterAndTestOleDbSettingsDialog.ControlIDs.HelpStaticControl);
                }
                
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EnterAndTestOLEDBDataSourceSettingsStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEnterAndTestOleDbSettingsDialogControls.EnterAndTestOLEDBDataSourceSettingsStaticControl
        {
            get
            {
                if ((this.cachedEnterAndTestOLEDBDataSourceSettingsStaticControl == null))
                {
                    this.cachedEnterAndTestOLEDBDataSourceSettingsStaticControl = new StaticControl(this, EnterAndTestOleDbSettingsDialog.ControlIDs.EnterAndTestOLEDBDataSourceSettingsStaticControl);
                }
                
                return this.cachedEnterAndTestOLEDBDataSourceSettingsStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
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
        /// 	[dialac] 8/5/2008 Created
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
        /// 	[dialac] 8/5/2008 Created
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
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Build
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickBuild()
        {
            this.Controls.BuildButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button TypeInTheQueryToExecute
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickTypeInTheQueryToExecute()
        {
            this.Controls.TypeInTheQueryToExecuteCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Test
        /// </summary>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
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
        /// <param name="app">MomConsoleApp owning the dialog.</param>
        /// <history>
        /// 	[dialac] 8/5/2008 Created
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
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Mom.Test.UI.Core.Common.Utilities.LogMessage("Attempt " + numberOfTries + " of " + maxTries);

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
        /// 	[dialac] 8/5/2008 Created
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
            //private const string ResourceDialogTitle = "Add Monitoring Wizard";
            private const string ResourceDialogTitle = @";Add Monitoring Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring." +
                "dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Common.PageCommon" +
                "Resources;TemplateWizard";
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
            /// Contains resource string for:  ConnectionString
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceConnectionString = "Connection String";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  QueryPerformance
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceQueryPerformance = "Query Performance";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WatcherNodes
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceWatcherNodes = "Watcher Nodes";
            
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
            /// Contains resource string for:  Build
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceBuild = ";&Build...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsof" +
                "t.EnterpriseManagement.Internal.UI.Authoring.Pages.ChooseOleDbConfigPage;buttonB" +
                "uildConnectionString.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  QueryExecutionTimeoutInSeconds
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceQueryExecutionTimeoutInSeconds = ";Query Execution Timeout in seconds:;ManagedString;Microsoft.EnterpriseManagement" +
                ".UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Cho" +
                "oseOleDbConfigPage;queryExecTimeoutLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TypeInTheQueryToExecute
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTypeInTheQueryToExecute = ";Type in the Query to execute:;ManagedString;Microsoft.EnterpriseManagement.UI.Au" +
                "thoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ChooseOle" +
                "DbConfigPage;queryCheckBox.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConnectionString2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConnectionString2 = ";&Connection String:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dl" +
                "l;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ChooseOleDbConfigPa" +
                "ge;lblConnectionString.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Test
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTest = ";&Test;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.En" +
                "terpriseManagement.Internal.UI.Authoring.Pages.ChooseURLPage;buttonTest.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TestConnectivityUsingOLEDBProviderToDatabasesEtc
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTestConnectivityUsingOLEDBProviderToDatabasesEtc = ";Test Connectivity using OLE-DB Provider to databases, etc.;ManagedString;Microso" +
                "ft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal" +
                ".UI.Authoring.Pages.ChooseOleDbConfigPage;lblPageSection.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RequestProcessedSuccessfully
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRequestProcessedSuccessfully = ";Request processed successfully;ManagedString;" +
                "Microsoft.EnterpriseManagement.UI.Authoring.dll;" +
                "Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.OleDbProbe.OleDbTemplateResources;StatusSuccess";

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
            /// Contains resource string for:  EnterAndTestOLEDBDataSourceSettings
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceEnterAndTestOLEDBDataSourceSettings = "Enter and Test OLE DB Data Source Settings";
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
            /// Caches the translated resource string for:  ConnectionString
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConnectionString;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  QueryPerformance
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedQueryPerformance;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WatcherNodes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWatcherNodes;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Summary
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSummary;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Build
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBuild;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  QueryExecutionTimeoutInSeconds
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedQueryExecutionTimeoutInSeconds;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TypeInTheQueryToExecute
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTypeInTheQueryToExecute;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConnectionString2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConnectionString2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Test
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTest;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TestConnectivityUsingOLEDBProviderToDatabasesEtc
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTestConnectivityUsingOLEDBProviderToDatabasesEtc;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RequestProcessedSuccessfully
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRequestProcessedSuccessfully;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EnterAndTestOLEDBDataSourceSettings
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEnterAndTestOLEDBDataSourceSettings;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 8/5/2008 Created
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
            /// 	[dialac] 8/5/2008 Created
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
            /// 	[dialac] 8/5/2008 Created
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
            /// 	[dialac] 8/5/2008 Created
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
            /// 	[dialac] 8/5/2008 Created
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
            /// 	[dialac] 8/5/2008 Created
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
            /// 	[dialac] 8/5/2008 Created
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
            /// Exposes access to the ConnectionString translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 8/5/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConnectionString
            {
                get
                {
                    if ((cachedConnectionString == null))
                    {
                        cachedConnectionString = CoreManager.MomConsole.GetIntlStr(ResourceConnectionString);
                    }
                    
                    return cachedConnectionString;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the QueryPerformance translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 8/5/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string QueryPerformance
            {
                get
                {
                    if ((cachedQueryPerformance == null))
                    {
                        cachedQueryPerformance = CoreManager.MomConsole.GetIntlStr(ResourceQueryPerformance);
                    }
                    
                    return cachedQueryPerformance;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WatcherNodes translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 8/5/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WatcherNodes
            {
                get
                {
                    if ((cachedWatcherNodes == null))
                    {
                        cachedWatcherNodes = CoreManager.MomConsole.GetIntlStr(ResourceWatcherNodes);
                    }
                    
                    return cachedWatcherNodes;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Summary translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 8/5/2008 Created
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
            /// Exposes access to the Build translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 8/5/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Build
            {
                get
                {
                    if ((cachedBuild == null))
                    {
                        cachedBuild = CoreManager.MomConsole.GetIntlStr(ResourceBuild);
                    }
                    
                    return cachedBuild;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the QueryExecutionTimeoutInSeconds translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 8/5/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string QueryExecutionTimeoutInSeconds
            {
                get
                {
                    if ((cachedQueryExecutionTimeoutInSeconds == null))
                    {
                        cachedQueryExecutionTimeoutInSeconds = CoreManager.MomConsole.GetIntlStr(ResourceQueryExecutionTimeoutInSeconds);
                    }
                    
                    return cachedQueryExecutionTimeoutInSeconds;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TypeInTheQueryToExecute translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 8/5/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TypeInTheQueryToExecute
            {
                get
                {
                    if ((cachedTypeInTheQueryToExecute == null))
                    {
                        cachedTypeInTheQueryToExecute = CoreManager.MomConsole.GetIntlStr(ResourceTypeInTheQueryToExecute);
                    }
                    
                    return cachedTypeInTheQueryToExecute;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConnectionString2 translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 8/5/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConnectionString2
            {
                get
                {
                    if ((cachedConnectionString2 == null))
                    {
                        cachedConnectionString2 = CoreManager.MomConsole.GetIntlStr(ResourceConnectionString2);
                    }
                    
                    return cachedConnectionString2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Test translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 8/5/2008 Created
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
            /// Exposes access to the TestConnectivityUsingOLEDBProviderToDatabasesEtc translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 8/5/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TestConnectivityUsingOLEDBProviderToDatabasesEtc
            {
                get
                {
                    if ((cachedTestConnectivityUsingOLEDBProviderToDatabasesEtc == null))
                    {
                        cachedTestConnectivityUsingOLEDBProviderToDatabasesEtc = CoreManager.MomConsole.GetIntlStr(ResourceTestConnectivityUsingOLEDBProviderToDatabasesEtc);
                    }
                    
                    return cachedTestConnectivityUsingOLEDBProviderToDatabasesEtc;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RequestProcessedSuccessfully translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 8/5/2008 Created
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
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 8/5/2008 Created
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
            /// Exposes access to the EnterAndTestOLEDBDataSourceSettings translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 8/5/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EnterAndTestOLEDBDataSourceSettings
            {
                get
                {
                    if ((cachedEnterAndTestOLEDBDataSourceSettings == null))
                    {
                        cachedEnterAndTestOLEDBDataSourceSettings = CoreManager.MomConsole.GetIntlStr(ResourceEnterAndTestOLEDBDataSourceSettings);
                    }
                    
                    return cachedEnterAndTestOLEDBDataSourceSettings;
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
        /// 	[dialac] 8/5/2008 Created
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
            /// Control ID for ConnectionStringStaticControl
            /// </summary>
            public const string ConnectionStringStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for QueryPerformanceStaticControl
            /// </summary>
            public const string QueryPerformanceStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for WatcherNodesStaticControl
            /// </summary>
            public const string WatcherNodesStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for SummaryStaticControl
            /// </summary>
            public const string SummaryStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ListView
            /// </summary>
            public const string ListView = "listResultView";
            
            /// <summary>
            /// Control ID for BuildButton
            /// </summary>
            public const string BuildButton = "buttonBuildConnectionString";
            
            /// <summary>
            /// Control ID for QueryExecutionTimeoutInSecondsComboBox
            /// </summary>
            public const string QueryExecutionTimeoutInSecondsComboBox = "queryTimeout";
            
            /// <summary>
            /// Control ID for QueryExecutionTimeoutInSecondsStaticControl
            /// </summary>
            public const string QueryExecutionTimeoutInSecondsStaticControl = "queryExecTimeoutLabel";
            
            /// <summary>
            /// Control ID for QueryToExecuteTextBox
            /// </summary>
            public const string QueryToExecuteTextBox = "queryText";
            
            /// <summary>
            /// Control ID for TypeInTheQueryToExecuteCheckBox
            /// </summary>
            public const string TypeInTheQueryToExecuteCheckBox = "queryCheckBox";
            
            /// <summary>
            /// Control ID for ConnectionStringTextBox
            /// </summary>
            public const string ConnectionStringTextBox = "textBoxConnectionString";
            
            /// <summary>
            /// Control ID for ConnectionStringStaticControl2
            /// </summary>
            public const string ConnectionStringStaticControl2 = "lblConnectionString";
            
            /// <summary>
            /// Control ID for TestButton
            /// </summary>
            public const string TestButton = "buttonTest";
            
            /// <summary>
            /// Control ID for TestConnectivityUsingOLEDBProviderToDatabasesEtcStaticControl
            /// </summary>
            public const string TestConnectivityUsingOLEDBProviderToDatabasesEtcStaticControl = "lblPageSection";
            
            /// <summary>
            /// Control ID for RequestProcessedSuccessfullyStaticControl
            /// </summary>
            public const string RequestProcessedSuccessfullyStaticControl = "labelStatus";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for EnterAndTestOLEDBDataSourceSettingsStaticControl
            /// </summary>
            public const string EnterAndTestOLEDBDataSourceSettingsStaticControl = "headerLabel";
        }
        #endregion
    }
}
