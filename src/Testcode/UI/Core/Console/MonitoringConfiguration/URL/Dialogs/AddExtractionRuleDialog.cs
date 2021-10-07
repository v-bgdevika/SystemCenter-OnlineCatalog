// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AddExtractionRuleDialog.cs">
// 	Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[v-eryon] 7/29/2009 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.URL.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IAddExtractionRuleDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAddExtractionRuleDialogControls, for AddExtractionRuleDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[v-eryon] 7/29/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAddExtractionRuleDialogControls
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
        /// Read-only property to access ATextDelimiterThatOccursImmediatelyAfterTheTextToBeExtractedStaticControl
        /// </summary>
        StaticControl ATextDelimiterThatOccursImmediatelyAfterTheTextToBeExtractedStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EndsWithTextBox
        /// </summary>
        TextBox EndsWithTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EndsWithStaticControl
        /// </summary>
        StaticControl EndsWithStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ATextDelimiterThatOccursImmediatelyBeforeTheTextToBeExtractedStaticControl
        /// </summary>
        StaticControl ATextDelimiterThatOccursImmediatelyBeforeTheTextToBeExtractedStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StartsWithTextBox
        /// </summary>
        TextBox StartsWithTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StartsWithStaticControl
        /// </summary>
        StaticControl StartsWithStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TheNameOfATextContextVariableToAssociateWithTheExtractedValueStaticControl
        /// </summary>
        StaticControl TheNameOfATextContextVariableToAssociateWithTheExtractedValueStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ContextParameterNameTextBox
        /// </summary>
        TextBox ContextParameterNameTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ContextParameterNameStaticControl
        /// </summary>
        StaticControl ContextParameterNameStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PerformURIEncodingOfExtractedStringsCheckBox
        /// </summary>
        CheckBox PerformURIEncodingOfExtractedStringsCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access IgnoreCaseDuringSearchForMatchingTextCheckBox
        /// </summary>
        CheckBox IgnoreCaseDuringSearchForMatchingTextCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access IndicatesWhichOccurrenceOfTheStringToExtractThisIsAZeroBasedIndexStaticControl
        /// </summary>
        StaticControl IndicatesWhichOccurrenceOfTheStringToExtractThisIsAZeroBasedIndexStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access IndexTextBox
        /// </summary>
        TextBox IndexTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access IndexStaticControl
        /// </summary>
        StaticControl IndexStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HideAdvancedSettingsButton
        /// </summary>
        Button HideAdvancedSettingsButton
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
    /// 	[v-eryon] 7/29/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class AddExtractionRuleDialog : Dialog, IAddExtractionRuleDialogControls
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
        /// Cache to hold a reference to ATextDelimiterThatOccursImmediatelyAfterTheTextToBeExtractedStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedATextDelimiterThatOccursImmediatelyAfterTheTextToBeExtractedStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to EndsWithTextBox of type TextBox
        /// </summary>
        private TextBox cachedEndsWithTextBox;
        
        /// <summary>
        /// Cache to hold a reference to EndsWithStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEndsWithStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ATextDelimiterThatOccursImmediatelyBeforeTheTextToBeExtractedStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedATextDelimiterThatOccursImmediatelyBeforeTheTextToBeExtractedStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to StartsWithTextBox of type TextBox
        /// </summary>
        private TextBox cachedStartsWithTextBox;
        
        /// <summary>
        /// Cache to hold a reference to StartsWithStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedStartsWithStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to TheNameOfATextContextVariableToAssociateWithTheExtractedValueStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTheNameOfATextContextVariableToAssociateWithTheExtractedValueStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ContextParameterNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedContextParameterNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ContextParameterNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedContextParameterNameStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to PerformURIEncodingOfExtractedStringsCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedPerformURIEncodingOfExtractedStringsCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to IgnoreCaseDuringSearchForMatchingTextCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedIgnoreCaseDuringSearchForMatchingTextCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to IndicatesWhichOccurrenceOfTheStringToExtractThisIsAZeroBasedIndexStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedIndicatesWhichOccurrenceOfTheStringToExtractThisIsAZeroBasedIndexStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to IndexTextBox of type TextBox
        /// </summary>
        private TextBox cachedIndexTextBox;
        
        /// <summary>
        /// Cache to hold a reference to IndexStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedIndexStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HideAdvancedSettingsButton of type Button
        /// </summary>
        private Button cachedHideAdvancedSettingsButton;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of AddExtractionRuleDialog of type ExtractionRuleFormDialog
        /// </param>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AddExtractionRuleDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IAddExtractionRuleDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAddExtractionRuleDialogControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion
        
        #region Checkbox Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox PerformURIEncodingOfExtractedStrings
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool PerformURIEncodingOfExtractedStrings
        {
            get
            {
                return this.Controls.PerformURIEncodingOfExtractedStringsCheckBox.Checked;
            }
            
            set
            {
                this.Controls.PerformURIEncodingOfExtractedStringsCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox IgnoreCaseDuringSearchForMatchingText
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool IgnoreCaseDuringSearchForMatchingText
        {
            get
            {
                return this.Controls.IgnoreCaseDuringSearchForMatchingTextCheckBox.Checked;
            }
            
            set
            {
                this.Controls.IgnoreCaseDuringSearchForMatchingTextCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control EndsWith
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string EndsWithText
        {
            get
            {
                return this.Controls.EndsWithTextBox.Text;
            }
            
            set
            {
                this.Controls.EndsWithTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control StartsWith
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string StartsWithText
        {
            get
            {
                return this.Controls.StartsWithTextBox.Text;
            }
            
            set
            {
                this.Controls.StartsWithTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ContextParameterName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ContextParameterNameText
        {
            get
            {
                return this.Controls.ContextParameterNameTextBox.Text;
            }
            
            set
            {
                this.Controls.ContextParameterNameTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Index
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string IndexText
        {
            get
            {
                return this.Controls.IndexTextBox.Text;
            }
            
            set
            {
                this.Controls.IndexTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddExtractionRuleDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AddExtractionRuleDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddExtractionRuleDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, AddExtractionRuleDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ATextDelimiterThatOccursImmediatelyAfterTheTextToBeExtractedStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddExtractionRuleDialogControls.ATextDelimiterThatOccursImmediatelyAfterTheTextToBeExtractedStaticControl
        {
            get
            {
                if ((this.cachedATextDelimiterThatOccursImmediatelyAfterTheTextToBeExtractedStaticControl == null))
                {
                    this.cachedATextDelimiterThatOccursImmediatelyAfterTheTextToBeExtractedStaticControl = new StaticControl(this, AddExtractionRuleDialog.ControlIDs.ATextDelimiterThatOccursImmediatelyAfterTheTextToBeExtractedStaticControl);
                }
                
                return this.cachedATextDelimiterThatOccursImmediatelyAfterTheTextToBeExtractedStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EndsWithTextBox control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAddExtractionRuleDialogControls.EndsWithTextBox
        {
            get
            {
                if ((this.cachedEndsWithTextBox == null))
                {
                    this.cachedEndsWithTextBox = new TextBox(this, AddExtractionRuleDialog.ControlIDs.EndsWithTextBox);
                }
                
                return this.cachedEndsWithTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EndsWithStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddExtractionRuleDialogControls.EndsWithStaticControl
        {
            get
            {
                if ((this.cachedEndsWithStaticControl == null))
                {
                    this.cachedEndsWithStaticControl = new StaticControl(this, AddExtractionRuleDialog.ControlIDs.EndsWithStaticControl);
                }
                
                return this.cachedEndsWithStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ATextDelimiterThatOccursImmediatelyBeforeTheTextToBeExtractedStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddExtractionRuleDialogControls.ATextDelimiterThatOccursImmediatelyBeforeTheTextToBeExtractedStaticControl
        {
            get
            {
                if ((this.cachedATextDelimiterThatOccursImmediatelyBeforeTheTextToBeExtractedStaticControl == null))
                {
                    this.cachedATextDelimiterThatOccursImmediatelyBeforeTheTextToBeExtractedStaticControl = new StaticControl(this, AddExtractionRuleDialog.ControlIDs.ATextDelimiterThatOccursImmediatelyBeforeTheTextToBeExtractedStaticControl);
                }
                
                return this.cachedATextDelimiterThatOccursImmediatelyBeforeTheTextToBeExtractedStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StartsWithTextBox control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAddExtractionRuleDialogControls.StartsWithTextBox
        {
            get
            {
                if ((this.cachedStartsWithTextBox == null))
                {
                    this.cachedStartsWithTextBox = new TextBox(this, AddExtractionRuleDialog.ControlIDs.StartsWithTextBox);
                }
                
                return this.cachedStartsWithTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StartsWithStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddExtractionRuleDialogControls.StartsWithStaticControl
        {
            get
            {
                if ((this.cachedStartsWithStaticControl == null))
                {
                    this.cachedStartsWithStaticControl = new StaticControl(this, AddExtractionRuleDialog.ControlIDs.StartsWithStaticControl);
                }
                
                return this.cachedStartsWithStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TheNameOfATextContextVariableToAssociateWithTheExtractedValueStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddExtractionRuleDialogControls.TheNameOfATextContextVariableToAssociateWithTheExtractedValueStaticControl
        {
            get
            {
                if ((this.cachedTheNameOfATextContextVariableToAssociateWithTheExtractedValueStaticControl == null))
                {
                    this.cachedTheNameOfATextContextVariableToAssociateWithTheExtractedValueStaticControl = new StaticControl(this, AddExtractionRuleDialog.ControlIDs.TheNameOfATextContextVariableToAssociateWithTheExtractedValueStaticControl);
                }
                
                return this.cachedTheNameOfATextContextVariableToAssociateWithTheExtractedValueStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ContextParameterNameTextBox control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAddExtractionRuleDialogControls.ContextParameterNameTextBox
        {
            get
            {
                if ((this.cachedContextParameterNameTextBox == null))
                {
                    this.cachedContextParameterNameTextBox = new TextBox(this, AddExtractionRuleDialog.ControlIDs.ContextParameterNameTextBox);
                }
                
                return this.cachedContextParameterNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ContextParameterNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddExtractionRuleDialogControls.ContextParameterNameStaticControl
        {
            get
            {
                if ((this.cachedContextParameterNameStaticControl == null))
                {
                    this.cachedContextParameterNameStaticControl = new StaticControl(this, AddExtractionRuleDialog.ControlIDs.ContextParameterNameStaticControl);
                }
                
                return this.cachedContextParameterNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PerformURIEncodingOfExtractedStringsCheckBox control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IAddExtractionRuleDialogControls.PerformURIEncodingOfExtractedStringsCheckBox
        {
            get
            {
                if ((this.cachedPerformURIEncodingOfExtractedStringsCheckBox == null))
                {
                    this.cachedPerformURIEncodingOfExtractedStringsCheckBox = new CheckBox(this, AddExtractionRuleDialog.ControlIDs.PerformURIEncodingOfExtractedStringsCheckBox);
                }
                
                return this.cachedPerformURIEncodingOfExtractedStringsCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IgnoreCaseDuringSearchForMatchingTextCheckBox control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IAddExtractionRuleDialogControls.IgnoreCaseDuringSearchForMatchingTextCheckBox
        {
            get
            {
                if ((this.cachedIgnoreCaseDuringSearchForMatchingTextCheckBox == null))
                {
                    this.cachedIgnoreCaseDuringSearchForMatchingTextCheckBox = new CheckBox(this, AddExtractionRuleDialog.ControlIDs.IgnoreCaseDuringSearchForMatchingTextCheckBox);
                }
                
                return this.cachedIgnoreCaseDuringSearchForMatchingTextCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IndicatesWhichOccurrenceOfTheStringToExtractThisIsAZeroBasedIndexStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddExtractionRuleDialogControls.IndicatesWhichOccurrenceOfTheStringToExtractThisIsAZeroBasedIndexStaticControl
        {
            get
            {
                if ((this.cachedIndicatesWhichOccurrenceOfTheStringToExtractThisIsAZeroBasedIndexStaticControl == null))
                {
                    this.cachedIndicatesWhichOccurrenceOfTheStringToExtractThisIsAZeroBasedIndexStaticControl = new StaticControl(this, AddExtractionRuleDialog.ControlIDs.IndicatesWhichOccurrenceOfTheStringToExtractThisIsAZeroBasedIndexStaticControl);
                }
                
                return this.cachedIndicatesWhichOccurrenceOfTheStringToExtractThisIsAZeroBasedIndexStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IndexTextBox control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAddExtractionRuleDialogControls.IndexTextBox
        {
            get
            {
                if ((this.cachedIndexTextBox == null))
                {
                    this.cachedIndexTextBox = new TextBox(this, AddExtractionRuleDialog.ControlIDs.IndexTextBox);
                }

                return this.cachedIndexTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IndexStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddExtractionRuleDialogControls.IndexStaticControl
        {
            get
            {
                if ((this.cachedIndexStaticControl == null))
                {
                    this.cachedIndexStaticControl = new StaticControl(this, AddExtractionRuleDialog.ControlIDs.IndexStaticControl);
                }
                
                return this.cachedIndexStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HideAdvancedSettingsButton control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddExtractionRuleDialogControls.HideAdvancedSettingsButton
        {
            get
            {
                if ((this.cachedHideAdvancedSettingsButton == null))
                {
                    this.cachedHideAdvancedSettingsButton = new Button(this, AddExtractionRuleDialog.ControlIDs.HideAdvancedSettingsButton);
                }
                
                return this.cachedHideAdvancedSettingsButton;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
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
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button PerformURIEncodingOfExtractedStrings
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickPerformURIEncodingOfExtractedStrings()
        {
            this.Controls.PerformURIEncodingOfExtractedStringsCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button IgnoreCaseDuringSearchForMatchingText
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickIgnoreCaseDuringSearchForMatchingText()
        {
            this.Controls.IgnoreCaseDuringSearchForMatchingTextCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button HideAdvancedSettings
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickHideAdvancedSettings()
        {
            this.Controls.HideAdvancedSettingsButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">ExtractionRuleFormDialog owning the dialog.</param>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(app.GetIntlStr(Strings.DialogTitle), StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
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
                        tempWindow = new Window(app.GetIntlStr(Strings.DialogTitle), StringMatchSyntax.WildCard);

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
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// <summary>
            /// Resource string for Add Extraction Rule
            /// </summary>
            // Add Extraction Rule
            public const string ResourceDialogTitle = ";Add Extraction Rule;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dl" +
                "l;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.ExtractionRuleForm" +
                ";$this.Text";
            
            /// <summary>
            /// Resource string for Cancel
            /// </summary>
            // C&ancel
            public const string Cancel = ";C&ancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft." +
                "EnterpriseManagement.Internal.UI.Authoring.WebApp.ExtractionRuleForm;buttonCance" +
                "l.Text";
            
            /// <summary>
            /// Resource string for OK
            /// </summary>
            // &OK
            public const string OK = ";&OK;ManagedString;Corgent.Diagramming.Dom.dll;Corgent.Diagramming.Dom.DiagramTem" +
                "plateProperties;okButton.Text";
            
            /// <summary>
            /// Resource string for A text delimiter that occurs immediately after the text to be extracted
            /// </summary>
            // A text delimiter that occurs immediately after the text to be extracted
            public const string ATextDelimiterThatOccursImmediatelyAfterTheTextToBeExtracted = ";A text delimiter that occurs immediately after the text to be extracted;ManagedS" +
                "tring;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManage" +
                "ment.Internal.UI.Authoring.WebApp.ExtractionRuleForm;endStringDescription.Text";
            
            /// <summary>
            /// Resource string for Ends with:
            /// </summary>
            // &Ends with:
            public const string EndsWith = ";&Ends with:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micros" +
                "oft.EnterpriseManagement.Internal.UI.Authoring.WebApp.ExtractionRuleForm;endStri" +
                "ng.Text";
            
            /// <summary>
            /// Resource string for A text delimiter that occurs immediately before the text to be extracted
            /// </summary>
            // A text delimiter that occurs immediately before the text to be extracted
            public const string ATextDelimiterThatOccursImmediatelyBeforeTheTextToBeExtracted = ";A text delimiter that occurs immediately before the text to be extracted;Managed" +
                "String;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManag" +
                "ement.Internal.UI.Authoring.WebApp.ExtractionRuleForm;startStringDescription.Tex" +
                "t";
            
            /// <summary>
            /// Resource string for Starts with:
            /// </summary>
            // &Starts with:
            public const string StartsWith = ";&Starts with:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micr" +
                "osoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.ExtractionRuleForm;start" +
                "String.Text";
            
            /// <summary>
            /// Resource string for The name of a text context variable to associate with the extracted value
            /// </summary>
            // The name of a text context variable to associate with the extracted value
            public const string TheNameOfATextContextVariableToAssociateWithTheExtractedValue = ";The name of a text context variable to associate with the extracted value;Manage" +
                "dString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseMana" +
                "gement.Internal.UI.Authoring.WebApp.ExtractionRuleForm;parameterNameDescription." +
                "Text";
            
            /// <summary>
            /// Resource string for Context parameter name:
            /// </summary>
            // &Context parameter name:
            public const string ContextParameterName = ";&Context parameter name:;ManagedString;Microsoft.EnterpriseManagement.UI.Authori" +
                "ng.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.ExtractionRul" +
                "eForm;parameterName.Text";
            
            /// <summary>
            /// Resource string for Perform URI encoding of extracted strings
            /// </summary>
            // &Perform URI encoding of extracted strings
            public const string PerformURIEncodingOfExtractedStrings = ";&Perform URI encoding of extracted strings;ManagedString;Microsoft.EnterpriseMan" +
                "agement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.We" +
                "bApp.ExtractionRuleForm;checkBoxURIencoding.Text";
            
            /// <summary>
            /// Resource string for Ignore case during search for matching text
            /// </summary>
            // I&gnore case during search for matching text
            public const string IgnoreCaseDuringSearchForMatchingText = ";I&gnore case during search for matching text;ManagedString;Microsoft.EnterpriseM" +
                "anagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring." +
                "WebApp.ExtractionRuleForm;checkBoxIgnoreCase.Text";
            
            /// <summary>
            /// Resource string for Indicates which occurrence of the string to extract. This is a zero-based index.
            /// </summary>
            // Indicates which occurrence of the string to extract. This is a zero-based index.
            public const string IndicatesWhichOccurrenceOfTheStringToExtractThisIsAZeroBasedIndex = ";Indicates which occurrence of the string to extract. This is a zero-based index." +
                ";ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.Enterpr" +
                "iseManagement.Internal.UI.Authoring.WebApp.ExtractionRuleForm;labelIndexDescript" +
                "ion.Text";
            
            /// <summary>
            /// Resource string for Index:
            /// </summary>
            // I&ndex:
            public const string Index = ";I&ndex:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft." +
                "EnterpriseManagement.Internal.UI.Authoring.WebApp.ExtractionRuleForm;labelIndex." +
                "Text";
            
            /// <summary>
            /// Resource string for Hide advanced settings
            /// </summary>
            // << Hide ad&vanced settings
            public const string HideAdvancedSettings = ";<< Hide ad&vanced settings;ManagedString;Microsoft.EnterpriseManagement.UI.Autho" +
                "ring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.WebApplicat" +
                "ionResources;ExtractionRuleHideAdvancedSetting";

            #endregion

            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitle;

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[v-eryon] 7/29/2009 Created
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

            #endregion
        }
        #endregion
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/29/2009 Created
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
            public const string OKButton = "buttonOk";
            
            /// <summary>
            /// Control ID for ATextDelimiterThatOccursImmediatelyAfterTheTextToBeExtractedStaticControl
            /// </summary>
            public const string ATextDelimiterThatOccursImmediatelyAfterTheTextToBeExtractedStaticControl = "endStringDescription";
            
            /// <summary>
            /// Control ID for EndsWithTextBox
            /// </summary>
            public const string EndsWithTextBox = "endStringTextbox";
            
            /// <summary>
            /// Control ID for EndsWithStaticControl
            /// </summary>
            public const string EndsWithStaticControl = "endString";
            
            /// <summary>
            /// Control ID for ATextDelimiterThatOccursImmediatelyBeforeTheTextToBeExtractedStaticControl
            /// </summary>
            public const string ATextDelimiterThatOccursImmediatelyBeforeTheTextToBeExtractedStaticControl = "startStringDescription";
            
            /// <summary>
            /// Control ID for StartsWithTextBox
            /// </summary>
            public const string StartsWithTextBox = "startStringTextbox";
            
            /// <summary>
            /// Control ID for StartsWithStaticControl
            /// </summary>
            public const string StartsWithStaticControl = "startString";
            
            /// <summary>
            /// Control ID for TheNameOfATextContextVariableToAssociateWithTheExtractedValueStaticControl
            /// </summary>
            public const string TheNameOfATextContextVariableToAssociateWithTheExtractedValueStaticControl = "parameterNameDescription";
            
            /// <summary>
            /// Control ID for ContextParameterNameTextBox
            /// </summary>
            public const string ContextParameterNameTextBox = "parameterNameTextBox";
            
            /// <summary>
            /// Control ID for ContextParameterNameStaticControl
            /// </summary>
            public const string ContextParameterNameStaticControl = "parameterName";
            
            /// <summary>
            /// Control ID for PerformURIEncodingOfExtractedStringsCheckBox
            /// </summary>
            public const string PerformURIEncodingOfExtractedStringsCheckBox = "checkBoxURIencoding";
            
            /// <summary>
            /// Control ID for IgnoreCaseDuringSearchForMatchingTextCheckBox
            /// </summary>
            public const string IgnoreCaseDuringSearchForMatchingTextCheckBox = "checkBoxIgnoreCase";
            
            /// <summary>
            /// Control ID for IndicatesWhichOccurrenceOfTheStringToExtractThisIsAZeroBasedIndexStaticControl
            /// </summary>
            public const string IndicatesWhichOccurrenceOfTheStringToExtractThisIsAZeroBasedIndexStaticControl = "labelIndexDescription";
            
            /// <summary>
            /// Control ID for IndexTextBox
            /// </summary>
            public const string IndexTextBox = "numericUpDownIndex";
            
            /// <summary>
            /// Control ID for IndexStaticControl
            /// </summary>
            public const string IndexStaticControl = "labelIndex";
            
            /// <summary>
            /// Control ID for HideAdvancedSettingsButton
            /// </summary>
            public const string HideAdvancedSettingsButton = "buttonAdvancedSetting";
        }
        #endregion
    }
}
