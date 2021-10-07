// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="DiscoveryResultsWindow.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[KellyMor] 07-Feb-06    Created
//  [KellyMor] 27-Feb-06    Updated resource strings
//  [KellyMor] 12-Apr-06    Added timeout to combobox constructor for proxy server combo
//  [KellyMor] 07-Jun-06    Updated resource assembly for new Admin assembly
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IDiscoveryResultsWindowControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IDiscoveryResultsWindowControls, for DiscoveryResultsWindow.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 2/7/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IDiscoveryResultsWindowControls
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
        /// Read-only property to access DeselectAllButton
        /// </summary>
        Button DeselectAllButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectAllButton
        /// </summary>
        Button SelectAllButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ManagementModeComboBox
        /// </summary>
        ComboBox ManagementModeComboBox
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
        
        /// <summary>
        /// Read-only property to access ManagementModeStaticControl
        /// </summary>
        StaticControl ManagementModeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ManagementServerStaticControl
        /// </summary>
        StaticControl ManagementServerStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectObjectsToManageListView
        /// </summary>
        ListView SelectObjectsToManageListView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectTheDevicesYouWantToManageStaticControl
        /// </summary>
        StaticControl SelectTheDevicesYouWantToManageStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TheDiscoveryProcessFoundTheFollowingUnManagedDevicesStaticControl
        /// </summary>
        StaticControl TheDiscoveryProcessFoundTheFollowingUnManagedDevicesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DiscoveryResultsStaticControl
        /// </summary>
        StaticControl DiscoveryResultsStaticControl
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
        /// Read-only property to access SelectObjectsToManageStaticControl2
        /// </summary>
        StaticControl SelectObjectsToManageStaticControl2
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the functionality of the discovery results step 
    /// in the Computer and Device Management Wizard.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 2/7/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class DiscoveryResultsWindow : Window, IDiscoveryResultsWindowControls
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
        private const int Timeout = 5000;
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
        /// Cache to hold a reference to DeselectAllButton of type Button
        /// </summary>
        private Button cachedDeselectAllButton;
        
        /// <summary>
        /// Cache to hold a reference to SelectAllButton of type Button
        /// </summary>
        private Button cachedSelectAllButton;
        
        /// <summary>
        /// Cache to hold a reference to ManagementModeComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedManagementModeComboBox;
        
        /// <summary>
        /// Cache to hold a reference to ManagementServerComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedManagementServerComboBox;
        
        /// <summary>
        /// Cache to hold a reference to ManagementModeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedManagementModeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ManagementServerStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedManagementServerStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectObjectsToManageListView of type ListView
        /// </summary>
        private ListView cachedSelectObjectsToManageListView;
        
        /// <summary>
        /// Cache to hold a reference to SelectTheDevicesYouWantToManageStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectTheDevicesYouWantToManageStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to TheDiscoveryProcessFoundTheFollowingUnManagedDevicesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTheDiscoveryProcessFoundTheFollowingUnManagedDevicesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DiscoveryResultsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDiscoveryResultsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectObjectsToManageStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedSelectObjectsToManageStaticControl2;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='ownerWindow'>
        /// Owner of DiscoveryResultsWindow of type App
        /// </param>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public DiscoveryResultsWindow(App ownerWindow) : 
                base(Init(ownerWindow))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IDiscoveryResultsWindow Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the window's control properties together</value>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IDiscoveryResultsWindowControls Controls
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
        ///  Routine to set/get the text in control ManagementMode
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ManagementModeText
        {
            get
            {
                return this.Controls.ManagementModeComboBox.Text;
            }
            
            set
            {
                this.Controls.ManagementModeComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ManagementServer
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
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
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDiscoveryResultsWindowControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, DiscoveryResultsWindow.ControlIDs.PreviousButton);
                }
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDiscoveryResultsWindowControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, DiscoveryResultsWindow.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FinishButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDiscoveryResultsWindowControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, DiscoveryResultsWindow.ControlIDs.FinishButton);
                }
                return this.cachedFinishButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDiscoveryResultsWindowControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, DiscoveryResultsWindow.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IntroductionStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiscoveryResultsWindowControls.IntroductionStaticControl
        {
            get
            {
                if ((this.cachedIntroductionStaticControl == null))
                {
                    this.cachedIntroductionStaticControl = new StaticControl(this, DiscoveryResultsWindow.ControlIDs.IntroductionStaticControl);
                }
                return this.cachedIntroductionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AutoOrAdvancedStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiscoveryResultsWindowControls.AutoOrAdvancedStaticControl
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
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiscoveryResultsWindowControls.DiscoveryMethodStaticControl
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
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiscoveryResultsWindowControls.AdministratorAccountStaticControl
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
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiscoveryResultsWindowControls.RunningDiscoveryStaticControl
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
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiscoveryResultsWindowControls.SelectObjectsToManageStaticControl
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
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiscoveryResultsWindowControls.SummaryStaticControl
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
        ///  Exposes access to the DeselectAllButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDiscoveryResultsWindowControls.DeselectAllButton
        {
            get
            {
                if ((this.cachedDeselectAllButton == null))
                {
                    this.cachedDeselectAllButton = new Button(this, DiscoveryResultsWindow.ControlIDs.DeselectAllButton);
                }
                return this.cachedDeselectAllButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectAllButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDiscoveryResultsWindowControls.SelectAllButton
        {
            get
            {
                if ((this.cachedSelectAllButton == null))
                {
                    this.cachedSelectAllButton = new Button(this, DiscoveryResultsWindow.ControlIDs.SelectAllButton);
                }
                return this.cachedSelectAllButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementModeComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IDiscoveryResultsWindowControls.ManagementModeComboBox
        {
            get
            {
                if ((this.cachedManagementModeComboBox == null))
                {
                    this.cachedManagementModeComboBox = 
                        new ComboBox(
                        this, 
                        DiscoveryResultsWindow.ControlIDs.ManagementModeComboBox);
                }
                return this.cachedManagementModeComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementServerComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IDiscoveryResultsWindowControls.ManagementServerComboBox
        {
            get
            {
                if ((this.cachedManagementServerComboBox == null))
                {
                    this.cachedManagementServerComboBox = 
                        new ComboBox(
                            this, 
                            DiscoveryResultsWindow.ControlIDs.ManagementServerComboBox,
                            true,
                            DiscoveryResultsWindow.Timeout);
                }
                return this.cachedManagementServerComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementModeStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiscoveryResultsWindowControls.ManagementModeStaticControl
        {
            get
            {
                if ((this.cachedManagementModeStaticControl == null))
                {
                    this.cachedManagementModeStaticControl = new StaticControl(this, DiscoveryResultsWindow.ControlIDs.ManagementModeStaticControl);
                }
                return this.cachedManagementModeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementServerStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiscoveryResultsWindowControls.ManagementServerStaticControl
        {
            get
            {
                if ((this.cachedManagementServerStaticControl == null))
                {
                    this.cachedManagementServerStaticControl = new StaticControl(this, DiscoveryResultsWindow.ControlIDs.ManagementServerStaticControl);
                }
                return this.cachedManagementServerStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectObjectsToManageListView control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IDiscoveryResultsWindowControls.SelectObjectsToManageListView
        {
            get
            {
                if ((this.cachedSelectObjectsToManageListView == null))
                {
                    this.cachedSelectObjectsToManageListView = new ListView(this, DiscoveryResultsWindow.ControlIDs.SelectObjectsToManageListView);
                }
                return this.cachedSelectObjectsToManageListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectTheDevicesYouWantToManageStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiscoveryResultsWindowControls.SelectTheDevicesYouWantToManageStaticControl
        {
            get
            {
                if ((this.cachedSelectTheDevicesYouWantToManageStaticControl == null))
                {
                    this.cachedSelectTheDevicesYouWantToManageStaticControl = new StaticControl(this, DiscoveryResultsWindow.ControlIDs.SelectTheDevicesYouWantToManageStaticControl);
                }
                return this.cachedSelectTheDevicesYouWantToManageStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TheDiscoveryProcessFoundTheFollowingUnManagedDevicesStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiscoveryResultsWindowControls.TheDiscoveryProcessFoundTheFollowingUnManagedDevicesStaticControl
        {
            get
            {
                if ((this.cachedTheDiscoveryProcessFoundTheFollowingUnManagedDevicesStaticControl == null))
                {
                    this.cachedTheDiscoveryProcessFoundTheFollowingUnManagedDevicesStaticControl = new StaticControl(this, DiscoveryResultsWindow.ControlIDs.TheDiscoveryProcessFoundTheFollowingUnManagedDevicesStaticControl);
                }
                return this.cachedTheDiscoveryProcessFoundTheFollowingUnManagedDevicesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DiscoveryResultsStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiscoveryResultsWindowControls.DiscoveryResultsStaticControl
        {
            get
            {
                if ((this.cachedDiscoveryResultsStaticControl == null))
                {
                    this.cachedDiscoveryResultsStaticControl = new StaticControl(this, DiscoveryResultsWindow.ControlIDs.DiscoveryResultsStaticControl);
                }
                return this.cachedDiscoveryResultsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiscoveryResultsWindowControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, DiscoveryResultsWindow.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectObjectsToManageStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiscoveryResultsWindowControls.SelectObjectsToManageStaticControl2
        {
            get
            {
                if ((this.cachedSelectObjectsToManageStaticControl2 == null))
                {
                    this.cachedSelectObjectsToManageStaticControl2 = new StaticControl(this, DiscoveryResultsWindow.ControlIDs.SelectObjectsToManageStaticControl2);
                }
                return this.cachedSelectObjectsToManageStaticControl2;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
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
        /// 	[KellyMor] 2/7/2006 Created
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
        /// 	[KellyMor] 2/7/2006 Created
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
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button DeselectAll
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickDeselectAll()
        {
            this.Controls.DeselectAllButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button SelectAll
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSelectAll()
        {
            this.Controls.SelectAllButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find the window.
        /// </summary>
        /// <returns>A System.IntPtr representing a handle to the window.</returns>
        ///  <param name="ownerWindow">App class instance that owns this window.</param>)
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
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
        /// 	[KellyMor] 2/7/2006 Created
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
            /// Contains resource string for:  DeselectAll
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDeselectAll = ";D&eselect All;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft." +
                "EnterpriseManagement.Mom.Internal.UI.Administration.DiscoveryResults;buttonDe" +
                "select.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectAll
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectAll = ";Select &All;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.Enterp" +
                "riseManagement.Mom.Internal.UI.PageFrameworks.PageFrameworksMain;SelectAllMen" +
                "uText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ManagementMode
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceManagementMode = ";Management M&ode:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micros" +
                "oft.EnterpriseManagement.Mom.Internal.UI.Administration.DiscoveryResults;labe" +
                "lMode.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ManagementServer
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceManagementServer = ";&Management Server;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;Manag" +
                "ementServerText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectTheDevicesYouWantToManage
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectTheDevicesYouWantToManage = ";&Select the devices you want to manage:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Di" +
                "scoveryResults;labelSelectManage.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TheDiscoveryProcessFoundTheFollowingUnManagedDevices
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTheDiscoveryProcessFoundTheFollowingUnManagedDevices = ";The discovery process found the following un-managed devices.;ManagedString;" +
                "Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Interna" +
                "l.UI.Administration.DiscoveryResults;labelDescription.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DiscoveryResults
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDiscoveryResults = ";Discovery Results;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micros" +
                "oft.EnterpriseManagement.Mom.Internal.UI.Administration.DiscoveryProgress;lab" +
                "elTitle.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseMan" +
                "agement.Mom.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectObjectsToManage2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectObjectsToManage2 = ";Select Objects to Manage;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources.en" +
                ";DiscoveryResultsTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ComboBoxAgentManaged
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceComboBoxAgentManaged = ";Agent;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" + 
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;" + 
                "ManagementModeAgent";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ComboBoxAgentlessManaged
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceComboBoxAgentlessManaged = ";Agentless;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" + 
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;" + 
                "ManagementModeProxy";

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
            /// Caches the translated resource string for:  DeselectAll
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDeselectAll;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectAll
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectAll;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ManagementMode
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedManagementMode;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ManagementServer
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedManagementServer;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectTheDevicesYouWantToManage
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectTheDevicesYouWantToManage;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TheDiscoveryProcessFoundTheFollowingUnManagedDevices
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTheDiscoveryProcessFoundTheFollowingUnManagedDevices;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DiscoveryResults
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDiscoveryResults;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectObjectsToManage2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectObjectsToManage2;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ComboBoxAgentManaged
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedComboBoxAgentManaged;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ComboBoxAgentlessManaged
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedComboBoxAgentlessManaged;

            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WindowTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/7/2006 Created
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
            /// 	[KellyMor] 2/7/2006 Created
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
            /// 	[KellyMor] 2/7/2006 Created
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
            /// 	[KellyMor] 2/7/2006 Created
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
            /// 	[KellyMor] 2/7/2006 Created
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
            /// 	[KellyMor] 2/7/2006 Created
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
            /// 	[KellyMor] 2/7/2006 Created
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
            /// 	[KellyMor] 2/7/2006 Created
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
            /// 	[KellyMor] 2/7/2006 Created
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
            /// 	[KellyMor] 2/7/2006 Created
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
            /// 	[KellyMor] 2/7/2006 Created
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
            /// 	[KellyMor] 2/7/2006 Created
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
            /// Exposes access to the DeselectAll translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DeselectAll
            {
                get
                {
                    if ((cachedDeselectAll == null))
                    {
                        cachedDeselectAll = CoreManager.MomConsole.GetIntlStr(ResourceDeselectAll);
                    }
                    return cachedDeselectAll;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectAll translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectAll
            {
                get
                {
                    if ((cachedSelectAll == null))
                    {
                        cachedSelectAll = CoreManager.MomConsole.GetIntlStr(ResourceSelectAll);
                    }
                    return cachedSelectAll;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ManagementMode translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ManagementMode
            {
                get
                {
                    if ((cachedManagementMode == null))
                    {
                        cachedManagementMode = CoreManager.MomConsole.GetIntlStr(ResourceManagementMode);
                    }
                    return cachedManagementMode;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ManagementServer translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ManagementServer
            {
                get
                {
                    if ((cachedManagementServer == null))
                    {
                        cachedManagementServer = CoreManager.MomConsole.GetIntlStr(ResourceManagementServer);
                    }
                    return cachedManagementServer;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectTheDevicesYouWantToManage translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectTheDevicesYouWantToManage
            {
                get
                {
                    if ((cachedSelectTheDevicesYouWantToManage == null))
                    {
                        cachedSelectTheDevicesYouWantToManage = CoreManager.MomConsole.GetIntlStr(ResourceSelectTheDevicesYouWantToManage);
                    }
                    return cachedSelectTheDevicesYouWantToManage;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TheDiscoveryProcessFoundTheFollowingUnManagedDevices translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TheDiscoveryProcessFoundTheFollowingUnManagedDevices
            {
                get
                {
                    if ((cachedTheDiscoveryProcessFoundTheFollowingUnManagedDevices == null))
                    {
                        cachedTheDiscoveryProcessFoundTheFollowingUnManagedDevices = CoreManager.MomConsole.GetIntlStr(ResourceTheDiscoveryProcessFoundTheFollowingUnManagedDevices);
                    }
                    return cachedTheDiscoveryProcessFoundTheFollowingUnManagedDevices;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DiscoveryResults translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DiscoveryResults
            {
                get
                {
                    if ((cachedDiscoveryResults == null))
                    {
                        cachedDiscoveryResults = CoreManager.MomConsole.GetIntlStr(ResourceDiscoveryResults);
                    }
                    return cachedDiscoveryResults;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/7/2006 Created
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
            /// Exposes access to the SelectObjectsToManage2 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectObjectsToManage2
            {
                get
                {
                    if ((cachedSelectObjectsToManage2 == null))
                    {
                        cachedSelectObjectsToManage2 = CoreManager.MomConsole.GetIntlStr(ResourceSelectObjectsToManage2);
                    }
                    return cachedSelectObjectsToManage2;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ComboBoxAgentManaged translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ComboBoxAgentManaged
            {
                get
                {
                    if ((cachedComboBoxAgentManaged == null))
                    {
                        cachedComboBoxAgentManaged = CoreManager.MomConsole.GetIntlStr(ResourceComboBoxAgentManaged);
                    }
                    return cachedComboBoxAgentManaged;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ComboBoxAgentlessManaged translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ComboBoxAgentlessManaged
            {
                get
                {
                    if ((cachedComboBoxAgentlessManaged == null))
                    {
                        cachedComboBoxAgentlessManaged = CoreManager.MomConsole.GetIntlStr(ResourceComboBoxAgentlessManaged);
                    }
                    return cachedComboBoxAgentlessManaged;
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
        /// 	[KellyMor] 2/7/2006 Created
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
            /// Control ID for DeselectAllButton
            /// </summary>
            public const string DeselectAllButton = "buttonDeselect";
            
            /// <summary>
            /// Control ID for SelectAllButton
            /// </summary>
            public const string SelectAllButton = "buttonSelectAll";
            
            /// <summary>
            /// Control ID for ManagementModeComboBox
            /// </summary>
            public const string ManagementModeComboBox = "comboBoxMode";
            
            /// <summary>
            /// Control ID for ManagementServerComboBox
            /// </summary>
            public const string ManagementServerComboBox = "comboBoxProxies";
            
            /// <summary>
            /// Control ID for ManagementModeStaticControl
            /// </summary>
            public const string ManagementModeStaticControl = "labelMode";
            
            /// <summary>
            /// Control ID for ManagementServerStaticControl
            /// </summary>
            public const string ManagementServerStaticControl = "labelProxy";
            
            /// <summary>
            /// Control ID for SelectObjectsToManageListView
            /// </summary>
            public const string SelectObjectsToManageListView = "listViewResults";
            
            /// <summary>
            /// Control ID for SelectTheDevicesYouWantToManageStaticControl
            /// </summary>
            public const string SelectTheDevicesYouWantToManageStaticControl = "labelSelectManage";
            
            /// <summary>
            /// Control ID for TheDiscoveryProcessFoundTheFollowingUnManagedDevicesStaticControl
            /// </summary>
            public const string TheDiscoveryProcessFoundTheFollowingUnManagedDevicesStaticControl = "labelDescription";
            
            /// <summary>
            /// Control ID for DiscoveryResultsStaticControl
            /// </summary>
            public const string DiscoveryResultsStaticControl = "labelTitle";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for SelectObjectsToManageStaticControl2
            /// </summary>
            public const string SelectObjectsToManageStaticControl2 = "headerLabel";
        }
        #endregion
    }
}
