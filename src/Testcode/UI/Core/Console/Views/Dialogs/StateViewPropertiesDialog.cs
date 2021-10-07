// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="StateViewPropertiesDialog.cs">
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

    #region Interface Definition - IStateViewPropertiesDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IStateViewPropertiesDialogControls, for StateViewPropertiesDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[lucyra] 2/8/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IStateViewPropertiesDialogControls
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
        /// Read-only property to access Ellipsis2Button
        /// </summary>
        Button Ellipsis2Button
        {
            get;
        }

        /// <summary>
        /// Read-only property to access Ellipsis3Button
        /// </summary>
        Button Ellipsis3Button
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
        /// Read-only property to access CriteriaDescriptionClickTheUnderlinedValueToEditListBox
        /// </summary>
        ListBox CriteriaDescriptionClickTheUnderlinedValueToEditListBox
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
        /// Read-only property to access ShowAllStateStaticControl
        /// </summary>
        StaticControl ShowAllStateStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access WithSpecificPropertiesStaticControl
        /// </summary>
        StaticControl WithSpecificPropertiesStaticControl
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
    public class StateViewPropertiesDialog : Dialog, IStateViewPropertiesDialogControls
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
        /// Cache to hold a reference to Ellipsis2Button of type Button
        /// </summary>
        private Button cachedEllipsis2Button;

        /// <summary>
        /// Cache to hold a reference to Ellipsis3Button of type Button
        /// </summary>
        private Button cachedEllipsis3Button;

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
        /// Cache to hold a reference to CriteriaDescriptionClickTheUnderlinedValueToEditListBox of type ListBox
        /// </summary>
        private ListBox cachedCriteriaDescriptionClickTheUnderlinedValueToEditListBox;

        /// <summary>
        /// Cache to hold a reference to CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCriteriaDescriptionClickTheUnderlinedValueToEditStaticControl;

        /// <summary>
        /// Cache to hold a reference to ShowAllStateStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedShowAllStateStaticControl;

        /// <summary>
        /// Cache to hold a reference to WithSpecificPropertiesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWithSpecificPropertiesStaticControl;

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
        /// Owner of StateViewPropertiesDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public StateViewPropertiesDialog(ConsoleApp app)
            :
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion

        #region IStateViewPropertiesDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IStateViewPropertiesDialogControls Controls
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
        ///  Routine to set/get the text in control None
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
        ///  Routine to set/get the text in control NameTextBox
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
        Button IStateViewPropertiesDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, StateViewPropertiesDialog.ControlIDs.OKButton);
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
        Button IStateViewPropertiesDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, StateViewPropertiesDialog.ControlIDs.CancelButton);
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
        TextBox IStateViewPropertiesDialogControls.DescriptionTextBox
        {
            get
            {
                if ((this.cachedDescriptionTextBox == null))
                {
                    this.cachedDescriptionTextBox = new TextBox(this, StateViewPropertiesDialog.ControlIDs.DescriptionTextBox);
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
        TextBox IStateViewPropertiesDialogControls.NameTextBox
        {
            get
            {
                if ((this.cachedNameTextBox == null))
                {
                    this.cachedNameTextBox = new TextBox(this, StateViewPropertiesDialog.ControlIDs.NameTextBox);
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
        TabControl IStateViewPropertiesDialogControls.Tab0TabControl
        {
            get
            {
                if ((this.cachedTab0TabControl == null))
                {
                    this.cachedTab0TabControl = new TabControl(this, StateViewPropertiesDialog.ControlIDs.Tab0TabControl);
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
        StaticControl IStateViewPropertiesDialogControls.ShowDataContainedInASpecificGroupStaticControl
        {
            get
            {
                if ((this.cachedShowDataContainedInASpecificGroupStaticControl == null))
                {
                    this.cachedShowDataContainedInASpecificGroupStaticControl = new StaticControl(this, StateViewPropertiesDialog.ControlIDs.ShowDataContainedInASpecificGroupStaticControl);
                }
                return this.cachedShowDataContainedInASpecificGroupStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Ellipsis2Button control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IStateViewPropertiesDialogControls.Ellipsis2Button
        {
            get
            {
                if ((this.cachedEllipsis2Button == null))
                {
                    this.cachedEllipsis2Button = new Button(this, StateViewPropertiesDialog.ControlIDs.Ellipsis2Button);
                }
                return this.cachedEllipsis2Button;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Ellipsis3Button control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IStateViewPropertiesDialogControls.Ellipsis3Button
        {
            get
            {
                if ((this.cachedEllipsis3Button == null))
                {
                    this.cachedEllipsis3Button = new Button(this, StateViewPropertiesDialog.ControlIDs.Ellipsis3Button);
                }
                return this.cachedEllipsis3Button;
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
        StaticControl IStateViewPropertiesDialogControls.NoneStaticControl
        {
            get
            {
                if ((this.cachedNoneStaticControl == null))
                {
                    this.cachedNoneStaticControl = new StaticControl(this, StateViewPropertiesDialog.ControlIDs.NoneStaticControl);
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
        StaticControl IStateViewPropertiesDialogControls.EntityStaticControl
        {
            get
            {
                if ((this.cachedEntityStaticControl == null))
                {
                    this.cachedEntityStaticControl = new StaticControl(this, StateViewPropertiesDialog.ControlIDs.EntityStaticControl);
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
        StaticControl IStateViewPropertiesDialogControls.ShowDataRelatedToStaticControl
        {
            get
            {
                if ((this.cachedShowDataRelatedToStaticControl == null))
                {
                    this.cachedShowDataRelatedToStaticControl = new StaticControl(this, StateViewPropertiesDialog.ControlIDs.ShowDataRelatedToStaticControl);
                }
                return this.cachedShowDataRelatedToStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CriteriaDescriptionClickTheUnderlinedValueToEditListBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListBox IStateViewPropertiesDialogControls.CriteriaDescriptionClickTheUnderlinedValueToEditListBox
        {
            get
            {
                if ((this.cachedCriteriaDescriptionClickTheUnderlinedValueToEditListBox == null))
                {
                    this.cachedCriteriaDescriptionClickTheUnderlinedValueToEditListBox = new ListBox(this, StateViewPropertiesDialog.ControlIDs.CriteriaDescriptionClickTheUnderlinedValueToEditListBox);
                }
                return this.cachedCriteriaDescriptionClickTheUnderlinedValueToEditListBox;
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
        StaticControl IStateViewPropertiesDialogControls.CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl
        {
            get
            {
                if ((this.cachedCriteriaDescriptionClickTheUnderlinedValueToEditStaticControl == null))
                {
                    this.cachedCriteriaDescriptionClickTheUnderlinedValueToEditStaticControl = new StaticControl(this, StateViewPropertiesDialog.ControlIDs.CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl);
                }
                return this.cachedCriteriaDescriptionClickTheUnderlinedValueToEditStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ShowAllStateStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IStateViewPropertiesDialogControls.ShowAllStateStaticControl
        {
            get
            {
                if ((this.cachedShowAllStateStaticControl == null))
                {
                    this.cachedShowAllStateStaticControl = new StaticControl(this, StateViewPropertiesDialog.ControlIDs.ShowAllStateStaticControl);
                }
                return this.cachedShowAllStateStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WithSpecificPropertiesStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IStateViewPropertiesDialogControls.WithSpecificPropertiesStaticControl
        {
            get
            {
                if ((this.cachedWithSpecificPropertiesStaticControl == null))
                {
                    this.cachedWithSpecificPropertiesStaticControl = new StaticControl(this, StateViewPropertiesDialog.ControlIDs.WithSpecificPropertiesStaticControl);
                }
                return this.cachedWithSpecificPropertiesStaticControl;
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
        StaticControl IStateViewPropertiesDialogControls.DescriptionStaticControl
        {
            get
            {
                if ((this.cachedDescriptionStaticControl == null))
                {
                    this.cachedDescriptionStaticControl = new StaticControl(this, StateViewPropertiesDialog.ControlIDs.DescriptionStaticControl);
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
        StaticControl IStateViewPropertiesDialogControls.NameStaticControl
        {
            get
            {
                if ((this.cachedNameStaticControl == null))
                {
                    this.cachedNameStaticControl = new StaticControl(this, StateViewPropertiesDialog.ControlIDs.NameStaticControl);
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
        ///  Routine to click on button Ellipsis2
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
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
        /// 	[lucyra] 2/8/2006 Created
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
            /// Contains resource string for:  ShowAllState
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceShowAllState = ";Show all state;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpris" +
                "eManagement.Mom.Internal.UI.Views.StateViewCriteriaResource;CriteriaDescription";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WithSpecificProperties
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceWithSpecificProperties = "with specific properties";

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
            /// Caches the translated resource string for:  Ellipsis2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEllipsis2;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Ellipsis3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEllipsis3;

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
            /// Caches the translated resource string for:  ShowAllState
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedShowAllState;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WithSpecificProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWithSpecificProperties;

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
            /// Exposes access to the Ellipsis2 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
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
            /// 	[lucyra] 2/8/2006 Created
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
            /// Exposes access to the ShowAllState translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ShowAllState
            {
                get
                {
                    if ((cachedShowAllState == null))
                    {
                        cachedShowAllState = CoreManager.MomConsole.GetIntlStr(ResourceShowAllState);
                    }
                    return cachedShowAllState;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WithSpecificProperties translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WithSpecificProperties
            {
                get
                {
                    if ((cachedWithSpecificProperties == null))
                    {
                        cachedWithSpecificProperties = CoreManager.MomConsole.GetIntlStr(ResourceWithSpecificProperties);
                    }
                    return cachedWithSpecificProperties;
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
            /// Control ID for Ellipsis2Button
            /// </summary>
            public const string Ellipsis2Button = "changeTargetButton";

            /// <summary>
            /// Control ID for Ellipsis3Button
            /// </summary>
            public const string Ellipsis3Button = "changeTypeButton";

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
            /// Control ID for CriteriaDescriptionClickTheUnderlinedValueToEditListBox
            /// </summary>
            public const string CriteriaDescriptionClickTheUnderlinedValueToEditListBox = "checkboxes";

            /// <summary>
            /// Control ID for CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl
            /// </summary>
            public const string CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl = "labelDescription";

            /// <summary>
            /// Control ID for ShowAllStateStaticControl
            /// </summary>
            public const string ShowAllStateStaticControl = "labelHeader";

            /// <summary>
            /// Control ID for WithSpecificPropertiesStaticControl
            /// </summary>
            public const string WithSpecificPropertiesStaticControl = "0";

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
