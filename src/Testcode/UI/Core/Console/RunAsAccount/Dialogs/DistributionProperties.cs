// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="DistributionProperties.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[sharatja] 8/7/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.RunAsAccount
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    
    #region Radio Group Enumeration - Tab2

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group Tab2
    /// </summary>
    /// <history>
    /// 	[sharatja] 8/7/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum Tab2
    {
        /// <summary>
        /// LowSecurityText = 0
        /// </summary>
        DistributeCredentialsToAllComputersLowSecurity = 0,
        
        /// <summary>
        /// HighSecurityText = 1
        /// </summary>
        DistributeCredentialsToSelectedComputersHighSecurity = 1,
    }
    #endregion
    
    #region Interface Definition - IDistributionPropertiesControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IDistributionPropertiesControls, for DistributionProperties.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[sharatja] 8/7/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IDistributionPropertiesControls
    {
        /// <summary>
        /// Read-only property to access ApplyButton
        /// </summary>
        Button ApplyButton
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
        /// Read-only property to access OKButton
        /// </summary>
        Button OKButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Tab2TabControl
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TabControl Tab2TabControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WhereIsThisCredentialUsedStaticControl
        /// </summary>
        StaticControl WhereIsThisCredentialUsedStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectedComputersListView
        /// </summary>
        ListView SelectedComputersListView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectedComputersStaticControl
        /// </summary>
        StaticControl SelectedComputersStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ToolStrip1
        /// </summary>
        Toolbar ToolStrip1
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LowSecurityRadioButton
        /// </summary>
        RadioButton LowSecurityRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HighSecurityRadioButton
        /// </summary>
        RadioButton HighSecurityRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DistributionStaticControl
        /// </summary>
        StaticControl DistributionStaticControl
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
    /// 	[sharatja] 8/7/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class DistributionProperties : Dialog, IDistributionPropertiesControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ApplyButton of type Button
        /// </summary>
        private Button cachedApplyButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to Tab2TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab2TabControl;
        
        /// <summary>
        /// Cache to hold a reference to WhereIsThisCredentialUsedStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWhereIsThisCredentialUsedStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectedComputersListView of type ListView
        /// </summary>
        private ListView cachedSelectedComputersListView;
        
        /// <summary>
        /// Cache to hold a reference to SelectedComputersStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectedComputersStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ToolStrip1 of type Toolbar
        /// </summary>
        private Toolbar cachedToolStrip1;
        
        /// <summary>
        /// Cache to hold a reference to LowSecurityRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedLowSecurityRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to HighSecurityRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedHighSecurityRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to DistributionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDistributionStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of DistributionProperties of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public DistributionProperties(ConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group Tab2
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual Tab2 Tab2
        {
            get
            {
                if ((this.Controls.LowSecurityRadioButton.ButtonState == ButtonState.Checked))
                {
                    return Tab2.DistributeCredentialsToAllComputersLowSecurity;
                }
                
                if ((this.Controls.HighSecurityRadioButton.ButtonState == ButtonState.Checked))
                {
                    return Tab2.DistributeCredentialsToSelectedComputersHighSecurity;
                }
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == Tab2.DistributeCredentialsToAllComputersLowSecurity))
                {
                    this.Controls.LowSecurityRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == Tab2.DistributeCredentialsToSelectedComputersHighSecurity))
                    {
                        this.Controls.HighSecurityRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region IDistributionProperties Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IDistributionPropertiesControls Controls
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
        ///  Exposes access to the ApplyButton control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDistributionPropertiesControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, DistributionProperties.ControlIDs.ApplyButton);
                }
                return this.cachedApplyButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDistributionPropertiesControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, DistributionProperties.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDistributionPropertiesControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, DistributionProperties.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab2TabControl control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IDistributionPropertiesControls.Tab2TabControl
        {
            get
            {
                if ((this.cachedTab2TabControl == null))
                {
                    this.cachedTab2TabControl = new TabControl(this, DistributionProperties.ControlIDs.Tab2TabControl);
                }
                return this.cachedTab2TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WhereIsThisCredentialUsedStaticControl control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDistributionPropertiesControls.WhereIsThisCredentialUsedStaticControl
        {
            get
            {
                if ((this.cachedWhereIsThisCredentialUsedStaticControl == null))
                {
                    this.cachedWhereIsThisCredentialUsedStaticControl = new StaticControl(this, DistributionProperties.ControlIDs.WhereIsThisCredentialUsedStaticControl);
                }
                return this.cachedWhereIsThisCredentialUsedStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectedComputersListView control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IDistributionPropertiesControls.SelectedComputersListView
        {
            get
            {
                if ((this.cachedSelectedComputersListView == null))
                {
                    this.cachedSelectedComputersListView = new ListView(this, DistributionProperties.ControlIDs.SelectedComputersListView);
                }
                return this.cachedSelectedComputersListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectedComputersStaticControl control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDistributionPropertiesControls.SelectedComputersStaticControl
        {
            get
            {
                if ((this.cachedSelectedComputersStaticControl == null))
                {
                    this.cachedSelectedComputersStaticControl = new StaticControl(this, DistributionProperties.ControlIDs.SelectedComputersStaticControl);
                }
                return this.cachedSelectedComputersStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToolStrip1 control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IDistributionPropertiesControls.ToolStrip1
        {
            get
            {
                if ((this.cachedToolStrip1 == null))
                {
                    this.cachedToolStrip1 = new Toolbar(this);//, DistributionProperties.ControlIDs.ToolStrip1);
                }
                return this.cachedToolStrip1;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LowSecurityRadioButton control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IDistributionPropertiesControls.LowSecurityRadioButton
        {
            get
            {
                if ((this.cachedLowSecurityRadioButton == null))
                {
                    this.cachedLowSecurityRadioButton = new RadioButton(this, DistributionProperties.ControlIDs.LowSecurityRadioButton);
                }
                return this.cachedLowSecurityRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HighSecurityRadioButton control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IDistributionPropertiesControls.HighSecurityRadioButton
        {
            get
            {
                if ((this.cachedHighSecurityRadioButton == null))
                {
                    this.cachedHighSecurityRadioButton = new RadioButton(this, DistributionProperties.ControlIDs.HighSecurityRadioButton);
                }
                return this.cachedHighSecurityRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DistributionStaticControl control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDistributionPropertiesControls.DistributionStaticControl
        {
            get
            {
                if ((this.cachedDistributionStaticControl == null))
                {
                    this.cachedDistributionStaticControl = new StaticControl(this, DistributionProperties.ControlIDs.DistributionStaticControl);
                }
                return this.cachedDistributionStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Apply
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickApply()
        {
            this.Controls.ApplyButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">ConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                tempWindow = new Window(Strings.DialogTitle
                    + "*",
                    StringMatchSyntax.WildCard);
            }
            catch (Exceptions.WindowNotFoundException ex)
            {
                // locate the dialog
                tempWindow = null;
                int numberOfTries = 0;
                const int MAXTRIES = 7;
                Core.Common.Utilities.LogMessage("Looking for window with title:  '"
                    + Strings.DialogTitle + "'");

                while (tempWindow == null && numberOfTries < MAXTRIES)
                {
                    // log the attempt
                    numberOfTries++;

                    try
                    {
                        // look for the dialogue again using wildcard matching
                        tempWindow = new Window(
                            Strings.DialogTitle + "*",
                            StringMatchSyntax.WildCard);
                        // If the window is not found then this wait is never called
                        // Hence added the sleep call in catch block
                        // Wait for the window to report that is ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Window.Exceptions.WindowNotFoundException)
                    {
                        //sleep to wait for window search
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);

                        // log the outcome of this attempt
                        Core.Common.Utilities.LogMessage("Attempt "
                            + numberOfTries
                            + " of "
                            + MAXTRIES
                            + "...");
                    }
                }
                // check for success
                if (tempWindow == null)
                {
                    throw new Window.Exceptions.WindowNotFoundException(
                        "Init function could not find or bring up the window"
                        + "with a title of '" + Strings.DialogTitle
                        + "'.\n\n" + ex.Message);
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
        /// 	[sharatja] 8/7/2008 Created
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
            private const string ResourceDialogTitle = ";Run As Account Properties -;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;RunAsAccountPropertiesCaption";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Apply
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceApply = ";&Apply;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.PropertyDialogForm;buttonApply.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.Tr" +
                "anslucentColorPicker;buttonOk.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Tab2
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTab2 = "Tab2";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WhereIsThisCredentialUsed
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWhereIsThisCredentialUsed = ";Where is this credential used?;ManagedString;Microsoft.EnterpriseManagement.UI.A" +
                "dministration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration." +
                "RunAsAccount.RunAsAccountDistributionsPage;whereUsedLink.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectedComputers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectedComputers = ";Selected computers:;ManagedString;Microsoft.EnterpriseManagement.UI.Administrati" +
                "on.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAsProfil" +
                "e.RunAsProfileAssociationsPage;label2.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ToolStrip1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceToolStrip1 = ";toolStrip1;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Mi" +
                "crosoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.Comman" +
                "dNotification;toolStrip.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  LowSecurityText
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLowSecurityText = ";Distribute credentials to all computers.  (Low Security);ManagedString;Microsoft" +
                ".EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.I" +
                "nternal.UI.Administration.RunAsAccount.RunAsAccountDistributionsPage;allChoice.T" +
                "ext";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  HighSecurityText
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHighSecurityText = ";Distribute credentials to selected computers.  (High Security);ManagedString;Mic" +
                "rosoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement" +
                ".Mom.Internal.UI.Administration.RunAsAccount.RunAsAccountDistributionsPage;selec" +
                "tedChoice.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Distribution
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDistribution = ";Distribution;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAsAccount.RunAs" +
                "AccountDistributionsPage;$this.TabName";
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
            /// Caches the translated resource string for:  Apply
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedApply;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Tab2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WhereIsThisCredentialUsed
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWhereIsThisCredentialUsed;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectedComputers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectedComputers;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ToolStrip1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedToolStrip1;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  LowSecurityText
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLowSecurityText;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  HighSecurityText
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHighSecurityText;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Distribution
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDistribution;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
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
            /// Exposes access to the Apply translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Apply
            {
                get
                {
                    if ((cachedApply == null))
                    {
                        cachedApply = CoreManager.MomConsole.GetIntlStr(ResourceApply);
                    }
                    return cachedApply;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
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
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OK
            {
                get
                {
                    if ((cachedOK == null))
                    {
                        cachedOK = CoreManager.MomConsole.GetIntlStr(ResourceOK);
                    }
                    return cachedOK;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Tab2 translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tab2
            {
                get
                {
                    if ((cachedTab2 == null))
                    {
                        cachedTab2 = CoreManager.MomConsole.GetIntlStr(ResourceTab2);
                    }
                    return cachedTab2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WhereIsThisCredentialUsed translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WhereIsThisCredentialUsed
            {
                get
                {
                    if ((cachedWhereIsThisCredentialUsed == null))
                    {
                        cachedWhereIsThisCredentialUsed = CoreManager.MomConsole.GetIntlStr(ResourceWhereIsThisCredentialUsed);
                    }
                    return cachedWhereIsThisCredentialUsed;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectedComputers translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectedComputers
            {
                get
                {
                    if ((cachedSelectedComputers == null))
                    {
                        cachedSelectedComputers = CoreManager.MomConsole.GetIntlStr(ResourceSelectedComputers);
                    }
                    return cachedSelectedComputers;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ToolStrip1 translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ToolStrip1
            {
                get
                {
                    if ((cachedToolStrip1 == null))
                    {
                        cachedToolStrip1 = CoreManager.MomConsole.GetIntlStr(ResourceToolStrip1);
                    }
                    return cachedToolStrip1;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the LowSecurityText translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LowSecurityText
            {
                get
                {
                    if ((cachedLowSecurityText == null))
                    {
                        cachedLowSecurityText = CoreManager.MomConsole.GetIntlStr(ResourceLowSecurityText);
                    }
                    return cachedLowSecurityText;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the HighSecurityText translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string HighSecurityText
            {
                get
                {
                    if ((cachedHighSecurityText == null))
                    {
                        cachedHighSecurityText = CoreManager.MomConsole.GetIntlStr(ResourceHighSecurityText);
                    }
                    return cachedHighSecurityText;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Distribution translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Distribution
            {
                get
                {
                    if ((cachedDistribution == null))
                    {
                        cachedDistribution = CoreManager.MomConsole.GetIntlStr(ResourceDistribution);
                    }
                    return cachedDistribution;
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
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ApplyButton
            /// </summary>
            public const string ApplyButton = "applyButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for Tab2TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab2TabControl = "tabPages";
            
            /// <summary>
            /// Control ID for WhereIsThisCredentialUsedStaticControl
            /// </summary>
            public const string WhereIsThisCredentialUsedStaticControl = "whereUsedLink";
            
            /// <summary>
            /// Control ID for SelectedComputersListView
            /// </summary>
            public const string SelectedComputersListView = "computersList";
            
            /// <summary>
            /// Control ID for SelectedComputersStaticControl
            /// </summary>
            public const string SelectedComputersStaticControl = "label2";
            
            /// <summary>
            /// Control ID for ToolStrip1
            /// </summary>
            public const string ToolStrip1 = "addRemoveStrip";
            
            /// <summary>
            /// Control ID for LowSecurityRadioButton
            /// </summary>
            public const string LowSecurityRadioButton = "allChoice";
            
            /// <summary>
            /// Control ID for HighSecurityRadioButton
            /// </summary>
            public const string HighSecurityRadioButton = "selectedChoice";
            
            /// <summary>
            /// Control ID for DistributionStaticControl
            /// </summary>
            public const string DistributionStaticControl = "labelTitle";
        }
        #endregion
    }
}
