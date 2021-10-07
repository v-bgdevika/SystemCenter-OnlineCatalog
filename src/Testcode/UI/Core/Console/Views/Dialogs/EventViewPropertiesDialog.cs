// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="EventViewPropertiesDialog.cs">
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

    #region Interface Definition - IEventViewPropertiesDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IEventViewPropertiesDialogControls, for EventViewPropertiesDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[lucyra] 2/8/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IEventViewPropertiesDialogControls
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
        /// Read-only property to access DescriptionTextBox
        /// </summary>
        TextBox DescriptionTextBox
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
        /// Read-only property to access Ellipsis0Button
        /// </summary>
        Button Ellipsis0Button
        {
            get;
        }

        /// <summary>
        /// Read-only property to access Ellipsis1Button
        /// </summary>
        Button Ellipsis1Button
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
        /// Read-only property to access NoneListBox
        /// </summary>
        ListBox NoneListBox
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
        /// Read-only property to access ViewAllEventsStaticControl
        /// </summary>
        StaticControl ViewAllEventsStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access WithASpecificEventNumberStaticControl
        /// </summary>
        StaticControl WithASpecificEventNumberStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AndGeneratedInSpecificTimePeriodStaticControl
        /// </summary>
        StaticControl AndGeneratedInSpecificTimePeriodStaticControl
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
        /// Read-only property to access AndWithSpecificLevelStaticControl
        /// </summary>
        StaticControl AndWithSpecificLevelStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AndFromASpecificUserStaticControl
        /// </summary>
        StaticControl AndFromASpecificUserStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AndLoggedByASpecificComputerStaticControl
        /// </summary>
        StaticControl AndLoggedByASpecificComputerStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AndEnteredTheDatabaseInASpecificTimePeriodStaticControl
        /// </summary>
        StaticControl AndEnteredTheDatabaseInASpecificTimePeriodStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AndWithSpecificEventIdStaticControl
        /// </summary>
        StaticControl AndWithSpecificEventIdStaticControl
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
    public class EventViewPropertiesDialog : Dialog, IEventViewPropertiesDialogControls
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
        /// Cache to hold a reference to DescriptionTextBox of type TextBox
        /// </summary>
        private TextBox cachedDescriptionTextBox;

        /// <summary>
        /// Cache to hold a reference to NameTextBox of type TextBox
        /// </summary>
        private TextBox cachedNameTextBox;

        /// <summary>
        /// Cache to hold a reference to Tab0TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab0TabControl;

        /// <summary>
        /// Cache to hold a reference to ShowDataContainedInASpecificGroupStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedShowDataContainedInASpecificGroupStaticControl;

        /// <summary>
        /// Cache to hold a reference to Ellipsis0Button of type Button
        /// </summary>
        private Button cachedEllipsis0Button;

        /// <summary>
        /// Cache to hold a reference to Ellipsis1Button of type Button
        /// </summary>
        private Button cachedEllipsis1Button;

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
        /// Cache to hold a reference to NoneListBox of type ListBox
        /// </summary>
        private ListBox cachedNoneListBox;

        /// <summary>
        /// Cache to hold a reference to CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCriteriaDescriptionClickTheUnderlinedValueToEditStaticControl;

        /// <summary>
        /// Cache to hold a reference to ViewAllEventsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedViewAllEventsStaticControl;

        /// <summary>
        /// Cache to hold a reference to WithASpecificEventNumberStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWithASpecificEventNumberStaticControl;

        /// <summary>
        /// Cache to hold a reference to AndGeneratedInSpecificTimePeriodStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAndGeneratedInSpecificTimePeriodStaticControl;

        /// <summary>
        /// Cache to hold a reference to AndRaisedByAnInstanceWithASpecificNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAndRaisedByAnInstanceWithASpecificNameStaticControl;

        /// <summary>
        /// Cache to hold a reference to AndWithSpecificLevelStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAndWithSpecificLevelStaticControl;

        /// <summary>
        /// Cache to hold a reference to AndFromASpecificUserStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAndFromASpecificUserStaticControl;

        /// <summary>
        /// Cache to hold a reference to AndLoggedByASpecificComputerStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAndLoggedByASpecificComputerStaticControl;

        /// <summary>
        /// Cache to hold a reference to AndEnteredTheDatabaseInASpecificTimePeriodStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAndEnteredTheDatabaseInASpecificTimePeriodStaticControl;

        /// <summary>
        /// Cache to hold a reference to AndWithSpecificEventIdStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAndWithSpecificEventIdStaticControl;

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
        /// Owner of EventViewPropertiesDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public EventViewPropertiesDialog(ConsoleApp app)
            :
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion

        #region IEventViewPropertiesDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IEventViewPropertiesDialogControls Controls
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
        ///  Routine to set/get the text in control Description
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
        Button IEventViewPropertiesDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, EventViewPropertiesDialog.ControlIDs.OKButton);
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
        Button IEventViewPropertiesDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, EventViewPropertiesDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
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
        TextBox IEventViewPropertiesDialogControls.DescriptionTextBox
        {
            get
            {
                if ((this.cachedDescriptionTextBox == null))
                {
                    this.cachedDescriptionTextBox = new TextBox(this, EventViewPropertiesDialog.ControlIDs.DescriptionTextBox);
                }
                return this.cachedDescriptionTextBox;
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
        TextBox IEventViewPropertiesDialogControls.NameTextBox
        {
            get
            {
                if ((this.cachedNameTextBox == null))
                {
                    this.cachedNameTextBox = new TextBox(this, EventViewPropertiesDialog.ControlIDs.NameTextBox);
                }
                return this.cachedNameTextBox;
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
        TabControl IEventViewPropertiesDialogControls.Tab0TabControl
        {
            get
            {
                if ((this.cachedTab0TabControl == null))
                {
                    this.cachedTab0TabControl = new TabControl(this, EventViewPropertiesDialog.ControlIDs.Tab0TabControl);
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
        StaticControl IEventViewPropertiesDialogControls.ShowDataContainedInASpecificGroupStaticControl
        {
            get
            {
                if ((this.cachedShowDataContainedInASpecificGroupStaticControl == null))
                {
                    this.cachedShowDataContainedInASpecificGroupStaticControl = new StaticControl(this, EventViewPropertiesDialog.ControlIDs.ShowDataContainedInASpecificGroupStaticControl);
                }
                return this.cachedShowDataContainedInASpecificGroupStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Ellipsis0Button control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEventViewPropertiesDialogControls.Ellipsis0Button
        {
            get
            {
                if ((this.cachedEllipsis0Button == null))
                {
                    this.cachedEllipsis0Button = new Button(this, EventViewPropertiesDialog.ControlIDs.Ellipsis0Button);
                }
                return this.cachedEllipsis0Button;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Ellipsis1Button control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEventViewPropertiesDialogControls.Ellipsis1Button
        {
            get
            {
                if ((this.cachedEllipsis1Button == null))
                {
                    this.cachedEllipsis1Button = new Button(this, EventViewPropertiesDialog.ControlIDs.Ellipsis1Button);
                }
                return this.cachedEllipsis1Button;
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
        StaticControl IEventViewPropertiesDialogControls.NoneStaticControl
        {
            get
            {
                if ((this.cachedNoneStaticControl == null))
                {
                    this.cachedNoneStaticControl = new StaticControl(this, EventViewPropertiesDialog.ControlIDs.NoneStaticControl);
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
        StaticControl IEventViewPropertiesDialogControls.EntityStaticControl
        {
            get
            {
                if ((this.cachedEntityStaticControl == null))
                {
                    this.cachedEntityStaticControl = new StaticControl(this, EventViewPropertiesDialog.ControlIDs.EntityStaticControl);
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
        StaticControl IEventViewPropertiesDialogControls.ShowDataRelatedToStaticControl
        {
            get
            {
                if ((this.cachedShowDataRelatedToStaticControl == null))
                {
                    this.cachedShowDataRelatedToStaticControl = new StaticControl(this, EventViewPropertiesDialog.ControlIDs.ShowDataRelatedToStaticControl);
                }
                return this.cachedShowDataRelatedToStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NoneListBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListBox IEventViewPropertiesDialogControls.NoneListBox
        {
            get
            {
                if ((this.cachedNoneListBox == null))
                {
                    this.cachedNoneListBox = new ListBox(this, EventViewPropertiesDialog.ControlIDs.NoneListBox);
                }
                return this.cachedNoneListBox;
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
        StaticControl IEventViewPropertiesDialogControls.CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl
        {
            get
            {
                if ((this.cachedCriteriaDescriptionClickTheUnderlinedValueToEditStaticControl == null))
                {
                    this.cachedCriteriaDescriptionClickTheUnderlinedValueToEditStaticControl = new StaticControl(this, EventViewPropertiesDialog.ControlIDs.CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl);
                }
                return this.cachedCriteriaDescriptionClickTheUnderlinedValueToEditStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ViewAllEventsStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEventViewPropertiesDialogControls.ViewAllEventsStaticControl
        {
            get
            {
                if ((this.cachedViewAllEventsStaticControl == null))
                {
                    this.cachedViewAllEventsStaticControl = new StaticControl(this, EventViewPropertiesDialog.ControlIDs.ViewAllEventsStaticControl);
                }
                return this.cachedViewAllEventsStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WithASpecificEventNumberStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEventViewPropertiesDialogControls.WithASpecificEventNumberStaticControl
        {
            get
            {
                if ((this.cachedWithASpecificEventNumberStaticControl == null))
                {
                    this.cachedWithASpecificEventNumberStaticControl = new StaticControl(this, EventViewPropertiesDialog.ControlIDs.WithASpecificEventNumberStaticControl);
                }
                return this.cachedWithASpecificEventNumberStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AndGeneratedInSpecificTimePeriodStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEventViewPropertiesDialogControls.AndGeneratedInSpecificTimePeriodStaticControl
        {
            get
            {
                if ((this.cachedAndGeneratedInSpecificTimePeriodStaticControl == null))
                {
                    this.cachedAndGeneratedInSpecificTimePeriodStaticControl = new StaticControl(this, EventViewPropertiesDialog.ControlIDs.AndGeneratedInSpecificTimePeriodStaticControl);
                }
                return this.cachedAndGeneratedInSpecificTimePeriodStaticControl;
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
        StaticControl IEventViewPropertiesDialogControls.AndRaisedByAnInstanceWithASpecificNameStaticControl
        {
            get
            {
                if ((this.cachedAndRaisedByAnInstanceWithASpecificNameStaticControl == null))
                {
                    this.cachedAndRaisedByAnInstanceWithASpecificNameStaticControl = new StaticControl(this, EventViewPropertiesDialog.ControlIDs.AndRaisedByAnInstanceWithASpecificNameStaticControl);
                }
                return this.cachedAndRaisedByAnInstanceWithASpecificNameStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AndWithSpecificLevelStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEventViewPropertiesDialogControls.AndWithSpecificLevelStaticControl
        {
            get
            {
                if ((this.cachedAndWithSpecificLevelStaticControl == null))
                {
                    this.cachedAndWithSpecificLevelStaticControl = new StaticControl(this, EventViewPropertiesDialog.ControlIDs.AndWithSpecificLevelStaticControl);
                }
                return this.cachedAndWithSpecificLevelStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AndFromASpecificUserStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEventViewPropertiesDialogControls.AndFromASpecificUserStaticControl
        {
            get
            {
                if ((this.cachedAndFromASpecificUserStaticControl == null))
                {
                    this.cachedAndFromASpecificUserStaticControl = new StaticControl(this, EventViewPropertiesDialog.ControlIDs.AndFromASpecificUserStaticControl);
                }
                return this.cachedAndFromASpecificUserStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AndLoggedByASpecificComputerStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEventViewPropertiesDialogControls.AndLoggedByASpecificComputerStaticControl
        {
            get
            {
                if ((this.cachedAndLoggedByASpecificComputerStaticControl == null))
                {
                    this.cachedAndLoggedByASpecificComputerStaticControl = new StaticControl(this, EventViewPropertiesDialog.ControlIDs.AndLoggedByASpecificComputerStaticControl);
                }
                return this.cachedAndLoggedByASpecificComputerStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AndEnteredTheDatabaseInASpecificTimePeriodStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEventViewPropertiesDialogControls.AndEnteredTheDatabaseInASpecificTimePeriodStaticControl
        {
            get
            {
                if ((this.cachedAndEnteredTheDatabaseInASpecificTimePeriodStaticControl == null))
                {
                    this.cachedAndEnteredTheDatabaseInASpecificTimePeriodStaticControl = new StaticControl(this, EventViewPropertiesDialog.ControlIDs.AndEnteredTheDatabaseInASpecificTimePeriodStaticControl);
                }
                return this.cachedAndEnteredTheDatabaseInASpecificTimePeriodStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AndWithSpecificEventIdStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEventViewPropertiesDialogControls.AndWithSpecificEventIdStaticControl
        {
            get
            {
                if ((this.cachedAndWithSpecificEventIdStaticControl == null))
                {
                    this.cachedAndWithSpecificEventIdStaticControl = new StaticControl(this, EventViewPropertiesDialog.ControlIDs.AndWithSpecificEventIdStaticControl);
                }
                return this.cachedAndWithSpecificEventIdStaticControl;
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
        StaticControl IEventViewPropertiesDialogControls.DescriptionStaticControl
        {
            get
            {
                if ((this.cachedDescriptionStaticControl == null))
                {
                    this.cachedDescriptionStaticControl = new StaticControl(this, EventViewPropertiesDialog.ControlIDs.DescriptionStaticControl);
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
        StaticControl IEventViewPropertiesDialogControls.NameStaticControl
        {
            get
            {
                if ((this.cachedNameStaticControl == null))
                {
                    this.cachedNameStaticControl = new StaticControl(this, EventViewPropertiesDialog.ControlIDs.NameStaticControl);
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
        ///  Routine to click on button Ellipsis0
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEllipsis0()
        {
            this.Controls.Ellipsis0Button.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Ellipsis1
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEllipsis1()
        {
            this.Controls.Ellipsis1Button.Click();
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
            /// Contains resource string for:  Ellipsis0
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEllipsis0 = ";...;ManagedString;DundasWinChart.dll;DC01.bL;buttonBackColor.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Ellipsis1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEllipsis1 = ";...;ManagedString;DundasWinChart.dll;DC01.bL;buttonBackColor.Text";

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
            /// Contains resource string for:  ViewAllEvents
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceViewAllEvents = ";View all events:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpr" +
                "iseManagement.Mom.Internal.UI.Views.EventViewCriteriaResource;CriteriaDescriptio" +
                "n";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WithASpecificEventNumber
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceWithASpecificEventNumber = "with a specific event number";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AndGeneratedInSpecificTimePeriod
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAndGeneratedInSpecificTimePeriod = "  and generated in specific time period";

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
            /// Contains resource string for:  AndWithSpecificLevel
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAndWithSpecificLevel = "  and with specific level";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AndFromASpecificUser
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAndFromASpecificUser = "  and from a specific user";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AndLoggedByASpecificComputer
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAndLoggedByASpecificComputer = "  and logged by a specific computer";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AndEnteredTheDatabaseInASpecificTimePeriod
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAndEnteredTheDatabaseInASpecificTimePeriod = "  and entered the database in a specific time period";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AndWithSpecificEventId
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAndWithSpecificEventId = "  and with specific event id";

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
            /// Caches the translated resource string for:  Ellipsis0
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEllipsis0;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Ellipsis1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEllipsis1;

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
            /// Caches the translated resource string for:  ViewAllEvents
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedViewAllEvents;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WithASpecificEventNumber
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWithASpecificEventNumber;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AndGeneratedInSpecificTimePeriod
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAndGeneratedInSpecificTimePeriod;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AndRaisedByAnInstanceWithASpecificName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAndRaisedByAnInstanceWithASpecificName;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AndWithSpecificLevel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAndWithSpecificLevel;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AndFromASpecificUser
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAndFromASpecificUser;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AndLoggedByASpecificComputer
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAndLoggedByASpecificComputer;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AndEnteredTheDatabaseInASpecificTimePeriod
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAndEnteredTheDatabaseInASpecificTimePeriod;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AndWithSpecificEventId
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAndWithSpecificEventId;

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
            /// Exposes access to the Ellipsis0 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Ellipsis0
            {
                get
                {
                    if ((cachedEllipsis0 == null))
                    {
                        cachedEllipsis0 = CoreManager.MomConsole.GetIntlStr(ResourceEllipsis0);
                    }
                    return cachedEllipsis0;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Ellipsis1 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Ellipsis1
            {
                get
                {
                    if ((cachedEllipsis1 == null))
                    {
                        cachedEllipsis1 = CoreManager.MomConsole.GetIntlStr(ResourceEllipsis1);
                    }
                    return cachedEllipsis1;
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
            /// Exposes access to the ViewAllEvents translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ViewAllEvents
            {
                get
                {
                    if ((cachedViewAllEvents == null))
                    {
                        cachedViewAllEvents = CoreManager.MomConsole.GetIntlStr(ResourceViewAllEvents);
                    }
                    return cachedViewAllEvents;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WithASpecificEventNumber translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WithASpecificEventNumber
            {
                get
                {
                    if ((cachedWithASpecificEventNumber == null))
                    {
                        cachedWithASpecificEventNumber = CoreManager.MomConsole.GetIntlStr(ResourceWithASpecificEventNumber);
                    }
                    return cachedWithASpecificEventNumber;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AndGeneratedInSpecificTimePeriod translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AndGeneratedInSpecificTimePeriod
            {
                get
                {
                    if ((cachedAndGeneratedInSpecificTimePeriod == null))
                    {
                        cachedAndGeneratedInSpecificTimePeriod = CoreManager.MomConsole.GetIntlStr(ResourceAndGeneratedInSpecificTimePeriod);
                    }
                    return cachedAndGeneratedInSpecificTimePeriod;
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
            /// Exposes access to the AndWithSpecificLevel translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AndWithSpecificLevel
            {
                get
                {
                    if ((cachedAndWithSpecificLevel == null))
                    {
                        cachedAndWithSpecificLevel = CoreManager.MomConsole.GetIntlStr(ResourceAndWithSpecificLevel);
                    }
                    return cachedAndWithSpecificLevel;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AndFromASpecificUser translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AndFromASpecificUser
            {
                get
                {
                    if ((cachedAndFromASpecificUser == null))
                    {
                        cachedAndFromASpecificUser = CoreManager.MomConsole.GetIntlStr(ResourceAndFromASpecificUser);
                    }
                    return cachedAndFromASpecificUser;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AndLoggedByASpecificComputer translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AndLoggedByASpecificComputer
            {
                get
                {
                    if ((cachedAndLoggedByASpecificComputer == null))
                    {
                        cachedAndLoggedByASpecificComputer = CoreManager.MomConsole.GetIntlStr(ResourceAndLoggedByASpecificComputer);
                    }
                    return cachedAndLoggedByASpecificComputer;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AndEnteredTheDatabaseInASpecificTimePeriod translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AndEnteredTheDatabaseInASpecificTimePeriod
            {
                get
                {
                    if ((cachedAndEnteredTheDatabaseInASpecificTimePeriod == null))
                    {
                        cachedAndEnteredTheDatabaseInASpecificTimePeriod = CoreManager.MomConsole.GetIntlStr(ResourceAndEnteredTheDatabaseInASpecificTimePeriod);
                    }
                    return cachedAndEnteredTheDatabaseInASpecificTimePeriod;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AndWithSpecificEventId translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AndWithSpecificEventId
            {
                get
                {
                    if ((cachedAndWithSpecificEventId == null))
                    {
                        cachedAndWithSpecificEventId = CoreManager.MomConsole.GetIntlStr(ResourceAndWithSpecificEventId);
                    }
                    return cachedAndWithSpecificEventId;
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
            /// Control ID for DescriptionTextBox
            /// </summary>
            public const string DescriptionTextBox = "descriptionTextbox";

            /// <summary>
            /// Control ID for NameTextBox
            /// </summary>
            public const string NameTextBox = "nameTextBox";

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
            /// Control ID for Ellipsis0Button
            /// </summary>
            public const string Ellipsis0Button = "changeTargetButton";

            /// <summary>
            /// Control ID for Ellipsis1Button
            /// </summary>
            public const string Ellipsis1Button = "changeTypeButton";

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
            /// Control ID for NoneListBox
            /// </summary>
            public const string NoneListBox = "checkboxes";

            /// <summary>
            /// Control ID for CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl
            /// </summary>
            public const string CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl = "labelDescription";

            /// <summary>
            /// Control ID for ViewAllEventsStaticControl
            /// </summary>
            public const string ViewAllEventsStaticControl = "labelHeader";

            /// <summary>
            /// Control ID for WithASpecificEventNumberStaticControl
            /// </summary>
            public const string WithASpecificEventNumberStaticControl = "0";

            /// <summary>
            /// Control ID for AndGeneratedInSpecificTimePeriodStaticControl
            /// </summary>
            public const string AndGeneratedInSpecificTimePeriodStaticControl = "1";

            /// <summary>
            /// Control ID for AndRaisedByAnInstanceWithASpecificNameStaticControl
            /// </summary>
            public const string AndRaisedByAnInstanceWithASpecificNameStaticControl = "2";

            /// <summary>
            /// Control ID for AndWithSpecificLevelStaticControl
            /// </summary>
            public const string AndWithSpecificLevelStaticControl = "3";

            /// <summary>
            /// Control ID for AndFromASpecificUserStaticControl
            /// </summary>
            public const string AndFromASpecificUserStaticControl = "4";

            /// <summary>
            /// Control ID for AndLoggedByASpecificComputerStaticControl
            /// </summary>
            public const string AndLoggedByASpecificComputerStaticControl = "5";

            /// <summary>
            /// Control ID for AndEnteredTheDatabaseInASpecificTimePeriodStaticControl
            /// </summary>
            public const string AndEnteredTheDatabaseInASpecificTimePeriodStaticControl = "6";

            /// <summary>
            /// Control ID for AndWithSpecificEventIdStaticControl
            /// </summary>
            public const string AndWithSpecificEventIdStaticControl = "7";

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
