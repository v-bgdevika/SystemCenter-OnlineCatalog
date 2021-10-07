// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AgentFailoverWindow.cs">
// 	Copyright (c) Microsoft Corporation 2007
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[KellyMor] 10/24/2007 Created
// </history>
// -----------------------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards.AutoAgentAssignment
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
    /// 	[KellyMor] 10/24/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum RadioGroup0
    {
        /// <summary>
        /// ManuallyConfigureFailover = 0
        /// </summary>
        ManuallyConfigureFailover = 0,
        
        /// <summary>
        /// AutomaticallyManageFailover = 1
        /// </summary>
        AutomaticallyManageFailover = 1,
    }
    #endregion
    
    #region Interface Definition - IAgentFailoverWindowControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAgentFailoverWindowControls, for AgentFailoverWindow.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 10/24/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAgentFailoverWindowControls
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
        /// Read-only property to access IntroductionStaticControl
        /// </summary>
        StaticControl IntroductionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DomainStaticControl
        /// </summary>
        StaticControl DomainStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access InclusionCriteriaStaticControl
        /// </summary>
        StaticControl InclusionCriteriaStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ExclusionCriteriaStaticControl
        /// </summary>
        StaticControl ExclusionCriteriaStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AgentFailoverStaticControl
        /// </summary>
        StaticControl AgentFailoverStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AgentFailoverRulesListView
        /// </summary>
        ListView AgentFailoverRulesListView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FailoverDescriptionStaticControl
        /// </summary>
        StaticControl FailoverDescriptionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AdditionalServersStaticControl
        /// </summary>
        StaticControl AdditionalServersStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AutomaticFailoverDescripitionStaticControl
        /// </summary>
        StaticControl AutomaticFailoverDescripitionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ManuallyConfigureFailoverRadioButton
        /// </summary>
        RadioButton ManuallyConfigureFailoverRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AutomaticallyManageFailoverRadioButton
        /// </summary>
        RadioButton AutomaticallyManageFailoverRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConfigureAgentFailoverStaticControl
        /// </summary>
        StaticControl ConfigureAgentFailoverStaticControl
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
        /// Read-only property to access AgentFailoverStaticControl2
        /// </summary>
        StaticControl AgentFailoverStaticControl2
        {
            get;
        }
    }

    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add window functionality description here.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 10/24/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class AgentFailoverWindow : Window, IAgentFailoverWindowControls
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
        /// Cache to hold a reference to IntroductionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedIntroductionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DomainStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDomainStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to InclusionCriteriaStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedInclusionCriteriaStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ExclusionCriteriaStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedExclusionCriteriaStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AgentFailoverStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAgentFailoverStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AgentFailoverRulesListView of type ListView
        /// </summary>
        private ListView cachedAgentFailoverRulesListView;
        
        /// <summary>
        /// Cache to hold a reference to FailoverDescriptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedFailoverDescriptionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AdditionalServersStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAdditionalServersStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AutomaticFailoverDescripitionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAutomaticFailoverDescripitionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ManuallyConfigureFailoverRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedManuallyConfigureFailoverRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to AutomaticallyManageFailoverRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedAutomaticallyManageFailoverRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureAgentFailoverStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureAgentFailoverStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AgentFailoverStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedAgentFailoverStaticControl2;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='ownerWindow'>
        /// Owner of AgentFailoverWindow of type App
        /// </param>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AgentFailoverWindow(App ownerWindow) : 
                base(Init(ownerWindow))
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
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual RadioGroup0 RadioGroup0
        {
            get
            {
                if ((this.Controls.ManuallyConfigureFailoverRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroup0.ManuallyConfigureFailover;
                }
                
                if ((this.Controls.AutomaticallyManageFailoverRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroup0.AutomaticallyManageFailover;
                }
                
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == RadioGroup0.ManuallyConfigureFailover))
                {
                    this.Controls.ManuallyConfigureFailoverRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == RadioGroup0.AutomaticallyManageFailover))
                    {
                        this.Controls.AutomaticallyManageFailoverRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region IAgentFailoverWindow Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the window's control properties together</value>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAgentFailoverWindowControls Controls
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
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAgentFailoverWindowControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, AgentFailoverWindow.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAgentFailoverWindowControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, AgentFailoverWindow.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAgentFailoverWindowControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, AgentFailoverWindow.ControlIDs.CreateButton);
                }
                
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAgentFailoverWindowControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AgentFailoverWindow.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IntroductionStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAgentFailoverWindowControls.IntroductionStaticControl
        {
            get
            {
                if ((this.cachedIntroductionStaticControl == null))
                {
                    this.cachedIntroductionStaticControl = new StaticControl(this, AgentFailoverWindow.ControlIDs.IntroductionStaticControl);
                }
                
                return this.cachedIntroductionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DomainStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAgentFailoverWindowControls.DomainStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedDomainStaticControl == null))
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
                    this.cachedDomainStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedDomainStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the InclusionCriteriaStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAgentFailoverWindowControls.InclusionCriteriaStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedInclusionCriteriaStaticControl == null))
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
                    this.cachedInclusionCriteriaStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedInclusionCriteriaStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExclusionCriteriaStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAgentFailoverWindowControls.ExclusionCriteriaStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedExclusionCriteriaStaticControl == null))
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
                    this.cachedExclusionCriteriaStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedExclusionCriteriaStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AgentFailoverStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAgentFailoverWindowControls.AgentFailoverStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedAgentFailoverStaticControl == null))
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
                    this.cachedAgentFailoverStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedAgentFailoverStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AgentFailoverRulesListView control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IAgentFailoverWindowControls.AgentFailoverRulesListView
        {
            get
            {
                if ((this.cachedAgentFailoverRulesListView == null))
                {
                    this.cachedAgentFailoverRulesListView = new ListView(this, AgentFailoverWindow.ControlIDs.AgentFailoverRulesListView);
                }
                
                return this.cachedAgentFailoverRulesListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FailoverDescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAgentFailoverWindowControls.FailoverDescriptionStaticControl
        {
            get
            {
                if ((this.cachedFailoverDescriptionStaticControl == null))
                {
                    this.cachedFailoverDescriptionStaticControl = new StaticControl(this, AgentFailoverWindow.ControlIDs.FailoverDescriptionStaticControl);
                }
                
                return this.cachedFailoverDescriptionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AdditionalServersStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAgentFailoverWindowControls.AdditionalServersStaticControl
        {
            get
            {
                if ((this.cachedAdditionalServersStaticControl == null))
                {
                    this.cachedAdditionalServersStaticControl = new StaticControl(this, AgentFailoverWindow.ControlIDs.AdditionalServersStaticControl);
                }
                
                return this.cachedAdditionalServersStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AutomaticFailoverDescripitionStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAgentFailoverWindowControls.AutomaticFailoverDescripitionStaticControl
        {
            get
            {
                if ((this.cachedAutomaticFailoverDescripitionStaticControl == null))
                {
                    this.cachedAutomaticFailoverDescripitionStaticControl = new StaticControl(this, AgentFailoverWindow.ControlIDs.AutomaticFailoverDescripitionStaticControl);
                }
                
                return this.cachedAutomaticFailoverDescripitionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManuallyConfigureFailoverRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IAgentFailoverWindowControls.ManuallyConfigureFailoverRadioButton
        {
            get
            {
                if ((this.cachedManuallyConfigureFailoverRadioButton == null))
                {
                    this.cachedManuallyConfigureFailoverRadioButton = new RadioButton(this, AgentFailoverWindow.ControlIDs.ManuallyConfigureFailoverRadioButton);
                }
                
                return this.cachedManuallyConfigureFailoverRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AutomaticallyManageFailoverRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IAgentFailoverWindowControls.AutomaticallyManageFailoverRadioButton
        {
            get
            {
                if ((this.cachedAutomaticallyManageFailoverRadioButton == null))
                {
                    this.cachedAutomaticallyManageFailoverRadioButton = new RadioButton(this, AgentFailoverWindow.ControlIDs.AutomaticallyManageFailoverRadioButton);
                }
                
                return this.cachedAutomaticallyManageFailoverRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureAgentFailoverStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAgentFailoverWindowControls.ConfigureAgentFailoverStaticControl
        {
            get
            {
                if ((this.cachedConfigureAgentFailoverStaticControl == null))
                {
                    this.cachedConfigureAgentFailoverStaticControl = new StaticControl(this, AgentFailoverWindow.ControlIDs.ConfigureAgentFailoverStaticControl);
                }
                
                return this.cachedConfigureAgentFailoverStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAgentFailoverWindowControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, AgentFailoverWindow.ControlIDs.HelpStaticControl);
                }
                
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AgentFailoverStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAgentFailoverWindowControls.AgentFailoverStaticControl2
        {
            get
            {
                if ((this.cachedAgentFailoverStaticControl2 == null))
                {
                    this.cachedAgentFailoverStaticControl2 = new StaticControl(this, AgentFailoverWindow.ControlIDs.AgentFailoverStaticControl2);
                }
                
                return this.cachedAgentFailoverStaticControl2;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
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
        /// 	[KellyMor] 10/24/2007 Created
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
        /// 	[KellyMor] 10/24/2007 Created
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
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find the window.
        /// </summary>
        /// <returns>A System.IntPtr representing a handle to the window.</returns>
        /// <param name="ownerWindow">App class instance that owns this window.</param>)
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static System.IntPtr Init(App ownerWindow)
        {
            // First check if the window is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a window
                tempWindow = 
                    new Window(
                        Strings.WindowTitle, 
                        StringMatchSyntax.WildCard, 
                        WindowClassNames.WinForms10Window8, 
                        StringMatchSyntax.ExactMatch, 
                        ownerWindow, 
                        Timeout);
            }
            catch (Exceptions.WindowNotFoundException windowNotFound)
            {
                // Reset the window reference
                tempWindow = null;

                // Maximum number of tries to find window
                int maxTries = 5;

                // Try several more times to find the window
                for (int numberOfTries = 0; 
                    ((null == tempWindow) && (numberOfTries < maxTries)); 
                    numberOfTries = (numberOfTries + 1))
                {
                    try
                    {
                        // Try to locate an existing instance of the window
                        tempWindow = new Window(Strings.WindowTitle, StringMatchSyntax.WildCard);

                        // Wait for the window to become ready
                        UISynchronization.WaitForUIObjectReady(tempWindow, Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException )
                    {
                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage(
                            "Attempt " +
                            numberOfTries +
                            " of " +
                            maxTries);

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }
                
                // check for success
                if ((null == tempWindow))
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find window with title := '" +
                        Strings.WindowTitle +
                        "'");

                    // rethrow the original exception
                    throw windowNotFound;
                }
            }
            
            return tempWindow.Extended.HWnd;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Resource string definitions.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
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
            private const string ResourceWindowTitle = 
                ";Agent Assignment and Failover Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;ADIntegrationWizardCaption";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrevious =
                ";< &Previous" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll" +
                ";Microsoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel" +
                ";previousButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext =
                ";&Next >" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll" +
                ";Microsoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel" +
                ";nextButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Create
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCreate =
                ";&Create;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;CreateText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel =
                ";Cancel" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.PageFrameworks.WizardFramework" +
                ";buttonCancel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp =
                ";Help" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.PageFrameworks.SheetFramework" +
                ";buttonHelp.Text";
                        
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Introduction
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceIntroduction =
                ";Introduction" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";WelcomeTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Domain
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDomain =
                ";Domain" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";ViewColumnDomain";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  InclusionCriteria
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceInclusionCriteria =
                ";Inclusion Criteria;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;InclusionRuleTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ExclusionCriteria
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceExclusionCriteria =
                ";Exclusion Criteria;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;ExclusionRuleTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AgentFailover
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAgentFailover =
                ";Agent Failover;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;AgentFailoverTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  FailoverDescriptionStaticControl
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFailoverDescriptionStaticControl = @";Deselect servers that you don’t want agents to failover to (if for example, one of servers is a critical management server that can’t handle any additional load).;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.ADIntegration.AgentFailover;labelManualDescription.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AdditionalServersStaticControl
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdditionalServersStaticControl = @";Note: If additional management server(s) are added you will need to run this wizard if you want agent to failover to it.;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.ADIntegration.AgentFailover;labelNote.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AutomaticFailoverDescripitionStaticControl
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAutomaticFailoverDescripitionStaticControl = @";The agents will automatically report to the other management servers in the same management group if their primary management server becomes unavailable.;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.ADIntegration.AgentFailover;labelAutoDescription.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ManuallyConfigureFailover
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceManuallyConfigureFailover =
                ";&Manually configure failover" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.ADIntegration.AgentFailover" +
                ";radioButtonManual.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AutomaticallyManageFailover
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAutomaticallyManageFailover =
                ";&Automatically manage failover" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.ADIntegration.AgentFailover" +
                ";radioButtonAuto.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureAgentFailover
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureAgentFailover =
                ";Configure agent Failover" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.ADIntegration.AgentFailover" +
                ";labelTitle.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AgentFailover2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAgentFailover2 =
               ";Agent Failover;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;AgentFailoverTitle";

            #endregion
            
            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWindowTitle;
            
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
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Introduction
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedIntroduction;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Domain
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDomain;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  InclusionCriteria
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedInclusionCriteria;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ExclusionCriteria
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedExclusionCriteria;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AgentFailover
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAgentFailover;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  FailoverDescriptionStaticControl
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFailoverDescriptionStaticControl;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AdditionalServersStaticControl
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdditionalServersStaticControl;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AutomaticFailoverDescripitionStaticControl
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAutomaticFailoverDescripitionStaticControl;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ManuallyConfigureFailover
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedManuallyConfigureFailover;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AutomaticallyManageFailover
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAutomaticallyManageFailover;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureAgentFailover
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigureAgentFailover;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AgentFailover2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAgentFailover2;

            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WindowTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WindowTitle
            {
                get
                {
                    if ((cachedWindowTitle == null))
                    {
                        cachedWindowTitle = CoreManager.MomConsole.GetIntlStr(ResourceWindowTitle);
                    }
                    
                    return cachedWindowTitle;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Previous translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
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
            /// 	[KellyMor] 10/24/2007 Created
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
            /// 	[KellyMor] 10/24/2007 Created
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
            /// 	[KellyMor] 10/24/2007 Created
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
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
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
            /// Exposes access to the Introduction translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Introduction
            {
                get
                {
                    if ((cachedIntroduction == null))
                    {
                        cachedIntroduction = CoreManager.MomConsole.GetIntlStr(ResourceIntroduction);
                    }
                    
                    return cachedIntroduction;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Domain translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Domain
            {
                get
                {
                    if ((cachedDomain == null))
                    {
                        cachedDomain = CoreManager.MomConsole.GetIntlStr(ResourceDomain);
                    }
                    
                    return cachedDomain;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the InclusionCriteria translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string InclusionCriteria
            {
                get
                {
                    if ((cachedInclusionCriteria == null))
                    {
                        cachedInclusionCriteria = CoreManager.MomConsole.GetIntlStr(ResourceInclusionCriteria);
                    }
                    
                    return cachedInclusionCriteria;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ExclusionCriteria translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ExclusionCriteria
            {
                get
                {
                    if ((cachedExclusionCriteria == null))
                    {
                        cachedExclusionCriteria = CoreManager.MomConsole.GetIntlStr(ResourceExclusionCriteria);
                    }
                    
                    return cachedExclusionCriteria;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AgentFailover translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AgentFailover
            {
                get
                {
                    if ((cachedAgentFailover == null))
                    {
                        cachedAgentFailover = CoreManager.MomConsole.GetIntlStr(ResourceAgentFailover);
                    }
                    
                    return cachedAgentFailover;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the FailoverDescriptionStaticControl translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FailoverDescriptionStaticControl
            {
                get
                {
                    if ((cachedFailoverDescriptionStaticControl == null))
                    {
                        cachedFailoverDescriptionStaticControl = CoreManager.MomConsole.GetIntlStr(ResourceFailoverDescriptionStaticControl);
                    }
                    
                    return cachedFailoverDescriptionStaticControl;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdditionalServersStaticControl translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdditionalServersStaticControl
            {
                get
                {
                    if ((cachedAdditionalServersStaticControl == null))
                    {
                        cachedAdditionalServersStaticControl = CoreManager.MomConsole.GetIntlStr(ResourceAdditionalServersStaticControl);
                    }
                    
                    return cachedAdditionalServersStaticControl;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AutomaticFailoverDescripitionStaticControl translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AutomaticFailoverDescripitionStaticControl
            {
                get
                {
                    if ((cachedAutomaticFailoverDescripitionStaticControl == null))
                    {
                        cachedAutomaticFailoverDescripitionStaticControl = CoreManager.MomConsole.GetIntlStr(ResourceAutomaticFailoverDescripitionStaticControl);
                    }
                    
                    return cachedAutomaticFailoverDescripitionStaticControl;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ManuallyConfigureFailover translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ManuallyConfigureFailover
            {
                get
                {
                    if ((cachedManuallyConfigureFailover == null))
                    {
                        cachedManuallyConfigureFailover = CoreManager.MomConsole.GetIntlStr(ResourceManuallyConfigureFailover);
                    }
                    
                    return cachedManuallyConfigureFailover;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AutomaticallyManageFailover translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AutomaticallyManageFailover
            {
                get
                {
                    if ((cachedAutomaticallyManageFailover == null))
                    {
                        cachedAutomaticallyManageFailover = CoreManager.MomConsole.GetIntlStr(ResourceAutomaticallyManageFailover);
                    }
                    
                    return cachedAutomaticallyManageFailover;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfigureAgentFailover translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfigureAgentFailover
            {
                get
                {
                    if ((cachedConfigureAgentFailover == null))
                    {
                        cachedConfigureAgentFailover = CoreManager.MomConsole.GetIntlStr(ResourceConfigureAgentFailover);
                    }
                    
                    return cachedConfigureAgentFailover;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AgentFailover2 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AgentFailover2
            {
                get
                {
                    if ((cachedAgentFailover2 == null))
                    {
                        cachedAgentFailover2 = CoreManager.MomConsole.GetIntlStr(ResourceAgentFailover2);
                    }
                    
                    return cachedAgentFailover2;
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
        /// 	[KellyMor] 10/24/2007 Created
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
            /// Control ID for IntroductionStaticControl
            /// </summary>
            public const string IntroductionStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for DomainStaticControl
            /// </summary>
            public const string DomainStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for InclusionCriteriaStaticControl
            /// </summary>
            public const string InclusionCriteriaStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ExclusionCriteriaStaticControl
            /// </summary>
            public const string ExclusionCriteriaStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for AgentFailoverStaticControl
            /// </summary>
            public const string AgentFailoverStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for AgentFailoverRulesListView
            /// </summary>
            public const string AgentFailoverRulesListView = "listViewServers";
            
            /// <summary>
            /// Control ID for FailoverDescriptionStaticControl
            /// </summary>
            public const string FailoverDescriptionStaticControl = "labelManualDescription";
            
            /// <summary>
            /// Control ID for AdditionalServersStaticControl
            /// </summary>
            public const string AdditionalServersStaticControl = "labelNote";
            
            /// <summary>
            /// Control ID for AutomaticFailoverDescripitionStaticControl
            /// </summary>
            public const string AutomaticFailoverDescripitionStaticControl = "labelAutoDescription";
            
            /// <summary>
            /// Control ID for ManuallyConfigureFailoverRadioButton
            /// </summary>
            public const string ManuallyConfigureFailoverRadioButton = "radioButtonManual";
            
            /// <summary>
            /// Control ID for AutomaticallyManageFailoverRadioButton
            /// </summary>
            public const string AutomaticallyManageFailoverRadioButton = "radioButtonAuto";
            
            /// <summary>
            /// Control ID for ConfigureAgentFailoverStaticControl
            /// </summary>
            public const string ConfigureAgentFailoverStaticControl = "labelTitle";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for AgentFailoverStaticControl2
            /// </summary>
            public const string AgentFailoverStaticControl2 = "headerLabel";
        }
        #endregion
    }
}
