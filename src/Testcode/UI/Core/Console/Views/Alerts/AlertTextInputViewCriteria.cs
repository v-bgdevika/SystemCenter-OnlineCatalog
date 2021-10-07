// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AlertTextInputViewCriteria.cs">
// 	Copyright (c) Microsoft Corporation 2007
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[lucyra] 3/21/2007 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.Alerts
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IAlertTextInputViewCriteriaControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAlertTextInputViewCriteriaControls, for AlertTextInputViewCriteria.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[lucyra] 3/21/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAlertTextInputViewCriteriaControls
    {
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
        /// Read-only property to access SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedStaticControl
        /// </summary>
        StaticControl SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedTextBox
        /// </summary>
        TextBox SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedTextBox
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
    /// 	[lucyra] 3/21/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class AlertTextInputViewCriteria : Dialog, IAlertTextInputViewCriteriaControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedTextBox of type TextBox
        /// </summary>
        private TextBox cachedSpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedTextBox;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This is a constructor for multiple text input dialogs.
        /// </summary>
        /// <param name='app'>
        /// Owner of AlertTextInputViewCriteria of type App
        /// </param>
        /// <param name="windowCaption">Properties dialog title.</param>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AlertTextInputViewCriteria(Mom.Test.UI.Core.Console.MomConsoleApp app, Views.WindowCaptions windowCaption)
            :
                base(app, Init(app, windowCaption))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, UI.Core.Common.Constants.DefaultDialogTimeout);
        }
        #endregion
        
        #region IAlertTextInputViewCriteria Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAlertTextInputViewCriteriaControls Controls
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
        ///  Routine to set/get the text in control SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAccepted
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedText
        {
            get
            {
                return this.Controls.SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedTextBox.Text;
            }
            
            set
            {
                this.Controls.SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertTextInputViewCriteriaControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AlertTextInputViewCriteria.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertTextInputViewCriteriaControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, AlertTextInputViewCriteria.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertTextInputViewCriteriaControls.SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedStaticControl
        {
            get
            {
                if ((this.cachedSpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedStaticControl == null))
                {
                    this.cachedSpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedStaticControl = new StaticControl(this, AlertTextInputViewCriteria.ControlIDs.SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedStaticControl);
                }
                
                return this.cachedSpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedTextBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAlertTextInputViewCriteriaControls.SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedTextBox
        {
            get
            {
                if ((this.cachedSpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedTextBox == null))
                {
                    this.cachedSpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedTextBox = new TextBox(this, AlertTextInputViewCriteria.ControlIDs.SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedTextBox);
                }
                
                return this.cachedSpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedTextBox;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
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
        /// 	[lucyra] 3/21/2007 Created
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
        ///  <param name="app">ConsoleApp owning the dialog.</param>
        ///  <param name="windowCaption">Window Caption Dialog Title.</param>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app, Views.WindowCaptions windowCaption)
        {
            string DialogTitle = Views.GetWindowCaption(windowCaption);
            // First check if the dialog is already up.
            Window tempWindow = null;

            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(
                    DialogTitle, 
                    StringMatchSyntax.ExactMatch, 
                    WindowClassNames.Dialog, 
                    StringMatchSyntax.ExactMatch, 
                    app.MainWindow, 
                    Timeout);

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
                                DialogTitle + "*", StringMatchSyntax.WildCard);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);

                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage(
                            "AlertTextInputViewCriteriaDialog:: Attempt " + 
                            numberOfTries + 
                            " of " + 
                            MaxTries);

                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "AlertTextInputViewCriteriaDialog:: " +
                        "Failed to find window with title:  '" + 
                        DialogTitle + 
                        "'");

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
        /// 	[lucyra] 3/21/2007 Created
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
            /// This is not used, we search for the appropriate text input dialog and
            /// get it as Window Caption parameter. Local variable is used for dialog title.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle = "*";
            
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
            /// Contains resource string for:  SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAccepted
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecifyTheTextStringToSearchForSQLStyleWildcards_AreAccepted = ";&Specify the text string to search for.  SQL-style wildcards (%, _) are accepted" +
                ".;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.I" +
                "nternal.UI.Controls.StringEditDialog;labelHeader.Text";
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
            /// Caches the translated resource string for:  SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAccepted
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpecifyTheTextStringToSearchForSQLStyleWildcards_AreAccepted;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// This is not used in this generic title but kept if needed
            /// </summary>
            /// <history>
            /// 	[lucyra] 3/21/2007 Created
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
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 3/21/2007 Created
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
            /// 	[lucyra] 3/21/2007 Created
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
            /// Exposes access to the SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAccepted translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 3/21/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAccepted
            {
                get
                {
                    if ((cachedSpecifyTheTextStringToSearchForSQLStyleWildcards_AreAccepted == null))
                    {
                        cachedSpecifyTheTextStringToSearchForSQLStyleWildcards_AreAccepted = CoreManager.MomConsole.GetIntlStr(ResourceSpecifyTheTextStringToSearchForSQLStyleWildcards_AreAccepted);
                    }
                    
                    return cachedSpecifyTheTextStringToSearchForSQLStyleWildcards_AreAccepted;
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
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "buttonCancel";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "buttonOK";
            
            /// <summary>
            /// Control ID for SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedStaticControl
            /// </summary>
            public const string SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedStaticControl = "labelHeader";
            
            /// <summary>
            /// Control ID for SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedTextBox
            /// </summary>
            public const string SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedTextBox = "textBox";
        }
        #endregion
    }
}
