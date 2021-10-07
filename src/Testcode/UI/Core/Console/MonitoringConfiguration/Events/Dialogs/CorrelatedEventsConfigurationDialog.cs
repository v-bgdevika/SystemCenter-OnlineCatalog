// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="CorrelatedEventsConfigurationDialog.cs">
// 	Copyright (c) Microsoft Corporation 2007
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[ruhim] 4/18/2007 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Events.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    
    #region Interface Definition - ICorrelatedEventsConfigurationDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ICorrelatedEventsConfigurationDialogControls, for CorrelatedEventsConfigurationDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 4/18/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ICorrelatedEventsConfigurationDialogControls
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
        /// Read-only property to access MonitorTypeStaticControl
        /// </summary>
        StaticControl MonitorTypeStaticControl
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
        /// Read-only property to access DefineEventLogNameAStaticControl
        /// </summary>
        StaticControl DefineEventLogNameAStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access BuildEventLogExpressionForAStaticControl
        /// </summary>
        StaticControl BuildEventLogExpressionForAStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DefineEventLogNameBStaticControl
        /// </summary>
        StaticControl DefineEventLogNameBStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access BuildEventLogExpressionForBStaticControl
        /// </summary>
        StaticControl BuildEventLogExpressionForBStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConfigureCorrelationStaticControl
        /// </summary>
        StaticControl ConfigureCorrelationStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConfigureHealthStaticControl
        /// </summary>
        StaticControl ConfigureHealthStaticControl
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
        /// Read-only property to access NoCorrelationStaticControl
        /// </summary>
        StaticControl NoCorrelationStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CorrelationTakesPlaceStaticControl
        /// </summary>
        StaticControl CorrelationTakesPlaceStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CorrelationIntervalStaticControl
        /// </summary>
        StaticControl CorrelationIntervalStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access BStaticControl
        /// </summary>
        StaticControl BStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AStaticControl
        /// </summary>
        StaticControl AStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LegendStaticControl
        /// </summary>
        StaticControl LegendStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SampleOfCorrelationBetweenTheFirstOccurrenceOfAAndTheThirdOccurrenceOfBOnA30SecondsIntervalAndInChro
        /// </summary>
        StaticControl SampleOfCorrelationBetweenTheFirstOccurrenceOfAAndTheThirdOccurrenceOfBOnA30SecondsIntervalAndInChro
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CorrelateWhenComboBox
        /// </summary>
        ComboBox CorrelateWhenComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConfigureAdvancedOptionsButton
        /// </summary>
        Button ConfigureAdvancedOptionsButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NotConfiguredStaticControl
        /// </summary>
        StaticControl NotConfiguredStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access _1StaticControl
        /// </summary>
        StaticControl _1StaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ExpressionStaticControl
        /// </summary>
        StaticControl ExpressionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access OccurrenceStaticControl
        /// </summary>
        StaticControl OccurrenceStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AdvancedOptionsStaticControl
        /// </summary>
        StaticControl AdvancedOptionsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CorrelateWhenTheFollowingHappensStaticControl
        /// </summary>
        StaticControl CorrelateWhenTheFollowingHappensStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConfigureCorrelationStaticControl2
        /// </summary>
        StaticControl ConfigureCorrelationStaticControl2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CorrelationIntervalStaticControl2
        /// </summary>
        StaticControl CorrelationIntervalStaticControl2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SpecifyCorrelationUnitsComboBox
        /// </summary>
        ComboBox SpecifyCorrelationUnitsComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CorrelationIntervalComboBox
        /// </summary>
        EditComboBox CorrelationIntervalComboBox
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
        /// Read-only property to access CorrelatedEventsConfigurationStaticControl
        /// </summary>
        StaticControl CorrelatedEventsConfigurationStaticControl
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
    /// 	[ruhim] 4/18/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class CorrelatedEventsConfigurationDialog : Dialog, ICorrelatedEventsConfigurationDialogControls
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
        /// Cache to hold a reference to MonitorTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMonitorTypeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to GeneralStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DefineEventLogNameAStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDefineEventLogNameAStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to BuildEventLogExpressionForAStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedBuildEventLogExpressionForAStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DefineEventLogNameBStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDefineEventLogNameBStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to BuildEventLogExpressionForBStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedBuildEventLogExpressionForBStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureCorrelationStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureCorrelationStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureHealthStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureHealthStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureAlertsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureAlertsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to NoCorrelationStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNoCorrelationStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CorrelationTakesPlaceStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCorrelationTakesPlaceStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CorrelationIntervalStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCorrelationIntervalStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to BStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedBStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to LegendStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedLegendStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SampleOfCorrelationBetweenTheFirstOccurrenceOfAAndTheThirdOccurrenceOfBOnA30SecondsIntervalAndInChro of type StaticControl
        /// </summary>
        private StaticControl cachedSampleOfCorrelationBetweenTheFirstOccurrenceOfAAndTheThirdOccurrenceOfBOnA30SecondsIntervalAndInChro;
        
        /// <summary>
        /// Cache to hold a reference to CorrelateWhenComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedCorrelateWhenComboBox;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureAdvancedOptionsButton of type Button
        /// </summary>
        private Button cachedConfigureAdvancedOptionsButton;
        
        /// <summary>
        /// Cache to hold a reference to NotConfiguredStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNotConfiguredStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to _1StaticControl of type StaticControl
        /// </summary>
        private StaticControl cached_1StaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ExpressionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedExpressionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to OccurrenceStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedOccurrenceStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AdvancedOptionsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAdvancedOptionsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CorrelateWhenTheFollowingHappensStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCorrelateWhenTheFollowingHappensStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureCorrelationStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureCorrelationStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to CorrelationIntervalStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedCorrelationIntervalStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyCorrelationUnitsComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedConfigureCorrelationComboBox;
        
        /// <summary>
        /// Cache to hold a reference to CorrelationIntervalComboBox of type ComboBox
        /// </summary>
        private EditComboBox cachedCorrelationIntervalComboBox;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CorrelatedEventsConfigurationStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCorrelatedEventsConfigurationStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of CorrelatedEventsConfigurationDialog of type App
        /// </param>
        /// <param name="windowCaption">Wizard dialog title.</param>
        /// <history>
        /// 	[ruhim] 4/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public CorrelatedEventsConfigurationDialog(Mom.Test.UI.Core.Console.MomConsoleApp app, MonitoringConfiguration.WindowCaptions windowCaption)
            :
                base(app, Init(app, windowCaption))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
        }
        #endregion
        
        #region ICorrelatedEventsConfigurationDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 4/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ICorrelatedEventsConfigurationDialogControls Controls
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
        ///  Routine to set/get the text in control CorrelateWhenComboBox
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 4/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string CorrelateWhenComboBoxText
        {
            get
            {
                return this.Controls.CorrelateWhenComboBox.Text;
            }
            
            set
            {
                this.Controls.CorrelateWhenComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control SpecifyCorrelationUnitsComboBox
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 4/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SpecifyCorrelationUnitsComboBoxText
        {
            get
            {
                return this.Controls.SpecifyCorrelationUnitsComboBox.Text;
            }
            
            set
            {
                this.Controls.SpecifyCorrelationUnitsComboBox.SelectByText(value, true);
            }
        }
                
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control CorrelationInterval
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 4/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string CorrelationIntervalText
        {
            get
            {
                return this.Controls.CorrelationIntervalComboBox.Text;
            }
            
            set
            {                
                this.Controls.CorrelationIntervalComboBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICorrelatedEventsConfigurationDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, CorrelatedEventsConfigurationDialog.ControlIDs.PreviousButton);
                }
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICorrelatedEventsConfigurationDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, CorrelatedEventsConfigurationDialog.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICorrelatedEventsConfigurationDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, CorrelatedEventsConfigurationDialog.ControlIDs.CreateButton);
                }
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICorrelatedEventsConfigurationDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, CorrelatedEventsConfigurationDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitorTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICorrelatedEventsConfigurationDialogControls.MonitorTypeStaticControl
        {
            get
            {
                if ((this.cachedMonitorTypeStaticControl == null))
                {
                    this.cachedMonitorTypeStaticControl = new StaticControl(this, CorrelatedEventsConfigurationDialog.ControlIDs.MonitorTypeStaticControl);
                }
                return this.cachedMonitorTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICorrelatedEventsConfigurationDialogControls.GeneralStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedGeneralStaticControl == null))
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
                    this.cachedGeneralStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedGeneralStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DefineEventLogNameAStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICorrelatedEventsConfigurationDialogControls.DefineEventLogNameAStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedDefineEventLogNameAStaticControl == null))
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
                    this.cachedDefineEventLogNameAStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedDefineEventLogNameAStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BuildEventLogExpressionForAStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICorrelatedEventsConfigurationDialogControls.BuildEventLogExpressionForAStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedBuildEventLogExpressionForAStaticControl == null))
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
                    this.cachedBuildEventLogExpressionForAStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedBuildEventLogExpressionForAStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DefineEventLogNameBStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICorrelatedEventsConfigurationDialogControls.DefineEventLogNameBStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedDefineEventLogNameBStaticControl == null))
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
                    this.cachedDefineEventLogNameBStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedDefineEventLogNameBStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BuildEventLogExpressionForBStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICorrelatedEventsConfigurationDialogControls.BuildEventLogExpressionForBStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedBuildEventLogExpressionForBStaticControl == null))
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
                    for (i = 0; (i <= 4); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedBuildEventLogExpressionForBStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedBuildEventLogExpressionForBStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureCorrelationStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICorrelatedEventsConfigurationDialogControls.ConfigureCorrelationStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedConfigureCorrelationStaticControl == null))
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
                    for (i = 0; (i <= 5); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedConfigureCorrelationStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedConfigureCorrelationStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureHealthStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICorrelatedEventsConfigurationDialogControls.ConfigureHealthStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedConfigureHealthStaticControl == null))
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
                    for (i = 0; (i <= 6); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedConfigureHealthStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedConfigureHealthStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureAlertsStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICorrelatedEventsConfigurationDialogControls.ConfigureAlertsStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedConfigureAlertsStaticControl == null))
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
                    for (i = 0; (i <= 7); i = (i + 1))
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
        ///  Exposes access to the NoCorrelationStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICorrelatedEventsConfigurationDialogControls.NoCorrelationStaticControl
        {
            get
            {
                if ((this.cachedNoCorrelationStaticControl == null))
                {
                    this.cachedNoCorrelationStaticControl = new StaticControl(this, CorrelatedEventsConfigurationDialog.ControlIDs.NoCorrelationStaticControl);
                }
                return this.cachedNoCorrelationStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CorrelationTakesPlaceStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICorrelatedEventsConfigurationDialogControls.CorrelationTakesPlaceStaticControl
        {
            get
            {
                if ((this.cachedCorrelationTakesPlaceStaticControl == null))
                {
                    this.cachedCorrelationTakesPlaceStaticControl = new StaticControl(this, CorrelatedEventsConfigurationDialog.ControlIDs.CorrelationTakesPlaceStaticControl);
                }
                return this.cachedCorrelationTakesPlaceStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CorrelationIntervalStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICorrelatedEventsConfigurationDialogControls.CorrelationIntervalStaticControl
        {
            get
            {
                if ((this.cachedCorrelationIntervalStaticControl == null))
                {
                    this.cachedCorrelationIntervalStaticControl = new StaticControl(this, CorrelatedEventsConfigurationDialog.ControlIDs.CorrelationIntervalStaticControl);
                }
                return this.cachedCorrelationIntervalStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICorrelatedEventsConfigurationDialogControls.BStaticControl
        {
            get
            {
                if ((this.cachedBStaticControl == null))
                {
                    this.cachedBStaticControl = new StaticControl(this, CorrelatedEventsConfigurationDialog.ControlIDs.BStaticControl);
                }
                return this.cachedBStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICorrelatedEventsConfigurationDialogControls.AStaticControl
        {
            get
            {
                if ((this.cachedAStaticControl == null))
                {
                    this.cachedAStaticControl = new StaticControl(this, CorrelatedEventsConfigurationDialog.ControlIDs.AStaticControl);
                }
                return this.cachedAStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LegendStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICorrelatedEventsConfigurationDialogControls.LegendStaticControl
        {
            get
            {
                if ((this.cachedLegendStaticControl == null))
                {
                    this.cachedLegendStaticControl = new StaticControl(this, CorrelatedEventsConfigurationDialog.ControlIDs.LegendStaticControl);
                }
                return this.cachedLegendStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SampleOfCorrelationBetweenTheFirstOccurrenceOfAAndTheThirdOccurrenceOfBOnA30SecondsIntervalAndInChro control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICorrelatedEventsConfigurationDialogControls.SampleOfCorrelationBetweenTheFirstOccurrenceOfAAndTheThirdOccurrenceOfBOnA30SecondsIntervalAndInChro
        {
            get
            {
                if ((this.cachedSampleOfCorrelationBetweenTheFirstOccurrenceOfAAndTheThirdOccurrenceOfBOnA30SecondsIntervalAndInChro == null))
                {
                    this.cachedSampleOfCorrelationBetweenTheFirstOccurrenceOfAAndTheThirdOccurrenceOfBOnA30SecondsIntervalAndInChro = new StaticControl(this, CorrelatedEventsConfigurationDialog.ControlIDs.SampleOfCorrelationBetweenTheFirstOccurrenceOfAAndTheThirdOccurrenceOfBOnA30SecondsIntervalAndInChro);
                }
                return this.cachedSampleOfCorrelationBetweenTheFirstOccurrenceOfAAndTheThirdOccurrenceOfBOnA30SecondsIntervalAndInChro;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CorrelateWhenComboBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ICorrelatedEventsConfigurationDialogControls.CorrelateWhenComboBox
        {
            get
            {
                if ((this.cachedCorrelateWhenComboBox == null))
                {
                    this.cachedCorrelateWhenComboBox = new ComboBox(this, CorrelatedEventsConfigurationDialog.ControlIDs.CorrelateWhenComboBox);
                }
                return this.cachedCorrelateWhenComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureAdvancedOptionsButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICorrelatedEventsConfigurationDialogControls.ConfigureAdvancedOptionsButton
        {
            get
            {
                if ((this.cachedConfigureAdvancedOptionsButton == null))
                {
                    this.cachedConfigureAdvancedOptionsButton = new Button(this, CorrelatedEventsConfigurationDialog.ControlIDs.ConfigureAdvancedOptionsButton);
                }
                return this.cachedConfigureAdvancedOptionsButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NotConfiguredStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICorrelatedEventsConfigurationDialogControls.NotConfiguredStaticControl
        {
            get
            {
                if ((this.cachedNotConfiguredStaticControl == null))
                {
                    this.cachedNotConfiguredStaticControl = new StaticControl(this, CorrelatedEventsConfigurationDialog.ControlIDs.NotConfiguredStaticControl);
                }
                return this.cachedNotConfiguredStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the _1StaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICorrelatedEventsConfigurationDialogControls._1StaticControl
        {
            get
            {
                if ((this.cached_1StaticControl == null))
                {
                    this.cached_1StaticControl = new StaticControl(this, CorrelatedEventsConfigurationDialog.ControlIDs._1StaticControl);
                }
                return this.cached_1StaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExpressionStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICorrelatedEventsConfigurationDialogControls.ExpressionStaticControl
        {
            get
            {
                if ((this.cachedExpressionStaticControl == null))
                {
                    this.cachedExpressionStaticControl = new StaticControl(this, CorrelatedEventsConfigurationDialog.ControlIDs.ExpressionStaticControl);
                }
                return this.cachedExpressionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OccurrenceStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICorrelatedEventsConfigurationDialogControls.OccurrenceStaticControl
        {
            get
            {
                if ((this.cachedOccurrenceStaticControl == null))
                {
                    this.cachedOccurrenceStaticControl = new StaticControl(this, CorrelatedEventsConfigurationDialog.ControlIDs.OccurrenceStaticControl);
                }
                return this.cachedOccurrenceStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AdvancedOptionsStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICorrelatedEventsConfigurationDialogControls.AdvancedOptionsStaticControl
        {
            get
            {
                if ((this.cachedAdvancedOptionsStaticControl == null))
                {
                    this.cachedAdvancedOptionsStaticControl = new StaticControl(this, CorrelatedEventsConfigurationDialog.ControlIDs.AdvancedOptionsStaticControl);
                }
                return this.cachedAdvancedOptionsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CorrelateWhenTheFollowingHappensStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICorrelatedEventsConfigurationDialogControls.CorrelateWhenTheFollowingHappensStaticControl
        {
            get
            {
                if ((this.cachedCorrelateWhenTheFollowingHappensStaticControl == null))
                {
                    this.cachedCorrelateWhenTheFollowingHappensStaticControl = new StaticControl(this, CorrelatedEventsConfigurationDialog.ControlIDs.CorrelateWhenTheFollowingHappensStaticControl);
                }
                return this.cachedCorrelateWhenTheFollowingHappensStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureCorrelationStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICorrelatedEventsConfigurationDialogControls.ConfigureCorrelationStaticControl2
        {
            get
            {
                if ((this.cachedConfigureCorrelationStaticControl2 == null))
                {
                    this.cachedConfigureCorrelationStaticControl2 = new StaticControl(this, CorrelatedEventsConfigurationDialog.ControlIDs.ConfigureCorrelationStaticControl2);
                }
                return this.cachedConfigureCorrelationStaticControl2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CorrelationIntervalStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICorrelatedEventsConfigurationDialogControls.CorrelationIntervalStaticControl2
        {
            get
            {
                if ((this.cachedCorrelationIntervalStaticControl2 == null))
                {
                    this.cachedCorrelationIntervalStaticControl2 = new StaticControl(this, CorrelatedEventsConfigurationDialog.ControlIDs.CorrelationIntervalStaticControl2);
                }
                return this.cachedCorrelationIntervalStaticControl2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyCorrelationUnitsComboBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ICorrelatedEventsConfigurationDialogControls.SpecifyCorrelationUnitsComboBox
        {
            get
            {
                if ((this.cachedConfigureCorrelationComboBox == null))
                {
                    this.cachedConfigureCorrelationComboBox = new ComboBox(this, CorrelatedEventsConfigurationDialog.ControlIDs.SpecifyCorrelationUnitsComboBox);
                }
                return this.cachedConfigureCorrelationComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CorrelationIntervalComboBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox ICorrelatedEventsConfigurationDialogControls.CorrelationIntervalComboBox
        {
            get
            {
                if ((this.cachedCorrelationIntervalComboBox == null))
                {
                    this.cachedCorrelationIntervalComboBox = new EditComboBox(this, CorrelatedEventsConfigurationDialog.ControlIDs.CorrelationIntervalComboBox);
                }
                return this.cachedCorrelationIntervalComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICorrelatedEventsConfigurationDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, CorrelatedEventsConfigurationDialog.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CorrelatedEventsConfigurationStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICorrelatedEventsConfigurationDialogControls.CorrelatedEventsConfigurationStaticControl
        {
            get
            {
                if ((this.cachedCorrelatedEventsConfigurationStaticControl == null))
                {
                    this.cachedCorrelatedEventsConfigurationStaticControl = new StaticControl(this, CorrelatedEventsConfigurationDialog.ControlIDs.CorrelatedEventsConfigurationStaticControl);
                }
                return this.cachedCorrelatedEventsConfigurationStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2007 Created
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
        /// 	[ruhim] 4/18/2007 Created
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
        /// 	[ruhim] 4/18/2007 Created
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
        /// 	[ruhim] 4/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ConfigureAdvancedOptions
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickConfigureAdvancedOptions()
        {
            this.Controls.ConfigureAdvancedOptionsButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">App owning the dialog.</param>
        /// <param name="windowCaption">Wizard dialog title.</param>
        /// <history>
        /// 	[ruhim] 4/18/2007 Created
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
                tempWindow = new Window(DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
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
        /// 	[ruhim] 4/18/2007 Created
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
            private const string ResourceDialogTitle = "Create a unit monitor";
            
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
            /// Contains resource string for:  MonitorType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMonitorType = ";Monitor Type;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micro" +
                "soft.EnterpriseManagement.Internal.UI.Authoring.Pages.ChooseMonitorTypePage;$thi" +
                "s.TabName";
            
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
            /// Contains resource string for:  DefineEventLogNameA
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceDefineEventLogNameA = "Define Event Log Name A";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  BuildEventLogExpressionForA
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceBuildEventLogExpressionForA = "Build Event Log Expression for A";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DefineEventLogNameB
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceDefineEventLogNameB = "Define Event Log Name B";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  BuildEventLogExpressionForB
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceBuildEventLogExpressionForB = "Build Event Log Expression for B";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureCorrelation
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureCorrelation = ";Configure Correlation;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring." +
                "dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.CorrelatorConditi" +
                "onPage;pageSectionLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureHealth
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureHealth = ";Configure Health;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;M" +
                "icrosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.OperationalStatesMappi" +
                "ngPage;$this.NavigationText";
            
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
            /// Contains resource string for:  NoCorrelation
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNoCorrelation = ";= No correlation;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;M" +
                "icrosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.CorrelatorConditionPag" +
                "e;labelNoCorrelation.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CorrelationTakesPlace
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCorrelationTakesPlace = ";= Correlation takes place;ManagedString;Microsoft.EnterpriseManagement.UI.Author" +
                "ing.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.CorrelatorCon" +
                "ditionPage;labelCorrelationMarkers.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CorrelationInterval
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCorrelationInterval = ";= Correlation interval;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring" +
                ".dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.CorrelatorCondit" +
                "ionPage;labelCorrelationInterval.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  B
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceB = ";B =;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.Ente" +
                "rpriseManagement.Internal.UI.Authoring.Pages.CorrelatorConditionPage;labelB.Text" +
                "";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  A
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceA = ";A =;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.Ente" +
                "rpriseManagement.Internal.UI.Authoring.Pages.CorrelatorConditionPage;labelA.Text" +
                "";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Legend
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLegend = ";Legend:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft." +
                "EnterpriseManagement.Internal.UI.Authoring.Pages.CorrelatorConditionPage;labelLe" +
                "gend.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SampleOfCorrelationBetweenTheFirstOccurrenceOfAAndTheThirdOccurrenceOfBOnA30SecondsIntervalAndInChro
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSampleOfCorrelationBetweenTheFirstOccurrenceOfAAndTheThirdOccurrenceOfBOnA30SecondsIntervalAndInChro = @";Sample of correlation between the first occurrence of A and the third occurrence of B on a 30 seconds interval and in chronological order.;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.CorrelatorCondition.CorrelatorResource;DetailsFirstInOrder";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureAdvancedOptions
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureAdvancedOptions = ";Con&figure advanced options...;ManagedString;Microsoft.EnterpriseManagement.UI.A" +
                "uthoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Correlat" +
                "orConditionPage;buttonAdvancedOptions.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  NotConfigured
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNotConfigured = ";Not configured;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Mic" +
                "rosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.CorrelatorCondition.Corr" +
                "elatorResource;ExpressionNotConfigured";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  _1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string Resource_1 = ";1;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.Pro" +
                "pertyDialogForm;>>tabPageLegend.ZOrder";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Expression
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceExpression = ";Expression:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micros" +
                "oft.EnterpriseManagement.Internal.UI.Authoring.Pages.CorrelatorConditionPage;lab" +
                "elExpression.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Occurrence
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOccurrence = ";Occurrence:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micros" +
                "oft.EnterpriseManagement.Internal.UI.Authoring.Pages.CorrelatorConditionPage;lab" +
                "elOccurrence.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AdvancedOptions
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdvancedOptions = ";Advanced options:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;" +
                "Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.CorrelatorConditionPa" +
                "ge;labelAdvancedOptions.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CorrelateWhenTheFollowingHappens
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCorrelateWhenTheFollowingHappens = ";Co&rrelate when the following happens:;ManagedString;Microsoft.EnterpriseManagem" +
                "ent.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages." +
                "CorrelatorConditionPage;labelOrder.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureCorrelation2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureCorrelation2 = ";Configure Correlation;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring." +
                "dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.CorrelatorConditi" +
                "onPage;pageSectionLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CorrelationInterval2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCorrelationInterval2 = ";Correlation &interval:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring" +
                ".dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.CorrelatorCondit" +
                "ionPage;labelInterval.Text";
            
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
            /// Contains resource string for:  CorrelatedEventsConfiguration
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceCorrelatedEventsConfiguration = "Correlated Events Configuration";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  The first occurrence of A with the configured occurrence of B in chronological order
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFirstAChronologicalOrder =
                ";The first occurrence of A with the configured occurrence of B in chronological order;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.CorrelatorCondition.CorrelatorResource;PolicyFirstInOrder";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  The last occurrence of A with the configured occurrence of B in chronological order
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLastAChronologicalOrder =
                ";The last occurrence of A with the configured occurrence of B in chronological order;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.CorrelatorCondition.CorrelatorResource;PolicyLastInOrder";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  The first occurrence of A with the configured occurrence of B, or vice versa
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFirstAViseVersa =
                ";The first occurrence of A with the configured occurrence of B, or vice versa;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.CorrelatorCondition.CorrelatorResource;PolicyFirstAnyOrder";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  The last occurrence of A with the configured occurrence of B, or vice versa
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLastAViseVersa =
                ";The last occurrence of A with the configured occurrence of B, or vice versa;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.CorrelatorCondition.CorrelatorResource;PolicyLastAnyOrder";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  The first occurrence of A with the configured occurrence of B happens, enable interval restart
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFirstAEnableIntervalRestart =
                ";The first occurrence of A with the configured occurrence of B happens, enable interval restart;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.CorrelatorCondition.CorrelatorResource;PolicyRestart";

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
            /// Caches the translated resource string for:  MonitorType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonitorType;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  General
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneral;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DefineEventLogNameA
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDefineEventLogNameA;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  BuildEventLogExpressionForA
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBuildEventLogExpressionForA;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DefineEventLogNameB
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDefineEventLogNameB;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  BuildEventLogExpressionForB
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBuildEventLogExpressionForB;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureCorrelation
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigureCorrelation;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureHealth
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigureHealth;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureAlerts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigureAlerts;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  NoCorrelation
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNoCorrelation;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CorrelationTakesPlace
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCorrelationTakesPlace;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CorrelationInterval
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCorrelationInterval;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  B
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedB;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  A
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedA;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Legend
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLegend;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SampleOfCorrelationBetweenTheFirstOccurrenceOfAAndTheThirdOccurrenceOfBOnA30SecondsIntervalAndInChro
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSampleOfCorrelationBetweenTheFirstOccurrenceOfAAndTheThirdOccurrenceOfBOnA30SecondsIntervalAndInChro;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureAdvancedOptions
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigureAdvancedOptions;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  NotConfigured
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNotConfigured;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  _1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cached_1;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Expression
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedExpression;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Occurrence
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOccurrence;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AdvancedOptions
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdvancedOptions;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CorrelateWhenTheFollowingHappens
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCorrelateWhenTheFollowingHappens;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureCorrelation2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigureCorrelation2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CorrelationInterval2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCorrelationInterval2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CorrelatedEventsConfiguration
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCorrelatedEventsConfiguration;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  The first occurrence of A with the configured occurrence of B in chronological order
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFirstAChronologicalOrder;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  The last occurrence of A with the configured occurrence of B in chronological order
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLastAChronologicalOrder;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  The first occurrence of A with the configured occurrence of B, or vice versa
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFirstAViseVersa;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  The last occurrence of A with the configured occurrence of B, or vice versa
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLastAViseVersa;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  The first occurrence of A with the configured occurrence 
            /// of B happens, enable interval restart
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFirstAEnableIntervalRestart;

            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2007 Created
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
            /// 	[ruhim] 4/18/2007 Created
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
            /// 	[ruhim] 4/18/2007 Created
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
            /// 	[ruhim] 4/18/2007 Created
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
            /// 	[ruhim] 4/18/2007 Created
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
            /// Exposes access to the MonitorType translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MonitorType
            {
                get
                {
                    if ((cachedMonitorType == null))
                    {
                        cachedMonitorType = CoreManager.MomConsole.GetIntlStr(ResourceMonitorType);
                    }
                    return cachedMonitorType;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the General translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2007 Created
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
            /// Exposes access to the DefineEventLogNameA translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DefineEventLogNameA
            {
                get
                {
                    if ((cachedDefineEventLogNameA == null))
                    {
                        cachedDefineEventLogNameA = CoreManager.MomConsole.GetIntlStr(ResourceDefineEventLogNameA);
                    }
                    return cachedDefineEventLogNameA;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the BuildEventLogExpressionForA translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string BuildEventLogExpressionForA
            {
                get
                {
                    if ((cachedBuildEventLogExpressionForA == null))
                    {
                        cachedBuildEventLogExpressionForA = CoreManager.MomConsole.GetIntlStr(ResourceBuildEventLogExpressionForA);
                    }
                    return cachedBuildEventLogExpressionForA;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DefineEventLogNameB translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DefineEventLogNameB
            {
                get
                {
                    if ((cachedDefineEventLogNameB == null))
                    {
                        cachedDefineEventLogNameB = CoreManager.MomConsole.GetIntlStr(ResourceDefineEventLogNameB);
                    }
                    return cachedDefineEventLogNameB;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the BuildEventLogExpressionForB translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string BuildEventLogExpressionForB
            {
                get
                {
                    if ((cachedBuildEventLogExpressionForB == null))
                    {
                        cachedBuildEventLogExpressionForB = CoreManager.MomConsole.GetIntlStr(ResourceBuildEventLogExpressionForB);
                    }
                    return cachedBuildEventLogExpressionForB;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfigureCorrelation translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfigureCorrelation
            {
                get
                {
                    if ((cachedConfigureCorrelation == null))
                    {
                        cachedConfigureCorrelation = CoreManager.MomConsole.GetIntlStr(ResourceConfigureCorrelation);
                    }
                    return cachedConfigureCorrelation;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfigureHealth translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfigureHealth
            {
                get
                {
                    if ((cachedConfigureHealth == null))
                    {
                        cachedConfigureHealth = CoreManager.MomConsole.GetIntlStr(ResourceConfigureHealth);
                    }
                    return cachedConfigureHealth;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfigureAlerts translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2007 Created
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
            /// Exposes access to the NoCorrelation translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NoCorrelation
            {
                get
                {
                    if ((cachedNoCorrelation == null))
                    {
                        cachedNoCorrelation = CoreManager.MomConsole.GetIntlStr(ResourceNoCorrelation);
                    }
                    return cachedNoCorrelation;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CorrelationTakesPlace translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CorrelationTakesPlace
            {
                get
                {
                    if ((cachedCorrelationTakesPlace == null))
                    {
                        cachedCorrelationTakesPlace = CoreManager.MomConsole.GetIntlStr(ResourceCorrelationTakesPlace);
                    }
                    return cachedCorrelationTakesPlace;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CorrelationInterval translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CorrelationInterval
            {
                get
                {
                    if ((cachedCorrelationInterval == null))
                    {
                        cachedCorrelationInterval = CoreManager.MomConsole.GetIntlStr(ResourceCorrelationInterval);
                    }
                    return cachedCorrelationInterval;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the B translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string B
            {
                get
                {
                    if ((cachedB == null))
                    {
                        cachedB = CoreManager.MomConsole.GetIntlStr(ResourceB);
                    }
                    return cachedB;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the A translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string A
            {
                get
                {
                    if ((cachedA == null))
                    {
                        cachedA = CoreManager.MomConsole.GetIntlStr(ResourceA);
                    }
                    return cachedA;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Legend translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Legend
            {
                get
                {
                    if ((cachedLegend == null))
                    {
                        cachedLegend = CoreManager.MomConsole.GetIntlStr(ResourceLegend);
                    }
                    return cachedLegend;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SampleOfCorrelationBetweenTheFirstOccurrenceOfAAndTheThirdOccurrenceOfBOnA30SecondsIntervalAndInChro translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SampleOfCorrelationBetweenTheFirstOccurrenceOfAAndTheThirdOccurrenceOfBOnA30SecondsIntervalAndInChro
            {
                get
                {
                    if ((cachedSampleOfCorrelationBetweenTheFirstOccurrenceOfAAndTheThirdOccurrenceOfBOnA30SecondsIntervalAndInChro == null))
                    {
                        cachedSampleOfCorrelationBetweenTheFirstOccurrenceOfAAndTheThirdOccurrenceOfBOnA30SecondsIntervalAndInChro = CoreManager.MomConsole.GetIntlStr(ResourceSampleOfCorrelationBetweenTheFirstOccurrenceOfAAndTheThirdOccurrenceOfBOnA30SecondsIntervalAndInChro);
                    }
                    return cachedSampleOfCorrelationBetweenTheFirstOccurrenceOfAAndTheThirdOccurrenceOfBOnA30SecondsIntervalAndInChro;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfigureAdvancedOptions translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfigureAdvancedOptions
            {
                get
                {
                    if ((cachedConfigureAdvancedOptions == null))
                    {
                        cachedConfigureAdvancedOptions = CoreManager.MomConsole.GetIntlStr(ResourceConfigureAdvancedOptions);
                    }
                    return cachedConfigureAdvancedOptions;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NotConfigured translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NotConfigured
            {
                get
                {
                    if ((cachedNotConfigured == null))
                    {
                        cachedNotConfigured = CoreManager.MomConsole.GetIntlStr(ResourceNotConfigured);
                    }
                    return cachedNotConfigured;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the _1 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string _1
            {
                get
                {
                    if ((cached_1 == null))
                    {
                        cached_1 = CoreManager.MomConsole.GetIntlStr(Resource_1);
                    }
                    return cached_1;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Expression translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Expression
            {
                get
                {
                    if ((cachedExpression == null))
                    {
                        cachedExpression = CoreManager.MomConsole.GetIntlStr(ResourceExpression);
                    }
                    return cachedExpression;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Occurrence translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Occurrence
            {
                get
                {
                    if ((cachedOccurrence == null))
                    {
                        cachedOccurrence = CoreManager.MomConsole.GetIntlStr(ResourceOccurrence);
                    }
                    return cachedOccurrence;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdvancedOptions translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdvancedOptions
            {
                get
                {
                    if ((cachedAdvancedOptions == null))
                    {
                        cachedAdvancedOptions = CoreManager.MomConsole.GetIntlStr(ResourceAdvancedOptions);
                    }
                    return cachedAdvancedOptions;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CorrelateWhenTheFollowingHappens translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CorrelateWhenTheFollowingHappens
            {
                get
                {
                    if ((cachedCorrelateWhenTheFollowingHappens == null))
                    {
                        cachedCorrelateWhenTheFollowingHappens = CoreManager.MomConsole.GetIntlStr(ResourceCorrelateWhenTheFollowingHappens);
                    }
                    return cachedCorrelateWhenTheFollowingHappens;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfigureCorrelation2 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfigureCorrelation2
            {
                get
                {
                    if ((cachedConfigureCorrelation2 == null))
                    {
                        cachedConfigureCorrelation2 = CoreManager.MomConsole.GetIntlStr(ResourceConfigureCorrelation2);
                    }
                    return cachedConfigureCorrelation2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CorrelationInterval2 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CorrelationInterval2
            {
                get
                {
                    if ((cachedCorrelationInterval2 == null))
                    {
                        cachedCorrelationInterval2 = CoreManager.MomConsole.GetIntlStr(ResourceCorrelationInterval2);
                    }
                    return cachedCorrelationInterval2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2007 Created
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
            /// Exposes access to the CorrelatedEventsConfiguration translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CorrelatedEventsConfiguration
            {
                get
                {
                    if ((cachedCorrelatedEventsConfiguration == null))
                    {
                        cachedCorrelatedEventsConfiguration = CoreManager.MomConsole.GetIntlStr(ResourceCorrelatedEventsConfiguration);
                    }
                    return cachedCorrelatedEventsConfiguration;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the The first occurrence of A with the configured occurrence of B 
            /// in chronological order translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FirstAChronologicalOrder
            {
                get
                {
                    if ((cachedFirstAChronologicalOrder == null))
                    {
                        cachedFirstAChronologicalOrder = CoreManager.MomConsole.GetIntlStr(ResourceFirstAChronologicalOrder);
                    }
                    return cachedFirstAChronologicalOrder;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the The last occurrence of A with the configured occurrence of B 
            /// in chronological order translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LastAChronologicalOrder
            {
                get
                {
                    if ((cachedLastAChronologicalOrder == null))
                    {
                        cachedLastAChronologicalOrder = CoreManager.MomConsole.GetIntlStr(ResourceLastAChronologicalOrder);
                    }
                    return cachedLastAChronologicalOrder;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the The first occurrence of A with the configured occurrence of B, 
            /// or vice versa translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FirstAViseVersa
            {
                get
                {
                    if ((cachedFirstAViseVersa == null))
                    {
                        cachedFirstAViseVersa = CoreManager.MomConsole.GetIntlStr(ResourceFirstAViseVersa);
                    }
                    return cachedFirstAViseVersa;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the The last occurrence of A with the configured occurrence of B, 
            /// or vice versa translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LastAViseVersa
            {
                get
                {
                    if ((cachedLastAViseVersa == null))
                    {
                        cachedLastAViseVersa = CoreManager.MomConsole.GetIntlStr(ResourceLastAViseVersa);
                    }
                    return cachedLastAViseVersa;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the The first occurrence of A with the configured occurrence of B 
            /// happens, enable interval restart translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FirstAEnableIntervalRestart
            {
                get
                {
                    if ((cachedFirstAEnableIntervalRestart == null))
                    {
                        cachedFirstAEnableIntervalRestart = CoreManager.MomConsole.GetIntlStr(ResourceFirstAEnableIntervalRestart);
                    }
                    return cachedFirstAEnableIntervalRestart;
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
        /// 	[ruhim] 4/18/2007 Created
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
            /// Control ID for MonitorTypeStaticControl
            /// </summary>
            public const string MonitorTypeStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for GeneralStaticControl
            /// </summary>
            public const string GeneralStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for DefineEventLogNameAStaticControl
            /// </summary>
            public const string DefineEventLogNameAStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for BuildEventLogExpressionForAStaticControl
            /// </summary>
            public const string BuildEventLogExpressionForAStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for DefineEventLogNameBStaticControl
            /// </summary>
            public const string DefineEventLogNameBStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for BuildEventLogExpressionForBStaticControl
            /// </summary>
            public const string BuildEventLogExpressionForBStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ConfigureCorrelationStaticControl
            /// </summary>
            public const string ConfigureCorrelationStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ConfigureHealthStaticControl
            /// </summary>
            public const string ConfigureHealthStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ConfigureAlertsStaticControl
            /// </summary>
            public const string ConfigureAlertsStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for NoCorrelationStaticControl
            /// </summary>
            public const string NoCorrelationStaticControl = "labelNoCorrelation";
            
            /// <summary>
            /// Control ID for CorrelationTakesPlaceStaticControl
            /// </summary>
            public const string CorrelationTakesPlaceStaticControl = "labelCorrelationMarkers";
            
            /// <summary>
            /// Control ID for CorrelationIntervalStaticControl
            /// </summary>
            public const string CorrelationIntervalStaticControl = "labelCorrelationInterval";
            
            /// <summary>
            /// Control ID for BStaticControl
            /// </summary>
            public const string BStaticControl = "labelB";
            
            /// <summary>
            /// Control ID for AStaticControl
            /// </summary>
            public const string AStaticControl = "labelA";
            
            /// <summary>
            /// Control ID for LegendStaticControl
            /// </summary>
            public const string LegendStaticControl = "labelLegend";
            
            /// <summary>
            /// Control ID for SampleOfCorrelationBetweenTheFirstOccurrenceOfAAndTheThirdOccurrenceOfBOnA30SecondsIntervalAndInChro
            /// </summary>
            public const string SampleOfCorrelationBetweenTheFirstOccurrenceOfAAndTheThirdOccurrenceOfBOnA30SecondsIntervalAndInChro = "labelCorrelationDetails";
            
            /// <summary>
            /// Control ID for CorrelateWhenComboBox
            /// </summary>
            public const string CorrelateWhenComboBox = "comboBoxCorrelate";
            
            /// <summary>
            /// Control ID for ConfigureAdvancedOptionsButton
            /// </summary>
            public const string ConfigureAdvancedOptionsButton = "buttonAdvancedOptions";
            
            /// <summary>
            /// Control ID for NotConfiguredStaticControl
            /// </summary>
            public const string NotConfiguredStaticControl = "labelExpressionValue";
            
            /// <summary>
            /// Control ID for _1StaticControl
            /// </summary>
            public const string _1StaticControl = "labelOccurrenceValue";
            
            /// <summary>
            /// Control ID for ExpressionStaticControl
            /// </summary>
            public const string ExpressionStaticControl = "labelExpression";
            
            /// <summary>
            /// Control ID for OccurrenceStaticControl
            /// </summary>
            public const string OccurrenceStaticControl = "labelOccurrence";
            
            /// <summary>
            /// Control ID for AdvancedOptionsStaticControl
            /// </summary>
            public const string AdvancedOptionsStaticControl = "labelAdvancedOptions";
            
            /// <summary>
            /// Control ID for CorrelateWhenTheFollowingHappensStaticControl
            /// </summary>
            public const string CorrelateWhenTheFollowingHappensStaticControl = "labelOrder";
            
            /// <summary>
            /// Control ID for ConfigureCorrelationStaticControl2
            /// </summary>
            public const string ConfigureCorrelationStaticControl2 = "pageSectionLabel";
            
            /// <summary>
            /// Control ID for CorrelationIntervalStaticControl2
            /// </summary>
            public const string CorrelationIntervalStaticControl2 = "labelInterval";
            
            /// <summary>
            /// Control ID for SpecifyCorrelationUnitsComboBox
            /// </summary>
            public const string SpecifyCorrelationUnitsComboBox = "comboBoxUnit";
            
            /// <summary>
            /// Control ID for CorrelationIntervalComboBox
            /// </summary>
            public const string CorrelationIntervalComboBox = "numericDropDown";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for CorrelatedEventsConfigurationStaticControl
            /// </summary>
            public const string CorrelatedEventsConfigurationStaticControl = "headerLabel";
        }
        #endregion
    }
}
