// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SelectDomainWindow.cs">
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
//  [KellyMor] 30-Oct-2007 Modified control interface for shorter names
// </history>
// -----------------------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards.AutoAgentAssignment
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - ISelectDomainWindowControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISelectDomainWindowControls, for SelectDomainWindow.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 10/24/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISelectDomainWindowControls
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
        /// Read-only property to access UseADifferentAccountCheckBox
        /// </summary>
        CheckBox UseADifferentAccountCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectRunAsProfileStaticControl
        /// </summary>
        StaticControl SelectRunAsProfileStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NewButton
        /// </summary>
        Button NewButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RunAsProfilesComboBox
        /// </summary>
        ComboBox RunAsProfilesComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DomainsComboBox
        /// </summary>
        EditComboBox DomainsComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AgentFailoverTextBox
        /// </summary>
        TextBox DomainsTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectADomainFromTheListOrTypeTheNameOfDomainOrFQDNOfADomainControlStaticControl
        /// </summary>
        StaticControl SelectADomainFromTheListOrTypeTheNameOfDomainOrFQDNOfADomainControlStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EgDC01CONTOSOCOMStaticControl
        /// </summary>
        StaticControl EgDC01CONTOSOCOMStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SpecifyTheDomainThatTheAgentComputersAreInStaticControl
        /// </summary>
        StaticControl SpecifyTheDomainThatTheAgentComputersAreInStaticControl
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
        /// Read-only property to access DomainStaticControl2
        /// </summary>
        StaticControl DomainStaticControl2
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
    public class SelectDomainWindow : Window, ISelectDomainWindowControls
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
        /// Cache to hold a reference to UseADifferentAccountCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedUseADifferentAccountCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to SelectRunAsProfileStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectRunAsProfileStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to NewButton of type Button
        /// </summary>
        private Button cachedNewButton;
        
        /// <summary>
        /// Cache to hold a reference to RunAsProfilesComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedRunAsProfilesComboBox;
        
        /// <summary>
        /// Cache to hold a reference to DomainsComboBox of type EditComboBox
        /// </summary>
        private EditComboBox cachedDomainsComboBox;
        
        /// <summary>
        /// Cache to hold a reference to AgentFailoverTextBox of type TextBox
        /// </summary>
        private TextBox cachedDomainsTextBox;
        
        /// <summary>
        /// Cache to hold a reference to SelectADomainFromTheListOrTypeTheNameOfDomainOrFQDNOfADomainControlStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectADomainFromTheListOrTypeTheNameOfDomainOrFQDNOfADomainControlStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to EgDC01CONTOSOCOMStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEgDC01CONTOSOCOMStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyTheDomainThatTheAgentComputersAreInStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyTheDomainThatTheAgentComputersAreInStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DomainStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedDomainStaticControl2;

        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='ownerWindow'>
        /// Owner of SelectDomainWindow of type App
        /// </param>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SelectDomainWindow(App ownerWindow) : 
                base(Init(ownerWindow))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region ISelectDomainWindow Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the window's control properties together</value>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISelectDomainWindowControls Controls
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
        ///  Property to handle checkbox UseADifferentAccount
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool UseADifferentAccount
        {
            get
            {
                return this.Controls.UseADifferentAccountCheckBox.Checked;
            }
            
            set
            {
                this.Controls.UseADifferentAccountCheckBox.Checked = value;
            }
        }

        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control RunAsProfiles
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string RunAsProfilesText
        {
            get
            {
                return this.Controls.RunAsProfilesComboBox.Text;
            }
            
            set
            {
                this.Controls.RunAsProfilesComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Domains
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DomainsText
        {
            get
            {
                return this.Controls.DomainsComboBox.Text;
            }
            
            set
            {
                this.Controls.DomainsComboBox.Text = value;
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
        Button ISelectDomainWindowControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, SelectDomainWindow.ControlIDs.PreviousButton);
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
        Button ISelectDomainWindowControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, SelectDomainWindow.ControlIDs.NextButton);
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
        Button ISelectDomainWindowControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, SelectDomainWindow.ControlIDs.CreateButton);
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
        Button ISelectDomainWindowControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, SelectDomainWindow.ControlIDs.CancelButton);
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
        StaticControl ISelectDomainWindowControls.IntroductionStaticControl
        {
            get
            {
                if ((this.cachedIntroductionStaticControl == null))
                {
                    this.cachedIntroductionStaticControl = new StaticControl(this, SelectDomainWindow.ControlIDs.IntroductionStaticControl);
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
        StaticControl ISelectDomainWindowControls.DomainStaticControl
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
        StaticControl ISelectDomainWindowControls.InclusionCriteriaStaticControl
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
        StaticControl ISelectDomainWindowControls.ExclusionCriteriaStaticControl
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
        StaticControl ISelectDomainWindowControls.AgentFailoverStaticControl
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
        ///  Exposes access to the UseADifferentAccountCheckBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox ISelectDomainWindowControls.UseADifferentAccountCheckBox
        {
            get
            {
                if ((this.cachedUseADifferentAccountCheckBox == null))
                {
                    this.cachedUseADifferentAccountCheckBox = new CheckBox(this, SelectDomainWindow.ControlIDs.UseADifferentAccountCheckBox);
                }
                
                return this.cachedUseADifferentAccountCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectRunAsProfileStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectDomainWindowControls.SelectRunAsProfileStaticControl
        {
            get
            {
                if ((this.cachedSelectRunAsProfileStaticControl == null))
                {
                    this.cachedSelectRunAsProfileStaticControl = new StaticControl(this, SelectDomainWindow.ControlIDs.SelectRunAsProfileStaticControl);
                }
                
                return this.cachedSelectRunAsProfileStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NewButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectDomainWindowControls.NewButton
        {
            get
            {
                if ((this.cachedNewButton == null))
                {
                    this.cachedNewButton = new Button(this, SelectDomainWindow.ControlIDs.NewButton);
                }
                
                return this.cachedNewButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RunAsProfilesComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ISelectDomainWindowControls.RunAsProfilesComboBox
        {
            get
            {
                if ((this.cachedRunAsProfilesComboBox == null))
                {
                    this.cachedRunAsProfilesComboBox = new ComboBox(this, SelectDomainWindow.ControlIDs.RunAsProfilesComboBox);
                }
                
                return this.cachedRunAsProfilesComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DomainsComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox ISelectDomainWindowControls.DomainsComboBox
        {
            get
            {
                if ((this.cachedDomainsComboBox == null))
                {
                    this.cachedDomainsComboBox = new EditComboBox(this, SelectDomainWindow.ControlIDs.DomainsComboBox);
                }
                
                return this.cachedDomainsComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DomainsTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ISelectDomainWindowControls.DomainsTextBox
        {
            get
            {
                if ((this.cachedDomainsTextBox == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 2); i = (i + 1))
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
                    this.cachedDomainsTextBox = new TextBox(wndTemp);
                }
                
                return this.cachedDomainsTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectADomainFromTheListOrTypeTheNameOfDomainOrFQDNOfADomainControlStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectDomainWindowControls.SelectADomainFromTheListOrTypeTheNameOfDomainOrFQDNOfADomainControlStaticControl
        {
            get
            {
                if ((this.cachedSelectADomainFromTheListOrTypeTheNameOfDomainOrFQDNOfADomainControlStaticControl == null))
                {
                    this.cachedSelectADomainFromTheListOrTypeTheNameOfDomainOrFQDNOfADomainControlStaticControl = new StaticControl(this, SelectDomainWindow.ControlIDs.SelectADomainFromTheListOrTypeTheNameOfDomainOrFQDNOfADomainControlStaticControl);
                }
                
                return this.cachedSelectADomainFromTheListOrTypeTheNameOfDomainOrFQDNOfADomainControlStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EgDC01CONTOSOCOMStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectDomainWindowControls.EgDC01CONTOSOCOMStaticControl
        {
            get
            {
                if ((this.cachedEgDC01CONTOSOCOMStaticControl == null))
                {
                    this.cachedEgDC01CONTOSOCOMStaticControl = new StaticControl(this, SelectDomainWindow.ControlIDs.EgDC01CONTOSOCOMStaticControl);
                }
                
                return this.cachedEgDC01CONTOSOCOMStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyTheDomainThatTheAgentComputersAreInStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectDomainWindowControls.SpecifyTheDomainThatTheAgentComputersAreInStaticControl
        {
            get
            {
                if ((this.cachedSpecifyTheDomainThatTheAgentComputersAreInStaticControl == null))
                {
                    this.cachedSpecifyTheDomainThatTheAgentComputersAreInStaticControl = new StaticControl(this, SelectDomainWindow.ControlIDs.SpecifyTheDomainThatTheAgentComputersAreInStaticControl);
                }
                
                return this.cachedSpecifyTheDomainThatTheAgentComputersAreInStaticControl;
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
        StaticControl ISelectDomainWindowControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, SelectDomainWindow.ControlIDs.HelpStaticControl);
                }
                
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DomainStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectDomainWindowControls.DomainStaticControl2
        {
            get
            {
                if ((this.cachedDomainStaticControl2 == null))
                {
                    this.cachedDomainStaticControl2 = new StaticControl(this, SelectDomainWindow.ControlIDs.DomainStaticControl2);
                }
                
                return this.cachedDomainStaticControl2;
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
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button UseADifferentAccount
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickUseADifferentAccount()
        {
            this.Controls.UseADifferentAccountCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button New
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNew()
        {
            this.Controls.NewButton.Click();
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
                    catch (Exceptions.WindowNotFoundException)
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
            /// Contains resource string for:  UseADifferentAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUseADifferentAccount = ";Use a different account to perform agent assignment in the specified domain;Mana" +
                "gedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Intern" +
                "al.UI.Console.Administration.ADIntegration.TrustMode;checkBoxProfile.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectRunAsProfile
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectRunAsProfile = ";&Select Run As Profile:;ManagedString;Microsoft.EnterpriseManagement.UI.Administ" +
                "ration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAsPr" +
                "ofile.RunAsProfileComboBoxControl;labelProfile.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  New
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNew = ";N&ew...;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAsProfile.RunAsProfi" +
                "leComboBoxControl;buttonProfile.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectADomainFromTheListOrTypeTheNameOfDomainOrFQDNOfADomainControl
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectADomainFromTheListOrTypeTheNameOfDomainOrFQDNOfADomainControl = ";Select a domain from the list or type the name of domain or FQDN of a domain con" +
                "trol;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.M" +
                "om.Internal.UI.Console.Administration.ADIntegration.TrustMode;labelTrusted.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EgDC01CONTOSOCOM
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEgDC01CONTOSOCOM = ";E.g. DC01.CONTOSO.COM;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.Enter" +
                "priseManagement.Mom.Internal.UI.Console.Administration.ADIntegration.TrustMode;l" +
                "abelExample.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpecifyTheDomainThatTheAgentComputersAreIn
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecifyTheDomainThatTheAgentComputersAreIn = ";Specify the domain that the agent computers are in;ManagedString;Microsoft.MOM.U" +
                "I.Console.exe;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administrat" +
                "ion.ADIntegration.TrustMode;labelTitle.Text";
 
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Domain2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDomain2 = ";Domain;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micros" +
                "oft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;ViewColum" +
                "nDomain";
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
            /// Caches the translated resource string for:  UseADifferentAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUseADifferentAccount;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectRunAsProfile
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectRunAsProfile;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  New
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNew;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectADomainFromTheListOrTypeTheNameOfDomainOrFQDNOfADomainControl
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectADomainFromTheListOrTypeTheNameOfDomainOrFQDNOfADomainControl;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EgDC01CONTOSOCOM
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEgDC01CONTOSOCOM;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpecifyTheDomainThatTheAgentComputersAreIn
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpecifyTheDomainThatTheAgentComputersAreIn;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Domain2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDomain2;
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
            /// Exposes access to the UseADifferentAccount translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UseADifferentAccount
            {
                get
                {
                    if ((cachedUseADifferentAccount == null))
                    {
                        cachedUseADifferentAccount = CoreManager.MomConsole.GetIntlStr(ResourceUseADifferentAccount);
                    }
                    
                    return cachedUseADifferentAccount;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectRunAsProfile translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectRunAsProfile
            {
                get
                {
                    if ((cachedSelectRunAsProfile == null))
                    {
                        cachedSelectRunAsProfile = CoreManager.MomConsole.GetIntlStr(ResourceSelectRunAsProfile);
                    }
                    
                    return cachedSelectRunAsProfile;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the New translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string New
            {
                get
                {
                    if ((cachedNew == null))
                    {
                        cachedNew = CoreManager.MomConsole.GetIntlStr(ResourceNew);
                    }
                    
                    return cachedNew;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectADomainFromTheListOrTypeTheNameOfDomainOrFQDNOfADomainControl translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectADomainFromTheListOrTypeTheNameOfDomainOrFQDNOfADomainControl
            {
                get
                {
                    if ((cachedSelectADomainFromTheListOrTypeTheNameOfDomainOrFQDNOfADomainControl == null))
                    {
                        cachedSelectADomainFromTheListOrTypeTheNameOfDomainOrFQDNOfADomainControl = CoreManager.MomConsole.GetIntlStr(ResourceSelectADomainFromTheListOrTypeTheNameOfDomainOrFQDNOfADomainControl);
                    }
                    
                    return cachedSelectADomainFromTheListOrTypeTheNameOfDomainOrFQDNOfADomainControl;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EgDC01CONTOSOCOM translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EgDC01CONTOSOCOM
            {
                get
                {
                    if ((cachedEgDC01CONTOSOCOM == null))
                    {
                        cachedEgDC01CONTOSOCOM = CoreManager.MomConsole.GetIntlStr(ResourceEgDC01CONTOSOCOM);
                    }
                    
                    return cachedEgDC01CONTOSOCOM;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SpecifyTheDomainThatTheAgentComputersAreIn translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpecifyTheDomainThatTheAgentComputersAreIn
            {
                get
                {
                    if ((cachedSpecifyTheDomainThatTheAgentComputersAreIn == null))
                    {
                        cachedSpecifyTheDomainThatTheAgentComputersAreIn = CoreManager.MomConsole.GetIntlStr(ResourceSpecifyTheDomainThatTheAgentComputersAreIn);
                    }
                    
                    return cachedSpecifyTheDomainThatTheAgentComputersAreIn;
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
            /// Exposes access to the Domain2 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Domain2
            {
                get
                {
                    if ((cachedDomain2 == null))
                    {
                        cachedDomain2 = CoreManager.MomConsole.GetIntlStr(ResourceDomain2);
                    }
                    
                    return cachedDomain2;
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
            /// Control ID for UseADifferentAccountCheckBox
            /// </summary>
            public const string UseADifferentAccountCheckBox = "checkBoxProfile";
            
            /// <summary>
            /// Control ID for SelectRunAsProfileStaticControl
            /// </summary>
            public const string SelectRunAsProfileStaticControl = "labelProfile";
            
            /// <summary>
            /// Control ID for NewButton
            /// </summary>
            public const string NewButton = "buttonProfile";
            
            /// <summary>
            /// Control ID for RunAsProfilesComboBox
            /// </summary>
            public const string RunAsProfilesComboBox = "comboBoxProfiles";
            
            /// <summary>
            /// Control ID for DomainsComboBox
            /// </summary>
            public const string DomainsComboBox = "comboBoxDomains";
            
            /// <summary>
            /// Control ID for SelectADomainFromTheListOrTypeTheNameOfDomainOrFQDNOfADomainControlStaticControl
            /// </summary>
            public const string SelectADomainFromTheListOrTypeTheNameOfDomainOrFQDNOfADomainControlStaticControl = "labelTrusted";
            
            /// <summary>
            /// Control ID for EgDC01CONTOSOCOMStaticControl
            /// </summary>
            public const string EgDC01CONTOSOCOMStaticControl = "labelExample";
            
            /// <summary>
            /// Control ID for SpecifyTheDomainThatTheAgentComputersAreInStaticControl
            /// </summary>
            public const string SpecifyTheDomainThatTheAgentComputersAreInStaticControl = "labelTitle";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for DomainStaticControl2
            /// </summary>
            public const string DomainStaticControl2 = "headerLabel";
        }
        #endregion
    }
}
