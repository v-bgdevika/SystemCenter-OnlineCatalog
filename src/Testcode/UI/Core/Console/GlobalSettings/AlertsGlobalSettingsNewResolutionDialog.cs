// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AlertsGlobalSettingsNewResolutionDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[lucyra] 9/21/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.GlobalSettings
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IAlertsGlobalSettingsNewResolutionDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAlertsGlobalSettingsNewResolutionDialogControls, for AlertsGlobalSettingsNewResolutionDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[lucyra] 9/21/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAlertsGlobalSettingsNewResolutionDialogControls
    {
        /// <summary>
        /// Read-only property to access StateIdComboBox
        /// </summary>
        ComboBox StateIdComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ResolutionStateTextBox
        /// </summary>
        TextBox ResolutionStateTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access UniqueIDStaticControl
        /// </summary>
        StaticControl UniqueIDStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ResolutionStateStaticControl
        /// </summary>
        StaticControl ResolutionStateStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ToAddResolutionStateEnterTheFollowingDetailsStaticControl
        /// </summary>
        StaticControl ToAddResolutionStateEnterTheFollowingDetailsStaticControl
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
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add dialog functionality description here.
    /// </summary>
    /// <history>
    /// 	[lucyra] 9/21/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class AlertsGlobalSettingsNewResolutionDialog : Dialog, IAlertsGlobalSettingsNewResolutionDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to StateIdComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedStateIdComboBox;
        
        /// <summary>
        /// Cache to hold a reference to ResolutionStateTextBox of type TextBox
        /// </summary>
        private TextBox cachedResolutionStateTextBox;
        
        /// <summary>
        /// Cache to hold a reference to UniqueIDStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedUniqueIDStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ResolutionStateStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedResolutionStateStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ToAddResolutionStateEnterTheFollowingDetailsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedToAddResolutionStateEnterTheFollowingDetailsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of AlertsGlobalSettingsNewResolutionDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AlertsGlobalSettingsNewResolutionDialog(ConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IAlertsGlobalSettingsNewResolutionDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAlertsGlobalSettingsNewResolutionDialogControls Controls
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
        ///  Routine to set/get the text in control ResolutionStateID
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ResolutionStateIDText
        {
            get
            {
                return this.Controls.StateIdComboBox.Text;
            }
            
            set
            {
                this.Controls.StateIdComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ResolutionState
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ResolutionStateText
        {
            get
            {
                return this.Controls.ResolutionStateTextBox.Text;
            }
            
            set
            {
                this.Controls.ResolutionStateTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StateIdComboBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IAlertsGlobalSettingsNewResolutionDialogControls.StateIdComboBox
        {
            get
            {
                if ((this.cachedStateIdComboBox == null))
                {
                    this.cachedStateIdComboBox = new ComboBox(this, AlertsGlobalSettingsNewResolutionDialog.ControlIDs.StateIdComboBox);
                }
                
                return this.cachedStateIdComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ResolutionStateTextBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAlertsGlobalSettingsNewResolutionDialogControls.ResolutionStateTextBox
        {
            get
            {
                if ((this.cachedResolutionStateTextBox == null))
                {
                    this.cachedResolutionStateTextBox = new TextBox(this, AlertsGlobalSettingsNewResolutionDialog.ControlIDs.ResolutionStateTextBox);
                }
                
                return this.cachedResolutionStateTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UniqueIDStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertsGlobalSettingsNewResolutionDialogControls.UniqueIDStaticControl
        {
            get
            {
                if ((this.cachedUniqueIDStaticControl == null))
                {
                    this.cachedUniqueIDStaticControl = new StaticControl(this, AlertsGlobalSettingsNewResolutionDialog.ControlIDs.UniqueIDStaticControl);
                }
                
                return this.cachedUniqueIDStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ResolutionStateStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertsGlobalSettingsNewResolutionDialogControls.ResolutionStateStaticControl
        {
            get
            {
                if ((this.cachedResolutionStateStaticControl == null))
                {
                    this.cachedResolutionStateStaticControl = new StaticControl(this, AlertsGlobalSettingsNewResolutionDialog.ControlIDs.ResolutionStateStaticControl);
                }
                
                return this.cachedResolutionStateStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToAddResolutionStateEnterTheFollowingDetailsStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertsGlobalSettingsNewResolutionDialogControls.ToAddResolutionStateEnterTheFollowingDetailsStaticControl
        {
            get
            {
                if ((this.cachedToAddResolutionStateEnterTheFollowingDetailsStaticControl == null))
                {
                    this.cachedToAddResolutionStateEnterTheFollowingDetailsStaticControl = new StaticControl(this, AlertsGlobalSettingsNewResolutionDialog.ControlIDs.ToAddResolutionStateEnterTheFollowingDetailsStaticControl);
                }
                
                return this.cachedToAddResolutionStateEnterTheFollowingDetailsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertsGlobalSettingsNewResolutionDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AlertsGlobalSettingsNewResolutionDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertsGlobalSettingsNewResolutionDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, AlertsGlobalSettingsNewResolutionDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
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
        /// 	[lucyra] 9/21/2006 Created
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
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(
                    Strings.DialogTitle,
                    StringMatchSyntax.WildCard,
                    WindowClassNames.WinForms10Window8,
                    StringMatchSyntax.WildCard,
                    app,
                    Timeout);
            }
            catch (Exceptions.WindowNotFoundException)
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
                        Core.Common.Utilities.LogMessage(
                            "AlertsGlobalSettingsNewResolutionDialog:: Attempt " + numberOfTries + " of " + MaxTries);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "AlertsGlobalSettingsNewResolutionDialog:: Failed to find window with title:  '" +
                        Strings.DialogTitle + "'");

                    // throw the existing WindowNotFound exception
                    throw;
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
        /// 	[lucyra] 9/21/2006 Created
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
            private const string ResourceDialogTitle = ";Add Alert Resolution State;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;AddAlertResolutionState";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  UniqueID
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUniqueID = ";&Unique ID:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.ResolutionStateForm;labelID.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ResolutionState
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceResolutionState = ";&Resolution state:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.ResolutionStateForm;labelState.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ToAddResolutionStateEnterTheFollowingDetails
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceToAddResolutionStateEnterTheFollowingDetails = ";To add resolution state, enter the following details:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;AlertResolutionAddTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.TranslucentColorPicker;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.TranslucentColorPicker;buttonOk.Text";
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
            /// Caches the translated resource string for:  UniqueID
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUniqueID;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ResolutionState
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedResolutionState;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ToAddResolutionStateEnterTheFollowingDetails
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedToAddResolutionStateEnterTheFollowingDetails;
            
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
            /// 	[lucyra] 9/21/2006 Created
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
            /// Exposes access to the UniqueID translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UniqueID
            {
                get
                {
                    if ((cachedUniqueID == null))
                    {
                        cachedUniqueID = CoreManager.MomConsole.GetIntlStr(ResourceUniqueID);
                    }
                    
                    return cachedUniqueID;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ResolutionState translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ResolutionState
            {
                get
                {
                    if ((cachedResolutionState == null))
                    {
                        cachedResolutionState = CoreManager.MomConsole.GetIntlStr(ResourceResolutionState);
                    }
                    
                    return cachedResolutionState;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ToAddResolutionStateEnterTheFollowingDetails translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ToAddResolutionStateEnterTheFollowingDetails
            {
                get
                {
                    if ((cachedToAddResolutionStateEnterTheFollowingDetails == null))
                    {
                        cachedToAddResolutionStateEnterTheFollowingDetails = CoreManager.MomConsole.GetIntlStr(ResourceToAddResolutionStateEnterTheFollowingDetails);
                    }
                    
                    return cachedToAddResolutionStateEnterTheFollowingDetails;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/21/2006 Created
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
            /// 	[lucyra] 9/21/2006 Created
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
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for StateIdComboBox
            /// </summary>
            public const string StateIdComboBox = "comboBoxStateIds";
            
            /// <summary>
            /// Control ID for ResolutionStateTextBox
            /// </summary>
            public const string ResolutionStateTextBox = "textBoxState";
            
            /// <summary>
            /// Control ID for UniqueIDStaticControl
            /// </summary>
            public const string UniqueIDStaticControl = "labelID";
            
            /// <summary>
            /// Control ID for ResolutionStateStaticControl
            /// </summary>
            public const string ResolutionStateStaticControl = "labelState";
            
            /// <summary>
            /// Control ID for ToAddResolutionStateEnterTheFollowingDetailsStaticControl
            /// </summary>
            public const string ToAddResolutionStateEnterTheFollowingDetailsStaticControl = "labelTitle";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelBtn";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
        }
        #endregion
    }
}
