// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="MultipleAlertsPropertiesDialog.cs">
// 	Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[v-yoz] 6/16/2009 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.Alerts
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IMultipleAlertsPropertiesDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IMultipleAlertsPropertiesDialogControls, for MultipleAlertsPropertiesDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[v-yoz] 6/16/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IMultipleAlertsPropertiesDialogControls
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
        /// Read-only property to access Tab0TabControl
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TabControl Tab0TabControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access YouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSavedStaticControl
        /// </summary>
        StaticControl YouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSavedStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access YouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSavedTextBox
        /// </summary>
        TextBox YouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSavedTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AddHistoryCommentStaticControl
        /// </summary>
        StaticControl AddHistoryCommentStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TextBox0
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TextBox TextBox0
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TicketIDStaticControl
        /// </summary>
        StaticControl TicketIDStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access KeyDetailsTextBox
        /// </summary>
        TextBox KeyDetailsTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ChangeButton
        /// </summary>
        Button ChangeButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AlertStatusCombo
        /// </summary>
        ComboBox AlertStatusCombo
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access OwnerStaticControl
        /// </summary>
        StaticControl OwnerStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AlertStatusStaticControl
        /// </summary>
        StaticControl AlertStatusStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access KeyDetailsStaticControl
        /// </summary>
        StaticControl KeyDetailsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access OnceYouHaveIdentifiedTheProblemAndTakenCorrectiveActionYouCanSelectClosedWhichWillRemoveTheAlertFrom
        /// </summary>
        StaticControl OnceYouHaveIdentifiedTheProblemAndTakenCorrectiveActionYouCanSelectClosedWhichWillRemoveTheAlertFrom
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
    /// 	[v-yoz] 6/16/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class MultipleAlertsPropertiesDialog : Dialog, IMultipleAlertsPropertiesDialogControls
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
        /// Cache to hold a reference to YouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSavedStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedYouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSavedStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to YouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSavedTextBox of type TextBox
        /// </summary>
        private TextBox cachedYouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSavedTextBox;
        
        /// <summary>
        /// Cache to hold a reference to AddHistoryCommentStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAddHistoryCommentStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to TextBox0 of type TextBox
        /// </summary>
        private TextBox cachedTextBox0;
        
        /// <summary>
        /// Cache to hold a reference to TicketIDStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTicketIDStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to KeyDetailsTextBox of type TextBox
        /// </summary>
        private TextBox cachedKeyDetailsTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ChangeButton of type Button
        /// </summary>
        private Button cachedChangeButton;
        
        /// <summary>
        /// Cache to hold a reference to AlertStatus of type ComboBox
        /// </summary>
        private ComboBox cachedAlertStatusCombo;
        
        /// <summary>
        /// Cache to hold a reference to OwnerStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedOwnerStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AlertStatusStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAlertStatusStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to KeyDetailsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedKeyDetailsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to OnceYouHaveIdentifiedTheProblemAndTakenCorrectiveActionYouCanSelectClosedWhichWillRemoveTheAlertFrom of type StaticControl
        /// </summary>
        private StaticControl cachedOnceYouHaveIdentifiedTheProblemAndTakenCorrectiveActionYouCanSelectClosedWhichWillRemoveTheAlertFrom;

        /// <summary>
        /// Cache to hold a reference to Tab0TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab0TabControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of MultipleAlertsPropertiesDialog of type App
        /// </param>
        /// <history>
        /// 	[v-yoz] 6/16/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public MultipleAlertsPropertiesDialog(App app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IMultipleAlertsPropertiesDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[v-yoz] 6/16/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IMultipleAlertsPropertiesDialogControls Controls
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
        ///  Routine to set/get the text in control YouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSaved
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-yoz] 6/16/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string YouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSavedText
        {
            get
            {
                return this.Controls.YouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSavedTextBox.Text;
            }
            
            set
            {
                this.Controls.YouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSavedTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TextBox0
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-yoz] 6/16/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TextBox0Text
        {
            get
            {
                return this.Controls.TextBox0.Text;
            }
            
            set
            {
                this.Controls.TextBox0.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control KeyDetails
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-yoz] 6/16/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string KeyDetailsText
        {
            get
            {
                return this.Controls.KeyDetailsTextBox.Text;
            }
            
            set
            {
                this.Controls.KeyDetailsTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control AlertStatusCombo
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-yoz] 6/16/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string AlertStatusComboText
        {
            get
            {
                return this.Controls.AlertStatusCombo.Text;
            }
            
            set
            {
                this.Controls.AlertStatusCombo.SelectByText(value, true);
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApplyButton control
        /// </summary>
        /// <history>
        /// 	[v-yoz] 6/16/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMultipleAlertsPropertiesDialogControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, MultipleAlertsPropertiesDialog.ControlIDs.ApplyButton);
                }
                
                return this.cachedApplyButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[v-yoz] 6/16/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMultipleAlertsPropertiesDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, MultipleAlertsPropertiesDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[v-yoz] 6/16/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMultipleAlertsPropertiesDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, MultipleAlertsPropertiesDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab0TabControl control
        /// </summary>
        /// <history>
        /// 	[v-yoz] 6/16/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IMultipleAlertsPropertiesDialogControls.Tab0TabControl
        {
            get
            {
                if ((this.cachedTab0TabControl == null))
                {
                    this.cachedTab0TabControl = new TabControl(this, MultipleAlertsPropertiesDialog.ControlIDs.Tab0TabControl);
                }
                
                return this.cachedTab0TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the YouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSavedStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-yoz] 6/16/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMultipleAlertsPropertiesDialogControls.YouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSavedStaticControl
        {
            get
            {
                if ((this.cachedYouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSavedStaticControl == null))
                {
                    this.cachedYouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSavedStaticControl = new StaticControl(this, MultipleAlertsPropertiesDialog.ControlIDs.YouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSavedStaticControl);
                }
                
                return this.cachedYouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSavedStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the YouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSavedTextBox control
        /// </summary>
        /// <history>
        /// 	[v-yoz] 6/16/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IMultipleAlertsPropertiesDialogControls.YouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSavedTextBox
        {
            get
            {
                if ((this.cachedYouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSavedTextBox == null))
                {
                    this.cachedYouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSavedTextBox = new TextBox(this, MultipleAlertsPropertiesDialog.ControlIDs.YouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSavedTextBox);
                }
                
                return this.cachedYouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSavedTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddHistoryCommentStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-yoz] 6/16/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMultipleAlertsPropertiesDialogControls.AddHistoryCommentStaticControl
        {
            get
            {
                if ((this.cachedAddHistoryCommentStaticControl == null))
                {
                    this.cachedAddHistoryCommentStaticControl = new StaticControl(this, MultipleAlertsPropertiesDialog.ControlIDs.AddHistoryCommentStaticControl);
                }
                
                return this.cachedAddHistoryCommentStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TextBox0 control
        /// </summary>
        /// <history>
        /// 	[v-yoz] 6/16/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IMultipleAlertsPropertiesDialogControls.TextBox0
        {
            get
            {
                if ((this.cachedTextBox0 == null))
                {
                    this.cachedTextBox0 = new TextBox(this, MultipleAlertsPropertiesDialog.ControlIDs.TextBox0);
                }
                
                return this.cachedTextBox0;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TicketIDStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-yoz] 6/16/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMultipleAlertsPropertiesDialogControls.TicketIDStaticControl
        {
            get
            {
                if ((this.cachedTicketIDStaticControl == null))
                {
                    this.cachedTicketIDStaticControl = new StaticControl(this, MultipleAlertsPropertiesDialog.ControlIDs.TicketIDStaticControl);
                }
                
                return this.cachedTicketIDStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the KeyDetailsTextBox control
        /// </summary>
        /// <history>
        /// 	[v-yoz] 6/16/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IMultipleAlertsPropertiesDialogControls.KeyDetailsTextBox
        {
            get
            {
                if ((this.cachedKeyDetailsTextBox == null))
                {
                    this.cachedKeyDetailsTextBox = new TextBox(this, MultipleAlertsPropertiesDialog.ControlIDs.KeyDetailsTextBox);
                }
                
                return this.cachedKeyDetailsTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ChangeButton control
        /// </summary>
        /// <history>
        /// 	[v-yoz] 6/16/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMultipleAlertsPropertiesDialogControls.ChangeButton
        {
            get
            {
                if ((this.cachedChangeButton == null))
                {
                    this.cachedChangeButton = new Button(this, MultipleAlertsPropertiesDialog.ControlIDs.ChangeButton);
                }
                
                return this.cachedChangeButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertStatusCombo control
        /// </summary>
        /// <history>
        /// 	[v-yoz] 6/16/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IMultipleAlertsPropertiesDialogControls.AlertStatusCombo
        {
            get
            {
                if ((this.cachedAlertStatusCombo == null))
                {
                    this.cachedAlertStatusCombo = new ComboBox(this, MultipleAlertsPropertiesDialog.ControlIDs.AlertStatusCombo);
                }

                return this.cachedAlertStatusCombo;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OwnerStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-yoz] 6/16/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMultipleAlertsPropertiesDialogControls.OwnerStaticControl
        {
            get
            {
                if ((this.cachedOwnerStaticControl == null))
                {
                    this.cachedOwnerStaticControl = new StaticControl(this, MultipleAlertsPropertiesDialog.ControlIDs.OwnerStaticControl);
                }
                
                return this.cachedOwnerStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertStatusStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-yoz] 6/16/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMultipleAlertsPropertiesDialogControls.AlertStatusStaticControl
        {
            get
            {
                if ((this.cachedAlertStatusStaticControl == null))
                {
                    this.cachedAlertStatusStaticControl = new StaticControl(this, MultipleAlertsPropertiesDialog.ControlIDs.AlertStatusStaticControl);
                }
                
                return this.cachedAlertStatusStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the KeyDetailsStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-yoz] 6/16/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMultipleAlertsPropertiesDialogControls.KeyDetailsStaticControl
        {
            get
            {
                if ((this.cachedKeyDetailsStaticControl == null))
                {
                    this.cachedKeyDetailsStaticControl = new StaticControl(this, MultipleAlertsPropertiesDialog.ControlIDs.KeyDetailsStaticControl);
                }
                
                return this.cachedKeyDetailsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OnceYouHaveIdentifiedTheProblemAndTakenCorrectiveActionYouCanSelectClosedWhichWillRemoveTheAlertFrom control
        /// </summary>
        /// <history>
        /// 	[v-yoz] 6/16/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMultipleAlertsPropertiesDialogControls.OnceYouHaveIdentifiedTheProblemAndTakenCorrectiveActionYouCanSelectClosedWhichWillRemoveTheAlertFrom
        {
            get
            {
                if ((this.cachedOnceYouHaveIdentifiedTheProblemAndTakenCorrectiveActionYouCanSelectClosedWhichWillRemoveTheAlertFrom == null))
                {
                    this.cachedOnceYouHaveIdentifiedTheProblemAndTakenCorrectiveActionYouCanSelectClosedWhichWillRemoveTheAlertFrom = new StaticControl(this, MultipleAlertsPropertiesDialog.ControlIDs.OnceYouHaveIdentifiedTheProblemAndTakenCorrectiveActionYouCanSelectClosedWhichWillRemoveTheAlertFrom);
                }
                
                return this.cachedOnceYouHaveIdentifiedTheProblemAndTakenCorrectiveActionYouCanSelectClosedWhichWillRemoveTheAlertFrom;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Apply
        /// </summary>
        /// <history>
        /// 	[v-yoz] 6/16/2009 Created
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
        /// 	[v-yoz] 6/16/2009 Created
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
        /// 	[v-yoz] 6/16/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Change
        /// </summary>
        /// <history>
        /// 	[v-yoz] 6/16/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickChange()
        {
            this.Controls.ChangeButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">App owning the dialog.</param>
        /// <history>
        /// 	[v-yoz] 6/16/2009 Created
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
                            "AlertPropertiesGeneralDialog:: Attempt " + numberOfTries + " of " + MaxTries);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "AlertPropertiesGeneralDialog:: Failed to find window with title:  '" +
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
        /// 	[v-yoz] 6/16/2009 Created
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
            private const string ResourceDialogTitle = ";Alert Properties;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.AlertPropertyDialog;$this.Text";


            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.Tr" +
                "anslucentColorPicker;buttonOk.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Apply
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceApply = ";&Apply;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.PropertyDialogForm;buttonApply.Text";
                        
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
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Apply
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedApply;
            #endregion

            #region Properties
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/20/2006 Created
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
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/20/2006 Created
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
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/20/2006 Created
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
            /// Exposes access to the Apply translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/20/2006 Created
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
            #endregion
        }
        #endregion
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[v-yoz] 6/16/2009 Created
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
            /// Control ID for Tab0TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab0TabControl = "tabPages";
            
            /// <summary>
            /// Control ID for YouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSavedStaticControl
            /// </summary>
            public const string YouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSavedStaticControl = "labelHistoryDiscription";
            
            /// <summary>
            /// Control ID for YouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSavedTextBox
            /// </summary>
            public const string YouCanAddACommentThatWillBeAddedToTheAlertHistoryWhenTheAlertIsSavedTextBox = "textboxHistory";
            
            /// <summary>
            /// Control ID for AddHistoryCommentStaticControl
            /// </summary>
            public const string AddHistoryCommentStaticControl = "labelHistory";
            
            /// <summary>
            /// Control ID for TextBox0
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string TextBox0 = "textboxTicketId";
            
            /// <summary>
            /// Control ID for TicketIDStaticControl
            /// </summary>
            public const string TicketIDStaticControl = "labelTicketId";
            
            /// <summary>
            /// Control ID for KeyDetailsTextBox
            /// </summary>
            public const string KeyDetailsTextBox = "textboxOwner";
            
            /// <summary>
            /// Control ID for ChangeButton
            /// </summary>
            public const string ChangeButton = "buttonChange";
            
            /// <summary>
            /// Control ID for AlertStatusCombo
            /// </summary>
            public const string AlertStatusCombo = "comboBoxStatus";
            
            /// <summary>
            /// Control ID for OwnerStaticControl
            /// </summary>
            public const string OwnerStaticControl = "labelOwner";
            
            /// <summary>
            /// Control ID for AlertStatusStaticControl
            /// </summary>
            public const string AlertStatusStaticControl = "labelStatus";
            
            /// <summary>
            /// Control ID for KeyDetailsStaticControl
            /// </summary>
            public const string KeyDetailsStaticControl = "labelKey";
            
            /// <summary>
            /// Control ID for OnceYouHaveIdentifiedTheProblemAndTakenCorrectiveActionYouCanSelectClosedWhichWillRemoveTheAlertFrom
            /// </summary>
            public const string OnceYouHaveIdentifiedTheProblemAndTakenCorrectiveActionYouCanSelectClosedWhichWillRemoveTheAlertFrom = "labelStatusDescription";
        }
        #endregion
    }
}
