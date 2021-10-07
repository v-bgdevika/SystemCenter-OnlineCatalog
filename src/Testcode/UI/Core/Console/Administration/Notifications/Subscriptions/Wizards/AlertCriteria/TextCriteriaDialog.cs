// ----------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="TextCriteriaDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	MOMv3 R2 test automation.
// </project>
// <summary>
// 	MOMv3 R2 test automation.
// </summary>
// <history>
// 	[KellyMor] 15-SEP-08 Created
// </history>
// ----------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Administration.Notifications.Subscriptions.Wizards.AlertCriteria
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - ITextCriteriaDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ITextCriteriaDialogControls, for TextCriteriaDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 15-SEP-08 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ITextCriteriaDialogControls
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
        
        /// <summary>
        /// Read-only property to access TextStringStaticControl
        /// </summary>
        StaticControl TextStringStaticControl
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the functionality of the alert criteria simple 
    /// text edit dialog.  This dialog is used to input text that will be used 
    /// to match alert criteria in the database using simple string matching.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 15-SEP-08 Created
    /// </history>
    /// -----------------------------------------------------------------------
    public class TextCriteriaDialog : Dialog, ITextCriteriaDialogControls
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
        
        /// <summary>
        /// Cache to hold a reference to TextStringStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTextStringStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="dialogTitle">
        /// Title string used to locate the dialog.
        /// </param>
        /// <param name='app'>
        /// Owner of TextCriteriaDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[KellyMor] 15-SEP-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public TextCriteriaDialog(
            string dialogTitle,
            MomConsoleApp app) : 
                base(app, Init(dialogTitle, app))
        {
            // TODO: Add Constructor logic here. 
        }

        #endregion
        
        #region ITextCriteriaDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[KellyMor] 15-SEP-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ITextCriteriaDialogControls Controls
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
        /// 	[KellyMor] 15-SEP-08 Created
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
        /// 	[KellyMor] 15-SEP-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITextCriteriaDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, TextCriteriaDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 15-SEP-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITextCriteriaDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, TextCriteriaDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 15-SEP-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITextCriteriaDialogControls.SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedStaticControl
        {
            get
            {
                if ((this.cachedSpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedStaticControl == null))
                {
                    this.cachedSpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedStaticControl = new StaticControl(this, TextCriteriaDialog.ControlIDs.SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedStaticControl);
                }
                
                return this.cachedSpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 15-SEP-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ITextCriteriaDialogControls.SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedTextBox
        {
            get
            {
                if ((this.cachedSpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedTextBox == null))
                {
                    this.cachedSpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedTextBox = new TextBox(this, TextCriteriaDialog.ControlIDs.SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedTextBox);
                }
                
                return this.cachedSpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TextStringStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 15-SEP-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITextCriteriaDialogControls.TextStringStaticControl
        {
            get
            {
                if ((this.cachedTextStringStaticControl == null))
                {
                    this.cachedTextStringStaticControl = new StaticControl(this, TextCriteriaDialog.ControlIDs.TextStringStaticControl);
                }
                
                return this.cachedTextStringStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[KellyMor] 15-SEP-08 Created
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
        /// 	[KellyMor] 15-SEP-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        #endregion
        
        /// -------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the 
        /// dialog.
        /// </summary>
        /// <returns>
        /// A reference to the dialog's Window.
        /// </returns>
        /// <param name="dialogTitle">
        /// Title string used to locate the dialog.
        /// </param>
        /// <param name="app">
        /// MomConsoleApp owning the dialog.
        /// </param>
        /// <history>
        /// 	[KellyMor] 15-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        private static Window Init(
            string dialogTitle,
            MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = 
                    new Window(
                        dialogTitle, 
                        StringMatchSyntax.ExactMatch, 
                        WindowClassNames.WinForms10Window8, 
                        StringMatchSyntax.ExactMatch, 
                        app.MainWindow, 
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
                    numberOfTries++)
                {
                    try
                    {
                        // Try to locate an existing instance of the window
                        tempWindow = 
                            new Window(
                                dialogTitle, 
                                StringMatchSyntax.WildCard);

                        // Wait for the window to become ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow, 
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException )
                    {
                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage(
                            "Attempt " +
                            numberOfTries +
                            " of " +
                            maxTries +
                            "...");

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }
                
                // check for success
                if ((null == tempWindow))
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find the window with title := '" +
                        dialogTitle);

                    // rethrow the original exception
                    throw windowNotFound;
                }
            }
            
            return tempWindow;
        }
        
        #region Strings Class

        /// -------------------------------------------------------------------
        /// <summary>
        /// Resource string definitions.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 15-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            #region Dialog Title Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertNameDialogTitle = 
                ";Alert Name;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;NameEditTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the Alert Description window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertDescriptionDialogTitle =
                ";Description;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;DescriptionEditTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the Assigned Owner window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAssignedOwnerDialogTitle =
                ";Owner;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;OwnerEditTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the Last Modified By Dialog window or dialog 
            /// title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLastModifiedByDialogTitle =
                ";Last Modified By;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;LastModifiedTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the Resolved By window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceResolvedByDialogTitle =
                ";Resolved By;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;ResolvedByTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the Ticket Id Dialog window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTicketIdDialogTitle =
                ";Ticket ID;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;TicketIDTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the From Site window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFromSiteDialogTitle =
                ";Site;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;SiteTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the Custom Field 1 window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField1DialogTitle =
                ";Custom Field 1;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;CustomField1EditTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the Custom Field 2 window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField2DialogTitle =
                ";Custom Field 2;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;CustomField2EditTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the Custom Field 3 window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField3DialogTitle =
                ";Custom Field 3;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;CustomField3EditTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the Custom Field 4 window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField4DialogTitle =
                ";Custom Field 4;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;CustomField4EditTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the Custom Field 5 window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField5DialogTitle =
                ";Custom Field 5;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;CustomField5EditTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the Custom Field 6 window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField6DialogTitle =
                ";Custom Field 6;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;CustomField6EditTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the Custom Field 7 window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField7DialogTitle =
                ";Custom Field 7;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;CustomField7EditTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the Custom Field 8 window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField8DialogTitle =
                ";Custom Field 8;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;CustomField8EditTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the Custom Field 9 window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField9DialogTitle =
                ";Custom Field 9;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;CustomField9EditTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Custom Field 10 dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField10DialogTitle =
                ";Custom Field 10;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;CustomField10EditTitle";

            #endregion Dialog Title Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = 
                ";Cancel" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.EditDialogBase" +
                ";buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK =
                ";OK" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.EditDialogBase" +
                ";buttonOK.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAccepted
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecifyTheTextStringToSearchForSQLStyleWildcards_AreAccepted = 
                ";Specify the text string to search for.  SQL-style wildcards (%, _) are accepted." + 
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.StringEditDialog" +
                ";labelHeader.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TextString
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTextString =
                ";&Text string:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.StringEditDialog;" +
                "textStringLabel.Text";

            #endregion
            
            #region Private Members

            #region Cached Dialog Titles

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertNameDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertDescriptionDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAssignedOwnerDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLastModifiedByDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedResolvedByDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTicketIdDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFromSiteDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField1DialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField2DialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField3DialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField4DialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField5DialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField6DialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField7DialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField8DialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField9DialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField10DialogTitle;

            #endregion Cached Dialog Titles

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
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TextString
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTextString;

            #endregion
            
            #region Properties

            #region Dialog Titles

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 15-SEP-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertNameDialogTitle
            {
                get
                {
                    if (cachedAlertNameDialogTitle == null)
                    {
                        cachedAlertNameDialogTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAlertNameDialogTitle);
                    }

                    return cachedAlertNameDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 15-SEP-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertDescriptionDialogTitle
            {
                get
                {
                    if (cachedAlertDescriptionDialogTitle == null)
                    {
                        cachedAlertDescriptionDialogTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAlertDescriptionDialogTitle);
                    }

                    return cachedAlertDescriptionDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 15-SEP-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AssignedOwnerDialogTitle
            {
                get
                {
                    if (cachedAssignedOwnerDialogTitle == null)
                    {
                        cachedAssignedOwnerDialogTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAssignedOwnerDialogTitle);
                    }

                    return cachedAssignedOwnerDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 15-SEP-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LastModifiedByDialogTitle
            {
                get
                {
                    if (cachedLastModifiedByDialogTitle == null)
                    {
                        cachedLastModifiedByDialogTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceLastModifiedByDialogTitle);
                    }

                    return cachedLastModifiedByDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 15-SEP-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ResolvedByDialogTitle
            {
                get
                {
                    if (cachedResolvedByDialogTitle == null)
                    {
                        cachedResolvedByDialogTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceResolvedByDialogTitle);
                    }

                    return cachedResolvedByDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 15-SEP-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TicketIdDialogTitle
            {
                get
                {
                    if (cachedTicketIdDialogTitle == null)
                    {
                        cachedTicketIdDialogTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceTicketIdDialogTitle);
                    }

                    return cachedTicketIdDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 15-SEP-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FromSiteDialogTitle 
            {
                get
                {
                    if (cachedFromSiteDialogTitle == null)
                    {
                        cachedFromSiteDialogTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceFromSiteDialogTitle);
                    }

                    return cachedFromSiteDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 15-SEP-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CustomField1DialogTitle
            {
                get
                {
                    if (cachedCustomField1DialogTitle == null)
                    {
                        cachedCustomField1DialogTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCustomField1DialogTitle);
                    }

                    return cachedCustomField1DialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 15-SEP-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CustomField2DialogTitle
            {
                get
                {
                    if (cachedCustomField2DialogTitle == null)
                    {
                        cachedCustomField2DialogTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCustomField2DialogTitle);
                    }

                    return cachedCustomField2DialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 15-SEP-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CustomField3DialogTitle
            {
                get
                {
                    if (cachedCustomField3DialogTitle == null)
                    {
                        cachedCustomField3DialogTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCustomField3DialogTitle);
                    }

                    return cachedCustomField3DialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 15-SEP-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CustomField4DialogTitle
            {
                get
                {
                    if (cachedCustomField4DialogTitle == null)
                    {
                        cachedCustomField4DialogTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCustomField4DialogTitle);
                    }

                    return cachedCustomField4DialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 15-SEP-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CustomField5DialogTitle
            {
                get
                {
                    if (cachedCustomField5DialogTitle == null)
                    {
                        cachedCustomField5DialogTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCustomField5DialogTitle);
                    }

                    return cachedCustomField5DialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 15-SEP-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CustomField6DialogTitle
            {
                get
                {
                    if (cachedCustomField6DialogTitle == null)
                    {
                        cachedCustomField6DialogTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCustomField6DialogTitle);
                    }

                    return cachedCustomField6DialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 15-SEP-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CustomField7DialogTitle
            {
                get
                {
                    if (cachedCustomField7DialogTitle == null)
                    {
                        cachedCustomField7DialogTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCustomField7DialogTitle);
                    }

                    return cachedCustomField7DialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 15-SEP-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CustomField8DialogTitle
            {
                get
                {
                    if (cachedCustomField8DialogTitle == null)
                    {
                        cachedCustomField8DialogTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCustomField8DialogTitle);
                    }

                    return cachedCustomField8DialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 15-SEP-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CustomField9DialogTitle
            {
                get
                {
                    if (cachedCustomField9DialogTitle == null)
                    {
                        cachedCustomField9DialogTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCustomField9DialogTitle);
                    }

                    return cachedCustomField9DialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 15-SEP-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CustomField10DialogTitle
            {
                get
                {
                    if (cachedCustomField10DialogTitle == null)
                    {
                        cachedCustomField10DialogTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCustomField10DialogTitle);
                    }

                    return cachedCustomField10DialogTitle;
                }
            }

            #endregion Dialog Titles

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 15-SEP-08 Created
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
            /// 	[KellyMor] 15-SEP-08 Created
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
            /// 	[KellyMor] 15-SEP-08 Created
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
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TextString translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 15-SEP-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TextString
            {
                get
                {
                    if ((cachedTextString == null))
                    {
                        cachedTextString = CoreManager.MomConsole.GetIntlStr(ResourceTextString);
                    }
                    
                    return cachedTextString;
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
        /// 	[KellyMor] 15-SEP-08 Created
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
            
            /// <summary>
            /// Control ID for TextStringStaticControl
            /// </summary>
            public const string TextStringStaticControl = "textStringLabel";
        }
        #endregion
    }
}
