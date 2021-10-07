// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="QueryCriteriaWindow.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[KellyMor] 03-Feb-06    Created
//  [KellyMor] 27-Feb-06    Updated resource strings
//  [KellyMor] 07-Jun-06    Updated resource assembly for new Admin assembly
//  [jnwoko]   10 -oct - 08  Updated due to Improvement 112171
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Radio Group Enumeration - QueryMethod

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group QueryMethod
    /// </summary>
    /// <history>
    /// 	[KellyMor] 2/3/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum QueryMethod
    {
        /// <summary>
        /// BrowseForOrTypeInComputerNames = 0
        /// </summary>
        BrowseForOrTypeInComputerNames = 0,
        
        /// <summary>
        /// ScanActiveDirectory = 1
        /// </summary>
        ScanActiveDirectory = 1,
    }
    #endregion
    
    #region Interface Definition - IQueryCriteriaWindowControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IQueryCriteriaWindowControls, for QueryCriteriaWindow.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 2/3/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IQueryCriteriaWindowControls
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
        /// Read-only property to access FinishButton
        /// </summary>
        Button FinishButton
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
        /// Read-only property to access AutoOrAdvancedStaticControl
        /// </summary>
        StaticControl AutoOrAdvancedStaticControl
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
        /// Read-only property to access AdministratorAccountStaticControl
        /// </summary>
        StaticControl AdministratorAccountStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RunningDiscoveryStaticControl
        /// </summary>
        StaticControl RunningDiscoveryStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectObjectsToManageStaticControl
        /// </summary>
        StaticControl SelectObjectsToManageStaticControl
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
        /// Read-only property to access DomainEditComboBox
        /// </summary>
        EditComboBox DomainEditComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DomainTextBox
        /// </summary>
        TextBox DomainTextBox
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
        /// Read-only property to access ComputerNamesTextBox
        /// </summary>
        TextBox ComputerNamesTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access BrowseButton
        /// </summary>
        Button BrowseButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectObjectsFromActiveDirectoryStaticControl
        /// </summary>
        StaticControl SelectObjectsFromActiveDirectoryStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access BrowseActiveDirectoryStaticControl
        /// </summary>
        StaticControl BrowseActiveDirectoryStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LdapQueryTextBox
        /// </summary>
        TextBox LdapQueryTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConfigureButton
        /// </summary>
        Button ConfigureButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HowDoYouWantToDiscoverComputersStaticControl
        /// </summary>
        StaticControl HowDoYouWantToDiscoverComputersStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access BrowseForOrTypeInComputerNamesRadioButton
        /// </summary>
        RadioButton BrowseForOrTypeInComputerNamesRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ScanActiveDirectoryRadioButton
        /// </summary>
        RadioButton ScanActiveDirectoryRadioButton
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
        /// Read-only property to access DiscoveryMethodStaticControl2
        /// </summary>
        StaticControl DiscoveryMethodStaticControl2
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ManagementServerComboBox
        /// </summary>
        ComboBox ManagementServerComboBox
        {
            get;
        }

    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the functionality of the Windows Computers Query 
    /// Criteria step in the Computer and Device Management wizard.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 2/3/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class QueryCriteriaWindow : Window, IQueryCriteriaWindowControls
    {
        #region Protected Internal Variables

        /// <summary>
        /// Cache to hold a reference to the active window of type Maui.Core.Window
        /// </summary>
        protected internal static Window activeWindow;
        #endregion
        
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
        /// Cache to hold a reference to FinishButton of type Button
        /// </summary>
        private Button cachedFinishButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to IntroductionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedIntroductionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AutoOrAdvancedStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAutoOrAdvancedStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DiscoveryMethodStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDiscoveryMethodStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AdministratorAccountStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAdministratorAccountStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to RunningDiscoveryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRunningDiscoveryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectObjectsToManageStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectObjectsToManageStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SummaryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSummaryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DomainEditComboBox of type EditComboBox
        /// </summary>
        private EditComboBox cachedDomainEditComboBox;
        
        /// <summary>
        /// Cache to hold a reference to DomainTextBox of type TextBox
        /// </summary>
        private TextBox cachedDomainTextBox;
        
        /// <summary>
        /// Cache to hold a reference to DomainStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDomainStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ComputerNamesTextBox of type TextBox
        /// </summary>
        private TextBox cachedComputerNamesTextBox;
        
        /// <summary>
        /// Cache to hold a reference to BrowseButton of type Button
        /// </summary>
        private Button cachedBrowseButton;
        
        /// <summary>
        /// Cache to hold a reference to SelectObjectsFromActiveDirectoryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectObjectsFromActiveDirectoryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to BrowseActiveDirectoryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedBrowseActiveDirectoryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to LdapQueryTextBox of type TextBox
        /// </summary>
        private TextBox cachedLdapQueryTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureButton of type Button
        /// </summary>
        private Button cachedConfigureButton;
        
        /// <summary>
        /// Cache to hold a reference to HowDoYouWantToDiscoverComputersStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHowDoYouWantToDiscoverComputersStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to BrowseForOrTypeInComputerNamesRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedBrowseForOrTypeInComputerNamesRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to ScanActiveDirectoryRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedScanActiveDirectoryRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DiscoveryMethodStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedDiscoveryMethodStaticControl2;

        /// <summary>
        /// Cache to hold a reference to ManagementServerComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedManagementServerComboBox;

        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='ownerWindow'>
        /// Owner of QueryCriteriaWindow of type App
        /// </param>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public QueryCriteriaWindow(App ownerWindow) : 
                base(Init(ownerWindow))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group QueryMethod
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual QueryMethod QueryMethod
        {
            get
            {
                if ((this.Controls.BrowseForOrTypeInComputerNamesRadioButton.ButtonState == ButtonState.Checked))
                {
                    return QueryMethod.BrowseForOrTypeInComputerNames;
                }
                
                if ((this.Controls.ScanActiveDirectoryRadioButton.ButtonState == ButtonState.Checked))
                {
                    return QueryMethod.ScanActiveDirectory;
                }
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == QueryMethod.BrowseForOrTypeInComputerNames))
                {
                    this.Controls.BrowseForOrTypeInComputerNamesRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == QueryMethod.ScanActiveDirectory))
                    {
                        this.Controls.ScanActiveDirectoryRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region IQueryCriteriaWindow Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the window's control properties together</value>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IQueryCriteriaWindowControls Controls
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
        ///  Routine to set/get the text in control Domain
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DomainText
        {
            get
            {
                return this.Controls.DomainEditComboBox.Text;
            }
            
            set
            {
                this.Controls.DomainEditComboBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Domain2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string Domain2Text
        {
            get
            {
                return this.Controls.DomainTextBox.Text;
            }
            
            set
            {
                this.Controls.DomainTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ComputerNames
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ComputerNamesText
        {
            get
            {
                return this.Controls.ComputerNamesTextBox.Text;
            }
            
            set
            {
                this.Controls.ComputerNamesTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control LdapQuery
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string LdapQueryText
        {
            get
            {
                return this.Controls.LdapQueryTextBox.Text;
            }
            
            set
            {
                this.Controls.LdapQueryTextBox.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ManagementServer
        /// </summary>
        /// <value>Name of the management server (FQDN)</value>
        /// <history>
        /// 	[jnwoko] 06 OCT 08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ManagementServerText
        {
            get
            {
                return this.Controls.ManagementServerComboBox.Text;
            }

            set
            {
                this.Controls.ManagementServerComboBox.SelectByText(value, true);
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IQueryCriteriaWindowControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, QueryCriteriaWindow.ControlIDs.PreviousButton);
                }
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IQueryCriteriaWindowControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, QueryCriteriaWindow.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FinishButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IQueryCriteriaWindowControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, QueryCriteriaWindow.ControlIDs.FinishButton);
                }
                return this.cachedFinishButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IQueryCriteriaWindowControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, QueryCriteriaWindow.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IntroductionStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IQueryCriteriaWindowControls.IntroductionStaticControl
        {
            get
            {
                if ((this.cachedIntroductionStaticControl == null))
                {
                    this.cachedIntroductionStaticControl = new StaticControl(this, QueryCriteriaWindow.ControlIDs.IntroductionStaticControl);
                }
                return this.cachedIntroductionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AutoOrAdvancedStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IQueryCriteriaWindowControls.AutoOrAdvancedStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedAutoOrAdvancedStaticControl == null))
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
                    this.cachedAutoOrAdvancedStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedAutoOrAdvancedStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DiscoveryMethodStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IQueryCriteriaWindowControls.DiscoveryMethodStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
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
        ///  Exposes access to the AdministratorAccountStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IQueryCriteriaWindowControls.AdministratorAccountStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedAdministratorAccountStaticControl == null))
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
                    this.cachedAdministratorAccountStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedAdministratorAccountStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RunningDiscoveryStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IQueryCriteriaWindowControls.RunningDiscoveryStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedRunningDiscoveryStaticControl == null))
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
                    this.cachedRunningDiscoveryStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedRunningDiscoveryStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectObjectsToManageStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IQueryCriteriaWindowControls.SelectObjectsToManageStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedSelectObjectsToManageStaticControl == null))
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
                    this.cachedSelectObjectsToManageStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedSelectObjectsToManageStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SummaryStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IQueryCriteriaWindowControls.SummaryStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
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
        ///  Exposes access to the DomainEditComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IQueryCriteriaWindowControls.DomainEditComboBox
        {
            get
            {
                if ((this.cachedDomainEditComboBox == null))
                {
                    this.cachedDomainEditComboBox = new EditComboBox(this, QueryCriteriaWindow.ControlIDs.DomainEditComboBox);
                }
                return this.cachedDomainEditComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DomainTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IQueryCriteriaWindowControls.DomainTextBox
        {
            get
            {
                if ((this.cachedDomainTextBox == null))
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
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedDomainTextBox = new TextBox(wndTemp);
                }
                return this.cachedDomainTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DomainStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IQueryCriteriaWindowControls.DomainStaticControl
        {
            get
            {
                if ((this.cachedDomainStaticControl == null))
                {
                    this.cachedDomainStaticControl = new StaticControl(this, QueryCriteriaWindow.ControlIDs.DomainStaticControl);
                }
                return this.cachedDomainStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ComputerNamesTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IQueryCriteriaWindowControls.ComputerNamesTextBox
        {
            get
            {
                if ((this.cachedComputerNamesTextBox == null))
                {
                    this.cachedComputerNamesTextBox = new TextBox(this, QueryCriteriaWindow.ControlIDs.ComputerNamesTextBox);
                }
                return this.cachedComputerNamesTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BrowseButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IQueryCriteriaWindowControls.BrowseButton
        {
            get
            {
                if ((this.cachedBrowseButton == null))
                {
                    this.cachedBrowseButton = new Button(this, QueryCriteriaWindow.ControlIDs.BrowseButton);
                }
                return this.cachedBrowseButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectObjectsFromActiveDirectoryStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IQueryCriteriaWindowControls.SelectObjectsFromActiveDirectoryStaticControl
        {
            get
            {
                if ((this.cachedSelectObjectsFromActiveDirectoryStaticControl == null))
                {
                    this.cachedSelectObjectsFromActiveDirectoryStaticControl = new StaticControl(this, QueryCriteriaWindow.ControlIDs.SelectObjectsFromActiveDirectoryStaticControl);
                }
                return this.cachedSelectObjectsFromActiveDirectoryStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BrowseActiveDirectoryStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IQueryCriteriaWindowControls.BrowseActiveDirectoryStaticControl
        {
            get
            {
                if ((this.cachedBrowseActiveDirectoryStaticControl == null))
                {
                    this.cachedBrowseActiveDirectoryStaticControl = new StaticControl(this, QueryCriteriaWindow.ControlIDs.BrowseActiveDirectoryStaticControl);
                }
                return this.cachedBrowseActiveDirectoryStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LdapQueryTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IQueryCriteriaWindowControls.LdapQueryTextBox
        {
            get
            {
                if ((this.cachedLdapQueryTextBox == null))
                {
                    this.cachedLdapQueryTextBox = new TextBox(this, QueryCriteriaWindow.ControlIDs.LdapQueryTextBox);
                }
                return this.cachedLdapQueryTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IQueryCriteriaWindowControls.ConfigureButton
        {
            get
            {
                if ((this.cachedConfigureButton == null))
                {
                    this.cachedConfigureButton = new Button(this, QueryCriteriaWindow.ControlIDs.ConfigureButton);
                }
                return this.cachedConfigureButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HowDoYouWantToDiscoverComputersStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IQueryCriteriaWindowControls.HowDoYouWantToDiscoverComputersStaticControl
        {
            get
            {
                if ((this.cachedHowDoYouWantToDiscoverComputersStaticControl == null))
                {
                    this.cachedHowDoYouWantToDiscoverComputersStaticControl = new StaticControl(this, QueryCriteriaWindow.ControlIDs.HowDoYouWantToDiscoverComputersStaticControl);
                }
                return this.cachedHowDoYouWantToDiscoverComputersStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BrowseForOrTypeInComputerNamesRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IQueryCriteriaWindowControls.BrowseForOrTypeInComputerNamesRadioButton
        {
            get
            {
                if ((this.cachedBrowseForOrTypeInComputerNamesRadioButton == null))
                {
                    this.cachedBrowseForOrTypeInComputerNamesRadioButton = new RadioButton(this, QueryCriteriaWindow.ControlIDs.BrowseForOrTypeInComputerNamesRadioButton);
                }
                return this.cachedBrowseForOrTypeInComputerNamesRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ScanActiveDirectoryRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IQueryCriteriaWindowControls.ScanActiveDirectoryRadioButton
        {
            get
            {
                if ((this.cachedScanActiveDirectoryRadioButton == null))
                {
                    this.cachedScanActiveDirectoryRadioButton = new RadioButton(this, QueryCriteriaWindow.ControlIDs.ScanActiveDirectoryRadioButton);
                }
                return this.cachedScanActiveDirectoryRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IQueryCriteriaWindowControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, QueryCriteriaWindow.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DiscoveryMethodStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IQueryCriteriaWindowControls.DiscoveryMethodStaticControl2
        {
            get
            {
                if ((this.cachedDiscoveryMethodStaticControl2 == null))
                {
                    this.cachedDiscoveryMethodStaticControl2 = new StaticControl(this, QueryCriteriaWindow.ControlIDs.DiscoveryMethodStaticControl2);
                }
                return this.cachedDiscoveryMethodStaticControl2;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementServerComboBox control
        /// </summary>
        /// <history>
        /// 	[jnwoko] 06-OCT-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IQueryCriteriaWindowControls.ManagementServerComboBox
        {
            get
            {
                if ((this.cachedManagementServerComboBox == null))
                {
                    this.cachedManagementServerComboBox =
                        new ComboBox(
                            this,
                            DiscoveryMethodWindow.ControlIDs.ManagementServerComboBox,
                            true,
                            QueryCriteriaWindow.Timeout);
                }
                return this.cachedManagementServerComboBox;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
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
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNext()
        {
            this.Controls.NextButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Finish
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickFinish()
        {
            this.Controls.FinishButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Browse
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickBrowse()
        {
            this.Controls.BrowseButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Configure
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickConfigure()
        {
            this.Controls.ConfigureButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find the window.
        /// </summary>
        /// <returns>A System.IntPtr representing a handle to the window.</returns>
        ///  <param name="ownerWindow">App class instance that owns this window.</param>)
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static System.IntPtr Init(App ownerWindow)
        {
            // First check if the window is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a window
                tempWindow = new Window(
                    Strings.WindowTitle + "*",
                    StringMatchSyntax.WildCard);
            }
            catch (Exceptions.WindowNotFoundException ex)
            {
                // try again with wildcards in the title
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
                                Strings.WindowTitle + "*",
                                StringMatchSyntax.WildCard);

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

                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find window with title:  '" +
                        Strings.WindowTitle + "'");

                    // throw the existing WindowNotFound exception
                    throw ex;
                }
            }
            return tempWindow.Extended.HWnd;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Contains resource string definitions.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWindowTitle = ";Computer and Device Management Wizard;ManagedString;" +
                "Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;" +
                "DiscoveryWizardCaption";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrevious = ";< &Previous;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.Enterp" +
                "riseManagement.Mom.Internal.UI.PageFramework.WizardButtonsPanel;previousButto" +
                "n.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext = ";&Next >;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.Enterprise" +
                "Management.Mom.Internal.UI.PageFrameworks.WizardFramework;buttonNext.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Finish
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFinish = ";&Finish;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.Enterprise" +
                "Management.Mom.Internal.UI.PageFrameworks.WizardFramework;buttonFinish.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseM" +
                "anagement.Mom.Internal.UI.PageFrameworks.WizardFramework;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Introduction
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceIntroduction = ";Introduction;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.E" +
                "nterpriseManagement.Mom.Internal.UI.Administration.AdminResources;WelcomeTitl" +
                "e";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AutoOrAdvanced
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAutoOrAdvanced = ";Auto or Advanced?;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micros" +
                "oft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;Discov" +
                "eryModeTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DiscoveryMethod
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDiscoveryMethod = ";Discovery Method;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microso" +
                "ft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;Discove" +
                "ryMethodTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AdministratorAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdministratorAccount = ";Administrator Account;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Mi" +
                "crosoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;Co" +
                "nnectionAccountTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RunningDiscovery
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRunningDiscovery = ";Running Discovery...;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Mic" +
                "rosoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;Dis" +
                "coveryProgressTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectObjectsToManage
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectObjectsToManage = ";Select Objects to Manage;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources.en" +
                ";DiscoveryResultsTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Summary
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSummary = ";Summary;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.Enterp" +
                "riseManagement.Mom.Internal.UI.Administration.AdminResources;SummaryTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Domain
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDomain = ";D&omain:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.Enter" +
                "priseManagement.Mom.Internal.UI.Administration.WindowsComputers;labelDomain.T" +
                "ext";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Browse
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceBrowse = ";&Browse...;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.Ent" +
                "erpriseManagement.Mom.Internal.UI.Administration.WindowsComputers;buttonBrows" +
                "e.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectObjectsFromActiveDirectory
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectObjectsFromActiveDirectory = ";Select objects from Active Directory to scan, or create an advanced query.;Manag" +
                "edString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagemen" +
                "t.Mom.Internal.UI.Administration.WindowsComputers;labelScan.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  BrowseActiveDirectoryStaticControl
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceBrowseActiveDirectoryStaticControl = @";Browse Active Directory or type computer names into the list below. Separate each computer name by a semi-colon, comma or a new line:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.WindowsComputers;labelBrowse.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Configure
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigure = ";&Configure...;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft." +
                "EnterpriseManagement.Mom.Internal.UI.Administration.WindowsComputers;buttonCo" +
                "nfigure.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  HowDoYouWantToDiscoverComputers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHowDoYouWantToDiscoverComputers = ";How do you want to discover computers?;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Win" +
                "dowsComputers;labelTitle.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  BrowseForOrTypeInComputerNames
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceBrowseForOrTypeInComputerNames = ";B&rowse for, or type-in computer names;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Win" +
                "dowsComputers;radioButtonBrowse.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ScanActiveDirectory
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceScanActiveDirectory = ";&Scan Active Directory;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;M" +
                "icrosoft.EnterpriseManagement.Mom.Internal.UI.Administration.WindowsComputers.en" +
                ";radioButtonScan.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseMan" +
                "agement.Mom.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DiscoveryMethod2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDiscoveryMethod2 = ";Discovery Method;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microso" +
                "ft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;Discove" +
                "ryMethodTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MultipleNamesFoundDialogTitle
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMultipleNamesFoundDialogTitle = ";Multiple Names Found;Win32DialogString;objsel.dll;107";
            
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
            /// Caches the translated resource string for:  Finish
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFinish;
            
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
            /// Caches the translated resource string for:  AutoOrAdvanced
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAutoOrAdvanced;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DiscoveryMethod
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDiscoveryMethod;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AdministratorAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdministratorAccount;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RunningDiscovery
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRunningDiscovery;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectObjectsToManage
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectObjectsToManage;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Summary
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSummary;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Domain
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDomain;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Browse
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBrowse;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectObjectsFromActiveDirectory
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectObjectsFromActiveDirectory;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  BrowseActiveDirectoryStaticControl
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBrowseActiveDirectoryStaticControl;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Configure
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigure;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  HowDoYouWantToDiscoverComputers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHowDoYouWantToDiscoverComputers;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  BrowseForOrTypeInComputerNames
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBrowseForOrTypeInComputerNames;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ScanActiveDirectory
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedScanActiveDirectory;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DiscoveryMethod2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDiscoveryMethod2;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MultipleNamesFoundDialogTitle
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMultipleNamesFoundDialogTitle;
            
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WindowTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
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
            /// 	[KellyMor] 2/3/2006 Created
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
            /// 	[KellyMor] 2/3/2006 Created
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
            /// Exposes access to the Finish translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Finish
            {
                get
                {
                    if ((cachedFinish == null))
                    {
                        cachedFinish = CoreManager.MomConsole.GetIntlStr(ResourceFinish);
                    }
                    return cachedFinish;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
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
            /// 	[KellyMor] 2/3/2006 Created
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
            /// Exposes access to the AutoOrAdvanced translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AutoOrAdvanced
            {
                get
                {
                    if ((cachedAutoOrAdvanced == null))
                    {
                        cachedAutoOrAdvanced = CoreManager.MomConsole.GetIntlStr(ResourceAutoOrAdvanced);
                    }
                    return cachedAutoOrAdvanced;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DiscoveryMethod translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
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
            /// Exposes access to the AdministratorAccount translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdministratorAccount
            {
                get
                {
                    if ((cachedAdministratorAccount == null))
                    {
                        cachedAdministratorAccount = CoreManager.MomConsole.GetIntlStr(ResourceAdministratorAccount);
                    }
                    return cachedAdministratorAccount;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RunningDiscovery translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RunningDiscovery
            {
                get
                {
                    if ((cachedRunningDiscovery == null))
                    {
                        cachedRunningDiscovery = CoreManager.MomConsole.GetIntlStr(ResourceRunningDiscovery);
                    }
                    return cachedRunningDiscovery;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectObjectsToManage translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectObjectsToManage
            {
                get
                {
                    if ((cachedSelectObjectsToManage == null))
                    {
                        cachedSelectObjectsToManage = CoreManager.MomConsole.GetIntlStr(ResourceSelectObjectsToManage);
                    }
                    return cachedSelectObjectsToManage;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Summary translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
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
            /// Exposes access to the Domain translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
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
            /// Exposes access to the Browse translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Browse
            {
                get
                {
                    if ((cachedBrowse == null))
                    {
                        cachedBrowse = CoreManager.MomConsole.GetIntlStr(ResourceBrowse);
                    }
                    return cachedBrowse;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectObjectsFromActiveDirectory translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectObjectsFromActiveDirectory
            {
                get
                {
                    if ((cachedSelectObjectsFromActiveDirectory == null))
                    {
                        cachedSelectObjectsFromActiveDirectory = CoreManager.MomConsole.GetIntlStr(ResourceSelectObjectsFromActiveDirectory);
                    }
                    return cachedSelectObjectsFromActiveDirectory;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the BrowseActiveDirectoryStaticControl translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string BrowseActiveDirectoryStaticControl
            {
                get
                {
                    if ((cachedBrowseActiveDirectoryStaticControl == null))
                    {
                        cachedBrowseActiveDirectoryStaticControl = CoreManager.MomConsole.GetIntlStr(ResourceBrowseActiveDirectoryStaticControl);
                    }
                    return cachedBrowseActiveDirectoryStaticControl;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Configure translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Configure
            {
                get
                {
                    if ((cachedConfigure == null))
                    {
                        cachedConfigure = CoreManager.MomConsole.GetIntlStr(ResourceConfigure);
                    }
                    return cachedConfigure;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the HowDoYouWantToDiscoverComputers translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string HowDoYouWantToDiscoverComputers
            {
                get
                {
                    if ((cachedHowDoYouWantToDiscoverComputers == null))
                    {
                        cachedHowDoYouWantToDiscoverComputers = CoreManager.MomConsole.GetIntlStr(ResourceHowDoYouWantToDiscoverComputers);
                    }
                    return cachedHowDoYouWantToDiscoverComputers;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the BrowseForOrTypeInComputerNames translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string BrowseForOrTypeInComputerNames
            {
                get
                {
                    if ((cachedBrowseForOrTypeInComputerNames == null))
                    {
                        cachedBrowseForOrTypeInComputerNames = CoreManager.MomConsole.GetIntlStr(ResourceBrowseForOrTypeInComputerNames);
                    }
                    return cachedBrowseForOrTypeInComputerNames;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ScanActiveDirectory translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ScanActiveDirectory
            {
                get
                {
                    if ((cachedScanActiveDirectory == null))
                    {
                        cachedScanActiveDirectory = CoreManager.MomConsole.GetIntlStr(ResourceScanActiveDirectory);
                    }
                    return cachedScanActiveDirectory;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
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
            /// Exposes access to the DiscoveryMethod2 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DiscoveryMethod2
            {
                get
                {
                    if ((cachedDiscoveryMethod2 == null))
                    {
                        cachedDiscoveryMethod2 = CoreManager.MomConsole.GetIntlStr(ResourceDiscoveryMethod2);
                    }
                    return cachedDiscoveryMethod2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MultipleNamesFoundDialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[StarrPar] 8/13/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MultipleNamesFoundDialogTitle
            {
                get
                {
                    if ((cachedMultipleNamesFoundDialogTitle == null))
                    {
                        cachedMultipleNamesFoundDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceMultipleNamesFoundDialogTitle);
                    }
                    return cachedMultipleNamesFoundDialogTitle;
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
        /// 	[KellyMor] 2/3/2006 Created
        /// 	[jnwoko] 10/06/2008 modified due to 112171 Added ManagementServer Combobox
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
            /// Control ID for FinishButton
            /// </summary>
            public const string FinishButton = "commitButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for IntroductionStaticControl
            /// </summary>
            public const string IntroductionStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for AutoOrAdvancedStaticControl
            /// </summary>
            public const string AutoOrAdvancedStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for DiscoveryMethodStaticControl
            /// </summary>
            public const string DiscoveryMethodStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for AdministratorAccountStaticControl
            /// </summary>
            public const string AdministratorAccountStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for RunningDiscoveryStaticControl
            /// </summary>
            public const string RunningDiscoveryStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for SelectObjectsToManageStaticControl
            /// </summary>
            public const string SelectObjectsToManageStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for SummaryStaticControl
            /// </summary>
            public const string SummaryStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for DomainEditComboBox
            /// </summary>
            public const string DomainEditComboBox = "comboBoxDomains";
            
            /// <summary>
            /// Control ID for DomainStaticControl
            /// </summary>
            public const string DomainStaticControl = "labelDomain";
            
            /// <summary>
            /// Control ID for ComputerNamesTextBox
            /// </summary>
            public const string ComputerNamesTextBox = "richTextBoxComputers";
            
            /// <summary>
            /// Control ID for BrowseButton
            /// </summary>
            public const string BrowseButton = "buttonBrowse";
            
            /// <summary>
            /// Control ID for SelectObjectsFromActiveDirectoryStaticControl
            /// </summary>
            public const string SelectObjectsFromActiveDirectoryStaticControl = "labelScan";
            
            /// <summary>
            /// Control ID for BrowseActiveDirectoryStaticControl
            /// </summary>
            public const string BrowseActiveDirectoryStaticControl = "labelBrowse";
            
            /// <summary>
            /// Control ID for LdapQueryTextBox
            /// </summary>
            public const string LdapQueryTextBox = "textBoxQuery";
            
            /// <summary>
            /// Control ID for ConfigureButton
            /// </summary>
            public const string ConfigureButton = "buttonConfigure";
            
            /// <summary>
            /// Control ID for HowDoYouWantToDiscoverComputersStaticControl
            /// </summary>
            public const string HowDoYouWantToDiscoverComputersStaticControl = "labelTitle";
            
            /// <summary>
            /// Control ID for BrowseForOrTypeInComputerNamesRadioButton
            /// </summary>
            public const string BrowseForOrTypeInComputerNamesRadioButton = "radioButtonBrowse";
            
            /// <summary>
            /// Control ID for ScanActiveDirectoryRadioButton
            /// </summary>
            public const string ScanActiveDirectoryRadioButton = "radioButtonScan";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for DiscoveryMethodStaticControl2
            /// </summary>
            public const string DiscoveryMethodStaticControl2 = "headerLabel";

            /// <summary>
            /// Control ID for ManagementServerComboBox
            /// </summary>
            public const string ManagementServerComboBox = "comboBoxProxy";
        }
        #endregion
    }
}
