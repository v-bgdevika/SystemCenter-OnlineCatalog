// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SetQueryPerformanceThresholdsDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[dialac] 7/11/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.OleDb.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - ISetQueryPerformanceThresholdsDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISetQueryPerformanceThresholdsDialogControls, for SetQueryPerformanceThresholdsDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[dialac] 7/11/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISetQueryPerformanceThresholdsDialogControls
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
        /// Read-only property to access QueryTimeInMillisecondsCheckBox
        /// </summary>
        CheckBox QueryTimeInMillisecondsCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FetchTimeInMillisecondsCheckBox
        /// </summary>
        CheckBox FetchTimeInMillisecondsCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConnectionTimeInMillisecondsCheckBox
        /// </summary>
        CheckBox ConnectionTimeInMillisecondsCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WarningThresholdComboBox
        /// </summary>
        EditComboBox QueryWarningThresholdComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access QueryErrorThresholdComboBox
        /// </summary>
        EditComboBox QueryErrorThresholdComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FetchWarningThresholdComboBox
        /// </summary>
        EditComboBox FetchWarningThresholdComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FetchErrorThresholdComboBox
        /// </summary>
        EditComboBox FetchErrorThresholdComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConnectionWarningThresholdComboBox
        /// </summary>
        EditComboBox ConnectionWarningThresholdComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConnectionErrorThresholdComboBox
        /// </summary>
        EditComboBox ConnectionErrorThresholdComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WarningThresholdStaticControl
        /// </summary>
        StaticControl WarningThresholdStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ErrorThresholdStaticControl
        /// </summary>
        StaticControl ErrorThresholdStaticControl
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
        /// Read-only property to access SetQueryPerformanceThresholdsStaticControl
        /// </summary>
        StaticControl SetQueryPerformanceThresholdsStaticControl
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
    /// 	[dialac] 7/11/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SetQueryPerformanceThresholdsDialog : Dialog, ISetQueryPerformanceThresholdsDialogControls
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
        /// Cache to hold a reference to QueryTimeInMillisecondsCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedQueryTimeInMillisecondsCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to FetchTimeInMillisecondsCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedFetchTimeInMillisecondsCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to ConnectionTimeInMillisecondsCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedConnectionTimeInMillisecondsCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to cachedQueryWarningThresholdComboBox of type ComboBox
        /// </summary>
        private EditComboBox cachedQueryWarningThresholdComboBox;
        
        /// <summary>
        /// Cache to hold a reference to QueryErrorThresholdComboBox of type ComboBox
        /// </summary>
        private EditComboBox cachedErrorThresholdComboBox;
        
        /// <summary>
        /// Cache to hold a reference to FetchWarningThresholdComboBox of type ComboBox
        /// </summary>
        private EditComboBox cachedFetchWarningThresholdComboBox;
        
        /// <summary>
        /// Cache to hold a reference to FetchErrorThresholdComboBox of type ComboBox
        /// </summary>
        private EditComboBox cachedFetchErrorThresholdComboBox;
        
        /// <summary>
        /// Cache to hold a reference to ConnectionWarningThresholdComboBox of type ComboBox
        /// </summary>
        private EditComboBox cachedConnectionWarningThresholdComboBox;
        
        /// <summary>
        /// Cache to hold a reference to ConnectionErrorThresholdComboBox of type ComboBox
        /// </summary>
        private EditComboBox cachedConnectionErrorThresholdComboBox;
        
        /// <summary>
        /// Cache to hold a reference to WarningThresholdStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWarningThresholdStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ErrorThresholdStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedErrorThresholdStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SetQueryPerformanceThresholdsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSetQueryPerformanceThresholdsStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of SetQueryPerformanceThresholdsDialog of type App
        /// </param>
        /// <history>
        /// 	[dialac] 7/11/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SetQueryPerformanceThresholdsDialog(App app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region ISetQueryPerformanceThresholdsDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[dialac] 7/11/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISetQueryPerformanceThresholdsDialogControls Controls
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
        ///  Property to handle checkbox QueryTimeInMilliseconds
        /// </summary>
        /// <history>
        /// 	[dialac] 7/11/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool QueryTimeInMilliseconds
        {
            get
            {
                return this.Controls.QueryTimeInMillisecondsCheckBox.Checked;
            }
            
            set
            {
                this.Controls.QueryTimeInMillisecondsCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox FetchTimeInMilliseconds
        /// </summary>
        /// <history>
        /// 	[dialac] 7/11/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool FetchTimeInMilliseconds
        {
            get
            {
                return this.Controls.FetchTimeInMillisecondsCheckBox.Checked;
            }
            
            set
            {
                this.Controls.FetchTimeInMillisecondsCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox ConnectionTimeInMilliseconds
        /// </summary>
        /// <history>
        /// 	[dialac] 7/11/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool ConnectionTimeInMilliseconds
        {
            get
            {
                return this.Controls.ConnectionTimeInMillisecondsCheckBox.Checked;
            }
            
            set
            {
                this.Controls.ConnectionTimeInMillisecondsCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control WarningThreshold
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 7/11/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string QueryWarningThresholdText
        {
            get
            {
                return this.Controls.QueryWarningThresholdComboBox.Text;
            }
            
            set
            {
                this.Controls.QueryWarningThresholdComboBox.Text = value;
                //this.Controls.QueryWarningThresholdComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control WarningThreshold2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 7/11/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string QueryErrorThresholText
        {
            get
            {
                return this.Controls.QueryErrorThresholdComboBox.Text;
            }
            
            set
            {
                //this.Controls.QueryErrorThresholdComboBox.SelectByText(value, true);
                this.Controls.QueryErrorThresholdComboBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control WarningThreshold3
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 7/11/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string FetchWarningThresholdText
        {
            get
            {
                return this.Controls.FetchWarningThresholdComboBox.Text;
            }
            
            set
            {
                //this.Controls.FetchWarningThresholdComboBox.SelectByText(value, true);
                this.Controls.FetchWarningThresholdComboBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control WarningThreshold4
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 7/11/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string FetchErrorThresholdText
        {
            get
            {
                return this.Controls.FetchErrorThresholdComboBox.Text;
            }
            
            set
            {
                //this.Controls.FetchErrorThresholdComboBox.SelectByText(value, true);
                this.Controls.FetchErrorThresholdComboBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control WarningThreshold5
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 7/11/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ConnectionWarningThresholdText
        {
            get
            {
                return this.Controls.ConnectionWarningThresholdComboBox.Text;
            }
            
            set
            {
                //this.Controls.ConnectionWarningThresholdComboBox.SelectByText(value, true);
                this.Controls.ConnectionWarningThresholdComboBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control WarningThreshold6
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 7/11/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ConnectionErrorThresholdText
        {
            get
            {
                return this.Controls.ConnectionErrorThresholdComboBox.Text;
            }
            
            set
            {
                //this.Controls.ConnectionErrorThresholdComboBox.SelectByText(value, true);
                this.Controls.ConnectionErrorThresholdComboBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/11/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISetQueryPerformanceThresholdsDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, SetQueryPerformanceThresholdsDialog.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/11/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISetQueryPerformanceThresholdsDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, SetQueryPerformanceThresholdsDialog.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/11/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISetQueryPerformanceThresholdsDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, SetQueryPerformanceThresholdsDialog.ControlIDs.CreateButton);
                }
                
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/11/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISetQueryPerformanceThresholdsDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, SetQueryPerformanceThresholdsDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitoringTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/11/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISetQueryPerformanceThresholdsDialogControls.MonitoringTypeStaticControl
        {
            get
            {
                if ((this.cachedMonitoringTypeStaticControl == null))
                {
                    this.cachedMonitoringTypeStaticControl = new StaticControl(this, SetQueryPerformanceThresholdsDialog.ControlIDs.MonitoringTypeStaticControl);
                }
                
                return this.cachedMonitoringTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralPropertiesStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/11/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISetQueryPerformanceThresholdsDialogControls.GeneralPropertiesStaticControl
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
        /// 	[dialac] 7/11/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISetQueryPerformanceThresholdsDialogControls.ConnectionStringStaticControl
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
        /// 	[dialac] 7/11/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISetQueryPerformanceThresholdsDialogControls.QueryPerformanceStaticControl
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
        /// 	[dialac] 7/11/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISetQueryPerformanceThresholdsDialogControls.WatcherNodesStaticControl
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
        /// 	[dialac] 7/11/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISetQueryPerformanceThresholdsDialogControls.SummaryStaticControl
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
        ///  Exposes access to the QueryTimeInMillisecondsCheckBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/11/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox ISetQueryPerformanceThresholdsDialogControls.QueryTimeInMillisecondsCheckBox
        {
            get
            {
                if ((this.cachedQueryTimeInMillisecondsCheckBox == null))
                {
                    this.cachedQueryTimeInMillisecondsCheckBox = new CheckBox(this, SetQueryPerformanceThresholdsDialog.ControlIDs.QueryTimeInMillisecondsCheckBox);
                }
                
                return this.cachedQueryTimeInMillisecondsCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FetchTimeInMillisecondsCheckBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/11/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox ISetQueryPerformanceThresholdsDialogControls.FetchTimeInMillisecondsCheckBox
        {
            get
            {
                if ((this.cachedFetchTimeInMillisecondsCheckBox == null))
                {
                    this.cachedFetchTimeInMillisecondsCheckBox = new CheckBox(this, SetQueryPerformanceThresholdsDialog.ControlIDs.FetchTimeInMillisecondsCheckBox);
                }
                
                return this.cachedFetchTimeInMillisecondsCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConnectionTimeInMillisecondsCheckBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/11/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox ISetQueryPerformanceThresholdsDialogControls.ConnectionTimeInMillisecondsCheckBox
        {
            get
            {
                if ((this.cachedConnectionTimeInMillisecondsCheckBox == null))
                {
                    this.cachedConnectionTimeInMillisecondsCheckBox = new CheckBox(this, SetQueryPerformanceThresholdsDialog.ControlIDs.ConnectionTimeInMillisecondsCheckBox);
                }
                
                return this.cachedConnectionTimeInMillisecondsCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the QueryWarningThresholdComboBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/11/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox ISetQueryPerformanceThresholdsDialogControls.QueryWarningThresholdComboBox
        {
            get
            {
                if ((this.cachedQueryWarningThresholdComboBox == null))
                {
                    this.cachedQueryWarningThresholdComboBox = new EditComboBox(this, SetQueryPerformanceThresholdsDialog.ControlIDs.QueryWarningThresholdComboBox);
                }

                return this.cachedQueryWarningThresholdComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the QueryErrorThresholdComboBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/11/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox ISetQueryPerformanceThresholdsDialogControls.QueryErrorThresholdComboBox
        {
            get
            {
                if ((this.cachedErrorThresholdComboBox == null))
                {
                    this.cachedErrorThresholdComboBox = new EditComboBox(this, SetQueryPerformanceThresholdsDialog.ControlIDs.QueryErrorThresholdComboBox);
                }
                
                return this.cachedErrorThresholdComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FetchWarningThresholdComboBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/11/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox ISetQueryPerformanceThresholdsDialogControls.FetchWarningThresholdComboBox
        {
            get
            {
                if ((this.cachedFetchWarningThresholdComboBox == null))
                {
                    this.cachedFetchWarningThresholdComboBox = new EditComboBox(this, SetQueryPerformanceThresholdsDialog.ControlIDs.FetchWarningThresholdComboBox);
                }
                
                return this.cachedFetchWarningThresholdComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FetchErrorThresholdComboBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/11/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox ISetQueryPerformanceThresholdsDialogControls.FetchErrorThresholdComboBox
        {
            get
            {
                if ((this.cachedFetchErrorThresholdComboBox == null))
                {
                    this.cachedFetchErrorThresholdComboBox = new EditComboBox(this, SetQueryPerformanceThresholdsDialog.ControlIDs.FetchErrorThresholdComboBox);
                }
                
                return this.cachedFetchErrorThresholdComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConnectionWarningThresholdComboBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/11/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox ISetQueryPerformanceThresholdsDialogControls.ConnectionWarningThresholdComboBox
        {
            get
            {
                if ((this.cachedConnectionWarningThresholdComboBox == null))
                {
                    this.cachedConnectionWarningThresholdComboBox = new EditComboBox(this, SetQueryPerformanceThresholdsDialog.ControlIDs.ConnectionWarningThresholdComboBox);
                }
                
                return this.cachedConnectionWarningThresholdComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConnectionErrorThresholdComboBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/11/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox ISetQueryPerformanceThresholdsDialogControls.ConnectionErrorThresholdComboBox
        {
            get
            {
                if ((this.cachedConnectionErrorThresholdComboBox == null))
                {
                    this.cachedConnectionErrorThresholdComboBox = new EditComboBox(this, SetQueryPerformanceThresholdsDialog.ControlIDs.ConnectionErrorThresholdComboBox);
                }
                
                return this.cachedConnectionErrorThresholdComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WarningThresholdStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/11/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISetQueryPerformanceThresholdsDialogControls.WarningThresholdStaticControl
        {
            get
            {
                if ((this.cachedWarningThresholdStaticControl == null))
                {
                    this.cachedWarningThresholdStaticControl = new StaticControl(this, SetQueryPerformanceThresholdsDialog.ControlIDs.WarningThresholdStaticControl);
                }
                
                return this.cachedWarningThresholdStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ErrorThresholdStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/11/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISetQueryPerformanceThresholdsDialogControls.ErrorThresholdStaticControl
        {
            get
            {
                if ((this.cachedErrorThresholdStaticControl == null))
                {
                    this.cachedErrorThresholdStaticControl = new StaticControl(this, SetQueryPerformanceThresholdsDialog.ControlIDs.ErrorThresholdStaticControl);
                }
                
                return this.cachedErrorThresholdStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/11/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISetQueryPerformanceThresholdsDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, SetQueryPerformanceThresholdsDialog.ControlIDs.HelpStaticControl);
                }
                
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SetQueryPerformanceThresholdsStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 7/11/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISetQueryPerformanceThresholdsDialogControls.SetQueryPerformanceThresholdsStaticControl
        {
            get
            {
                if ((this.cachedSetQueryPerformanceThresholdsStaticControl == null))
                {
                    this.cachedSetQueryPerformanceThresholdsStaticControl = new StaticControl(this, SetQueryPerformanceThresholdsDialog.ControlIDs.SetQueryPerformanceThresholdsStaticControl);
                }
                
                return this.cachedSetQueryPerformanceThresholdsStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[dialac] 7/11/2008 Created
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
        /// 	[dialac] 7/11/2008 Created
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
        /// 	[dialac] 7/11/2008 Created
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
        /// 	[dialac] 7/11/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button QueryTimeInMilliseconds
        /// </summary>
        /// <history>
        /// 	[dialac] 7/11/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickQueryTimeInMilliseconds()
        {
            this.Controls.QueryTimeInMillisecondsCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button FetchTimeInMilliseconds
        /// </summary>
        /// <history>
        /// 	[dialac] 7/11/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickFetchTimeInMilliseconds()
        {
            this.Controls.FetchTimeInMillisecondsCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ConnectionTimeInMilliseconds
        /// </summary>
        /// <history>
        /// 	[dialac] 7/11/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickConnectionTimeInMilliseconds()
        {
            this.Controls.ConnectionTimeInMillisecondsCheckBox.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">App owning the dialog.</param>
        /// <history>
        /// 	[dialac] 7/11/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app)
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
        /// 	[dialac] 7/11/2008 Created
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
            private const string ResourceDialogTitle = ";Add Monitoring Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring." +
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
            /// Contains resource string for:  QueryTimeInMilliseconds
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceQueryTimeInMilliseconds = "Query time in milliseconds:";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  FetchTimeInMilliseconds
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceFetchTimeInMilliseconds = "Fetch time in milliseconds:";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConnectionTimeInMilliseconds
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceConnectionTimeInMilliseconds = "Connection time in milliseconds:";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WarningThreshold
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceWarningThreshold = "Warning Threshold:";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ErrorThreshold
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceErrorThreshold = "Error Threshold:";
            
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
            /// Contains resource string for:  SetQueryPerformanceThresholds
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceSetQueryPerformanceThresholds = "Set Query Performance Thresholds";
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
            /// Caches the translated resource string for:  QueryTimeInMilliseconds
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedQueryTimeInMilliseconds;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  FetchTimeInMilliseconds
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFetchTimeInMilliseconds;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConnectionTimeInMilliseconds
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConnectionTimeInMilliseconds;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WarningThreshold
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWarningThreshold;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ErrorThreshold
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedErrorThreshold;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SetQueryPerformanceThresholds
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSetQueryPerformanceThresholds;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 7/11/2008 Created
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
            /// 	[dialac] 7/11/2008 Created
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
            /// 	[dialac] 7/11/2008 Created
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
            /// 	[dialac] 7/11/2008 Created
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
            /// 	[dialac] 7/11/2008 Created
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
            /// 	[dialac] 7/11/2008 Created
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
            /// 	[dialac] 7/11/2008 Created
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
            /// 	[dialac] 7/11/2008 Created
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
            /// 	[dialac] 7/11/2008 Created
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
            /// 	[dialac] 7/11/2008 Created
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
            /// 	[dialac] 7/11/2008 Created
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
            /// Exposes access to the QueryTimeInMilliseconds translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 7/11/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string QueryTimeInMilliseconds
            {
                get
                {
                    if ((cachedQueryTimeInMilliseconds == null))
                    {
                        cachedQueryTimeInMilliseconds = CoreManager.MomConsole.GetIntlStr(ResourceQueryTimeInMilliseconds);
                    }
                    
                    return cachedQueryTimeInMilliseconds;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the FetchTimeInMilliseconds translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 7/11/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FetchTimeInMilliseconds
            {
                get
                {
                    if ((cachedFetchTimeInMilliseconds == null))
                    {
                        cachedFetchTimeInMilliseconds = CoreManager.MomConsole.GetIntlStr(ResourceFetchTimeInMilliseconds);
                    }
                    
                    return cachedFetchTimeInMilliseconds;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConnectionTimeInMilliseconds translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 7/11/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConnectionTimeInMilliseconds
            {
                get
                {
                    if ((cachedConnectionTimeInMilliseconds == null))
                    {
                        cachedConnectionTimeInMilliseconds = CoreManager.MomConsole.GetIntlStr(ResourceConnectionTimeInMilliseconds);
                    }
                    
                    return cachedConnectionTimeInMilliseconds;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WarningThreshold translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 7/11/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WarningThreshold
            {
                get
                {
                    if ((cachedWarningThreshold == null))
                    {
                        cachedWarningThreshold = CoreManager.MomConsole.GetIntlStr(ResourceWarningThreshold);
                    }
                    
                    return cachedWarningThreshold;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ErrorThreshold translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 7/11/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ErrorThreshold
            {
                get
                {
                    if ((cachedErrorThreshold == null))
                    {
                        cachedErrorThreshold = CoreManager.MomConsole.GetIntlStr(ResourceErrorThreshold);
                    }
                    
                    return cachedErrorThreshold;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 7/11/2008 Created
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
            /// Exposes access to the SetQueryPerformanceThresholds translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 7/11/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SetQueryPerformanceThresholds
            {
                get
                {
                    if ((cachedSetQueryPerformanceThresholds == null))
                    {
                        cachedSetQueryPerformanceThresholds = CoreManager.MomConsole.GetIntlStr(ResourceSetQueryPerformanceThresholds);
                    }
                    
                    return cachedSetQueryPerformanceThresholds;
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
        /// 	[dialac] 7/11/2008 Created
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
            /// Control ID for QueryTimeInMillisecondsCheckBox
            /// </summary>
            public const string QueryTimeInMillisecondsCheckBox = "queryChkBox";
            
            /// <summary>
            /// Control ID for FetchTimeInMillisecondsCheckBox
            /// </summary>
            public const string FetchTimeInMillisecondsCheckBox = "fetchChkBox";
            
            /// <summary>
            /// Control ID for ConnectionTimeInMillisecondsCheckBox
            /// </summary>
            public const string ConnectionTimeInMillisecondsCheckBox = "connectionChkBox";
            
            /// <summary>
            /// Control ID for WarningThresholdComboBox
            /// </summary>
            public const string QueryWarningThresholdComboBox = "QueryWarningThreshold";
            
            /// <summary>
            /// Control ID for QueryErrorThresholdComboBox
            /// </summary>
            public const string QueryErrorThresholdComboBox = "QueryErrorThreshold";
            
            /// <summary>
            /// Control ID for FetchWarningThresholdComboBox
            /// </summary>
            public const string FetchWarningThresholdComboBox = "FetchWarningThreshold";
            
            /// <summary>
            /// Control ID for FetchErrorThresholdComboBox
            /// </summary>
            public const string FetchErrorThresholdComboBox = "FetchErrorThreshold";
            
            /// <summary>
            /// Control ID for ConnectionWarningThresholdComboBox
            /// </summary>
            public const string ConnectionWarningThresholdComboBox = "ConnectionWarningThreshold";
            
            /// <summary>
            /// Control ID for ConnectionErrorThresholdComboBox
            /// </summary>
            public const string ConnectionErrorThresholdComboBox = "ConnectionErrorThreshold";
            
            /// <summary>
            /// Control ID for WarningThresholdStaticControl
            /// </summary>
            public const string WarningThresholdStaticControl = "label2";
            
            /// <summary>
            /// Control ID for ErrorThresholdStaticControl
            /// </summary>
            public const string ErrorThresholdStaticControl = "label1";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for SetQueryPerformanceThresholdsStaticControl
            /// </summary>
            public const string SetQueryPerformanceThresholdsStaticControl = "headerLabel";
        }
        #endregion
    }
}
