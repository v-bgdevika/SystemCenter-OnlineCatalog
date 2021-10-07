// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SettingsSummaryDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[faizalk] 9/27/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.DotNETMonitor.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - ISettingsSummaryDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISettingsSummaryDialogControls, for SettingsSummaryDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[faizalk] 9/27/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISettingsSummaryDialogControls
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
        /// Read-only property to access DiscoveryMethodStaticControl
        /// </summary>
        StaticControl DiscoveryMethodStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ASPNETApplicationStaticControl
        /// </summary>
        StaticControl ASPNETApplicationStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ExceptionsStaticControl
        /// </summary>
        StaticControl ExceptionsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PerformanceStaticControl
        /// </summary>
        StaticControl PerformanceStaticControl
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
        /// Read-only property to access TheFollowingSummarizesAllTheDataYouHaveSuppliedToConfigureThisTemplateForMonitoringStaticControl
        /// </summary>
        StaticControl TheFollowingSummarizesAllTheDataYouHaveSuppliedToConfigureThisTemplateForMonitoringStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SummaryStaticControl2
        /// </summary>
        StaticControl SummaryStaticControl2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access IfTheRateOfErrorExceptionsDuringASamplingIntervalExceedsTheWarningOrTheErrorThresholdsTheStateOfTheA
        /// </summary>
        ListView IfTheRateOfErrorExceptionsDuringASamplingIntervalExceedsTheWarningOrTheErrorThresholdsTheStateOfTheA
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SummaryStaticControl3
        /// </summary>
        StaticControl SummaryStaticControl3
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
        /// Read-only property to access ASPNETApplicationMonitoringSettingsSummaryStaticControl
        /// </summary>
        StaticControl ASPNETApplicationMonitoringSettingsSummaryStaticControl
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
    /// 	[faizalk] 9/27/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SettingsSummaryDialog : Dialog, ISettingsSummaryDialogControls
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
        /// Cache to hold a reference to DiscoveryMethodStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDiscoveryMethodStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ASPNETApplicationStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedASPNETApplicationStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ExceptionsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedExceptionsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to PerformanceStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPerformanceStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SummaryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSummaryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to TheFollowingSummarizesAllTheDataYouHaveSuppliedToConfigureThisTemplateForMonitoringStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTheFollowingSummarizesAllTheDataYouHaveSuppliedToConfigureThisTemplateForMonitoringStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SummaryStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedSummaryStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to IfTheRateOfErrorExceptionsDuringASamplingIntervalExceedsTheWarningOrTheErrorThresholdsTheStateOfTheA of type ListView
        /// </summary>
        private ListView cachedIfTheRateOfErrorExceptionsDuringASamplingIntervalExceedsTheWarningOrTheErrorThresholdsTheStateOfTheA;
        
        /// <summary>
        /// Cache to hold a reference to SummaryStaticControl3 of type StaticControl
        /// </summary>
        private StaticControl cachedSummaryStaticControl3;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ASPNETApplicationMonitoringSettingsSummaryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedASPNETApplicationMonitoringSettingsSummaryStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of SettingsSummaryDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SettingsSummaryDialog(ConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region ISettingsSummaryDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISettingsSummaryDialogControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISettingsSummaryDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, SettingsSummaryDialog.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISettingsSummaryDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, SettingsSummaryDialog.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISettingsSummaryDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, SettingsSummaryDialog.ControlIDs.CreateButton);
                }
                
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISettingsSummaryDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, SettingsSummaryDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitoringTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISettingsSummaryDialogControls.MonitoringTypeStaticControl
        {
            get
            {
                if ((this.cachedMonitoringTypeStaticControl == null))
                {
                    this.cachedMonitoringTypeStaticControl = new StaticControl(this, SettingsSummaryDialog.ControlIDs.MonitoringTypeStaticControl);
                }
                
                return this.cachedMonitoringTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralPropertiesStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISettingsSummaryDialogControls.GeneralPropertiesStaticControl
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
        ///  Exposes access to the DiscoveryMethodStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISettingsSummaryDialogControls.DiscoveryMethodStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedDiscoveryMethodStaticControl == null))
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
                    this.cachedDiscoveryMethodStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedDiscoveryMethodStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ASPNETApplicationStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISettingsSummaryDialogControls.ASPNETApplicationStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedASPNETApplicationStaticControl == null))
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
                    this.cachedASPNETApplicationStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedASPNETApplicationStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExceptionsStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISettingsSummaryDialogControls.ExceptionsStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedExceptionsStaticControl == null))
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
                    this.cachedExceptionsStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedExceptionsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PerformanceStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISettingsSummaryDialogControls.PerformanceStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedPerformanceStaticControl == null))
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
                    this.cachedPerformanceStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedPerformanceStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SummaryStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISettingsSummaryDialogControls.SummaryStaticControl
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
                    for (i = 0; (i <= 5); i = (i + 1))
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
        ///  Exposes access to the TheFollowingSummarizesAllTheDataYouHaveSuppliedToConfigureThisTemplateForMonitoringStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISettingsSummaryDialogControls.TheFollowingSummarizesAllTheDataYouHaveSuppliedToConfigureThisTemplateForMonitoringStaticControl
        {
            get
            {
                if ((this.cachedTheFollowingSummarizesAllTheDataYouHaveSuppliedToConfigureThisTemplateForMonitoringStaticControl == null))
                {
                    this.cachedTheFollowingSummarizesAllTheDataYouHaveSuppliedToConfigureThisTemplateForMonitoringStaticControl = new StaticControl(this, SettingsSummaryDialog.ControlIDs.TheFollowingSummarizesAllTheDataYouHaveSuppliedToConfigureThisTemplateForMonitoringStaticControl);
                }
                
                return this.cachedTheFollowingSummarizesAllTheDataYouHaveSuppliedToConfigureThisTemplateForMonitoringStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SummaryStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISettingsSummaryDialogControls.SummaryStaticControl2
        {
            get
            {
                if ((this.cachedSummaryStaticControl2 == null))
                {
                    this.cachedSummaryStaticControl2 = new StaticControl(this, SettingsSummaryDialog.ControlIDs.SummaryStaticControl2);
                }
                
                return this.cachedSummaryStaticControl2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IfTheRateOfErrorExceptionsDuringASamplingIntervalExceedsTheWarningOrTheErrorThresholdsTheStateOfTheA control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView ISettingsSummaryDialogControls.IfTheRateOfErrorExceptionsDuringASamplingIntervalExceedsTheWarningOrTheErrorThresholdsTheStateOfTheA
        {
            get
            {
                if ((this.cachedIfTheRateOfErrorExceptionsDuringASamplingIntervalExceedsTheWarningOrTheErrorThresholdsTheStateOfTheA == null))
                {
                    this.cachedIfTheRateOfErrorExceptionsDuringASamplingIntervalExceedsTheWarningOrTheErrorThresholdsTheStateOfTheA = new ListView(this, SettingsSummaryDialog.ControlIDs.IfTheRateOfErrorExceptionsDuringASamplingIntervalExceedsTheWarningOrTheErrorThresholdsTheStateOfTheA);
                }
                
                return this.cachedIfTheRateOfErrorExceptionsDuringASamplingIntervalExceedsTheWarningOrTheErrorThresholdsTheStateOfTheA;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SummaryStaticControl3 control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISettingsSummaryDialogControls.SummaryStaticControl3
        {
            get
            {
                if ((this.cachedSummaryStaticControl3 == null))
                {
                    this.cachedSummaryStaticControl3 = new StaticControl(this, SettingsSummaryDialog.ControlIDs.SummaryStaticControl3);
                }
                
                return this.cachedSummaryStaticControl3;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISettingsSummaryDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, SettingsSummaryDialog.ControlIDs.HelpStaticControl);
                }
                
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ASPNETApplicationMonitoringSettingsSummaryStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISettingsSummaryDialogControls.ASPNETApplicationMonitoringSettingsSummaryStaticControl
        {
            get
            {
                if ((this.cachedASPNETApplicationMonitoringSettingsSummaryStaticControl == null))
                {
                    this.cachedASPNETApplicationMonitoringSettingsSummaryStaticControl = new StaticControl(this, SettingsSummaryDialog.ControlIDs.ASPNETApplicationMonitoringSettingsSummaryStaticControl);
                }
                
                return this.cachedASPNETApplicationMonitoringSettingsSummaryStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
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
        /// 	[faizalk] 9/27/2006 Created
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
        /// 	[faizalk] 9/27/2006 Created
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
        /// 	[faizalk] 9/27/2006 Created
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
        ///  <param name="app">ConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
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
                         Core.Common.Utilities.LogMessage("Attempt "
                            + numberOfTries
                            + " of "
                            + MaxTries
                            + "...");                         
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
        /// 	[faizalk] 9/27/2006 Created
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
            private const string ResourceGeneralProperties = ";General Properties;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll" +
                ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.NameAndDescriptionPa" +
                "ge;$this.NavigationText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DiscoveryMethod
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDiscoveryMethod = ";Discovery Method;ManagedString;Microsoft.EnterpriseManagement.UI.Administration." +
                "dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";DiscoveryMethodTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ASPNETApplication
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceASPNETApplication = "ASP.NET Application";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Exceptions
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceExceptions = "Exceptions";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Performance
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePerformance = ";Performance;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMa" +
                "nagement.Mom.Internal.UI.Views.EventResources;ViewPerformanceCommand";
            
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
            /// Contains resource string for:  TheFollowingSummarizesAllTheDataYouHaveSuppliedToConfigureThisTemplateForMonitoring
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTheFollowingSummarizesAllTheDataYouHaveSuppliedToConfigureThisTemplateForMonitoring = @";The following summarizes all the data you have supplied to configure this template for monitoring ;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.OleDbSummaryPage;labelDescription.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Summary2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSummary2 = ";&Summary:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsof" +
                "t.EnterpriseManagement.Internal.UI.Authoring.Pages.SummaryPage;labelSummary.Text" +
                "";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Summary3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSummary3 = ";Summary;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;SummaryT" +
                "itle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.Ent" +
                "erpriseManagement.Internal.UI.Authoring.Common.CommonResources;CommandHelp";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ASPNETApplicationMonitoringSettingsSummary
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceASPNETApplicationMonitoringSettingsSummary = "ASP.NET Application Monitoring Settings Summary";
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
            /// Caches the translated resource string for:  DiscoveryMethod
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDiscoveryMethod;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ASPNETApplication
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedASPNETApplication;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Exceptions
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedExceptions;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Performance
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPerformance;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Summary
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSummary;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TheFollowingSummarizesAllTheDataYouHaveSuppliedToConfigureThisTemplateForMonitoring
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTheFollowingSummarizesAllTheDataYouHaveSuppliedToConfigureThisTemplateForMonitoring;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Summary2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSummary2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Summary3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSummary3;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ASPNETApplicationMonitoringSettingsSummary
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedASPNETApplicationMonitoringSettingsSummary;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
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
            /// 	[faizalk] 9/27/2006 Created
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
            /// 	[faizalk] 9/27/2006 Created
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
            /// 	[faizalk] 9/27/2006 Created
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
            /// 	[faizalk] 9/27/2006 Created
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
            /// 	[faizalk] 9/27/2006 Created
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
            /// 	[faizalk] 9/27/2006 Created
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
            /// Exposes access to the DiscoveryMethod translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DiscoveryMethod
            {
                get
                {
                    if ((cachedDiscoveryMethod == null))
                    {
                        cachedDiscoveryMethod = CoreManager.MomConsole.GetIntlStr(ResourceDiscoveryMethod);
                    }
                    
                    return cachedDiscoveryMethod;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ASPNETApplication translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ASPNETApplication
            {
                get
                {
                    if ((cachedASPNETApplication == null))
                    {
                        cachedASPNETApplication = CoreManager.MomConsole.GetIntlStr(ResourceASPNETApplication);
                    }
                    
                    return cachedASPNETApplication;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Exceptions translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Exceptions
            {
                get
                {
                    if ((cachedExceptions == null))
                    {
                        cachedExceptions = CoreManager.MomConsole.GetIntlStr(ResourceExceptions);
                    }
                    
                    return cachedExceptions;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Performance translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Performance
            {
                get
                {
                    if ((cachedPerformance == null))
                    {
                        cachedPerformance = CoreManager.MomConsole.GetIntlStr(ResourcePerformance);
                    }
                    
                    return cachedPerformance;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Summary translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
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
            /// Exposes access to the TheFollowingSummarizesAllTheDataYouHaveSuppliedToConfigureThisTemplateForMonitoring translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TheFollowingSummarizesAllTheDataYouHaveSuppliedToConfigureThisTemplateForMonitoring
            {
                get
                {
                    if ((cachedTheFollowingSummarizesAllTheDataYouHaveSuppliedToConfigureThisTemplateForMonitoring == null))
                    {
                        cachedTheFollowingSummarizesAllTheDataYouHaveSuppliedToConfigureThisTemplateForMonitoring = CoreManager.MomConsole.GetIntlStr(ResourceTheFollowingSummarizesAllTheDataYouHaveSuppliedToConfigureThisTemplateForMonitoring);
                    }
                    
                    return cachedTheFollowingSummarizesAllTheDataYouHaveSuppliedToConfigureThisTemplateForMonitoring;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Summary2 translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Summary2
            {
                get
                {
                    if ((cachedSummary2 == null))
                    {
                        cachedSummary2 = CoreManager.MomConsole.GetIntlStr(ResourceSummary2);
                    }
                    
                    return cachedSummary2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Summary3 translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Summary3
            {
                get
                {
                    if ((cachedSummary3 == null))
                    {
                        cachedSummary3 = CoreManager.MomConsole.GetIntlStr(ResourceSummary3);
                    }
                    
                    return cachedSummary3;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
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
            /// Exposes access to the ASPNETApplicationMonitoringSettingsSummary translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ASPNETApplicationMonitoringSettingsSummary
            {
                get
                {
                    if ((cachedASPNETApplicationMonitoringSettingsSummary == null))
                    {
                        cachedASPNETApplicationMonitoringSettingsSummary = CoreManager.MomConsole.GetIntlStr(ResourceASPNETApplicationMonitoringSettingsSummary);
                    }
                    
                    return cachedASPNETApplicationMonitoringSettingsSummary;
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
        /// 	[faizalk] 9/27/2006 Created
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
            /// Control ID for DiscoveryMethodStaticControl
            /// </summary>
            public const string DiscoveryMethodStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ASPNETApplicationStaticControl
            /// </summary>
            public const string ASPNETApplicationStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ExceptionsStaticControl
            /// </summary>
            public const string ExceptionsStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for PerformanceStaticControl
            /// </summary>
            public const string PerformanceStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for SummaryStaticControl
            /// </summary>
            public const string SummaryStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for TheFollowingSummarizesAllTheDataYouHaveSuppliedToConfigureThisTemplateForMonitoringStaticControl
            /// </summary>
            public const string TheFollowingSummarizesAllTheDataYouHaveSuppliedToConfigureThisTemplateForMonitoringStaticControl = "labelDescription";
            
            /// <summary>
            /// Control ID for SummaryStaticControl2
            /// </summary>
            public const string SummaryStaticControl2 = "labelSummary";
            
            /// <summary>
            /// Control ID for IfTheRateOfErrorExceptionsDuringASamplingIntervalExceedsTheWarningOrTheErrorThresholdsTheStateOfTheA
            /// </summary>
            public const string IfTheRateOfErrorExceptionsDuringASamplingIntervalExceedsTheWarningOrTheErrorThresholdsTheStateOfTheA = "listView";
            
            /// <summary>
            /// Control ID for SummaryStaticControl3
            /// </summary>
            public const string SummaryStaticControl3 = "pageSectionLabel";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for ASPNETApplicationMonitoringSettingsSummaryStaticControl
            /// </summary>
            public const string ASPNETApplicationMonitoringSettingsSummaryStaticControl = "headerLabel";
        }
        #endregion
    }
}
