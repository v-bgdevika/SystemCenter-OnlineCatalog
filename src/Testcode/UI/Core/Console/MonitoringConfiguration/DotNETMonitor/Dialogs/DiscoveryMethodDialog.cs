// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="DiscoveryMethodDialog.cs">
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
    
    #region Radio Group Enumeration - RadioGroup0

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group RadioGroup0
    /// </summary>
    /// <history>
    /// 	[faizalk] 9/27/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum RadioGroup0
    {
        /// <summary>
        /// SelectADiscoveredASPNETApplication = 0
        /// </summary>
        SelectADiscoveredASPNETApplication = 0,
        
        /// <summary>
        /// AddNewASPNETApplication = 1
        /// </summary>
        AddNewASPNETApplication = 1,
    }
    #endregion
    
    #region Interface Definition - IDiscoveryMethodDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IDiscoveryMethodDialogControls, for DiscoveryMethodDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[faizalk] 9/27/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IDiscoveryMethodDialogControls
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
        /// Read-only property to access NoteYourChangesWillNotTakeEffectUntilYouRestartIISYouCanDoItOnCompletetionOfTheTemplateProcessOrRest
        /// </summary>
        StaticControl NoteYourChangesWillNotTakeEffectUntilYouRestartIISYouCanDoItOnCompletetionOfTheTemplateProcessOrRest
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RestartIISCheckBox
        /// </summary>
        CheckBox RestartIISCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access InternetInformationServicesStaticControl
        /// </summary>
        StaticControl InternetInformationServicesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DiscoveryTypeStaticControl
        /// </summary>
        StaticControl DiscoveryTypeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectADiscoveredASPNETApplicationRadioButton
        /// </summary>
        RadioButton SelectADiscoveredASPNETApplicationRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AddNewASPNETApplicationRadioButton
        /// </summary>
        RadioButton AddNewASPNETApplicationRadioButton
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
        /// Read-only property to access SelectADiscoveredApplicationOrCreateANewOneStaticControl
        /// </summary>
        StaticControl SelectADiscoveredApplicationOrCreateANewOneStaticControl
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
    public class DiscoveryMethodDialog : Dialog, IDiscoveryMethodDialogControls
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
        /// Cache to hold a reference to NoteYourChangesWillNotTakeEffectUntilYouRestartIISYouCanDoItOnCompletetionOfTheTemplateProcessOrRest of type StaticControl
        /// </summary>
        private StaticControl cachedNoteYourChangesWillNotTakeEffectUntilYouRestartIISYouCanDoItOnCompletetionOfTheTemplateProcessOrRest;
        
        /// <summary>
        /// Cache to hold a reference to RestartIISCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedRestartIISCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to InternetInformationServicesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedInternetInformationServicesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DiscoveryTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDiscoveryTypeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectADiscoveredASPNETApplicationRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedSelectADiscoveredASPNETApplicationRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to AddNewASPNETApplicationRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedAddNewASPNETApplicationRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectADiscoveredApplicationOrCreateANewOneStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectADiscoveredApplicationOrCreateANewOneStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of DiscoveryMethodDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public DiscoveryMethodDialog(ConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group RadioGroup0
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual RadioGroup0 RadioGroup0
        {
            get
            {
                if ((this.Controls.SelectADiscoveredASPNETApplicationRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroup0.SelectADiscoveredASPNETApplication;
                }
                
                if ((this.Controls.AddNewASPNETApplicationRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroup0.AddNewASPNETApplication;
                }
                
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == RadioGroup0.SelectADiscoveredASPNETApplication))
                {
                    this.Controls.SelectADiscoveredASPNETApplicationRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == RadioGroup0.AddNewASPNETApplication))
                    {
                        this.Controls.AddNewASPNETApplicationRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region IDiscoveryMethodDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IDiscoveryMethodDialogControls Controls
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
        ///  Property to handle checkbox RestartIIS
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool RestartIIS
        {
            get
            {
                return this.Controls.RestartIISCheckBox.Checked;
            }
            
            set
            {
                this.Controls.RestartIISCheckBox.Checked = value;
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
        Button IDiscoveryMethodDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, DiscoveryMethodDialog.ControlIDs.PreviousButton);
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
        Button IDiscoveryMethodDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, DiscoveryMethodDialog.ControlIDs.NextButton);
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
        Button IDiscoveryMethodDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, DiscoveryMethodDialog.ControlIDs.CreateButton);
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
        Button IDiscoveryMethodDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, DiscoveryMethodDialog.ControlIDs.CancelButton);
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
        StaticControl IDiscoveryMethodDialogControls.MonitoringTypeStaticControl
        {
            get
            {
                if ((this.cachedMonitoringTypeStaticControl == null))
                {
                    this.cachedMonitoringTypeStaticControl = new StaticControl(this, DiscoveryMethodDialog.ControlIDs.MonitoringTypeStaticControl);
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
        StaticControl IDiscoveryMethodDialogControls.GeneralPropertiesStaticControl
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
        StaticControl IDiscoveryMethodDialogControls.DiscoveryMethodStaticControl
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
        StaticControl IDiscoveryMethodDialogControls.ASPNETApplicationStaticControl
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
        StaticControl IDiscoveryMethodDialogControls.ExceptionsStaticControl
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
        StaticControl IDiscoveryMethodDialogControls.PerformanceStaticControl
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
        StaticControl IDiscoveryMethodDialogControls.SummaryStaticControl
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
        ///  Exposes access to the NoteYourChangesWillNotTakeEffectUntilYouRestartIISYouCanDoItOnCompletetionOfTheTemplateProcessOrRest control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiscoveryMethodDialogControls.NoteYourChangesWillNotTakeEffectUntilYouRestartIISYouCanDoItOnCompletetionOfTheTemplateProcessOrRest
        {
            get
            {
                if ((this.cachedNoteYourChangesWillNotTakeEffectUntilYouRestartIISYouCanDoItOnCompletetionOfTheTemplateProcessOrRest == null))
                {
                    this.cachedNoteYourChangesWillNotTakeEffectUntilYouRestartIISYouCanDoItOnCompletetionOfTheTemplateProcessOrRest = new StaticControl(this, DiscoveryMethodDialog.ControlIDs.NoteYourChangesWillNotTakeEffectUntilYouRestartIISYouCanDoItOnCompletetionOfTheTemplateProcessOrRest);
                }
                
                return this.cachedNoteYourChangesWillNotTakeEffectUntilYouRestartIISYouCanDoItOnCompletetionOfTheTemplateProcessOrRest;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RestartIISCheckBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IDiscoveryMethodDialogControls.RestartIISCheckBox
        {
            get
            {
                if ((this.cachedRestartIISCheckBox == null))
                {
                    this.cachedRestartIISCheckBox = new CheckBox(this, DiscoveryMethodDialog.ControlIDs.RestartIISCheckBox);
                }
                
                return this.cachedRestartIISCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the InternetInformationServicesStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiscoveryMethodDialogControls.InternetInformationServicesStaticControl
        {
            get
            {
                if ((this.cachedInternetInformationServicesStaticControl == null))
                {
                    this.cachedInternetInformationServicesStaticControl = new StaticControl(this, DiscoveryMethodDialog.ControlIDs.InternetInformationServicesStaticControl);
                }
                
                return this.cachedInternetInformationServicesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DiscoveryTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiscoveryMethodDialogControls.DiscoveryTypeStaticControl
        {
            get
            {
                if ((this.cachedDiscoveryTypeStaticControl == null))
                {
                    this.cachedDiscoveryTypeStaticControl = new StaticControl(this, DiscoveryMethodDialog.ControlIDs.DiscoveryTypeStaticControl);
                }
                
                return this.cachedDiscoveryTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectADiscoveredASPNETApplicationRadioButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IDiscoveryMethodDialogControls.SelectADiscoveredASPNETApplicationRadioButton
        {
            get
            {
                if ((this.cachedSelectADiscoveredASPNETApplicationRadioButton == null))
                {
                    this.cachedSelectADiscoveredASPNETApplicationRadioButton = new RadioButton(this, DiscoveryMethodDialog.ControlIDs.SelectADiscoveredASPNETApplicationRadioButton);
                }
                
                return this.cachedSelectADiscoveredASPNETApplicationRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddNewASPNETApplicationRadioButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IDiscoveryMethodDialogControls.AddNewASPNETApplicationRadioButton
        {
            get
            {
                if ((this.cachedAddNewASPNETApplicationRadioButton == null))
                {
                    this.cachedAddNewASPNETApplicationRadioButton = new RadioButton(this, DiscoveryMethodDialog.ControlIDs.AddNewASPNETApplicationRadioButton);
                }
                
                return this.cachedAddNewASPNETApplicationRadioButton;
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
        StaticControl IDiscoveryMethodDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, DiscoveryMethodDialog.ControlIDs.HelpStaticControl);
                }
                
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectADiscoveredApplicationOrCreateANewOneStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiscoveryMethodDialogControls.SelectADiscoveredApplicationOrCreateANewOneStaticControl
        {
            get
            {
                if ((this.cachedSelectADiscoveredApplicationOrCreateANewOneStaticControl == null))
                {
                    this.cachedSelectADiscoveredApplicationOrCreateANewOneStaticControl = new StaticControl(this, DiscoveryMethodDialog.ControlIDs.SelectADiscoveredApplicationOrCreateANewOneStaticControl);
                }
                
                return this.cachedSelectADiscoveredApplicationOrCreateANewOneStaticControl;
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
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button RestartIIS
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickRestartIIS()
        {
            this.Controls.RestartIISCheckBox.Click();
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
            /// Contains resource string for:  NoteYourChangesWillNotTakeEffectUntilYouRestartIISYouCanDoItOnCompletetionOfTheTemplateProcessOrRest
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceNoteYourChangesWillNotTakeEffectUntilYouRestartIISYouCanDoItOnCompletetionOfTheTemplateProcessOrRest = "Note: Your changes will not take effect until you restart IIS. You can do it on c" +
                "ompletetion of the template process or restart it manually at a later time.";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RestartIIS
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceRestartIIS = "&Restart IIS ";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  InternetInformationServices
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceInternetInformationServices = "Internet Information Services";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DiscoveryType
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceDiscoveryType = "Discovery Type";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectADiscoveredASPNETApplication
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectADiscoveredASPNETApplication = "Select a discovered ASP.NET Application";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AddNewASPNETApplication
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAddNewASPNETApplication = "Add new ASP.NET Application";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.Ent" +
                "erpriseManagement.Internal.UI.Authoring.Common.CommonResources;CommandHelp";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectADiscoveredApplicationOrCreateANewOne
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectADiscoveredApplicationOrCreateANewOne = "Select a discovered application or create a new one";
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
            /// Caches the translated resource string for:  NoteYourChangesWillNotTakeEffectUntilYouRestartIISYouCanDoItOnCompletetionOfTheTemplateProcessOrRest
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNoteYourChangesWillNotTakeEffectUntilYouRestartIISYouCanDoItOnCompletetionOfTheTemplateProcessOrRest;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RestartIIS
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRestartIIS;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  InternetInformationServices
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedInternetInformationServices;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DiscoveryType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDiscoveryType;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectADiscoveredASPNETApplication
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectADiscoveredASPNETApplication;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AddNewASPNETApplication
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAddNewASPNETApplication;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectADiscoveredApplicationOrCreateANewOne
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectADiscoveredApplicationOrCreateANewOne;
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
            /// Exposes access to the NoteYourChangesWillNotTakeEffectUntilYouRestartIISYouCanDoItOnCompletetionOfTheTemplateProcessOrRest translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NoteYourChangesWillNotTakeEffectUntilYouRestartIISYouCanDoItOnCompletetionOfTheTemplateProcessOrRest
            {
                get
                {
                    if ((cachedNoteYourChangesWillNotTakeEffectUntilYouRestartIISYouCanDoItOnCompletetionOfTheTemplateProcessOrRest == null))
                    {
                        cachedNoteYourChangesWillNotTakeEffectUntilYouRestartIISYouCanDoItOnCompletetionOfTheTemplateProcessOrRest = CoreManager.MomConsole.GetIntlStr(ResourceNoteYourChangesWillNotTakeEffectUntilYouRestartIISYouCanDoItOnCompletetionOfTheTemplateProcessOrRest);
                    }
                    
                    return cachedNoteYourChangesWillNotTakeEffectUntilYouRestartIISYouCanDoItOnCompletetionOfTheTemplateProcessOrRest;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RestartIIS translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RestartIIS
            {
                get
                {
                    if ((cachedRestartIIS == null))
                    {
                        cachedRestartIIS = CoreManager.MomConsole.GetIntlStr(ResourceRestartIIS);
                    }
                    
                    return cachedRestartIIS;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the InternetInformationServices translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string InternetInformationServices
            {
                get
                {
                    if ((cachedInternetInformationServices == null))
                    {
                        cachedInternetInformationServices = CoreManager.MomConsole.GetIntlStr(ResourceInternetInformationServices);
                    }
                    
                    return cachedInternetInformationServices;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DiscoveryType translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DiscoveryType
            {
                get
                {
                    if ((cachedDiscoveryType == null))
                    {
                        cachedDiscoveryType = CoreManager.MomConsole.GetIntlStr(ResourceDiscoveryType);
                    }
                    
                    return cachedDiscoveryType;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectADiscoveredASPNETApplication translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectADiscoveredASPNETApplication
            {
                get
                {
                    if ((cachedSelectADiscoveredASPNETApplication == null))
                    {
                        cachedSelectADiscoveredASPNETApplication = CoreManager.MomConsole.GetIntlStr(ResourceSelectADiscoveredASPNETApplication);
                    }
                    
                    return cachedSelectADiscoveredASPNETApplication;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AddNewASPNETApplication translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AddNewASPNETApplication
            {
                get
                {
                    if ((cachedAddNewASPNETApplication == null))
                    {
                        cachedAddNewASPNETApplication = CoreManager.MomConsole.GetIntlStr(ResourceAddNewASPNETApplication);
                    }
                    
                    return cachedAddNewASPNETApplication;
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
            /// Exposes access to the SelectADiscoveredApplicationOrCreateANewOne translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectADiscoveredApplicationOrCreateANewOne
            {
                get
                {
                    if ((cachedSelectADiscoveredApplicationOrCreateANewOne == null))
                    {
                        cachedSelectADiscoveredApplicationOrCreateANewOne = CoreManager.MomConsole.GetIntlStr(ResourceSelectADiscoveredApplicationOrCreateANewOne);
                    }
                    
                    return cachedSelectADiscoveredApplicationOrCreateANewOne;
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
            /// Control ID for NoteYourChangesWillNotTakeEffectUntilYouRestartIISYouCanDoItOnCompletetionOfTheTemplateProcessOrRest
            /// </summary>
            public const string NoteYourChangesWillNotTakeEffectUntilYouRestartIISYouCanDoItOnCompletetionOfTheTemplateProcessOrRest = "label1";
            
            /// <summary>
            /// Control ID for RestartIISCheckBox
            /// </summary>
            public const string RestartIISCheckBox = "idRestartIIS";
            
            /// <summary>
            /// Control ID for InternetInformationServicesStaticControl
            /// </summary>
            public const string InternetInformationServicesStaticControl = "pageSectionLabel1";
            
            /// <summary>
            /// Control ID for DiscoveryTypeStaticControl
            /// </summary>
            public const string DiscoveryTypeStaticControl = "pageSectionLabel";
            
            /// <summary>
            /// Control ID for SelectADiscoveredASPNETApplicationRadioButton
            /// </summary>
            public const string SelectADiscoveredASPNETApplicationRadioButton = "radioDiscoveredApplication";
            
            /// <summary>
            /// Control ID for AddNewASPNETApplicationRadioButton
            /// </summary>
            public const string AddNewASPNETApplicationRadioButton = "radioNewApplication";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for SelectADiscoveredApplicationOrCreateANewOneStaticControl
            /// </summary>
            public const string SelectADiscoveredApplicationOrCreateANewOneStaticControl = "headerLabel";
        }
        #endregion
    }
}
