// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ComputerAndDeviceType.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// </project>
// <summary>
// 	MOMv3 Test UI Automation
// </summary>
// <history>
// 	[jnwoko] 10/7/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Microsoft.EnterpriseManagement.Mom.Internal;
    
    #region Interface Definition - IComputerAndDeviceTypeControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IComputerAndDeviceTypeControls, for ComputerAndDeviceType.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[jnwoko] 10/7/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IComputerAndDeviceTypeControls
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
        /// Read-only property to access DiscoverButton
        /// </summary>
        Button DiscoverButton
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
        /// Read-only property to access DiscoveryTypeStaticControl
        /// </summary>
        StaticControl DiscoveryTypeStaticControl
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
        /// Read-only property to access ChooseTheTypeOfComputersOrDevicesToDiscoverAndManageStaticControl
        /// </summary>
        StaticControl ChooseTheTypeOfComputersOrDevicesToDiscoverAndManageStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectADiscoveryTypeAndClickNextToContinueStaticControl
        /// </summary>
        StaticControl SelectADiscoveryTypeAndClickNextToContinueStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ThisEnablesYouToDiscoverWindowsComputersInYourActiveDirectoryEnvironmentAndToInstallAgentsOnTheOnesY
        /// </summary>
        StaticControl ThisEnablesYouToDiscoverWindowsComputersInYourActiveDirectoryEnvironmentAndToInstallAgentsOnTheOnesY
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WindowsComputersStaticControl
        /// </summary>
        StaticControl WindowsComputersStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ThisEnablesYouToSpecifyAnIPRangeToDiscoverNetworkDevicesAndMonitorThemUsingSNMPStaticControl
        /// </summary>
        StaticControl ThisEnablesYouToSpecifyAnIPRangeToDiscoverNetworkDevicesAndMonitorThemUsingSNMPStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NetworkDevicesStaticControl
        /// </summary>
        StaticControl NetworkDevicesStaticControl
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
        /// Read-only property to access WhatWouldYouLikeToManageStaticControl
        /// </summary>
        StaticControl WhatWouldYouLikeToManageStaticControl
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    ///Class to encapsulate the functionality of the ComputerAndDeviceType (First)step of
    /// the Computer and Device Management Wizard.
    /// </summary>
    /// <history>
    /// 	[jnwoko] 10/7/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ComputerAndDeviceType : Dialog, IComputerAndDeviceTypeControls
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
        /// Cache to hold a reference to DiscoverButton of type Button
        /// </summary>
        private Button cachedDiscoverButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to DiscoveryTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDiscoveryTypeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DiscoveryMethodStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDiscoveryMethodStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectObjectsToManageStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectObjectsToManageStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SummaryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSummaryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ChooseTheTypeOfComputersOrDevicesToDiscoverAndManageStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedChooseTheTypeOfComputersOrDevicesToDiscoverAndManageStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectADiscoveryTypeAndClickNextToContinueStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectADiscoveryTypeAndClickNextToContinueStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ThisEnablesYouToDiscoverWindowsComputersInYourActiveDirectoryEnvironmentAndToInstallAgentsOnTheOnesY of type StaticControl
        /// </summary>
        private StaticControl cachedThisEnablesYouToDiscoverWindowsComputersInYourActiveDirectoryEnvironmentAndToInstallAgentsOnTheOnesY;
        
        /// <summary>
        /// Cache to hold a reference to WindowsComputersStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWindowsComputersStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ThisEnablesYouToSpecifyAnIPRangeToDiscoverNetworkDevicesAndMonitorThemUsingSNMPStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedThisEnablesYouToSpecifyAnIPRangeToDiscoverNetworkDevicesAndMonitorThemUsingSNMPStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to NetworkDevicesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNetworkDevicesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to WhatWouldYouLikeToManageStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWhatWouldYouLikeToManageStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Constructor for ComputerAndDeviceType Dialog which also includes retry logic 
        /// to account for slow load time.
        /// </summary>
        /// <param name='app'>
        /// Owner of ComputerAndDeviceType of type App
        /// </param>
        /// <history>
        /// 	[jnwoko] 10/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ComputerAndDeviceType(App app) : 
                base(app, Init(app))
        {
            const int maxVerifyAttempts = 90;
            const int timeout = Core.Common.Constants.OneSecond;

            CoreManager.MomConsole.Waiters.WaitForObjectPropertyChangedSafe(this.Controls.NextButton, "@IsEnabled", PropertyOperator.Equals, true);
            
            for (int currentAttempt = 1; (currentAttempt <= maxVerifyAttempts) && (this.Controls.NextButton.IsEnabled == false); currentAttempt++)
            {
                Core.Common.Utilities.LogMessage(
                            "This is attempt #: " + currentAttempt + " of " + maxVerifyAttempts + " to find wizard, sleeping for " + timeout + " [ms]");
                Maui.Core.Utilities.Sleeper.Delay(timeout);
            }

            if (this.Controls.NextButton.IsEnabled == false)
            {
                throw new Maui.GlobalExceptions.MauiException("ComputerAndDeviceType:Could not find Wizard, Next button was not enabled");
            }

        }
        #endregion

        #region IComputerAndDeviceType Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[jnwoko] 10/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IComputerAndDeviceTypeControls Controls
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
        /// 	[jnwoko] 10/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IComputerAndDeviceTypeControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, ComputerAndDeviceType.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[jnwoko] 10/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IComputerAndDeviceTypeControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, ComputerAndDeviceType.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DiscoverButton control
        /// </summary>
        /// <history>
        /// 	[jnwoko] 10/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IComputerAndDeviceTypeControls.DiscoverButton
        {
            get
            {
                if ((this.cachedDiscoverButton == null))
                {
                    this.cachedDiscoverButton = new Button(this, ComputerAndDeviceType.ControlIDs.DiscoverButton);
                }
                
                return this.cachedDiscoverButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[jnwoko] 10/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IComputerAndDeviceTypeControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ComputerAndDeviceType.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DiscoveryTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[jnwoko] 10/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IComputerAndDeviceTypeControls.DiscoveryTypeStaticControl
        {
            get
            {
                if ((this.cachedDiscoveryTypeStaticControl == null))
                {
                    this.cachedDiscoveryTypeStaticControl = new StaticControl(this, ComputerAndDeviceType.ControlIDs.DiscoveryTypeStaticControl);
                }
                
                return this.cachedDiscoveryTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DiscoveryMethodStaticControl control
        /// </summary>
        /// <history>
        /// 	[jnwoko] 10/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IComputerAndDeviceTypeControls.DiscoveryMethodStaticControl
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
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedDiscoveryMethodStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedDiscoveryMethodStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectObjectsToManageStaticControl control
        /// </summary>
        /// <history>
        /// 	[jnwoko] 10/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IComputerAndDeviceTypeControls.SelectObjectsToManageStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
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
                    for (i = 0; (i <= 1); i = (i + 1))
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
        /// 	[jnwoko] 10/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IComputerAndDeviceTypeControls.SummaryStaticControl
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
                    for (i = 0; (i <= 2); i = (i + 1))
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
        ///  Exposes access to the ChooseTheTypeOfComputersOrDevicesToDiscoverAndManageStaticControl control
        /// </summary>
        /// <history>
        /// 	[jnwoko] 10/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IComputerAndDeviceTypeControls.ChooseTheTypeOfComputersOrDevicesToDiscoverAndManageStaticControl
        {
            get
            {
                if ((this.cachedChooseTheTypeOfComputersOrDevicesToDiscoverAndManageStaticControl == null))
                {
                    this.cachedChooseTheTypeOfComputersOrDevicesToDiscoverAndManageStaticControl = new StaticControl(this, ComputerAndDeviceType.ControlIDs.ChooseTheTypeOfComputersOrDevicesToDiscoverAndManageStaticControl);
                }
                
                return this.cachedChooseTheTypeOfComputersOrDevicesToDiscoverAndManageStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectADiscoveryTypeAndClickNextToContinueStaticControl control
        /// </summary>
        /// <history>
        /// 	[jnwoko] 10/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IComputerAndDeviceTypeControls.SelectADiscoveryTypeAndClickNextToContinueStaticControl
        {
            get
            {
                if ((this.cachedSelectADiscoveryTypeAndClickNextToContinueStaticControl == null))
                {
                    this.cachedSelectADiscoveryTypeAndClickNextToContinueStaticControl = new StaticControl(this, ComputerAndDeviceType.ControlIDs.SelectADiscoveryTypeAndClickNextToContinueStaticControl);
                }
                
                return this.cachedSelectADiscoveryTypeAndClickNextToContinueStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ThisEnablesYouToDiscoverWindowsComputersInYourActiveDirectoryEnvironmentAndToInstallAgentsOnTheOnesY control
        /// </summary>
        /// <history>
        /// 	[jnwoko] 10/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IComputerAndDeviceTypeControls.ThisEnablesYouToDiscoverWindowsComputersInYourActiveDirectoryEnvironmentAndToInstallAgentsOnTheOnesY
        {
            get
            {
                if ((this.cachedThisEnablesYouToDiscoverWindowsComputersInYourActiveDirectoryEnvironmentAndToInstallAgentsOnTheOnesY == null))
                {
                    this.cachedThisEnablesYouToDiscoverWindowsComputersInYourActiveDirectoryEnvironmentAndToInstallAgentsOnTheOnesY = new StaticControl(this, ComputerAndDeviceType.ControlIDs.ThisEnablesYouToDiscoverWindowsComputersInYourActiveDirectoryEnvironmentAndToInstallAgentsOnTheOnesY);
                }
                
                return this.cachedThisEnablesYouToDiscoverWindowsComputersInYourActiveDirectoryEnvironmentAndToInstallAgentsOnTheOnesY;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WindowsComputersStaticControl control
        /// </summary>
        /// <history>
        /// 	[jnwoko] 10/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IComputerAndDeviceTypeControls.WindowsComputersStaticControl
        {
            get
            {
                if ((this.cachedWindowsComputersStaticControl == null))
                {
                    this.cachedWindowsComputersStaticControl = new StaticControl(this, Strings.WindowsComputers, StringMatchSyntax.ExactMatch, "*", StringMatchSyntax.WildCard);                    
                }
                
                return this.cachedWindowsComputersStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ThisEnablesYouToSpecifyAnIPRangeToDiscoverNetworkDevicesAndMonitorThemUsingSNMPStaticControl control
        /// </summary>
        /// <history>
        /// 	[jnwoko] 10/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IComputerAndDeviceTypeControls.ThisEnablesYouToSpecifyAnIPRangeToDiscoverNetworkDevicesAndMonitorThemUsingSNMPStaticControl
        {
            get
            {
                // The ID for this control (labelDescription) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedThisEnablesYouToSpecifyAnIPRangeToDiscoverNetworkDevicesAndMonitorThemUsingSNMPStaticControl == null))
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
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedThisEnablesYouToSpecifyAnIPRangeToDiscoverNetworkDevicesAndMonitorThemUsingSNMPStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedThisEnablesYouToSpecifyAnIPRangeToDiscoverNetworkDevicesAndMonitorThemUsingSNMPStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NetworkDevicesStaticControl control
        /// </summary>
        /// <history>
        /// 	[jnwoko] 10/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IComputerAndDeviceTypeControls.NetworkDevicesStaticControl
        {
            get
            {
                // The ID for this control (labelTitle) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedNetworkDevicesStaticControl == null))
                {


                    this.cachedNetworkDevicesStaticControl = new StaticControl(this, Strings.NetworkDevices, StringMatchSyntax.ExactMatch, "*", StringMatchSyntax.WildCard); ;
                }
                
                return this.cachedNetworkDevicesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[jnwoko] 10/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IComputerAndDeviceTypeControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, ComputerAndDeviceType.ControlIDs.HelpStaticControl);
                }
                
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WhatWouldYouLikeToManageStaticControl control
        /// </summary>
        /// <history>
        /// 	[jnwoko] 10/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IComputerAndDeviceTypeControls.WhatWouldYouLikeToManageStaticControl
        {
            get
            {
                if ((this.cachedWhatWouldYouLikeToManageStaticControl == null))
                {
                    this.cachedWhatWouldYouLikeToManageStaticControl = new StaticControl(this, ComputerAndDeviceType.ControlIDs.WhatWouldYouLikeToManageStaticControl);
                }
                
                return this.cachedWhatWouldYouLikeToManageStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[jnwoko] 10/7/2008 Created
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
        /// 	[jnwoko] 10/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNext()
        {
            this.Controls.NextButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Discover
        /// </summary>
        /// <history>
        /// 	[jnwoko] 10/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickDiscover()
        {
            this.Controls.DiscoverButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[jnwoko] 10/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Routine to Select Windows Computer as discovery type.
        /// </summary>
        /// <history>
        ///       [jnwoko] 06-OCT-08 Created
        /// </history>
        /// <remarks>
        /// TODO-112171: (May not Need this)
        /// </remarks>
        ///-------------------------------------------------------------------
        public virtual void ClickNavigationLink(string linkText)
        {
            // find the link control
            StaticControl navigationLink =
                new StaticControl(
                    this,
                    linkText,
                    StringMatchSyntax.ExactMatch,
                    "*",
                    StringMatchSyntax.WildCard);

            // click the link
            navigationLink.Click();
        }

        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">App owning the dialog.</param>
        /// <history>
        /// 	[jnwoko] 10/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(app.GetIntlStr(Strings.WindowTitle), StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
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
                        tempWindow = new Window(app.GetIntlStr(Strings.WindowTitle), StringMatchSyntax.WildCard);

                        // Wait for the window to become ready
                        UISynchronization.WaitForUIObjectReady(tempWindow, Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException )
                    {
                        // log the unsuccessful attempt

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
        /// Contains resource string definitions.
        /// </summary>
        /// <history>
        /// 	[jnwoko] 10/7/2008 Created
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
            /// Resource string for Discover
            /// </summary>
            /// <remarks>this control is was not contained in other proxy classes</remarks>
            /// -----------------------------------------------------------------------------
            private const string ResourceDiscover = ";&Discover;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Mic" +
                "rosoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;Discov" +
                "erActionText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseM" +
                "anagement.Mom.Internal.UI.PageFrameworks.WizardFramework;buttonCancel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AutoOrAdvanced
            /// </summary>
            /// <remarks>ResourceID of rthis item in WelcomeWindow.cs is incorrect, contain ".en".</remarks>
            /// -----------------------------------------------------------------------------
            private const string ResourceAutoOrAdvanced = ";Auto or Advanced?;ManagedString;Microsoft.EnterpriseManagement.UI.Administration" +
                ".dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResource" +
                "s;DiscoveryModeTitle";

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
            /// Contains resource string for:  SelectObjectsToManage
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectObjectsToManage = ";Select Objects to Manage;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";DiscoveryResultsTitle";

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
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseMan" +
                "agement.Mom.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";

            #region Strings Which need to be Obtained from MP
            /// <summary>
            /// Resource string for This enables you to discover Windows computers in your Active Directory environment and to install agents on the ones you want to manage.
            /// </summary>
            // TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            private const string ThisEnablesYouToDiscoverWindowsComputersInYourActiveDirectoryEnvironmentAndToInstallAgentsOnTheOnesY = "This enables you to discover Windows computers in your Active Directory environme" +
                "nt and to install agents on the ones you want to manage.";
   
            /// <summary>
            /// Resource string for Windows computers
            /// </summary>
            // TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            private const string ResourceWindowsComputers = "&Windows computers";

            /// <summary>
            /// Resource string for This enables you to specify an IP range to discover network devices and monitor them using SNMP.
            /// </summary>
            // TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            private const string ThisEnablesYouToSpecifyAnIPRangeToDiscoverNetworkDevicesAndMonitorThemUsingSNMP = "This enables you to specify an IP range to discover network devices and monitor t" +
                "hem using SNMP.";

            /// <summary>
            /// Resource string for Network devices
            /// </summary>        
            // TODO: DialogMaker could not find the resource 
            private const string ResourceNetworkDevices = ";NetworkDevices;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.NetworkDevices;>>$this.Name";
            #endregion
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Resource string for Select a discovery type and click Next to continue.
            /// </summary>
            /// <remarks>code needs to be added to Properties </remarks>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectADiscoveryTypeAndClickNextToContinue =
                ";Select a discovery type and click Next to continue.;ManagedString;" +
                 "Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                 "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.DiscoveryTypeSelectionPage;label2.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Resource string for What would you like to manage?
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWhatWouldYouLikeToManage =
                ";What would you like to manage?;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.DiscoveryTypeSelectionPage;$this.Title";


            /// -----------------------------------------------------------------------------   
            /// <summary>
            /// Resource string for Discovery Type
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDiscoveryType = ";Discovery Type;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dl" +
                "l;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.DiscoveryTypeSel" +
                "ectionPage;$this.NavigationText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Resource string for Discovery Method
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDiscoveryMethod =
                ";Discovery Method;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;DiscoveryMethodTitle";

                               
            
            /// <summary>
            /// Resource string for Choose the type of computers or devices to discover and manage.
            /// </summary>
            // Choose the type of computers or devices to discover and manage.
            private const string ResourceChooseTheTypeOfComputersOrDevicesToDiscoverAndManage =
                ";Choose the type of computers or devices to discover and manage.;" +
                "ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.DiscoveryTypeSelectionPage;label3.Text";                                                    

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
            /// Caches the translated resource string for:  Discover
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDiscover;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DiscoveryMethod
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDiscoveryMethod;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DiscoveryType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDiscoveryType;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AutoOrAdvanced
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAutoOrAdvanced;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AdministratorAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdministratorAccount;

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
            /// Caches the translated resource string for:  WindowsComputers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWindowsComputers;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  NetworkDevices
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNetworkDevices;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ChooseTheTypeOfComputersOrDevicesToDiscoverAndManage
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedChooseTheTypeOfComputersOrDevicesToDiscoverAndManage;
           
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WhatWouldYouLikeToManage
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWhatWouldYouLikeToManage;
            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WindowTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[jnwoko] 10/06/2008 Created
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
            /// 	[jnwoko] 10/06/2008 Created
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
            /// 	[jnwoko] 10/06/2008 Created
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
            /// 	[jnwoko] 10/06/2008 Created
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
            /// Exposes access to the Dicover translated resource string
            /// </summary>
            /// <history>
            /// 	[jnwoko] 10/06/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Discover
            {
                get
                {
                    if ((cachedDiscover == null))
                    {
                        cachedDiscover = CoreManager.MomConsole.GetIntlStr(ResourceDiscover);
                    }
                    return cachedDiscover;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[jnwoko] 10/06/2008 Created
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
            /// Exposes access to the AutoOrAdvanced translated resource string
            /// </summary>
            /// <history>
            /// 	[jnwoko] 10/06/2008 Created
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
            /// Exposes access to the AdministratorAccount translated resource string
            /// </summary>
            /// <history>
            /// 	[jnwoko] 10/06/2008 Created
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
            /// Exposes access to the WhatWouldYouLikeToManage translated resource string
            /// </summary>
            /// <history>
            /// 	[jnwoko] 10/06/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WhatWouldYouLikeToManage
            {
                get
                {
                    if ((cachedWhatWouldYouLikeToManage == null))
                    {
                        cachedWhatWouldYouLikeToManage = CoreManager.MomConsole.GetIntlStr(ResourceWhatWouldYouLikeToManage);
                    }
                    return cachedWhatWouldYouLikeToManage;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectObjectsToManage translated resource string
            /// </summary>
            /// <history>
            /// 	[jnwoko] 10/06/2008 Created
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
            /// 	[jnwoko] 10/06/2008 Created
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
            /// Exposes access to the ResourceWindowsComputer
            /// </summary>
            /// <history>
            /// 	[jnwoko] 10/06/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WindowsComputers
            {
                get
                {
                    if ((cachedWindowsComputers == null))
                    {
                        //retriving guid                         
                        cachedWindowsComputers = Core.Common.Utilities.GetWindowsComputersPageSet();
                    }
                    return cachedWindowsComputers;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NetworkDevices
            /// </summary>
            /// <history>
            /// 	[jnwoko] 10/06/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NetworkDevices
            {
                get
                {
                    if ((cachedNetworkDevices == null))
                    {
                        cachedNetworkDevices = Core.Common.Utilities.GetNetworkDevicesPageSet();
                    }
                    return cachedNetworkDevices;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ChooseTheTypeOfComputersOrDevicesToDiscoverAndManage translated resource string
            /// </summary>
            /// <history>
            /// 	[jnwoko] 10/06/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ChooseTheTypeOfComputersOrDevicesToDiscoverAndManage
            {
                get
                {
                    if ((cachedChooseTheTypeOfComputersOrDevicesToDiscoverAndManage == null))
                    {
                        cachedChooseTheTypeOfComputersOrDevicesToDiscoverAndManage = CoreManager.MomConsole.GetIntlStr(ResourceChooseTheTypeOfComputersOrDevicesToDiscoverAndManage);
                    }
                    return cachedChooseTheTypeOfComputersOrDevicesToDiscoverAndManage;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DiscoveryMethod translated resource string
            /// </summary>
            /// <history>
            /// 	[jnwoko] 10/06/2008 Created
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
            /// Exposes access to the DiscoveryType translated resource string
            /// </summary>
            /// <history>
            /// 	[jnwoko] 10/06/2008 Created
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
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[jnwoko] 10/06/2008 Created
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
            
            #endregion
        }
        #endregion
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[jnwoko] 10/7/2008 Created
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
            /// Control ID for DiscoverButton
            /// </summary>
            public const string DiscoverButton = "commitButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for DiscoveryTypeStaticControl
            /// </summary>
            public const string DiscoveryTypeStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for DiscoveryMethodStaticControl
            /// </summary>
            public const string DiscoveryMethodStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for SelectObjectsToManageStaticControl
            /// </summary>
            public const string SelectObjectsToManageStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for SummaryStaticControl
            /// </summary>
            public const string SummaryStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ChooseTheTypeOfComputersOrDevicesToDiscoverAndManageStaticControl
            /// </summary>
            public const string ChooseTheTypeOfComputersOrDevicesToDiscoverAndManageStaticControl = "label3";
            
            /// <summary>
            /// Control ID for SelectADiscoveryTypeAndClickNextToContinueStaticControl
            /// </summary>
            public const string SelectADiscoveryTypeAndClickNextToContinueStaticControl = "label2";
            
            /// <summary>
            /// Control ID for ThisEnablesYouToDiscoverWindowsComputersInYourActiveDirectoryEnvironmentAndToInstallAgentsOnTheOnesY
            /// </summary>
            public const string ThisEnablesYouToDiscoverWindowsComputersInYourActiveDirectoryEnvironmentAndToInstallAgentsOnTheOnesY = "labelDescription";
            
            /// <summary>
            /// Control ID for WindowsComputersStaticControl
            /// </summary>
            public const string WindowsComputersStaticControl = "labelTitle";
            
            /// <summary>
            /// Control ID for ThisEnablesYouToSpecifyAnIPRangeToDiscoverNetworkDevicesAndMonitorThemUsingSNMPStaticControl
            /// </summary>
            public const string ThisEnablesYouToSpecifyAnIPRangeToDiscoverNetworkDevicesAndMonitorThemUsingSNMPStaticControl = "labelDescription";
            
            /// <summary>
            /// Control ID for NetworkDevicesStaticControl
            /// </summary>
            public const string NetworkDevicesStaticControl = "labelTitle";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for WhatWouldYouLikeToManageStaticControl
            /// </summary>
            public const string WhatWouldYouLikeToManageStaticControl = "headerLabel";
        }
        #endregion
    }
}
