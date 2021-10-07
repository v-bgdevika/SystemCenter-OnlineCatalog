// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="CommunityAccountProperties.cs">
// 	Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
// 	MOM Project
// </project>
// <summary>
// 	Community Account Property Dialog
// </summary>
// <history>
// 	[v-linch] 6/24/2009 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.RunAsAccount
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - ICommunityAccountPropertiesControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ICommunityAccountPropertiesControls, for CommunityAccountProperties.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[v-linch] 6/24/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ICommunityAccountPropertiesControls
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
        /// Read-only property to access GeneralPropertiesStaticControl
        /// </summary>
        StaticControl GeneralPropertiesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CredentialsStaticControl
        /// </summary>
        StaticControl CredentialsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DistributionSecurityStaticControl
        /// </summary>
        StaticControl DistributionSecurityStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CompletionStaticControl
        /// </summary>
        StaticControl CompletionStaticControl
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
        /// Read-only property to access CommunityStringTextBox
        /// </summary>
        TextBox CommunityStringTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ProvideCredentialsForThisCommunityStringAccountTypeStaticControl
        /// </summary>
        StaticControl ProvideCredentialsForThisCommunityStringAccountTypeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ProvideAccountCredentialsStaticControl
        /// </summary>
        StaticControl ProvideAccountCredentialsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CredentialsStaticControl2
        /// </summary>
        StaticControl CredentialsStaticControl2
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
    /// 	[v-linch] 6/24/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class CommunityAccountProperties : Dialog, ICommunityAccountPropertiesControls
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
        /// Cache to hold a reference to GeneralPropertiesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralPropertiesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CredentialsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCredentialsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DistributionSecurityStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDistributionSecurityStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CompletionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCompletionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CommunityStringStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCommunityStringStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CommunityStringTextBox of type TextBox
        /// </summary>
        private TextBox cachedCommunityStringTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ProvideCredentialsForThisCommunityStringAccountTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedProvideCredentialsForThisCommunityStringAccountTypeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ProvideAccountCredentialsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedProvideAccountCredentialsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CredentialsStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedCredentialsStaticControl2;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of CommunityAccountProperties of type App
        /// </param>
        /// <history>
        /// 	[v-linch] 6/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public CommunityAccountProperties(App app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region ICommunityAccountProperties Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[v-linch] 6/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ICommunityAccountPropertiesControls Controls
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
        /// 	[v-linch] 6/24/2009 Created
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
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[v-linch] 6/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICommunityAccountPropertiesControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, CommunityAccountProperties.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[v-linch] 6/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICommunityAccountPropertiesControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, CommunityAccountProperties.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[v-linch] 6/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICommunityAccountPropertiesControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, CommunityAccountProperties.ControlIDs.CreateButton);
                }
                
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[v-linch] 6/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICommunityAccountPropertiesControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, CommunityAccountProperties.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralPropertiesStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-linch] 6/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICommunityAccountPropertiesControls.GeneralPropertiesStaticControl
        {
            get
            {
                if ((this.cachedGeneralPropertiesStaticControl == null))
                {
                    this.cachedGeneralPropertiesStaticControl = new StaticControl(this, CommunityAccountProperties.ControlIDs.GeneralPropertiesStaticControl);
                }
                
                return this.cachedGeneralPropertiesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CredentialsStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-linch] 6/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICommunityAccountPropertiesControls.CredentialsStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedCredentialsStaticControl == null))
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
                    this.cachedCredentialsStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedCredentialsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DistributionSecurityStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-linch] 6/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICommunityAccountPropertiesControls.DistributionSecurityStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedDistributionSecurityStaticControl == null))
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
                    this.cachedDistributionSecurityStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedDistributionSecurityStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CompletionStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-linch] 6/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICommunityAccountPropertiesControls.CompletionStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedCompletionStaticControl == null))
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
                    this.cachedCompletionStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedCompletionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CommunityStringStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-linch] 6/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICommunityAccountPropertiesControls.CommunityStringStaticControl
        {
            get
            {
                if ((this.cachedCommunityStringStaticControl == null))
                {
                    this.cachedCommunityStringStaticControl = new StaticControl(this, CommunityAccountProperties.ControlIDs.CommunityStringStaticControl);
                }
                
                return this.cachedCommunityStringStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CommunityStringTextBox control
        /// </summary>
        /// <history>
        /// 	[v-linch] 6/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ICommunityAccountPropertiesControls.CommunityStringTextBox
        {
            get
            {
                if ((this.cachedCommunityStringTextBox == null))
                {
                    this.cachedCommunityStringTextBox = new TextBox(this, CommunityAccountProperties.ControlIDs.CommunityStringTextBox);
                }
                
                return this.cachedCommunityStringTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ProvideCredentialsForThisCommunityStringAccountTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-linch] 6/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICommunityAccountPropertiesControls.ProvideCredentialsForThisCommunityStringAccountTypeStaticControl
        {
            get
            {
                if ((this.cachedProvideCredentialsForThisCommunityStringAccountTypeStaticControl == null))
                {
                    this.cachedProvideCredentialsForThisCommunityStringAccountTypeStaticControl = new StaticControl(this, CommunityAccountProperties.ControlIDs.ProvideCredentialsForThisCommunityStringAccountTypeStaticControl);
                }
                
                return this.cachedProvideCredentialsForThisCommunityStringAccountTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ProvideAccountCredentialsStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-linch] 6/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICommunityAccountPropertiesControls.ProvideAccountCredentialsStaticControl
        {
            get
            {
                if ((this.cachedProvideAccountCredentialsStaticControl == null))
                {
                    this.cachedProvideAccountCredentialsStaticControl = new StaticControl(this, CommunityAccountProperties.ControlIDs.ProvideAccountCredentialsStaticControl);
                }
                
                return this.cachedProvideAccountCredentialsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CredentialsStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[v-linch] 6/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICommunityAccountPropertiesControls.CredentialsStaticControl2
        {
            get
            {
                if ((this.cachedCredentialsStaticControl2 == null))
                {
                    this.cachedCredentialsStaticControl2 = new StaticControl(this, CommunityAccountProperties.ControlIDs.CredentialsStaticControl2);
                }
                
                return this.cachedCredentialsStaticControl2;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[v-linch] 6/24/2009 Created
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
        /// 	[v-linch] 6/24/2009 Created
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
        /// 	[v-linch] 6/24/2009 Created
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
        /// 	[v-linch] 6/24/2009 Created
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
        /// <param name="app">App owning the dialog.</param>
        /// <history>
        /// 	[v-linch] 6/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
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
                                Strings.DialogTitle + "*", StringMatchSyntax.WildCard);

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
                        "Failed to find window with title:  '" + Strings.DialogTitle + "'");

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
        /// 	[v-linch] 6/24/2009 Created
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
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle = ";Run As Account Properties -;ManagedString;Microsoft.EnterpriseManagement.UI." +
                "Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;RunAsAccountPropertiesCaption";

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

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[v-linch] 2009/6/17  Created
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
            /// 	[v-linch] 2009/6/17  Created
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
            /// 	[v-linch] 2009/6/17  Created
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
            /// 	[v-linch] 2009/6/17  Created
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

            #endregion
        }
        #endregion
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[v-linch] 6/24/2009 Created
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
            /// Control ID for GeneralPropertiesStaticControl
            /// </summary>
            public const string GeneralPropertiesStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for CredentialsStaticControl
            /// </summary>
            public const string CredentialsStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for DistributionSecurityStaticControl
            /// </summary>
            public const string DistributionSecurityStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for CompletionStaticControl
            /// </summary>
            public const string CompletionStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for CommunityStringStaticControl
            /// </summary>
            public const string CommunityStringStaticControl = "labelCommunity";
            
            /// <summary>
            /// Control ID for CommunityStringTextBox
            /// </summary>
            public const string CommunityStringTextBox = "textBoxCommunity";
            
            /// <summary>
            /// Control ID for ProvideCredentialsForThisCommunityStringAccountTypeStaticControl
            /// </summary>
            public const string ProvideCredentialsForThisCommunityStringAccountTypeStaticControl = "labelTitle1";
            
            /// <summary>
            /// Control ID for ProvideAccountCredentialsStaticControl
            /// </summary>
            public const string ProvideAccountCredentialsStaticControl = "labelTitle";
            
            /// <summary>
            /// Control ID for CredentialsStaticControl2
            /// </summary>
            public const string CredentialsStaticControl2 = "headerLabel";
        }
        #endregion
    }
}
