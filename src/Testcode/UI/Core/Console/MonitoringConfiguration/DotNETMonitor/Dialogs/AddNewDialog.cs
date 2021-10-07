// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AddNewDialog.cs">
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
    
    #region Interface Definition - IAddNewDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAddNewDialogControls, for AddNewDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[faizalk] 9/27/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAddNewDialogControls
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
        /// Read-only property to access DiscoveryTypeTextBox
        /// </summary>
        TextBox DiscoveryTypeTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NameStaticControl
        /// </summary>
        StaticControl NameStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WebSitesStaticControl
        /// </summary>
        StaticControl WebSitesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NoteYourChangesWillNotTakeEffectUntilYouRestartIISYouCanDoItOnCompletetionOfTheTemplateProcessOrRest
        /// </summary>
        ListView NoteYourChangesWillNotTakeEffectUntilYouRestartIISYouCanDoItOnCompletetionOfTheTemplateProcessOrRest
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DiscoveryTypeTextBox2
        /// </summary>
        TextBox DiscoveryTypeTextBox2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access IISApplicationNameStaticControl
        /// </summary>
        StaticControl IISApplicationNameStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HelpTextBox
        /// </summary>
        TextBox HelpTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ApplicationVRootStaticControl
        /// </summary>
        StaticControl ApplicationVRootStaticControl
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
        /// Read-only property to access ASPNETApplicationToBeMonitoredStaticControl
        /// </summary>
        StaticControl ASPNETApplicationToBeMonitoredStaticControl
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
    public class AddNewDialog : Dialog, IAddNewDialogControls
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
        /// Cache to hold a reference to DiscoveryTypeTextBox of type TextBox
        /// </summary>
        private TextBox cachedDiscoveryTypeTextBox;
        
        /// <summary>
        /// Cache to hold a reference to NameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNameStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to WebSitesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWebSitesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to NoteYourChangesWillNotTakeEffectUntilYouRestartIISYouCanDoItOnCompletetionOfTheTemplateProcessOrRest of type ListView
        /// </summary>
        private ListView cachedNoteYourChangesWillNotTakeEffectUntilYouRestartIISYouCanDoItOnCompletetionOfTheTemplateProcessOrRest;
        
        /// <summary>
        /// Cache to hold a reference to DiscoveryTypeTextBox2 of type TextBox
        /// </summary>
        private TextBox cachedDiscoveryTypeTextBox2;
        
        /// <summary>
        /// Cache to hold a reference to IISApplicationNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedIISApplicationNameStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpTextBox of type TextBox
        /// </summary>
        private TextBox cachedHelpTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ApplicationVRootStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedApplicationVRootStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ASPNETApplicationToBeMonitoredStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedASPNETApplicationToBeMonitoredStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of AddNewDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AddNewDialog(ConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IAddNewDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAddNewDialogControls Controls
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
        ///  Routine to set/get the text in control DiscoveryType
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DiscoveryTypeText
        {
            get
            {
                return this.Controls.DiscoveryTypeTextBox.Text;
            }
            
            set
            {
                this.Controls.DiscoveryTypeTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control DiscoveryType2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DiscoveryType2Text
        {
            get
            {
                return this.Controls.DiscoveryTypeTextBox2.Text;
            }
            
            set
            {
                this.Controls.DiscoveryTypeTextBox2.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Help
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        new public virtual string HelpText
        {
            get
            {
                return this.Controls.HelpTextBox.Text;
            }
            
            set
            {
                this.Controls.HelpTextBox.Text = value;
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
        Button IAddNewDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, AddNewDialog.ControlIDs.PreviousButton);
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
        Button IAddNewDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, AddNewDialog.ControlIDs.NextButton);
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
        Button IAddNewDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, AddNewDialog.ControlIDs.CreateButton);
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
        Button IAddNewDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AddNewDialog.ControlIDs.CancelButton);
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
        StaticControl IAddNewDialogControls.MonitoringTypeStaticControl
        {
            get
            {
                if ((this.cachedMonitoringTypeStaticControl == null))
                {
                    this.cachedMonitoringTypeStaticControl = new StaticControl(this, AddNewDialog.ControlIDs.MonitoringTypeStaticControl);
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
        StaticControl IAddNewDialogControls.GeneralPropertiesStaticControl
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
        StaticControl IAddNewDialogControls.DiscoveryMethodStaticControl
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
        StaticControl IAddNewDialogControls.ASPNETApplicationStaticControl
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
        StaticControl IAddNewDialogControls.ExceptionsStaticControl
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
        StaticControl IAddNewDialogControls.PerformanceStaticControl
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
        StaticControl IAddNewDialogControls.SummaryStaticControl
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
        ///  Exposes access to the DiscoveryTypeTextBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAddNewDialogControls.DiscoveryTypeTextBox
        {
            get
            {
                if ((this.cachedDiscoveryTypeTextBox == null))
                {
                    this.cachedDiscoveryTypeTextBox = new TextBox(this, AddNewDialog.ControlIDs.DiscoveryTypeTextBox);
                }
                
                return this.cachedDiscoveryTypeTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddNewDialogControls.NameStaticControl
        {
            get
            {
                if ((this.cachedNameStaticControl == null))
                {
                    this.cachedNameStaticControl = new StaticControl(this, AddNewDialog.ControlIDs.NameStaticControl);
                }
                
                return this.cachedNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WebSitesStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddNewDialogControls.WebSitesStaticControl
        {
            get
            {
                if ((this.cachedWebSitesStaticControl == null))
                {
                    this.cachedWebSitesStaticControl = new StaticControl(this, AddNewDialog.ControlIDs.WebSitesStaticControl);
                }
                
                return this.cachedWebSitesStaticControl;
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
        ListView IAddNewDialogControls.NoteYourChangesWillNotTakeEffectUntilYouRestartIISYouCanDoItOnCompletetionOfTheTemplateProcessOrRest
        {
            get
            {
                if ((this.cachedNoteYourChangesWillNotTakeEffectUntilYouRestartIISYouCanDoItOnCompletetionOfTheTemplateProcessOrRest == null))
                {
                    this.cachedNoteYourChangesWillNotTakeEffectUntilYouRestartIISYouCanDoItOnCompletetionOfTheTemplateProcessOrRest = new ListView(this, AddNewDialog.ControlIDs.NoteYourChangesWillNotTakeEffectUntilYouRestartIISYouCanDoItOnCompletetionOfTheTemplateProcessOrRest);
                }
                
                return this.cachedNoteYourChangesWillNotTakeEffectUntilYouRestartIISYouCanDoItOnCompletetionOfTheTemplateProcessOrRest;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DiscoveryTypeTextBox2 control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAddNewDialogControls.DiscoveryTypeTextBox2
        {
            get
            {
                if ((this.cachedDiscoveryTypeTextBox2 == null))
                {
                    this.cachedDiscoveryTypeTextBox2 = new TextBox(this, AddNewDialog.ControlIDs.DiscoveryTypeTextBox2);
                }
                
                return this.cachedDiscoveryTypeTextBox2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IISApplicationNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddNewDialogControls.IISApplicationNameStaticControl
        {
            get
            {
                if ((this.cachedIISApplicationNameStaticControl == null))
                {
                    this.cachedIISApplicationNameStaticControl = new StaticControl(this, AddNewDialog.ControlIDs.IISApplicationNameStaticControl);
                }
                
                return this.cachedIISApplicationNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpTextBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAddNewDialogControls.HelpTextBox
        {
            get
            {
                if ((this.cachedHelpTextBox == null))
                {
                    this.cachedHelpTextBox = new TextBox(this, AddNewDialog.ControlIDs.HelpTextBox);
                }
                
                return this.cachedHelpTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApplicationVRootStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddNewDialogControls.ApplicationVRootStaticControl
        {
            get
            {
                if ((this.cachedApplicationVRootStaticControl == null))
                {
                    this.cachedApplicationVRootStaticControl = new StaticControl(this, AddNewDialog.ControlIDs.ApplicationVRootStaticControl);
                }
                
                return this.cachedApplicationVRootStaticControl;
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
        StaticControl IAddNewDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, AddNewDialog.ControlIDs.HelpStaticControl);
                }
                
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ASPNETApplicationToBeMonitoredStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddNewDialogControls.ASPNETApplicationToBeMonitoredStaticControl
        {
            get
            {
                if ((this.cachedASPNETApplicationToBeMonitoredStaticControl == null))
                {
                    this.cachedASPNETApplicationToBeMonitoredStaticControl = new StaticControl(this, AddNewDialog.ControlIDs.ASPNETApplicationToBeMonitoredStaticControl);
                }
                
                return this.cachedASPNETApplicationToBeMonitoredStaticControl;
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
            /// Contains resource string for:  Name
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceName = "&Name";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WebSites
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceWebSites = "&Web sites";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  IISApplicationName
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceIISApplicationName = "&IIS Application Name:";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ApplicationVRoot
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceApplicationVRoot = "&Application VRoot:";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.Ent" +
                "erpriseManagement.Internal.UI.Authoring.Common.CommonResources;CommandHelp";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ASPNETApplicationToBeMonitored
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceASPNETApplicationToBeMonitored = "ASP.NET Application to be monitored";
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
            /// Caches the translated resource string for:  Name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedName;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WebSites
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWebSites;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  IISApplicationName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedIISApplicationName;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ApplicationVRoot
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedApplicationVRoot;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ASPNETApplicationToBeMonitored
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedASPNETApplicationToBeMonitored;
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
            /// Exposes access to the Name translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Name
            {
                get
                {
                    if ((cachedName == null))
                    {
                        cachedName = CoreManager.MomConsole.GetIntlStr(ResourceName);
                    }
                    
                    return cachedName;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WebSites translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WebSites
            {
                get
                {
                    if ((cachedWebSites == null))
                    {
                        cachedWebSites = CoreManager.MomConsole.GetIntlStr(ResourceWebSites);
                    }
                    
                    return cachedWebSites;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the IISApplicationName translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string IISApplicationName
            {
                get
                {
                    if ((cachedIISApplicationName == null))
                    {
                        cachedIISApplicationName = CoreManager.MomConsole.GetIntlStr(ResourceIISApplicationName);
                    }
                    
                    return cachedIISApplicationName;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ApplicationVRoot translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ApplicationVRoot
            {
                get
                {
                    if ((cachedApplicationVRoot == null))
                    {
                        cachedApplicationVRoot = CoreManager.MomConsole.GetIntlStr(ResourceApplicationVRoot);
                    }
                    
                    return cachedApplicationVRoot;
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
            /// Exposes access to the ASPNETApplicationToBeMonitored translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ASPNETApplicationToBeMonitored
            {
                get
                {
                    if ((cachedASPNETApplicationToBeMonitored == null))
                    {
                        cachedASPNETApplicationToBeMonitored = CoreManager.MomConsole.GetIntlStr(ResourceASPNETApplicationToBeMonitored);
                    }
                    
                    return cachedASPNETApplicationToBeMonitored;
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
            /// Control ID for DiscoveryTypeTextBox
            /// </summary>
            public const string DiscoveryTypeTextBox = "textBoxName";
            
            /// <summary>
            /// Control ID for NameStaticControl
            /// </summary>
            public const string NameStaticControl = "label4";
            
            /// <summary>
            /// Control ID for WebSitesStaticControl
            /// </summary>
            public const string WebSitesStaticControl = "label3";
            
            /// <summary>
            /// Control ID for NoteYourChangesWillNotTakeEffectUntilYouRestartIISYouCanDoItOnCompletetionOfTheTemplateProcessOrRest
            /// </summary>
            public const string NoteYourChangesWillNotTakeEffectUntilYouRestartIISYouCanDoItOnCompletetionOfTheTemplateProcessOrRest = "listViewWS";
            
            /// <summary>
            /// Control ID for DiscoveryTypeTextBox2
            /// </summary>
            public const string DiscoveryTypeTextBox2 = "textBoxIISName";
            
            /// <summary>
            /// Control ID for IISApplicationNameStaticControl
            /// </summary>
            public const string IISApplicationNameStaticControl = "label2";
            
            /// <summary>
            /// Control ID for HelpTextBox
            /// </summary>
            public const string HelpTextBox = "textBoxVRoot";
            
            /// <summary>
            /// Control ID for ApplicationVRootStaticControl
            /// </summary>
            public const string ApplicationVRootStaticControl = "label1";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for ASPNETApplicationToBeMonitoredStaticControl
            /// </summary>
            public const string ASPNETApplicationToBeMonitoredStaticControl = "headerLabel";
        }
        #endregion
    }
}
