// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="IpAddressRangeWindow.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
//  MOMv3
// </project>
// <summary>
// 	MOMv3 UI Automation
// </summary>
// <history>
// 	[KellyMor] 05-Apr-06    Created
//  [KellyMor] 12-Apr-06    Updated control ID's and AA treewalk for StartTextBox
//  [KellyMor] 07-Jun-06    Updated resource assembly for new Admin assembly
//  [KellyMor] 03-Oct-06    Added a control ID for the community string text box that will
//                          replace the combobox control
//  [KellyMor] 30-May-07    Modified AA treewalk for StartTextBox for change to SNMP changes
//                          Added updated control ID's for IP Address controls
//  [a-joelj]   22DEC09     Added resource string for localized "Error" dialog if IP range issue occurs
//                          to fix SM bug# 162962 
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IIpAddressRangeWindowControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IIpAddressRangeWindowControls, for IpAddressRangeWindow.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 4/5/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IIpAddressRangeWindowControls
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
        /// Read-only property to access CommunityStringStaticControl
        /// </summary>
        StaticControl CommunityStringStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CommunityStringEditComboBox
        /// </summary>
        EditComboBox CommunityStringEditComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CommunityStringTextBox
        /// </summary>
        TextBox CommunityStringTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ThePasswordUsedToDiscoverNetworkDevicesIsCalledACommunityStringPleaseSpecifyYourNetworkDeviceCommuni
        /// </summary>
        StaticControl ThePasswordUsedToDiscoverNetworkDevicesIsCalledACommunityStringPleaseSpecifyYourNetworkDeviceCommuni
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SimpleNetworkManagementProtocolSNMPCommunityStringsStaticControl
        /// </summary>
        StaticControl SimpleNetworkManagementProtocolSNMPCommunityStringsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EndStaticControl
        /// </summary>
        StaticControl EndStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StartStaticControl
        /// </summary>
        StaticControl StartStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EndTextBox
        /// </summary>
        TextBox EndTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EndTextBox2
        /// </summary>
        TextBox EndTextBox2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TextBox4
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TextBox TextBox4
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TextBox5
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TextBox TextBox5
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SummaryTextBox
        /// </summary>
        TextBox SummaryTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StartTextBox
        /// </summary>
        TextBox StartTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TextBox6
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TextBox TextBox6
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TextBox7
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TextBox TextBox7
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SpecifyAStartingAndEndingAddressesStaticControl
        /// </summary>
        StaticControl SpecifyAStartingAndEndingAddressesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SpecifyNetworkAddressesStaticControl
        /// </summary>
        StaticControl SpecifyNetworkAddressesStaticControl
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
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the functionality of the IP Address Range window.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 4/5/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class IpAddressRangeWindow : Window, IIpAddressRangeWindowControls
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
        /// Cache to hold a reference to DiscoverButton of type Button
        /// </summary>
        private Button cachedDiscoverButton;
        
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
        /// Cache to hold a reference to SelectObjectsToManageStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectObjectsToManageStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SummaryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSummaryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CommunityStringStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCommunityStringStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CommunityStringEditComboBox of type EditComboBox
        /// </summary>
        private EditComboBox cachedCommunityStringEditComboBox;
        
        /// <summary>
        /// Cache to hold a reference to CommunityStringTextBox of type TextBox
        /// </summary>
        private TextBox cachedCommunityStringTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ThePasswordUsedToDiscoverNetworkDevicesIsCalledACommunityStringPleaseSpecifyYourNetworkDeviceCommuni of type StaticControl
        /// </summary>
        private StaticControl cachedThePasswordUsedToDiscoverNetworkDevicesIsCalledACommunityStringPleaseSpecifyYourNetworkDeviceCommuni;
        
        /// <summary>
        /// Cache to hold a reference to SimpleNetworkManagementProtocolSNMPCommunityStringsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSimpleNetworkManagementProtocolSNMPCommunityStringsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to EndStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEndStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to StartStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedStartStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to EndTextBox of type TextBox
        /// </summary>
        private TextBox cachedEndTextBox;
        
        /// <summary>
        /// Cache to hold a reference to EndTextBox2 of type TextBox
        /// </summary>
        private TextBox cachedEndTextBox2;
        
        /// <summary>
        /// Cache to hold a reference to TextBox4 of type TextBox
        /// </summary>
        private TextBox cachedTextBox4;
        
        /// <summary>
        /// Cache to hold a reference to TextBox5 of type TextBox
        /// </summary>
        private TextBox cachedTextBox5;
        
        /// <summary>
        /// Cache to hold a reference to SummaryTextBox of type TextBox
        /// </summary>
        private TextBox cachedSummaryTextBox;
        
        /// <summary>
        /// Cache to hold a reference to StartTextBox of type TextBox
        /// </summary>
        private TextBox cachedStartTextBox;
        
        /// <summary>
        /// Cache to hold a reference to TextBox6 of type TextBox
        /// </summary>
        private TextBox cachedTextBox6;
        
        /// <summary>
        /// Cache to hold a reference to TextBox7 of type TextBox
        /// </summary>
        private TextBox cachedTextBox7;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyAStartingAndEndingAddressesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyAStartingAndEndingAddressesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyNetworkAddressesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyNetworkAddressesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DiscoveryMethodStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedDiscoveryMethodStaticControl2;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='ownerWindow'>
        /// Owner of IpAddressRangeWindow of type App
        /// </param>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public IpAddressRangeWindow(App ownerWindow) : 
                base(Init(ownerWindow))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IIpAddressRangeWindow Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the window's control properties together</value>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IIpAddressRangeWindowControls Controls
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
        ///  Routine to set/get the text in control CommunityString
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string CommunityStringText
        {
            get
            {
                return this.Controls.CommunityStringTextBox.Text;
            }
            
            set
            {
                this.Controls.CommunityStringTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control CommunityString2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string CommunityString2Text
        {
            get
            {
                return this.Controls.CommunityStringTextBox.Text;
            }
            
            set
            {
                this.Controls.CommunityStringTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control End
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string EndText
        {
            get
            {
                return this.Controls.EndTextBox.Text;
            }
            
            set
            {
                this.Controls.EndTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control End2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string End2Text
        {
            get
            {
                return this.Controls.EndTextBox2.Text;
            }
            
            set
            {
                this.Controls.EndTextBox2.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TextBox4
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TextBox4Text
        {
            get
            {
                return this.Controls.TextBox4.Text;
            }
            
            set
            {
                this.Controls.TextBox4.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TextBox5
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TextBox5Text
        {
            get
            {
                return this.Controls.TextBox5.Text;
            }
            
            set
            {
                this.Controls.TextBox5.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Summary
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SummaryText
        {
            get
            {
                return this.Controls.SummaryTextBox.Text;
            }
            
            set
            {
                this.Controls.SummaryTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Start
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string StartText
        {
            get
            {
                return this.Controls.StartTextBox.Text;
            }
            
            set
            {
                this.Controls.StartTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TextBox6
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TextBox6Text
        {
            get
            {
                return this.Controls.TextBox6.Text;
            }
            
            set
            {
                this.Controls.TextBox6.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TextBox7
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TextBox7Text
        {
            get
            {
                return this.Controls.TextBox7.Text;
            }
            
            set
            {
                this.Controls.TextBox7.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IIpAddressRangeWindowControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, IpAddressRangeWindow.ControlIDs.PreviousButton);
                }
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IIpAddressRangeWindowControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, IpAddressRangeWindow.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DiscoverButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IIpAddressRangeWindowControls.DiscoverButton
        {
            get
            {
                if ((this.cachedDiscoverButton == null))
                {
                    this.cachedDiscoverButton = new Button(this, IpAddressRangeWindow.ControlIDs.DiscoverButton);
                }
                return this.cachedDiscoverButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IIpAddressRangeWindowControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, IpAddressRangeWindow.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IntroductionStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IIpAddressRangeWindowControls.IntroductionStaticControl
        {
            get
            {
                if ((this.cachedIntroductionStaticControl == null))
                {
                    this.cachedIntroductionStaticControl = new StaticControl(this, IpAddressRangeWindow.ControlIDs.IntroductionStaticControl);
                }
                return this.cachedIntroductionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AutoOrAdvancedStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IIpAddressRangeWindowControls.AutoOrAdvancedStaticControl
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
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IIpAddressRangeWindowControls.DiscoveryMethodStaticControl
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
        ///  Exposes access to the SelectObjectsToManageStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IIpAddressRangeWindowControls.SelectObjectsToManageStaticControl
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
                    for (i = 0; (i <= 2); i = (i + 1))
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
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IIpAddressRangeWindowControls.SummaryStaticControl
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
                    for (i = 0; (i <= 3); i = (i + 1))
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
        ///  Exposes access to the CommunityStringStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IIpAddressRangeWindowControls.CommunityStringStaticControl
        {
            get
            {
                if ((this.cachedCommunityStringStaticControl == null))
                {
                    this.cachedCommunityStringStaticControl = new StaticControl(this, IpAddressRangeWindow.ControlIDs.CommunityStringStaticControl);
                }
                return this.cachedCommunityStringStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CommunityStringEditComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IIpAddressRangeWindowControls.CommunityStringEditComboBox
        {
            get
            {
                if ((this.cachedCommunityStringEditComboBox == null))
                {
                    this.cachedCommunityStringEditComboBox = new EditComboBox(this, IpAddressRangeWindow.ControlIDs.CommunityStringEditComboBox);
                }
                return this.cachedCommunityStringEditComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CommunityStringTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IIpAddressRangeWindowControls.CommunityStringTextBox
        {
            get
            {
                if ((this.cachedCommunityStringTextBox == null))
                {
                    this.cachedCommunityStringTextBox = new TextBox(this, IpAddressRangeWindow.ControlIDs.CommunityStringTextBox);
                }
                return this.cachedCommunityStringTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ThePasswordUsedToDiscoverNetworkDevicesIsCalledACommunityStringPleaseSpecifyYourNetworkDeviceCommuni control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IIpAddressRangeWindowControls.ThePasswordUsedToDiscoverNetworkDevicesIsCalledACommunityStringPleaseSpecifyYourNetworkDeviceCommuni
        {
            get
            {
                if ((this.cachedThePasswordUsedToDiscoverNetworkDevicesIsCalledACommunityStringPleaseSpecifyYourNetworkDeviceCommuni == null))
                {
                    this.cachedThePasswordUsedToDiscoverNetworkDevicesIsCalledACommunityStringPleaseSpecifyYourNetworkDeviceCommuni = new StaticControl(this, IpAddressRangeWindow.ControlIDs.ThePasswordUsedToDiscoverNetworkDevicesIsCalledACommunityStringPleaseSpecifyYourNetworkDeviceCommuni);
                }
                return this.cachedThePasswordUsedToDiscoverNetworkDevicesIsCalledACommunityStringPleaseSpecifyYourNetworkDeviceCommuni;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SimpleNetworkManagementProtocolSNMPCommunityStringsStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IIpAddressRangeWindowControls.SimpleNetworkManagementProtocolSNMPCommunityStringsStaticControl
        {
            get
            {
                if ((this.cachedSimpleNetworkManagementProtocolSNMPCommunityStringsStaticControl == null))
                {
                    this.cachedSimpleNetworkManagementProtocolSNMPCommunityStringsStaticControl = new StaticControl(this, IpAddressRangeWindow.ControlIDs.SimpleNetworkManagementProtocolSNMPCommunityStringsStaticControl);
                }
                return this.cachedSimpleNetworkManagementProtocolSNMPCommunityStringsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EndStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IIpAddressRangeWindowControls.EndStaticControl
        {
            get
            {
                if ((this.cachedEndStaticControl == null))
                {
                    this.cachedEndStaticControl = new StaticControl(this, IpAddressRangeWindow.ControlIDs.EndStaticControl);
                }
                return this.cachedEndStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StartStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IIpAddressRangeWindowControls.StartStaticControl
        {
            get
            {
                if ((this.cachedStartStaticControl == null))
                {
                    this.cachedStartStaticControl = new StaticControl(this, IpAddressRangeWindow.ControlIDs.StartStaticControl);
                }
                return this.cachedStartStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EndTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IIpAddressRangeWindowControls.EndTextBox
        {
            get
            {
                if ((this.cachedEndTextBox == null))
                {
                    this.cachedEndTextBox = new TextBox(this, IpAddressRangeWindow.ControlIDs.EndTextBox);
                }
                return this.cachedEndTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EndTextBox2 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IIpAddressRangeWindowControls.EndTextBox2
        {
            get
            {
                if ((this.cachedEndTextBox2 == null))
                {
                    this.cachedEndTextBox2 = new TextBox(this, IpAddressRangeWindow.ControlIDs.EndTextBox2);
                }
                return this.cachedEndTextBox2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TextBox4 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IIpAddressRangeWindowControls.TextBox4
        {
            get
            {
                if ((this.cachedTextBox4 == null))
                {
                    this.cachedTextBox4 = new TextBox(this, IpAddressRangeWindow.ControlIDs.TextBox4);
                }
                return this.cachedTextBox4;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TextBox5 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IIpAddressRangeWindowControls.TextBox5
        {
            get
            {
                if ((this.cachedTextBox5 == null))
                {
                    this.cachedTextBox5 = new TextBox(this, IpAddressRangeWindow.ControlIDs.TextBox5);
                }
                return this.cachedTextBox5;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SummaryTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IIpAddressRangeWindowControls.SummaryTextBox
        {
            get
            {
                // The ID for this control (IPAddressField0) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedSummaryTextBox == null))
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
                    for (i = 0; (i <= 7); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedSummaryTextBox = new TextBox(wndTemp);
                }
                return this.cachedSummaryTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StartTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IIpAddressRangeWindowControls.StartTextBox
        {
            get
            {
                // The ID for this control (IPAddressField0) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedStartTextBox == null))
                {
                    // get the top-level window for the control
                    Maui.Core.WinControls.Control startAddressControl = 
                        new Maui.Core.WinControls.Control(
                            this, 
                            ControlIDs.IPAddressControlStart);

                    // get the window for this control
                    Window wndTemp = 
                        startAddressControl.Extended.AccessibleObject.Window;

                    // create the text box control
                    this.cachedStartTextBox = new TextBox(wndTemp, ControlIDs.StartTextBox);
                }
                return this.cachedStartTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TextBox6 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IIpAddressRangeWindowControls.TextBox6
        {
            get
            {
                // The ID for this control (IPAddressField2) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedTextBox6 == null))
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
                    for (i = 0; (i <= 7); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    this.cachedTextBox6 = new TextBox(wndTemp);
                }
                return this.cachedTextBox6;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TextBox7 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IIpAddressRangeWindowControls.TextBox7
        {
            get
            {
                // The ID for this control (IPAddressField3) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedTextBox7 == null))
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
                    for (i = 0; (i <= 7); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    this.cachedTextBox7 = new TextBox(wndTemp);
                }
                return this.cachedTextBox7;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyAStartingAndEndingAddressesStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IIpAddressRangeWindowControls.SpecifyAStartingAndEndingAddressesStaticControl
        {
            get
            {
                if ((this.cachedSpecifyAStartingAndEndingAddressesStaticControl == null))
                {
                    this.cachedSpecifyAStartingAndEndingAddressesStaticControl = new StaticControl(this, IpAddressRangeWindow.ControlIDs.SpecifyAStartingAndEndingAddressesStaticControl);
                }
                return this.cachedSpecifyAStartingAndEndingAddressesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyNetworkAddressesStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IIpAddressRangeWindowControls.SpecifyNetworkAddressesStaticControl
        {
            get
            {
                if ((this.cachedSpecifyNetworkAddressesStaticControl == null))
                {
                    this.cachedSpecifyNetworkAddressesStaticControl = new StaticControl(this, IpAddressRangeWindow.ControlIDs.SpecifyNetworkAddressesStaticControl);
                }
                return this.cachedSpecifyNetworkAddressesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IIpAddressRangeWindowControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, IpAddressRangeWindow.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DiscoveryMethodStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IIpAddressRangeWindowControls.DiscoveryMethodStaticControl2
        {
            get
            {
                if ((this.cachedDiscoveryMethodStaticControl2 == null))
                {
                    this.cachedDiscoveryMethodStaticControl2 = new StaticControl(this, IpAddressRangeWindow.ControlIDs.DiscoveryMethodStaticControl2);
                }
                return this.cachedDiscoveryMethodStaticControl2;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
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
        /// 	[KellyMor] 4/5/2006 Created
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
        /// 	[KellyMor] 4/5/2006 Created
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
        /// 	[KellyMor] 4/5/2006 Created
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
        ///  <param name="ownerWindow">App class instance that owns this window.</param>)
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
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
        /// Strin definitions.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
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
            private const string ResourcePrevious = ";< &Previous;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.PageFramework.WizardButtonsPanel;previousButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext = ";&Next >;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement" +
                ".Mom.Internal.UI.PageFrameworks.WizardFramework;buttonNext.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Discover
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDiscover = ";&Discover;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseMana" +
                "gement.Mom.Internal.UI.Administration.AdminResources;DiscoverActionText";
            
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
            private const string ResourceIntroduction = ";Introduction;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseM" +
                "anagement.Mom.Internal.UI.Administration.AdminResources;WelcomeTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AutoOrAdvanced
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAutoOrAdvanced = ";Auto or Advanced?;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.Enterp" +
                "riseManagement.Mom.Internal.UI.Administration.AdminResources;DiscoveryModeTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DiscoveryMethod
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDiscoveryMethod = ";Discovery Method;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.Enterpr" +
                "iseManagement.Mom.Internal.UI.Administration.AdminResources;DiscoveryMethodTitle" +
                "";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectObjectsToManage
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectObjectsToManage = ";Select Objects to Manage;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft" +
                ".EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;DiscoveryRes" +
                "ultsTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Summary
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSummary = ";Summary;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.Administration.AdminResources;SummaryTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CommunityString
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCommunityString = ";Community &string:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.Enter" +
                "priseManagement.Mom.Internal.UI.Administration.NetworkDevices;labelReadOnly.Text" +
                "";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ThePasswordUsedToDiscoverNetworkDevicesIsCalledACommunityStringPleaseSpecifyYourNetworkDeviceCommuni
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceThePasswordUsedToDiscoverNetworkDevicesIsCalledACommunityStringPleaseSpecifyYourNetworkDeviceCommuni = @";The password used to discover network devices is called a ""community string"". Please specify your network device community string.;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.NetworkDevices;labelDescription.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SimpleNetworkManagementProtocolSNMPCommunityStrings
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSimpleNetworkManagementProtocolSNMPCommunityStrings = ";Simple Network Management Protocol (SNMP) Community Strings;ManagedString;" +
                "Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Adminis" +
                "tration.NetworkDevices;label1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  End
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEnd = ";E&nd:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManageme" +
                "nt.Mom.Internal.UI.Administration.NetworkDevices;labelRangeEnd.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Start
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceStart = ";&Start:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.Administration.NetworkDevices;labelStart.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpecifyAStartingAndEndingAddresses
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecifyAStartingAndEndingAddresses = ";Specify a starting and ending addresses;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.NetworkDevic" +
                "es;labelRange.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpecifyNetworkAddresses
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecifyNetworkAddresses = ";Specify Network Addresses;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsof" +
                "t.EnterpriseManagement.Mom.Internal.UI.Administration.NetworkDevices;labelTitle." +
                "Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mo" +
                "m.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DiscoveryMethod2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDiscoveryMethod2 = ";Discovery Method;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.Enterpr" +
                "iseManagement.Mom.Internal.UI.Administration.AdminResources;DiscoveryMethodTitle" +
                "";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Error
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceError = ";Error;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.IPAddress.IPAddressResources;Caption";
            
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
            /// Caches the translated resource string for:  CommunityString
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCommunityString;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ThePasswordUsedToDiscoverNetworkDevicesIsCalledACommunityStringPleaseSpecifyYourNetworkDeviceCommuni
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedThePasswordUsedToDiscoverNetworkDevicesIsCalledACommunityStringPleaseSpecifyYourNetworkDeviceCommuni;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SimpleNetworkManagementProtocolSNMPCommunityStrings
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSimpleNetworkManagementProtocolSNMPCommunityStrings;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  End
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEnd;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Start
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedStart;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpecifyAStartingAndEndingAddresses
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpecifyAStartingAndEndingAddresses;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpecifyNetworkAddresses
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpecifyNetworkAddresses;
            
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
            /// Caches the translated resource string for:  Error
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedError;

            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WindowTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
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
            /// 	[KellyMor] 4/5/2006 Created
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
            /// 	[KellyMor] 4/5/2006 Created
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
            /// Exposes access to the Discover translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
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
            /// 	[KellyMor] 4/5/2006 Created
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
            /// 	[KellyMor] 4/5/2006 Created
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
            /// 	[KellyMor] 4/5/2006 Created
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
            /// 	[KellyMor] 4/5/2006 Created
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
            /// Exposes access to the SelectObjectsToManage translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
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
            /// 	[KellyMor] 4/5/2006 Created
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
            /// Exposes access to the CommunityString translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CommunityString
            {
                get
                {
                    if ((cachedCommunityString == null))
                    {
                        cachedCommunityString = CoreManager.MomConsole.GetIntlStr(ResourceCommunityString);
                    }
                    return cachedCommunityString;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ThePasswordUsedToDiscoverNetworkDevicesIsCalledACommunityStringPleaseSpecifyYourNetworkDeviceCommuni translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ThePasswordUsedToDiscoverNetworkDevicesIsCalledACommunityStringPleaseSpecifyYourNetworkDeviceCommuni
            {
                get
                {
                    if ((cachedThePasswordUsedToDiscoverNetworkDevicesIsCalledACommunityStringPleaseSpecifyYourNetworkDeviceCommuni == null))
                    {
                        cachedThePasswordUsedToDiscoverNetworkDevicesIsCalledACommunityStringPleaseSpecifyYourNetworkDeviceCommuni = CoreManager.MomConsole.GetIntlStr(ResourceThePasswordUsedToDiscoverNetworkDevicesIsCalledACommunityStringPleaseSpecifyYourNetworkDeviceCommuni);
                    }
                    return cachedThePasswordUsedToDiscoverNetworkDevicesIsCalledACommunityStringPleaseSpecifyYourNetworkDeviceCommuni;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SimpleNetworkManagementProtocolSNMPCommunityStrings translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SimpleNetworkManagementProtocolSNMPCommunityStrings
            {
                get
                {
                    if ((cachedSimpleNetworkManagementProtocolSNMPCommunityStrings == null))
                    {
                        cachedSimpleNetworkManagementProtocolSNMPCommunityStrings = CoreManager.MomConsole.GetIntlStr(ResourceSimpleNetworkManagementProtocolSNMPCommunityStrings);
                    }
                    return cachedSimpleNetworkManagementProtocolSNMPCommunityStrings;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the End translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string End
            {
                get
                {
                    if ((cachedEnd == null))
                    {
                        cachedEnd = CoreManager.MomConsole.GetIntlStr(ResourceEnd);
                    }
                    return cachedEnd;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Start translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Start
            {
                get
                {
                    if ((cachedStart == null))
                    {
                        cachedStart = CoreManager.MomConsole.GetIntlStr(ResourceStart);
                    }
                    return cachedStart;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SpecifyAStartingAndEndingAddresses translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpecifyAStartingAndEndingAddresses
            {
                get
                {
                    if ((cachedSpecifyAStartingAndEndingAddresses == null))
                    {
                        cachedSpecifyAStartingAndEndingAddresses = CoreManager.MomConsole.GetIntlStr(ResourceSpecifyAStartingAndEndingAddresses);
                    }
                    return cachedSpecifyAStartingAndEndingAddresses;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SpecifyNetworkAddresses translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpecifyNetworkAddresses
            {
                get
                {
                    if ((cachedSpecifyNetworkAddresses == null))
                    {
                        cachedSpecifyNetworkAddresses = CoreManager.MomConsole.GetIntlStr(ResourceSpecifyNetworkAddresses);
                    }
                    return cachedSpecifyNetworkAddresses;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
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
            /// 	[KellyMor] 4/5/2006 Created
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
            /// Exposes access to the Error translated resource string
            /// </summary>
            /// <history>
            ///     [a-joelj] 22DEC09   Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Error
            {
                get
                {
                    if ((cachedError == null))
                    {
                        cachedError = CoreManager.MomConsole.GetIntlStr(ResourceError);
                    }
                    return cachedError;
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
        /// 	[KellyMor] 4/5/2006 Created
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
            /// Control ID for SelectObjectsToManageStaticControl
            /// </summary>
            public const string SelectObjectsToManageStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for SummaryStaticControl
            /// </summary>
            public const string SummaryStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for CommunityStringStaticControl
            /// </summary>
            public const string CommunityStringStaticControl = "labelReadOnly";
            
            /// <summary>
            /// Control ID for CommunityStringEditComboBox
            /// </summary>
            public const string CommunityStringEditComboBox = "comboBoxReadOnly";

            /// <summary>
            /// Control ID for CommunityStringTextBox
            /// </summary>
            public const string CommunityStringTextBox = "textBoxCommunityString";

            /// <summary>
            /// Control ID for ThePasswordUsedToDiscoverNetworkDevicesIsCalledACommunityStringPleaseSpecifyYourNetworkDeviceCommuni
            /// </summary>
            public const string ThePasswordUsedToDiscoverNetworkDevicesIsCalledACommunityStringPleaseSpecifyYourNetworkDeviceCommuni = "labelDescription";
            
            /// <summary>
            /// Control ID for SimpleNetworkManagementProtocolSNMPCommunityStringsStaticControl
            /// </summary>
            public const string SimpleNetworkManagementProtocolSNMPCommunityStringsStaticControl = "label1";
            
            /// <summary>
            /// Control ID for EndStaticControl
            /// </summary>
            public const string EndStaticControl = "labelRangeEnd";
            
            /// <summary>
            /// Control ID for StartStaticControl
            /// </summary>
            public const string StartStaticControl = "labelStart";
            
            /// <summary>
            /// Control ID for EndTextBox
            /// </summary>
            public const string EndTextBox = "IPAddressField0";
            
            /// <summary>
            /// Control ID for EndTextBox2
            /// </summary>
            public const string EndTextBox2 = "IPAddressField1";
            
            /// <summary>
            /// Control ID for TextBox4
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string TextBox4 = "IPAddressField2";
            
            /// <summary>
            /// Control ID for TextBox5
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string TextBox5 = "IPAddressField3";
            
            /// <summary>
            /// Control ID for SummaryTextBox
            /// </summary>
            public const string StartTextBox = "IPAddressField0";
            
            /// <summary>
            /// Control ID for StartTextBox
            /// </summary>
            public const string SummaryTextBox = "IPAddressField1";
            
            /// <summary>
            /// Control ID for TextBox6
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string TextBox6 = "IPAddressField2";
            
            /// <summary>
            /// Control ID for TextBox7
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string TextBox7 = "IPAddressField3";
            
            /// <summary>
            /// Control ID for SpecifyAStartingAndEndingAddressesStaticControl
            /// </summary>
            public const string SpecifyAStartingAndEndingAddressesStaticControl = "labelRange";
            
            /// <summary>
            /// Control ID for SpecifyNetworkAddressesStaticControl
            /// </summary>
            public const string SpecifyNetworkAddressesStaticControl = "labelTitle";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for DiscoveryMethodStaticControl2
            /// </summary>
            public const string DiscoveryMethodStaticControl2 = "headerLabel";

            /// <summary>
            /// Control ID for IPAddressControlStart
            /// </summary>
            public const string IPAddressControlStart = "ipAddressControlStart";

            /// <summary>
            /// Control ID for IPAddressControlEnd
            /// </summary>
            public const string IPAddressControlEnd = "ipAddressControlEnd";
        }
        #endregion
    }
}
