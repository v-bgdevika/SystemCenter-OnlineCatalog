// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="TaskStatusViewPropertiesDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[zhihaoq] 03/24/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.TaskStatus.Dialogs
{
    #region Using directivew
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console;
    #endregion
    
    #region Interface Definition - ITaskStatusViewPropertiesDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ITaskStatusViewPropertiesDialogControls, for TaskStatusViewPropertiesDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[zhihaoq] 03/24/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ITaskStatusViewPropertiesDialogControls
    {
        #region OKButton
        /// <summary>
        /// Read-only property to access OKButton
        /// </summary>
        Button OKButton
        {
            get;
        }
        #endregion

        #region CancelButton
        /// <summary>
        /// Read-only property to access CancelButton
        /// </summary>
        Button CancelButton
        {
            get;
        }
        #endregion

        #region NameTextBox
        /// <summary>
        /// Read-only property to access NameTextBox
        /// </summary>
        TextBox NameTextBox
        {
            get;
        }
        #endregion

        #region DescriptionTextBox
        /// <summary>
        /// Read-only property to access DescriptionTextBox
        /// </summary>
        TextBox DescriptionTextBox
        {
            get;
        }
        #endregion

        #region Tab0TabControl
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
        #endregion

        #region ClearButton
        /// <summary>
        /// Read-only property to access ClearButton
        /// </summary>
        Button ClearButton
        {
            get;
        }
        #endregion

        #region Ellipsis2Button
        /// <summary>
        /// Read-only property to access Ellipsis2Button
        /// </summary>
        Button Ellipsis2Button
        {
            get;
        }
        #endregion

        #region Ellipsis3Button
        /// <summary>
        /// Read-only property to access Ellipsis3Button
        /// </summary>
        Button Ellipsis3Button
        {
            get;
        }
        #endregion

        #region AllStaticControl
        /// <summary>
        /// Read-only property to access AllStaticControl
        /// </summary>
        StaticControl AllStaticControl
        {
            get;
        }
        #endregion

        #region EntityStaticControl
        /// <summary>
        /// Read-only property to access EntityStaticControl
        /// </summary>
        StaticControl EntityStaticControl
        {
            get;
        }
        #endregion

        #region ShowDataContainedInASpecificGroupListBox
        /// <summary>
        /// Read-only property to access ShowDataContainedInASpecificGroupListBox
        /// </summary>
        ListBox ShowDataContainedInASpecificGroupListBox
        {
            get;
        }
        #endregion

        #region CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl
        /// <summary>
        /// Read-only property to access CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl
        /// </summary>
        StaticControl CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl
        {
            get;
        }
        #endregion

        #region ShowAllTaskStatusStaticControl
        /// <summary>
        /// Read-only property to access ShowAllTaskStatusStaticControl
        /// </summary>
        StaticControl ShowAllTaskStatusStaticControl
        {
            get;
        }
        #endregion

        #region ShowDataContainedInASpecificGroupStaticControl
        /// <summary>
        /// Read-only property to access ShowDataContainedInASpecificGroupStaticControl
        /// </summary>
        StaticControl ShowDataContainedInASpecificGroupStaticControl
        {
            get;
        }
        #endregion

        #region ShowDataRelatedToStaticControl
        /// <summary>
        /// Read-only property to access ShowDataRelatedToStaticControl
        /// </summary>
        StaticControl ShowDataRelatedToStaticControl
        {
            get;
        }
        #endregion


        #region CreatedBySpecificTasksStaticControl
        /// <summary>
        /// Read-only property to access CreatedBySpecificTasksStaticControl
        /// </summary>
        StaticControl CreatedBySpecificTasksStaticControl
        {
            get;
        }
        #endregion

        #region AndSubmittedBySpecificPersonsStaticControl
        /// <summary>
        /// Read-only property to access AndSubmittedBySpecificPersonsStaticControl
        /// </summary>
        StaticControl AndSubmittedBySpecificPersonsStaticControl
        {
            get;
        }
        #endregion

        #region AndRunningAsSpecificAccountStaticControl
        /// <summary>
        /// Read-only property to access AndRunningAsSpecificAccountStaticControl
        /// </summary>
        StaticControl AndRunningAsSpecificAccountStaticControl
        {
            get;
        }
        #endregion

        #region AndWithSpecificStatusStaticControl
        /// <summary>
        /// Read-only property to access AndWithSpecificStatusStaticControl
        /// </summary>
        StaticControl AndWithSpecificStatusStaticControl
        {
            get;
        }
        #endregion

        #region AndWithSpecificOutputTextStaticControl
        /// <summary>
        /// Read-only property to access AndWithSpecificOutputTextStaticControl
        /// </summary>
        StaticControl AndWithSpecificOutputTextStaticControl
        {
            get;
        }
        #endregion

        #region AndScheduledToRunInASpecificTimePeriodStaticControl
        /// <summary>
        /// Read-only property to access AndScheduledToRunInASpecificTimePeriodStaticControl
        /// </summary>
        StaticControl AndScheduledToRunInASpecificTimePeriodStaticControl
        {
            get;
        }
        #endregion

        #region AndThatStartedRunningInASpecificTimePeriodStaticControl
        /// <summary>
        /// Read-only property to access AndThatStartedRunningInASpecificTimePeriodStaticControl
        /// </summary>
        StaticControl AndThatStartedRunningInASpecificTimePeriodStaticControl
        {
            get;
        }
        #endregion

        #region AndWereLastModifiedInASpecificTimePeriodStaticControl
        /// <summary>
        /// Read-only property to access AndWereLastModifiedInASpecificTimePeriodStaticControl
        /// </summary>
        StaticControl AndWereLastModifiedInASpecificTimePeriodStaticControl
        {
            get;
        }
        #endregion



        #region DescriptionStaticControl
        /// <summary>
        /// Read-only property to access DescriptionStaticControl
        /// </summary>
        StaticControl DescriptionStaticControl
        {
            get;
        }
        #endregion

        #region NameStaticControl
        /// <summary>
        /// Read-only property to access NameStaticControl
        /// </summary>
        StaticControl NameStaticControl
        {
            get;
        }
        #endregion
    }
    #endregion

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add dialog functionality description here.
    /// </summary>
    /// <history>
    /// 	[zhihaoq] 03/24/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class TaskStatusViewPropertiesDialog : Dialog, ITaskStatusViewPropertiesDialogControls
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
        /// Cache to hold a reference to ClearButton of type Button
        /// </summary>
        private Button cachedClearButton;

        /// <summary>
        /// Cache to hold a reference to Ellipsis2Button of type Button
        /// </summary>
        private Button cachedEllipsis2Button;

        /// <summary>
        /// Cache to hold a reference to Ellipsis3Button of type Button
        /// </summary>
        private Button cachedEllipsis3Button;

        /// <summary>
        /// Cache to hold a reference to AllStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAllStaticControl;

        /// <summary>
        /// Cache to hold a reference to EntityStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEntityStaticControl;

        /// <summary>
        /// Cache to hold a reference to ShowDataContainedInASpecificGroupListBox of type ListBox
        /// </summary>
        private ListBox cachedShowDataContainedInASpecificGroupListBox;

        /// <summary>
        /// Cache to hold a reference to CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCriteriaDescriptionClickTheUnderlinedValueToEditStaticControl;

        /// <summary>
        /// Cache to hold a reference to ShowAllTaskStatusStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedShowAllTaskStatusStaticControl;

        /// <summary>
        /// Cache to hold a reference to ShowDataContainedInASpecificGroupStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedShowDataContainedInASpecificGroupStaticControl;

        /// <summary>
        /// Cache to hold a reference to ShowDataRelatedToStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedShowDataRelatedToStaticControl;

        /// <summary>
        /// Cache to hold a reference to OfASpecificSeverityStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCreatedBySpecificTasksStaticControl;

        /// <summary>
        /// Cache to hold a reference to AndOfASpecificPriorityStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAndSubmittedBySpecificPersonsStaticControl;

        /// <summary>
        /// Cache to hold a reference to AndWithASpecificCategoryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAndRunningAsSpecificAccountStaticControl;

        /// <summary>
        /// Cache to hold a reference to AndWithSpecificResolutionStateStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAndWithSpecificStatusStaticControl;

        /// <summary>
        /// Cache to hold a reference to AndWithASpecificNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAndWithSpecificOutputTextStaticControl;

        /// <summary>
        /// Cache to hold a reference to AndWithSpecificTextInTheDescriptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAndScheduledToRunInASpecificTimePeriodStaticControl;

        /// <summary>
        /// Cache to hold a reference to AndCreatedInSpecificTimePeriodStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAndThatStartedRunningInASpecificTimePeriodStaticControl;

        /// <summary>
        /// Cache to hold a reference to AndAssignedToASpecificPersonStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAndWereLastModifiedInASpecificTimePeriodStaticControl;

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
        /// Owner of TaskStatusViewPropertiesDialog of type App
        /// </param>
        /// <history>
        /// 	[zhihaoq] 03/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public TaskStatusViewPropertiesDialog(ConsoleApp app)
            :
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion

        #region ITaskStatusViewPropertiesDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[zhihaoq] 03/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ITaskStatusViewPropertiesDialogControls Controls
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
        /// 	[zhihaoq] 03/34/2008 Created
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
        ///  Routine to set/get the text in control Description
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[zhihaoq] 03/24/2008 Created
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
        /// 	[zhihaoq] 03/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITaskStatusViewPropertiesDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, TaskStatusViewPropertiesDialog.ControlIDs.OKButton);
                }

                return this.cachedOKButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 03/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITaskStatusViewPropertiesDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, TaskStatusViewPropertiesDialog.ControlIDs.CancelButton);
                }

                return this.cachedCancelButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameTextBox control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 03/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ITaskStatusViewPropertiesDialogControls.NameTextBox
        {
            get
            {
                if ((this.cachedNameTextBox == null))
                {
                    this.cachedNameTextBox = new TextBox(this, TaskStatusViewPropertiesDialog.ControlIDs.NameTextBox);
                }

                return this.cachedNameTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionTextBox control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 03/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ITaskStatusViewPropertiesDialogControls.DescriptionTextBox
        {
            get
            {
                if ((this.cachedDescriptionTextBox == null))
                {
                    this.cachedDescriptionTextBox = new TextBox(this, TaskStatusViewPropertiesDialog.ControlIDs.DescriptionTextBox);
                }
                return this.cachedDescriptionTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab0TabControl control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 03/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl ITaskStatusViewPropertiesDialogControls.Tab0TabControl
        {
            get
            {
                if ((this.cachedTab0TabControl == null))
                {
                    this.cachedTab0TabControl = new TabControl(this, TaskStatusViewPropertiesDialog.ControlIDs.Tab0TabControl);
                }

                return this.cachedTab0TabControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ClearButton control
        /// </summary>
        /// <history>
        /// 	[asttest] 23/04/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITaskStatusViewPropertiesDialogControls.ClearButton
        {
            get
            {
                if ((this.cachedClearButton == null))
                {
                    this.cachedClearButton = new Button(this, TaskStatusViewPropertiesDialog.ControlIDs.ClearButton);
                }

                return this.cachedClearButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Ellipsis2Button control
        /// </summary>
        /// <history>
        /// 	[asttest] 23/04/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITaskStatusViewPropertiesDialogControls.Ellipsis2Button
        {
            get
            {
                if ((this.cachedEllipsis2Button == null))
                {
                    this.cachedEllipsis2Button = new Button(this, TaskStatusViewPropertiesDialog.ControlIDs.Ellipsis2Button);
                }

                return this.cachedEllipsis2Button;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Ellipsis3Button control
        /// </summary>
        /// <history>
        /// 	[asttest] 23/04/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITaskStatusViewPropertiesDialogControls.Ellipsis3Button
        {
            get
            {
                if ((this.cachedEllipsis3Button == null))
                {
                    this.cachedEllipsis3Button = new Button(this, TaskStatusViewPropertiesDialog.ControlIDs.Ellipsis3Button);
                }

                return this.cachedEllipsis3Button;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AllStaticControl control
        /// </summary>
        /// <history>
        /// 	[asttest] 23/04/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITaskStatusViewPropertiesDialogControls.AllStaticControl
        {
            get
            {
                if ((this.cachedAllStaticControl == null))
                {
                    this.cachedAllStaticControl = new StaticControl(this, TaskStatusViewPropertiesDialog.ControlIDs.AllStaticControl);
                }

                return this.cachedAllStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EntityStaticControl control
        /// </summary>
        /// <history>
        /// 	[asttest] 23/04/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITaskStatusViewPropertiesDialogControls.EntityStaticControl
        {
            get
            {
                if ((this.cachedEntityStaticControl == null))
                {
                    this.cachedEntityStaticControl = new StaticControl(this, TaskStatusViewPropertiesDialog.ControlIDs.EntityStaticControl);
                }

                return this.cachedEntityStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ShowDataContainedInASpecificGroupListBox control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 3/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListBox ITaskStatusViewPropertiesDialogControls.ShowDataContainedInASpecificGroupListBox
        {
            get
            {
                if ((this.cachedShowDataContainedInASpecificGroupListBox == null))
                {
                    this.cachedShowDataContainedInASpecificGroupListBox = new ListBox(this, TaskStatusViewPropertiesDialog.ControlIDs.ShowDataContainedInASpecificGroupListBox);
                }
                return this.cachedShowDataContainedInASpecificGroupListBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 03/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITaskStatusViewPropertiesDialogControls.CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl
        {
            get
            {
                if ((this.cachedCriteriaDescriptionClickTheUnderlinedValueToEditStaticControl == null))
                {
                    this.cachedCriteriaDescriptionClickTheUnderlinedValueToEditStaticControl = new StaticControl(this, TaskStatusViewPropertiesDialog.ControlIDs.CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl);
                }

                return this.cachedCriteriaDescriptionClickTheUnderlinedValueToEditStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ShowAllTaskStatusStaticControl control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 03/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITaskStatusViewPropertiesDialogControls.ShowAllTaskStatusStaticControl
        {
            get
            {
                if ((this.cachedShowAllTaskStatusStaticControl == null))
                {
                    this.cachedShowAllTaskStatusStaticControl = new StaticControl(this, TaskStatusViewPropertiesDialog.ControlIDs.ShowAllTaskStatusStaticControl);
                }

                return this.cachedShowAllTaskStatusStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ShowDataContainedInASpecificGroupStaticControl control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 03/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITaskStatusViewPropertiesDialogControls.ShowDataContainedInASpecificGroupStaticControl
        {
            get
            {
                if ((this.cachedShowDataContainedInASpecificGroupStaticControl == null))
                {
                    this.cachedShowDataContainedInASpecificGroupStaticControl = new StaticControl(this, TaskStatusViewPropertiesDialog.ControlIDs.ShowDataContainedInASpecificGroupStaticControl);
                }

                return this.cachedShowDataContainedInASpecificGroupStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ShowDataRelatedToStaticControl control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 03/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITaskStatusViewPropertiesDialogControls.ShowDataRelatedToStaticControl
        {
            get
            {
                if ((this.cachedShowDataRelatedToStaticControl == null))
                {
                    this.cachedShowDataRelatedToStaticControl = new StaticControl(this, TaskStatusViewPropertiesDialog.ControlIDs.ShowDataRelatedToStaticControl);
                }

                return this.cachedShowDataRelatedToStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreatedBySpecificTasksStaticControl control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 3/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITaskStatusViewPropertiesDialogControls.CreatedBySpecificTasksStaticControl
        {
            get
            {
                if ((this.cachedCreatedBySpecificTasksStaticControl == null))
                {
                    this.cachedCreatedBySpecificTasksStaticControl = new StaticControl(this/*, TaskStatusViewPropertiesDialog.ControlIDs.CreatedBySpecificTasksStaticControl*/);
                }
                return this.cachedCreatedBySpecificTasksStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AndSubmittedBySpecificPersonsStaticControl control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 3/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITaskStatusViewPropertiesDialogControls.AndSubmittedBySpecificPersonsStaticControl
        {
            get
            {
                if ((this.cachedAndSubmittedBySpecificPersonsStaticControl == null))
                {
                    this.cachedAndSubmittedBySpecificPersonsStaticControl = new StaticControl(this/*, TaskStatusViewPropertiesDialog.ControlIDs.AndSubmittedBySpecificPersonsStaticControl*/);
                }
                return this.cachedAndSubmittedBySpecificPersonsStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AndRunningAsSpecificAccountStaticControl control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 3/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITaskStatusViewPropertiesDialogControls.AndRunningAsSpecificAccountStaticControl
        {
            get
            {
                if ((this.cachedAndRunningAsSpecificAccountStaticControl == null))
                {
                    this.cachedAndRunningAsSpecificAccountStaticControl = new StaticControl(this/*, TaskStatusViewPropertiesDialog.ControlIDs.AndRunningAsSpecificAccountStaticControl*/);
                }
                return this.cachedAndRunningAsSpecificAccountStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AndWithSpecificStatusStaticControl control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 3/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITaskStatusViewPropertiesDialogControls.AndWithSpecificStatusStaticControl
        {
            get
            {
                if ((this.cachedAndWithSpecificStatusStaticControl == null))
                {
                    this.cachedAndWithSpecificStatusStaticControl = new StaticControl(this/*, TaskStatusViewPropertiesDialog.ControlIDs.AndWithSpecificStatusStaticControl*/);
                }
                return this.cachedAndWithSpecificStatusStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AndWithSpecificOutputTextStaticControl control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 3/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITaskStatusViewPropertiesDialogControls.AndWithSpecificOutputTextStaticControl
        {
            get
            {
                if ((this.cachedAndWithSpecificOutputTextStaticControl == null))
                {
                    this.cachedAndWithSpecificOutputTextStaticControl = new StaticControl(this/*, TaskStatusViewPropertiesDialog.ControlIDs.AndWithSpecificOutputTextStaticControl*/);
                }
                return this.cachedAndWithSpecificOutputTextStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AndScheduledToRunInASpecificTimePeriodStaticControl control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 3/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITaskStatusViewPropertiesDialogControls.AndScheduledToRunInASpecificTimePeriodStaticControl
        {
            get
            {
                if ((this.cachedAndScheduledToRunInASpecificTimePeriodStaticControl == null))
                {
                    this.cachedAndScheduledToRunInASpecificTimePeriodStaticControl = new StaticControl(this/*, TaskStatusViewPropertiesDialog.ControlIDs.AndScheduledToRunInASpecificTimePeriodStaticControl*/);
                }
                return this.cachedAndScheduledToRunInASpecificTimePeriodStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AndThatStartedRunningInASpecificTimePeriodStaticControl control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 3/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITaskStatusViewPropertiesDialogControls.AndThatStartedRunningInASpecificTimePeriodStaticControl
        {
            get
            {
                if ((this.cachedAndThatStartedRunningInASpecificTimePeriodStaticControl == null))
                {
                    this.cachedAndThatStartedRunningInASpecificTimePeriodStaticControl = new StaticControl(this/*, TaskStatusViewPropertiesDialog.ControlIDs.AndThatStartedRunningInASpecificTimePeriodStaticControl*/);
                }
                return this.cachedAndThatStartedRunningInASpecificTimePeriodStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AndWereLastModifiedInASpecificTimePeriodStaticControl control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 3/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITaskStatusViewPropertiesDialogControls.AndWereLastModifiedInASpecificTimePeriodStaticControl
        {
            get
            {
                if ((this.cachedAndWereLastModifiedInASpecificTimePeriodStaticControl == null))
                {
                    this.cachedAndWereLastModifiedInASpecificTimePeriodStaticControl = new StaticControl(this/*, TaskStatusViewPropertiesDialog.ControlIDs.AndWereLastModifiedInASpecificTimePeriodStaticControl*/);
                }
                return this.cachedAndWereLastModifiedInASpecificTimePeriodStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[asttest] 23/04/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITaskStatusViewPropertiesDialogControls.DescriptionStaticControl
        {
            get
            {
                if ((this.cachedDescriptionStaticControl == null))
                {
                    this.cachedDescriptionStaticControl = new StaticControl(this, TaskStatusViewPropertiesDialog.ControlIDs.DescriptionStaticControl);
                }

                return this.cachedDescriptionStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameStaticControl control
        /// </summary>
        /// <history>
        /// 	[asttest] 23/04/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITaskStatusViewPropertiesDialogControls.NameStaticControl
        {
            get
            {
                if ((this.cachedNameStaticControl == null))
                {
                    this.cachedNameStaticControl = new StaticControl(this, TaskStatusViewPropertiesDialog.ControlIDs.NameStaticControl);
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
        /// 	[zhihaoq] 3/24/2008 Created
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
        /// 	[zhihaoq] 3/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Clear
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 3/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickClear()
        {
            this.Controls.ClearButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Ellipsis2
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 3/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEllipsis2()
        {
            this.Controls.Ellipsis2Button.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Ellipsis3
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 3/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEllipsis3()
        {
            this.Controls.Ellipsis3Button.Click();
        }
        #endregion

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">App owning the dialog.</param>
        /// <history>
        /// 	[asttest] 23/04/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, 
                    StringMatchSyntax.ExactMatch, 
                    WindowClassNames.WinForms10Window8, 
                    StringMatchSyntax.ExactMatch, 
                    app, 
                    Timeout);
            }
            catch (Exceptions.WindowNotFoundException windowNotFound)
            {
                tempWindow = null;
                int numberofTries = 0;
                const int MaxTries = 10;
                while (tempWindow == null && numberofTries < MaxTries)
                {
                    numberofTries++;
                    try
                    {
                        // look for the window again using wildcards
                        tempWindow = new Window(Strings.DialogTitle + "*",
                            StringMatchSyntax.WildCard,
                            WindowClassNames.WinForms10Window8,
                            StringMatchSyntax.WildCard,
                            app,
                            Timeout);

                        // wait for the window to report ready
                        app.Waiters.WaitForWindowIdle(tempWindow, 60000);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    { 
                        //log the unsuccessful attemp
                        Core.Common.Utilities.LogMessage("Attempt " + numberofTries + " of " + MaxTries);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    //log the failure
                    Core.Common.Utilities.LogMessage("Failed to find window with title: '" + Strings.DialogTitle + "'");

                    //throw the existing WindowNotFound exception
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
        /// 	[zhihaoq] 3/24/2008 Created
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

            /// <summary>
            /// Resource string for Clear
            /// </summary>
            public const string ResourceClear = "&Clear";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Ellipsis2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEllipsis2 = ";...;ManagedString;DundasWinChart.dll;DC01.bL;buttonBackColor.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Ellipsis3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEllipsis3 = ";...;ManagedString;DundasWinChart.dll;DC01.bL;buttonBackColor.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  All
            /// </summary>
            /// -----------------------------------------------------------------------------
            public const string ResourceAll = "(All)";

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
            /// Contains resource string for:  CriteriaDescriptionClickTheUnderlinedValueToEdit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCriteriaDescriptionClickTheUnderlinedValueToEdit = ";Criteria description (click the underlined value to edit):;ManagedString;Microso" +
                "ft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.Cri" +
                "teriaControl.CriteriaControlResource;Description";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ShowAllTaskStatus
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceViewAllTaskStatus = ";Show all task status;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpr" +
                "iseManagement.Mom.Internal.UI.Views.TaskStatusCriteriaResource;CriteriaDescription";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ShowDataContainedInASpecificGroup
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceShowDataContainedInASpecificGroup = ";Show data contained in a specific group;ManagedString;Microsoft.MOM.UI.Component" +
                "s.dll;Microsoft.EnterpriseManagement.Mom.UI.AuthoringDialog;label1.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ShowDataRelatedTo
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceShowDataRelatedTo = ";Show data related to:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.En" +
                "terpriseManagement.Mom.UI.AuthoringDialog;typeLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CreatedBySpecificTasks
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceCreatedBySpecificTasks = "created by specific tasks";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AndSubmittedBySpecificPersons
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAndSubmittedBySpecificPersons = "  and submitted by specific persons";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AndRunningAsSpecificAccount
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAndRunningAsSpecificAccount = "  and running as specific account";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AndWithSpecificStatus
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAndWithSpecificStatus = "  and with specific status";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AndWithSpecificOutputText
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAndWithSpecificOutputText = "  and with specific output text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AndScheduledToRunInASpecificTimePeriod
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAndScheduledToRunInASpecificTimePeriod = "  and scheduled to run in a specific time period";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AndThatStartedRunningInASpecificTimePeriod
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAndThatStartedRunningInASpecificTimePeriod = "  and that started running in a specific time period";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AndWereLastModifiedInASpecificTimePeriod
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAndWereLastModifiedInASpecificTimePeriod = "  and were last modified in a specific time period";

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
            private static string cachedEllipsis2;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Ellipsis28
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEllipsis3;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  All
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAll;

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
            /// Caches the translated resource string for:  ViewAllTaskStatus
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedViewAllTaskStatus;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CreatedBySpecificTasks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCreatedBySpecificTasks;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AndSubmittedBySpecificPersons
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAndSubmittedBySpecificPersons;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AndRunningAsSpecificAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAndRunningAsSpecificAccount;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AndWithSpecificStatus
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAndWithSpecificStatus;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AndWithSpecificOutputText
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAndWithSpecificOutputText;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AndScheduledToRunInASpecificTimePeriod
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAndScheduledToRunInASpecificTimePeriod;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AndThatStartedRunningInASpecificTimePeriod
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAndThatStartedRunningInASpecificTimePeriod;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AndWereLastModifiedInASpecificTimePeriod
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAndWereLastModifiedInASpecificTimePeriod;

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
            /// 	[zhihaoq] 3/24/2008 Created
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
            /// 	[zhihaoq] 3/24/2008 Created
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
            /// 	[zhihaoq] 3/24/2008 Created
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
            /// 	[zhihaoq] 3/24/2008 Created
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
            /// 	[zhihaoq] 3/24/2008 Created
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
            /// Exposes access to the Ellipsis2 translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 3/24/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Ellipsis2
            {
                get
                {
                    if ((cachedEllipsis2 == null))
                    {
                        cachedEllipsis2 = CoreManager.MomConsole.GetIntlStr(ResourceEllipsis2);
                    }
                    return cachedEllipsis2;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Ellipsis3 translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 3/24/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Ellipsis3
            {
                get
                {
                    if ((cachedEllipsis3 == null))
                    {
                        cachedEllipsis3 = CoreManager.MomConsole.GetIntlStr(ResourceEllipsis3);
                    }
                    return cachedEllipsis3;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the All translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 3/24/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string All
            {
                get
                {
                    if ((cachedAll == null))
                    {
                        cachedAll = CoreManager.MomConsole.GetIntlStr(ResourceAll);
                    }
                    return cachedAll;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Entity translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 3/24/2008 Created
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
            /// 	[zhihaoq] 3/24/2008 Created
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
            /// 	[zhihaoq] 3/24/2008 Created
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
            /// Exposes access to the ViewAllTaskStatus translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 3/24/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ViewAllTaskStatus
            {
                get
                {
                    if ((cachedViewAllTaskStatus == null))
                    {
                        cachedViewAllTaskStatus = CoreManager.MomConsole.GetIntlStr(ResourceViewAllTaskStatus);
                    }
                    return cachedViewAllTaskStatus;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CreatedBySpecificTasks translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 3/24/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CreatedBySpecificTasks
            {
                get
                {
                    if ((cachedCreatedBySpecificTasks == null))
                    {
                        cachedCreatedBySpecificTasks = CoreManager.MomConsole.GetIntlStr(ResourceCreatedBySpecificTasks);
                    }
                    return cachedCreatedBySpecificTasks;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AndSubmittedBySpecificPersons translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 3/24/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AndSubmittedBySpecificPersons
            {
                get
                {
                    if ((cachedAndSubmittedBySpecificPersons == null))
                    {
                        cachedAndSubmittedBySpecificPersons = CoreManager.MomConsole.GetIntlStr(ResourceAndSubmittedBySpecificPersons);
                    }
                    return cachedAndSubmittedBySpecificPersons;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AndRunningAsSpecificAccount translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 3/24/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AndRunningAsSpecificAccount
            {
                get
                {
                    if ((cachedAndRunningAsSpecificAccount == null))
                    {
                        cachedAndRunningAsSpecificAccount = CoreManager.MomConsole.GetIntlStr(ResourceAndRunningAsSpecificAccount);
                    }
                    return cachedAndRunningAsSpecificAccount;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AndWithSpecificStatus translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 3/24/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AndWithSpecificStatus
            {
                get
                {
                    if ((cachedAndWithSpecificStatus == null))
                    {
                        cachedAndWithSpecificStatus = CoreManager.MomConsole.GetIntlStr(ResourceAndWithSpecificStatus);
                    }
                    return cachedAndWithSpecificStatus;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AndWithSpecificOutputText translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 3/24/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AndWithSpecificOutputText
            {
                get
                {
                    if ((cachedAndWithSpecificOutputText == null))
                    {
                        cachedAndWithSpecificOutputText = CoreManager.MomConsole.GetIntlStr(ResourceAndWithSpecificOutputText);
                    }
                    return cachedAndWithSpecificOutputText;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AndScheduledToRunInASpecificTimePeriod translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 3/24/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AndScheduledToRunInASpecificTimePeriod
            {
                get
                {
                    if ((cachedAndScheduledToRunInASpecificTimePeriod == null))
                    {
                        cachedAndScheduledToRunInASpecificTimePeriod = CoreManager.MomConsole.GetIntlStr(ResourceAndScheduledToRunInASpecificTimePeriod);
                    }
                    return cachedAndScheduledToRunInASpecificTimePeriod;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AndThatStartedRunningInASpecificTimePeriod translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 3/24/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AndThatStartedRunningInASpecificTimePeriod
            {
                get
                {
                    if ((cachedAndThatStartedRunningInASpecificTimePeriod == null))
                    {
                        cachedAndThatStartedRunningInASpecificTimePeriod = CoreManager.MomConsole.GetIntlStr(ResourceAndThatStartedRunningInASpecificTimePeriod);
                    }
                    return cachedAndThatStartedRunningInASpecificTimePeriod;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AndWereLastModifiedInASpecificTimePeriod translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 3/24/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AndWereLastModifiedInASpecificTimePeriod
            {
                get
                {
                    if ((cachedAndWereLastModifiedInASpecificTimePeriod == null))
                    {
                        cachedAndWereLastModifiedInASpecificTimePeriod = CoreManager.MomConsole.GetIntlStr(ResourceAndWereLastModifiedInASpecificTimePeriod);
                    }
                    return cachedAndWereLastModifiedInASpecificTimePeriod;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Description translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 3/24/2008 Created
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
            /// 	[zhihaoq] 3/24/2008 Created
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
        /// 	[zhihaoq] 03/24/2008 Created
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
            /// Control ID for ClearButton
            /// </summary>
            public const string ClearButton = "clearGroupButton";

            /// <summary>
            /// Control ID for Ellipsis2Button
            /// </summary>
            public const string Ellipsis2Button = "changeTargetButton";

            /// <summary>
            /// Control ID for Ellipsis3Button
            /// </summary>
            public const string Ellipsis3Button = "changeTypeButton";

            /// <summary>
            /// Control ID for AllStaticControl
            /// </summary>
            public const string AllStaticControl = "targetObjectLabel";

            /// <summary>
            /// Control ID for EntityStaticControl
            /// </summary>
            public const string EntityStaticControl = "targetTypeLabel";

            /// <summary>
            /// Control ID for ShowDataContainedInASpecificGroupListBox
            /// </summary>
            public const string ShowDataContainedInASpecificGroupListBox = "checkboxes";

            /// <summary>
            /// Control ID for CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl
            /// </summary>
            public const string CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl = "labelDescription";

            /// <summary>
            /// Control ID for ShowAllTaskStatusStaticControl
            /// </summary>
            public const string ShowAllTaskStatusStaticControl = "labelHeader";

            /// <summary>
            /// Control ID for ShowDataContainedInASpecificGroupStaticControl
            /// </summary>
            public const string ShowDataContainedInASpecificGroupStaticControl = "label1";

            /// <summary>
            /// Control ID for ShowDataRelatedToStaticControl
            /// </summary>
            public const string ShowDataRelatedToStaticControl = "typeLabel";

            /// <summary>
            /// Control ID for CreatedBySpecificTasksStaticControl
            /// </summary>
            public const string CreatedBySpecificTasksStaticControl = "0";

            /// <summary>
            /// Control ID for AndSubmittedBySpecificPersonsStaticControl
            /// </summary>
            public const string AndSubmittedBySpecificPersonsStaticControl = "1";

            /// <summary>
            /// Control ID for AndRunningAsSpecificAccountStaticControl
            /// </summary>
            public const string AndRunningAsSpecificAccountStaticControl = "2";

            /// <summary>
            /// Control ID for AndWithSpecificStatusStaticControl
            /// </summary>
            public const string AndWithSpecificStatusStaticControl = "3";

            /// <summary>
            /// Control ID for AndWithSpecificOutputTextStaticControl
            /// </summary>
            public const string AndWithSpecificOutputTextStaticControl = "4";

            /// <summary>
            /// Control ID for AndScheduledToRunInASpecificTimePeriodStaticControl
            /// </summary>
            public const string AndScheduledToRunInASpecificTimePeriodStaticControl = "5";

            /// <summary>
            /// Control ID for AndThatStartedRunningInASpecificTimePeriodStaticControl
            /// </summary>
            public const string AndThatStartedRunningInASpecificTimePeriodStaticControl = "6";

            /// <summary>
            /// Control ID for AndWereLastModifiedInASpecificTimePeriodStaticControl
            /// </summary>
            public const string AndWereLastModifiedInASpecificTimePeriodStaticControl = "7";
            
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
