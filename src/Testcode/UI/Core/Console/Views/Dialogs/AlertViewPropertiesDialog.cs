// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AlertViewPropertiesDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[lucyra] 2/8/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.Dialogs
{
    #region Using directives
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using System.Collections;
    using System.Drawing;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console;
    #endregion

    #region Interface Definition - IAlertViewPropertiesDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAlertViewPropertiesDialogControls, for AlertViewPropertiesDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[lucyra] 2/8/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAlertViewPropertiesDialogControls
    {
        /// <summary>
        /// Read-only property to access OKButton
        /// </summary>
        Button OKButton
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
        /// Read-only property to access NameTextBox
        /// </summary>
        TextBox NameTextBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access DescriptionTextBox
        /// </summary>
        TextBox DescriptionTextBox
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
        /// Read-only property to access ShowDataContainedInASpecificGroupStaticControl
        /// </summary>
        StaticControl ShowDataContainedInASpecificGroupStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access Ellipsis27Button
        /// </summary>
        Button Ellipsis27Button
        {
            get;
        }

        /// <summary>
        /// Read-only property to access Ellipsis28Button
        /// </summary>
        Button Ellipsis28Button
        {
            get;
        }

        /// <summary>
        /// Read-only property to access NoneStaticControl
        /// </summary>
        StaticControl NoneStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access EntityStaticControl
        /// </summary>
        StaticControl EntityStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ShowDataRelatedToStaticControl
        /// </summary>
        StaticControl ShowDataRelatedToStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ShowDataContainedInASpecificGroupListBox
        /// </summary>
        ListBox ShowDataContainedInASpecificGroupListBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl
        /// </summary>
        StaticControl CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ViewAllAlertsStaticControl
        /// </summary>
        StaticControl ViewAllAlertsStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access OfASpecificSeverityStaticControl
        /// </summary>
        StaticControl OfASpecificSeverityStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AndOfASpecificPriorityStaticControl
        /// </summary>
        StaticControl AndOfASpecificPriorityStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AndWithASpecificCategoryStaticControl
        /// </summary>
        StaticControl AndWithASpecificCategoryStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AndWithSpecificResolutionStateStaticControl
        /// </summary>
        StaticControl AndWithSpecificResolutionStateStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AndWithASpecificNameStaticControl
        /// </summary>
        StaticControl AndWithASpecificNameStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AndWithSpecificTextInTheDescriptionStaticControl
        /// </summary>
        StaticControl AndWithSpecificTextInTheDescriptionStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AndCreatedInSpecificTimePeriodStaticControl
        /// </summary>
        StaticControl AndCreatedInSpecificTimePeriodStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AndAssignedToASpecificPersonStaticControl
        /// </summary>
        StaticControl AndAssignedToASpecificPersonStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AndRaisedByAnyInstanceOfASpecificClassStaticControl
        /// </summary>
        StaticControl AndRaisedByAnyInstanceOfASpecificClassStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AndRaisedByAnInstanceWithASpecificNameStaticControl
        /// </summary>
        StaticControl AndRaisedByAnInstanceWithASpecificNameStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AndLastModifiedByASpecificUserStaticControl
        /// </summary>
        StaticControl AndLastModifiedByASpecificUserStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AndThatWasModifiedInASpecificTimePeriodStaticControl
        /// </summary>
        StaticControl AndThatWasModifiedInASpecificTimePeriodStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AndCreatedInSpecificTimePeriodStaticControl2
        /// </summary>
        StaticControl AndCreatedInSpecificTimePeriodStaticControl2
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AndCreatedInASpecificTimePeriodStaticControl
        /// </summary>
        StaticControl AndCreatedInASpecificTimePeriodStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AndResolvedBySpecificUserStaticControl
        /// </summary>
        StaticControl AndResolvedBySpecificUserStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AndWasAddedToTheDatabaseInASpecificTimePeriodStaticControl
        /// </summary>
        StaticControl AndWasAddedToTheDatabaseInASpecificTimePeriodStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AndWithASpecificRuleIDStaticControl
        /// </summary>
        StaticControl AndWithASpecificRuleIDStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AndWithASpecificSpecificIDStaticControl
        /// </summary>
        StaticControl AndWithASpecificSpecificIDStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AndWithSpecificTextInCustomField1StaticControl
        /// </summary>
        StaticControl AndWithSpecificTextInCustomField1StaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AndWithSpecificTextInCustomField2StaticControl
        /// </summary>
        StaticControl AndWithSpecificTextInCustomField2StaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AndWithSpecificTextInCustomField3StaticControl
        /// </summary>
        StaticControl AndWithSpecificTextInCustomField3StaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AndWithSpecificTextInCustomField4StaticControl
        /// </summary>
        StaticControl AndWithSpecificTextInCustomField4StaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AndWithSpecificTextInCustomField5StaticControl
        /// </summary>
        StaticControl AndWithSpecificTextInCustomField5StaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access DescriptionStaticControl
        /// </summary>
        StaticControl DescriptionStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access NameStaticControl
        /// </summary>
        StaticControl NameStaticControl
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
    /// 	[lucyra] 2/8/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class AlertViewPropertiesDialog : Dialog, IAlertViewPropertiesDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        
        #endregion

        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;

        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;

        /// <summary>
        /// Cache to hold a reference to NameTextBox of type TextBox
        /// </summary>
        private TextBox cachedNameTextBox;

        /// <summary>
        /// Cache to hold a reference to DescriptionTextBox of type TextBox
        /// </summary>
        private TextBox cachedDescriptionTextBox;

        /// <summary>
        /// Cache to hold a reference to Tab0TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab0TabControl;

        /// <summary>
        /// Cache to hold a reference to ShowDataContainedInASpecificGroupStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedShowDataContainedInASpecificGroupStaticControl;

        /// <summary>
        /// Cache to hold a reference to Ellipsis27Button of type Button
        /// </summary>
        private Button cachedEllipsis27Button;

        /// <summary>
        /// Cache to hold a reference to Ellipsis28Button of type Button
        /// </summary>
        private Button cachedEllipsis28Button;

        /// <summary>
        /// Cache to hold a reference to NoneStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNoneStaticControl;

        /// <summary>
        /// Cache to hold a reference to EntityStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEntityStaticControl;

        /// <summary>
        /// Cache to hold a reference to ShowDataRelatedToStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedShowDataRelatedToStaticControl;

        /// <summary>
        /// Cache to hold a reference to ShowDataContainedInASpecificGroupListBox of type ListBox
        /// </summary>
        private ListBox cachedShowDataContainedInASpecificGroupListBox;

        /// <summary>
        /// Cache to hold a reference to CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCriteriaDescriptionClickTheUnderlinedValueToEditStaticControl;

        /// <summary>
        /// Cache to hold a reference to ViewAllAlertsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedViewAllAlertsStaticControl;

        /// <summary>
        /// Cache to hold a reference to OfASpecificSeverityStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedOfASpecificSeverityStaticControl;

        /// <summary>
        /// Cache to hold a reference to AndOfASpecificPriorityStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAndOfASpecificPriorityStaticControl;

        /// <summary>
        /// Cache to hold a reference to AndWithASpecificCategoryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAndWithASpecificCategoryStaticControl;

        /// <summary>
        /// Cache to hold a reference to AndWithSpecificResolutionStateStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAndWithSpecificResolutionStateStaticControl;

        /// <summary>
        /// Cache to hold a reference to AndWithASpecificNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAndWithASpecificNameStaticControl;

        /// <summary>
        /// Cache to hold a reference to AndWithSpecificTextInTheDescriptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAndWithSpecificTextInTheDescriptionStaticControl;

        /// <summary>
        /// Cache to hold a reference to AndCreatedInSpecificTimePeriodStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAndCreatedInSpecificTimePeriodStaticControl;

        /// <summary>
        /// Cache to hold a reference to AndAssignedToASpecificPersonStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAndAssignedToASpecificPersonStaticControl;

        /// <summary>
        /// Cache to hold a reference to AndRaisedByAnyInstanceOfASpecificClassStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAndRaisedByAnyInstanceOfASpecificClassStaticControl;

        /// <summary>
        /// Cache to hold a reference to AndRaisedByAnInstanceWithASpecificNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAndRaisedByAnInstanceWithASpecificNameStaticControl;

        /// <summary>
        /// Cache to hold a reference to AndLastModifiedByASpecificUserStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAndLastModifiedByASpecificUserStaticControl;

        /// <summary>
        /// Cache to hold a reference to AndThatWasModifiedInASpecificTimePeriodStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAndThatWasModifiedInASpecificTimePeriodStaticControl;

        /// <summary>
        /// Cache to hold a reference to AndCreatedInSpecificTimePeriodStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedAndCreatedInSpecificTimePeriodStaticControl2;

        /// <summary>
        /// Cache to hold a reference to AndCreatedInASpecificTimePeriodStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAndCreatedInASpecificTimePeriodStaticControl;

        /// <summary>
        /// Cache to hold a reference to AndResolvedBySpecificUserStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAndResolvedBySpecificUserStaticControl;

        /// <summary>
        /// Cache to hold a reference to AndWasAddedToTheDatabaseInASpecificTimePeriodStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAndWasAddedToTheDatabaseInASpecificTimePeriodStaticControl;

        /// <summary>
        /// Cache to hold a reference to AndWithASpecificRuleIDStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAndWithASpecificRuleIDStaticControl;

        /// <summary>
        /// Cache to hold a reference to AndWithASpecificSpecificIDStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAndWithASpecificSpecificIDStaticControl;

        /// <summary>
        /// Cache to hold a reference to AndWithSpecificTextInCustomField1StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAndWithSpecificTextInCustomField1StaticControl;

        /// <summary>
        /// Cache to hold a reference to AndWithSpecificTextInCustomField2StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAndWithSpecificTextInCustomField2StaticControl;

        /// <summary>
        /// Cache to hold a reference to AndWithSpecificTextInCustomField3StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAndWithSpecificTextInCustomField3StaticControl;

        /// <summary>
        /// Cache to hold a reference to AndWithSpecificTextInCustomField4StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAndWithSpecificTextInCustomField4StaticControl;

        /// <summary>
        /// Cache to hold a reference to AndWithSpecificTextInCustomField5StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAndWithSpecificTextInCustomField5StaticControl;

        /// <summary>
        /// Cache to hold a reference to DescriptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDescriptionStaticControl;

        /// <summary>
        /// Cache to hold a reference to NameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNameStaticControl;
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of AlertViewPropertiesDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AlertViewPropertiesDialog(ConsoleApp app)
            :
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion

        #region IAlertViewPropertiesDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAlertViewPropertiesDialogControls Controls
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
        ///  Routine to set/get the text in control Name
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string NameText
        {
            get
            {
                return this.Controls.NameTextBox.Text;
            }

            set
            {
                this.Controls.NameTextBox.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Name2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DescriptionText
        {
            get
            {
                return this.Controls.DescriptionTextBox.Text;
            }

            set
            {
                this.Controls.DescriptionTextBox.Text = value;
            }
        }
        #endregion

        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertViewPropertiesDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, AlertViewPropertiesDialog.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertViewPropertiesDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AlertViewPropertiesDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameTextBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAlertViewPropertiesDialogControls.NameTextBox
        {
            get
            {
                if ((this.cachedNameTextBox == null))
                {
                    this.cachedNameTextBox = new TextBox(this, AlertViewPropertiesDialog.ControlIDs.NameTextBox);
                }
                return this.cachedNameTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionTextBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAlertViewPropertiesDialogControls.DescriptionTextBox
        {
            get
            {
                if ((this.cachedDescriptionTextBox == null))
                {
                    this.cachedDescriptionTextBox = new TextBox(this, AlertViewPropertiesDialog.ControlIDs.DescriptionTextBox);
                }
                return this.cachedDescriptionTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab0TabControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IAlertViewPropertiesDialogControls.Tab0TabControl
        {
            get
            {
                if ((this.cachedTab0TabControl == null))
                {
                    this.cachedTab0TabControl = new TabControl(this, AlertViewPropertiesDialog.ControlIDs.Tab0TabControl);
                }
                return this.cachedTab0TabControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ShowDataContainedInASpecificGroupStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertViewPropertiesDialogControls.ShowDataContainedInASpecificGroupStaticControl
        {
            get
            {
                if ((this.cachedShowDataContainedInASpecificGroupStaticControl == null))
                {
                    this.cachedShowDataContainedInASpecificGroupStaticControl = new StaticControl(this/*, AlertViewPropertiesDialog.ControlIDs.ShowDataContainedInASpecificGroupStaticControl*/);
                }
                return this.cachedShowDataContainedInASpecificGroupStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Ellipsis27Button control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertViewPropertiesDialogControls.Ellipsis27Button
        {
            get
            {
                if ((this.cachedEllipsis27Button == null))
                {
                    this.cachedEllipsis27Button = new Button(this, AlertViewPropertiesDialog.ControlIDs.Ellipsis27Button);
                }
                return this.cachedEllipsis27Button;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Ellipsis28Button control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertViewPropertiesDialogControls.Ellipsis28Button
        {
            get
            {
                if ((this.cachedEllipsis28Button == null))
                {
                    this.cachedEllipsis28Button = new Button(this, AlertViewPropertiesDialog.ControlIDs.Ellipsis28Button);
                }
                return this.cachedEllipsis28Button;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NoneStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertViewPropertiesDialogControls.NoneStaticControl
        {
            get
            {
                if ((this.cachedNoneStaticControl == null))
                {
                    this.cachedNoneStaticControl = new StaticControl(this/*, AlertViewPropertiesDialog.ControlIDs.NoneStaticControl*/);
                }
                return this.cachedNoneStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EntityStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertViewPropertiesDialogControls.EntityStaticControl
        {
            get
            {
                if ((this.cachedEntityStaticControl == null))
                {
                    this.cachedEntityStaticControl = new StaticControl(this/*, AlertViewPropertiesDialog.ControlIDs.EntityStaticControl*/);
                }
                return this.cachedEntityStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ShowDataRelatedToStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertViewPropertiesDialogControls.ShowDataRelatedToStaticControl
        {
            get
            {
                if ((this.cachedShowDataRelatedToStaticControl == null))
                {
                    this.cachedShowDataRelatedToStaticControl = new StaticControl(this/*, AlertViewPropertiesDialog.ControlIDs.ShowDataRelatedToStaticControl*/);
                }
                return this.cachedShowDataRelatedToStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ShowDataContainedInASpecificGroupListBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListBox IAlertViewPropertiesDialogControls.ShowDataContainedInASpecificGroupListBox
        {
            get
            {
                if ((this.cachedShowDataContainedInASpecificGroupListBox == null))
                {
                    this.cachedShowDataContainedInASpecificGroupListBox = new ListBox(this, AlertViewPropertiesDialog.ControlIDs.ShowDataContainedInASpecificGroupListBox);
                }
                return this.cachedShowDataContainedInASpecificGroupListBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertViewPropertiesDialogControls.CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl
        {
            get
            {
                if ((this.cachedCriteriaDescriptionClickTheUnderlinedValueToEditStaticControl == null))
                {
                    this.cachedCriteriaDescriptionClickTheUnderlinedValueToEditStaticControl = new StaticControl(this/*, AlertViewPropertiesDialog.ControlIDs.CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl*/);
                }
                return this.cachedCriteriaDescriptionClickTheUnderlinedValueToEditStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ViewAllAlertsStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertViewPropertiesDialogControls.ViewAllAlertsStaticControl
        {
            get
            {
                if ((this.cachedViewAllAlertsStaticControl == null))
                {
                    this.cachedViewAllAlertsStaticControl = new StaticControl(this/*, AlertViewPropertiesDialog.ControlIDs.ViewAllAlertsStaticControl*/);
                }
                return this.cachedViewAllAlertsStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OfASpecificSeverityStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertViewPropertiesDialogControls.OfASpecificSeverityStaticControl
        {
            get
            {
                if ((this.cachedOfASpecificSeverityStaticControl == null))
                {
                    this.cachedOfASpecificSeverityStaticControl = new StaticControl(this/*, AlertViewPropertiesDialog.ControlIDs.OfASpecificSeverityStaticControl*/);
                }
                return this.cachedOfASpecificSeverityStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AndOfASpecificPriorityStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertViewPropertiesDialogControls.AndOfASpecificPriorityStaticControl
        {
            get
            {
                if ((this.cachedAndOfASpecificPriorityStaticControl == null))
                {
                    this.cachedAndOfASpecificPriorityStaticControl = new StaticControl(this/*, AlertViewPropertiesDialog.ControlIDs.AndOfASpecificPriorityStaticControl*/);
                }
                return this.cachedAndOfASpecificPriorityStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AndWithASpecificCategoryStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertViewPropertiesDialogControls.AndWithASpecificCategoryStaticControl
        {
            get
            {
                if ((this.cachedAndWithASpecificCategoryStaticControl == null))
                {
                    this.cachedAndWithASpecificCategoryStaticControl = new StaticControl(this/*, AlertViewPropertiesDialog.ControlIDs.AndWithASpecificCategoryStaticControl*/);
                }
                return this.cachedAndWithASpecificCategoryStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AndWithSpecificResolutionStateStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertViewPropertiesDialogControls.AndWithSpecificResolutionStateStaticControl
        {
            get
            {
                if ((this.cachedAndWithSpecificResolutionStateStaticControl == null))
                {
                    this.cachedAndWithSpecificResolutionStateStaticControl = new StaticControl(this/*, AlertViewPropertiesDialog.ControlIDs.AndWithSpecificResolutionStateStaticControl*/);
                }
                return this.cachedAndWithSpecificResolutionStateStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AndWithASpecificNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertViewPropertiesDialogControls.AndWithASpecificNameStaticControl
        {
            get
            {
                if ((this.cachedAndWithASpecificNameStaticControl == null))
                {
                    this.cachedAndWithASpecificNameStaticControl = new StaticControl(this/*, AlertViewPropertiesDialog.ControlIDs.AndWithASpecificNameStaticControl*/);
                }
                return this.cachedAndWithASpecificNameStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AndWithSpecificTextInTheDescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertViewPropertiesDialogControls.AndWithSpecificTextInTheDescriptionStaticControl
        {
            get
            {
                if ((this.cachedAndWithSpecificTextInTheDescriptionStaticControl == null))
                {
                    this.cachedAndWithSpecificTextInTheDescriptionStaticControl = new StaticControl(this/*, AlertViewPropertiesDialog.ControlIDs.AndWithSpecificTextInTheDescriptionStaticControl*/);
                }
                return this.cachedAndWithSpecificTextInTheDescriptionStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AndCreatedInSpecificTimePeriodStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertViewPropertiesDialogControls.AndCreatedInSpecificTimePeriodStaticControl
        {
            get
            {
                if ((this.cachedAndCreatedInSpecificTimePeriodStaticControl == null))
                {
                    this.cachedAndCreatedInSpecificTimePeriodStaticControl = new StaticControl(this/*, AlertViewPropertiesDialog.ControlIDs.AndCreatedInSpecificTimePeriodStaticControl*/);
                }
                return this.cachedAndCreatedInSpecificTimePeriodStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AndAssignedToASpecificPersonStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertViewPropertiesDialogControls.AndAssignedToASpecificPersonStaticControl
        {
            get
            {
                if ((this.cachedAndAssignedToASpecificPersonStaticControl == null))
                {
                    this.cachedAndAssignedToASpecificPersonStaticControl = new StaticControl(this/*, AlertViewPropertiesDialog.ControlIDs.AndAssignedToASpecificPersonStaticControl*/);
                }
                return this.cachedAndAssignedToASpecificPersonStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AndRaisedByAnyInstanceOfASpecificClassStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertViewPropertiesDialogControls.AndRaisedByAnyInstanceOfASpecificClassStaticControl
        {
            get
            {
                if ((this.cachedAndRaisedByAnyInstanceOfASpecificClassStaticControl == null))
                {
                    this.cachedAndRaisedByAnyInstanceOfASpecificClassStaticControl = new StaticControl(this/*, AlertViewPropertiesDialog.ControlIDs.AndRaisedByAnyInstanceOfASpecificClassStaticControl*/);
                }
                return this.cachedAndRaisedByAnyInstanceOfASpecificClassStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AndRaisedByAnInstanceWithASpecificNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertViewPropertiesDialogControls.AndRaisedByAnInstanceWithASpecificNameStaticControl
        {
            get
            {
                if ((this.cachedAndRaisedByAnInstanceWithASpecificNameStaticControl == null))
                {
                    this.cachedAndRaisedByAnInstanceWithASpecificNameStaticControl = new StaticControl(this/*, AlertViewPropertiesDialog.ControlIDs.AndRaisedByAnInstanceWithASpecificNameStaticControl*/);
                }
                return this.cachedAndRaisedByAnInstanceWithASpecificNameStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AndLastModifiedByASpecificUserStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertViewPropertiesDialogControls.AndLastModifiedByASpecificUserStaticControl
        {
            get
            {
                if ((this.cachedAndLastModifiedByASpecificUserStaticControl == null))
                {
                    this.cachedAndLastModifiedByASpecificUserStaticControl = new StaticControl(this/*, AlertViewPropertiesDialog.ControlIDs.AndLastModifiedByASpecificUserStaticControl*/);
                }
                return this.cachedAndLastModifiedByASpecificUserStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AndThatWasModifiedInASpecificTimePeriodStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertViewPropertiesDialogControls.AndThatWasModifiedInASpecificTimePeriodStaticControl
        {
            get
            {
                if ((this.cachedAndThatWasModifiedInASpecificTimePeriodStaticControl == null))
                {
                    this.cachedAndThatWasModifiedInASpecificTimePeriodStaticControl = new StaticControl(this/*, AlertViewPropertiesDialog.ControlIDs.AndThatWasModifiedInASpecificTimePeriodStaticControl*/);
                }
                return this.cachedAndThatWasModifiedInASpecificTimePeriodStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AndCreatedInSpecificTimePeriodStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertViewPropertiesDialogControls.AndCreatedInSpecificTimePeriodStaticControl2
        {
            get
            {
                if ((this.cachedAndCreatedInSpecificTimePeriodStaticControl2 == null))
                {
                    this.cachedAndCreatedInSpecificTimePeriodStaticControl2 = new StaticControl(this/*, AlertViewPropertiesDialog.ControlIDs.AndCreatedInSpecificTimePeriodStaticControl2*/);
                }
                return this.cachedAndCreatedInSpecificTimePeriodStaticControl2;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AndCreatedInASpecificTimePeriodStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertViewPropertiesDialogControls.AndCreatedInASpecificTimePeriodStaticControl
        {
            get
            {
                if ((this.cachedAndCreatedInASpecificTimePeriodStaticControl == null))
                {
                    this.cachedAndCreatedInASpecificTimePeriodStaticControl = new StaticControl(this/*, AlertViewPropertiesDialog.ControlIDs.AndCreatedInASpecificTimePeriodStaticControl*/);
                }
                return this.cachedAndCreatedInASpecificTimePeriodStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AndResolvedBySpecificUserStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertViewPropertiesDialogControls.AndResolvedBySpecificUserStaticControl
        {
            get
            {
                if ((this.cachedAndResolvedBySpecificUserStaticControl == null))
                {
                    this.cachedAndResolvedBySpecificUserStaticControl = new StaticControl(this/*, AlertViewPropertiesDialog.ControlIDs.AndResolvedBySpecificUserStaticControl*/);
                }
                return this.cachedAndResolvedBySpecificUserStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AndWasAddedToTheDatabaseInASpecificTimePeriodStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertViewPropertiesDialogControls.AndWasAddedToTheDatabaseInASpecificTimePeriodStaticControl
        {
            get
            {
                if ((this.cachedAndWasAddedToTheDatabaseInASpecificTimePeriodStaticControl == null))
                {
                    this.cachedAndWasAddedToTheDatabaseInASpecificTimePeriodStaticControl = new StaticControl(this/*, AlertViewPropertiesDialog.ControlIDs.AndWasAddedToTheDatabaseInASpecificTimePeriodStaticControl*/);
                }
                return this.cachedAndWasAddedToTheDatabaseInASpecificTimePeriodStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AndWithASpecificRuleIDStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertViewPropertiesDialogControls.AndWithASpecificRuleIDStaticControl
        {
            get
            {
                if ((this.cachedAndWithASpecificRuleIDStaticControl == null))
                {
                    this.cachedAndWithASpecificRuleIDStaticControl = new StaticControl(this/*, AlertViewPropertiesDialog.ControlIDs.AndWithASpecificRuleIDStaticControl*/);
                }
                return this.cachedAndWithASpecificRuleIDStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AndWithASpecificSpecificIDStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertViewPropertiesDialogControls.AndWithASpecificSpecificIDStaticControl
        {
            get
            {
                if ((this.cachedAndWithASpecificSpecificIDStaticControl == null))
                {
                    this.cachedAndWithASpecificSpecificIDStaticControl = new StaticControl(this/*, AlertViewPropertiesDialog.ControlIDs.AndWithASpecificSpecificIDStaticControl*/);
                }
                return this.cachedAndWithASpecificSpecificIDStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AndWithSpecificTextInCustomField1StaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertViewPropertiesDialogControls.AndWithSpecificTextInCustomField1StaticControl
        {
            get
            {
                if ((this.cachedAndWithSpecificTextInCustomField1StaticControl == null))
                {
                    this.cachedAndWithSpecificTextInCustomField1StaticControl = new StaticControl(this/*, AlertViewPropertiesDialog.ControlIDs.AndWithSpecificTextInCustomField1StaticControl*/);
                }
                return this.cachedAndWithSpecificTextInCustomField1StaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AndWithSpecificTextInCustomField2StaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertViewPropertiesDialogControls.AndWithSpecificTextInCustomField2StaticControl
        {
            get
            {
                if ((this.cachedAndWithSpecificTextInCustomField2StaticControl == null))
                {
                    this.cachedAndWithSpecificTextInCustomField2StaticControl = new StaticControl(this/*, AlertViewPropertiesDialog.ControlIDs.AndWithSpecificTextInCustomField2StaticControl*/);
                }
                return this.cachedAndWithSpecificTextInCustomField2StaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AndWithSpecificTextInCustomField3StaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertViewPropertiesDialogControls.AndWithSpecificTextInCustomField3StaticControl
        {
            get
            {
                if ((this.cachedAndWithSpecificTextInCustomField3StaticControl == null))
                {
                    this.cachedAndWithSpecificTextInCustomField3StaticControl = new StaticControl(this/*, AlertViewPropertiesDialog.ControlIDs.AndWithSpecificTextInCustomField3StaticControl*/);
                }
                return this.cachedAndWithSpecificTextInCustomField3StaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AndWithSpecificTextInCustomField4StaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertViewPropertiesDialogControls.AndWithSpecificTextInCustomField4StaticControl
        {
            get
            {
                if ((this.cachedAndWithSpecificTextInCustomField4StaticControl == null))
                {
                    this.cachedAndWithSpecificTextInCustomField4StaticControl = new StaticControl(this/*, AlertViewPropertiesDialog.ControlIDs.AndWithSpecificTextInCustomField4StaticControl*/);
                }
                return this.cachedAndWithSpecificTextInCustomField4StaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AndWithSpecificTextInCustomField5StaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertViewPropertiesDialogControls.AndWithSpecificTextInCustomField5StaticControl
        {
            get
            {
                if ((this.cachedAndWithSpecificTextInCustomField5StaticControl == null))
                {
                    this.cachedAndWithSpecificTextInCustomField5StaticControl = new StaticControl(this/*, AlertViewPropertiesDialog.ControlIDs.AndWithSpecificTextInCustomField5StaticControl*/);
                }
                return this.cachedAndWithSpecificTextInCustomField5StaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertViewPropertiesDialogControls.DescriptionStaticControl
        {
            get
            {
                if ((this.cachedDescriptionStaticControl == null))
                {
                    this.cachedDescriptionStaticControl = new StaticControl(this/*, AlertViewPropertiesDialog.ControlIDs.DescriptionStaticControl*/);
                }
                return this.cachedDescriptionStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertViewPropertiesDialogControls.NameStaticControl
        {
            get
            {
                if ((this.cachedNameStaticControl == null))
                {
                    this.cachedNameStaticControl = new StaticControl(this/*, AlertViewPropertiesDialog.ControlIDs.NameStaticControl*/);
                }
                return this.cachedNameStaticControl;
            }
        }
        #endregion

        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
            UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow);
            CoreManager.MomConsole.MainWindow.WaitForResponse();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Ellipsis27
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEllipsis27()
        {
            this.Controls.Ellipsis27Button.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Ellipsis28
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEllipsis28()
        {
            this.Controls.Ellipsis28Button.Click();
        }
        #endregion

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">ConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(
                    Strings.DialogTitle,
                    StringMatchSyntax.ExactMatch,
                    WindowClassNames.WinForms10Window8,
                    StringMatchSyntax.WildCard,
                    app,
                    Timeout);
            }

            catch (Exceptions.WindowNotFoundException ex)
            {
                tempWindow = null;
                int numberOfTries = 0;
                const int MaxTries = 10;
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
                        app.Waiters.WaitForWindowIdle(tempWindow, 60000);
                        //UISynchronization.WaitForUIObjectReady(tempWindow,Timeout);
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
                        "Failed to find window with title:  '" +
                        Strings.DialogTitle + "'");

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
        /// 	[lucyra] 2/8/2006 Created
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
            private const string ResourceDialogTitle = ";Properties;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.AuthoringDialog;$this.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;DC01.bU;buttonOk.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;DC01.bU;buttonCancel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Tab0
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTab0 = "Tab0";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ShowDataContainedInASpecificGroup
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceShowDataContainedInASpecificGroup = ";Show data contained in a specific group;ManagedString;Microsoft.MOM.UI.Component" +
                "s.dll;Microsoft.EnterpriseManagement.Mom.UI.AuthoringDialog;label1.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Ellipsis27
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEllipsis27 = ";...;ManagedString;DundasWinChart.dll;DC01.bL;buttonBackColor.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Ellipsis28
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEllipsis28 = ";...;ManagedString;DundasWinChart.dll;DC01.bL;buttonBackColor.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  None
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNone = ";(None);ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagem" +
                "ent.Mom.Internal.UI.Views.SharedResources;AuthoringDialogTargetNull";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Entity
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceEntity = "Entity";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ShowDataRelatedTo
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceShowDataRelatedTo = ";Show data related to:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.En" +
                "terpriseManagement.Mom.UI.AuthoringDialog;typeLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CriteriaDescriptionClickTheUnderlinedValueToEdit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCriteriaDescriptionClickTheUnderlinedValueToEdit = ";Criteria description (click the underlined value to edit):;ManagedString;Microso" +
                "ft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.Cri" +
                "teriaControl.CriteriaControlResource;Description";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ViewAllAlerts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceViewAllAlerts = ";View all alerts:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpr" +
                "iseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;CriteriaDescriptio" +
                "n";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OfASpecificSeverity
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceOfASpecificSeverity = "of a specific severity";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AndOfASpecificPriority
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAndOfASpecificPriority = "  and of a specific priority";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AndWithASpecificCategory
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAndWithASpecificCategory = "  and with a specific category";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AndWithSpecificResolutionState
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAndWithSpecificResolutionState = "  and with specific resolution state";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AndWithASpecificName
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAndWithASpecificName = "  and with a specific name";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AndWithSpecificTextInTheDescription
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAndWithSpecificTextInTheDescription = "  and with specific text in the description";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AndCreatedInSpecificTimePeriod
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAndCreatedInSpecificTimePeriod = "  and created in specific time period";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AndAssignedToASpecificPerson
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAndAssignedToASpecificPerson = "  and assigned to a specific person";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AndRaisedByAnyInstanceOfASpecificClass
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAndRaisedByAnyInstanceOfASpecificClass = "  and raised by any instance of a specific class";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AndRaisedByAnInstanceWithASpecificName
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAndRaisedByAnInstanceWithASpecificName = "  and raised by an instance with a specific name";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AndLastModifiedByASpecificUser
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAndLastModifiedByASpecificUser = "  and last modified by a specific user";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AndThatWasModifiedInASpecificTimePeriod
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAndThatWasModifiedInASpecificTimePeriod = "  and that was modified in a specific time period";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AndCreatedInSpecificTimePeriod2
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAndCreatedInSpecificTimePeriod2 = "  and created in specific time period";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AndCreatedInASpecificTimePeriod
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAndCreatedInASpecificTimePeriod = "  and created in a specific time period";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AndResolvedBySpecificUser
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAndResolvedBySpecificUser = "  and resolved by specific user";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AndWasAddedToTheDatabaseInASpecificTimePeriod
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAndWasAddedToTheDatabaseInASpecificTimePeriod = "  and was added to the database in a specific time period";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AndWithASpecificRuleID
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAndWithASpecificRuleID = "  and with a specific rule ID";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AndWithASpecificSpecificID
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAndWithASpecificSpecificID = "  and with a specific specific ID";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AndWithSpecificTextInCustomField1
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAndWithSpecificTextInCustomField1 = "  and with specific text in Custom Field1";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AndWithSpecificTextInCustomField2
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAndWithSpecificTextInCustomField2 = "  and with specific text in Custom Field2";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AndWithSpecificTextInCustomField3
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAndWithSpecificTextInCustomField3 = "  and with specific text in Custom Field3";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AndWithSpecificTextInCustomField4
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAndWithSpecificTextInCustomField4 = "  and with specific text in Custom Field4";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AndWithSpecificTextInCustomField5
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAndWithSpecificTextInCustomField5 = "  and with specific text in Custom Field5";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Description
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDescription = ";&Description;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseM" +
                "anagement.Mom.UI.AuthoringDialog;descriptionLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceName = ";Na&me;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManageme" +
                "nt.Mom.UI.AuthoringDialog;nameLabel.Text";
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
            /// Caches the translated resource string for:  Tab0
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab0;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ShowDataContainedInASpecificGroup
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedShowDataContainedInASpecificGroup;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Ellipsis27
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEllipsis27;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Ellipsis28
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEllipsis28;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  None
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNone;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Entity
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEntity;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ShowDataRelatedTo
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedShowDataRelatedTo;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CriteriaDescriptionClickTheUnderlinedValueToEdit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCriteriaDescriptionClickTheUnderlinedValueToEdit;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ViewAllAlerts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedViewAllAlerts;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OfASpecificSeverity
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOfASpecificSeverity;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AndOfASpecificPriority
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAndOfASpecificPriority;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AndWithASpecificCategory
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAndWithASpecificCategory;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AndWithSpecificResolutionState
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAndWithSpecificResolutionState;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AndWithASpecificName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAndWithASpecificName;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AndWithSpecificTextInTheDescription
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAndWithSpecificTextInTheDescription;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AndCreatedInSpecificTimePeriod
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAndCreatedInSpecificTimePeriod;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AndAssignedToASpecificPerson
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAndAssignedToASpecificPerson;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AndRaisedByAnyInstanceOfASpecificClass
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAndRaisedByAnyInstanceOfASpecificClass;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AndRaisedByAnInstanceWithASpecificName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAndRaisedByAnInstanceWithASpecificName;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AndLastModifiedByASpecificUser
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAndLastModifiedByASpecificUser;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AndThatWasModifiedInASpecificTimePeriod
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAndThatWasModifiedInASpecificTimePeriod;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AndCreatedInSpecificTimePeriod2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAndCreatedInSpecificTimePeriod2;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AndCreatedInASpecificTimePeriod
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAndCreatedInASpecificTimePeriod;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AndResolvedBySpecificUser
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAndResolvedBySpecificUser;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AndWasAddedToTheDatabaseInASpecificTimePeriod
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAndWasAddedToTheDatabaseInASpecificTimePeriod;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AndWithASpecificRuleID
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAndWithASpecificRuleID;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AndWithASpecificSpecificID
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAndWithASpecificSpecificID;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AndWithSpecificTextInCustomField1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAndWithSpecificTextInCustomField1;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AndWithSpecificTextInCustomField2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAndWithSpecificTextInCustomField2;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AndWithSpecificTextInCustomField3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAndWithSpecificTextInCustomField3;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AndWithSpecificTextInCustomField4
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAndWithSpecificTextInCustomField4;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AndWithSpecificTextInCustomField5
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAndWithSpecificTextInCustomField5;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Description
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDescription;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedName;
            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
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
            /// 	[lucyra] 2/8/2006 Created
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
            /// 	[lucyra] 2/8/2006 Created
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
            /// Exposes access to the Tab0 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tab0
            {
                get
                {
                    if ((cachedTab0 == null))
                    {
                        cachedTab0 = CoreManager.MomConsole.GetIntlStr(ResourceTab0);
                    }
                    return cachedTab0;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ShowDataContainedInASpecificGroup translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ShowDataContainedInASpecificGroup
            {
                get
                {
                    if ((cachedShowDataContainedInASpecificGroup == null))
                    {
                        cachedShowDataContainedInASpecificGroup = CoreManager.MomConsole.GetIntlStr(ResourceShowDataContainedInASpecificGroup);
                    }
                    return cachedShowDataContainedInASpecificGroup;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Ellipsis27 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Ellipsis27
            {
                get
                {
                    if ((cachedEllipsis27 == null))
                    {
                        cachedEllipsis27 = CoreManager.MomConsole.GetIntlStr(ResourceEllipsis27);
                    }
                    return cachedEllipsis27;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Ellipsis28 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Ellipsis28
            {
                get
                {
                    if ((cachedEllipsis28 == null))
                    {
                        cachedEllipsis28 = CoreManager.MomConsole.GetIntlStr(ResourceEllipsis28);
                    }
                    return cachedEllipsis28;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the None translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string None
            {
                get
                {
                    if ((cachedNone == null))
                    {
                        cachedNone = CoreManager.MomConsole.GetIntlStr(ResourceNone);
                    }
                    return cachedNone;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Entity translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Entity
            {
                get
                {
                    if ((cachedEntity == null))
                    {
                        cachedEntity = CoreManager.MomConsole.GetIntlStr(ResourceEntity);
                    }
                    return cachedEntity;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ShowDataRelatedTo translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ShowDataRelatedTo
            {
                get
                {
                    if ((cachedShowDataRelatedTo == null))
                    {
                        cachedShowDataRelatedTo = CoreManager.MomConsole.GetIntlStr(ResourceShowDataRelatedTo);
                    }
                    return cachedShowDataRelatedTo;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CriteriaDescriptionClickTheUnderlinedValueToEdit translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CriteriaDescriptionClickTheUnderlinedValueToEdit
            {
                get
                {
                    if ((cachedCriteriaDescriptionClickTheUnderlinedValueToEdit == null))
                    {
                        cachedCriteriaDescriptionClickTheUnderlinedValueToEdit = CoreManager.MomConsole.GetIntlStr(ResourceCriteriaDescriptionClickTheUnderlinedValueToEdit);
                    }
                    return cachedCriteriaDescriptionClickTheUnderlinedValueToEdit;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ViewAllAlerts translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ViewAllAlerts
            {
                get
                {
                    if ((cachedViewAllAlerts == null))
                    {
                        cachedViewAllAlerts = CoreManager.MomConsole.GetIntlStr(ResourceViewAllAlerts);
                    }
                    return cachedViewAllAlerts;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OfASpecificSeverity translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OfASpecificSeverity
            {
                get
                {
                    if ((cachedOfASpecificSeverity == null))
                    {
                        cachedOfASpecificSeverity = CoreManager.MomConsole.GetIntlStr(ResourceOfASpecificSeverity);
                    }
                    return cachedOfASpecificSeverity;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AndOfASpecificPriority translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AndOfASpecificPriority
            {
                get
                {
                    if ((cachedAndOfASpecificPriority == null))
                    {
                        cachedAndOfASpecificPriority = CoreManager.MomConsole.GetIntlStr(ResourceAndOfASpecificPriority);
                    }
                    return cachedAndOfASpecificPriority;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AndWithASpecificCategory translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AndWithASpecificCategory
            {
                get
                {
                    if ((cachedAndWithASpecificCategory == null))
                    {
                        cachedAndWithASpecificCategory = CoreManager.MomConsole.GetIntlStr(ResourceAndWithASpecificCategory);
                    }
                    return cachedAndWithASpecificCategory;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AndWithSpecificResolutionState translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AndWithSpecificResolutionState
            {
                get
                {
                    if ((cachedAndWithSpecificResolutionState == null))
                    {
                        cachedAndWithSpecificResolutionState = CoreManager.MomConsole.GetIntlStr(ResourceAndWithSpecificResolutionState);
                    }
                    return cachedAndWithSpecificResolutionState;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AndWithASpecificName translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AndWithASpecificName
            {
                get
                {
                    if ((cachedAndWithASpecificName == null))
                    {
                        cachedAndWithASpecificName = CoreManager.MomConsole.GetIntlStr(ResourceAndWithASpecificName);
                    }
                    return cachedAndWithASpecificName;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AndWithSpecificTextInTheDescription translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AndWithSpecificTextInTheDescription
            {
                get
                {
                    if ((cachedAndWithSpecificTextInTheDescription == null))
                    {
                        cachedAndWithSpecificTextInTheDescription = CoreManager.MomConsole.GetIntlStr(ResourceAndWithSpecificTextInTheDescription);
                    }
                    return cachedAndWithSpecificTextInTheDescription;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AndCreatedInSpecificTimePeriod translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AndCreatedInSpecificTimePeriod
            {
                get
                {
                    if ((cachedAndCreatedInSpecificTimePeriod == null))
                    {
                        cachedAndCreatedInSpecificTimePeriod = CoreManager.MomConsole.GetIntlStr(ResourceAndCreatedInSpecificTimePeriod);
                    }
                    return cachedAndCreatedInSpecificTimePeriod;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AndAssignedToASpecificPerson translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AndAssignedToASpecificPerson
            {
                get
                {
                    if ((cachedAndAssignedToASpecificPerson == null))
                    {
                        cachedAndAssignedToASpecificPerson = CoreManager.MomConsole.GetIntlStr(ResourceAndAssignedToASpecificPerson);
                    }
                    return cachedAndAssignedToASpecificPerson;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AndRaisedByAnyInstanceOfASpecificClass translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AndRaisedByAnyInstanceOfASpecificClass
            {
                get
                {
                    if ((cachedAndRaisedByAnyInstanceOfASpecificClass == null))
                    {
                        cachedAndRaisedByAnyInstanceOfASpecificClass = CoreManager.MomConsole.GetIntlStr(ResourceAndRaisedByAnyInstanceOfASpecificClass);
                    }
                    return cachedAndRaisedByAnyInstanceOfASpecificClass;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AndRaisedByAnInstanceWithASpecificName translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AndRaisedByAnInstanceWithASpecificName
            {
                get
                {
                    if ((cachedAndRaisedByAnInstanceWithASpecificName == null))
                    {
                        cachedAndRaisedByAnInstanceWithASpecificName = CoreManager.MomConsole.GetIntlStr(ResourceAndRaisedByAnInstanceWithASpecificName);
                    }
                    return cachedAndRaisedByAnInstanceWithASpecificName;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AndLastModifiedByASpecificUser translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AndLastModifiedByASpecificUser
            {
                get
                {
                    if ((cachedAndLastModifiedByASpecificUser == null))
                    {
                        cachedAndLastModifiedByASpecificUser = CoreManager.MomConsole.GetIntlStr(ResourceAndLastModifiedByASpecificUser);
                    }
                    return cachedAndLastModifiedByASpecificUser;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AndThatWasModifiedInASpecificTimePeriod translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AndThatWasModifiedInASpecificTimePeriod
            {
                get
                {
                    if ((cachedAndThatWasModifiedInASpecificTimePeriod == null))
                    {
                        cachedAndThatWasModifiedInASpecificTimePeriod = CoreManager.MomConsole.GetIntlStr(ResourceAndThatWasModifiedInASpecificTimePeriod);
                    }
                    return cachedAndThatWasModifiedInASpecificTimePeriod;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AndCreatedInSpecificTimePeriod2 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AndCreatedInSpecificTimePeriod2
            {
                get
                {
                    if ((cachedAndCreatedInSpecificTimePeriod2 == null))
                    {
                        cachedAndCreatedInSpecificTimePeriod2 = CoreManager.MomConsole.GetIntlStr(ResourceAndCreatedInSpecificTimePeriod2);
                    }
                    return cachedAndCreatedInSpecificTimePeriod2;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AndCreatedInASpecificTimePeriod translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AndCreatedInASpecificTimePeriod
            {
                get
                {
                    if ((cachedAndCreatedInASpecificTimePeriod == null))
                    {
                        cachedAndCreatedInASpecificTimePeriod = CoreManager.MomConsole.GetIntlStr(ResourceAndCreatedInASpecificTimePeriod);
                    }
                    return cachedAndCreatedInASpecificTimePeriod;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AndResolvedBySpecificUser translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AndResolvedBySpecificUser
            {
                get
                {
                    if ((cachedAndResolvedBySpecificUser == null))
                    {
                        cachedAndResolvedBySpecificUser = CoreManager.MomConsole.GetIntlStr(ResourceAndResolvedBySpecificUser);
                    }
                    return cachedAndResolvedBySpecificUser;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AndWasAddedToTheDatabaseInASpecificTimePeriod translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AndWasAddedToTheDatabaseInASpecificTimePeriod
            {
                get
                {
                    if ((cachedAndWasAddedToTheDatabaseInASpecificTimePeriod == null))
                    {
                        cachedAndWasAddedToTheDatabaseInASpecificTimePeriod = CoreManager.MomConsole.GetIntlStr(ResourceAndWasAddedToTheDatabaseInASpecificTimePeriod);
                    }
                    return cachedAndWasAddedToTheDatabaseInASpecificTimePeriod;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AndWithASpecificRuleID translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AndWithASpecificRuleID
            {
                get
                {
                    if ((cachedAndWithASpecificRuleID == null))
                    {
                        cachedAndWithASpecificRuleID = CoreManager.MomConsole.GetIntlStr(ResourceAndWithASpecificRuleID);
                    }
                    return cachedAndWithASpecificRuleID;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AndWithASpecificSpecificID translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AndWithASpecificSpecificID
            {
                get
                {
                    if ((cachedAndWithASpecificSpecificID == null))
                    {
                        cachedAndWithASpecificSpecificID = CoreManager.MomConsole.GetIntlStr(ResourceAndWithASpecificSpecificID);
                    }
                    return cachedAndWithASpecificSpecificID;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AndWithSpecificTextInCustomField1 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AndWithSpecificTextInCustomField1
            {
                get
                {
                    if ((cachedAndWithSpecificTextInCustomField1 == null))
                    {
                        cachedAndWithSpecificTextInCustomField1 = CoreManager.MomConsole.GetIntlStr(ResourceAndWithSpecificTextInCustomField1);
                    }
                    return cachedAndWithSpecificTextInCustomField1;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AndWithSpecificTextInCustomField2 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AndWithSpecificTextInCustomField2
            {
                get
                {
                    if ((cachedAndWithSpecificTextInCustomField2 == null))
                    {
                        cachedAndWithSpecificTextInCustomField2 = CoreManager.MomConsole.GetIntlStr(ResourceAndWithSpecificTextInCustomField2);
                    }
                    return cachedAndWithSpecificTextInCustomField2;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AndWithSpecificTextInCustomField3 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AndWithSpecificTextInCustomField3
            {
                get
                {
                    if ((cachedAndWithSpecificTextInCustomField3 == null))
                    {
                        cachedAndWithSpecificTextInCustomField3 = CoreManager.MomConsole.GetIntlStr(ResourceAndWithSpecificTextInCustomField3);
                    }
                    return cachedAndWithSpecificTextInCustomField3;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AndWithSpecificTextInCustomField4 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AndWithSpecificTextInCustomField4
            {
                get
                {
                    if ((cachedAndWithSpecificTextInCustomField4 == null))
                    {
                        cachedAndWithSpecificTextInCustomField4 = CoreManager.MomConsole.GetIntlStr(ResourceAndWithSpecificTextInCustomField4);
                    }
                    return cachedAndWithSpecificTextInCustomField4;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AndWithSpecificTextInCustomField5 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AndWithSpecificTextInCustomField5
            {
                get
                {
                    if ((cachedAndWithSpecificTextInCustomField5 == null))
                    {
                        cachedAndWithSpecificTextInCustomField5 = CoreManager.MomConsole.GetIntlStr(ResourceAndWithSpecificTextInCustomField5);
                    }
                    return cachedAndWithSpecificTextInCustomField5;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Description translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Description
            {
                get
                {
                    if ((cachedDescription == null))
                    {
                        cachedDescription = CoreManager.MomConsole.GetIntlStr(ResourceDescription);
                    }
                    return cachedDescription;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Name translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Name
            {
                get
                {
                    if ((cachedName == null))
                    {
                        cachedName = CoreManager.MomConsole.GetIntlStr(ResourceName);
                    }
                    return cachedName;
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
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";

            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";

            /// <summary>
            /// Control ID for NameTextBox
            /// </summary>
            public const string NameTextBox = "nameTextBox";

            /// <summary>
            /// Control ID for DescriptionTextBox
            /// </summary>
            public const string DescriptionTextBox = "descriptionTextbox";

            /// <summary>
            /// Control ID for Tab0TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab0TabControl = "mainTabControl";

            /// <summary>
            /// Control ID for ShowDataContainedInASpecificGroupStaticControl
            /// </summary>
            public const string ShowDataContainedInASpecificGroupStaticControl = "label1";

            /// <summary>
            /// Control ID for Ellipsis27Button
            /// </summary>
            public const string Ellipsis27Button = "changeTargetButton";

            /// <summary>
            /// Control ID for Ellipsis28Button
            /// </summary>
            public const string Ellipsis28Button = "changeTypeButton";

            /// <summary>
            /// Control ID for NoneStaticControl
            /// </summary>
            public const string NoneStaticControl = "targetObjectLabel";

            /// <summary>
            /// Control ID for EntityStaticControl
            /// </summary>
            public const string EntityStaticControl = "targetTypeLabel";

            /// <summary>
            /// Control ID for ShowDataRelatedToStaticControl
            /// </summary>
            public const string ShowDataRelatedToStaticControl = "typeLabel";

            /// <summary>
            /// Control ID for ShowDataContainedInASpecificGroupListBox
            /// </summary>
            public const string ShowDataContainedInASpecificGroupListBox = "checkboxes";

            /// <summary>
            /// Control ID for CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl
            /// </summary>
            public const string CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl = "labelDescription";

            /// <summary>
            /// Control ID for ViewAllAlertsStaticControl
            /// </summary>
            public const string ViewAllAlertsStaticControl = "labelHeader";

            /// <summary>
            /// Control ID for OfASpecificSeverityStaticControl
            /// </summary>
            public const string OfASpecificSeverityStaticControl = "0";

            /// <summary>
            /// Control ID for AndOfASpecificPriorityStaticControl
            /// </summary>
            public const string AndOfASpecificPriorityStaticControl = "1";

            /// <summary>
            /// Control ID for AndWithASpecificCategoryStaticControl
            /// </summary>
            public const string AndWithASpecificCategoryStaticControl = "2";

            /// <summary>
            /// Control ID for AndWithSpecificResolutionStateStaticControl
            /// </summary>
            public const string AndWithSpecificResolutionStateStaticControl = "3";

            /// <summary>
            /// Control ID for AndWithASpecificNameStaticControl
            /// </summary>
            public const string AndWithASpecificNameStaticControl = "4";

            /// <summary>
            /// Control ID for AndWithSpecificTextInTheDescriptionStaticControl
            /// </summary>
            public const string AndWithSpecificTextInTheDescriptionStaticControl = "5";

            /// <summary>
            /// Control ID for AndCreatedInSpecificTimePeriodStaticControl
            /// </summary>
            public const string AndCreatedInSpecificTimePeriodStaticControl = "6";

            /// <summary>
            /// Control ID for AndAssignedToASpecificPersonStaticControl
            /// </summary>
            public const string AndAssignedToASpecificPersonStaticControl = "7";

            /// <summary>
            /// Control ID for AndRaisedByAnyInstanceOfASpecificClassStaticControl
            /// </summary>
            public const string AndRaisedByAnyInstanceOfASpecificClassStaticControl = "8";

            /// <summary>
            /// Control ID for AndRaisedByAnInstanceWithASpecificNameStaticControl
            /// </summary>
            public const string AndRaisedByAnInstanceWithASpecificNameStaticControl = "9";

            /// <summary>
            /// Control ID for AndLastModifiedByASpecificUserStaticControl
            /// </summary>
            public const string AndLastModifiedByASpecificUserStaticControl = "10";

            /// <summary>
            /// Control ID for AndThatWasModifiedInASpecificTimePeriodStaticControl
            /// </summary>
            public const string AndThatWasModifiedInASpecificTimePeriodStaticControl = "11";

            /// <summary>
            /// Control ID for AndCreatedInSpecificTimePeriodStaticControl2
            /// </summary>
            public const string AndCreatedInSpecificTimePeriodStaticControl2 = "12";

            /// <summary>
            /// Control ID for AndCreatedInASpecificTimePeriodStaticControl
            /// </summary>
            public const string AndCreatedInASpecificTimePeriodStaticControl = "13";

            /// <summary>
            /// Control ID for AndResolvedBySpecificUserStaticControl
            /// </summary>
            public const string AndResolvedBySpecificUserStaticControl = "14";

            /// <summary>
            /// Control ID for AndWasAddedToTheDatabaseInASpecificTimePeriodStaticControl
            /// </summary>
            public const string AndWasAddedToTheDatabaseInASpecificTimePeriodStaticControl = "15";

            /// <summary>
            /// Control ID for AndWithASpecificRuleIDStaticControl
            /// </summary>
            public const string AndWithASpecificRuleIDStaticControl = "16";

            /// <summary>
            /// Control ID for AndWithASpecificSpecificIDStaticControl
            /// </summary>
            public const string AndWithASpecificSpecificIDStaticControl = "17";

            /// <summary>
            /// Control ID for AndWithSpecificTextInCustomField1StaticControl
            /// </summary>
            public const string AndWithSpecificTextInCustomField1StaticControl = "18";

            /// <summary>
            /// Control ID for AndWithSpecificTextInCustomField2StaticControl
            /// </summary>
            public const string AndWithSpecificTextInCustomField2StaticControl = "19";

            /// <summary>
            /// Control ID for AndWithSpecificTextInCustomField3StaticControl
            /// </summary>
            public const string AndWithSpecificTextInCustomField3StaticControl = "20";

            /// <summary>
            /// Control ID for AndWithSpecificTextInCustomField4StaticControl
            /// </summary>
            public const string AndWithSpecificTextInCustomField4StaticControl = "21";

            /// <summary>
            /// Control ID for AndWithSpecificTextInCustomField5StaticControl
            /// </summary>
            public const string AndWithSpecificTextInCustomField5StaticControl = "22";

            /// <summary>
            /// Control ID for DescriptionStaticControl
            /// </summary>
            public const string DescriptionStaticControl = "descriptionLabel";

            /// <summary>
            /// Control ID for NameStaticControl
            /// </summary>
            public const string NameStaticControl = "nameLabel";
        }
        #endregion
    }
}
