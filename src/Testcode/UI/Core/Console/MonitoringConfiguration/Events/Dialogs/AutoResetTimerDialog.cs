// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AutoResetTimerDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[mbickle] 05MAY06 Created
//  [ruhim]   18April07 Adding resource strings for Timer Units  
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Events.Dialogs
{
    #region Using directive
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console.MonitoringConfiguration;
    #endregion

    #region Interface Definition - IAutoResetTimerDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAutoResetTimerDialogControls, for AutoResetTimerDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[mbickle] 05MAY06 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAutoResetTimerDialogControls
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
        /// Read-only property to access EventLogTypeStaticControl
        /// </summary>
        StaticControl EventLogTypeStaticControl
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
        /// Read-only property to access AutoResetTimerStaticControl
        /// </summary>
        StaticControl AutoResetTimerStaticControl
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
        /// Read-only property to access ProductKnowledgeStaticControl
        /// </summary>
        StaticControl ProductKnowledgeStaticControl
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
        /// Read-only property to access SpecifyTheWaitUnitsStaticControl
        /// </summary>
        StaticControl SpecifyTheWaitUnitsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SpecifyTheTimerWaitStaticControl
        /// </summary>
        StaticControl SpecifyTheTimerWaitStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SpecifyTheWaitUnitsComboBox
        /// </summary>
        ComboBox SpecifyTheWaitUnitsComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SpecifyTheTimerWaitComboBox
        /// </summary>
        EditComboBox SpecifyTheTimerWaitComboBox
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
        /// Read-only property to access SpecifyTheWaitUnitsStaticControl2
        /// </summary>
        StaticControl SpecifyTheWaitUnitsStaticControl2
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
    /// 	[mbickle] 05MAY06 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class AutoResetTimerDialog : Dialog, IAutoResetTimerDialogControls
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
        /// Cache to hold a reference to EventLogTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEventLogTypeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to BuildEventExpressionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedBuildEventExpressionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AutoResetTimerStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAutoResetTimerStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureHealthStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureHealthStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureAlertsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureAlertsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ProductKnowledgeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedProductKnowledgeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to GeneralStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyTheWaitUnitsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyTheWaitUnitsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyTheTimerWaitStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyTheTimerWaitStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyTheWaitUnitsComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedSpecifyTheWaitUnitsComboBox;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyTheTimerWaitComboBox of type ComboBox
        /// </summary>
        private EditComboBox cachedSpecifyTheTimerWaitComboBox;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyTheWaitUnitsStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyTheWaitUnitsStaticControl2;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of AutoResetTimerDialog of type App
        /// </param>
        /// <param name="windowCaption">MonitoringConfiguration.WindowCaptions</param>
        /// <history>
        /// 	[mbickle] 05MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AutoResetTimerDialog(Mom.Test.UI.Core.Console.MomConsoleApp app, MonitoringConfiguration.WindowCaptions windowCaption)
            : base(app, Init(app, windowCaption))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
        }
        #endregion
        
        #region IAutoResetTimerDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[mbickle] 05MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAutoResetTimerDialogControls Controls
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
        ///  Routine to set/get the text in control SpecifyTheWaitUnits
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 05MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SpecifyTheWaitUnitsText
        {
            get
            {
                return this.Controls.SpecifyTheWaitUnitsComboBox.Text;
            }
            
            set
            {
                this.Controls.SpecifyTheWaitUnitsComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control SpecifyTheTimerWait
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 05MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SpecifyTheTimerWaitText
        {
            get
            {
                return this.Controls.SpecifyTheTimerWaitComboBox.Text;
            }
            
            set
            {
                UIUtilities.SetControlValue(this.Controls.SpecifyTheTimerWaitComboBox, value);
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 05MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAutoResetTimerDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, AutoResetTimerDialog.ControlIDs.PreviousButton);
                }
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 05MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAutoResetTimerDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, AutoResetTimerDialog.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 05MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAutoResetTimerDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, AutoResetTimerDialog.ControlIDs.CreateButton);
                }
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 05MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAutoResetTimerDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AutoResetTimerDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitorTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 05MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAutoResetTimerDialogControls.MonitorTypeStaticControl
        {
            get
            {
                if ((this.cachedMonitorTypeStaticControl == null))
                {
                    this.cachedMonitorTypeStaticControl = new StaticControl(this, AutoResetTimerDialog.ControlIDs.MonitorTypeStaticControl);
                }
                return this.cachedMonitorTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EventLogTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 05MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAutoResetTimerDialogControls.EventLogTypeStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedEventLogTypeStaticControl == null))
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
                    this.cachedEventLogTypeStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedEventLogTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BuildEventExpressionStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 05MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAutoResetTimerDialogControls.BuildEventExpressionStaticControl
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
                    for (i = 0; (i <= 1); i = (i + 1))
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
        ///  Exposes access to the AutoResetTimerStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 05MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAutoResetTimerDialogControls.AutoResetTimerStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedAutoResetTimerStaticControl == null))
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
                    this.cachedAutoResetTimerStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedAutoResetTimerStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureHealthStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 05MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAutoResetTimerDialogControls.ConfigureHealthStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedConfigureHealthStaticControl == null))
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
        /// 	[mbickle] 05MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAutoResetTimerDialogControls.ConfigureAlertsStaticControl
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
                    for (i = 0; (i <= 4); i = (i + 1))
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
        ///  Exposes access to the ProductKnowledgeStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 05MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAutoResetTimerDialogControls.ProductKnowledgeStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedProductKnowledgeStaticControl == null))
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
                    this.cachedProductKnowledgeStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedProductKnowledgeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 05MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAutoResetTimerDialogControls.GeneralStaticControl
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
                    for (i = 0; (i <= 6); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedGeneralStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedGeneralStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyTheWaitUnitsStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 05MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAutoResetTimerDialogControls.SpecifyTheWaitUnitsStaticControl
        {
            get
            {
                if ((this.cachedSpecifyTheWaitUnitsStaticControl == null))
                {
                    this.cachedSpecifyTheWaitUnitsStaticControl = new StaticControl(this, AutoResetTimerDialog.ControlIDs.SpecifyTheWaitUnitsStaticControl);
                }
                return this.cachedSpecifyTheWaitUnitsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyTheTimerWaitStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 05MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAutoResetTimerDialogControls.SpecifyTheTimerWaitStaticControl
        {
            get
            {
                if ((this.cachedSpecifyTheTimerWaitStaticControl == null))
                {
                    this.cachedSpecifyTheTimerWaitStaticControl = new StaticControl(this, AutoResetTimerDialog.ControlIDs.SpecifyTheTimerWaitStaticControl);
                }
                return this.cachedSpecifyTheTimerWaitStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyTheWaitUnitsComboBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 05MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IAutoResetTimerDialogControls.SpecifyTheWaitUnitsComboBox
        {
            get
            {
                if ((this.cachedSpecifyTheWaitUnitsComboBox == null))
                {
                    this.cachedSpecifyTheWaitUnitsComboBox = new ComboBox(this, AutoResetTimerDialog.ControlIDs.SpecifyTheWaitUnitsComboBox);
                }
                return this.cachedSpecifyTheWaitUnitsComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyTheTimerWaitComboBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 05MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IAutoResetTimerDialogControls.SpecifyTheTimerWaitComboBox
        {
            get
            {
                if ((this.cachedSpecifyTheTimerWaitComboBox == null))
                {
                    this.cachedSpecifyTheTimerWaitComboBox = new EditComboBox(this, AutoResetTimerDialog.ControlIDs.SpecifyTheTimerWaitComboBox);
                }
                return this.cachedSpecifyTheTimerWaitComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 05MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAutoResetTimerDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, AutoResetTimerDialog.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyTheWaitUnitsStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 05MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAutoResetTimerDialogControls.SpecifyTheWaitUnitsStaticControl2
        {
            get
            {
                if ((this.cachedSpecifyTheWaitUnitsStaticControl2 == null))
                {
                    this.cachedSpecifyTheWaitUnitsStaticControl2 = new StaticControl(this, AutoResetTimerDialog.ControlIDs.SpecifyTheWaitUnitsStaticControl2);
                }
                return this.cachedSpecifyTheWaitUnitsStaticControl2;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[mbickle] 05MAY06 Created
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
        /// 	[mbickle] 05MAY06 Created
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
        /// 	[mbickle] 05MAY06 Created
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
        /// 	[mbickle] 05MAY06 Created
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
        ///  <param name="app">App owning the dialog.</param>
        /// <param name="windowCaption">Wizard dialog title.</param>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
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
        /// 	[mbickle] 05MAY06 Created
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
            private const string ResourceDialogTitle = "Create Monitor Wizard";
            
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
            /// Contains resource string for:  MonitorType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMonitorType = ";Monitor Type;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseM" +
                "anagement.Internal.UI.Authoring.Pages.ChooseMonitorTypePage;$this.TabName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EventLogType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEventLogType = ";Event Log Type;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpris" +
                "eManagement.Internal.UI.Authoring.Pages.EvtLogDataSource;$this.NavigationText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  BuildEventExpression
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceBuildEventExpression = ";Build Event Expression;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.E" +
                "nterpriseManagement.Internal.UI.Authoring.Pages.ExpressionEvaluatorCondition;$this.N" +
                "avigationText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AutoResetTimer
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAutoResetTimer = "Auto Reset Timer";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureHealth
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureHealth = ";Configure Health;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpr" +
                "iseManagement.Internal.UI.Authoring.Pages.OperationalStatesMappi" +
                "ngPage;$this.NavigationText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureAlerts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureAlerts = ";Configure Alerts;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpr" +
                "iseManagement.Internal.UI.Authoring.Pages.AlertConfiguration;$this.NavigationText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ProductKnowledge
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceProductKnowledge = ";Product Knowledge;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterp" +
                "riseManagement.Internal.UI.Authoring.Pages.ProductKnowledgePage;$this.TabName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  General
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneral = ";General;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.Administration.AdminResources;GeneralPropertyPageTabText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpecifyTheWaitUnits
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecifyTheWaitUnits = ";Specify the wait before triggering the auto reset state of the monitor;ManagedSt" +
                "ring;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Internal" +
                ".UI.Authoring.Pages.TimerConditionPage;pageSectionLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpecifyTheTimerWait
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecifyTheTimerWait = ";Specify the timer &wait:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft" +
                ".EnterpriseManagement.Internal.UI.Authoring.Pages.TimerConditionPage;labelWait.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mo" +
                "m.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpecifyTheWaitUnits2
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecifyTheWaitUnits2 = "Specify the wait before triggering the auto reset state of the monitor.";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Days Timer Unit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDaysTimerUnit =
                ";Days;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.IntervalUnitControl;comboBoxUnit.Items3";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Hours Timer Unit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHoursTimerUnit =
                ";Hours;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.IntervalUnitControl;comboBoxUnit.Items2";                

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Minutes Timer Unit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMinutesTimerUnit =
                ";Minutes;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.IntervalUnitControl;comboBoxUnit.Items1";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Seconds Timer Unit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSecondsTimerUnit =
                ";Seconds;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.IntervalUnitControl;comboBoxUnit.Items";

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
            /// Caches the translated resource string for:  EventLogType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEventLogType;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  BuildEventExpression
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBuildEventExpression;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AutoResetTimer
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAutoResetTimer;
            
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
            /// Caches the translated resource string for:  ProductKnowledge
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedProductKnowledge;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  General
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneral;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpecifyTheWaitUnits
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpecifyTheWaitUnits;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpecifyTheTimerWait
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpecifyTheTimerWait;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpecifyTheWaitUnits2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpecifyTheWaitUnits2;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Days Timer Unit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDaysTimerUnit;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Hours Timer Unit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHoursTimerUnit;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Minutes Timer Unit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMinutesTimerUnit;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Seconds Timer Unit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSecondsTimerUnit;

            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 05MAY06 Created
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
            /// 	[mbickle] 05MAY06 Created
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
            /// 	[mbickle] 05MAY06 Created
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
            /// 	[mbickle] 05MAY06 Created
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
            /// 	[mbickle] 05MAY06 Created
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
            /// 	[mbickle] 05MAY06 Created
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
            /// Exposes access to the EventLogType translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 05MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EventLogType
            {
                get
                {
                    if ((cachedEventLogType == null))
                    {
                        cachedEventLogType = CoreManager.MomConsole.GetIntlStr(ResourceEventLogType);
                    }
                    return cachedEventLogType;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the BuildEventExpression translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 05MAY06 Created
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
            /// Exposes access to the AutoResetTimer translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 05MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AutoResetTimer
            {
                get
                {
                    if ((cachedAutoResetTimer == null))
                    {
                        cachedAutoResetTimer = CoreManager.MomConsole.GetIntlStr(ResourceAutoResetTimer);
                    }
                    return cachedAutoResetTimer;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfigureHealth translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 05MAY06 Created
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
            /// 	[mbickle] 05MAY06 Created
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
            /// Exposes access to the ProductKnowledge translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 05MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ProductKnowledge
            {
                get
                {
                    if ((cachedProductKnowledge == null))
                    {
                        cachedProductKnowledge = CoreManager.MomConsole.GetIntlStr(ResourceProductKnowledge);
                    }
                    return cachedProductKnowledge;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the General translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 05MAY06 Created
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
            /// Exposes access to the SpecifyTheWaitUnits translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 05MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpecifyTheWaitUnits
            {
                get
                {
                    if ((cachedSpecifyTheWaitUnits == null))
                    {
                        cachedSpecifyTheWaitUnits = CoreManager.MomConsole.GetIntlStr(ResourceSpecifyTheWaitUnits);
                    }
                    return cachedSpecifyTheWaitUnits;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SpecifyTheTimerWait translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 05MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpecifyTheTimerWait
            {
                get
                {
                    if ((cachedSpecifyTheTimerWait == null))
                    {
                        cachedSpecifyTheTimerWait = CoreManager.MomConsole.GetIntlStr(ResourceSpecifyTheTimerWait);
                    }
                    return cachedSpecifyTheTimerWait;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 05MAY06 Created
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
            /// Exposes access to the SpecifyTheWaitUnits2 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 05MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpecifyTheWaitUnits2
            {
                get
                {
                    if ((cachedSpecifyTheWaitUnits2 == null))
                    {
                        cachedSpecifyTheWaitUnits2 = CoreManager.MomConsole.GetIntlStr(ResourceSpecifyTheWaitUnits2);
                    }
                    return cachedSpecifyTheWaitUnits2;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Days translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 18April07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DaysTimerUnit
            {
                get
                {
                    if ((cachedDaysTimerUnit == null))
                    {
                        cachedDaysTimerUnit = CoreManager.MomConsole.GetIntlStr(ResourceDaysTimerUnit);
                    }
                    return cachedDaysTimerUnit;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Hours translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 18April07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string HoursTimerUnit
            {
                get
                {
                    if ((cachedHoursTimerUnit == null))
                    {
                        cachedHoursTimerUnit = CoreManager.MomConsole.GetIntlStr(ResourceHoursTimerUnit);
                    }
                    return cachedHoursTimerUnit;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Minutes translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 18April07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MinutesTimerUnit
            {
                get
                {
                    if ((cachedMinutesTimerUnit == null))
                    {
                        cachedMinutesTimerUnit = CoreManager.MomConsole.GetIntlStr(ResourceMinutesTimerUnit);
                    }
                    return cachedMinutesTimerUnit;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Seconds translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 18April07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SecondsTimerUnit
            {
                get
                {
                    if ((cachedSecondsTimerUnit == null))
                    {
                        cachedSecondsTimerUnit = CoreManager.MomConsole.GetIntlStr(ResourceSecondsTimerUnit);
                    }
                    return cachedSecondsTimerUnit;
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
        /// 	[mbickle] 05MAY06 Created
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
            /// Control ID for EventLogTypeStaticControl
            /// </summary>
            public const string EventLogTypeStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for BuildEventExpressionStaticControl
            /// </summary>
            public const string BuildEventExpressionStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for AutoResetTimerStaticControl
            /// </summary>
            public const string AutoResetTimerStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ConfigureHealthStaticControl
            /// </summary>
            public const string ConfigureHealthStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ConfigureAlertsStaticControl
            /// </summary>
            public const string ConfigureAlertsStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ProductKnowledgeStaticControl
            /// </summary>
            public const string ProductKnowledgeStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for GeneralStaticControl
            /// </summary>
            public const string GeneralStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for SpecifyTheWaitUnitsStaticControl
            /// </summary>
            public const string SpecifyTheWaitUnitsStaticControl = "pageSectionLabel";
            
            /// <summary>
            /// Control ID for SpecifyTheTimerWaitStaticControl
            /// </summary>
            public const string SpecifyTheTimerWaitStaticControl = "labelWait";
            
            /// <summary>
            /// Control ID for SpecifyTheWaitUnitsComboBox
            /// </summary>
            public const string SpecifyTheWaitUnitsComboBox = "comboBoxUnit";
            
            /// <summary>
            /// Control ID for SpecifyTheTimerWaitComboBox
            /// </summary>
            public const string SpecifyTheTimerWaitComboBox = "numericDropDown";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for SpecifyTheWaitUnitsStaticControl2
            /// </summary>
            public const string SpecifyTheWaitUnitsStaticControl2 = "headerLabel";
        }
        #endregion
    }
}
